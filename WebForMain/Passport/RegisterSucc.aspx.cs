using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;

namespace WebForMain.Passport
{
    public partial class RegisterSucc : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetSession().CustomerEntity == null || GetSession().CustomerEntity.SysNo == AppConst.IntNull)
                {
                    Response.Redirect("../error.aspx");
                }
                Literal2.Text = "亲爱的<font color='red'>" + GetSession().CustomerEntity.NickName +"</font>，感谢您注册上上签命理网，现在可以开始体验各项会员服务了！";
                if (Request.QueryString["url"] != null)
                {
                    string returl = Request.QueryString["url"];
                    
                    if (returl.Contains(AppConfig.HomeUrl()))
                    {
                        Literal1.Text = "<font id='countdown' color='red'>10</font>秒后将跳转到<a id='returl' href='" + returl + "' style='color:blue; text-decoration:underline;'>" + returl + "</a><br />";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "reurl", "SetTimeDown();", true);
                    }
                    else
                    {
                        Response.Redirect("../error.aspx");
                    }
                }
            }
        }
    }
}