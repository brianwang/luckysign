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

namespace WebForAdmin.Customer
{
    public partial class List : PageBase
    {
        // Fields
    private int pageindex = 1;
    private int total;

    private string urlnow = "List.aspx";

    // Methods
    protected void BindContent()
    {
        DateTime beginTime = AppConst.DateTimeNull;
        DateTime endTime = AppConst.DateTimeNull;
        try
        {
            if (this.txtTimeBegin.Text != "")
            {
                beginTime = DateTime.Parse(this.txtTimeBegin.Text.Trim());
            }
            if (this.txtTimeEnd.Text != "")
            {
                endTime = DateTime.Parse(this.txtTimeEnd.Text.Trim());
            }
        }
        catch
        {
        }
        DataTable m_dt = USR_CustomerBll.GetInstance().GetList(20, this.pageindex, this.txtName.Text.Trim(), beginTime, endTime, this.drpStatus.SelectedValue, ref this.total);
        m_dt.Columns.Add("deleteurl");
        m_dt.Columns.Add("topurl");
        m_dt.Columns.Add("topname");
        for (int i = 0; i < m_dt.Rows.Count; i++)
        {
            m_dt.Rows[i]["deleteurl"] = this.urlnow + "&delete=";
            int star = 1;
            if (m_dt.Rows[i]["IsStar"].ToString() == star.ToString())
            {
                m_dt.Rows[i]["topurl"] = this.urlnow + "&notop=";
                m_dt.Rows[i]["topname"] = "取消明星";
            }
            else
            {
                m_dt.Rows[i]["topurl"] = this.urlnow + "&top=";
                m_dt.Rows[i]["topname"] = "设置明星";
            }
        }
        this.rptFamous.DataSource = m_dt;
        this.rptFamous.DataBind();
        this.Pager1.url = "List.aspx?name=" + this.txtName.Text.Trim() + "&begin=" + this.txtTimeBegin.Text.Trim() + "&end=" + this.txtTimeEnd.Text.Trim() + "&status=" + this.drpStatus.SelectedValue + "&pn=";
        if ((this.total % 20) == 0)
        {
            this.Pager1.total = this.total / 20;
        }
        else
        {
            this.Pager1.total = (this.total / 20) + 1;
        }
        this.Pager1.index = this.pageindex;
        this.Pager1.numlenth = 3;
    }

    protected void Delete()
    {
        try
        {
            USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetModel(int.Parse(base.Request.QueryString["delete"]));
            m_customer.Status = 3;
            USR_CustomerBll.GetInstance().UpDate(m_customer);
            this.ltrNotice.Text = "该记录已冻结！";
            base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
        }
        catch
        {
            this.ltrError.Text = "系统错误，冻结失败！";
            base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Login(base.Request.RawUrl);
        base.CheckPrivilege(base.Request.RawUrl);
        AdminMaster m_master = (AdminMaster) base.Master;
        m_master.PageName = "会员管理";
        m_master.SetCate(AdminMaster.CateType.Customer1);
        if (!base.IsPostBack)
        {
            if ((base.Request.QueryString["delete"] != null) && (base.Request.QueryString["delete"] != ""))
            {
                this.Delete();
            }
            if ((base.Request.QueryString["top"] != null) && (base.Request.QueryString["top"] != ""))
            {
                this.SetTop(true);
            }
            if ((base.Request.QueryString["notop"] != null) && (base.Request.QueryString["top"] != ""))
            {
                this.SetTop(false);
            }
            if ((base.Request.QueryString["pn"] != null) && (base.Request.QueryString["pn"] != ""))
            {
                try
                {
                    this.pageindex = int.Parse(base.Request.QueryString["pn"]);
                }
                catch
                {
                }
            }
            this.urlnow = this.urlnow + "?pn=" + this.pageindex;
            if ((base.Request.QueryString["name"] != null) && (base.Request.QueryString["name"] != ""))
            {
                this.txtName.Text = base.Request.QueryString["name"];
                this.urlnow = this.urlnow + "&name=" + base.Request.QueryString["name"];
            }
            if ((base.Request.QueryString["status"] != null) && (base.Request.QueryString["status"] != ""))
            {
                this.drpStatus.SelectedIndex = this.drpStatus.Items.IndexOf(this.drpStatus.Items.FindByValue(base.Request.QueryString["status"]));
                this.urlnow = this.urlnow + "&status=" + base.Request.QueryString["status"];
            }
            if ((base.Request.QueryString["begin"] != null) && (base.Request.QueryString["begin"] != ""))
            {
                this.txtTimeBegin.Text = base.Request.QueryString["begin"];
                this.urlnow = this.urlnow + "&begin=" + base.Request.QueryString["begin"];
            }
            if ((base.Request.QueryString["end"] != null) && (base.Request.QueryString["end"] != ""))
            {
                this.txtTimeEnd.Text = base.Request.QueryString["end"];
                this.urlnow = this.urlnow + "&end=" + base.Request.QueryString["end"];
            }
            this.BindContent();
        }
    }

    protected void SetTop(bool input)
    {
        try
        {
            int sysno = 0;
            if (input)
            {
                sysno = int.Parse(base.Request.QueryString["top"]);
            }
            else
            {
                sysno = int.Parse(base.Request.QueryString["notop"]);
            }
            USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetModel(sysno);
            if (input)
            {
                m_customer.IsStar = 1;
            }
            else
            {
                m_customer.IsStar = 0;
            }
            USR_CustomerBll.GetInstance().UpDate(m_customer);
            if (input)
            {
                this.ltrNotice.Text = "已设置该用户为明星！";
                base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            else
            {
                this.ltrNotice.Text = "已取消该用户明星！";
                base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
        }
        catch
        {
            this.ltrError.Text = "系统错误，设置明星失败！";
            base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("List.aspx?pn=1&name=" + this.txtName.Text.Trim() + "&begin=" + this.txtTimeBegin.Text.Trim() + "&end=" + this.txtTimeEnd.Text.Trim() + "&status=" + this.drpStatus.SelectedValue);
    }

    }
}