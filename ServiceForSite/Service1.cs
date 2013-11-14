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
