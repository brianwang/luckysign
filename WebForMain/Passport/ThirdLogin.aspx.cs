using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Text;
using AppCmn;
using AppBll.User;
using AppMod.User;
using WebMonitor;

namespace WebForMain.Passport
{
    public partial class ThirdLogin : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReceiveThirdRequest();
            }
        }

        protected void ReceiveThirdRequest()
        {
            if (Request.QueryString["code"] != null && Request.QueryString["code"] != "" && Request.QueryString["state"] != null)
            {
                //QQ回调
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data/ThirdLogin.xml")));
                XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//AppID");
                XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//Key");
                //获取Access Token
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://graph.qq.com/oauth2.0/token?grant_type=authorization_code&client_id=" + node.InnerText + "&client_secret=" + node1.InnerText
                    + "&code=" + Request.QueryString["code"] + "&redirect_uri=" + AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx");
                System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();
                Encoding encoding = Encoding.UTF8;
                StreamReader reader = new StreamReader(res.GetResponseStream(), encoding);
                string ret = reader.ReadToEnd();
                string code = "";
                int timespan = 0;
                try
                {
                    code = ret.Split(new char[] { '&' })[0].Split(new char[] { '=' })[1];
                    timespan = int.Parse(ret.Split(new char[] { '&' })[1].Split(new char[] { '=' })[1]);
                }
                catch(Exception ex)
                {
                    LogManagement.getInstance().WriteException(ex, "WebForMain.ThirdLogin", Request.UserHostAddress);
                    ShowError("系统故障，请联系管理员");
                }
                //获取OpenID
                req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://graph.qq.com/oauth2.0/me?access_token=" + code);
                res = (System.Net.HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream(), encoding);
                ret = reader.ReadToEnd();
                string openid = "";
                try
                {
                    openid = ret.Split(new char[] { '"' })[7];
                }
                catch
                {
                    ShowError("系统故障，请联系管理员");
                }
                //获取用户信息
                req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(@"https://graph.qq.com/user/get_user_info?access_token=" +code+

"&oauth_consumer_key=" + node.InnerXml +

"&openid=" + openid);
                res = (System.Net.HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream(), encoding);
                ret = reader.ReadToEnd();

                try
                {
                    ViewState["nickname"] = ret.Split(new char[] { ':',',' })[7].Replace(@"""","").Trim();
                    ViewState["photo"] = ret.Split(new string[] { @""":", "," }, StringSplitOptions.None)[19].Replace(@"""", "").Replace(@"\", "").Trim();
                    if (USR_CustomerBll.GetInstance().CheckNickName(ViewState["nickname"].ToString().Trim()).SysNo != AppConst.IntNull)
                    {
                        newname.Style["display"] = "";
                    }
                }
                catch
                {
                    ShowError("系统故障，请联系管理员");
                }


                USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetUserByThirdID(openid);
                if (m_customer != null && m_customer.SysNo != AppConst.IntNull)
                {
                    SetSession(m_customer);
                    m_customer.LastLoginTime = DateTime.Now;
                    USR_CustomerBll.GetInstance().UpDate(m_customer);
                    if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
                    {
                        Response.Redirect(Request.QueryString["url"]);
                    }
                    else
                    {
                        Response.Redirect("../Qin/View/" + m_customer.SysNo);
                    }
                    return;
                }

                ViewState["openid"] = openid;
                ViewState["expire"] = timespan;
                ViewState["code"] = code;
                ViewState["type"] = "qq";
            }

            else if (Request.QueryString["code"] != null && Request.QueryString["code"] != "")
            {
                //新浪微博回调
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data/ThirdLogin.xml")));
                XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//AppID");
                XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//Key");
                var oauth = new NetDimension.Weibo.OAuth(node.InnerText, node1.InnerText, AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx");

                var accessToken = oauth.GetAccessTokenByAuthorizationCode(Request.QueryString["code"]);
                var uid = "";
                if (!string.IsNullOrEmpty(accessToken.Token))
                {
                    var Sina = new NetDimension.Weibo.Client(oauth);
                    uid = Sina.API.Account.GetUID(); //调用API中获取UID的方法
                    var userinfo = Sina.API.Users.Show(uid: uid);
                    Response.Write(userinfo);
                }

                USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetUserByThirdID(uid);
                if (m_customer != null && m_customer.SysNo != AppConst.IntNull)
                {
                    SetSession(m_customer);
                    m_customer.LastLoginTime = DateTime.Now;
                    USR_CustomerBll.GetInstance().UpDate(m_customer);
                    if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
                    {
                        Response.Redirect(Request.QueryString["url"]);
                    }
                    else
                    {
                        Response.Redirect("../Qin/View/" + m_customer.SysNo);
                    }
                    return;
                }

                ViewState["openid"] = uid;
                ViewState["code"] = Request.QueryString["code"];
                ViewState["type"] = "weibo";
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //if (!ValidateEmail())
            //{
            //    return;
            //}
            if (!ValidateNickName())
            {
                return;
            }

            #region 获取用户第三方数据
            USR_ThirdLoginMod m_third = new USR_ThirdLoginMod();
            switch (ViewState["type"].ToString())
            {
                case "qq":
                    m_third.OpenID = ViewState["openid"].ToString();
                    m_third.AccessKey = ViewState["code"].ToString();
                    m_third.ExpireTime = DateTime.Now.AddSeconds(int.Parse(ViewState["expire"].ToString()));
                    m_third.ThirdType = (int)AppEnum.ThirdLoginType.qq;
                    break;
                case "weibo":
                    m_third.OpenID = ViewState["openid"].ToString();
                    m_third.AccessKey = ViewState["code"].ToString();
                    m_third.ThirdType = (int)AppEnum.ThirdLoginType.weibo;
                    break;
                default:
                    ShowError("系统故障，请联系管理员");
                    break;
            }
            #endregion

            #region 保存数据
            USR_CustomerMod m_user = new USR_CustomerMod();
            try
            {
                m_user.Email = "";
                m_user.FateType = int.Parse(drpType.SelectedValue);
                m_user.GradeSysNo = AppConst.OriginalGrade; ;
                m_user.NickName = ViewState["nickname"].ToString();
                m_user.Password = "";
                m_user.RegTime = DateTime.Now;
                m_user.Point = AppConst.OriginalPoint;
                m_user.Photo = ViewState["photo"].ToString();
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
                LogManagement.getInstance().WriteException(ex, "WebForMain.Register", Request.UserHostAddress);
                return;
            }
            #endregion

            #region 登陆状态设置
            if (!(AppConfig.RegisterEmailCheck.ToLower() == "true"))
            {
                SessionInfo m_session = new SessionInfo();
                m_session.CustomerEntity = m_user;
                m_session.GradeEntity = USR_GradeBll.GetInstance().GetModel(m_user.SysNo);
                Session[AppConfig.CustomerSession] = m_session;
            }
            #endregion
            if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
            {
                Response.Redirect("RegisterSucc.aspx?url=" + Request.QueryString["url"]);
            }
            else
            {
                Response.Redirect("RegisterSucc.aspx");
            }

        }

        //private bool ValidateEmail()
        //{
        //    USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(email.Text.Trim());
        //    if (m_user.SysNo != AppConst.IntNull)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "emailwrong", "document.getElementById('ctl00_ContentPlaceHolder1_emailTip').innerHTML = '该邮箱已注册，请重新输入!';document.getElementById('ctl00_ContentPlaceHolder1_emailTip').style['display']='block';document.getElementById('ctl00_ContentPlaceHolder1_emailTip').className='onError';", true);
        //        return false;
        //    }
        //    return true;
        //}
        private bool ValidateNickName()
        {
            if (CommonTools.HasForbiddenWords(name.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "namewrong", "document.getElementById('ctl00_ContentPlaceHolder1_nameTip').innerHTML = '您的昵称中有违禁字符,请重新输入!';document.getElementById('ctl00_ContentPlaceHolder1_nameTip').style['display']='block';document.getElementById('ctl00_ContentPlaceHolder1_nameTip').className='onError';", true);
                return false;
            }
            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckNickName(name.Text.Trim());
            if (m_user.SysNo != AppConst.IntNull)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "emailwrong", "document.getElementById('ctl00_ContentPlaceHolder1_nameTip').innerHTML = '该昵称已被占用，请尝试使用其他昵称!';document.getElementById('ctl00_ContentPlaceHolder1_nameTip').style['display']='block';document.getElementById('ctl00_ContentPlaceHolder1_nameTip').className='onError';", true);
                return false;
            }

            return true;
        }

    }
}