using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebMonitor;
using AppBll.QA;
using AppMod.QA;
using AppCmn;

namespace WebForAdmin.Quest
{
    public partial class Category : PageBase
    {
        public string type = "TOP";
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "问答分类管理";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.QA1);
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
            if (type == "ADD")
            {
                if (Request.QueryString["parent"] == null || Request.QueryString["parent"] == "")
                {
                    Response.Redirect("../Error.aspx?msg=");
                    return;
                }
                try
                {
                    ltrParent.Text = QA_CategoryBll.GetInstance().GetModel(int.Parse(Request.QueryString["parent"])).Name;
                }
                catch
                {
                    Response.Redirect("../Error.aspx?msg=");
                    return;
                }
                ViewState["parent"] = Request.QueryString["parent"];
                fieldset1.Style["display"] = "";
                fieldset2.Style["display"] = "";
            }
            else if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        SysNo = int.Parse(Request.QueryString["id"]);
                        QA_CategoryMod m_cate = QA_CategoryBll.GetInstance().GetModel(SysNo);
                        
                        txtName.Text = m_cate.Name;
                        drpStatus.SelectedIndex = drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(m_cate.DR.ToString()));

                        DataTable m_child = QA_CategoryBll.GetInstance().GetCates(SysNo);
                        rptFamous.DataSource = m_child;
                        rptFamous.DataBind();

                        if (m_cate.ParentSysNo != 0)
                        {
                            QA_CategoryMod m_parent = QA_CategoryBll.GetInstance().GetModel(m_cate.ParentSysNo);
                            ltrParent.Text = m_parent.Name + "—" + m_cate.Name;
                        }
                        else
                        {
                            ltrParent.Text = "此分类为一级分类";
                        }
                        fieldset1.Style["display"] = "";
                        fieldset2.Style["display"] = "";
                    }
                    catch
                    {
                        Response.Redirect("../Error.aspx?msg=");
                        return;
                    }
                }
            }
            else if (type == "TOP")
            {
                DataTable m_child = QA_CategoryBll.GetInstance().GetCates(0);
                rptFamous.DataSource = m_child;
                rptFamous.DataBind();
                fieldset1.Style["display"] = "none";
                fieldset2.Style["display"] = "none";
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            QA_CategoryMod m_cate = new QA_CategoryMod();
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                }
                m_cate = QA_CategoryBll.GetInstance().GetModel(SysNo);

                try
                {
                    m_cate.Name = txtName.Text.Trim();
                    m_cate.DR = int.Parse(drpStatus.SelectedValue);
                    QA_CategoryBll.GetInstance().UpDate(m_cate);
                    LogManagement.getInstance().WriteTrace(m_cate.SysNo, "CMS.Category.Update", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);

                    ltrNotice.Text = "该记录已保存成功！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
                }
                catch
                {
                    ltrError.Text = "输入资料格式有误，请检查！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    return;
                }
            }
            else if (type == "ADD")
            {
                try
                {
                    m_cate.Name = txtName.Text.Trim();
                    m_cate.DR = int.Parse(drpStatus.SelectedValue);
                    m_cate.TS = DateTime.Now;
                    m_cate.ParentSysNo = Convert.ToInt32(ViewState["parent"]);
                    m_cate.TopSysNo = QA_CategoryBll.GetInstance().GetModel(Convert.ToInt32(ViewState["parent"])).TopSysNo;
                    QA_CategoryBll.GetInstance().Add(m_cate);
                    LogManagement.getInstance().WriteTrace(m_cate.SysNo, "CMS.Category.Add", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);

                    ltrNotice.Text = "该记录已保存成功！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
                }
                catch
                {
                    ltrError.Text = "输入资料格式有误，请检查！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    return;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int parent = 0;
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    parent = int.Parse(Request.QueryString["id"]);
                }
            }
            Response.Redirect("Category.aspx?type=add&parent=" + parent);
        }
    }
}
