using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.QA;
using AppMod.QA;
using AppBll.User;
using AppCmn;

namespace WebForMain.ControlLibrary
{
    public partial class QuestRightPanel : System.Web.UI.UserControl
    {
        private int cate = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["key"] != null)
            {
                txtName.Text = Server.HtmlEncode(Request.QueryString["key"]);
            }
            else if (Page.RouteData.Values["key"] != null && Page.RouteData.Values["key"].ToString() != "")
            {
                txtName.Text = Server.HtmlEncode(Page.RouteData.Values["key"].ToString());
            }
            if (Request.QueryString["cate"] != null)
            {
                try
                {
                    cate = int.Parse(Request.QueryString["cate"]);
                }
                catch
                {
                    return;
                }
            }
            else if (Page.RouteData.Values["cate"] != null && Page.RouteData.Values["cate"].ToString() != "")
            {
                try
                {
                    cate = int.Parse(Page.RouteData.Values["cate"].ToString());
                }
                catch
                {
                    return;
                }
            }
            else
            {
                return;
            }
            if (!IsPostBack)
            {
                QA_CategoryMod m_cate = QA_CategoryBll.GetInstance().GetModel(cate);
                if (m_cate.TopSysNo == 1)
                {
                    ltrMaster.Text = "驻场命理师";
                }
                else if (m_cate.TopSysNo == 2)
                {
                    ltrMaster.Text = "版主";
                }
                DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(0).Copy();
                for (int i = 0; i < m_dt.Rows.Count; i++)
                {
                    if (m_dt.Rows[i]["SysNo"].ToString() != m_cate.TopSysNo.ToString())
                    {
                        m_dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
                rptCateMain.DataSource = m_dt;
                rptCateMain.DataBind();
                BindStars();

                
            }
        }

        public bool showsearch 
        {
            set
            {
                if (!value)
                {
                    searchdiv.Style["display"] = "none";
                }
            }
        }

        protected void rptCateMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptCate = (Repeater)e.Item.FindControl("rptCateSub");

                //找到分类Repeater关联的数据项 
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //提取分类ID 
                int CategoryId = Convert.ToInt32(rowv["SysNo"]);
                //根据分类ID查询该分类下的子分类，并绑定子分类Repeater                 

                DataTable dt = QA_CategoryBll.GetInstance().GetCates(CategoryId);
                dt.Columns.Add("selected");
                dt.Columns.Add("Replys");
                dt.Columns.Add("QuestNum");
                dt.Columns.Add("SolvedNum");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["QuestNum"] = "0";
                    DataTable questnum = QA_CategoryBll.GetInstance().GetCatesPostNum().Tables[0];
                    for (int j = 0; j < questnum.Rows.Count; j++)
                    {
                        if (questnum.Rows[j]["CateSysNo"].ToString() == dt.Rows[i]["SysNo"].ToString())
                        {
                            dt.Rows[i]["QuestNum"] = int.Parse(dt.Rows[i]["QuestNum"].ToString()) + int.Parse(questnum.Rows[j]["questnum"].ToString());
                            if (questnum.Rows[j]["IsSolved"].ToString() == "1")
                            {
                                dt.Rows[i]["SolvedNum"] = dt.Rows[i]["QuestNum"].ToString();
                            }
                        }
                    }
                    DataTable postnum = QA_CategoryBll.GetInstance().GetCatesPostNum().Tables[1];
                    for (int j = 0; j < postnum.Rows.Count; j++)
                    {
                        if (postnum.Rows[j]["CateSysNo"].ToString() == dt.Rows[i]["SysNo"].ToString())
                        {
                            dt.Rows[i]["Replys"] = int.Parse(dt.Rows[i]["QuestNum"].ToString()) + int.Parse(postnum.Rows[j]["AnswerNum"].ToString()) + int.Parse(postnum.Rows[j]["CommentNum"].ToString());
                        }
                    }

                    dt.Rows[i]["selected"] = "s" + i;
                    if (cate != 0)
                    {
                        if (cate.ToString() == dt.Rows[i]["SysNo"].ToString())
                        {
                            dt.Rows[i]["selected"] = "s" + i + "' style='text-decoration:underline;";
                        }
                    }
                }
                rptCate.DataSource = dt;
                rptCate.DataBind();
            }
        }

        protected void BindStars()
        {
            //int count = 5;
            if (cate != 0)
            {
                try
                {
                    DataTable m_dt = REL_Customer_CategoryBll.GetInstance().GetListByCate(cate, (int)AppEnum.CategoryType.QA);
                    //DataTable m_dt = QA_StarBll.GetInstance().GetStarsList(count, 0);
                    for (int i = 0; i < m_dt.Rows.Count; i++)
                    {
                        m_dt.Rows[i]["intro"] = CommonTools.CutStr(m_dt.Rows[i]["intro"].ToString(), 80);
                    }
                    rptStars.DataSource = m_dt;
                    rptStars.DataBind();
                }
                catch
                { }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if(Request.Url.ToString().ToLower().Contains("talk"))
            {
                Response.Redirect(AppConfig.HomeUrl()+"Quest/TalkList/" +cate+ "/" + txtName.Text.Trim());
            }
            else
            {
                Response.Redirect(AppConfig.HomeUrl() + "Quest/QuestList/" + cate + "/" + txtName.Text.Trim());
            }
        }

    }
}