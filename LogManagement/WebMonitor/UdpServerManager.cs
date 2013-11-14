using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Configuration;
using WebMonitor.ebThread;
using System.Threading;

namespace WebMonitor
{
    public class UdpServerManager : EBThread
    {

        public override void run()     //每个连上来超过8个小时的监视器都将关闭,每小时判定一次
        {
            
            while (true)
            {

                try
                {
                    DateTime comparetime = DateTime.Now;

                    foreach (UdpServerInfo info in UdpServerListInfo._udpServerInfoList)
                    {
                        if (info.ConnectTime.AddDays(8) >= comparetime)
                        {
                            UdpServerListInfo._udpServerInfoList.Remove(info);                            
                        }
                    }
                    
                    Thread.Sleep(3600000);
                }
                catch (Exception ex)
                {

                   
                }
            }
        }
    }
}
