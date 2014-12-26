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
using AppBll.WebSys;
using AppMod.WebSys;
using AppMod.Fate;

namespace WebForMain.ControlLibrary
{
    public partial class ZiWeiForQuest : System.Web.UI.UserControl
    {
        public FATE_ChartMod input
        {
            set { _input = value; }
            get { return _input; }
        }
        public ZiWeiMod m_ziwei
        {
            set { _m_ziwei = value; }
            get { return _m_ziwei; }
        }
        public int[] Paras
        {
            set { _paras = value; }
            get { return _paras; }
        }
        public bool Trans
        {
            set { _trans = value; }
            get { return _trans; }
        }
        public bool IfRealTime
        {
            set { _realtime = value; }
            get { return _realtime; }
        }

        private FATE_ChartMod _input = null;
        private ZiWeiMod _m_ziwei =null;
        private int[] _paras = {1,1,0,1};
        private bool _trans = false;
        private bool hepan = false;
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
                    else if (_m_ziwei != null)
                    {
                        InitialFate();
                        tab1.Style["display"] = "none";
                    }
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "start", "document.getElementById('" + pnl1.ClientID + "').click();", true);
                    chartpara = m_ziwei.BirthTime.Date.ToString("yyyy_MM_dd_HH_mm") + "_" + ((int)m_ziwei.Gender).ToString();
                }
                
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "SetDocument", "SetDocument();", true);
            }
        }

        /// <summary>
        /// 用于赋予datatable后初始化页面，其中本命盘显示本命盘，合盘则显示比较盘
        /// </summary>
        public void InitialChart()
        {
            if (_input == null || _input.CharType == null)
            {
                return;
            }

            _m_ziwei = new ZiWeiMod();
            #region 设置实体各种参数
            //默认做太阳时修正
            string[] tmplatlng = _input.FirstPoi.ToString().Split(new char[] { '|' });
                m_ziwei.BirthTime = new DateEntity(_realtime?PublicDeal.GetInstance().RealTime(DateTime.Parse(_input.FirstBirth.ToString()),
                    new LatLng(tmplatlng[1], tmplatlng[0], _input.FirstPoiName)) : DateTime.Parse(_input.FirstBirth.ToString()));
                m_ziwei.Gender = (AppEnum.Gender)int.Parse(_input.FirstGender.ToString());
            m_ziwei.RunYue = PublicValue.ZiWeiRunYue.dangxia;
            m_ziwei.TransitTime = new DateEntity(DateTime.Now);
            #endregion
            SetBenMing();

            if (_input.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
            {
                _m_ziwei = new ZiWeiMod();
                #region 设置实体各种参数
                tmplatlng = _input.SecondPoi.ToString().Split(new char[] { '|' });
                m_ziwei.BirthTime = new DateEntity(_realtime ? PublicDeal.GetInstance().RealTime(DateTime.Parse(_input.SecondBirth.ToString()),
                    new LatLng(tmplatlng[1], tmplatlng[0], _input.SecondPoiName)) : DateTime.Parse(_input.SecondBirth.ToString()));
                m_ziwei.Gender = (AppEnum.Gender)int.Parse(_input.SecondGender.ToString());
                m_ziwei.RunYue = PublicValue.ZiWeiRunYue.dangxia;
                m_ziwei.TransitTime = new DateEntity(DateTime.Now);
                #endregion
                SetHePan();
            }
            else
            {
                tab1.Style["display"] = "none";
            }
        }

        /// <summary>
        /// 用于赋予了实体后初始化页面
        /// </summary>
        public void InitialFate()
        {
            if (!_trans)
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
            else
            {
                SetLiuXian();
            }
        }

        //本命盘排盘
        protected void SetBenMing()
        {
            m_ziwei = ZiWeiBiz.GetInstance().TimeToZiWei(m_ziwei.BirthTime, m_ziwei.Gender, _paras);
            Literal1.Text = ZiWeiBiz.GetInstance().ZiWeiToHTML(m_ziwei);
            LinkButton3.Visible = false;
            LinkButton1.Visible = true;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
            if (!IsPostBack)
            {
                ViewState["OriginalChart"] = _m_ziwei;
                ViewState["NowChart"] = _m_ziwei;
            }
        }
        //和盘排盘
        protected void SetHePan()
        {
            m_ziwei = ZiWeiBiz.GetInstance().TimeToZiWei(m_ziwei.BirthTime, m_ziwei.Gender, _paras);
            Literal2.Text = ZiWeiBiz.GetInstance().ZiWeiToHTML(m_ziwei);
            LinkButton4.Visible = false;
            LinkButton2.Visible = true;
            Button7.Visible = false;
            Button8.Visible = false;
            Button9.Visible = false;
            Button10.Visible = false;
            if (!IsPostBack)
            {
                ViewState["OriginalChart1"] = _m_ziwei;
                ViewState["NowChart1"] = _m_ziwei;
            }
        }
        //流限盘排盘
        protected void SetLiuXian()
        {
            m_ziwei = ZiWeiBiz.GetInstance().TransitToZiWei(m_ziwei.BirthTime, m_ziwei.TransitTime, m_ziwei.Gender, _paras);
            if (!hepan)
            {
                Literal1.Text = ZiWeiBiz.GetInstance().ZiWeiLiuToHTML(m_ziwei);
                //ltrTransTime1.Text = m_ziwei.TransitTime.Date.ToString("yyyy年");
                LinkButton1.Visible = false;
                LinkButton3.Visible = true;
                Button3.Visible = true;
                Button4.Visible = true;
                Button5.Visible = true;
                Button6.Visible = true;
                if (!IsPostBack)
                {
                    ViewState["OriginalChart"] = _m_ziwei;
                    ViewState["NowChart"] = _m_ziwei;
                }
            }
            else
            {
                Literal2.Text = ZiWeiBiz.GetInstance().ZiWeiLiuToHTML(m_ziwei);
                //ltrTransTime2.Text = m_ziwei.TransitTime.Date.ToString("yyyy年");
                LinkButton2.Visible = false;
                LinkButton4.Visible = true;
                Button7.Visible = true;
                Button8.Visible = true;
                Button9.Visible = true;
                Button10.Visible = true;
                if (!IsPostBack)
                {
                    ViewState["OriginalChart1"] = _m_ziwei;
                    ViewState["NowChart1"] = _m_ziwei;
                }
            }
        }



        #region 盘1
        //推运
        protected void Button11_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            PublicValue.TianGan tmp =  m_ziwei.TransitTime.NongliTG;
            m_ziwei.TransitTime.Date = m_ziwei.TransitTime.Date.AddYears(-8);
            while (m_ziwei.TransitTime.NongliTG != tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(-6));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnltuiyun1.ClientID + "').click();", true);
        }
        protected void Button12_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            PublicValue.TianGan tmp = m_ziwei.TransitTime.NongliTG;
            m_ziwei.TransitTime.Date = m_ziwei.TransitTime.Date.AddYears(8);
            while (m_ziwei.TransitTime.NongliTG != tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(6));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnltuiyun1.ClientID + "').click();", true);
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            PublicValue.TianGan tmp = m_ziwei.TransitTime.NongliTG;
            while (m_ziwei.TransitTime.NongliTG == tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(-1));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnltuiyun1.ClientID + "').click();", true);
        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            PublicValue.TianGan tmp = m_ziwei.TransitTime.NongliTG;
            while (m_ziwei.TransitTime.NongliTG == tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(1));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnltuiyun1.ClientID + "').click();", true);
        }
        //校正
        protected void Button15_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            m_ziwei.BirthTime = new DateEntity(m_ziwei.BirthTime.Date.AddHours(-2));
            ViewState["NowChart"] = m_ziwei;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnljiaozheng1.ClientID + "').click();", true);
        }
        protected void Button16_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            m_ziwei.BirthTime = new DateEntity(m_ziwei.BirthTime.Date.AddHours(2));
            ViewState["NowChart"] = m_ziwei;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnljiaozheng1.ClientID + "').click();", true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            InitialFate();
            
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnltuiyun1.ClientID + "').click();", true);
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            m_ziwei.TransitTime = new DateEntity(DateTime.Now);
            _trans = true;
            InitialFate();

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnltuiyun1.ClientID + "').click();", true);
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl1.ClientID + "').click();document.getElementById('" + pnljiaozheng1.ClientID + "').click();", true);
        }
        #endregion

        #region 盘2
        //推运
        protected void Button21_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart1"];
            PublicValue.TianGan tmp = m_ziwei.TransitTime.NongliTG;
            m_ziwei.TransitTime.Date = m_ziwei.TransitTime.Date.AddYears(-8);
            while (m_ziwei.TransitTime.NongliTG == tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(-6));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnltuiyun2.ClientID + "').click();", true);
        }
        protected void Button22_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart1"];
            PublicValue.TianGan tmp = m_ziwei.TransitTime.NongliTG;
            m_ziwei.TransitTime.Date = m_ziwei.TransitTime.Date.AddYears(8);
            while (m_ziwei.TransitTime.NongliTG == tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(6));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnltuiyun2.ClientID + "').click();", true);
        }
        protected void Button23_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart1"];
            PublicValue.TianGan tmp = m_ziwei.TransitTime.NongliTG;
            while (m_ziwei.TransitTime.NongliTG != tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(-1));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnltuiyun2.ClientID + "').click();", true);
        }
        protected void Button24_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart1"];
            PublicValue.TianGan tmp = m_ziwei.TransitTime.NongliTG;
            while (m_ziwei.TransitTime.NongliTG != tmp)
            {
                m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date.AddMonths(1));
            }
            m_ziwei.TransitTime = new DateEntity(m_ziwei.TransitTime.Date);
            _trans = true;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnltuiyun2.ClientID + "').click();", true);
        }
        //校正
        protected void Button25_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart1"];
            m_ziwei.BirthTime = new DateEntity(m_ziwei.BirthTime.Date.AddHours(-2));
            ViewState["NowChart1"] = m_ziwei;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnljiaozheng2.ClientID + "').click();", true);
        }
        protected void Button26_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart1"];
            m_ziwei.BirthTime = new DateEntity(m_ziwei.BirthTime.Date.AddHours(2));
            ViewState["NowChart1"] = m_ziwei;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnljiaozheng2.ClientID + "').click();", true);
        } 
        
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["OriginalChart1"];
            ViewState["NowChart1"] = m_ziwei;
            hepan = true;
            InitialFate();
            
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnltuiyun2.ClientID + "').click();", true);
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart1"];
            m_ziwei.TransitTime = new DateEntity(DateTime.Now);
            _trans = true;
            hepan = true;
            InitialFate();
            
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnltuiyun2.ClientID + "').click();", true);
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["OriginalChart1"];
            ViewState["NowChart1"] = m_ziwei;
            hepan = true;
            InitialFate();
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "jiaozheng", "document.getElementById('" + pnl2.ClientID + "').click();document.getElementById('" + pnljiaozheng2.ClientID + "').click();", true);
        }
        #endregion

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            m_ziwei = (ZiWeiMod)ViewState["NowChart"];
            string url = AppConfig.HomeUrl() + "Quest/Ask.aspx?";
            url += "chart1=" + m_ziwei.BirthTime.Date.ToString("yyyy-MM-dd_HH:mm")+"_0_2146_" + (int)m_ziwei.Gender +
                "&chart2=" + m_ziwei.BirthTime.Date.ToString("yyyy-MM-dd_HH:mm")+"_0_2146_" + (int)m_ziwei.Gender +
                "&type=" + (int)PublicValue.AstroType.benming;
            Response.Redirect(url);
        }
    }
}