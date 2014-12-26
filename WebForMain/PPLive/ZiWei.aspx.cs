using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive;
namespace WebForMain.PPLive
{
    public partial class ZiWei : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(4);
            ((System.Web.UI.HtmlControls.HtmlForm)((WebForMain.Master.Main)Master).FindControl("form1")).Attributes.Add("target", "_blank");

            #region 本命盘下拉绑定
            drpLeaf.DataSource = PublicValue.GetZiWeiRunYue();
            drpLeaf.DataTextField = "value";
            drpLeaf.DataValueField = "key";
            drpLeaf.DataBind();
            drpLeaf.SelectedIndex = 2;
            #endregion
        }
    }
}