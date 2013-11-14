using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForMain.PPLive
{
    public partial class BaZi : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(4);
            ((System.Web.UI.HtmlControls.HtmlForm)((WebForMain.Master.Main)Master).FindControl("form1")).Attributes.Add("target", "_blank");

        }
    }
}