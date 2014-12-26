using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.WebSys;
using AppMod.WebSys;
using AppCmn;

namespace WebForAdmin.Celebrity
{
    public partial class Keys : PageBase
    {
        private int pageindex = 1;
        private int total = 0;
        private string urlnow = "Keys.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "案例关键字";
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

                BindContent();
            }
        }

        protected void BindContent()
        {
            DataTable m_dt = SYS_Famous_KeyWordsBll.GetInstance().GetList(AppConst.PageSize, pageindex, txtName.Text.Trim(),drpStatus.SelectedValue,false, ref total);
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

            Pager1.url = "Keys.aspx?name=" + txtName.Text.Trim() + "&status=" + drpStatus.SelectedValue + "&pn=";
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
            Response.Redirect("Keys.aspx?pn=1&name=" + txtName.Text.Trim() +"&status=" + drpStatus.SelectedValue);
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
                 SYS_Famous_KeyWordsMod m_kyes = SYS_Famous_KeyWordsBll.GetInstance().GetModel(int.Parse(Request.QueryString["delete"]));
                 m_kyes.DR = (int)AppEnum.State.deleted;
                 SYS_Famous_KeyWordsBll.GetInstance().Update(m_kyes);

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
                SYS_Famous_KeyWordsMod m_kyes = SYS_Famous_KeyWordsBll.GetInstance().GetModel(sysno);
                if (input)
                {
                    m_kyes.IsTop = (int)AppEnum.BOOL.True;
                }
                else
                {
                    m_kyes.IsTop = (int)AppEnum.BOOL.False;
                }
                SYS_Famous_KeyWordsBll.GetInstance().Update(m_kyes);

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
