using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XMS.Core;
using AppCmn;
using AppMod.User;
using AppDal.User;
using AppBll.User;
using System.IO;
using System.Configuration;

namespace WCFServiceForApp
{
    public class CustomerService : ICustomerService
    {
        public ReturnValue<USR_CustomerMod> UserLogin(string username, string password)
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
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new BusinessException("账号或密码错误，请重新输入！");
            }
        }

        public ReturnValue<USR_CustomerMod> CheckUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new BusinessException("用户名不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(username);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new BusinessException("用户不存在！");
            }
        }

        public ReturnValue<USR_CustomerMod> CheckNickName(string nickname)
        {
            if (string.IsNullOrEmpty(nickname))
            {
                throw new BusinessException("昵称不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckNickName(nickname);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new BusinessException("用户不存在！");
            }
        }

        public ReturnValue<USR_CustomerMod> CheckPhone(string phone,string sms)
        {
            if (string.IsNullOrEmpty(phone))
            {
                throw new BusinessException("手机号不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckPhone(phone);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                if (sms == "1" || sms.ToUpper() == "TRUE")
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
                    throw new BusinessException(Password);
                    #endregion
                    throw new BusinessException("用户不存在！");
                }
                else
                {
                    throw new BusinessException("用户不存在！");
                }
            }
        }

        public ReturnValue<bool> FindPass(string email, string phone)
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

            if (!string.IsNullOrEmpty(phone) )
            {
                m_user = USR_CustomerBll.GetInstance().CheckPhone(phone);
                m_user.Password = Password;
                USR_CustomerBll.GetInstance().UpDate(m_user);

                #region 发送短信
                throw new BusinessException("短信接口还未申请！");
                #endregion

            }
            else if (!string.IsNullOrEmpty(email))
            {
                m_user = USR_CustomerBll.GetInstance().CheckUser(email);
                m_user.Password = Password;
                USR_CustomerBll.GetInstance().UpDate(m_user);
                
                #region SetEmailContent
                string mailBody = CommonTools.ReadHtmFile(AppConfig.AdvFolderPath + @"EmailTemplate/FindPassword.htm");
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
                throw new BusinessException("手机号与邮箱不能全为空");
            }

             
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<bool>.Get200OK(true);
            }
            else
            {
                throw new BusinessException("用户不存在！");
            }
        }

        public ReturnValue<USR_CustomerMod> Register(string email, string password, string phone, string nickname, string fatetype)
        {
            #region 验证输入
            if (email.Trim() != "")
            {
                USR_CustomerMod m_userrr = USR_CustomerBll.GetInstance().CheckUser(email);
                if (m_userrr.SysNo != AppConst.IntNull)
                {
                    throw new BusinessException("该邮箱已注册，请重新输入!");
                }
            }
            else if (phone.Trim() != "")
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
            try
            {
                m_user.Email = email.Trim();
                m_user.Phone = phone.Trim();
                m_user.FateType = int.Parse(fatetype);
                m_user.GradeSysNo = AppConst.OriginalGrade; ;
                m_user.NickName = nickname.Trim();
                m_user.Password = password.Trim();
                m_user.RegTime = DateTime.Now;
                m_user.Point = AppConst.OriginalPoint;
                m_user.Photo = AppConst.OriginalPhoto;
                m_user.LastLoginTime = DateTime.Now;
                if (AppConfig.RegisterEmailCheck.ToLower() == "true")
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion

            #region 发送验证邮件
            if (AppConfig.RegisterEmailCheck.ToLower() == "true")
            {

            }
            #endregion
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new Exception();
            }

        }

        public ReturnValue<string> GetQQLoginUrl()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigurationManager.AppSettings["ThirdLoginFilePath"]);
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//AppID");
            string returnurl = AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx";

            return ReturnValue<string>.Get200OK("https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=" + node.InnerText + "&redirect_uri=" + returnurl + "&state=test");
        }

        public ReturnValue<string> GetWeiboLoginUrl()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigurationManager.AppSettings["ThirdLoginFilePath"]);
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//AppID");
            XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//Key");
            string returnurl = AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx";
            var oauth = new NetDimension.Weibo.OAuth(node.InnerText, node1.InnerText, returnurl);

            //第一步获取新浪授权页面的地址
            var authUrl = oauth.GetAuthorizeURL(); //VS2008需要指定全部4个参数，这里是VS2010等支持“可选参数”的开发环境的写法
            // 第二步访问这个地址。
            return ReturnValue<string>.Get200OK(authUrl);
        }

        public ReturnValue<USR_CustomerMod> WeiboLogin(string code)
        {
            //新浪微博回调
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigurationManager.AppSettings["ThirdLoginFilePath"]);
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//AppID");
            XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//Key");
            var oauth = new NetDimension.Weibo.OAuth(node.InnerText, node1.InnerText, AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx");

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
                return ReturnValue<USR_CustomerMod>.Get200OK(m_customer);
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
                if (AppConfig.RegisterEmailCheck.ToLower() == "true")
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

            return ReturnValue<USR_CustomerMod>.Get200OK(m_customer);
        }

        public ReturnValue<USR_CustomerMod> QQLogin(string code)
        {
            //QQ回调
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigurationManager.AppSettings["ThirdLoginFilePath"]);
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//AppID");
            XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//Key");
            //获取Access Token
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://graph.qq.com/oauth2.0/token?grant_type=authorization_code&client_id=" + node.InnerText + "&client_secret=" + node1.InnerText
                + "&code=" + code + "&redirect_uri=" + AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx");
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
                return ReturnValue<USR_CustomerMod>.Get200OK(m_customer);
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
                m_customer.NickName = ret.Split(new char[] { ':', ',' })[7].Replace(@"""", "").Trim();
                m_customer.Photo = ret.Split(new string[] { @""":", "," }, StringSplitOptions.None)[19].Replace(@"""", "").Replace(@"\", "").Trim();
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
                if (AppConfig.RegisterEmailCheck.ToLower() == "true")
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

            return ReturnValue<USR_CustomerMod>.Get200OK(m_customer);
        }
    }
}
