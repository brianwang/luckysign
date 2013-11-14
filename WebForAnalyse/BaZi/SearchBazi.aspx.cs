using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using PPLive;
using PPLive.BaZi;

namespace WebForAnalyse.BaZi
{
    public partial class SearchBazi : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);
            WebForAnalyse.Master.AdminMaster m_master = (WebForAnalyse.Master.AdminMaster)this.Master;
            m_master.PageName = "八字查询";
            m_master.SetCate(WebForAnalyse.Master.AdminMaster.CateType.BaZi2);
            #endregion
            if (!IsPostBack)
            {
                Dictionary<string, string> ganzhi = new Dictionary<string, string>();
                for (int i = 0; i < 60; i++)
                {
                    string tmp = PublicValue.GetTianGan(i % 10) + PublicValue.GetDiZhi(i % 12);
                    ganzhi.Add((i % 10 * 100 + i % 12).ToString(), tmp);
                }
                    drpHour.DataSource = ganzhi;
                    drpHour.DataTextField = "Value";
                    drpHour.DataValueField = "Key";
                drpHour.DataBind();
                drpYear.DataSource = ganzhi;
                drpYear.DataTextField = "Value";
                drpYear.DataValueField = "Key";
                drpYear.DataBind();
                drpMonth.DataSource = ganzhi;
                drpMonth.DataTextField = "Value";
                drpMonth.DataValueField = "Key";
                drpMonth.DataBind();
                drpDay.DataSource = ganzhi;
                drpDay.DataTextField = "Value";
                drpDay.DataValueField = "Key";
                drpDay.DataBind();
            }
        }
        private int dayun = 6;
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ltrResult.Text = "";
            if (txtDate.Text == "" || txtDate1.Text == "")
            {
                ltrNotice.Text = "请选择日期";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';closeforseconds();", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "plus(1);", true);
                return;
            }
            DateEntity m_date = new DateEntity(new DateTime(int.Parse(txtDate.Text.Split(new char[] { '-' })[0]), int.Parse(txtDate.Text.Split(new char[] { '-' })[1]), int.Parse(txtDate.Text.Split(new char[] { '-' })[2]),
               0, 0, 0));
            DateEntity m_date1 = new DateEntity(new DateTime(int.Parse(txtDate1.Text.Split(new char[] { '-' })[0]), int.Parse(txtDate1.Text.Split(new char[] { '-' })[1]), int.Parse(txtDate1.Text.Split(new char[] { '-' })[2]),
               0, 0, 0));
            if (m_date.Date >= m_date1.Date)
            {
                ltrNotice.Text = "开始日期必须在结束日期前";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';closeforseconds();", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "plus(1);", true);
                return;
            }
            while (m_date.Date < m_date1.Date)
            {
                BaZiMod male_bazi = new BaZiMod();
                male_bazi.BirthTime = m_date;
                male_bazi.Gender = AppEnum.Gender.male;
                BaZiBiz.GetInstance().TimeToBaZi(ref male_bazi);
                if ((((int)male_bazi.YearTG) * 100 + male_bazi.YearDZ).ToString() == drpYear.SelectedValue)
                {
                    if ((((int)male_bazi.MonthTG) * 100 + male_bazi.MonthDZ).ToString() == drpMonth.SelectedValue)
                    {
                        if ((((int)male_bazi.DayTG) * 100 + male_bazi.DayDZ).ToString() == drpDay.SelectedValue)
                        {
                            if ((((int)male_bazi.HourTG) * 100 + male_bazi.HourDZ).ToString() == drpHour.SelectedValue)
                            {
                                ltrResult.Text += m_date.Date.ToString("yyyy年MM月dd日HH时") + "<br />";
                                m_date = new DateEntity(m_date.Date.AddHours(2));
                                continue;
                            }
                            else
                            {
                                m_date = new DateEntity(new DateTime(m_date.Date.AddHours(2).Year, m_date.Date.AddHours(2).Month, m_date.Date.AddHours(2).Day, m_date.Date.AddHours(2).Hour,0,0));
                                continue;
                            }
                        }
                        else
                        {
                            m_date = new DateEntity(new DateTime(m_date.Date.AddDays(1).Year,m_date.Date.AddDays(1).Month,m_date.Date.AddDays(1).Day));
                            continue;
                        }
                    }
                    else
                    {
                            m_date = new DateEntity(male_bazi.JieQi[1].AddSeconds(1));
                            continue;
                    }
                }
                else
                {
                    if (m_date.Date >= m_date.BeginMonth[1])
                    {
                        m_date = new DateEntity(new DateEntity(m_date.Date.AddYears(1)).BeginMonth[1]);
                    }
                    else
                    {
                        m_date = new DateEntity(m_date.BeginMonth[1]);
                    }
                    continue;
                }
            }






        }

    }
}