using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using System.Data;
using AppBll.User;
using AppMod.User;
using WebForAdmin.Master;
using AppBll.QA;

namespace WebForAdmin.Customer
{
    public partial class MasterList : PageBase
    {
        // Fields
    private int pageindex = 1;
    private int total;

    private string urlnow = "MasterList.aspx";

    // Methods
    protected void BindContent()
    {
        
        
        DataTable m_dt = REL_Customer_CategoryBll.GetInstance().GetList(this.txtName.Text.Trim(), int.Parse(drpQACate.SelectedValue), (int)AppEnum.CategoryType.QA);
        m_dt.Columns.Add("deleteurl");
        for (int i = 0; i < m_dt.Rows.Count; i++)
        {
            if (urlnow.Contains("?"))
            {
                m_dt.Rows[i]["deleteurl"] = this.urlnow + "&delete=";
            }
            else
            {
                m_dt.Rows[i]["deleteurl"] = this.urlnow + "?delete=";
            }
        }
        this.rptFamous.DataSource = m_dt;
        this.rptFamous.DataBind();
    }

    protected void Delete()
    {
        try
        {
            REL_Customer_CategoryBll.GetInstance().Delete(int.Parse(base.Request.QueryString["delete"]));
            this.ltrNotice.Text = "该记录已删除！";
            base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
        }
        catch
        {
            this.ltrError.Text = "系统错误，删除失败！";
            base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Login(base.Request.RawUrl);
        base.CheckPrivilege(base.Request.RawUrl);
        AdminMaster m_master = (AdminMaster) base.Master;
        m_master.PageName = "版主管理";
        m_master.SetCate(AdminMaster.CateType.Customer3);

        drpQACate.DataSource = QA_CategoryBll.GetInstance().GetAllCates();
        drpQACate.DataTextField = "Name";
        drpQACate.DataValueField = "SysNo";
        drpQACate.DataBind();
        drpQACate.Items.Insert(0, new ListItem("选择问答分类", "0"));

        if (!base.IsPostBack)
        {
            if ((base.Request.QueryString["delete"] != null) && (base.Request.QueryString["delete"] != ""))
            {
                this.Delete();
            }
            if ((base.Request.QueryString["name"] != null) && (base.Request.QueryString["name"] != ""))
            {
                this.txtName.Text = base.Request.QueryString["name"];
                this.urlnow = this.urlnow + "&name=" + base.Request.QueryString["name"];
            }
            if ((base.Request.QueryString["cate"] != null) && (base.Request.QueryString["cate"] != ""))
            {
                this.drpQACate.SelectedIndex = this.drpQACate.Items.IndexOf(this.drpQACate.Items.FindByValue(base.Request.QueryString["cate"]));
                this.urlnow = this.urlnow + "&cate=" + base.Request.QueryString["cate"];
            }
            this.BindContent();
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("MasterList.aspx?name=" + this.txtName.Text.Trim() + "&cate=" + this.drpQACate.SelectedValue);
    }

    }
}