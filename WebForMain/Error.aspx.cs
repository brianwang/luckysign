using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
namespace WebForMain
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["message"]))
                {
                    ltrErr.Text = Server.HtmlEncode(Request.QueryString["message"]);
                }
                else
                {
                    ltrErr.Text = "您访问的页面暂时无法打开";
                }
            }
        }
    }
}