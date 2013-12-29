using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

using XMS.Core;

using AppMod.User;
using AppDal.User;

namespace WCFServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/Customer")]
    public interface ICustomerService
    {
        [OperationContract, WebGet(UriTemplate = "/login?uname={username}&pwd={password}")]
        [Description("登录接口,/login?uname={username}&pwd={password}")]
        ReturnValue<USR_CustomerMod> UserLogin(string username, string password);

        [OperationContract, WebGet(UriTemplate = "/Register?uname={username}&pwd={password}")]
        [Description("登录接口,/login?uname={username}&pwd={password}")]
        ReturnValue<USR_CustomerMod> UserLogin(string username, string password);
    }

}
