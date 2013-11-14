using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.CMS;
using AppMod.CMS;
using AppCmn;
using System.Data;

namespace WebForMain.Article
{
    public partial class Index : PageBase
    {
        private int pageindex = 1;
        private int pagesize = 12;
        public string title = "";
        private int cate = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(2);
            if (!IsPostBack)
            {
                if (Request.QueryString["key"] != null)
                {
                    txtName.Text = Server.HtmlEncode(Request.QueryString["key"]);
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
                if (Request.QueryString["cate"] != null)
                {
                    try
                    {
                        cate = int.Parse(Request.QueryString["cate"]);
                    }
                    catch
                    { }
                }
                if (cate == 0)
                {
                    title = "象牙塔-上上签命理网";
                }
                else
                {
                    title = CMS_CategoryBll.GetInstance().GetModel(cate).Name+ "-象牙塔-上上签命理网";
                }
                BindData();
                BindRecommend();
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                string url = "Index.aspx?key=" + txtName.Text;
                if (Request.QueryString["pn"] != null)
                {
                    url += "&pn=" + Request.QueryString["pn"];
                }
                if (Request.QueryString["cate"] != null)
                {
                    url += "&cate=" + Request.QueryString["cate"];
                }
                Response.Redirect(url);
            }
        }

        protected void BindData()
        {
            int total = 0;

            DataTable m_dt = CMS_ArticleBll.GetInstance().GetList(pagesize, pageindex, txtName.Text, cate,0, ref total);
            m_dt.Columns.Add("power");
            m_dt.Columns.Add("Keys");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                m_dt.Rows[i]["Description"] = CommonTools.CutStr(m_dt.Rows[i]["Description"].ToString(), 300);
                if (m_dt.Rows[i]["Cost"] != null && m_dt.Rows[i]["Cost"].ToString() != ""&& m_dt.Rows[i]["Cost"].ToString() !="0")
                {
                    m_dt.Rows[i]["power"] = "| 阅读需要支付积分：" + m_dt.Rows[i]["Cost"].ToString();
                }
                else
                {
                    m_dt.Rows[i]["power"] = "";
                }
                string[] tmpkeys = m_dt.Rows[i]["keywords"].ToString().Trim().Split(new char[] { ' ' });
                for (int j = 0; j < tmpkeys.Length; j++)
                {
                    m_dt.Rows[i]["Keys"] += @"<a href=""Index.aspx?key=" + tmpkeys[j] + @""" title=""" + tmpkeys[j] + @""">" + tmpkeys[j] + @"</a> ";
                }
            }
            rptQuestion.DataSource = m_dt;
            rptQuestion.DataBind();

            Pager1.url = "Index.aspx?key=" + txtName.Text.Trim() + "&cate=" + Request.QueryString["cate"] + "&pn=";
            Pager1.totalrecord = total;
            if (total % pagesize == 0)
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


        protected void BindRecommend()
        {
            DataSet m_ds = CMS_ArticleBll.GetInstance().GetRecommendList(5);
            for (int i = 0; i < m_ds.Tables[0].Rows.Count; i++)
            {
                m_ds.Tables[0].Rows[i]["Description"] = CommonTools.CutStr(m_ds.Tables[0].Rows[i]["Description"].ToString(), 100);
            }
            rptNew.DataSource = m_ds.Tables[0];
            rptNew.DataBind();
            for (int i = 0; i < m_ds.Tables[1].Rows.Count; i++)
            {
                m_ds.Tables[1].Rows[i]["Description"] = CommonTools.CutStr(m_ds.Tables[1].Rows[i]["Description"].ToString(), 100);
            }
            rptGood .DataSource = m_ds.Tables[1];
            rptGood.DataBind();
            for (int i = 0; i < m_ds.Tables[2].Rows.Count; i++)
            {
                m_ds.Tables[2].Rows[i]["Description"] = CommonTools.CutStr(m_ds.Tables[2].Rows[i]["Description"].ToString(), 100);
            }
            rptHot.DataSource = m_ds.Tables[2];
            rptHot.DataBind();
        }
    }
}