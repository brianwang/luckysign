using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.Net;
using System.Net.Sockets;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.EnterpriseLibrary.Logging;


namespace WebMonitor
{
    /// <summary>
    /// 扩展CustomTraceListenerData，创建自己的LISTENER
    /// </summary>
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class UDPTrace : CustomTraceListener
    {
        public System.Diagnostics.EventLog el = new EventLog();
        public UdpClient[] udp;   //多个监视端可以连过来。
        public IPEndPoint groupEP;

        public UDPTrace()
            : base()
        {

        }
        /// <summary>
        /// 初始化UDP，确保在CONFIG中有UDPTraceIP以及UDPTraceIP值，也就是UDP接收服务器的IP地址及端口号
        /// </summary>
        public void InitUDP()
        {
            el.Source = "ServicesLog";
            el.Log = "ServicesLog";

            try
            {
                string ip;
                string port;

                //多重连接
                if (UdpServerListInfo._udpServerInfoList.Count > 0)
                {
                    udp = new UdpClient[UdpServerListInfo._udpServerInfoList.Count];
                }
                else
                {
                    udp = new UdpClient[1];
                    
                }
                if (UdpServerListInfo._udpServerInfoList.Count > 0)
                {
                    for (int i = 0; i < UdpServerListInfo._udpServerInfoList.Count; i++)
                    {
                        udp[i] = new UdpClient();
                        ip = UdpServerListInfo._udpServerInfoList[i].ServerIp;
                        port = UdpServerListInfo._udpServerInfoList[i].Port;
                        groupEP = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt16(port));
                        udp[i].Connect(groupEP);
                    }
                }
                else
                {
                    ip = "127.0.0.1";
                    port = "1100";
                    udp[0] = new UdpClient();
                    groupEP = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt16(port));
                    udp[0].Connect(groupEP);
                }
             
            }
            catch (Exception e)
            {
                el.WriteEntry(e.Message);
            }

        }

        /// <summary>
        /// 重构TraceData方法
        /// </summary>
        /// <param name="eventCache"></param>
        /// <param name="source"></param>
        /// <param name="eventType"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            InitUDP();

            if (data is LogEntry && this.Formatter != null)
            {
                this.WriteLine(this.Formatter.Format(data as LogEntry));
            }
            else
            {
                this.WriteLine(data.ToString());
            }

            this.Close();
        }

        /// <summary>
        /// 重构Write方法
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message)
        {
            try
            {
                //Console.Write(message);

                el.WriteEntry(message);

                byte[] bytes = Encoding.Default.GetBytes(message);
                //byte[] bytes = Encoding.UTF8.GetEncoder().GetBytes(message);
                //udp.Send(bytes, bytes.Length, groupEP);
                for (int i = 0; i < udp.Length; i++)
                {
                    udp[i].Send(bytes, bytes.Length);
                }
                //el.WriteEntry("Send UDP", EventLogEntryType.SuccessAudit);

            }
            catch (Exception e)
            {
                el.WriteEntry(e.Message, EventLogEntryType.Error);
            }

        }

        /// <summary>
        /// 重构WriteLine方法
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            try
            {
                // Write formatted message
                Console.WriteLine(message);

                el.WriteEntry(message);

                //byte[] bytes = Encoding.UTF8.GetBytes(message);
                byte[] bytes = Encoding.Default.GetBytes(message);
                //udp.Send(bytes, bytes.Length, groupEP);
                for (int i = 0; i < udp.Length; i++)
                {
                    udp[i].Send(bytes, bytes.Length);
                }
                //el.WriteEntry("Send UDP", EventLogEntryType.SuccessAudit);
            }
            catch (Exception e)
            {
                el.WriteEntry(e.Message, EventLogEntryType.Error);
            }


        }

        /// <summary>
        /// 重构Close方法
        /// </summary>
        public override void Close()
        {
            // Leave the group
            //udp.DropMulticastGroup(groupAddress);

            for (int i = 0; i < udp.Length; i++)
            {
                udp[i].Close();
            }
            el.Close();
            base.Close();

        }

        protected override void Dispose(bool disposing)
        {
            // Leave the group
            // udp.DropMulticastGroup(groupAddress);

            for (int i = 0; i < udp.Length; i++)
            {
                udp[i].Close();
            }
            el.Close();
            base.Close();

            base.Dispose(disposing);
        }
    }
}
