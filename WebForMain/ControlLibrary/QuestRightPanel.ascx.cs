using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.QA;


namespace WebForMain.ControlLibrary
{
    public partial class QuestRightPanel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(0);
                rptCateMain.DataSource = m_dt;
                rptCateMain.DataBind();
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
                    if (Request.QueryString["cate"] != null)
                    {
                        if (Request.QueryString["cate"] == dt.Rows[i]["SysNo"].ToString())
                        {
                            dt.Rows[i]["selected"] = "s" + i + "' style='text-decoration:underline;";
                        }
                    }
                }
                rptCate.DataSource = dt;
                rptCate.DataBind();
            }
        }
    }
}