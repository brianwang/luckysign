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
        private int pageindex = 1;
        private int pagesize = AppConst.PageSize;
        public QA_QuestionMod m_qustion = new QA_QuestionMod();

        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(1);
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
                ShowError("");
            }

            if (m_qustion.CateSysNo != 17)//不是付费咨询则弹出
            {
                ShowError("");
            }

            if (Request.QueryString["pn"] != null)
            {
                try
                {
                    pageindex = int.Parse(Request.QueryString["pn"]);
                }
                catch
                { }
            }
            else if (Page.RouteData.Values["pn"] != null && Page.RouteData.Values["pn"].ToString() != "")
            {
                try
                {
                    pageindex = int.Parse(Page.RouteData.Values["pn"].ToString());
                }
                catch
                {
                    ShowError("");
                }
            }
            if (!IsPostBack)
            {
                BindData();
            }
            #region 登录状态判断
            if (GetSession().CustomerEntity == null || GetSession().CustomerEntity.SysNo == AppConst.IntNull)
            {
                ShowError("");
            }
            #endregion
            
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "SetDocument", "SetDocument();", true);

        }
        #region 发布回答


        protected void lkbReply2_Click(object sender, EventArgs e)
        {
            QA_AnswerMod m_answer = new QA_AnswerMod();
            m_answer.Award = 0;
            m_answer.Context = Server.HtmlEncode(txtReply2.Text.Trim());
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

            if (SaveReply(m_answer))
            {
                ClearReply();
                BindList();
            }
        }

        private bool SaveReply(QA_AnswerMod m_answer)
        {
            try
            {
                QA_AnswerBll.GetInstance().AddAnswer(m_answer);
                RefreshSession();
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addanswer", "alert('回答发布成功！');", true);
                return true;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addanswer", "alert('系统故障,发布失败！');", true);
                return false;
            }

        }
        private void ClearReply()
        {
            //txtReply.Text = "";

            txtReply2.Text = "";

        }

        #endregion


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
                ltrTime.Text = m_qustion.TS.ToString("yyyy-MM-dd HH:mm:ss");
                ltrViewNum.Text = m_qustion.ReadCount.ToString();
                if (GetSession().CustomerEntity.SysNo == m_qustion.CustomerSysNo)
                {
                    LinkButton5.Style["display"] = "";
                    ltrTime.Text += "&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;";
                }
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

                
            }
            catch
            {
                ShowError("");
            }
        }


    }
}
