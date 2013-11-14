using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive;

namespace WebForMain.PPLive
{
    public partial class Astro : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(4);
            if (!IsPostBack)
            {
                ((System.Web.UI.HtmlControls.HtmlForm)((WebForMain.Master.Main)Master).FindControl("form1")).Attributes.Add("target", "_blank");
                SortedList<int, string> timezone = new SortedList<int, string>();
                timezone.Add(0, "零时区");
                for (int i = 1; i < 13; i++)
                {
                    timezone.Add(0 - i, "东" + i + "区");
                }
                for (int i = 1; i < 13; i++)
                {
                    timezone.Add(i, "西" + i + "区");
                }

                SortedList<int, string> aspect = new SortedList<int, string>();
                for (int i = 1; i < 11; i++)
                {
                    aspect.Add(i, i.ToString("0.00"));
                }
                aspect.Add(-1, "隐藏");

                #region 本命盘下拉绑定
                drpTimeZone1.DataSource = timezone;
                drpTimeZone1.DataTextField = "value";
                drpTimeZone1.DataValueField = "key";
                drpTimeZone1.DataBind();
                drpTimeZone1.SelectedIndex = 4;

                drpAspect0.DataSource = aspect;
                drpAspect0.DataTextField = "value";
                drpAspect0.DataValueField = "key";
                drpAspect0.DataBind();
                drpAspect0.SelectedIndex = 6;
                drpAspect180.DataSource = aspect;
                drpAspect180.DataTextField = "value";
                drpAspect180.DataValueField = "key";
                drpAspect180.DataBind();
                drpAspect180.SelectedIndex = 5;
                drpAspect120.DataSource = aspect;
                drpAspect120.DataTextField = "value";
                drpAspect120.DataValueField = "key";
                drpAspect120.DataBind();
                drpAspect120.SelectedIndex = 5;
                drpAspect90.DataSource = aspect;
                drpAspect90.DataTextField = "value";
                drpAspect90.DataValueField = "key";
                drpAspect90.DataBind();
                drpAspect90.SelectedIndex = 5;
                drpAspect60.DataSource = aspect;
                drpAspect60.DataTextField = "value";
                drpAspect60.DataValueField = "key";
                drpAspect60.DataBind();
                drpAspect60.SelectedIndex = 3;
                #endregion

                #region 组合盘下拉绑定
                drpTimeZone2.DataSource = timezone;
                drpTimeZone2.DataTextField = "value";
                drpTimeZone2.DataValueField = "key";
                drpTimeZone2.DataBind();
                drpTimeZone2.SelectedIndex = 4;

                drpCompareType.DataSource = PublicValue.GetAstroZuhe();
                drpCompareType.DataTextField = "value";
                drpCompareType.DataValueField = "key";
                drpCompareType.DataBind();
                #endregion


                //((ScriptManager)Master.FindControl("ContentPlaceHolder1").FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1); 

            }
        }


    }
}