using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using XMS.Core.WCF;

namespace WebServiceForApp
{
    public class SecurityBehavior : OperationInterceptorBehavior
    {
        public bool NeedVerifyHeader
        {
            get;
            set;
        }

        public bool NeedTokenHeader
        {
            get;
            set;
        }

        public bool NeedRequestLog
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化 <see cref="VerifyOperationInterceptorBehavior"/> 类的新实例。
        /// </summary>
        public SecurityBehavior()
            : base(false)
        {
        }

        protected override OperationInterceptor CreateInvoker(OperationDescription operationDescription, IOperationInvoker invoker)
        {
            return new SecurityOperationInterceptor(operationDescription, invoker, this.ShowExceptionDetailToClient, this.NeedVerifyHeader, this.NeedTokenHeader, this.NeedRequestLog);
        }
    }
}
