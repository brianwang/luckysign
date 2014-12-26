using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using AppBll.CMS;
using AppMod.CMS;

using AppCmn;

namespace WebForAdmin.CMS
{
    public partial class Articles : PageBase
    {
        private int pageindex = 1;
        private int total = 0;
        private string urlnow = "Articles.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "查询文章";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Article1);
            #endregion
            if (!IsPostBack)
            {
                if (Request.QueryString["delete"] != null && Request.QueryString["delete"] != "")
                {
                    Delete();
                }

                if (Request.QueryString["pn"] != null && Request.QueryString["pn"] != "")
                {
                    try
                    {
                        pageindex = int.Parse(Request.QueryString["pn"]);
                    }
                    catch { }
                }
                urlnow += "?pn=" + pageindex;
                if (Request.QueryString["name"] != null && Request.QueryString["name"] != "")
                {
                    txtName.Text = Request.QueryString["name"];
                    urlnow += "&name=" + Request.QueryString["name"];
                }
                if (Request.QueryString["status"] != null && Request.QueryString["status"] != "")
                {
                    drpStatus.SelectedIndex = drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(Request.QueryString["status"]));
                    urlnow += "&status=" + Request.QueryString["status"];
                }
                
                BindCate();
                if (Request.QueryString["cate"] != null && Request.QueryString["cate"] != "")
                {
                    drpCate.SelectedIndex = drpCate.Items.IndexOf(drpCate.Items.FindByValue(Request.QueryString["cate"]));
                    urlnow += "&cate=" + Request.QueryString["cate"];
                }

                BindContent();
            }
        }

        protected void BindContent()
        {
            DataTable m_dt = CMS_ArticleBll.GetInstance().GetList(AppConst.PageSize, pageindex, txtName.Text.Trim(), int.Parse(drpCate.SelectedValue), int.Parse(drpStatus.SelectedValue),0, ref total);
            m_dt.Columns.Add("deleteurl");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                    m_dt.Rows[i]["deleteurl"] = urlnow + "&delete=";

            }
            rptFamous.DataSource = m_dt;
            rptFamous.DataBind();

            Pager1.url = "Articles.aspx?name=" + txtName.Text.Trim() + "&cate=" + drpCate.SelectedValue + "&status=" + drpStatus.SelectedValue + "&pn=";
            if (total % AppConst.PageSize == 0)
            {
                this.Pager1.total = total / AppConst.PageSize;
            }
            else
            {
                this.Pager1.total = total / AppConst.PageSize + 1;
            }
            this.Pager1.index = pageindex;
            this.Pager1.numlenth = 3;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articles.aspx?pn=1&name=" + txtName.Text.Trim() + "&cate=" + drpCate.SelectedValue + "&status=" + drpStatus.SelectedValue);
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
                CMS_ArticleMod m_famous = CMS_ArticleBll.GetInstance().GetModel(int.Parse(Request.QueryString["delete"]));
                m_famous.DR = (int)AppEnum.State.deleted;
                CMS_ArticleBll.GetInstance().Update(m_famous);

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
            DataTable parent = CMS_CategoryBll.GetInstance().GetCates(0);
            DataTable m_dt = new DataTable();
            m_dt.Columns.Add("SysNo");
            m_dt.Columns.Add("Name");
            for (int i = 0; i < parent.Rows.Count; i++)
            {
                DataTable tmp = CMS_CategoryBll.GetInstance().GetCates(int.Parse(parent.Rows[i]["SysNo"].ToString()));
                for (int j = 0; j < tmp.Rows.Count; j++)
                {
                    DataTable tmpp = CMS_CategoryBll.GetInstance().GetCates(int.Parse(tmp.Rows[j]["SysNo"].ToString()));
                    for (int k = 0; k < tmpp.Rows.Count; k++)
                    {
                        DataRow m_dr = m_dt.NewRow();
                        m_dr["SysNo"] = tmpp.Rows[k]["SysNo"];
                        m_dr["Name"] = parent.Rows[i]["Name"].ToString() + "-" + tmp.Rows[j]["Name"].ToString() + "-" + tmpp.Rows[k]["Name"].ToString();
                        m_dt.Rows.Add(m_dr);
                    }
                }
            }
            drpCate.DataSource = m_dt;
            drpCate.DataValueField = "SysNo";
            drpCate.DataTextField = "Name";
            drpCate.DataBind();
            drpCate.Items.Insert(0, new ListItem("请选择", "0"));
        }
    }
}