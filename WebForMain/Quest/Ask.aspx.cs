using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.QA;
using AppMod.QA;
using AppBll.User;
using AppBll.Fate;
using AppMod.Fate;
using AppCmn;
using System.Data;
using WebMonitor;
using PPLive;


namespace WebForMain.Quest
{
    public partial class Ask : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(1);
            if (!IsPostBack)
            {
                Login(Request.Url.ToString());


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

                drpTimeZone1.DataSource = timezone;
                drpTimeZone1.DataTextField = "value";
                drpTimeZone1.DataValueField = "key";
                drpTimeZone1.DataBind();
                drpTimeZone1.SelectedIndex = 4;

                drpTimeZone2.DataSource = timezone;
                drpTimeZone2.DataTextField = "value";
                drpTimeZone2.DataValueField = "key";
                drpTimeZone2.DataBind();
                drpTimeZone2.SelectedIndex = 4;

                DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(1);
                //m_dt.Columns.Add("SysNo");
                //m_dt.Columns.Add("Name");
                //for (int i = 0; i < parent.Rows.Count; i++)
                //{
                //    DataTable tmp = QA_CategoryBll.GetInstance().GetCates(int.Parse(parent.Rows[i]["SysNo"].ToString()));
                //    for(int j=0;j<tmp.Rows.Count;j++)
                //    {
                //        DataRow m_dr = m_dt.NewRow();
                //        m_dr["SysNo"] = tmp.Rows[j]["SysNo"];
                //        m_dr["Name"] = parent.Rows[i]["Name"].ToString()+"-"+tmp.Rows[j]["Name"].ToString();
                //        m_dt.Rows.Add(m_dr);
                //    }
                //}
                drpCate.DataSource = m_dt;
                drpCate.DataValueField = "SysNo";
                drpCate.DataTextField = "Name";
                drpCate.DataBind();
                drpCate.Items.Insert(0, new ListItem("请选择", "0"));

                drpType.DataSource = AppEnum.GetChartType();
                drpType.DataTextField = "value";
                drpType.DataValueField = "key";
                drpType.DataBind();
                drpType.SelectedIndex = 1;

                ltrPoint.Text = GetSession().CustomerEntity.Point.ToString();

                #region 占星骰子问题
                if ((Request.QueryString["type"] != null && Request.QueryString["type"] == "dice")||
                    (Page.RouteData.Values["type"]!=null &&Page.RouteData.Values["type"].ToString()=="dice"))
                {
                    try
                    {
                        int star = int.Parse(Request.QueryString["star"])+1;
                        int house = int.Parse(Request.QueryString["house"])+1;
                        int constellation = int.Parse(Request.QueryString["const"])+1;
                        txtTitle.Text = Request.QueryString["ask"] + " #" + PublicValue.GetAstroStar(star)+" " + house + "宫 " + PublicValue.GetConstellation(constellation) + "#";
                        drpType.SelectedIndex = drpType.Items.IndexOf(drpType.Items.FindByValue("0"));
                        drpCate.SelectedIndex = drpCate.Items.IndexOf(drpCate.Items.FindByValue("7"));
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "touzi", "qaTypeChanged(document.getElementById('"+drpType.ClientID+"'));", true);
                    }
                    catch { }
                    }

                #endregion
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Login(Request.Url.ToString());
            #region 判断输入项
            if (drpCate.SelectedIndex == 0)
            {
                CateTip.InnerHtml = "请选择分类";
                CateTip.Attributes["class"] = "err";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "typemodify", "qaTypeChanged(document.getElementById('" + drpType.ClientID + "'));", true);
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                TitleTip.InnerHtml = "请输入标题";
                TitleTip.Attributes["class"] = "err";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "typemodify", "qaTypeChanged(document.getElementById('" + drpType.ClientID + "'));", true);
                return;
            }
            if (txtTitle.Text.Trim().Length > 30)
            {
                TitleTip.InnerHtml = "您输入的标题太长，请控制在30字以内";
                TitleTip.Attributes["class"] = "err";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "typemodify", "qaTypeChanged(document.getElementById('" + drpType.ClientID + "'));", true);
                return;
            }
            int pointpay = 0;
            try
            {
                pointpay = int.Parse(txtPoint.Text.Trim());
            }
            catch
            {
                PointTip.InnerHtml = "您输入的积分数值有误，请重新输入";
                PointTip.Attributes["class"] = "err";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "typemodify", "qaTypeChanged(document.getElementById('" + drpType.ClientID + "'));", true);
                return;
            }
            if (pointpay > GetSession().CustomerEntity.Point)
            {
                PointTip.InnerHtml = "您最多可用" + GetSession().CustomerEntity.Point.ToString() + "积分";
                PointTip.Attributes["class"] = "err";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "typemodify", "qaTypeChanged(document.getElementById('" + drpType.ClientID + "'));", true);
                return;
            }
            //if (District1.Area3SysNo == 0)
            //{
                
            //}
            //else if (drpType.SelectedIndex == 1)
            //{
 
            //}

            #endregion
            
            try
            {
                QA_QuestionMod m_quest = new QA_QuestionMod();
                m_quest.Award = pointpay;
                m_quest.CateSysNo = int.Parse(drpCate.SelectedValue);
                m_quest.Context = txtContext.Text.Trim();
                m_quest.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                m_quest.LastReplyTime = DateTime.Now;
                m_quest.ReplyCount = 0;
                m_quest.ReadCount = 0;
                m_quest.Title = txtTitle.Text.Trim();
                m_quest.TS = DateTime.Now;
                m_quest.DR = (int)AppEnum.State.normal;

                int sysno = 0;

                QA_QuestionBll.GetInstance().AddQuest(m_quest,true);
                sysno = m_quest.SysNo;
                RefreshSession();

                FATE_ChartMod m_chart = new FATE_ChartMod();
                m_chart.CharType = int.Parse(drpType.SelectedValue);
                if (m_chart.CharType != (int)AppEnum.ChartType.nochart)
                {
                    m_chart.FirstBirth = DatePicker1.SelectedTime;
                    m_chart.FirstPoi = District1.lng + "|" + District1.lat;
                    m_chart.Transit = DateTime.Now;
                    m_chart.TransitPoi = m_chart.FirstPoi;
                    m_chart.TheoryType = 0;
                    m_chart.FirstPoiName = District1.Area1Name + "-" + District1.Area2Name + "-" + District1.Area3Name;
                    m_chart.FirstTimeZone = -8;
                    m_chart.FirstGender = int.Parse(drpGender1.SelectedValue);
                    if (chkDaylight1.Checked)
                    {
                        m_chart.FirstDayLight = (int)AppEnum.BOOL.True;
                    }
                    else
                    {
                        m_chart.FirstDayLight = (int)AppEnum.BOOL.False;
                    }
                    if (m_chart.CharType == (int)AppEnum.ChartType.relation)
                    {
                        m_chart.SecondBirth = DatePicker2.SelectedTime;
                        m_chart.SecondPoi = District2.lng + "|" + District2.lat;
                        m_chart.SecondPoiName = District2.Area1Name + "-" + District2.Area2Name + "-" + District2.Area3Name;
                        m_chart.SecondTimeZone = -8;
                        m_chart.SecondGender = int.Parse(drpGender2.SelectedValue);
                        if (chkDaylight2.Checked)
                        {
                            m_chart.SecondDayLight = (int)AppEnum.BOOL.True;
                        }
                        else
                        {
                            m_chart.SecondDayLight = (int)AppEnum.BOOL.False;
                        }
                    }
                    m_chart.TS = DateTime.Now;
                    m_chart.DR = (int)AppEnum.State.normal;
                    int fatesysno = FATE_ChartBll.GetInstance().Add(m_chart);

                    REL_Question_ChartMod m_qchart = new REL_Question_ChartMod();
                    m_qchart.Chart_SysNo = fatesysno;
                    m_qchart.Question_SysNo = sysno;
                    REL_Question_ChartBll.GetInstance().Add(m_qchart);
                }
                


                LogManagement.getInstance().WriteTrace("前台发布问题", "Ask", "IP:" + Request.UserHostAddress + "|UID:" + GetSession().CustomerEntity.Email);
                Page.ClientScript.RegisterStartupScript(this.GetType(),"askok","alert('问题发布成功！');",true);
                Response.Redirect(AppConfig.HomeUrl()+"Quest/Question/" + sysno,false);
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "QA-Add", Request.UserHostAddress, "发布问题失败");
            }
        }

    }
}