using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCmn;
using AppMod.WebSys;

namespace WebForAdmin
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
                if (Request.Cookies["upup1000Admin"]["uname"] != null && Request.Cookies["upup1000Admin"]["uname"] != string.Empty &&
                    Request.Cookies["upup1000Admin"]["psd"] != null && Request.Cookies["upup1000Admin"]["psd"] != string.Empty)
                {
                    string username = CommonTools.Decode(Request.Cookies["upup1000Admin"]["uname"]);
                    string password = CommonTools.Decode(Request.Cookies["upup1000Admin"]["psd"]);
                    Default my_default = new Default();
                    my_default.LoginCheck(username, password);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                }
            }
            catch { }
        }

        public SessionInfo GetSession()
        {
            SessionInfo oSession = (SessionInfo)Session[AppConfig.AdminSession];
            if (oSession == null)
            {
                oSession = new SessionInfo();
                Session[AppConfig.AdminSession] = oSession;
            }
            return oSession;
        }
        protected void Login(string URL)
        {
            // 取Session变量
            SessionInfo oSession = GetSession();
            if (oSession.AdminEntity == null || oSession.AdminEntity.SysNo == AppConst.IntNull)
            {
                if (URL != "")
                {
                    if (URL.Contains("//"))
                    {
                        URL = URL.Split(new string[] { "//" }, 5, StringSplitOptions.None)[1];
                    }
                    URL = URL.Substring(URL.IndexOf('/') + 1);
                }

                Response.Redirect("~/Default.aspx?url=" + System.Web.HttpUtility.UrlEncode(AppConfig.HomeUrl() + URL));
            }
        }

        protected void CheckPrivilege(string URL)
        {
            // 取Session变量
            SessionInfo oSession = GetSession();
            if (oSession.PrivilegeDt == null || oSession.PrivilegeDt.Count == 0)
            {
                Response.Redirect("~/Welcome.aspx?forbidden=" + DateTime.Now.ToString("HHmmss"));
            }
            else
            {
                foreach (SYS_PrivilegeMod tmp in oSession.PrivilegeDt.Values)
                {
                    if (URL.Contains(tmp.URL))
                    {
                        return;
                    }
                }
                Response.Redirect("~/Welcome.aspx?forbidden=" + DateTime.Now.ToString("HHmmss"));
            }
        }

        protected void ShowError(string message)
        {
            string url = "../Error.aspx?message=" + Server.UrlEncode(message);
            Response.Redirect(url);
        }
    }
}