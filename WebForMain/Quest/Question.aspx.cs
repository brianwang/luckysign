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

namespace WebForMain.Quest
{
    public partial class Question : PageBase
    {
        private int SysNo = 0;
        private int pageindex = 1;
        private int pagesize = 12;
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
                    Response.Redirect("../Error.aspx");
                }
            }
            else
            {
                Response.Redirect("../Error.aspx");
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
            if (!IsPostBack)
            {
                BindData();
            }
            #region 登录状态判断
            if (GetSession().CustomerEntity == null || GetSession().CustomerEntity.SysNo == AppConst.IntNull)
            {
                nologin.Style["display"] = "";
                txtReply2.Enabled = false;
                Button3.Style["display"] = "none";
                IsLogined.Value = "FALSE";
            }
            else
            {
                nologin.Style["display"] = "none";
                txtReply2.Enabled = true;
                Button3.Style["display"] = "";
                Image2.ImageUrl = "../ControlLibrary/ShowPhoto.aspx?type=t&id=" + GetSession().CustomerEntity.Photo;
                IsLogined.Value = "TRUE";
            }
            #endregion
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SetDocument", "SetDocument();", true);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "SetDocument", "SetDocument();", true);

        }
        #region 发布回答
        protected void lkbReply_Click(object sender, EventArgs e)
        {
            if (GetSession().CustomerEntity == null || GetSession().CustomerEntity.SysNo == AppConst.IntNull)
            {
                return;
            }
            QA_AnswerMod m_answer = new QA_AnswerMod();
            m_answer.Award = 0;
            m_answer.Context = Server.HtmlEncode(txtReply.Text.Trim());
            m_answer.CustomerSysNo = GetSession().CustomerEntity.SysNo;
            m_answer.DR = (int)AppEnum.State.normal;
            m_answer.Hate = 0;
            m_answer.Love = 0;
            m_answer.QuestionSysNo = SysNo;
            m_answer.Title = "";
            m_answer.TS = DateTime.Now;

            SaveReply(m_answer);
            ClearReply();
            BindList();
        }

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

            SaveReply(m_answer);
            ClearReply();
            BindList();
        }

        private void SaveReply(QA_AnswerMod m_answer)
        {
            try
            {
                QA_AnswerBll.GetInstance().AddAnswer(m_answer);
                RefreshSession();
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addanswer", "alert('回答发布成功！');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addanswer", "alert('系统故障,发布失败！');", true);
            }

        }
        private void ClearReply()
        {
            txtReply.Text = "";

            txtReply2.Text = "";

        }

        #endregion

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Love")
            {
                if (!CheckCommentCookies(int.Parse(e.CommandArgument.ToString())))
                {
                    QA_AnswerMod m_answer = QA_AnswerBll.GetInstance().GetModel(int.Parse(e.CommandArgument.ToString()));
                    m_answer.Love++;
                    QA_AnswerBll.GetInstance().UpDate(m_answer);
                    SetCommentCookies(int.Parse(e.CommandArgument.ToString()));
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addlove", "alert('您对该回答表示了赞同！');", true);
                    BindList();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addlove", "alert('您已对该回答发表了看法！');", true);
                }
            }
            else if (e.CommandName == "Hate")
            {
                if (!CheckCommentCookies(int.Parse(e.CommandArgument.ToString())))
                {
                    QA_AnswerMod m_answer = QA_AnswerBll.GetInstance().GetModel(int.Parse(e.CommandArgument.ToString()));
                    m_answer.Hate++;
                    QA_AnswerBll.GetInstance().UpDate(m_answer);
                    SetCommentCookies(int.Parse(e.CommandArgument.ToString()));
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addhate", "alert('您对该回答表示了不赞同！');", true);
                    BindList();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addlove", "alert('您已对该回答发表了看法！');", true);
                }
            }
            else if (e.CommandName == "Award")
            {
                QA_QuestionMod m_quest = QA_QuestionBll.GetInstance().GetModel(SysNo);
                int usedAward = QA_AnswerBll.GetInstance().GetUsedAward(SysNo);
                ltrMax.Text = "该问题的总悬赏积分为：" + (m_quest.Award - usedAward).ToString();
                HiddenField1.Value = e.CommandArgument.ToString();
                ModalPopupExtender1.Show();
            }
            else if (e.CommandName == "Reply")
            {
                if (((TextBox)e.Item.FindControl("txtRe")).Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addComment", "alert('请输入您的回复信息！');", true);
                    return;
                }
                try
                {
                    QA_CommentMod m_comment = new QA_CommentMod();
                    m_comment.AnswerSysNo = int.Parse(e.CommandArgument.ToString());
                    m_comment.Context = Server.HtmlEncode(((TextBox)e.Item.FindControl("txtRe")).Text.Trim());
                    m_comment.DR = (int)AppEnum.State.normal;
                    m_comment.QuestionSysNo = SysNo;
                    m_comment.TS = DateTime.Now;
                    m_comment.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                    QA_CommentBll.GetInstance().AddComment(m_comment);
                    RefreshSession();
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addComment", "alert('发表看法成功！');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addComment", "alert('系统故障，请联系管理员');", true);
                }
                BindList();
            }
            else if (e.CommandName == "Del")
            {
                QA_AnswerMod m_answer = QA_AnswerBll.GetInstance().GetModel(int.Parse(e.CommandArgument.ToString()));
                m_answer.DR = (int)AppEnum.State.deleted;
                QA_AnswerBll.GetInstance().UpDate(m_answer);
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addhate", "alert('成功删除该回答！');", true);
                BindList();
            }
        }

        protected bool CheckCommentCookies(int sysno)
        {
            bool ret = false;
            string[] tmpstr;
            string newstr = "";
            if (Request.Cookies["upup1000"] != null && Request.Cookies["upup1000"]["QuestComment"] != null && Request.Cookies["upup1000"]["QuestComment"] != string.Empty)
            {
                tmpstr = CommonTools.Decode(Request.Cookies["upup1000"]["QuestComment"]).Split(new char[] { '|' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    if (sysno.ToString() == tmpstr[i].Split(new char[] { ',' })[0])
                    {
                        ret = true;
                    }
                    if (DateTime.Now - DateTime.Parse(tmpstr[i].Split(new char[] { ',' })[1]) < new TimeSpan(7, 0, 0, 0))
                    {
                        newstr += tmpstr[i] + "|";
                    }
                }
                newstr = newstr.Remove(newstr.LastIndexOf("|"));
                CookiesHelper.SetCookie("upup1000", "QuestComment", CommonTools.Encode(newstr), DateTime.Now.AddYears(50));
            }
            return ret;
        }

        protected void SetCommentCookies(int sysno)
        {
            string tmpstr = "";
            if (Request.Cookies["upup1000"] != null && Request.Cookies["upup1000"]["QuestComment"] != null && Request.Cookies["upup1000"]["QuestComment"] != string.Empty)
            {
                tmpstr = CommonTools.Decode(Request.Cookies["upup1000"]["QuestComment"]) + "|" + sysno + "," + DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                tmpstr = sysno.ToString() + "," + DateTime.Now.ToString("yyyy-MM-dd");
            }

            HttpCookie Cookie = CookiesHelper.GetCookie("upup1000");
            if (Cookie == null || Cookie.Value == null || Cookie.Value == "")
            {
                Cookie = new HttpCookie("upup1000");
                Cookie.Values.Add("QuestComment", CommonTools.Encode(tmpstr));
                //设置Cookie过期时间
                Cookie.Expires = DateTime.Now.AddYears(50);
                CookiesHelper.AddCookie(Cookie);
            }
            else
            {
                CookiesHelper.SetCookie("upup1000", "QuestComment", CommonTools.Encode(tmpstr), DateTime.Now.AddYears(50));
            }
        }

        protected void BindData()
        {
            try
            {
                if (m_qustion.DR != (int)AppEnum.State.normal)
                {
                    Response.Redirect("../Error.aspx");
                }
                m_qustion.ReadCount++;
                QA_QuestionBll.GetInstance().UpDate(m_qustion);
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
                Image1.ImageUrl = "../ControlLibrary/ShowPhoto.aspx?type=t&id=" + m_user.Photo;

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

                BindList();
                
            }
            catch
            {
                Response.Redirect("../Error.aspx");
            }
        }

        protected void BindList()
        {
            int total = 0;
            if (m_qustion.CustomerSysNo == AppConst.IntNull)
            {
                m_qustion = QA_QuestionBll.GetInstance().GetModel(SysNo);
            }
            DataTable m_dt = QA_AnswerBll.GetInstance().GetListByQuest(pagesize, pageindex, SysNo, ref total);
            Repeater1.DataSource = m_dt;
            Repeater1.DataBind();
            Pager1.url = "Question.aspx?id=" + SysNo + "&pn=";
            Pager1.totalrecord = total;
            if (total % AppConst.PageSize == 0)
            {
                this.Pager1.total = total / pagesize;
            }
            else
            {
                this.Pager1.total = total / pagesize + 1;
            }
            this.Pager1.index = pageindex;
            this.Pager1.numlenth = 3;
            if (IsPostBack)
            {
                UpdatePanel1.Update();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (GetSession().CustomerEntity.SysNo == m_qustion.CustomerSysNo)
            {
                e.Item.FindControl("LinkButton1").Visible = true;
                if (m_qustion.EndTime <= DateTime.Now || GetSession().CustomerEntity.SysNo.ToString() == ((DataRowView)e.Item.DataItem)["CustomerSysNo"].ToString())
                {
                    e.Item.FindControl("LinkButton1").Visible = false;
                }
                e.Item.FindControl("LinkButton5").Visible = true;
                e.Item.FindControl("Literal1").Visible = true;
            }
            else
            {
                e.Item.FindControl("LinkButton1").Visible = false;
                if(REL_Customer_CategoryBll.GetInstance().HasRecord(GetSession().CustomerEntity.SysNo,m_qustion.CateSysNo,(int)AppEnum.CategoryType.QA)
                    || GetSession().CustomerEntity.SysNo == m_qustion.CustomerSysNo)
                {
                    e.Item.FindControl("LinkButton5").Visible = true;
                    e.Item.FindControl("Literal1").Visible = true;
                }
            }

            Repeater m_rpt = (Repeater)e.Item.FindControl("Repeater3");
            DataTable m_dt = QA_CommentBll.GetInstance().GetListByAnswer(int.Parse(((DataRowView)e.Item.DataItem)["SysNo"].ToString()));
            if (m_dt != null)
            {
                m_dt.Columns.Add("color");
                for (int i = 0; i < m_dt.Rows.Count; i++)
                {
                    if (m_dt.Rows[i]["CustomerSysNo"].ToString() == m_qustion.CustomerSysNo.ToString())
                        m_dt.Rows[i]["color"] = "color: #A5534C";
                }
                m_rpt.DataSource = m_dt;
                m_rpt.DataBind();
            }
            Repeater m_rpt1 = (Repeater)e.Item.FindControl("Repeater4");
            DataTable m_dt1 = REL_Customer_MedalBll.GetInstance().GetMedalByCustomer(int.Parse(((DataRowView)e.Item.DataItem)["CustomerSysNo"].ToString()),0);
            if (m_dt1 != null)
            {
                m_rpt1.DataSource = m_dt1;
                m_rpt1.DataBind();
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int score = 0;
            try
            {
                score = int.Parse(txtScore.Text.Trim());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addAward", "alert('您输入的积分数不正确，请重新输入！');", true);
                ModalPopupExtender1.Show();
            }
            QA_QuestionMod m_quest = QA_QuestionBll.GetInstance().GetModel(SysNo);
            int usedAward = QA_AnswerBll.GetInstance().GetUsedAward(SysNo);
            if (score > m_quest.Award - usedAward)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addAward", "alert('您输入的积分数不可超过" + (m_quest.Award - usedAward) + "，请重新输入！');", true);
                ModalPopupExtender1.Show();
                return;
            }

            try
            {
                QA_AnswerMod m_answer = QA_AnswerBll.GetInstance().GetModel(int.Parse(HiddenField1.Value));
                if (m_answer.Award == AppConst.IntNull)
                {
                    m_answer.Award = score;
                }
                else
                {
                    m_answer.Award += score;
                }
                QA_AnswerBll.GetInstance().UpDate(m_answer);

                USR_CustomerBll.GetInstance().AddPoint(score, m_answer.CustomerSysNo);
                USR_CustomerBll.GetInstance().AddCount(m_answer.CustomerSysNo, 0, 0, 1, 0, 0, 0);
                if (score == m_quest.Award - usedAward)
                {
                    m_quest.EndTime = DateTime.Now;
                    QA_QuestionBll.GetInstance().UpDate(m_quest);
                }
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addAward", "alert('悬赏分配成功！');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addAward", "alert('系统故障，请联系管理员');", true);
            }
            BindList();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Login1.ShowLogin();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Passport/Register.aspx?url="+Request.Url.ToString());
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            m_qustion.DR = (int)AppEnum.State.deleted;
            QA_QuestionBll.GetInstance().UpDate(m_qustion);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "delqa", "alert('该问题已删除');window.location.href='"+AppConfig.HomeUrl()+"Quest/Index.aspx';", true);
        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (GetSession().CustomerEntity.SysNo.ToString() == ((DataRowView)e.Item.DataItem)["CustomerSysNo"].ToString() || REL_Customer_CategoryBll.GetInstance().HasRecord(GetSession().CustomerEntity.SysNo, m_qustion.CateSysNo, (int)AppEnum.CategoryType.QA))
            {
                e.Item.FindControl("LinkButton5").Visible = true;
                e.Item.FindControl("Literal1").Visible = true;
            }
        }

        protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            QA_CommentMod m_comment = QA_CommentBll.GetInstance().GetModel(int.Parse(e.CommandArgument.ToString()));
            m_comment.DR = (int)AppEnum.State.deleted;
            QA_CommentBll.GetInstance().UpDate(m_comment);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "addhate", "alert('成功删除该评论！');", true);
            BindList();
        }


    }
}
