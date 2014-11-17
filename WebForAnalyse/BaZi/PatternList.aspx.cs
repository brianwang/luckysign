using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.Research;
using AppMod.Research;
using AppCmn;

namespace WebForAnalyse.BaZi
{
    public partial class PatternList : PageBase
    {
        private int pageindex = 1;
        private int total = 0;
        private string urlnow = "PatternList.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            //Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAnalyse.Master.AdminMaster m_master = (WebForAnalyse.Master.AdminMaster)this.Master;
            m_master.PageName = "八字组合";
            m_master.SetCate(WebForAnalyse.Master.AdminMaster.CateType.BaZi3);
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

                BindContent();
            }
        }

        protected void BindContent()
        {
            DataTable m_dt = RSH_BaziLogicBll.GetInstance().GetList(AppConst.PageSize, pageindex, txtName.Text.Trim(), ref total);
            m_dt.Columns.Add("deleteurl");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                m_dt.Rows[i]["deleteurl"] = urlnow + "&delete=";
            }
            rptFamous.DataSource = m_dt;
            rptFamous.DataBind();

            Pager1.url = "PatternList.aspx?name=" + txtName.Text.Trim() + "&pn=";
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
            Response.Redirect("PatternList.aspx?pn=1&name=" + txtName.Text.Trim());
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
                RSH_BaziLogicMod m_logic = RSH_BaziLogicBll.GetInstance().GetModel(int.Parse(Request.QueryString["delete"]));
                m_logic.DR = (int)AppEnum.State.deleted;
                RSH_BaziLogicBll.GetInstance().Update(m_logic);

                ltrNotice.Text = "该记录已删除！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            catch
            {
                ltrError.Text = "系统错误，删除失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
        }
    }
}
