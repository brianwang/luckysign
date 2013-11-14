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
using System.Data;
using System.Collections;

namespace WebForMain.PPLive
{
    public partial class AstroChart : PageBase
    {
        public string picurl = "";
        public AstroMod m_astro = new AstroMod();
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(4);
            if (Page.PreviousPage != null)
            {
                if (!Page.IsCrossPagePostBack)
                {
                    Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");
                    if (((HiddenField)m_PlaceHolder.FindControl("hdType")).Value != "")
                    {
                        switch (((HiddenField)m_PlaceHolder.FindControl("hdType")).Value)
                        {
                            case "10":
                                SetBenMing();
                                break;
                            case "20":
                                SetHePan();
                                break;
                            case "30":
                            case "31":
                                SetTransit();
                                break;
                            case "32":
                                SetProgress();
                                break;
                            case "33":
                                SetReturn();
                                break;
                            case "34":
                                SetSolarArcs();
                                break;
                        }
                    }
                    SetParaLink();
                    SetSameFamous();
                    
                }
            }
            Astro1.ChangePara += new EventHandler(ResetPara); 
        }

        //本命盘排盘
        protected void SetBenMing()
        {
            m_astro.type = PublicValue.AstroType.benming;
            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");
            m_astro.birth = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime;
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo));
            if (((CheckBox)m_PlaceHolder.FindControl("chkDaylight1")).Checked)
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            m_astro.zone = int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTimeZone1")).SelectedValue);

            //m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
            m_astro.startsShow.Clear();
            for (int i = 1; i < 21; i++)
            {
                if (((CheckBox)m_PlaceHolder.FindControl("star" + i)).Checked)
                {
                    m_astro.startsShow.Add(i, ((CheckBox)m_PlaceHolder.FindControl("star" + i)).Text);
                }
            }
            m_astro.startsShow.Add(21, "上升");
            m_astro.startsShow.Add(24, "天底");
            m_astro.startsShow.Add(27, "下降");
            m_astro.startsShow.Add(30, "中天");
            m_astro.aspectsShow.Clear();
            m_astro.aspectsShow.Add(1, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect0")).SelectedValue));
            m_astro.aspectsShow.Add(2, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect180")).SelectedValue));
            m_astro.aspectsShow.Add(4, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect120")).SelectedValue));
            m_astro.aspectsShow.Add(3, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect90")).SelectedValue));
            m_astro.aspectsShow.Add(5, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect60")).SelectedValue));

            #endregion
            //生成ID并访问图片页
            SetPic();
        }
        //组合盘排盘
        protected void SetHePan()
        {
            m_astro.type = PublicValue.AstroType.hepan;
            
            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");
            m_astro.compose = (PublicValue.AstroZuhe)int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpCompareType")).SelectedValue);

            m_astro.birth = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime;
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo));
            if (((CheckBox)m_PlaceHolder.FindControl("chkDaylight1")).Checked)
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            m_astro.zone = int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTimeZone1")).SelectedValue);
            m_astro.birth1 = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker2")).SelectedTime;
            m_astro.position1 = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District2")).Area3SysNo));
            if (((CheckBox)m_PlaceHolder.FindControl("chkDaylight2")).Checked)
            {
                m_astro.IsDaylight1 = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight1 = AppEnum.BOOL.False;
            }
            m_astro.zone1 = int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTimeZone2")).SelectedValue);

            //m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
            m_astro.startsShow.Clear();
            for (int i = 1; i < 21; i++)
            {
                if (((CheckBox)m_PlaceHolder.FindControl("star" + i)).Checked)
                {
                    m_astro.startsShow.Add(i, ((CheckBox)m_PlaceHolder.FindControl("star" + i)).Text);
                }
            }
            m_astro.startsShow.Add(21, "上升");
            m_astro.startsShow.Add(24, "天底");
            m_astro.startsShow.Add(27, "下降");
            m_astro.startsShow.Add(30, "中天");
            m_astro.aspectsShow.Clear();
            m_astro.aspectsShow.Add(1, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect0")).SelectedValue));
            m_astro.aspectsShow.Add(2, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect180")).SelectedValue));
            m_astro.aspectsShow.Add(4, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect120")).SelectedValue));
            m_astro.aspectsShow.Add(3, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect90")).SelectedValue));
            m_astro.aspectsShow.Add(5, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect60")).SelectedValue));

            #endregion
            //生成ID并访问图片页
            SetPic();
        }
        //推运盘排盘
        protected void SetTransit()
        {
            m_astro.type = PublicValue.AstroType.tuiyun;
            m_astro.transit = PublicValue.AstroTuiyun.xingyun;
            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");

            m_astro.birth = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime;
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo));
            if (((CheckBox)m_PlaceHolder.FindControl("chkDaylight1")).Checked)
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            m_astro.zone = int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTimeZone1")).SelectedValue);

            m_astro.transitTime = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePickert1")).SelectedTime;
            m_astro.transitPosition = m_astro.position;
            //m_astro.IsDaylight1 = m_astro.IsDaylight;
            //m_astro.zone1 = m_astro.zone;

            //m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
            m_astro.startsShow.Clear();
            for (int i = 1; i < 21; i++)
            {
                if (((CheckBox)m_PlaceHolder.FindControl("star" + i)).Checked)
                {
                    m_astro.startsShow.Add(i, ((CheckBox)m_PlaceHolder.FindControl("star" + i)).Text);
                }
            }
            m_astro.startsShow.Add(21, "上升");
            m_astro.startsShow.Add(24, "天底");
            m_astro.startsShow.Add(27, "下降");
            m_astro.startsShow.Add(30, "中天");
            m_astro.aspectsShow.Clear();
            m_astro.aspectsShow.Add(1, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect0")).SelectedValue));
            m_astro.aspectsShow.Add(2, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect180")).SelectedValue));
            m_astro.aspectsShow.Add(4, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect120")).SelectedValue));
            m_astro.aspectsShow.Add(3, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect90")).SelectedValue));
            m_astro.aspectsShow.Add(5, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect60")).SelectedValue));
            
            #endregion
            //生成ID并访问图片页
            SetPic();
        }

        protected void SetProgress()
        {
            m_astro.type = PublicValue.AstroType.tuiyun;
            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");

            m_astro.transit = (PublicValue.AstroTuiyun)int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpProgressType")).SelectedValue);
            m_astro.birth = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime;
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo));
            if (((CheckBox)m_PlaceHolder.FindControl("chkDaylight1")).Checked)
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            m_astro.zone = int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTimeZone1")).SelectedValue);

            m_astro.transitTime = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePickert2")).SelectedTime;
            //m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
            m_astro.startsShow.Clear();
            for (int i = 1; i < 21; i++)
            {
                if (((CheckBox)m_PlaceHolder.FindControl("star" + i)).Checked)
                {
                    m_astro.startsShow.Add(i, ((CheckBox)m_PlaceHolder.FindControl("star" + i)).Text);
                }
            }
            m_astro.startsShow.Add(21, "上升");
            m_astro.startsShow.Add(24, "天底");
            m_astro.startsShow.Add(27, "下降");
            m_astro.startsShow.Add(30, "中天");
            m_astro.aspectsShow.Clear();
            m_astro.aspectsShow.Add(1, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect0")).SelectedValue));
            m_astro.aspectsShow.Add(2, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect180")).SelectedValue));
            m_astro.aspectsShow.Add(4, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect120")).SelectedValue));
            m_astro.aspectsShow.Add(3, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect90")).SelectedValue));
            m_astro.aspectsShow.Add(5, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect60")).SelectedValue));
            
            #endregion
            //生成ID并访问图片页
            SetPic();
        }

        protected void SetReturn()
        {
            m_astro.type = PublicValue.AstroType.tuiyun;
            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");

            m_astro.transit = (PublicValue.AstroTuiyun)int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpReturnType")).SelectedValue);
            m_astro.birth = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime;
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo));
            if (((CheckBox)m_PlaceHolder.FindControl("chkDaylight1")).Checked)
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            m_astro.zone = int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTimeZone1")).SelectedValue);

            m_astro.transitTime = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePickert3")).SelectedTime;
            m_astro.transitPosition = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("Districtt3")).Area3SysNo));
            //m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
            m_astro.startsShow.Clear();
            for (int i = 1; i < 21; i++)
            {
                if (((CheckBox)m_PlaceHolder.FindControl("star" + i)).Checked)
                {
                    m_astro.startsShow.Add(i, ((CheckBox)m_PlaceHolder.FindControl("star" + i)).Text);
                }
            }
            m_astro.startsShow.Add(21, "上升");
            m_astro.startsShow.Add(24, "天底");
            m_astro.startsShow.Add(27, "下降");
            m_astro.startsShow.Add(30, "中天");
            m_astro.aspectsShow.Clear();
            m_astro.aspectsShow.Add(1, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect0")).SelectedValue));
            m_astro.aspectsShow.Add(2, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect180")).SelectedValue));
            m_astro.aspectsShow.Add(4, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect120")).SelectedValue));
            m_astro.aspectsShow.Add(3, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect90")).SelectedValue));
            m_astro.aspectsShow.Add(5, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect60")).SelectedValue));

            #endregion
            //生成ID并访问图片页
            SetPic();
        }

        protected void SetSolarArcs()
        {
            m_astro.type = PublicValue.AstroType.tuiyun;
            m_astro.transit = PublicValue.AstroTuiyun.taiyanghu;
            #region 设置实体各种参数
            Control m_PlaceHolder = PreviousPage.Master.FindControl("ContentPlaceHolder1");

            m_astro.birth = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePicker1")).SelectedTime;
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(((WebForMain.ControlLibrary.DistrictPicker)m_PlaceHolder.FindControl("District1")).Area3SysNo));
            if (((CheckBox)m_PlaceHolder.FindControl("chkDaylight1")).Checked)
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            m_astro.zone = int.Parse(((DropDownList)m_PlaceHolder.FindControl("drpTimeZone1")).SelectedValue);

            m_astro.transitTime = ((WebForMain.ControlLibrary.DatePicker)m_PlaceHolder.FindControl("DatePickert4")).SelectedTime;
            //m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
            m_astro.startsShow.Clear();
            for (int i = 1; i < 21; i++)
            {
                if (((CheckBox)m_PlaceHolder.FindControl("star" + i)).Checked)
                {
                    m_astro.startsShow.Add(i, ((CheckBox)m_PlaceHolder.FindControl("star" + i)).Text);
                }
            }
            m_astro.startsShow.Add(21, "上升");
            m_astro.startsShow.Add(24, "天底");
            m_astro.startsShow.Add(27, "下降");
            m_astro.startsShow.Add(30, "中天");
            m_astro.aspectsShow.Clear();
            m_astro.aspectsShow.Add(1, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect0")).SelectedValue));
            m_astro.aspectsShow.Add(2, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect180")).SelectedValue));
            m_astro.aspectsShow.Add(4, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect120")).SelectedValue));
            m_astro.aspectsShow.Add(3, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect90")).SelectedValue));
            m_astro.aspectsShow.Add(5, decimal.Parse(((DropDownList)m_PlaceHolder.FindControl("drpAspect60")).SelectedValue));
            #endregion
            //生成ID并访问图片页
            SetPic();
        }

        protected void SetPic()
        {
            Astro1.m_astro = m_astro;
        }

        public void ResetPara(object sender, EventArgs e)
        {
            m_astro = Astro1.m_astro; ;
            SetParaLink();
            SetSameFamous();
        }


        public void SetParaLink()
        {
            AstroBiz.GetInstance().GetParamters(ref m_astro);
        }

        public void SetSameFamous()
        {
            DataSet m_ds = AstroBiz.GetInstance().GetSameFamous(m_astro);
            if (m_ds != null && m_ds.Tables.Count == 15)
            {
                SortedList m_star = PublicValue.GetAstroStar();
                DataTable m_stars = new DataTable();
                m_stars.Columns.Add("starname");
                m_stars.Columns.Add("gong");
                for (int i = 0; i < 10; i++)
                {
                    DataRow m_dr = m_stars.NewRow();
                    m_dr["starname"] = m_star[i+1];
                    m_dr["gong"] = m_astro.Stars[i].Gong;
                    m_stars.Rows.Add(m_dr);
                }



                for (int i = 5; m_star.Count > 5; )
                {
                    m_star.RemoveAt(i);
                }

                ViewState["samefamous"] = m_ds;
                Repeater1.DataSource = m_star;
                Repeater1.DataBind();

                Repeater3.DataSource = m_stars;
                Repeater3.DataBind();


            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataSet m_ds = (DataSet)ViewState["samefamous"];
            Repeater tmprpt = (Repeater)e.Item.FindControl("Repeater2");
            tmprpt.DataSource = m_ds.Tables[e.Item.ItemIndex];
            tmprpt.DataBind();
        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataSet m_ds = (DataSet)ViewState["samefamous"];
            Repeater tmprpt = (Repeater)e.Item.FindControl("Repeater4");
            tmprpt.DataSource = m_ds.Tables[e.Item.ItemIndex+5];
            tmprpt.DataBind();
        }

    }
}