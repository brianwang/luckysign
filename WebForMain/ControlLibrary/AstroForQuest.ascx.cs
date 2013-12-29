using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppCmn;
using PPLive.Astro;
using PPLive;
using AppBll.WebSys;
using AppMod.Fate;

namespace WebForMain.ControlLibrary
{
    
    public partial class AstroForQuest : System.Web.UI.UserControl
    {
        public FATE_ChartMod input
        {
            set { _input = value;  }
            get { return _input; }
        }
        public AstroMod m_astro
        {
            set { _m_astro = value;  }
            get { return _m_astro; }
        }

        public event EventHandler ChangePara; 
        private AstroMod _m_astro = null;
        private FATE_ChartMod _input = null;
        public string picurl = "";
        public string chartpara = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                if (!IsPostBack)
                {
                    #region 本命盘下拉绑定

                    SortedList<int, string> aspect = new SortedList<int, string>();
                    for (int i = 1; i < 11; i++)
                    {
                        aspect.Add(i, i.ToString("0.00"));
                    }
                    aspect.Add(-1, "隐藏");

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

                    #region 推运下拉绑定
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
                    drpTimeZone2.DataSource = timezone;
                    drpTimeZone2.DataTextField = "value";
                    drpTimeZone2.DataValueField = "key";
                    drpTimeZone2.DataBind();
                    drpTimeZone2.SelectedIndex = 4;
                    drpProgressType.DataSource = PublicValue.GetAstroTuiyun();
                    drpProgressType.DataTextField = "value";
                    drpProgressType.DataValueField = "key";
                    drpProgressType.DataBind();
                    #endregion

                    #region 组合下拉绑定
                    drpCompareType.DataSource = PublicValue.GetAstroZuhe();
                    drpCompareType.DataTextField = "value";
                    drpCompareType.DataValueField = "key";
                    drpCompareType.DataBind();
                    #endregion

                    if (_input != null)
                    {
                        InitialChart();
                    }
                    else if (_m_astro != null)
                    {
                        InitialFate();
                    }
                    else
                    { return; }
                    ViewState["OriginalChart"] = m_astro;
                    ViewState["NowChart"] = m_astro;
                    
                }
               
                
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "SetDocument", "SetDocument();", true);

                if (!IsPostBack)
                {
                    if (m_astro.type == PublicValue.AstroType.tuiyun)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "tuiyun", "document.getElementById('" + pnlTuiYun.ClientID + "').click();", true);
                    }
                    else if (m_astro.type == PublicValue.AstroType.hepan)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "hepan", "document.getElementById('" + pnlHePan.ClientID + "').click();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozhengqian", "document.getElementById('" + pnlJiaoZheng.ClientID + "').click();", true);
                    }
                }
                m_astro = (AstroMod)ViewState["NowChart"];
                if (m_astro.type == PublicValue.AstroType.hepan)
                {
                    Literal2.Text = @"出生时间：<br />
                    " + m_astro.birth1.ToString("yyyy年MM月dd日 HH:mm:ss") + @"
                    <br />
                    所属时区： " + (m_astro.zone1 > 0 ? "西" + m_astro.zone1.ToString() : "东" + m_astro.zone1.ToString()) + @"区<br />
                    夏令时：" + (((int)m_astro.IsDaylight1) == 1 ? "是" : "否") + @"
                    <br />
                    性别： "+ AppEnum.GetGender(m_astro.Gender1)+@"
                    <br />
                    出生地： " + m_astro.position1.name + @"
                    <br />
                    (经度" + m_astro.position1.Lng + @"
                    <br />
                    纬度" + m_astro.position1.Lat + @")
                    <br />";
                }
                else 
                {
                    second.Visible = false;
                }
                Literal1.Text = @"出生时间：<br />
                    " + m_astro.birth.ToString("yyyy年MM月dd日 HH:mm:ss") + @"
                    <br />
                    所属时区： " + (m_astro.zone > 0 ? "西" + m_astro.zone.ToString() : "东" + m_astro.zone.ToString()) + @"区<br />
                    夏令时：" + (((int)m_astro.IsDaylight) == 1 ? "是" : "否") + @"
                    <br />
                    性别： " + AppEnum.GetGender(m_astro.Gender) + @"
                    <br />
                    出生地： " + m_astro.position.name + @"
                    <br />
                    (经度" + m_astro.position.Lng + @"
                    <br />
                    纬度" + m_astro.position.Lat + @")
                    <br />";

                chartpara = m_astro.birth.ToString("yyyy_MM_dd_HH_mm") + "_" + (int)m_astro.IsDaylight + "_" + m_astro.position.Lat + "_" + m_astro.position.Lng + "_" + m_astro.zone;

                if (Parent.Page.ToString() == "ASP.pplive_astrochart_aspx" && IsPostBack)
                {
                    //PPLive.AstroChart m_parent = (PPLive.AstroChart)Parent;
                    //m_parent.m_astro = m_astro;
                    //m_parent.SetParaLink();
                    //m_parent.SetSameFamous();
                    if (ChangePara != null)
                    {
                        ChangePara(this,  EventArgs.Empty);
                    } 


                }
            }
        }

        /// <summary>
        /// 用于赋予datatable后初始化页面，其中本命盘显示本命盘，合盘则显示比较盘
        /// </summary>
        public void InitialChart()
        {
            if (_input == null || _input.CharType == AppConst.IntNull)
            {
                return; 
            }
            if(_input.CharType.ToString()==((int)AppEnum.ChartType.personal).ToString())
            {
                m_astro = new AstroMod();
                #region 设置实体各种参数
                m_astro.type = PublicValue.AstroType.benming;
                m_astro.birth = DateTime.Parse(_input.FirstBirth.ToString());
                m_astro.Gender = (AppEnum.Gender)_input.FirstGender;
                string[] tmplatlng = _input.FirstPoi.ToString().Split(new char[] { '|' });
                m_astro.position = new LatLng(tmplatlng[1],tmplatlng[0],_input.FirstPoiName);
                if (_input.FirstDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                {
                    m_astro.IsDaylight = AppEnum.BOOL.True;
                }
                else
                {
                    m_astro.IsDaylight = AppEnum.BOOL.False;
                }
                m_astro.zone = int.Parse(_input.FirstTimeZone.ToString());

                SetPara();
                #endregion
                SetBenMing();
                DatePickert3.SelectedTime = m_astro.birth;
            }
            else if(_input.CharType.ToString()==((int)AppEnum.ChartType.relation).ToString())
            {
                m_astro = new AstroMod();
                #region 设置实体各种参数
                m_astro.type = PublicValue.AstroType.hepan;
                m_astro.compose = PublicValue.AstroZuhe.bijiao;
                m_astro.Gender = (AppEnum.Gender)_input.FirstGender;
                m_astro.Gender1 = (AppEnum.Gender)_input.SecondGender;
                m_astro.birth = DateTime.Parse(_input.FirstBirth.ToString());
                string[] tmplatlng = _input.FirstPoi.ToString().Split(new char[] { '|' });
                m_astro.position = new LatLng(tmplatlng[1], tmplatlng[0], _input.FirstPoiName);
                if (_input.FirstDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                {
                    m_astro.IsDaylight = AppEnum.BOOL.True;
                }
                else
                {
                    m_astro.IsDaylight = AppEnum.BOOL.False;
                }
                m_astro.zone = int.Parse(_input.FirstTimeZone.ToString());
                m_astro.birth1 = DateTime.Parse(_input.SecondBirth.ToString());
                tmplatlng = _input.SecondPoi.ToString().Split(new char[] { '|' });
                m_astro.position1 = new LatLng(tmplatlng[1], tmplatlng[0], _input.SecondPoiName);
                if (_input.SecondDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                {
                    m_astro.IsDaylight1 = AppEnum.BOOL.True;
                }
                else
                {
                    m_astro.IsDaylight1 = AppEnum.BOOL.False;
                }
                m_astro.zone1 = int.Parse(_input.SecondTimeZone.ToString());

                //m_astro.houseSystem = int.Parse(drpSOH.SelectedValue);
                SetPara();

                #endregion
                SetHePan();
                if (!IsPostBack)
                {
                    pnlTuiYun.Style["display"] = "none";
                    pnlJiaoZheng.Style["display"] = "none";
                    hepaninfo.Style["display"] = "none";
                    DatePicker2.SelectedTime = m_astro.birth1;
                    chkDaylight2.Checked = Convert.ToBoolean((int)m_astro.IsDaylight1);
                    District2.Area = m_astro.position1.Area;
                    drpTimeZone2.SelectedIndex = drpTimeZone2.Items.IndexOf(drpTimeZone2.Items.FindByValue(m_astro.zone1.ToString()));
                    LinkButton2.Style["display"] = "none";
                }
            }
        }

        /// <summary>
        /// 用于赋予了实体后初始化页面
        /// </summary>
        public void InitialFate()
        {
            

            if (_m_astro.type == PublicValue.AstroType.benming)
            {
                SetBenMing();
                DatePickert3.SelectedTime = m_astro.birth;
            }
            else if (_m_astro.type == PublicValue.AstroType.hepan)
            {
                SetHePan();
                if (!IsPostBack)
                {
                    pnlTuiYun.Style["display"] = "none";
                    pnlJiaoZheng.Style["display"] = "none";
                    hepaninfo.Style["display"] = "none";
                    DatePicker2.SelectedTime = m_astro.birth1;
                    chkDaylight2.Checked = Convert.ToBoolean((int)m_astro.IsDaylight1);
                    District2.Area = m_astro.position1.Area;
                    drpTimeZone2.SelectedIndex = drpTimeZone2.Items.IndexOf(drpTimeZone2.Items.FindByValue(m_astro.zone1.ToString()));
                    LinkButton2.Style["display"] = "none";
                }
            }
            else if (_m_astro.type == PublicValue.AstroType.tuiyun)
            {
                if (_m_astro.transit == PublicValue.AstroTuiyun.xingyun)
                {
                    SetTransit();
                }
                else if (_m_astro.transit == PublicValue.AstroTuiyun.sanxian || _m_astro.transit == PublicValue.AstroTuiyun.cixian || _m_astro.transit == PublicValue.AstroTuiyun.sanxian1)
                {
                    SetProgress();
                }
                else if (_m_astro.transit == PublicValue.AstroTuiyun.rifanzhao || _m_astro.transit == PublicValue.AstroTuiyun.yuefanzhao)
                {
                    SetReturn();
                }
                else if (_m_astro.transit == PublicValue.AstroTuiyun.taiyanghu)
                {
                    SetSolarArcs();
                }
                if (!IsPostBack)
                {
                    pnlHePan.Style["display"] = "none";
                    LinkButton4.Style["display"] = "none";
                    DatePickert1.SelectedTime = m_astro.transitTime; 
                    drpProgressType.SelectedIndex = drpProgressType.Items.IndexOf(drpProgressType.Items.FindByValue(((int)m_astro.transit).ToString()));
                }
               
                
                
            }
        }

        //本命盘排盘
        protected void SetBenMing()
        {
            //生成ID并访问图片页
            SetPic(AppConfig.PPLiveUrl() + "PPLive/AstroChart.aspx?ID=" + AstroBiz.GetInstance().SetGraphicID(m_astro));
            //+ "&fa=" + m_astro.composeFile1.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", "")
            //+ "&fb=" + m_astro.composeFile2.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", ""));
        }
        //组合盘排盘
        protected void SetHePan()
        {
            //生成ID并访问图片页
            SetPic(AppConfig.PPLiveUrl() + "PPLive/AstroChart.aspx?ID=" + AstroBiz.GetInstance().SetGraphicID(m_astro)
                + "&fa=" + m_astro.composeFile1.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", "")
                + "&fb=" + m_astro.composeFile2.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", ""));
        }
        //推运盘排盘
        protected void SetTransit()
        {
            //生成ID并访问图片页
            SetPic(AppConfig.PPLiveUrl() + "PPLive/AstroChart.aspx?ID=" + AstroBiz.GetInstance().SetGraphicID(m_astro)
            + "&fa=" + m_astro.composeFile1.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", "")
            + "&fb=" + m_astro.composeFile2.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", ""));
        }

        protected void SetProgress()
        {
            //生成ID并访问图片页
            SetPic(AppConfig.PPLiveUrl() + "PPLive/AstroChart.aspx?ID=" + AstroBiz.GetInstance().SetGraphicID(m_astro));
            //    + "&fa=" + m_astro.composeFile1.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", "")
            //    + "&fb=" + m_astro.composeFile2.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", ""));
        }

        protected void SetReturn()
        {
            //生成ID并访问图片页
            SetPic(AppConfig.PPLiveUrl() + "PPLive/AstroChart.aspx?ID=" + AstroBiz.GetInstance().SetGraphicID(m_astro));
            //    + "&fa=" + m_astro.composeFile1.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", "")
            //    + "&fb=" + m_astro.composeFile2.Replace(AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\", ""));
        }

        protected void SetSolarArcs()
        {
            //生成ID并访问图片页
            SetPic(AppConfig.PPLiveUrl() + "PPLive/AstroChart.aspx?ID=" + AstroBiz.GetInstance().SetGraphicID(m_astro));
        }

        protected void SetPic(string url)
        {
            imgChart.ImageUrl = url;
            txtUrl.Text = url;
            picurl = url;
        }

        /// <summary>
        /// 排合盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["NowChart"];
            m_astro.type = PublicValue.AstroType.hepan;
            m_astro.compose = (PublicValue.AstroZuhe)int.Parse(drpCompareType.SelectedValue);
            m_astro.birth1 = DatePicker2.SelectedTime;
            m_astro.position1 = new LatLng(SYS_DistrictBll.GetInstance().GetModel(District2.Area3SysNo));
            if (chkDaylight2.Checked)
            {
                m_astro.IsDaylight1 = AppEnum.BOOL.True;
            }
            else
            {
                m_astro.IsDaylight1 = AppEnum.BOOL.False;
            }
            m_astro.zone1 = int.Parse(drpTimeZone2.SelectedValue);
            SetPara();
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "hepan", "document.getElementById('" + pnlHePan.ClientID + "').click();", true);
        }

        /// <summary>
        /// 推运盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["NowChart"];
            m_astro.type = PublicValue.AstroType.tuiyun;
            m_astro.transitTime = DatePickert1.SelectedTime;
            m_astro.transitPosition = m_astro.position;
            m_astro.position1 = m_astro.position;
            m_astro.transit = (PublicValue.AstroTuiyun)int.Parse(drpProgressType.SelectedValue);
            SetPara();
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "tuiyun", "document.getElementById('" + pnlTuiYun.ClientID + "').click();", true);
        }

        /// <summary>
        /// 生时校正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["OriginalChart"];
            m_astro.birth = DatePickert3.SelectedTime;
            ViewState["NowChart"] = m_astro;
            SetPara();
            InitialFate();
            DatePickert3.SelectedTime = m_astro.birth;
            Page_Load(sender, e);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnlJiaoZheng.ClientID + "').click();", true);
        }

        /// <summary>
        /// 返回原盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["OriginalChart"];
            ViewState["NowChart"] = m_astro;
            SetPara();
            InitialFate();
        }

        /// <summary>
        /// 前5分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["NowChart"];
            m_astro.birth = m_astro.birth.AddMinutes(-5);
            ViewState["NowChart"] = m_astro;
            SetPara();
            InitialFate();
            DatePickert3.SelectedTime = m_astro.birth;
            Page_Load(sender, e);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozhengqian", "document.getElementById('" + pnlJiaoZheng.ClientID + "').click();", true);
        }

        /// <summary>
        /// 后5分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["NowChart"];
            m_astro.birth = m_astro.birth.AddMinutes(5);
            ViewState["NowChart"] = m_astro;
            SetPara();
            InitialFate();
            DatePickert3.SelectedTime = m_astro.birth;
            Page_Load(sender, e);
            ScriptManager.RegisterStartupScript(UpdatePanel1,UpdatePanel1.GetType(),"jiaozhenghou","document.getElementById('"+pnlJiaoZheng.ClientID+"').click();",true);
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["NowChart"];
            SetPara();
            InitialFate();
            if (m_astro.type == PublicValue.AstroType.tuiyun)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "tuiyun", "document.getElementById('" + pnlTuiYun.ClientID + "').click();", true);
            }
            else if (m_astro.type == PublicValue.AstroType.hepan)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "hepan", "document.getElementById('" + pnlHePan.ClientID + "').click();", true);
            }
            else 
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozhengqian", "document.getElementById('" + pnlJiaoZheng.ClientID + "').click();", true);
            }
        }

        protected void SetPara()
        {
            m_astro.startsShow.Clear();
            try
            {
                for (int i = 1; i < 21; i++)
                {
                    if (((CheckBox)this.FindControl("star" + i)).Checked)
                    {
                        m_astro.startsShow.Add(i, ((CheckBox)this.FindControl("star" + i)).Text);
                    }
                }
            }
            catch
            { }
            m_astro.startsShow.Add(21, "上升");
            m_astro.startsShow.Add(24, "天底");
            m_astro.startsShow.Add(27, "下降");
            m_astro.startsShow.Add(30, "中天");
            m_astro.aspectsShow.Clear();
            m_astro.aspectsShow.Add(1, decimal.Parse(((DropDownList)this.FindControl("drpAspect0")).SelectedValue));
            m_astro.aspectsShow.Add(2, decimal.Parse(((DropDownList)this.FindControl("drpAspect180")).SelectedValue));
            m_astro.aspectsShow.Add(4, decimal.Parse(((DropDownList)this.FindControl("drpAspect120")).SelectedValue));
            m_astro.aspectsShow.Add(3, decimal.Parse(((DropDownList)this.FindControl("drpAspect90")).SelectedValue));
            m_astro.aspectsShow.Add(5, decimal.Parse(((DropDownList)this.FindControl("drpAspect60")).SelectedValue));
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            m_astro = (AstroMod)ViewState["NowChart"];
            string url = AppConfig.HomeUrl()+"Quest/Ask.aspx?";
            url += "chart1=" + m_astro.birth.ToString("yyyy-MM-dd_HH:mm_") + Convert.ToInt16(m_astro.IsDaylight) + "_" + m_astro.position.Area.SysNo + "_" + (int)m_astro.Gender +
                "&chart2=" + m_astro.birth1.ToString("yyyy-MM-dd_HH:mm_") + Convert.ToInt16(m_astro.IsDaylight1) + "_" + m_astro.position1.Area.SysNo + "_" + (int)m_astro.Gender +
                "&type=" + (int)m_astro.type;
            Response.Redirect(url);
        }

    }
}