using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using XMS.Core;
using XMS.Core.Logging;
using XMS.Core.Configuration;
using XMS.Core.WCF;
using XMS.Core.Tasks;

namespace WCFHost
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();

            ManageableServiceHostManager.Instance.RegisterService(typeof(WebServiceForApp.CustomerService));
            ManageableServiceHostManager.Instance.RegisterService(typeof(WebServiceForApp.QAService));
            ManageableServiceHostManager.Instance.RegisterService(typeof(WebServiceForApp.PPLiveService));
            ManageableServiceHostManager.Instance.RegisterService(typeof(WebServiceForApp.SystemService));
        }

        protected override void OnStart(string[] args)
        {
            ManageableServiceHostManager.Instance.Start();
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            ManageableServiceHostManager.Instance.Stop();
            base.OnStop();
        }
    }
}
