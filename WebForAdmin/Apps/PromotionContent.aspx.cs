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
using AppCmn;

namespace WebForAdmin.Apps
{
    public partial class PromotionContent : PageBase
    {
        private string urlnow = "PromotionContent.aspx?a=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "推广内容管理";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.App2);
            #endregion
            if (!IsPostBack)
            {
                if (Request.QueryString["delete"] != null && Request.QueryString["delete"] != "")
                {
                    Delete();
                }

                BindCate();
                if (Request.QueryString["topic"] != null && Request.QueryString["topic"] != "")
                {
                    drpTopic.SelectedIndex = drpTopic.Items.IndexOf(drpTopic.Items.FindByValue(Request.QueryString["topic"]));
                    urlnow += "&topic=" + drpTopic.SelectedIndex;
                }

                BindContent();
            }
        }

        protected void BindContent()
        {
            DataTable m_dt = AdvTopicContentBll.GetInstance().GetListByTopic(int.Parse(drpTopic.SelectedValue));
            m_dt.Columns.Add("deleteurl"); 
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                m_dt.Rows[i]["deleteurl"] = urlnow + "&delete=";
            }
            rptFamous.DataSource = m_dt;
            rptFamous.DataBind();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PromotionContent.aspx?topic=" + drpTopic.SelectedValue);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Delete()
        {
            try
            {
                AdvTopicContentMod m_content = AdvTopicContentBll.GetInstance().GetModel(int.Parse(Request.QueryString["delete"]));
                m_content.DR = (int)AppEnum.State.deleted;
                AdvTopicContentBll.GetInstance().UpDate(m_content);

                ltrNotice.Text = "该记录已删除！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            catch
            {
                ltrError.Text = "系统错误，删除失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
        }

        protected void BindCate()
        {
            DataTable m_dt = AdvTopicBll.GetInstance().GetTopicList();
            
            drpTopic.DataSource = m_dt;
            drpTopic.DataValueField = "SysNo";
            drpTopic.DataTextField = "Title";
            drpTopic.DataBind();
            drpTopic.Items.Insert(0, new ListItem("请选择", "0"));
        }
    }
}