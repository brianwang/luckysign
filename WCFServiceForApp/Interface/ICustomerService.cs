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
        [Description("登录,/login?uname={username}&pwd={password}")]
        ReturnValue<USR_CustomerMod> UserLogin(string username, string password);

        [OperationContract, WebGet(UriTemplate = "/CheckUserName?uname={username}")]
        [Description("验证用户名,/CheckUserName?uname={username}")]
        ReturnValue<USR_CustomerMod> CheckUserName(string username);

        [OperationContract, WebGet(UriTemplate = "/CheckNickName?nickname={nickname}")]
        [Description("验证昵称,/CheckNickName?nickname={nickname}")]
        ReturnValue<USR_CustomerMod> CheckNickName(string nickname);

        [OperationContract, WebGet(UriTemplate = "/CheckPhone?phone={phone}&sendsms={sendsms}")]
        [Description("验证手机号,/CheckPhone?phone={phone}&sendsms={sendsms}")]
        ReturnValue<USR_CustomerMod> CheckPhone(string phone, string sendsms);

        [OperationContract, WebGet(UriTemplate = "/Register?email={email}&pwd={password}&phone={phone}&nickname={nickname}&fatetype={fatetype}")]
        [Description("验证昵称,/Register?email={email}&pwd={password}&phone={phone}&nickname={nickname}&fatetype={fatetype}")]
        ReturnValue<USR_CustomerMod> Register(string email, string password, string phone, string nickname, string fatetype);

        [OperationContract, WebGet(UriTemplate = "/FindPass?username={username}")]
        [Description("找回密码,/FindPass?username={username}")]
        ReturnValue<bool> FindPass(string username);

        [OperationContract, WebGet(UriTemplate = "/GetQQLoginUrl")]
        [Description("QQ第三方登录地址获取,/GetQQLoginUrl")]
        ReturnValue<string> GetQQLoginUrl();

        [OperationContract, WebGet(UriTemplate = "/GetWeiboLoginUrl")]
        [Description("微博第三方登录地址获取,/GetWeiboLoginUrl")]
        ReturnValue<string> GetWeiboLoginUrl();

        [OperationContract, WebGet(UriTemplate = "/QQLogin?code={code}")]
        [Description("QQ第三方登录,/QQLogin?code={code}")]
        ReturnValue<USR_CustomerMod> QQLogin(string code);

        [OperationContract, WebGet(UriTemplate = "/WeiboLogin?code={code}")]
        [Description("微博第三方登录,/WeiboLogin?code={code}")]
        ReturnValue<USR_CustomerMod> WeiboLogin(string code);
    }

}
