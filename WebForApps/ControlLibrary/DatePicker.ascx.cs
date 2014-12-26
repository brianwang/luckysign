using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace WebForApps.ControlLibrary
{
    public partial class DatePicker : System.Web.UI.UserControl
    {
        private int type = 5;
        private DateTime _time = DateTime.Now;
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

                if (type > 3)
                {
                    Dictionary<string, string> hour = new Dictionary<string, string>();
                    for (int i = 0; i <= 23; i++)
                    {
                        hour.Add(i.ToString(), i.ToString());
                    }
                    drpHour.DataSource = hour;
                    drpHour.DataTextField = "Key";
                    drpHour.DataValueField = "Value";
                    drpHour.DataBind();
                    drpHour.Visible = true;
                    shi.Text = "时";

                    if (type > 4)
                    {
                        Dictionary<string, string> minute = new Dictionary<string, string>();
                        for (int i = 0; i <= 59; i++)
                        {
                            minute.Add(i.ToString(), i.ToString());
                        }
                        drpMinute.DataSource = minute;
                        drpMinute.DataTextField = "Key";
                        drpMinute.DataValueField = "Value";
                        drpMinute.DataBind();
                        drpMinute.Visible = true;
                        fen.Text = "分";
                        if (type > 5)
                        {
                            drpSecond.DataSource = minute;
                            drpSecond.DataTextField = "Key";
                            drpSecond.DataValueField = "Value";
                            drpSecond.DataBind();
                            drpSecond.Visible = true;
                            miao.Text = "秒";
                        }
                    }
                }
                SelectedTime = _time;
                drpYear.Attributes.Add("onchange",@"setDays(this,"+drpMonth.ClientID+","+drpDay.ClientID+");");
                drpMonth.Attributes.Add("onchange", @"setDays(" + drpYear.ClientID + ",this," + drpDay.ClientID + ");");
            }
        }

        public int Year
        {
            get { return int.Parse(drpYear.SelectedValue); }
        }
        public int Month
        {
            get { return int.Parse(drpMonth.SelectedValue); }
        }
        public int Day
        {
            get { return int.Parse(drpDay.SelectedValue); }
        }
        public int Hour
        {
            get { return int.Parse(drpHour.SelectedValue); }
        }
        public int Minute
        {
            get { return int.Parse(drpMinute.SelectedValue); }
        }
        public int Second
        {
            get { return int.Parse(drpSecond.SelectedValue); }
        }

        public DateTime SelectedTime
        {
            get 
            {
                DateTime ret = new DateTime();
                if (type <= 3)
                {
                    ret =  new DateTime(Year, Month, Day, 12, 0, 0);
                }
                else if (type == 4)
                {
                    ret = new DateTime(Year, Month, Day, Hour, 0, 0);
                }
                else if (type == 5)
                {
                    ret = new DateTime(Year, Month, Day, Hour, Minute, 0);
                }
                else if (type == 6)
                {
                    ret = new DateTime(Year, Month, Day, Hour, Minute, Second);
                }
                return ret;
            }
            set
            {
                _time = value;
                drpYear.SelectedIndex = drpYear.Items.IndexOf(drpYear.Items.FindByValue(value.Year.ToString()));
                drpMonth.SelectedIndex = drpMonth.Items.IndexOf(drpMonth.Items.FindByValue(value.Month.ToString()));
                drpDay.SelectedIndex = drpDay.Items.IndexOf(drpDay.Items.FindByValue(value.Day.ToString()));
                if (type > 3)
                {
                    drpHour.SelectedIndex = drpHour.Items.IndexOf(drpHour.Items.FindByValue(value.Hour.ToString()));
                }
                if (type > 4)
                {
                    drpMinute.SelectedIndex = drpMinute.Items.IndexOf(drpMinute.Items.FindByValue(value.Minute.ToString()));
                }
                if (type > 5)
                {
                    drpSecond.SelectedIndex = drpSecond.Items.IndexOf(drpSecond.Items.FindByValue(value.Second.ToString()));
                }
            }
        }

        public int Type
        {
            set { type = value; }
            get { return type; }
        }
    }
}