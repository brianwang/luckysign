using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebMonitor;
using AppBll.User;
using AppMod.User;
using AppCmn;

namespace WebForAdmin.Customer
{
    public partial class SetMedal : PageBase
    {
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl); CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "设置勋章";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Customer2);
            #endregion

            if (!IsPostBack)
            {
                PrepareForm();
            }
            if (Request.QueryString["delete"] != null && Request.QueryString["delete"] != "")
            {
                Delete();
            }
        }

        protected void PrepareForm()
        {
            drpMedal.DataSource = USR_MedalBll.GetInstance().GetList();
            drpMedal.DataTextField = "MedalName";
            drpMedal.DataValueField = "SysNo";
            drpMedal.DataBind();
            drpMedal.Items.Insert(0, new ListItem("选择要颁发的勋章", "0"));


                if (Request.QueryString["user"] != null && Request.QueryString["user"] != "")
                {
                    try
                    {
                        rptFamous.DataSource = REL_Customer_MedalBll.GetInstance().GetMedalByCustomer(int.Parse(Request.QueryString["user"]), 0);
                        rptFamous.DataBind();
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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (drpMedal.SelectedIndex == 0)
            {
                ltrError.Text = "请选择勋章！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            if (REL_Customer_MedalBll.GetInstance().HasMedal(int.Parse(Request.QueryString["user"]), int.Parse(drpMedal.SelectedValue)))
            {
                ltrError.Text = "该用户已经拥有该勋章！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            REL_Customer_MedalMod m_medal = new REL_Customer_MedalMod();
            m_medal.CustomerSysNo = int.Parse(Request.QueryString["user"]);
            m_medal.MedalSysNo = int.Parse(drpMedal.SelectedValue);
            m_medal.TS = DateTime.Now;
            m_medal.DR = 0;
            try
            {
                REL_Customer_MedalBll.GetInstance().Add(m_medal);
                LogManagement.getInstance().WriteTrace(m_medal.SysNo, "CustomerMedal.Add", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);

                ltrNotice.Text = "该记录已保存成功！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
                PrepareForm();
            }
            catch
            {
                ltrError.Text = "系统错误，添加失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            
        }

        public void Delete()
        {
            try
            {
                REL_Customer_MedalBll.GetInstance().Delete(int.Parse(Request.QueryString["delete"]));
                this.ltrNotice.Text = "该记录已删除！";
                base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
                PrepareForm();
            }
            catch
            {
                this.ltrError.Text = "系统错误，删除失败！";
                base.ClientScript.RegisterStartupScript(base.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
        }
    }
}
