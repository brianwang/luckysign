using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForAdmin
{
    public partial class Welcome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl); 
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "上上签后台管理系统";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Welcome);
            #endregion
            if (!IsPostBack)
            {
                if (Request.QueryString["forbidden"] != null && Request.QueryString["forbidden"] != "")
                {
                    try
                    {
                        DateTime fobidden = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            int.Parse(Request.QueryString["forbidden"].Substring(0, 2)), int.Parse(Request.QueryString["forbidden"].Substring(2, 2)), int.Parse(Request.QueryString["forbidden"].Substring(4, 2)));
                        if (DateTime.Now.Subtract(fobidden).TotalMinutes <= 1.0)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "forbidden", "alert('您的账号没有访问此模块的权限，如需开通请联系雪雪！');", true);
                        }
                    }
                    catch
                    { }
                }
            }
        }
    }
}