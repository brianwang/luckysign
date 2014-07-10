using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.QA;
using AppMod.QA;
using AppBll.User;
using AppCmn;
using System.Data;

namespace WebForMain.Quest
{
    public partial class ConsultList : PageBase
    {
        private int pageindex = 1;
        private int pagesize = AppConst.PageSize;
        private string search = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(1);
            if (!IsPostBack)
            {
                if (Request.QueryString["key"] != null)
                {
                    search = Server.HtmlEncode(Request.QueryString["key"]);
                }
                else if (Page.RouteData.Values["key"] != null && Page.RouteData.Values["key"].ToString() != "")
                {
                    search = Server.HtmlEncode(Page.RouteData.Values["key"].ToString());
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
                    { }
                }

                ViewState["order"] = "timedown";
                lkbOrder1.CssClass = "current";
                lkbOrder2.CssClass = "";
                lkbOrder3.CssClass = "";

                BindData();
            }
        }

        //protected void Unnamed3_Click(object sender, EventArgs e)
        //{
        //    if (txtName.Text.Trim() != "")
        //    {
        //        string url = "Index.aspx?key="+txtName.Text;
        //        if (Request.QueryString["pn"] != null)
        //        {
        //            url += "&pn=" + Request.QueryString["pn"];
        //        }
        //        if (Request.QueryString["cate"] != null)
        //        {
        //            url += "&cate=" + Request.QueryString["cate"];
        //        }
        //        if (Request.QueryString["order"] != null)
        //        {
        //            url += "&order=" + Request.QueryString["order"];
        //        }
        //        Response.Redirect(url);
        //    }
        //}

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            string order = "";
            if (lkbOrder1.Text.Contains("up"))
            {
                order = "timeup";
                if (lkbOrder1.CssClass == "current")
                {
                    order = "timedown";
                    lkbOrder1.Text = lkbOrder1.Text.Replace("up", "down");
                }
            }
            else
            {
                order = "timedown";
                if (lkbOrder1.CssClass == "current")
                {
                    order = "timeup";
                    lkbOrder1.Text = lkbOrder1.Text.Replace("down", "up");
                }
            }
            lkbOrder1.CssClass = "current";
            lkbOrder2.CssClass = "";
            lkbOrder3.CssClass = "";

            ViewState["order"] = order;
            BindData();
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            string order = "";
            if (lkbOrder2.Text.Contains("up"))
            {
                order = "replyup";
                if (lkbOrder2.CssClass == "current")
                {
                    order = "replydown";
                    lkbOrder2.Text = lkbOrder2.Text.Replace("up", "down");
                }
            }
            else
            {
                order = "replydown";
                if (lkbOrder2.CssClass == "current")
                {
                    order = "replyup";
                    lkbOrder2.Text = lkbOrder2.Text.Replace("down", "up");
                }
            }
            lkbOrder1.CssClass = "";
            lkbOrder2.CssClass = "current";
            lkbOrder3.CssClass = "";

            ViewState["order"] = order;
            BindData();
        }

        protected void Unnamed7_Click(object sender, EventArgs e)
        {
            string order = "";
            if (lkbOrder3.Text.Contains("up"))
            {
                order = "pointup";
                if (lkbOrder3.CssClass == "current")
                {
                    order = "pointdown";
                    lkbOrder3.Text = lkbOrder3.Text.Replace("up", "down");
                }
            }
            else
            {
                order = "pointdown";
                if (lkbOrder3.CssClass == "current")
                {
                    order = "pointup";
                    lkbOrder3.Text = lkbOrder3.Text.Replace("down", "up");
                }
            }
            lkbOrder1.CssClass = "";
            lkbOrder2.CssClass = "";
            lkbOrder3.CssClass = "current";

            ViewState["order"] = order;
            BindData();
        }

        protected void BindData()
        {
            int total = 0;
            int cate = 0;
            if (Request.QueryString["cate"] != null)
            {
                try
                {
                    cate = int.Parse(Request.QueryString["cate"]);
                }
                catch
                {
                    ShowError("请从正常入口进入");
                }
            }
            else if (Page.RouteData.Values["cate"] != null && Page.RouteData.Values["cate"].ToString()!="")
            {
                try
                {
                    cate = int.Parse(Page.RouteData.Values["cate"].ToString());
                }
                catch
                {
                    ShowError("请从正常入口进入");
                }
            }
            else
            {
                ShowError("请从正常入口进入");
            }
            QA_CategoryMod m_cate = QA_CategoryBll.GetInstance().GetModel(cate);
            ltrNav.Text = @"<a href=""" + AppConfig.HomeUrl() + @""">首页</a> > <a href=""" + AppConfig.HomeUrl() + @"Quest/"">煮酒论命</a> > <span>" + QA_CategoryBll.GetInstance().GetModel(m_cate.TopSysNo).Name + "</span> > <span>" + m_cate.Name + "</span>";
            string search = "";
            //if (txtName.Trim() != "寻找你感兴趣的咨询话题")
            //{
            //    search = txtName.Trim();
            //}
            DataTable m_dt = QA_QuestionBll.GetInstance().GetList(pagesize, pageindex, search, cate, ViewState["order"].ToString(), ref total);
            m_dt.Columns.Add("DateShow");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                //m_dt.Rows[i]["Context"] = CommonTools.CutStr(m_dt.Rows[i]["Context"].ToString(), 100);
                DateTime ts = DateTime.Parse(m_dt.Rows[i]["ts"].ToString());
                if ((DateTime.Now - ts).TotalDays > 365)
                {
                    m_dt.Rows[i]["DateShow"] = "一年前发布";
                }
                else if ((DateTime.Now - ts).TotalDays > 180)
                {
                    m_dt.Rows[i]["DateShow"] = "半年前发布";
                }
                else if ((DateTime.Now - ts).TotalDays > 60)
                {
                    m_dt.Rows[i]["DateShow"] = "几个月前发布";
                }
                else if ((DateTime.Now - ts).TotalDays > 30)
                {
                    m_dt.Rows[i]["DateShow"] = "一个月前发布";
                }
                else if ((DateTime.Now - ts).TotalDays > 15)
                {
                    m_dt.Rows[i]["DateShow"] = "半个月前发布";
                }
                else if ((DateTime.Now - ts).TotalDays > 7)
                {
                    m_dt.Rows[i]["DateShow"] = "一周前发布";
                }
                else if ((DateTime.Now - ts).TotalDays > 2)
                {
                    m_dt.Rows[i]["DateShow"] = "几天前发布";
                }
                else if ((DateTime.Now - ts).TotalDays > 1)
                {
                    m_dt.Rows[i]["DateShow"] = "一天前发布";
                }
                else if ((DateTime.Now - ts).TotalHours > 2)
                {
                    m_dt.Rows[i]["DateShow"] = "几小时前发布";
                }
                else if ((DateTime.Now - ts).TotalHours > 1)
                {
                    m_dt.Rows[i]["DateShow"] = "一小时前发布";
                }
                else if ((DateTime.Now - ts).TotalMinutes > 30)
                {
                    m_dt.Rows[i]["DateShow"] = "半小时前发布";
                }
                else if ((DateTime.Now - ts).TotalMinutes > 2)
                {
                    m_dt.Rows[i]["DateShow"] = "几分钟前发布";
                }
                else if ((DateTime.Now - ts).TotalMinutes > 1)
                {
                    m_dt.Rows[i]["DateShow"] = "一分钟前发布";
                }
                else
                {
                    m_dt.Rows[i]["DateShow"] = "几秒钟前发布";
                }
            }
            rptQuestion.DataSource = m_dt;
            rptQuestion.DataBind();

            Pager1.url = AppConfig.HomeUrl() + @"Quest/QuestList/" + cate + "/";
            if (search.Trim() != "")
            {
                Pager1.url += search.Trim() + "/";
            }
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
        }



       

        protected void rptQuestion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //找到分类Repeater关联的数据项 
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取分类ID 
            int sysno = Convert.ToInt32(rowv["SysNo"]);
            int total = 0;
            DataTable m_dt = QA_AnswerBll.GetInstance().GetListByQuest(1000, 1, sysno, ref total);
            int choosen = AppConst.IntNull; ;
            int goodnow = 0;
            int awardnow = 0;
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                if (choosen == AppConst.IntNull && m_dt.Rows[i]["CustomerSysNo"].ToString() != rowv["CustomerSysNo"].ToString())
                {
                    choosen = i;
                    goodnow = int.Parse(m_dt.Rows[i]["Love"].ToString());
                    awardnow = int.Parse(m_dt.Rows[i]["Award"].ToString());
                    continue;
                }
                if (awardnow < int.Parse(m_dt.Rows[i]["Award"].ToString()))
                {
                    choosen = i;
                    goodnow = int.Parse(m_dt.Rows[i]["Love"].ToString());
                    awardnow = int.Parse(m_dt.Rows[i]["Award"].ToString());
                    continue;
                }
                if (awardnow == 0 && goodnow < int.Parse(m_dt.Rows[i]["Love"].ToString()))
                {
                    choosen = i;
                    goodnow = int.Parse(m_dt.Rows[i]["Love"].ToString());
                    awardnow = int.Parse(m_dt.Rows[i]["Award"].ToString());
                    continue;
                }
            }
            if (choosen == AppConst.IntNull)
            {
                Image Image1 = (Image)e.Item.FindControl("Image1");
                Panel Panel1 = (Panel)e.Item.FindControl("Panel1");
                Panel1.CssClass = "no_reply";
                Image1.Visible = false;
                Literal Literal1 = (Literal)e.Item.FindControl("Literal1");
                Literal1.Text = @"<a target=""_blank"" href="""+AppConfig.HomeUrl()+"Quest/Question/"+sysno+@""">还没人回复，快来抢个大沙发吧！</a>";
            }
            else
            {
                Image Image1 = (Image)e.Item.FindControl("Image1");
                Image1.ImageUrl = AppConfig.HomeUrl()+ "ControlLibrary/ShowPhoto.aspx?type=t&id=" + m_dt.Rows[choosen]["photo"].ToString();
                Literal Literal1 = (Literal)e.Item.FindControl("Literal1");
                Literal1.Text = @"<span>" + m_dt.Rows[choosen]["NickName"].ToString() + @"回复：</span>" + AppCmn.CommonTools.CutStr(CommonTools.NoHTML(m_dt.Rows[choosen]["Context"].ToString()),85);
            }
        }


    }
}