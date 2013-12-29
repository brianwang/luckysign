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
        private int[] _paras = {1,1,0,0};
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
                m_ziwei.BirthTime = new DateEntity(_realtime?RealTime(DateTime.Parse(_input.FirstBirth.ToString()),
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
                if (_realtime)
                {
 
                }
                m_ziwei.BirthTime = new DateEntity(_realtime?RealTime(DateTime.Parse(_input.SecondBirth.ToString()),
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

        protected DateTime RealTime(DateTime input, LatLng poi)
        {
            TimeSpan latspan = new TimeSpan(0, 0, Convert.ToInt32((poi.longitude - 120) * 4 * 60));
            int daycount = input.DayOfYear;
            if (!((input.Year % 4 == 0 && input.Year % 100 != 0) || input.Year % 400 == 0))
            {
                if (daycount > 59)
                {
                    daycount++;
                }
            }
            TimeSpan timespan = new TimeSpan(0, int.Parse(realtime[daycount].Split(new char[] { '|' })[0]), int.Parse(realtime[daycount].Substring(0, 1) + realtime[daycount].Split(new char[] { '|' })[1]));
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
"-3|3"
        };
        #endregion


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