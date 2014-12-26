using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMonitor
{
    public class UdpServerInfo
    {
        private string _serverIp;
        private string _port;
        private DateTime _connectTime;

        public string ServerIp
        {
            get
            {
                return _serverIp;
            }
            set
            {
                _serverIp = value;
            }
        }

        public string Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public DateTime ConnectTime
        {
            get
            {
                return _connectTime;
            }
            set
            {
                _connectTime = value;
            }
        }
    }
}
