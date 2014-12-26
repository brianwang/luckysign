using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive.BaZi;
using PPLive;
using AppCmn;
using AppBll.WebSys;
using AppMod.WebSys;

namespace WebForMain.PPLive
{
    public partial class BaZiChart : PageBase
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
                    SetLtr();
                }
            }
        }

        
        protected void SetLtr()
        {
            BaZiMod m_bazi = new BaZiMod();

            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");
            if (((CheckBox)m_PlaceHolder.FindControl("chkRealTime")).Checked)
            {
                m_bazi.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime,
                    new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo))));
                //m_bazi.AreaSysNo = ((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo;
                m_bazi.AreaName = ((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area1Name + "-"+
                    ((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area2Name + "-" +
                    ((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3Name;
                m_bazi.Longitude = ((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).lng;
            }
            else
            {
                m_bazi.BirthTime = new DateEntity(((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime);
            }
            m_bazi.Gender = (AppEnum.Gender)int.Parse(((RadioButtonList)m_PlaceHolder.FindControl("drpGender")).SelectedValue);
            m_bazi.RealTime = ((CheckBox)m_PlaceHolder.FindControl("chkRealTime")).Checked;

            #endregion
           
            if (((RadioButtonList)m_PlaceHolder.FindControl("rblType")).SelectedValue != "")
            {
                switch (((RadioButtonList)m_PlaceHolder.FindControl("rblType")).SelectedValue)
                {
                    case "1":
                        BaZi1.m_bazi = m_bazi;
                        BaZi1.total = true;
                        break;
                    case "2":
                        BaZi1.m_bazi = m_bazi;
                        BaZi1.total = false;
                        break;
                }
            }
        }

        
    }
}