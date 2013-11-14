using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.CMS;


namespace WebForMain.ControlLibrary
{
    public partial class ArticleRightPanel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable m_dt = CMS_CategoryBll.GetInstance().GetCates(0);
                Repeater1.DataSource = m_dt;
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptCate = (Repeater)e.Item.FindControl("Repeater2");

                //找到分类Repeater关联的数据项 
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //提取分类ID 
                int CategoryId = Convert.ToInt32(rowv["SysNo"]);
                //根据分类ID查询该分类下的子分类，并绑定子分类Repeater                 

                DataTable dt = CMS_CategoryBll.GetInstance().GetCates(CategoryId);
                dt.Columns.Add("currect");
                if (Request.QueryString["cate"] != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Request.QueryString["cate"] == dt.Rows[i]["SysNo"].ToString())
                        {
                            dt.Rows[i]["currect"] = @"currect";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "showsub", "sub" + CategoryId + ".style.display='';", true);
                        }
                    }
                }
                rptCate.DataSource = dt;
                rptCate.DataBind();
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptCate = (Repeater)e.Item.FindControl("Repeater3");

                //找到分类Repeater关联的数据项 
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //提取分类ID 
                int CategoryId = Convert.ToInt32(rowv["SysNo"]);
                //根据分类ID查询该分类下的子分类，并绑定子分类Repeater                 

                DataTable dt = CMS_CategoryBll.GetInstance().GetCates(CategoryId);
                dt.Columns.Add("currect");
                if (Request.QueryString["cate"] != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Request.QueryString["cate"] == dt.Rows[i]["SysNo"].ToString())
                        {
                            dt.Rows[i]["currect"] = @"color:red;";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "dropcate", "li" + CategoryId + ".className='currect';sub" + CategoryId + ".style.display='';", true);
                        }
                    }
                }
                rptCate.DataSource = dt;
                rptCate.DataBind();
            }
        }
    }
}