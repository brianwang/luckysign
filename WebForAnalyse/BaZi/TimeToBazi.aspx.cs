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
    public partial class TimeToBazi : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);
            WebForAnalyse.Master.AdminMaster m_master = (WebForAnalyse.Master.AdminMaster)this.Master;
            m_master.PageName = "八字男女同排";
            m_master.SetCate(WebForAnalyse.Master.AdminMaster.CateType.BaZi1);
            #endregion
            if (!IsPostBack)
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

                Dictionary<string, string> minute = new Dictionary<string, string>();
                for (int i = 0; i <= 59; i++)
                {
                    minute.Add(i.ToString(), i.ToString());
                }
                drpMinute.DataSource = minute;
                drpMinute.DataTextField = "Key";
                drpMinute.DataValueField = "Value";
                drpMinute.DataBind();
            }
        }
        private int dayun = 6;
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (txtDate.Text == "")
            {
                ltrNotice.Text = "请选择日期";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';closeforseconds();", true);
                return;
            }

            DateEntity m_date = new DateEntity(new DateTime(int.Parse(txtDate.Text.Split(new char[] { '-' })[0]), int.Parse(txtDate.Text.Split(new char[] { '-' })[1]), int.Parse(txtDate.Text.Split(new char[] { '-' })[2]),
                int.Parse(drpHour.SelectedValue), int.Parse(drpMinute.SelectedValue), 0));
            BaZiMod male_bazi = new BaZiMod();
            male_bazi.BirthTime = m_date;
            male_bazi.Gender = AppEnum.Gender.male;
            BaZiBiz.GetInstance().TimeToBaZi(ref male_bazi);
            BaZiMod female_baze = new BaZiMod();
            female_baze.BirthTime = m_date;
            female_baze.Gender = AppEnum.Gender.female;
            BaZiBiz.GetInstance().TimeToBaZi(ref female_baze);

            if (drpDaYun.SelectedValue == "1")
            {
                SetDayun(ref male_bazi, male_bazi.DayTG, male_bazi.DayDZ);
                SetDayun(ref female_baze, female_baze.DayTG, female_baze.DayDZ);
            }
            else if (drpDaYun.SelectedValue == "2")
            {
                SetDayun(ref male_bazi, male_bazi.HourTG, male_bazi.HourDZ);
                SetDayun(ref female_baze, female_baze.HourTG, female_baze.HourDZ);
            }
            else if (drpDaYun.SelectedValue == "3")
            {
                SetDayun(ref male_bazi, BaZiBiz.GetInstance().MinuteTG(male_bazi.HourTG, male_bazi.BirthTime.Date.Minute + (male_bazi.BirthTime.Date.Hour + 1) % 2 * 60), BaZiBiz.GetInstance().MinuteDZ(male_bazi.BirthTime.Date.Minute + (male_bazi.BirthTime.Date.Hour + 1) % 2 * 60));
                SetDayun(ref female_baze, BaZiBiz.GetInstance().MinuteTG(female_baze.HourTG, female_baze.BirthTime.Date.Minute + (female_baze.BirthTime.Date.Hour + 1) % 2 * 60), BaZiBiz.GetInstance().MinuteDZ(female_baze.BirthTime.Date.Minute + (female_baze.BirthTime.Date.Hour + 1) % 2 * 60));
            }
            ltrResult.Text = BaziToHTML(male_bazi);
            ltrResult.Text += "<br /><br />" + BaziToHTML(female_baze);

        }

        public string BaziToHTML(BaZiMod mod)
        {
            string ret = "";
            ret += mod.BirthTime.Date.ToString("yyyy-MM-dd HH:mm") + "  （" + AppEnum.GetGender(mod.Gender) + "）<br />";
            ret += PublicValue.GetTianGan(mod.YearTG) + PublicValue.GetDiZhi(mod.YearDZ) + " " +
                PublicValue.GetTianGan(mod.MonthTG) + PublicValue.GetDiZhi(mod.MonthDZ) + " " +
                PublicValue.GetTianGan(mod.DayTG) + PublicValue.GetDiZhi(mod.DayDZ) + " " +
                PublicValue.GetTianGan(mod.HourTG) + PublicValue.GetDiZhi(mod.HourDZ) + " " +
                PublicValue.GetTianGan(BaZiBiz.GetInstance().MinuteTG(mod.HourTG, mod.BirthTime.Date.Minute + (mod.BirthTime.Date.Hour + 1) % 2 * 60)) +
                PublicValue.GetDiZhi(BaZiBiz.GetInstance().MinuteDZ(mod.BirthTime.Date.Minute + (mod.BirthTime.Date.Hour + 1) % 2 * 60)) + " " +
                "（" + PublicValue.GetDiZhi(mod.XunKong0) + PublicValue.GetDiZhi(mod.XunKong1) + "空）<br /><br />";
            ret += "大运：";
            for (int i = 0; i < dayun; i++)
            {
                ret += PublicValue.GetTianGan(mod.Dayun[i].YearTG) + PublicValue.GetDiZhi(mod.Dayun[i].YearDZ) + " " +
                    PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(mod.Dayun[i].YearTG, mod.YearTG)).ShiShen) + "|";
            }
            ret += "<br />";
            ret += "始于：";
            for (int i = 0; i < dayun; i++)
            {
                ret += mod.Dayun[i].Begin.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|";
            }
            ret += "<br />";
            ret += "流年：";
            for (int i = 0; i < 10; i++)
            {
                if (i != 0)
                {
                    ret += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                }
                for (int j = 0; j < dayun; j++)
                {

                    ret += PublicValue.GetTianGan(BaZiBiz.GetInstance().YearTG(mod.Dayun[j].Begin + i)) + PublicValue.GetDiZhi(BaZiBiz.GetInstance().YearDZ(mod.Dayun[j].Begin + i)) + " " +
                        PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(BaZiBiz.GetInstance().YearTG(mod.Dayun[j].Begin + i), mod.DayTG)).ShiShen) + "|";
                }
                ret += "<br />";
            }
            return ret;
        }

        private void SetDayun(ref BaZiMod bazi,PublicValue.TianGan G,PublicValue.DiZhi Z)
        {
            for (int i = 0; i < bazi.Dayun.Length; i++)
            {
                bazi.Dayun[i] = new BaZiDaYun();
                if ((bazi.YinYang == PublicValue.ShuXing.yang && bazi.Gender == AppCmn.AppEnum.Gender.male) ||
                    (bazi.YinYang == PublicValue.ShuXing.yin && bazi.Gender == AppCmn.AppEnum.Gender.female))//顺
                {
                    bazi.Dayun[i].YearTG = (PublicValue.TianGan)(((int)G + 1 + i) % 10);
                    bazi.Dayun[i].YearDZ = (PublicValue.DiZhi)(((int)Z + 1 + i) % 12);
                }
                else//逆
                {
                    bazi.Dayun[i].YearTG = (PublicValue.TianGan)(((int)G - 1 - i + 20) % 10);
                    bazi.Dayun[i].YearDZ = (PublicValue.DiZhi)(((int)Z - 1 - i + 24) % 12);
                }
                bazi.Dayun[i].Begin = bazi.JiaoYun.Year + 10 * i;
                bazi.Dayun[i].End = bazi.Dayun[i].Begin + 9;
                bazi.Dayun[i].NaYin = (PublicValue.Nayin)((int)bazi.Dayun[i].YearTG * 10 + bazi.Dayun[i].YearDZ);
                bazi.Dayun[i].ShiShen = PublicDeal.GetInstance().GZWuXing(new WuXingRelation(bazi.Dayun[i].YearTG, bazi.DayTG)).ShiShen;
            }
        }
    }
}