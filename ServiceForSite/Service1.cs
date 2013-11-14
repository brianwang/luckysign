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
            //while (Flag)
            //{
            //    localhost.AdvService la = new WindowsService1.localhost.AdvService();
            //    try
            //    {
            //        string helloname = la.Hello("Andy"); // 调用远程WebService中的方法
            //        writeInLog(helloname, false);   // 把调用返回的数据写入到文件中
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Diagnostics.Trace.Write(ex.Message);
            //        throw ex;
            //    }

            //    Thread.Sleep(5000);
            //}
        }

        
    }
}
