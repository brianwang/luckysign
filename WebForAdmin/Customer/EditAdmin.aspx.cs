using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppMod.WebSys;
using AppBll.User;
using AppBll.WebSys;
using AppCmn;
using WebMonitor;

namespace WebForAdmin.Privilege
{
    public partial class EditAdmin : PageBase
    {
        public string type = "";
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl); CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "添加/修改后台用户";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Privilege2);
            #endregion

            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {
                type = Request.QueryString["type"].ToUpper().Trim();
            }
            if (!IsPostBack)
            {
                PrepareForm();
            }
        }

        protected void PrepareForm()
        {
            #region 选项绑定
            //drpGender.DataSource = AppEnum.GetGender();
            //drpGender.DataTextField = "Value";
            //drpGender.DataValueField = "Key";
            //drpGender.DataBind();
            //drpGender.SelectedIndex = 2;

            //drpLevel.DataSource = AppEnum.GetCustomerType();
            //drpLevel.DataTextField = "Value";
            //drpLevel.DataValueField = "Key";
            //drpLevel.DataBind();
            //drpLevel.SelectedIndex = 2;
            //drpLevel.Items.Insert(0, new ListItem("请选择会员等级", "0"));

            int tmptotal = 0;
            drpPrivilege.DataSource = SYS_AdminBll.GetInstance().GetList(1000, 1, "",  "", 0, ref tmptotal);
            drpPrivilege.DataTextField = "NickName";
            drpPrivilege.DataValueField = "SysNo";
            drpPrivilege.DataBind();
            drpPrivilege.Items.Insert(0, new ListItem("选择后台用户", "0"));

            #endregion

            if (type == "ADD")
            {
                if (Request.QueryString["user"] != null && Request.QueryString["user"] != "")
                {
                    try
                    {
                        if (SYS_AdminBll.GetInstance().IsAdmin(int.Parse(Request.QueryString["user"])))
                        {
                            Response.Redirect("../Error.aspx?msg=");
                            return;
                        }
                        txtName.Text = USR_CustomerBll.GetInstance().GetModel(int.Parse(Request.QueryString["user"])).NickName;
                    }
                    catch
                    {
                        Response.Redirect("../Error.aspx?msg=");
                        return;
                    }
                }
                else
                {
                    Response.Redirect("../Error.aspx?msg=");
                    return;
                }
            }
            else if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        SysNo = int.Parse(Request.QueryString["id"]);
                        SYS_AdminMod m_cms = SYS_AdminBll.GetInstance().GetModel(SysNo);

                        txtSysNo.Text = m_cms.SysNo.ToString();
                        txtName.Text = USR_CustomerBll.GetInstance().GetModel(m_cms.CustomerSysNo).NickName;
                        txtUserName.Text = m_cms.Username;
                        //txtPass.Enabled = false;
                        txtPass.Text = "加密存储";
                        //txtPass.ReadOnly = true;   
                    }
                    catch
                    {
                        Response.Redirect("../Error.aspx?msg=");
                        return;
                    }
                }
            }
        }


        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            SYS_AdminMod m_supplier = new SYS_AdminMod();
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                }
                m_supplier = SYS_AdminBll.GetInstance().GetModel(SysNo);
            }
            if (txtUserName.Text.Trim() == "")
            {
                ltrError.Text = "请填写用户登录名！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            if (txtPass.Text.Trim() == "" && type == "ADD")
            {
                ltrError.Text = "请输入初始密码！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            m_supplier.CustomerSysNo = int.Parse(Request.QueryString["user"]);
            m_supplier.Username = txtUserName.Text;
            
            try
            {
                if (type == "ADD")
                {
                    m_supplier.DR = 0;
                    m_supplier.Password = txtPass.Text;
                    m_supplier.TS = DateTime.Now;
                    m_supplier.LastLogin = DateTime.Now;
                    m_supplier.SysNo = SYS_AdminBll.GetInstance().Add(m_supplier);
                    
                    SetPrivilege(m_supplier.SysNo);
                    LogManagement.getInstance().WriteTrace(m_supplier.SysNo, "Article.Add", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                }
                else if (type == "EDIT")
                {
                    if (txtPass.Text.Trim() != "加密存储")
                    {
                        m_supplier.Password = txtPass.Text;
                    }
                    SYS_AdminBll.GetInstance().Update(m_supplier);
                    SetPrivilege(m_supplier.SysNo);
                    LogManagement.getInstance().WriteTrace(m_supplier.SysNo, "Article.Edit", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                }
                ltrNotice.Text = "该记录已保存成功！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            catch (Exception ex)
            {
                ltrError.Text = "系统错误，保存失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                LogManagement.getInstance().WriteException(ex, "Article.Save", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
            }
        }

        private void SetPrivilege(int adminsysno)
        {
            try
            {
                int user = int.Parse(drpPrivilege.SelectedValue);
                if (user == 0)
                {
                    return;
                }
                SYS_PrivilegeBll.GetInstance().CopyPrivilege(user, adminsysno);
            }
            catch
            {
                return;
            }
        }
    }
}
