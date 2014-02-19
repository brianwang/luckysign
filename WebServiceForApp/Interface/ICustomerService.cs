using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

using XMS.Core;

using AppMod.User;

namespace WebServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/Customer")]
    public partial interface ISSQianService
    {
        [OperationContract, WebGet(UriTemplate = "/login?uname={username}&pwd={password}")]
        [Description("登录,/login?uname={username}&pwd={password}")]
        ReturnValue<USR_CustomerShow> UserLogin(string username, string password);

        [OperationContract, WebGet(UriTemplate = "/CheckUserName?uname={username}")]
        [Description("验证用户名,/CheckUserName?uname={username}")]
        ReturnValue<bool> CheckUserName(string username);

        [OperationContract, WebGet(UriTemplate = "/CheckNickName?nickname={nickname}")]
        [Description("验证昵称,/CheckNickName?nickname={nickname}")]
        ReturnValue<bool> CheckNickName(string nickname);

        [OperationContract, WebGet(UriTemplate = "/CheckPhone?phone={phone}&sendsms={sendsms}")]
        [Description("验证手机号,/CheckPhone?phone={phone}&sendsms={sendsms}")]
        ReturnValue<bool> CheckPhone(string phone, string sendsms);

        [OperationContract, WebGet(UriTemplate = "/CheckSMSVerifyCode?phone={phone}&code={code}")]
        [Description("验证短信验证码,/CheckSMSVerifyCode?phone={phone}&code={code}")]
        ReturnValue<bool> CheckSMSVerifyCode(string phone, string code);

        [OperationContract, WebGet(UriTemplate = "/Register?email={email}&pwd={password}&phone={phone}&nickname={nickname}&fatetype={fatetype}")]
        [Description("注册,/Register?email={email}&pwd={password}&phone={phone}&nickname={nickname}&fatetype={fatetype}")]
        ReturnValue<USR_CustomerShow> Register(string email, string password, string phone, string nickname, string fatetype);

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
        ReturnValue<USR_CustomerShow> QQLogin(string code);

        [OperationContract, WebGet(UriTemplate = "/WeiboLogin?code={code}")]
        [Description("微博第三方登录,/WeiboLogin?code={code}")]
        ReturnValue<USR_CustomerShow> WeiboLogin(string code);
    }

}
