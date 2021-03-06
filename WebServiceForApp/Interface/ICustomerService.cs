﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using AppMod.WebSys;
using XMS.Core;

using AppMod.User;

namespace WebServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/Customer")]
    public interface ICustomerService
    {
        [OperationContract, WebGet(UriTemplate = "/test")]
        [Description("登录,/test")]
        [SecurityBehavior(NeedVerifyHeader = true, NeedTokenHeader = false, NeedRequestLog = false)]
        ReturnValue<String> Test();

        [OperationContract, WebGet(UriTemplate = "/login?uname={username}&pwd={password}")]
        [Description("登录,/login?uname={username}&pwd={password}")]
        ReturnValue<USR_CustomerMaintain> UserLogin(string username, string password);

        [OperationContract, WebGet(UriTemplate = "/GetUserInfo?uid={uid}")]
        [Description("获取用户信息,/GetUserInfo?uid={uid}")]
        ReturnValue<USR_CustomerShow> GetUserInfo(int uid);

        [OperationContract, WebGet(UriTemplate = "/CheckUser?uname={username}")]
        [Description("验证用户名,/CheckUser?uname={username}")]
        ReturnValue<bool> CheckUser(string username);

        [OperationContract, WebGet(UriTemplate = "/CheckNickName?nickname={nickname}")]
        [Description("验证昵称,/CheckNickName?nickname={nickname}")]
        ReturnValue<bool> CheckNickName(string nickname);

        [OperationContract, WebGet(UriTemplate = "/CheckPhone?phone={phone}")]
        [Description("验证手机号,/CheckPhone?phone={phone}")]
        ReturnValue<bool> CheckPhone(string phone);

        [OperationContract, WebGet(UriTemplate = "/CheckSMSVerifyCode?phone={phone}&code={code}")]
        [Description("验证短信验证码,/CheckSMSVerifyCode?phone={phone}&code={code}")]
        ReturnValue<bool> CheckSMSVerifyCode(string phone, string code);

        [OperationContract, WebGet(UriTemplate = "/Register?email={email}&pwd={password}&phone={phone}&nickname={nickname}&fatetype={fatetype}")]
        [Description("注册,/Register?email={email}&pwd={password}&phone={phone}&nickname={nickname}&fatetype={fatetype}")]
        ReturnValue<USR_CustomerMaintain> Register(string email, string password, string phone, string nickname, string fatetype);

        [OperationContract, WebGet(UriTemplate = "/FindPass?username={username}")]
        [Description("找回密码,/FindPass?username={username}")]
        ReturnValue<bool> FindPass(string username);

        [OperationContract, WebGet(UriTemplate = "/UpdateUserInfo?uid={uid}&gender={gender}&fatetype={fatetype}&intro={intro}")]
        [Description("修改用户信息,/UpdateUserInfo?uid={uid}&gender={gender}&fatetype={fatetype}&intro={intro}")]
        ReturnValue<bool> UpdateUserInfo(int uid, int gender, int fatetype, string intro);

        [OperationContract, WebGet(UriTemplate = "/GetQQLoginUrl")]
        [Description("QQ第三方登录地址获取,/GetQQLoginUrl")]
        ReturnValue<string> GetQQLoginUrl();

        [OperationContract, WebGet(UriTemplate = "/GetWeiboLoginUrl")]
        [Description("微博第三方登录地址获取,/GetWeiboLoginUrl")]
        ReturnValue<string> GetWeiboLoginUrl();

        [OperationContract, WebGet(UriTemplate = "/QQLogin?code={code}")]
        [Description("QQ第三方登录,/QQLogin?code={code}")]
        ReturnValue<USR_CustomerMaintain> QQLogin(string code);

        [OperationContract, WebGet(UriTemplate = "/WeiboLogin?code={code}")]
        [Description("微博第三方登录,/WeiboLogin?code={code}")]
        ReturnValue<USR_CustomerMaintain> WeiboLogin(string code);

        [OperationContract, WebGet(UriTemplate = "/WeiboLoginAlt?token={token}&expires={expires}")]
        [Description("微博第三方登录,/WeiboLoginAlt?token={token}&expires={expires}")]
        ReturnValue<USR_CustomerMaintain> WeiboLoginAlt(string token, long expires);

        [OperationContract, WebGet(UriTemplate = "/GetMessageByCustomer?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}")]
        [Description("获取系统消息,/GetMessageByCustomer?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}")]
        ReturnValue<PageInfo<USR_MessageMod>> GetMessageByCustomer(int pagesize, int pageindex, int customersysno);

        [OperationContract, WebGet(UriTemplate = "/GetSMSTopicByUser?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}")]
        [Description("获取私信列表,/GetSMSTopicByUser?pagesize={pagesize}&pageindex={pageindex}&customersysno={customersysno}")]
        ReturnValue<PageInfo<USR_SMSShow>> GetSMSTopicByUser(int pagesize, int pageindex, int customersysno);

        [OperationContract, WebGet(UriTemplate = "/GetSMSTalk?sysno={sysno}")]
        [Description("获取单次私信对话,/GetSMSTalk?sysno={sysno}")]
        ReturnValue<List<USR_SMSShow>> GetSMSTalk(int sysno);

        [OperationContract, WebGet(UriTemplate = "/AddSMS?fromsysno={fromsysno}&tosysno={tosysno}&title={title}&context={context}&topicsysno={topicsysno}")]
        [Description("发送私聊信息,/GAddSMS?fromsysno={fromsysno}&tosysno={tosysno}&title={title}&context={context}&topicsysno={topicsysno}")]
        ReturnValue<bool> AddSMS(int FromSysNo, int ToSysNo, string title, string context, int TopicSysNo);

        [OperationContract, WebGet(UriTemplate = "/GetCustomerMedal?customersysno={customersysno}")]
        [Description("获取用户奖章,/GetCustomerMedal?customersysno={customersysno}")]
        ReturnValue<List<USR_MedalMod>> GetCustomerMedal(int customersysno);
    }

}
