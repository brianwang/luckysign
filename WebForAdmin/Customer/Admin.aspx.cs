using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using AppBll.WebSys;
using System.Data;
using AppMod.WebSys;

namespace WebForAdmin.Privilege
{
    public partial class Admin : PageBase
    {
        // Fields
        private int pageindex = 1;
        private int total;

        private string urlnow = "Admin.aspx";

        // Methods
        protected void BindContent()
        {
            DataTable m_dt = SYS_AdminBll.GetInstance().GetList(20, this.pageindex, this.txtName.Text.Trim(), this.drpStatus.SelectedValue,int.Parse(drpPrivilege.SelectedValue), ref this.total);
            m_dt.Columns.Add("deleteurl");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                m_dt.Rows[i]["deleteurl"] = this.urlnow + "&delete=";
            }
            this.rptFamous.DataSource = m_dt;
            this.rptFamous.DataBind();
            this.Pager1.url = "Admin.aspx?name=" + this.txtName.Text.Trim() +  "&privilege=" + drpPrivilege.SelectedValue + "&status=" + this.drpStatus.SelectedValue + "&pn=";
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
                SYS_AdminMod m_customer = SYS_AdminBll.GetInstance().GetModel(int.Parse(base.Request.QueryString["delete"]));
                m_customer.DR = 1;
                SYS_AdminBll.GetInstance().Update(m_customer);
                this.ltrNotice.Text = "该记录已删除！";
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
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)base.Master;
            m_master.PageName = "后台管理员管理";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Privilege1);
            if (!base.IsPostBack)
            {
                if ((base.Request.QueryString["delete"] != null) && (base.Request.QueryString["delete"] != ""))
                {
                    this.Delete();
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

                #region 绑定选项
                drpPrivilege.DataSource = SYS_PrivilegeBll.GetInstance().GetList();
                drpPrivilege.DataTextField = "name";
                drpPrivilege.DataValueField = "sysno";
                drpPrivilege.DataBind();
                drpPrivilege.Items.Insert(0, new ListItem("请选择", "0"));
                #endregion

                this.urlnow = this.urlnow + "?pn=" + this.pageindex;
                if ((base.Request.QueryString["name"] != null) && (base.Request.QueryString["name"] != ""))
                {
                    this.txtName.Text = base.Request.QueryString["name"];
                    this.urlnow = this.urlnow + "&name=" + base.Request.QueryString["name"];
                }
                if ((base.Request.QueryString["privilege"] != null) && (base.Request.QueryString["privilege"] != ""))
                {
                    this.drpPrivilege.SelectedIndex = this.drpPrivilege.Items.IndexOf(this.drpPrivilege.Items.FindByValue(base.Request.QueryString["privilege"]));
                    this.urlnow = this.urlnow + "&privilege=" + base.Request.QueryString["privilege"];
                }
                if ((base.Request.QueryString["status"] != null) && (base.Request.QueryString["status"] != ""))
                {
                    this.drpStatus.SelectedIndex = this.drpStatus.Items.IndexOf(this.drpStatus.Items.FindByValue(base.Request.QueryString["status"]));
                    this.urlnow = this.urlnow + "&status=" + base.Request.QueryString["status"];
                }

                

                this.BindContent();
            }
        }
        

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Admin.aspx?name=" + this.txtName.Text.Trim() + "&privilege=" + drpPrivilege.SelectedValue + "&status=" + this.drpStatus.SelectedValue);
        }

    }
}
