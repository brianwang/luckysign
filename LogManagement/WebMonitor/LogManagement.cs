using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using log4net;

namespace WebMonitor
{
    /// <summary>
    /// 优先级
    /// </summary>
    internal struct Priority
    {
        public const int Lowest = 0;
        public const int Low = 1;
        public const int Normal = 2;
        public const int High = 3;
        public const int Highest = 4;
    }

    /// <summary>
    /// 日志类别 - 必须对应于ENTERPRISE LIBRARY中的类别，确保在CONFIG文件中定义了以下类别
    /// </summary>
    internal struct Category
    {
        public const string Exception = "Exception";
        public const string Trace = "Trace";
        public const string General = "General";
        public const string Warning = "Warning";
    }

    public class LogManagement
    {

        private static LogManagement _instance = null;
        private static readonly ILog _log = log4net.LogManager.GetLogger(typeof(LogManagement));

        public static LogManagement getInstance()
        {
            if (_instance == null)
            {
                _instance = new LogManagement();
                return _instance;
            }
            else
                return _instance;
        }

        private LogManagement()
        {
            _log.Info("启动连接监听");

            StartUdpServerLister startudpServer = new StartUdpServerLister();
            startudpServer.start();
            _log.Info("连接成功");
            //UdpServerManager udpservermanager = new UdpServerManager();
           
            //udpservermanager.start();
        }
        /// <summary>
        /// 提醒日志
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="category">所属类别</param>
        /// <param name="client">客户端信息</param>
        public void WriteWarning(string message, string category, string client)
        {
            LogEntry log = new LogEntry();
            log.Categories.Add(Category.Warning);

            log.Message = client + "-|-" + message;
            log.Priority = Priority.Normal;
            log.MachineName = Environment.MachineName;
            log.ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            log.ProcessId = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
            log.Title = category;
            log.TimeStamp = DateTime.Now;
            _log.Info(log);
            Logger.Write(log);

        }

        /// <summary>
        /// 业务跟踪日志
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="category">所属类别</param>
        /// <param name="client">客户端信息</param>
        public void WriteTrace(object message, string category, string client)
        {

            LogEntry log = new LogEntry();
            log.Categories.Add(Category.Trace);

            log.Message = client + "-|-" + message.ToString();
            log.Priority = Priority.Normal;
            log.MachineName = Environment.MachineName;
            log.ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            log.ProcessId = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
            log.Title = category;
            log.TimeStamp = DateTime.Now;
            _log.Info(log);
            Logger.Write(log);

        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="category">所属类别</param>
        /// <param name="client">客户端信息</param>
        public void WriteException(Exception message, string category, string client)
        {
            WriteException(message, category, client, "");
        }

        /// <summary>
        /// 错误日志 2
        /// </summary>
        /// <param name="message">信息内容</param>
        public void WriteException(string message)
        {
            if (!IsIgnore(message.Trim()))
            {
                LogEntry log = new LogEntry();
                log.Categories.Add(Category.Exception);

                log.Message =  message;
                log.Priority = Priority.Highest;
                log.MachineName = Environment.MachineName;
                log.ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                log.ProcessId = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
                log.Title = "N/A";
                log.TimeStamp = DateTime.Now;
                _log.Info(log);
                _log.Error(log);
                Logger.Write(log);
            }
        }

        /// <summary>
        /// 错误日志 3
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="category">所属类别</param>
        /// <param name="client">客户端信息</param>
        public void WriteException(Exception message, string category, string client, string additionalMessage)
        {
            if (!IsIgnore(message.Message.Trim()))
            {

                LogEntry log = new LogEntry();
                log.Categories.Add(Category.Exception);

                log.Message = client + "-|-" + message.Message + "-|-" + message.StackTrace;
                log.Priority = Priority.Highest;
                log.MachineName = Environment.MachineName;
                log.ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                log.ProcessId = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
                log.Title = category;
                log.TimeStamp = DateTime.Now;
                log.ExtendedProperties.Add("Additional Info", additionalMessage);
                _log.Info(log);
                _log.Error(log);
                Logger.Write(log);
            }
        }
        /// <summary>
        /// 一般日志
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="category">所属类别</param>
        /// <param name="client">客户端信息</param>
        public void WriteGeneral(string message, string category, string client)
        {
            LogEntry log = new LogEntry();
            log.Categories.Add(Category.General);

            log.Message = client + "-|-" + message;
            log.Priority = Priority.Normal;
            log.MachineName = Environment.MachineName;
            log.ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            log.ProcessId = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
            log.Title = category;
            log.TimeStamp = DateTime.Now;
            _log.Info(log);
            Logger.Write(log);
        }

        /// <summary>
        ///  Ignore some messages based on message content
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool IsIgnore(string message)
        {
            bool result = false;
            //if(message.Trim().ToLower().StartsWith(ExceptionFilter.ThreadAborted))
            //{
            //    result = true;
            //}

            return result;
        }

    }
}
