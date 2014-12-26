using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebMonitor.ebThread;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using log4net;

namespace WebMonitor
{
    public class StartUdpServerLister : EBThread
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(StartUdpServerLister));

        public override void run()     
        {

            bool done = false;

            int listenPort = Convert.ToInt32(ConfigurationManager.AppSettings["ListenPort"]);
            //UdpClient listener = new UdpClient(listenPort);
            try
            {
                UdpClient listener = UdpClientManager.GetInstance(listenPort).UDPClient;
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);


                while (!done)
                {
                    try
                    {
                        _log.Info("进入等待接收UPD连接数据");
                        byte[] bytes = listener.Receive(ref groupEP);
                        string reStr = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                        _log.Info("接收到数据");
                        if (reStr.Contains("MonitorServerIP"))     //发送的数据机构为：MonitorServerIP,10.0.40.27,port,1100
                        {
                            string[] ServerInfo = reStr.Split(',');
                            if (ServerInfo.Length >= 4)
                            {
                                if (!UdpServerListInfo.ipList.Contains(ServerInfo[1]))
                                {
                                    UdpServerInfo udpserverInfo = new UdpServerInfo();
                                    udpserverInfo.ServerIp = ServerInfo[1];
                                    udpserverInfo.Port = ServerInfo[3];
                                    udpserverInfo.ConnectTime = DateTime.Now;
                                    UdpServerListInfo._udpServerInfoList.Add(udpserverInfo);
                                    UdpServerListInfo.ipList.Add(ServerInfo[1]);
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        _log .Error (ex.Message );
                        listener.Close();
                    }
                }


            }
            catch(Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
    }
}
