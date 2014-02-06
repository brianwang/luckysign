using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppCmn;
using AppMod.User;
using AppBll.User;
using AppMod.WebSys;
using AppBll.WebSys;
using AppMod.CMS;
using AppBll.CMS;
using AppMod.QA;
using AppBll.QA;

namespace WebForMain.Qin
{
    public partial class View : PageBase
    {
        public USR_CustomerMod m_user = new USR_CustomerMod();
        public USR_GradeMod m_grade = new USR_GradeMod();

        private int pageindex = 1;
        private int pagesize = 12;
        private int tab = 0;
        public string ltrMe = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    m_user = USR_CustomerBll.GetInstance().GetModel(int.Parse(Request.QueryString["id"]));
                    if (m_user.SysNo == AppConst.IntNull)
                    {
                        ShowError("");
                    }
                }
                catch
                {
                    ShowError("");
                }
            }
            else if (Page.RouteData.Values["id"] != null)
            {
                try
                {
                    m_user = USR_CustomerBll.GetInstance().GetModel(int.Parse(Page.RouteData.Values["id"].ToString()));
                    if (m_user.SysNo == AppConst.IntNull)
                    {
                        ShowError("");
                    }
                }
                catch
                {
                    ShowError("");
                }
            }
            else
            {
                Login(Request.Url.ToString());
                m_user = USR_CustomerBll.GetInstance().GetModel(GetSession().CustomerEntity.SysNo);
                m_grade = USR_GradeBll.GetInstance().GetModel(m_user.GradeSysNo);
            }
            try
            {
                if (!IsPostBack)
                {
                    
                    
                    if (m_user.HomeTown != AppConst.IntNull)
                    {
                        SYS_DistrictMod m_dictrict = SYS_DistrictBll.GetInstance().GetModel(SYS_DistrictBll.GetInstance().GetModel(m_user.HomeTown).UpSysNo);
                        ltrFrom.Text = m_dictrict.Name;
                    }
                    else
                    {
                        ltrFrom.Text = "未知";
                    }
                    if (m_user.birth != AppConst.DateTimeNull)
                    {
                        ltrBirth.Text = "生日：" + m_user.birth.ToString("yyyy年MM月dd日");
                    }
                    else
                    {
                        ltrBirth.Text = "生日：未知";
                    }
                    BindArticles();
                    BindBestAnswer();
                    BindIcons();

                    LinkButton1_Click(LinkButton1, e);
                }
                if (GetSession().CustomerEntity != null && GetSession().CustomerEntity.SysNo != AppConst.IntNull && m_user.SysNo == GetSession().CustomerEntity.SysNo)
                    {
                        ltrMe = "我";
                        sendmsg.Visible = false;
                        intro.HRef = AppConfig.HomeUrl() + "Qin/UserInfo.aspx?id=" + m_user.SysNo + "&tab=1";
                        ImageButton1.ImageUrl = AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=o&id=" + m_user.Photo;
                    }
                    else
                    {
                        ltrMe = "Ta";
                        intro.Visible = false;
                        sendmsg.HRef = AppConfig.HomeUrl() + "Qin/MsgDetail.aspx?UserSysNo=" + m_user.SysNo;
                        ImageButton1.ImageUrl = AppConfig.HomeUrl()+"ControlLibrary/ShowPhoto.aspx?type=o&id=" + m_user.Photo;
                        ImageButton1.Enabled = false;
                    }
                RightPannel1.m_user = m_user;
                RightPannel1.m_grade = m_grade;
            }
            catch
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
            if (Request.QueryString["tab"] != null)
            {
                try
                {
                    tab = int.Parse(Request.QueryString["tab"]);
                }
                catch
                { }
            }
        }

        protected void BindArticles()
        {
            int total = 0;
            DataTable m_dt = CMS_ArticleBll.GetInstance().GetList(pagesize, pageindex, "", 0, m_user.SysNo, ref total);
            m_dt.Columns.Add("KeyWordsShow");

            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                string[] tmpkeys = m_dt.Rows[i]["KeyWords"].ToString().Split(new char[] { ' ' });
                m_dt.Rows[i]["KeyWordsShow"] = "";
                foreach (string tmpkey in tmpkeys)
                {
                    m_dt.Rows[i]["KeyWordsShow"] += @"<a href="""+AppConfig.HomeUrl() + @"Article/" + tmpkey + @""">" + tmpkey + "</a>";
                }
            }
            rptArticle.DataSource = m_dt;
            rptArticle.DataBind();
        }

        /// <summary>
        /// 勋章
        /// </summary>
        protected void BindIcons()
        {

        }

        protected void BindBestAnswer()
        {
            int total = 0;
            DataTable m_dt = QA_AnswerBll.GetInstance().GetListByUser(pagesize, pageindex, m_user.SysNo, "", 0, false, "timedown", ref total);
            rptQuest.DataSource = m_dt;
            rptQuest.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(AppConfig.HomeUrl() + "Qin/UserInfo.aspx?id=" + m_user.SysNo + "&tab=0");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton m_link = (LinkButton)sender;
            if (m_link.ID == "LinkButton1")
            {
                LinkButton1.Style["color"] = "#a82f33";
                LinkButton2.Style["color"] = "#333";
                MultiView1.ActiveViewIndex = 1;
            }
            else if (m_link.ID == "LinkButton2")
            {
                LinkButton2.Style["color"] = "#a82f33";
                LinkButton1.Style["color"] = "#333";
                MultiView1.ActiveViewIndex = 0;
            }
        }
    }
}