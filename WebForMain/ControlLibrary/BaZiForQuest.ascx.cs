using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PPLive.BaZi;
using PPLive;
using AppCmn;
using AppBll.WebSys;
using AppMod.WebSys;
using AppMod.Fate;

namespace WebForMain.ControlLibrary
{
    public partial class BaZiForQuest : System.Web.UI.UserControl
    {
        public FATE_ChartMod input
        {
            set { _input = value; }
            get { return _input; }
        }
        public BaZiMod m_bazi
        {
            set { _m_bazi = value; }
            get { return _m_bazi; }
        }
        public bool total
        {
            set { _total = value; }
            get { return _total; }
        }
        public bool IfRealTime
        {
            set { _realtime = value; }
            get { return _realtime; }
        }

        private FATE_ChartMod _input = null;
        private BaZiMod _m_bazi = null;
        private bool hepan = false;
        private bool _total = true;
        private bool _realtime = true;
        public string chartpara = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                if (!IsPostBack)
                {
                    if (_input != null)
                    {
                        InitialChart();
                    }
                    else if (_m_bazi != null)
                    {
                        InitialFate();
                        tab1.Style["display"] = "none";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "start", "document.getElementById('" + pnl1.ClientID + "').click();", true);
                    }
                    ViewState["OriginalChart"] = _m_bazi;
                    ViewState["NowChart"] = _m_bazi;
                }
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "SetDocument", "SetDocument();", true);
                chartpara = m_bazi.BirthTime.Date.ToString("yyyy_MM_dd_HH_mm") + "_" + ((int)m_bazi.Gender).ToString();
            }
        }

        /// <summary>
        /// 用于赋予datatable后初始化页面，其中本命盘显示本命盘，合盘则显示比较盘
        /// </summary>
        public void InitialChart()
        {
            if (_input == null ||  _input.CharType == null)
            {
                return;
            }

            _m_bazi = new BaZiMod();
            #region 设置实体各种参数
            string[] tmplatlng = _input.FirstPoi.ToString().Split(new char[] { '|' });
            m_bazi.BirthTime = new DateEntity(_realtime ? PublicDeal.GetInstance().RealTime(DateTime.Parse(_input.FirstBirth.ToString()),
                new LatLng(tmplatlng[1], tmplatlng[0], _input.FirstPoiName)) : DateTime.Parse(_input.FirstBirth.ToString()));
            m_bazi.AreaName = _input.FirstPoiName.ToString();
            m_bazi.Longitude = tmplatlng[0];
            m_bazi.Gender = (AppEnum.Gender)_input.FirstGender;
            SetBenMing();

            if (_input.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
            {
                tmplatlng = _input.SecondPoi.ToString().Split(new char[] { '|' });
                m_bazi.BirthTime = new DateEntity(_realtime ? PublicDeal.GetInstance().RealTime(DateTime.Parse(_input.SecondBirth.ToString()),
                    new LatLng(tmplatlng[1], tmplatlng[0], _input.SecondPoiName)) : DateTime.Parse(_input.SecondBirth.ToString()));
                m_bazi.AreaName = _input.SecondPoiName.ToString();
                m_bazi.Longitude = tmplatlng[0];
                m_bazi.Gender = (AppEnum.Gender)_input.SecondGender;
                SetHePan();
            }
            #endregion
        }

        /// <summary>
        /// 用于赋予了实体后初始化页面
        /// </summary>
        public void InitialFate()
        {
            if (!hepan)
            {
                SetBenMing();
            }
            else
            {
                SetHePan();
            }
        }

        //本命盘排盘
        protected void SetBenMing()
        {
            BaZiBiz.GetInstance().TimeToBaZi(ref _m_bazi);
            Literal1.Text = BaZiBiz.GetInstance().BaziToHTML(m_bazi, total);
            if (!IsPostBack)
            {
                ViewState["OriginalChart"] = m_bazi;
                ViewState["NowChart"] = m_bazi;
            }
        }
        //和盘排盘
        protected void SetHePan()
        {
            BaZiBiz.GetInstance().TimeToBaZi(ref _m_bazi);
            Literal2.Text = BaZiBiz.GetInstance().BaziToHTML(m_bazi, total);
            if (!IsPostBack)
            {
                ViewState["OriginalChart1"] = m_bazi;
                ViewState["NowChart1"] = m_bazi;
            }
        }


        #region 盘1
        //推运
        //校正
        protected void Button15_Click(object sender, EventArgs e)
        {
            m_bazi = (BaZiMod)ViewState["NowChart"];
            m_bazi.BirthTime = new DateEntity(m_bazi.BirthTime.Date.AddHours(-2));
            ViewState["NowChart"] = m_bazi;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jz", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnljiaozheng1.ClientID + "').click();", true);
        }
        protected void Button16_Click(object sender, EventArgs e)
        {
            m_bazi = (BaZiMod)ViewState["NowChart"];
            m_bazi.BirthTime = new DateEntity(m_bazi.BirthTime.Date.AddHours(2));
            ViewState["NowChart"] = m_bazi;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jz", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnljiaozheng1.ClientID + "').click();", true);
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            m_bazi = (BaZiMod)ViewState["NowChart"];
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jz", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnljiaozheng1.ClientID + "').click();", true);
        }
        #endregion

        #region 盘2
        //校正
        protected void Button25_Click(object sender, EventArgs e)
        {
            m_bazi = (BaZiMod)ViewState["NowChart1"];
            m_bazi.BirthTime = new DateEntity(m_bazi.BirthTime.Date.AddHours(-2));
            ViewState["NowChart1"] = m_bazi;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jz", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnljiaozheng2.ClientID + "').click();", true);
        }
        protected void Button26_Click(object sender, EventArgs e)
        {
            m_bazi = (BaZiMod)ViewState["NowChart1"];
            m_bazi.BirthTime = new DateEntity(m_bazi.BirthTime.Date.AddHours(2));
            ViewState["NowChart1"] = m_bazi;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jz", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnljiaozheng2.ClientID + "').click();", true);
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            m_bazi = (BaZiMod)ViewState["OriginalChart1"];
            ViewState["NowChart1"] = m_bazi;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jz", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnljiaozheng2.ClientID + "').click();", true);
        }
        #endregion

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            m_bazi = (BaZiMod)ViewState["NowChart"];
            string url = AppConfig.HomeUrl() + "Quest/Ask.aspx?";
            url += "chart1=" + m_bazi.BirthTime.Date.ToString("yyyy-MM-dd_HH:mm") + "_0_2146_" + (int)m_bazi.Gender +
                "&chart2=" + m_bazi.BirthTime.Date.ToString("yyyy-MM-dd_HH:mm") + "_0_2146_" + (int)m_bazi.Gender +
                "&type=" + (int)PublicValue.AstroType.benming;
            Response.Redirect(url);
        }
    }
}