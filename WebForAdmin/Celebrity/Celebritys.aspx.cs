using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.WebSys;
using AppBll.Spider;
using AppMod.WebSys;
using AppCmn;

namespace WebForAdmin.Celebrity
{
    public partial class Celebritys : PageBase
    {
        private int pageindex = 1;
        private int total = 0;
        private string urlnow = "Celebritys.aspx";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
                Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
                WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
                m_master.PageName = "查询名人案例库";
                m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Famous1);
                #endregion
            if (!IsPostBack)
            {
                
                if (Request.QueryString["delete"] != null && Request.QueryString["delete"] != "")
                {
                    Delete();
                }
                if (Request.QueryString["top"] != null && Request.QueryString["top"] != "")
                {
                    SetTop(true);
                }
                if (Request.QueryString["notop"] != null && Request.QueryString["top"] != "")
                {
                    SetTop(false);
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
                if (Request.QueryString["begin"] != null && Request.QueryString["begin"] != "")
                {
                    txtTimeBegin.Text = Request.QueryString["begin"];
                    urlnow += "&begin=" + Request.QueryString["begin"];
                }
                if (Request.QueryString["end"] != null && Request.QueryString["end"] != "")
                {
                    txtTimeEnd.Text = Request.QueryString["end"];
                    urlnow += "&end=" + Request.QueryString["end"];
                }
               
                BindContent();
            }
        }

        protected void BindContent()
        {
            DateTime beginTime = AppCmn.AppConst.DateTimeNull;
            DateTime endTime = AppCmn.AppConst.DateTimeNull;
            try
            {
                if (txtTimeBegin.Text != "")
                {
                    beginTime = DateTime.Parse(txtTimeBegin.Text.Trim());
                }
                if (txtTimeEnd.Text != "")
                {
                    endTime = DateTime.Parse(txtTimeEnd.Text.Trim());
                }
            }
            catch { }
            DataTable m_dt = SYS_FamousBll.GetInstance().GetList(AppConst.PageSize, pageindex, txtName.Text.Trim(), beginTime, endTime,drpStatus.SelectedValue,false, ref total);
            m_dt.Columns.Add("deleteurl");
            m_dt.Columns.Add("topurl");
            m_dt.Columns.Add("topname");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                m_dt.Rows[i]["deleteurl"] = urlnow + "&delete=";
                    if (m_dt.Rows[i]["IsTop"].ToString() == ((int)AppEnum.BOOL.True).ToString())
                    {
                        m_dt.Rows[i]["topurl"] = urlnow + "&notop=";
                        m_dt.Rows[i]["topname"] = "取消置顶";
                    }
                    else
                    {
                        m_dt.Rows[i]["topurl"] = urlnow + "&top=";
                        m_dt.Rows[i]["topname"] = "置顶到首页";
                    }
               
            }
            rptFamous.DataSource = m_dt;
            rptFamous.DataBind();

            Pager1.url = "Celebritys.aspx?name=" + txtName.Text.Trim() + "&begin=" + txtTimeBegin.Text.Trim() + "&end=" + txtTimeEnd.Text.Trim() + "&status=" + drpStatus.SelectedValue + "&pn=";
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
            Response.Redirect("Celebritys.aspx?pn=1&name=" + txtName.Text.Trim() + "&begin=" + txtTimeBegin.Text.Trim() + "&end=" + txtTimeEnd.Text.Trim() + "&status=" + drpStatus.SelectedValue);
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
                SYS_FamousMod m_famous = SYS_FamousBll.GetInstance().GetModel(int.Parse(Request.QueryString["delete"]));
                m_famous.DR = (int)AppEnum.State.deleted;
                SYS_FamousBll.GetInstance().Update(m_famous);
                if (m_famous.Source != "")
                {
                    SPD_FamousBll.GetInstance().InputReturn(m_famous.SysNo);
                }

                ltrNotice.Text = "该记录已删除！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            catch
            {
                ltrError.Text = "系统错误，删除失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
        }

        /// <summary>
        /// 首页置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SetTop(bool input)
        {
            try
            {
                int sysno = 0;
                if (input)
                {
                    sysno = int.Parse(Request.QueryString["top"]);
                }
                else
                {
                    sysno = int.Parse(Request.QueryString["notop"]);
                }
                SYS_FamousMod m_famous = SYS_FamousBll.GetInstance().GetModel(sysno);
                if (input)
                {
                    m_famous.IsTop = (int)AppEnum.BOOL.True;
                }
                else
                {
                    m_famous.IsTop = (int)AppEnum.BOOL.False;
                }
                SYS_FamousBll.GetInstance().Update(m_famous);

                ltrNotice.Text = "该记录已置顶！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            catch
            {
                ltrError.Text = "系统错误，置顶失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
        }
        
    }
}
