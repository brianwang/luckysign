using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.Apps;
using AppMod.Apps;
using System.Data;
using WebMonitor;

namespace WebForAdmin.Apps
{
    public partial class PromotionTopic : PageBase
    {
        public string type = "TOP";
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "推广主题管理";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.App1);
            #endregion

            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {
                type = Request.QueryString["type"].ToUpper().Trim();
            }
            if (!IsPostBack)
            {
                #region Bind DropDown
                drpGroup.DataSource = AppCmn.AppEnum.GetAdvTopicType();
                drpGroup.DataTextField = "value";
                drpGroup.DataValueField = "key";
                drpGroup.DataBind();
                #endregion

                PrepareForm();
            }
        }

        protected void PrepareForm()
        {
            DataTable m_child = AdvTopicBll.GetInstance().GetTopicList();
            rptFamous.DataSource = m_child;
            rptFamous.DataBind();

            if (type == "ADD")
            {
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
                        AdvTopicMod m_topic = AdvTopicBll.GetInstance().GetModel(SysNo);
                        txtName.Text = m_topic.Title;
                        drpGroup.SelectedIndex = drpGroup.Items.IndexOf(drpGroup.Items.FindByValue(m_topic.Group.ToString()));
                        drpStatus.SelectedIndex = drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(m_topic.DR.ToString()));

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
                fieldset1.Style["display"] = "none";
                fieldset2.Style["display"] = "none";
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            AdvTopicMod m_topic = new AdvTopicMod();
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                }
                m_topic = AdvTopicBll.GetInstance().GetModel(SysNo);

                try
                {
                    m_topic.Title = txtName.Text.Trim();
                    m_topic.Group = int.Parse(drpGroup.SelectedValue);
                    m_topic.DR = int.Parse(drpStatus.SelectedValue);
                    AdvTopicBll.GetInstance().Update(m_topic);
                    LogManagement.getInstance().WriteTrace(m_topic.SysNo, "APP.AdvTopic.Update", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);

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
                    m_topic.Title = txtName.Text.Trim();
                    m_topic.Group = int.Parse(drpGroup.SelectedValue);
                    m_topic.DR = int.Parse(drpStatus.SelectedValue);
                    m_topic.TS = DateTime.Now;
                    AdvTopicBll.GetInstance().Add(m_topic);
                    LogManagement.getInstance().WriteTrace(m_topic.SysNo, "APP.AdvTopic.Add", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);

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

            Response.Redirect("Category.aspx?type=add");
        }
    }
}