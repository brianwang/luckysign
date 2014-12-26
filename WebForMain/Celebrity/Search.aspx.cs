using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.WebSys;
using AppCmn;

namespace WebForMain.Celebrity
{
    public partial class Search : PageBase
    {
        // Fields
    private int key = 0;

    // Methods
    protected void BindKeys()
    {
        int count = 10;
        int topcss = 0x12;
        DataTable m_dt = SYS_Famous_KeyWordsBll.GetInstance().GetList(count, 1, "", "", true, ref count);
        m_dt.Columns.Add("css");
        for (int i = 0; i < m_dt.Rows.Count; i++)
        {
            m_dt.Rows[i]["css"] = CommonTools.ThrowRandom(1, topcss);
        }
        this.rptKeys.DataSource = m_dt;
        this.rptKeys.DataBind();
    }

    protected void BindSearchList()
    {
        int state;
        int total = 0;
        int count = 10;
        DataTable m_dt = new DataTable();
        if (this.key != 0)
        {
            state = 0;
            m_dt = SYS_FamousBll.GetInstance().GetListByKeys(count, 1, this.key,state.ToString(), ref total);
        }
        else
        {
            state = 0;
            m_dt = SYS_FamousBll.GetInstance().GetList(count, 1, SQLData.SQLFilter(this.txtKeyword.Text.Trim()), AppConst.DateTimeNull, AppConst.DateTimeNull, state.ToString(), false, ref total);
        }
        for (int i = 0; i < m_dt.Rows.Count; i++)
        {
            if (m_dt.Rows[i]["photo"].ToString() == "")
            {
                m_dt.Rows[i]["photo"] = "";
            }
            else if (!m_dt.Rows[i]["photo"].ToString().Contains("//"))
            {
                m_dt.Rows[i]["photo"] = AppCmn.AppConfig.WebResourcesPath() + "FamousPhoto/" + m_dt.Rows[i]["photo"];
            }
            m_dt.Rows[i]["Description"] = CommonTools.CutStr(CommonTools.NoHTML(m_dt.Rows[i]["Description"].ToString()), 150);
        }
        this.rptResult.DataSource = m_dt;
        this.rptResult.DataBind();
        this.Literal1.Text = total.ToString();
        if (total < 10)
        {
            this.Literal2.Text = total.ToString();
        }
    }

    protected void BindTops()
    {
        int count = 5;
        this.rptTop.DataSource = SYS_FamousBll.GetInstance().GetTodayTopList(count);
        this.rptTop.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtKeyword.Text.Trim() != "")
        {
            base.Response.Redirect(AppCmn.AppConfig.HomeUrl()+"Celebrity/" + this.txtKeyword.Text.Trim());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            if ((base.Request.QueryString["key"] != null) || (base.Request.QueryString["keyword"] != null)||
                Page.RouteData.Values["key"] != null || Page.RouteData.Values["keyword"] != null)
            {
                if (base.Request.QueryString["key"] != null && base.Request.QueryString["key"] != "")
                {
                    try
                    {
                        this.key = int.Parse(base.Request.QueryString["key"]);
                    }
                    catch
                    {
                        ShowError("");
                    }
                }
                else if (Page.RouteData.Values["key"] != null&&Page.RouteData.Values["key"].ToString() != "")
                {
                    try
                    {
                        this.key = int.Parse(Page.RouteData.Values["key"].ToString());
                    }
                    catch
                    {
                        ShowError("");
                    }
                }
                else if (base.Request.QueryString["keyword"] != null && base.Request.QueryString["keyword"]!="")
                {
                    this.txtKeyword.Text = base.Server.HtmlEncode(base.Request.QueryString["keyword"]);
                }
                else if (Page.RouteData.Values["keyword"] != null&&Page.RouteData.Values["keyword"].ToString() != "")
                {
                    this.txtKeyword.Text = base.Server.HtmlEncode(Page.RouteData.Values["keyword"].ToString());
                }
                else
                {
                    ShowError("");
                }
                this.BindSearchList();
                this.MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                this.BindKeys();
                this.BindTops();
                this.MultiView1.ActiveViewIndex = 0;
            }
        }
    }

    }
}