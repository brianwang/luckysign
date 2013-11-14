using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using AppBll.WebSys;
using AppMod.WebSys;
using WebMonitor;

namespace WebForAnalyse
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] == "logout")
                {
                    Session[AppConfig.AdminSession] = null;
                    HttpCookie Cookie = CookiesHelper.GetCookie("upup1000Admin");
                    if (Cookie!= null && Cookie.Value!= null&& Cookie.Value != "")
                    {
                        CookiesHelper.SetCookie("upup1000Admin", "uname", "", DateTime.Now.AddYears(-1));
                        CookiesHelper.SetCookie("upup1000Admin", "psd", "", DateTime.Now.AddYears(-1));
                    }
                }
                try
                {
                    if (Request.Cookies["upup1000Admin"]["uname"] != null && Request.Cookies["upup1000Admin"]["uname"] != string.Empty &&
                        Request.Cookies["upup1000Admin"]["psd"] != null && Request.Cookies["upup1000Admin"]["psd"] != string.Empty)
                    {
                        string username = CommonTools.Decode(Request.Cookies["upup1000Admin"]["uname"]);
                        string password = CommonTools.Decode(Request.Cookies["upup1000Admin"]["psd"]);
                        LoginCheck(username, password);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    }
                }catch{}
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = txtUname.Text.Trim();
            string password = txtPass.Text.Trim();

            LoginCheck(username, password);
        }


        public void LoginCheck(string username, string password)
        {
            SYS_AdminMod m_admin = SYS_AdminBll.GetInstance().CheckAdmin(username, password);
            if (m_admin.CustomerSysNo != AppConst.IntNull)//COOKIES验证成功
            {
                WebForAnalyse. SessionInfo m_session = new SessionInfo();
                m_session.AdminEntity = m_admin;
                m_session.PrivilegeDt = SYS_AdminBll.GetInstance().GetAdminPrivilege(m_admin.CustomerSysNo);
                Session[AppConfig.AdminSession] = m_session;
                //记住我
                if (CheckBox1.Checked)
                {
                    HttpCookie Cookie = CookiesHelper.GetCookie("upup1000Admin");
                    if (Cookie== null || Cookie.Value == null || Cookie.Value == "")
                    {
                        Cookie = new HttpCookie("upup1000Admin");
                        Cookie.Values.Add("uname", CommonTools.Encode(username));
                        Cookie.Values.Add("psd", CommonTools.Encode(password));
                        //设置Cookie过期时间
                        Cookie.Expires = DateTime.Now.AddYears(50);
                        CookiesHelper.AddCookie(Cookie);
                    }
                    else
                    {
                        CookiesHelper.SetCookie("upup1000Admin", "uname", CommonTools.Encode(username), DateTime.Now.AddYears(50));
                        CookiesHelper.SetCookie("upup1000Admin", "psd", CommonTools.Encode(password), DateTime.Now.AddYears(50));
                    }
                }
                LogManagement.getInstance().WriteTrace(m_session.AdminEntity, "Login", "IP:" + Request.UserHostAddress + "|AdminID:" + m_session.AdminEntity.Username);
                //跳转
                if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
                {
                    Response.Redirect(Request.QueryString["url"]);
                }
                else
                {
                    Response.Redirect("Celebrity/Celebritys.aspx");
                }
            }
        }

        public void Logout()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            SessionInfo m_session = (SessionInfo)Session[AppConfig.AdminSession];
            m_session = null;
            HttpContext.Current.Response.Cookies["upup1000Admin"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}