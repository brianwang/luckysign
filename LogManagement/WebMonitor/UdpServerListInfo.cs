using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMonitor
{

    public class UdpServerListInfo
    {
        public static IList<UdpServerInfo> _udpServerInfoList = new List<UdpServerInfo>();
        public static IList<string> ipList = new List<string>();
    }
}
