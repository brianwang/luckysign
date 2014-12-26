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
        private int pagesize = AppConst.PageSize;
        public string title = "";
        private int cate = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(2);
            if (Request.QueryString["key"] != null)
            {
                txtName.Text = Server.HtmlEncode(Request.QueryString["key"]);
            }
            else if (Page.RouteData.Values["key"] != null && Page.RouteData.Values["key"].ToString() != "")
            {
                txtName.Text = Server.HtmlEncode(Page.RouteData.Values["key"].ToString());
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
            if (Request.QueryString["cate"] != null)
            {
                try
                {
                    cate = int.Parse(Request.QueryString["cate"]);
                }
                catch
                { }
            }
            else if (Page.RouteData.Values["cate"] != null && Page.RouteData.Values["cate"].ToString() != "")
            {
                try
                {
                    cate = int.Parse(Page.RouteData.Values["cate"].ToString());
                }
                catch
                { }
            }
            if (!IsPostBack)
            {
                if (cate == 0)
                {
                    title = "象牙塔-上上签命理网";
                }
                else
                {
                    title = CMS_CategoryBll.GetInstance().GetModel(cate).Name + "-象牙塔-上上签命理网";
                }
                BindData();
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                string url = AppConfig.HomeUrl() + "Article";
                if (cate !=0)
                {
                    url += "/" + cate;
                }
                url += "/"+txtName.Text;
                
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
                    m_dt.Rows[i]["Keys"] += @"<a href="""+AppConfig.HomeUrl()+@"Article/" + tmpkeys[j] + @""" title=""" + tmpkeys[j] + @""">" + tmpkeys[j] + @"</a> ";
                }
            }
            rptQuestion.DataSource = m_dt;
            rptQuestion.DataBind();

            Pager1.url = AppConfig.HomeUrl() + "Article/" + cate + "/" + txtName.Text.Trim() + "/";
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


        
    }
}