using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

using AppMod.QA;
using AppBll.QA;
using AppMod.User;
using AppBll.User;
using AppCmn;
using XMS.Core;

namespace WCFServiceForApp.Task
{
    public class RewardTask : XMS.Core.TriggerTaskBase
    {
        /// <summary>
        /// 日志目录
        /// </summary>
        const string LogInfoCategory = "RewardTask";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        public RewardTask(string key, string name)
            : base(key, name) 
        {
            this.NextExecuteTime =System.DateTime.Now.AddSeconds(50); 
        }

        /// <summary>
        /// 任务实体
        /// </summary>
        /// <param name="lastExecuteTime"></param>
        public override void Execute(DateTime? lastExecuteTime)
        {
            try
            {
                LogService.Info("任务开始", LogInfoCategory);

                DataTable m_dt = QA_QuestionBll.GetInstance().GetToEndList();
                if (m_dt != null && m_dt.Rows.Count > 0)
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
                            //EventLog.WriteEntry("Hi,I'm wiseman");
                        }
                    }
                }
                LogService.Info("任务结束", LogInfoCategory);
            }
            catch (Exception ex)
            {
                LogService.Error("RewardTask 任务失败", LogInfoCategory);
                LogService.Error(ex, LogInfoCategory);
            }
            finally
            {
                this.NextExecuteTime = DateTime.Now.AddHours(1);
            }
        }
    }
}
