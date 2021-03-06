﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive.ZiWei;
using PPLive;
using AppCmn;
using AppBll.WebSys;
using AppMod.WebSys;

namespace WebForMain.PPLive
{
    public partial class ZiWeiChart : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(4);
            if (Page.PreviousPage != null)
            {
                if (!Page.IsCrossPagePostBack)
                {
                    Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");
                    if (((RadioButton)m_PlaceHolder.FindControl("rblType1")).Checked)
                    {
                        SetBenMing();
                    }
                    else if (((RadioButton)m_PlaceHolder.FindControl("rblType2")).Checked)
                    {
                        SetLiuXian();
                    }
                    else
                    { }
                }
            }
        }
    

        //本命盘排盘
        protected void SetBenMing()
        {
            ZiWeiMod m_ziwei = new ZiWeiMod();

            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");
            if (((CheckBox)m_PlaceHolder.FindControl("chkRealTime")).Checked)
            {
                m_ziwei.BirthTime = new DateEntity(RealTime(((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime,
                    new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo))));
            }
            else
            {
                m_ziwei.BirthTime = new DateEntity(((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime);
            }
            m_ziwei.Gender = (AppEnum.Gender)int.Parse(((RadioButtonList)m_PlaceHolder.FindControl("drpGender")).SelectedValue);
            m_ziwei.RunYue = (PublicValue.ZiWeiRunYue)int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpLeaf")).SelectedValue);
            int[] paras = {int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTianma")).SelectedValue),
                          int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpShenzhu")).SelectedValue),
                          int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpShiShang")).SelectedValue),
                          int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTransit")).SelectedValue)};
            #endregion
            ZiWei1.m_ziwei = m_ziwei;
            ZiWei1.Paras = paras;
        }
        //流限盘排盘
        protected void SetLiuXian()
        {
            ZiWeiMod m_ziwei = new ZiWeiMod();

            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");
            if (((CheckBox)m_PlaceHolder.FindControl("chkRealTime")).Checked)
            {
                m_ziwei.BirthTime = new DateEntity(RealTime(((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime,
                    new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo))));
            }
            else
            {
                m_ziwei.BirthTime = new DateEntity(((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime);
            }
            m_ziwei.Gender = (AppEnum.Gender)int.Parse(((RadioButtonList)m_PlaceHolder.FindControl("drpGender")).SelectedValue);
            m_ziwei.RunYue = (PublicValue.ZiWeiRunYue)int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpLeaf")).SelectedValue);
            int[] paras = {int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTianma")).SelectedValue),
                          int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpShenzhu")).SelectedValue),
                          int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpShiShang")).SelectedValue),
                          int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTransit")).SelectedValue)};
            m_ziwei.TransitTime = new DateEntity(((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("TransitDate")).SelectedTime);
            string args = m_ziwei.BirthTime.Date.ToString() + "|" + (int)m_ziwei.Gender + "|" + paras[0] + paras[1] + paras[2] + paras[3] + m_ziwei.TransitTime.Date.ToString();
            ViewState["args"] = args;
            #endregion
            ZiWei1.m_ziwei = m_ziwei;
            ZiWei1.Paras = paras;
            ZiWei1.Trans = true;
        }

        protected DateTime RealTime(DateTime input, LatLng poi)
        {
            TimeSpan latspan = new TimeSpan(0, 0, Convert.ToInt32((poi.longitude - 120) * 4 * 60));
            int daycount = input.DayOfYear;
            if(!((input.Year%4==0&&input.Year%100!=0)|| input.Year%400==0))
            {
                if(daycount>59)
                {
                    daycount++;
                }
            }
            TimeSpan timespan = new TimeSpan(0, int.Parse(realtime[daycount].Split(new char[] { '|' })[0]), int.Parse(realtime[daycount].Substring(0,1) + realtime[daycount].Split(new char[] { '|' })[1]));
            return input + latspan + timespan;
        }
        #region 节气造成的真太阳时差
        private string[] realtime = 
        {
"-3|9",
"-3|38",
"-4|6",
"-4|33",
"-5|1",
"-5|27",
"-5|54",
"-6|20",
"-6|45",
"-7|10",
"-7|35",
"-7|59",
"-8|22",
"-8|45",
"-9|7",
"-9|28",
"-9|49",
"-10|9",
"-10|28",
"-10|47",
"-11|5",
"-11|22",
"-11|38",
"-11|54",
"-12|8",
"-12|22",
"-12|35",
"-12|59",
"-13|10",
"-13|19",
"-13|37",
"-13|44",
"-13|50",
"-13|56",
"-14|1",
"-14|5",
"-14|9",
"-14|11",
"-14|13",
"-14|14",
"-14|15",
"-14|14",
"-14|13",
"-14|11",
"-14|8",
"-14|5",
"-14|1",
"-13|56",
"-13|51",
"-13|44",
"-13|38",
"-13|30",
"-13|22",
"-13|13",
"-11|4",
"-12|54",
"-12|43",
"-12|32",
"-12|21",
"-12|8",
"-11|56",
"-11|43",
"-11|29",
"-11|15",
"-11|1",
"-10|47",
"-10|32",
"-10|16",
"-10|1",
"-9|45",
"-9|28",
"-9|12",
"-8|55",
"-8|38",
"-8|21",
"-8|4",
"-7|46",
"-7|29",
"-7|11",
"-6|53",
"-6|35",
"-6|17",
"-5|58",
"-5|40",
"-5|22",
"-5|4",
"-4|45",
"-4|27",
"-4|9",
"-3|51",
"-3|33",
"-3|16",
"-2|58",
"-2|41",
"-2|24",
"-2|7",
"-1|50",
"-1|33",
"-1|17",
"-1|1",
"+0|46",
"+0|30",
"+0|16",
"+0|1",
"+0|13",
"+0|27",
"+0|41",
"+0|54",
"+1|6",
"+1|19",
"+1|31",
"+1|42",
"+1|53",
"+2|4",
"+2|14",
"+2|23",
"+2|33",
"+2|41",
"+2|49",
"+2|57",
"+3|4",


"+1|10",
"+3|16",
"+3|21",
"+3|26",
"+3|30",
"+3|37",
"+3|36",
"+3|39",
"+3|40",
"+3|42",
"+3|42",
"+3|42",
"+3|42",
"+3|41",
"+3|39",
"+3|37",
"+3|34",
"+3|31",
"+3|27",
"+3|23",
"+3|18",
"+3|13",
"+3|7",
"+3|1",
"+2|54",
"+2|47",
"+2|39",
"+2|31",
"+2|22",
"+2|13",
"+2|4",
"+1|54",
"+1|44",
"+1|34",
"+1|23",
"+1|12",
"+1|0",
"+0|48",
"+0|36",
"+0|24",
"+0|12",
"+0|1",
"+0|14",
"+0|39",
"+0|52",
"-1|5",
"-1|18",
"-1|31",
"-1|45",
"-1|57",
"-2|10",
"-2|23",
"-2|36",
"-2|48",
"-3|1",
"-3|13",
"-3|25",
"-3|37",
"-3|49",
"-4|0",
"-4|11",
"-4|22",
"-4|33",
"-4|43",
"-4|53",
"-5|2",
"-5|11",
"-5|20",
"-5|28",
"-5|36",
"-5|43",
"-5|50",
"-5|56",
"-6|2",
"-6|8",
"-6|12",
"-6|16",
"-6|20",
"-6|23",
"-6|25",
"-6|27",
"-6|29",
"-6|29",
"-6|29",
"-6|29",
"-6|28",
"-6|26",
"-6|24",
"-6|21",
"-6|17",
"-6|13",
"-6|8",
"-6|3",
"-5|57",
"-5|51",
"-5|44",
"-5|36",
"-5|28",
"-5|19",
"-5|10",
"-5|0",
"-4|50",
"-4|39",
"-4|27",
"-4|15",
"-4|2",
"-3|49",
"-3|36",
"-3|21",
"-3|7",
"-2|51",
"-2|36",
"-2|20",
"-2|3",
"-1|47",
"-1|29",
"-1|12",
"+0|54",
"+0|35",
"+0|17",
"+0|2",
"+0|21",
"+0|41",


"+1|0",
"+1|20",
"+1|40",
"+2|1",
"+2|21",
"+2|42",
"+3|3",
"+3|3",
"+3|24",
"+3|45",
"+4|6",
"+4|27",
"+4|48",
"+5|10",
"+5|31",
"+5|53",
"+6|14",
"+6|35",
"+6|57",
"+7|18",
"+7|39",
"+8|0",
"+8|21",
"+8|42",
"+9|2",
"+9|22",
"+9|42",
"+10|2",
"+10|21",
"+10|40",
"+10|59",
"+11|18",
"+11|36",
"+11|36",
"+11|53",
"+12|11",
"+12|28",
"+12|44",
"+12|60",
"+13|16",
"+13|16",
"+13|31",
"+13|45",
"+13|59",
"+14|13",
"+14|26",
"+14|38",
"+14|50",
"+15|1",
"+15|12",
"+15|21",
"+15|31",
"+15|40",
"+15|48",
"+15|55",
"+16|1",
"+16|7",
"+16|12",
"+16|16",
"+16|20",
"+16|22",
"+16|24",
"+16|25",
"+16|25",
"+16|24",
"+16|23",
"+16|21",
"+16|17",
"+16|13",
"+16|9",
"+16|3",
"+15|56",
"+15|49",
"+15|41",
"+15|32",
"+15|22",
"+15|11",
"+14|60",
"+14|47",
"+14|34",
"+14|20",
"+14|6",
"+13|50",
"+13|34",
"+13|17",
"+12|59",
"+12|40",
"+12|21",
"+12|1",
"+11|40",
"+11|18",
"+10|56",
"+10|33",
"+10|9",
"+9|45",
"+9|21",
"+8|55",
"+8|29",
"+8|3",
"+7|36",
"+7|9",
"+6|42",
"+6|14",
"+5|46",
"+5|17",
"+4|48",
"+4|19",
"+3|50",
"+3|21",
"+2|51",
"+2|22",
"+1|52",
"+1|22",
"+0|52",
"+0|23",
"+0|7",
"+0|37",
"-1|6",
"-1|36",
"-2|5",
"-2|34",
"-3|3",
  "-3|6"      };
        #endregion
    }
}