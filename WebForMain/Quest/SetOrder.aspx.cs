using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.QA;
using AppMod.QA;
using AppBll.User;
using AppMod.User;
using AppMod.Fate;
using System.Data;
using AppCmn;
using System.Text.RegularExpressions;

namespace WebForMain.Quest
{
    public partial class SetOrder : PageBase
    {
        private int SysNo = 0;
        private int order = 0;
        public QA_QuestionMod m_qustion = new QA_QuestionMod();
        public QA_OrderMod old_order = new QA_OrderMod();

        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(1);
            Login(Request.Url.ToString());
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                    m_qustion = QA_QuestionBll.GetInstance().GetModel(SysNo);
                    //DataBind();
                }
                catch
                {
                    ShowError("");
                }
            }
            else if (Page.RouteData.Values["id"] != null && Page.RouteData.Values["id"].ToString() != "")
            {
                try
                {
                    SysNo = int.Parse(Page.RouteData.Values["id"].ToString());
                    m_qustion = QA_QuestionBll.GetInstance().GetModel(SysNo);
                    //DataBind();
                }
                catch
                {
                    ShowError("");
                }
            }
            else
            {
                if (Request.QueryString["order"] != null)
                {
                    try
                    {
                        order = int.Parse(Request.QueryString["order"]);
                        old_order = QA_OrderBll.GetInstance().GetModel(order);
                        SysNo = old_order.QuestionSysNo;
                        m_qustion = QA_QuestionBll.GetInstance().GetModel(SysNo);
                        //DataBind();
                    }
                    catch
                    {
                        ShowError("");
                    }
                }
                else if (Page.RouteData.Values["order"] != null && Page.RouteData.Values["order"].ToString() != "")
                {
                    try
                    {
                        order = int.Parse(Page.RouteData.Values["order"].ToString());
                        old_order = QA_OrderBll.GetInstance().GetModel(order);
                        SysNo = old_order.QuestionSysNo;
                        m_qustion = QA_QuestionBll.GetInstance().GetModel(SysNo);
                        //DataBind();
                    }
                    catch
                    {
                        ShowError("");
                    }
                }
                else
                {
                    ShowError("");
                }
            }

            if (m_qustion.CateSysNo != 17)//不是付费咨询则弹出
            {
                ShowError("");
            }

            if (!IsPostBack)
            {
                BindData();
            }
            
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "SetDocument", "SetDocument();", true);

        }

        protected void BindData()
        {
            try
            {
                if (m_qustion.DR != (int)AppEnum.State.normal)
                {
                    ShowError("");
                }
                m_qustion.ReadCount++;
                QA_QuestionBll.GetInstance().Update(m_qustion);

                ltrTitle.Text = m_qustion.Title;
                ltrContext.Text = m_qustion.Context;
                ltrAward.Text = m_qustion.Award.ToString();
                ltrReply.Text = m_qustion.ReplyCount.ToString();
                ltrViewNum.Text = m_qustion.ReadCount.ToString();
                USR_CustomerMod m_user = USR_CustomerBll.GetInstance().GetModel(m_qustion.CustomerSysNo);
                USR_GradeMod m_grade = USR_GradeBll.GetInstance().GetModel(m_user.GradeSysNo);
                ltrNickName.Text = m_user.NickName;
                ltrQALevel.Text = m_grade.Name;
                ltrTotalReply.Text = m_user.TotalReply.ToString();
                ltrTotalAsk.Text = m_user.TotalQuest.ToString();
                Image1.ImageUrl = AppConfig.HomeUrl()+ "ControlLibrary/ShowPhoto.aspx?type=t&id=" + m_user.Photo;

                #region 显示命盘
                FATE_ChartMod m_chart = QA_QuestionBll.GetInstance().GetChartByQuest(SysNo);
                if (m_chart != null && m_chart.SysNo != AppConst.IntNull)
                {
                    if (GetSession().CustomerEntity == null || GetSession().CustomerEntity.SysNo == AppConst.IntNull)
                    {
                        Astro1.input = m_chart;
                        Astro1.Visible = true;
                    }
                    else if (GetSession().CustomerEntity.FateType == (int)AppEnum.FateType.ziwei)
                    {
                        Ziwei1.input = m_chart;
                        Ziwei1.Visible = true;
                    }
                    else if (GetSession().CustomerEntity.FateType == (int)AppEnum.FateType.bazi)
                    {
                        Bazi1.input = m_chart;
                        Bazi1.Visible = true;
                    }
                    else
                    {
                        Astro1.input = m_chart;
                        Astro1.Visible = true;
                    }
                }
                #endregion

                #region 绑定原报价单信息
                if (order != 0)
                {
                    TextBox2.Text = old_order.Words.ToString();
                    TextBox2.ReadOnly = true;
                    TextBox3.Text = old_order.Price.ToString();
                    TextBox3.ReadOnly = true;
                    txtDescription.Text = old_order.Description;
                    txtDescription.ReadOnly = true;
                    txtTrial.Text = old_order.Trial;
                    txtTrial.ReadOnly = true;
                }
                #endregion
            }
            catch
            {
                ShowError("");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Login(Request.Url.ToString());
            if (order == 0)
            {
                #region 判断输入项
                decimal price = 0;
                try
                {
                    price = decimal.Parse(TextBox3.Text.Trim());
                    pricetip.InnerHtml = "";
                }
                catch
                {
                    pricetip.InnerHtml = "<samp>预计消费金额只可填写数字，请重新输入</samp>";
                }

                int words = 0;
                try
                {
                    words = int.Parse(TextBox2.Text.Trim());
                    wordstip.InnerHtml = "";
                }
                catch
                {
                    wordstip.InnerHtml = "<samp>最少字数只可填写数字，请重新输入</samp>";
                }
                #endregion

                QA_AnswerMod m_answer = new QA_AnswerMod();
                m_answer.Award = 0;
                m_answer.Context = "";
                if (GetSession().CustomerEntity == null || GetSession().CustomerEntity.SysNo == AppConst.IntNull)
                {
                    m_answer.CustomerSysNo = 0;
                }
                else
                {
                    m_answer.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                }
                m_answer.DR = (int)AppEnum.State.normal;
                m_answer.Hate = 0;
                m_answer.Love = 0;
                m_answer.QuestionSysNo = SysNo;
                m_answer.Title = "";
                m_answer.TS = DateTime.Now;

                QA_OrderMod m_order = new QA_OrderMod();
                m_order.CustomerSysNo = m_answer.CustomerSysNo;
                m_order.Description = txtDescription.Text.Trim();
                m_order.Price = price;
                m_order.QuestionSysNo = m_answer.QuestionSysNo;
                m_order.Score = AppConst.IntNull;
                m_order.Status = (int)AppEnum.ConsultOrderStatus.beforepay;
                m_order.Trial = txtTrial.Text.Trim();
                m_order.TS = DateTime.Now;
                m_order.Words = words;

                try
                {
                    QA_OrderBll.GetInstance().SetOrder(m_order, m_answer);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ok", "alert('报价发布成功！');location.href='" + AppConfig.HomeUrl() + "Quest/Consult/" + SysNo + "'", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "nook", "alert('系统故障,发布失败！');", true);
                }
            }
            else
            {
                QA_AnswerMod m_answer = QA_AnswerBll.GetInstance().GetModel(old_order.AnswerSysNo);
                m_answer.Context = txtContext.Text;
                old_order.Status = (int)AppEnum.ConsultOrderStatus.beforeconfirm;
                try
                {
                    QA_AnswerBll.GetInstance().Update(m_answer);
                    QA_OrderBll.GetInstance().Update(old_order);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ok", "alert('解答提交成功！');location.href='" + AppConfig.HomeUrl() + "Quest/Consult/" + SysNo + "'", true);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "nook", "alert('系统故障,提交失败！');", true);
                }
                
            }
        }


    }
}
