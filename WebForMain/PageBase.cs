using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCmn;
using AppMod.User;
using AppBll.User;

namespace WebForMain
{
    /// <summary>
    ///PageBase 的摘要说明
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        public PageBase()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            try
            {
                if (Request.Cookies["upup1000"]["uname"] != null && Request.Cookies["upup1000"]["uname"] != string.Empty &&
                    Request.Cookies["upup1000"]["psd"] != null && Request.Cookies["upup1000"]["psd"] != string.Empty)
                {
                    string username = CommonTools.Decode(Request.Cookies["upup1000"]["uname"]);
                    string password = CommonTools.Decode(Request.Cookies["upup1000"]["psd"]);
                    Passport.Login my_login = new Passport.Login();
                    my_login.LoginCheck(username, password);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                }
            }
            catch { }
        }

        public SessionInfo GetSession()
        {
            SessionInfo oSession = (SessionInfo)Session[AppConfig.CustomerSession];
            if (oSession == null)
            {
                oSession = new SessionInfo();
                Session[AppConfig.CustomerSession] = oSession;
            }
            return oSession;
        }

        public void RefreshSession()
        {
            SessionInfo oSession = (SessionInfo)Session[AppConfig.CustomerSession];
            if (oSession != null)
            {
                oSession.CustomerEntity = USR_CustomerBll.GetInstance().GetModel(oSession.CustomerEntity.SysNo);
                oSession.GradeEntity = USR_GradeBll.GetInstance().GetModel(oSession.CustomerEntity.GradeSysNo);
            }
        }

        public void SetSession(USR_CustomerMod m_user)
        {
            SessionInfo m_session = new SessionInfo();
            m_session.CustomerEntity = m_user;
            m_session.GradeEntity = USR_GradeBll.GetInstance().GetModel(m_user.GradeSysNo);
            Session[AppConfig.CustomerSession] = m_session;
        }

        protected void Login(string URL)
        {
            // 取Session变量
            SessionInfo oSession = GetSession();
            if (oSession.CustomerEntity == null || oSession.CustomerEntity.SysNo == AppConst.IntNull)
            {
                if (URL != "")
                {
                    if (URL.Contains("//"))
                    {
                        URL = URL.Split(new string[] { "//" }, 5, StringSplitOptions.None)[1];
                    }
                    URL = URL.Substring(URL.IndexOf('/') + 1);
                }

                Response.Redirect("~/Passport/Login.aspx?url=" + System.Web.HttpUtility.UrlEncode(AppConfig.HomeUrl() + URL));
            }
        }

        protected void ShowError(string message)
        {
            string url = "../Error.aspx?message=" + Server.UrlEncode(message);
            Response.Redirect(url);
        }
    }
}