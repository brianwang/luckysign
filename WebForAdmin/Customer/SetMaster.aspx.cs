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
using AppBll.QA;

namespace WebForAdmin.Customer
{
    public partial class SetMaster : PageBase
    {
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl); CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "设置版块";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Customer4);
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
            if (Request.QueryString["user"] != null && Request.QueryString["user"] != "")
            {
                try
                {
                    rptFamous.DataSource = REL_Customer_CategoryBll.GetInstance().GetListByCustomer(int.Parse(Request.QueryString["user"]), (int)AppEnum.CategoryType.QA);
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

            drpQACate.DataSource = QA_CategoryBll.GetInstance().GetAllCates();
            drpQACate.DataTextField = "Name";
            drpQACate.DataValueField = "SysNo";
            drpQACate.DataBind();
            drpQACate.Items.Insert(0, new ListItem("选择问答分类", "0"));
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (drpQACate.SelectedIndex == 0)
            {
                ltrError.Text = "请选择问答分类！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            if (REL_Customer_CategoryBll.GetInstance().HasRecord(int.Parse(Request.QueryString["user"]), int.Parse(drpQACate.SelectedValue),(int)AppEnum.CategoryType.QA))
            {
                ltrError.Text = "该用户已经是该分类的版主了！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            REL_Customer_CategoryMod m_medal = new REL_Customer_CategoryMod();
            m_medal.CustomerSysNo = int.Parse(Request.QueryString["user"]);
            m_medal.CategorySysNo = int.Parse(drpQACate.SelectedValue);
            m_medal.Type = (int)AppEnum.CategoryType.QA;
            m_medal.TS = DateTime.Now;
            m_medal.DR = 0;
            try
            {
                REL_Customer_CategoryBll.GetInstance().Add(m_medal);
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
                REL_Customer_CategoryBll.GetInstance().Delete(int.Parse(Request.QueryString["delete"]));
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
