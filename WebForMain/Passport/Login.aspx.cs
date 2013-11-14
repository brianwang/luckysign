using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using WebMonitor;
using AppMod.User;
using AppBll.User;

namespace WebForMain.Passport
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] == "logout")
                {
                    Session[AppConfig.CustomerSession] = null;
                    HttpCookie Cookie = CookiesHelper.GetCookie("upup1000");
                    if (Cookie != null && Cookie.Value != null && Cookie.Value != "")
                    {
                        CookiesHelper.SetCookie("upup1000", "uname", "", DateTime.Now.AddYears(-1));
                        CookiesHelper.SetCookie("upup1000", "psd", "", DateTime.Now.AddYears(-1));
                    }
                }
                else if (Request.QueryString["error"] != null && Request.QueryString["error"] != "")
                {
                    try
                    {
                        email.Text = Request.QueryString["email"];
                        password1Tip.InnerText = AppEnum.GetErrorType(int.Parse(Request.QueryString["error"]));
                        return;
                    }
                    catch
                    { }
                }
                try
                {
                    if (Request.Cookies["upup1000"]["uname"] != null && Request.Cookies["upup1000"]["uname"] != string.Empty &&
                        Request.Cookies["upup1000"]["psd"] != null && Request.Cookies["upup1000"]["psd"] != string.Empty)
                    {
                        string username = CommonTools.Decode(Request.Cookies["upup1000"]["uname"]);
                        string password = CommonTools.Decode(Request.Cookies["upup1000"]["psd"]);
                        LoginCheck(username, password);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    }
                }
                catch { }
                Unnamed1.Focus();
            }

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string username = email.Text.Trim();
            string password = password1.Text.Trim();
            #region 验证邮箱有效性
            #endregion

            LoginCheck(username, password);
        }


        public void LoginCheck(string username, string password)
        {
            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(username, password);
            if (m_user.SysNo != AppConst.IntNull)//COOKIES验证成功
            {
                SetSession(m_user);
                //记住我
                if (CheckBox1.Checked)
                {
                    HttpCookie Cookie = CookiesHelper.GetCookie("upup1000");
                    if (Cookie == null || Cookie.Value == null || Cookie.Value == "")
                    {
                        Cookie = new HttpCookie("upup1000");
                        Cookie.Values.Add("uname", CommonTools.Encode(username));
                        Cookie.Values.Add("psd", CommonTools.Encode(password));
                        //设置Cookie过期时间
                        Cookie.Expires = DateTime.Now.AddYears(50);
                        CookiesHelper.AddCookie(Cookie);
                    }
                    else
                    {
                        CookiesHelper.SetCookie("upup1000", "uname", CommonTools.Encode(username), DateTime.Now.AddYears(50));
                        CookiesHelper.SetCookie("upup1000", "psd", CommonTools.Encode(password), DateTime.Now.AddYears(50));
                    }
                }
                LogManagement.getInstance().WriteTrace("前台会员登录", "Login", "IP:" + Request.UserHostAddress + "|UserID:" + GetSession().CustomerEntity.Email);
                //跳转
                if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
                {
                    Response.Redirect(Request.QueryString["url"]);
                }
                else
                {
                    Response.Redirect("../Qin/View.aspx?id=" + m_user.SysNo);
                }
            }
            else
            {
                password1Tip.InnerHtml = AppEnum.GetErrorType(2);
            }
        }

        public void Logout()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            SessionInfo m_session = (SessionInfo)Session[AppConfig.CustomerSession];
            m_session = null;
            HttpContext.Current.Response.Cookies["upup1000"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
            {
                Response.Redirect("Register.aspx?url="+Request.QueryString["url"]);
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }
    }
}