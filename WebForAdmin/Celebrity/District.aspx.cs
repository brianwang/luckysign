using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebMonitor;
using AppBll.WebSys;
using AppMod.WebSys;
using AppCmn;

namespace WebForAdmin.Celebrity
{
    public partial class District : PageBase
    {
        public string type = "top";
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "地区管理";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Famous5);
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
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        SysNo = int.Parse(Request.QueryString["id"]);
                        SYS_DistrictMod m_area = SYS_DistrictBll.GetInstance().GetModel(SysNo);
                        ltrParent.Text = "";
                        txtName.Text = m_area.Name;
                        txtEnglishName.Text = m_area.EnglishName;
                        drpStatus.SelectedIndex = drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(m_area.DR.ToString()));

                        DataTable m_child = SYS_DistrictBll.GetInstance().GetSubLevel(SysNo);
                        rptFamous.DataSource = m_child;
                        rptFamous.DataBind();

                        if (m_area.Level == 3)
                        {
                            DataTable m_parent = SYS_DistrictBll.GetInstance().GetTreeDetail(SysNo);
                            if(m_parent.Rows.Count>0)
                            {
                                ltrParent.Text = m_parent.Rows[0]["Name1"].ToString() + "—" + m_parent.Rows[0]["Name2"].ToString() + "—" + m_parent.Rows[0]["Name3"].ToString();
                            }
                        }
                        else if (m_area.Level == 2)
                        {
                            DataTable m_parent = SYS_DistrictBll.GetInstance().GetTreeDetail(SysNo);
                            if (m_parent.Rows.Count > 0)
                            {
                                ltrParent.Text = m_parent.Rows[0]["Name1"].ToString() + "—" + m_parent.Rows[0]["Name2"].ToString();
                            }
                        }
                        else if (m_area.Level==1)
                        {
                            ltrParent.Text = "此地区为一级地区";
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
                DataTable m_child = SYS_DistrictBll.GetInstance().GetFirstLevel(0);
                rptFamous.DataSource = m_child;
                rptFamous.DataBind();
                fieldset1.Style["display"] = "none";
                fieldset2.Style["display"] = "none";
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            SYS_DistrictMod m_area = new SYS_DistrictMod();
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                }
                m_area = SYS_DistrictBll.GetInstance().GetModel(SysNo);
            }
            try
            {
                m_area.Name = txtName.Text.Trim();
                m_area.EnglishName = txtEnglishName.Text.Trim();
                m_area.DR = int.Parse(drpStatus.SelectedValue);
                SYS_DistrictBll.GetInstance().UpDate(m_area);
                LogManagement.getInstance().WriteTrace(m_area.SysNo, "District.Update", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);

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
}
