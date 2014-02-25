using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XMS.Core;
using AppCmn;
using AppMod.User;
using AppBll.User;
using System.IO;
using System.Configuration;
using System.Data;

namespace WebServiceForApp
{
    public partial class SSQianService : ISSQianService
    {
        public ReturnValue<String> Test()
        {
            return ReturnValue<string>.Get200OK("OK");
        }

        public ReturnValue<USR_CustomerMaintain> UserLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new BusinessException("用户名不能为空");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new BusinessException("密码不能为空");
            }
            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(username, password);
            if (m_user.SysNo != -999999)
            {
                USR_CustomerMaintain ret = new USR_CustomerMaintain();
                m_user.MemberwiseCopy(ret);
                return ReturnValue<USR_CustomerMaintain>.Get200OK(ret);
            }
            else
            {
                throw new BusinessException("账号或密码错误，请重新输入！");
            }
        }

        public ReturnValue<bool> CheckUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new BusinessException("用户名或手机号不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(username);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<bool>.Get200OK(true);
            }
            else
            {
                m_user = USR_CustomerBll.GetInstance().CheckPhone(username);
                if (m_user.SysNo != -999999)
                {
                    return ReturnValue<bool>.Get200OK(true);
                }
                else
                {
                    return ReturnValue<bool>.Get200OK(false);
                }
            }
        }

        public ReturnValue<bool> CheckNickName(string nickname)
        {
            if (string.IsNullOrEmpty(nickname))
            {
                throw new BusinessException("昵称不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckNickName(nickname);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<bool>.Get200OK(true);
            }
            else
            {
                return ReturnValue<bool>.Get200OK(false);
            }
        }

        public ReturnValue<bool> CheckPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                throw new BusinessException("手机号不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckPhone(phone);
            if (m_user.SysNo != -999999)
            {
                throw new BusinessException("该手机号已注册");
            }
            else
            {
                //生成6位随机验证码
                string[] arr = ("A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,2,3,4,5,6,7,8,9").Split(',');
                string Password = "";
                int randValue = -1;
                Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
                for (int i = 0; i < 6; i++)
                {
                    randValue = rand.Next(0, arr.Length - 1);
                    Password += arr[randValue];
                }
                #region 发送短信

                Password = "111111";    //测试验证码为111111
                XMS.Core.Container.CacheService.LocalCache.SetItem(AppConst.APIRegionName, "SMSVerifyCode" + phone, Password, 600);
                return ReturnValue<bool>.Get200OK(true);

                #endregion
            }
        }

        public ReturnValue<bool> CheckSMSVerifyCode(string phone, string code)
        {
            try
            {
                if (code.ToUpper() == XMS.Core.Container.CacheService.LocalCache.GetItem(AppConst.APIRegionName, "SMSVerifyCode" + phone).ToString().ToUpper())
                {
                    return ReturnValue<bool>.Get200OK(true);
                }
                else
                {
                    return ReturnValue<bool>.Get200OK(false);
                }
            }
            catch
            {
                throw new BusinessException("验证码已过期或手机号有误！");
            }

        }

        public ReturnValue<bool> FindPass(string username)
        {
            USR_CustomerMod m_user = new USR_CustomerMod();
            //生成6位随机新密码,并MD5加密;
            string[] arr = ("A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,2,3,4,5,6,7,8,9").Split(',');
            string Password = "";
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < 6; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                Password += arr[randValue];
            }
            if (string.IsNullOrEmpty(username))
            {
                throw new BusinessException("手机号或邮箱为空");
            }
            else
            {
                if (Util.IsCellNumber(username))
                {
                    m_user = USR_CustomerBll.GetInstance().CheckPhone(username);
                    if (m_user.SysNo == AppConst.IntNull)
                    {
                        throw new BusinessException("用户不存在！");
                    }
                    m_user.Password = Password;
                    USR_CustomerBll.GetInstance().UpDate(m_user);

                    #region 发送短信
                    throw new BusinessException("短信接口还未申请！");
                    #endregion

                }
                else if (Util.IsEmailAddress(username))
                {
                    m_user = USR_CustomerBll.GetInstance().CheckUser(username);
                    if (m_user.SysNo == AppConst.IntNull)
                    {
                        throw new BusinessException("用户不存在！");
                    }
                    m_user.Password = Password;
                    USR_CustomerBll.GetInstance().UpDate(m_user);

                    #region SetEmailContent
                    string mailBody = CommonTools.ReadHtmFile(Container.ConfigService.GetAppSetting<string>("AdvFolderPath","") + @"EmailTemplate/FindPassword.htm");
                    mailBody.Replace("@nickname", m_user.NickName);
                    mailBody.Replace("@password", m_user.Password);
                    //mailBody.Replace("@userid", m_user.SysNo.ToString());
                    //mailBody.Replace("@md5",CommonTools.md5(m_user.NickName+m_user.Password+DateTime.Now.ToString("yyyyMMddHHmmss"),32);
                    string mailadd = m_user.Email;
                    string mailSubject = "上上签密码找回";
                    #endregion SetEmailContent

                    //邮件发送
                    TCPMail oMail = new TCPMail();
                    oMail.Html = true;
                    if (oMail.Send(mailadd,
                        mailSubject,
                        mailBody))
                    {
                        return ReturnValue<bool>.Get200OK(true);
                    }
                    else
                    {
                        throw new BusinessException("发送邮件失败！");
                    }
                }
                else
                {
                    throw new BusinessException("手机号或邮箱不合法");
                }
            }
        }

        public ReturnValue<USR_CustomerMaintain> Register(string email, string password, string phone, string nickname, string fatetype)
        {
            #region 验证输入
            if (email!=null&&email.DoTrim() != "")
            {
                USR_CustomerMod m_userrr = USR_CustomerBll.GetInstance().CheckUser(email);
                if (m_userrr.SysNo != AppConst.IntNull)
                {
                    throw new BusinessException("该邮箱已注册，请重新输入!");
                }
            }
            else if (phone != null && phone.DoTrim() != "")
            {
                if (!Util.IsCellNumber(phone))
                {
                    throw new BusinessException("手机号格式有误，请重新输入!");
                }
                USR_CustomerMod m_userrr = USR_CustomerBll.GetInstance().CheckPhone(phone);
                if (m_userrr.SysNo != AppConst.IntNull)
                {
                    throw new BusinessException("该手机号已注册，请重新输入!");
                }
            }
            if (CommonTools.HasForbiddenWords(nickname))
            {
                throw new BusinessException("您的昵称中有违禁字符,请重新输入!");
            }
            USR_CustomerMod m_userr = USR_CustomerBll.GetInstance().CheckNickName(nickname);
            if (m_userr.SysNo != AppConst.IntNull)
            {
                throw new BusinessException("该昵称已被占用，请尝试使用其他昵称!");
            }
            try
            {
                int fate = int.Parse(fatetype);
            }
            catch
            {
                throw new BusinessException("该昵称已被占用，请尝试使用其他昵称!");
            }

            #endregion

            #region 保存数据
            USR_CustomerMod m_user = new USR_CustomerMod();
           
                m_user.Email = email.DoTrim();
                m_user.Phone = phone.DoTrim();
                m_user.FateType = int.Parse(fatetype);
                m_user.GradeSysNo = AppConst.OriginalGrade; ;
                m_user.NickName = nickname.DoTrim();
                m_user.Password = password.DoTrim();
                m_user.RegTime = DateTime.Now;
                m_user.Point = AppConst.OriginalPoint;
                m_user.Photo = AppConst.OriginalPhoto;
                m_user.LastLoginTime = DateTime.Now;
                if (Container.ConfigService.GetAppSetting<string>("RegisterEmailCheck","false").ToLower() == "true")
                {
                    m_user.Status = (int)AppEnum.State.prepare;
                }
                else
                {
                    m_user.Status = (int)AppEnum.State.normal;
                }

                m_user.Credit = 0;
                m_user.birth = AppConst.DateTimeNull;
                m_user.IsShowBirth = 1;
                m_user.IsStar = 0;
                m_user.BestAnswer = 0;
                m_user.TotalAnswer = 0;
                m_user.TotalQuest = 0;
                m_user.HomeTown = AppConst.IntNull;
                m_user.Intro = AppConst.OriginalIntro;
                m_user.Signature = AppConst.OriginalSign;
                m_user.Exp = 0;
                m_user.TotalReply = 0;
                m_user.HasNewInfo = 0;

                m_user.SysNo = USR_CustomerBll.GetInstance().Add(m_user);
           
            #endregion

            #region 发送验证邮件
            if (Container.ConfigService.GetAppSetting<string>("RegisterEmailCheck","false").ToLower() == "true")
            {

            }
            #endregion
            if (m_user.SysNo != -999999)
            {
                USR_CustomerMaintain ret = new USR_CustomerMaintain();
                m_user.MemberwiseCopy(ret);
                return ReturnValue<USR_CustomerMaintain>.Get200OK(ret);
            }
            else
            {
                throw new Exception();
            }

        }

        public ReturnValue<string> GetQQLoginUrl()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Container.ConfigService.GetAppSetting<string>("ThirdLoginFilePath",""));
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//AppID");
            string returnurl = Container.ConfigService.GetAppSetting<string>("HomeUrl", "") + "Passport/ThirdLogin.aspx";

            return ReturnValue<string>.Get200OK("https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=" + node.InnerText + "&redirect_uri=" + returnurl + "&state=test");
        }

        public ReturnValue<string> GetWeiboLoginUrl()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Container.ConfigService.GetAppSetting<string>("ThirdLoginFilePath", ""));
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//AppID");
            XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//Key");
            string returnurl = Container.ConfigService.GetAppSetting<string>("HomeUrl", "") + "Passport/ThirdLogin.aspx";
            var oauth = new NetDimension.Weibo.OAuth(node.InnerText, node1.InnerText, returnurl);

            //第一步获取新浪授权页面的地址
            var authUrl = oauth.GetAuthorizeURL(); //VS2008需要指定全部4个参数，这里是VS2010等支持“可选参数”的开发环境的写法
            // 第二步访问这个地址。
            return ReturnValue<string>.Get200OK(authUrl);
        }

        public ReturnValue<USR_CustomerMaintain> WeiboLogin(string code)
        {
            //新浪微博回调
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Container.ConfigService.GetAppSetting<string>("ThirdLoginFilePath", ""));
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//AppID");
            XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//Key");
            var oauth = new NetDimension.Weibo.OAuth(node.InnerText, node1.InnerText, Container.ConfigService.GetAppSetting<string>("HomeUrl", "") + "Passport/ThirdLogin.aspx");

            var accessToken = oauth.GetAccessTokenByAuthorizationCode(code);
            var uid = "";
            if (!string.IsNullOrEmpty(accessToken.Token))
            {
                var Sina = new NetDimension.Weibo.Client(oauth);
                uid = Sina.API.Account.GetUID(); //调用API中获取UID的方法
            }

            USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetUserByThirdID(uid);
            if (m_customer != null && m_customer.SysNo != AppConst.IntNull)
            {
                m_customer.LastLoginTime = DateTime.Now;
                USR_CustomerBll.GetInstance().UpDate(m_customer);

                USR_CustomerMaintain ret = new USR_CustomerMaintain();
                m_customer.MemberwiseCopy(ret);
                return ReturnValue<USR_CustomerMaintain>.Get200OK(ret);
            }

            USR_ThirdLoginMod m_third = new USR_ThirdLoginMod();
            m_third.OpenID = uid;
            m_third.AccessKey = code;
            m_third.ThirdType = (int)AppEnum.ThirdLoginType.weibo;
            USR_CustomerMod m_user = new USR_CustomerMod();
            try
            {
                m_user.Email = "";
                m_user.FateType = (int)AppEnum.FateType.astro;
                m_user.GradeSysNo = AppConst.OriginalGrade; ;
                m_user.NickName = uid;
                m_user.Password = "";
                m_user.RegTime = DateTime.Now;
                m_user.Point = AppConst.OriginalPoint;
                m_user.Photo = AppConst.OriginalPhoto;
                m_user.LastLoginTime = DateTime.Now;
                if (Container.ConfigService.GetAppSetting<string>("RegisterEmailCheck", "false").ToLower() == "true")
                {
                    m_user.Status = (int)AppEnum.State.prepare;
                }
                else
                {
                    m_user.Status = (int)AppEnum.State.normal;
                }

                m_user.Credit = 0;
                m_user.birth = AppConst.DateTimeNull;
                m_user.IsShowBirth = 1;
                m_user.IsStar = 0;
                m_user.BestAnswer = 0;
                m_user.TotalAnswer = 0;
                m_user.TotalQuest = 0;
                m_user.HomeTown = AppConst.IntNull;
                m_user.Intro = AppConst.OriginalIntro;
                m_user.Signature = AppConst.OriginalSign;
                m_user.Exp = 0;
                m_user.TotalReply = 0;

                m_user.SysNo = USR_CustomerBll.GetInstance().Add(m_user);

                m_third.CustomerSysNo = m_user.SysNo;
                USR_ThirdLoginBll.GetInstance().Add(m_third);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            USR_CustomerMaintain rett = new USR_CustomerMaintain();
            m_customer.MemberwiseCopy(rett);
            return ReturnValue<USR_CustomerMaintain>.Get200OK(rett);
        }

        public ReturnValue<USR_CustomerMaintain> QQLogin(string code)
        {
            //QQ回调
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Container.ConfigService.GetAppSetting<string>("ThirdLoginFilePath", ""));
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//AppID");
            XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//Key");
            //获取Access Token
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://graph.qq.com/oauth2.0/token?grant_type=authorization_code&client_id=" + node.InnerText + "&client_secret=" + node1.InnerText
                + "&code=" + code + "&redirect_uri=" + Container.ConfigService.GetAppSetting<string>("HomeUrl", "") + "Passport/ThirdLogin.aspx");
            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.UTF8;
            StreamReader reader = new StreamReader(res.GetResponseStream(), encoding);
            string ret = reader.ReadToEnd();
            string retcode = "";
            int timespan = 0;
            try
            {
                retcode = ret.Split(new char[] { '&' })[0].Split(new char[] { '=' })[1];
                timespan = int.Parse(ret.Split(new char[] { '&' })[1].Split(new char[] { '=' })[1]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //获取OpenID
            req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://graph.qq.com/oauth2.0/me?access_token=" + retcode);
            res = (System.Net.HttpWebResponse)req.GetResponse();
            reader = new StreamReader(res.GetResponseStream(), encoding);
            ret = reader.ReadToEnd();
            string openid = "";
            try
            {
                openid = ret.Split(new char[] { '"' })[7];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetUserByThirdID(openid);
            if (m_customer != null && m_customer.SysNo != AppConst.IntNull)
            {
                m_customer.LastLoginTime = DateTime.Now;
                USR_CustomerBll.GetInstance().UpDate(m_customer);

                USR_CustomerMaintain rett = new USR_CustomerMaintain();
                m_customer.MemberwiseCopy(rett);
                return ReturnValue<USR_CustomerMaintain>.Get200OK(rett);
            }

            m_customer = new USR_CustomerMod();

            //获取用户信息
            req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(@"https://graph.qq.com/user/get_user_info?access_token=" + retcode +

"&oauth_consumer_key=" + node.InnerXml +

"&openid=" + openid);
            res = (System.Net.HttpWebResponse)req.GetResponse();
            reader = new StreamReader(res.GetResponseStream(), encoding);
            ret = reader.ReadToEnd();

            try
            {
                m_customer.NickName = ret.Split(new char[] { ':', ',' })[7].Replace(@"""", "").DoTrim();
                m_customer.Photo = ret.Split(new string[] { @""":", "," }, StringSplitOptions.None)[19].Replace(@"""", "").Replace(@"\", "").DoTrim();
                if (USR_CustomerBll.GetInstance().CheckNickName(m_customer.NickName).SysNo != AppConst.IntNull)
                {
                    m_customer.NickName += "-"+openid.Substring(0, 6);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            #region 保存数据
            USR_ThirdLoginMod m_third = new USR_ThirdLoginMod();
            m_third.OpenID = openid;
            m_third.AccessKey = retcode;
            m_third.ExpireTime = DateTime.Now.AddSeconds(timespan);
            m_third.ThirdType = (int)AppEnum.ThirdLoginType.qq;

            USR_CustomerMod m_user = new USR_CustomerMod();
            try
            {
                m_user.Email = "";
                m_user.FateType = (int)AppEnum.FateType.astro;
                m_user.GradeSysNo = AppConst.OriginalGrade; ;
                m_user.Password = "";
                m_user.RegTime = DateTime.Now;
                m_user.Point = AppConst.OriginalPoint;
                m_user.LastLoginTime = DateTime.Now;
                if (Container.ConfigService.GetAppSetting<string>("RegisterEmailCheck", "false").ToLower() == "true")
                {
                    m_user.Status = (int)AppEnum.State.prepare;
                }
                else
                {
                    m_user.Status = (int)AppEnum.State.normal;
                }

                m_user.Credit = 0;
                m_user.birth = AppConst.DateTimeNull;
                m_user.IsShowBirth = 1;
                m_user.IsStar = 0;
                m_user.BestAnswer = 0;
                m_user.TotalAnswer = 0;
                m_user.TotalQuest = 0;
                m_user.HomeTown = AppConst.IntNull;
                m_user.Intro = AppConst.OriginalIntro;
                m_user.Signature = AppConst.OriginalSign;
                m_user.Exp = 0;
                m_user.TotalReply = 0;

                m_user.SysNo = USR_CustomerBll.GetInstance().Add(m_user);

                m_third.CustomerSysNo = m_user.SysNo;
                USR_ThirdLoginBll.GetInstance().Add(m_third);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            #endregion


            USR_CustomerMaintain rettt = new USR_CustomerMaintain();
            m_customer.MemberwiseCopy(rettt);
            return ReturnValue<USR_CustomerMaintain>.Get200OK(rettt);
        }


        #region Map方法

        public USR_CustomerShow MapUSR_CustomerShow(DataRow input)
        {
            USR_CustomerShow ret = new USR_CustomerShow();
            ret.BestAnswer = int.Parse(input["BestAnswer"].ToString());
            ret.birth = (DateTime.Parse(input["birth"].ToString()).ToMilliSecondsFrom1970L())/1000;
            ret.Credit = int.Parse(input["Credit"].ToString());
            ret.Exp = int.Parse(input["Exp"].ToString());
            ret.FateType = int.Parse(input["FateType"].ToString());
            ret.Gender = int.Parse(input["Gender"].ToString());
            ret.GradeSysNo = int.Parse(input["GradeSysNo"].ToString());
            ret.HasNewInfo = int.Parse(input["HasNewInfo"].ToString());
            ret.HomeTown = int.Parse(input["HomeTown"].ToString());
            ret.Intro = input["Intro"].ToString();
            ret.IsShowBirth = int.Parse(input["IsShowBirth"].ToString());
            ret.IsStar = int.Parse(input["IsStar"].ToString());
            ret.LastLoginTime = (DateTime.Parse(input["LastLoginTime"].ToString()).ToMilliSecondsFrom1970L())/1000;
            ret.NickName = input["NickName"].ToString();
            ret.Photo = input["Photo"].ToString();
            ret.Point = int.Parse(input["Point"].ToString());
            ret.RegTime = (DateTime.Parse(input["RegTime"].ToString()).ToMilliSecondsFrom1970L())/1000;
            ret.Signature = input["Signature"].ToString();
            ret.Status = int.Parse(input["Status"].ToString());
            ret.SysNo = int.Parse(input["SysNo"].ToString());
            ret.TotalAnswer = int.Parse(input["TotalAnswer"].ToString());
            ret.TotalQuest = int.Parse(input["TotalQuest"].ToString());
            ret.TotalReply = int.Parse(input["TotalReply"].ToString());
            ret.TotalTalk = int.Parse(input["TotalTalk"].ToString());
            ret.TotalTalkReply = int.Parse(input["TotalTalkReply"].ToString());

            return ret;
        }
        #endregion
    }
}
