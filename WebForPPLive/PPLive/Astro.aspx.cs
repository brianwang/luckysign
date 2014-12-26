using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive.Astro;
using PPLive;
using AppCmn;
using AppBll.WebSys;
using AppMod.WebSys;

namespace WebForPPLive.PP
{
    public partial class Astro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dictionary<string, string> year = new Dictionary<string, string>();
                for (int i = DateTime.Now.Year - 120; i <= DateTime.Now.Year + 50; i++)
                {
                    year.Add(i.ToString(), i.ToString());
                }
                drpYear.DataSource = year;
                drpYear.DataTextField = "Key";
                drpYear.DataValueField = "Value";
                drpYear.DataBind();

                Dictionary<string, string> month = new Dictionary<string, string>();
                for (int i = 1; i <= 12; i++)
                {
                    month.Add(i.ToString(), i.ToString());
                }
                drpMonth.DataSource = month;
                drpMonth.DataTextField = "Key";
                drpMonth.DataValueField = "Value";
                drpMonth.DataBind();

                Dictionary<string, string> day = new Dictionary<string, string>();
                for (int i = 1; i <= 31; i++)
                {
                    day.Add(i.ToString(), i.ToString());
                }
                drpDay.DataSource = day;
                drpDay.DataTextField = "Key";
                drpDay.DataValueField = "Value";
                drpDay.DataBind();

                Dictionary<string, string> hour = new Dictionary<string, string>();
                for (int i = 0; i <= 23; i++)
                {
                    hour.Add(i.ToString(), i.ToString());
                }
                drpHour.DataSource = hour;
                drpHour.DataTextField = "Key";
                drpHour.DataValueField = "Value";
                drpHour.DataBind();

                Dictionary<string, string> minute = new Dictionary<string, string>();
                for (int i = 0; i <= 59; i++)
                {
                    minute.Add(i.ToString(), i.ToString());
                }
                drpMinute.DataSource = minute;
                drpMinute.DataTextField = "Key";
                drpMinute.DataValueField = "Value";
                drpMinute.DataBind();

                drpYear.SelectedIndex = drpYear.Items.IndexOf(drpYear.Items.FindByValue(DateTime.Now.Year.ToString()));
                drpMonth.SelectedIndex = drpMonth.Items.IndexOf(drpMonth.Items.FindByValue(DateTime.Now.Month.ToString()));
                drpDay.SelectedIndex = drpDay.Items.IndexOf(drpDay.Items.FindByValue(DateTime.Now.Day.ToString()));
                drpHour.SelectedIndex = drpHour.Items.IndexOf(drpHour.Items.FindByValue(DateTime.Now.Hour.ToString()));
                drpMinute.SelectedIndex = drpMinute.Items.IndexOf(drpMinute.Items.FindByValue(DateTime.Now.Minute.ToString()));

                drpDistrict1.DataSource = SYS_DistrictBll.GetInstance().GetFirstLevel(0);
                drpDistrict1.DataTextField = "Name";
                drpDistrict1.DataValueField = "SysNo";
                drpDistrict1.DataBind();
                drpDistrict1.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }


        protected void drpYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maxday = 0;
            if (drpMonth.SelectedValue == "2")
            {
                int year = int.Parse(drpYear.SelectedValue);
                if ((year % 400 == 0) || (year % 100 != 0 && year % 4 == 0))
                {
                    maxday = 29;
                }
                else
                {
                    maxday = 28;
                }
                Dictionary<string, string> day = new Dictionary<string, string>();
                for (int i = 1; i <= maxday; i++)
                {
                    day.Add(i.ToString(), i.ToString());
                }
                drpDay.DataSource = day;
                drpDay.DataTextField = "Key";
                drpDay.DataValueField = "Value";
                drpDay.DataBind();
            }
        }

        protected void drpMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maxday = 0;

            switch (drpMonth.SelectedValue)
            {
                case "1":
                case "3":
                case "5":
                case "7":
                case "8":
                case "10":
                case "12":
                    maxday = 31;
                    break;
                case "4":
                case "6":
                case "9":
                case "11":
                    maxday = 30;
                    break;
                case "2":
                    int year = int.Parse(drpYear.SelectedValue);
                    if ((year % 400 == 0) || (year % 100 != 0 && year % 4 == 0))
                    {
                        maxday = 29;
                    }
                    else
                    {
                        maxday = 28;
                    }
                    break;
            }
            Dictionary<string, string> day = new Dictionary<string, string>();
            for (int i = 1; i <= maxday; i++)
            {
                day.Add(i.ToString(), i.ToString());
            }
            drpDay.DataSource = day;
            drpDay.DataTextField = "Key";
            drpDay.DataValueField = "Value";
            drpDay.DataBind();
        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            AstroMod m_astro = new AstroMod();
            #region 设置实体各种参数
            m_astro.birth = new DateTime(int.Parse(drpYear.SelectedValue),int.Parse(drpMonth.SelectedValue),int.Parse(drpDay.SelectedValue),
                int.Parse(drpHour.SelectedValue),int.Parse(drpMinute.SelectedValue),0);
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(int.Parse(drpDistrict3.SelectedValue)));
            if (chkDaylight.Checked)
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
            m_astro.startsShow.Clear();
            for(int i=0;i<chkStar.Items.Count;i++)
            {
                if (chkStar.Items[i].Selected)
                {
                    m_astro.startsShow.Add(int.Parse(chkStar.Items[i].Value), chkStar.Items[i].Text);
                }
            }
            try
            {
                m_astro.aspectsShow.Clear();
                if (chkAspect1.Checked)
                {
                    m_astro.aspectsShow.Add(1, decimal.Parse(txtAspect1.Text));
                }
                else
                {
                    m_astro.aspectsShow.Add(1, -1);
                }
                if (chkAspect2.Checked)
                {
                    m_astro.aspectsShow.Add(2, decimal.Parse(txtAspect2.Text));
                }
                else
                {
                    m_astro.aspectsShow.Add(2, -1);
                }
                if (chkAspect3.Checked)
                {
                    m_astro.aspectsShow.Add(4, decimal.Parse(txtAspect3.Text));
                }
                else
                {
                    m_astro.aspectsShow.Add(4, -1);
                }
                if (chkAspect4.Checked)
                {
                    m_astro.aspectsShow.Add(3, decimal.Parse(txtAspect4.Text));
                }
                else
                {
                    m_astro.aspectsShow.Add(3, -1);
                }
                if (chkAspect5.Checked)
                {
                    m_astro.aspectsShow.Add(5, decimal.Parse(txtAspect5.Text));
                }
                else
                {
                    m_astro.aspectsShow.Add(5, -1);
                }
            }
            catch 
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('输入容许度格式有误');", true);
            }
            #endregion
            //生成ID并访问图片页
            Image1.ImageUrl = "AstroChart.aspx?ID=" + AstroBiz.GetInstance().SetGraphicID(m_astro) 
                + "&fa="+ m_astro.composeFile1.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\","")
                + "&fb=" + m_astro.composeFile2.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", "");
            Image1.Visible = true;
        }


        protected void drpDistrict1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistrict1.SelectedValue != "0")
            {
                drpDistrict2.DataSource = SYS_DistrictBll.GetInstance().GetSubLevel(int.Parse(drpDistrict1.SelectedValue));
                drpDistrict2.DataTextField = "Name";
                drpDistrict2.DataValueField = "SysNo";
                drpDistrict2.DataBind();
                drpDistrict2.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }

        protected void drpDistrict2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistrict2.SelectedValue != "0")
            {
                drpDistrict3.DataSource = SYS_DistrictBll.GetInstance().GetSubLevel(int.Parse(drpDistrict2.SelectedValue));
                drpDistrict3.DataTextField = "Name";
                drpDistrict3.DataValueField = "SysNo";
                drpDistrict3.DataBind();
                drpDistrict3.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }

        protected void drpDistrict3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistrict3.SelectedValue != "0")
            {
                SYS_DistrictMod m_area = SYS_DistrictBll.GetInstance().GetModel(int.Parse(drpDistrict3.SelectedValue));
                lblPosition.Text = "北纬" + m_area.Latitude + ",东经" + m_area.longitude;
                lblPosition.Visible = true;
            }
        }
    }
}
