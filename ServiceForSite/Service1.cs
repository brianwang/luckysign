using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AppMod.QA;
using AppBll.QA;
using System.Transactions;
using AppMod.User;
using AppBll.User;
using AppCmn;

namespace ServiceForSite
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 服务启动的操作
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            StartEndQuest();
        }

        /// <summary>
        /// 服务停止的操作
        /// </summary>
        protected override void OnStop()
        {
            try
            {

                ThreadEndQuest.Abort();

                Flag = false;

                System.Diagnostics.Trace.Write("线程停止");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex.Message);
            }
        }

        private Thread ThreadEndQuest;
        private bool Flag;

        private void StartEndQuest()
        {
            try
            {
                // 标准形式

                //ThreadStart NewThreadStart = new ThreadStart(VoidName);
                //Thread NewThead = new Thread(NewThreadStart);
                //NewThead.Start();

                ThreadEndQuest = new Thread(new ThreadStart(EndQuest));
                ThreadEndQuest.Start();
                System.Diagnostics.Trace.Write("线程任务开始");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex.Message);
                throw ex;
            }
        }

        private void EndQuest()
        {
            while (Flag)
            {
                DataTable m_dt = QA_QuestionBll.GetInstance().GetToEndList();
                if (m_dt == null || m_dt.Rows.Count == 0)
                {

                }
                else
                {
                    try
                    {
                        int total = 0;
                        for (int i = 0; i < m_dt.Rows.Count; i++)
                        {
                            int sysno = int.Parse(m_dt.Rows[i]["sysno"].ToString());
                            DataTable m_answer = QA_AnswerBll.GetInstance().GetListByQuest(1, 10000, sysno, ref total);
                            m_answer.Columns.Add("commcount");
                            m_answer.Columns.Add("score");
                            int totalcomm = 0;
                            int totallenth = 0;
                            int totallove = 0;
                            int[,] tmpresult = new int[3, 2];
                            for (int j = 0; j < m_answer.Rows.Count; j++)
                            {
                                totallenth += m_answer.Rows[j]["Context"].ToString().Length;
                                totallove += int.Parse(m_answer.Rows[j]["Love"].ToString());
                                DataTable m_comm = QA_CommentBll.GetInstance().GetListByAnswer(int.Parse(m_answer.Rows[j]["SysNo"].ToString()));
                                totalcomm += m_comm.Rows.Count;
                                m_answer.Rows[j]["commcount"] = m_comm.Rows.Count.ToString();
                                m_answer.Rows[j]["score"] = 0;
                            }

                            for (int j = 0; j < m_answer.Rows.Count; j++)
                            {
                                double tmp = Convert.ToDouble(m_answer.Rows[j]["Context"].ToString().Length * m_answer.Rows.Count) / Convert.ToDouble(totallenth);
                                tmp -= 1;
                                if (tmp > 0)
                                {
                                    m_answer.Rows[j]["score"] = int.Parse(m_answer.Rows[j]["score"].ToString()) + Math.Floor(tmp * 10) * Math.Floor(tmp * 10) * 10;
                                }

                                tmp = Convert.ToDouble(m_answer.Rows[j]["Love"].ToString()) * Convert.ToDouble(m_answer.Rows.Count) / Convert.ToDouble(totallove);
                                tmp -= 1;
                                if (tmp > 0)
                                {
                                    m_answer.Rows[j]["score"] = int.Parse(m_answer.Rows[j]["score"].ToString()) + Math.Floor(tmp * 10) * Math.Floor(tmp * 10) * 5;
                                }

                                tmp = Convert.ToDouble(m_answer.Rows[j]["commcount"].ToString()) * Convert.ToDouble(m_answer.Rows.Count) / Convert.ToDouble(totalcomm);
                                tmp -= 1;
                                if (tmp > 0)
                                {
                                    m_answer.Rows[j]["score"] = int.Parse(m_answer.Rows[j]["score"].ToString()) + Math.Floor(tmp * 10) * Math.Floor(tmp * 10) * 3;
                                }

                            }

                            TransactionOptions options = new TransactionOptions();
                            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                            options.Timeout = TransactionManager.DefaultTimeout;

                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
                            {

                                m_answer.DefaultView.Sort = "award asc, score desc";
                                DataTable dtTemp = m_answer.DefaultView.ToTable();
                                if (dtTemp.Rows.Count == 1)
                                {
                                    QA_AnswerBll.GetInstance().SetAward(QA_AnswerBll.GetInstance().GetModel(int.Parse(dtTemp.Rows[0]["SysNo"].ToString())), QA_QuestionBll.GetInstance().GetModel(int.Parse(m_dt.Rows[i]["SysNo"].ToString())), int.Parse(m_dt.Rows[i]["Award"].ToString()) - QA_AnswerBll.GetInstance().GetUsedAward(int.Parse(dtTemp.Rows[0]["SysNo"].ToString())));
                                }
                                else
                                {
                                    int awardremain = int.Parse(m_dt.Rows[i]["Award"].ToString()) - QA_AnswerBll.GetInstance().GetUsedAward(int.Parse(dtTemp.Rows[0]["SysNo"].ToString()));
                                    int award1 = awardremain * int.Parse(m_dt.Rows[0]["score"].ToString()) / (int.Parse(m_dt.Rows[0]["score"].ToString()) + int.Parse(m_dt.Rows[1]["score"].ToString()));
                                    int award2 = awardremain - award1;
                                    QA_AnswerBll.GetInstance().SetAward(QA_AnswerBll.GetInstance().GetModel(int.Parse(dtTemp.Rows[0]["SysNo"].ToString())), QA_QuestionBll.GetInstance().GetModel(int.Parse(m_dt.Rows[i]["SysNo"].ToString())), award1);
                                    QA_AnswerBll.GetInstance().SetAward(QA_AnswerBll.GetInstance().GetModel(int.Parse(dtTemp.Rows[1]["SysNo"].ToString())), QA_QuestionBll.GetInstance().GetModel(int.Parse(m_dt.Rows[i]["SysNo"].ToString())), award2);
                                }

                                USR_MessageMod m_notice = new USR_MessageMod();
                                m_notice.CustomerSysNo = int.Parse(m_dt.Rows[i]["CustomerSysNo"].ToString());
                                m_notice.Title = AppConst.AutoSendAward.Replace("@url", AppConfig.HomeUrl() + "Quest/Question.aspx?id=" + m_dt.Rows[i]["SysNo"].ToString())
                                    .Replace("@question", m_dt.Rows[i]["Title"].ToString());
                                m_notice.DR = 0;
                                m_notice.IsRead = 0;
                                m_notice.Context = "";
                                m_notice.TS = DateTime.Now;
                                m_notice.Type = (int)AppEnum.MessageType.notice;
                                USR_MessageBll.GetInstance().AddMessage(m_notice);

                                scope.Complete();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.Write(ex.Message);
                        throw ex;
                    }

                }

                Thread.Sleep(5000);
            }
        }


    }
}
