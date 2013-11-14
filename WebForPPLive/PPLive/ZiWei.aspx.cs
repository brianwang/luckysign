using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PPLive.ZiWei;
using PPLive;
using AppCmn;

namespace WebForPPLive.PP
{
    public partial class ZiWei : System.Web.UI.Page
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
                drpLiuYear.DataSource = year;
                drpLiuYear.DataTextField = "Key";
                drpLiuYear.DataValueField = "Value";
                drpLiuYear.DataBind();
                
                Dictionary<string, string> month = new Dictionary<string, string>();
                for (int i = 1; i <= 12; i++)
                {
                    month.Add(i.ToString(), i.ToString());
                }
                drpMonth.DataSource = month;
                drpMonth.DataTextField = "Key";
                drpMonth.DataValueField = "Value";
                drpMonth.DataBind();
                drpLiuMonth.DataSource = month;
                drpLiuMonth.DataTextField = "Key";
                drpLiuMonth.DataValueField = "Value";
                drpLiuMonth.DataBind();

                Dictionary<string, string> day = new Dictionary<string, string>();
                for (int i = 1; i <= 31; i++)
                {
                    day.Add(i.ToString(), i.ToString());
                }
                drpDay.DataSource = day;
                drpDay.DataTextField = "Key";
                drpDay.DataValueField = "Value";
                drpDay.DataBind();
                drpLiuDay.DataSource = day;
                drpLiuDay.DataTextField = "Key";
                drpLiuDay.DataValueField = "Value";
                drpLiuDay.DataBind();

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
                drpLiuYear.SelectedIndex = drpLiuYear.Items.IndexOf(drpLiuYear.Items.FindByValue(DateTime.Now.Year.ToString()));
                drpLiuMonth.SelectedIndex = drpLiuMonth.Items.IndexOf(drpLiuMonth.Items.FindByValue(DateTime.Now.Month.ToString()));
                drpLiuDay.SelectedIndex = drpLiuDay.Items.IndexOf(drpLiuDay.Items.FindByValue(DateTime.Now.Day.ToString()));
                drpHour.SelectedIndex = drpHour.Items.IndexOf(drpHour.Items.FindByValue(DateTime.Now.Hour.ToString()));
                drpMinute.SelectedIndex = drpMinute.Items.IndexOf(drpMinute.Items.FindByValue(DateTime.Now.Minute.ToString()));
            }
        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            if (drpType.SelectedValue == "1")
            {
                ZiWeiMod m_ziwei = ZiWeiBiz.GetInstance().TimeToZiWei(new DateEntity(new DateTime(int.Parse(drpYear.SelectedValue), int.Parse(drpMonth.SelectedValue), int.Parse(drpDay.SelectedValue),
                    int.Parse(drpHour.SelectedValue), int.Parse(drpMinute.SelectedValue), 0)), (AppEnum.Gender)int.Parse(drpGender.SelectedValue), new int[] { 1, 1, 0 });
                ltrPan.Text = ZiWeiBiz.GetInstance().ZiWeiToHTML(m_ziwei);
            }
            else
            {
                ZiWeiMod m_ziwei = ZiWeiBiz.GetInstance().TransitToZiWei(new DateEntity(new DateTime(int.Parse(drpYear.SelectedValue), int.Parse(drpMonth.SelectedValue), int.Parse(drpDay.SelectedValue),
                    int.Parse(drpHour.SelectedValue), int.Parse(drpMinute.SelectedValue), 0)),
                    new DateEntity(new DateTime(int.Parse(drpLiuYear.SelectedValue), int.Parse(drpLiuMonth.SelectedValue), int.Parse(drpLiuDay.SelectedValue),
                    12, 0, 0)), (AppEnum.Gender)int.Parse(drpGender.SelectedValue), new int[] { 1, 1, 0, 0 });
                ltrPan.Text = ZiWeiBiz.GetInstance().ZiWeiLiuToHTML(m_ziwei);
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

        protected void drpLiuYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maxday = 0;
            if (drpLiuMonth.SelectedValue == "2")
            {
                int year = int.Parse(drpLiuYear.SelectedValue);
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
                drpLiuDay.DataSource = day;
                drpLiuDay.DataTextField = "Key";
                drpLiuDay.DataValueField = "Value";
                drpLiuDay.DataBind();
            }
        }

        protected void drpLiuMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maxday = 0;

            switch (drpLiuMonth.SelectedValue)
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
                    int year = int.Parse(drpLiuYear.SelectedValue);
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
            drpLiuDay.DataSource = day;
            drpLiuDay.DataTextField = "Key";
            drpLiuDay.DataValueField = "Value";
            drpLiuDay.DataBind();
        }
    }
}