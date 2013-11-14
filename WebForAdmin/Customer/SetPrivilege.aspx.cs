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
    public partial class SetPrivilege : PageBase
    {
        // Fields
        private int SysNo;

        // Methods
        protected void BindContent()
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                try
                {
                    SysNo = int.Parse(Request.QueryString["id"]);

                    DataTable m_pri = REL_Admin_PrivilegeBll.GetInstance().GetListByAdmin(SysNo);
                    Dictionary<int,int> tmp = new Dictionary<int ,int>();
                    for (int i = 0; i < m_pri.Rows.Count; i++)
                    {
                        tmp.Add(int.Parse(m_pri.Rows[i]["Privilege_SysNo"].ToString()),int.Parse(m_pri.Rows[i]["SysNo"].ToString()));
                    }
                    ViewState["privilege"] = tmp;
                }
                catch
                {
                    Response.Redirect("../Error.aspx?msg=");
                    return;
                }
            }
            DataTable m_dt = SYS_PrivilegeBll.GetInstance().GetList();

            this.rptFamous.DataSource = m_dt;
            this.rptFamous.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            base.Login(base.Request.RawUrl);
            base.CheckPrivilege(base.Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)base.Master;
            m_master.PageName = "权限设置";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Privilege3);
            if (!base.IsPostBack)
            {                
                this.BindContent();
                SYS_AdminMod m_admin = SYS_AdminBll.GetInstance().GetModel(SysNo);
                Literal1.Text = m_admin.Username + "的权限";
            }
        }


        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptFamous.Items.Count; i++)
            {
                CheckBox rptCate = (CheckBox)rptFamous.Items[i].FindControl("CheckBox1");
                Dictionary<int, int> tmpp = (Dictionary<int, int>)ViewState["privilege"];
                int tmp = Convert.ToInt32(((HiddenField)rptFamous.Items[i].FindControl("HiddenField1")).Value);
                if (rptCate.Checked && !tmpp.ContainsKey(tmp))
                {
                    REL_Admin_PrivilegeMod m_rel = new REL_Admin_PrivilegeMod();
                    m_rel.Admin_SysNo = int.Parse(Request.QueryString["id"]);
                    m_rel.Privilege_SysNo = tmp;
                    REL_Admin_PrivilegeBll.GetInstance().Add(m_rel);
                }
                else if (!rptCate.Checked && tmpp.ContainsKey(tmp))
                {
                    REL_Admin_PrivilegeBll.GetInstance().Delete(tmpp[tmp]);
                }
            }
            this.BindContent();
            ltrNotice.Text = "权限设置成功！";
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
        }

        protected void rptFamous_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CheckBox rptCate = (CheckBox)e.Item.FindControl("CheckBox1");

            //找到分类Repeater关联的数据项 
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取分类ID 
            int CategoryId = Convert.ToInt32(rowv["SysNo"]);
            Dictionary<int, int> tmp = (Dictionary<int, int>)ViewState["privilege"];
            if (tmp.ContainsKey(CategoryId))
            {
                rptCate.Checked = true;
            }
        }

    }
}
