using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace WebMonitor
{
    class UdpClientManager
    {
        private UdpClientManager(int port_)
        {
            if (_udpclient != null)
            {
                _udpclient.Close();
            }
            try
            {
                _udpclient = new UdpClient(port_);
            }
            catch(Exception ex)
            {
                //string i = ex.Message;
                //_udpclient.Close();
                //_udpclient = new UdpClient(port_);
            }
        }
        private UdpClient _udpclient;
        private static UdpClientManager _instance;
        public static UdpClientManager GetInstance(int port_)
        {
            if (_instance == null)
            {
                _instance = new UdpClientManager(port_);
            }
            return _instance;
        }
        public UdpClient UDPClient
        {
            get { return _udpclient; }
        }
    }

     
}
