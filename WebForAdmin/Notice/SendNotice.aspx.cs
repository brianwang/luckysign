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

namespace WebForAdmin.Notice
{
    public partial class SendNotice : PageBase
    {
        public string type = "TOP";
        public int SysNo = 0;
        private int pagesize = 20;
        private int pageindex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "发送系统通知";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Notice1);
            #endregion

            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {
                type = Request.QueryString["type"].ToUpper().Trim();
            }
            if (Request.QueryString["pn"] != null && Request.QueryString["pn"] != "")
            {
                try
                {
                    pageindex = int.Parse(Request.QueryString["pn"]);
                }
                catch { }
            }
            if (!IsPostBack)
            {
                PrepareForm();
            }
        }

        protected void PrepareForm()
        {
            int total = 0;
            rptFamous.DataSource = USR_NoticeBll.GetInstance().GetList(pagesize, pageindex, ref total);
            rptFamous.DataBind();

            Pager1.url = "SendNotice.aspx?pn=";
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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                ltrError.Text = "请输入标题！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            if (txtContext.Text.Trim() == "")
            {
                ltrError.Text = "请输入内容！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            
            try
            {
                USR_NoticeMod m_notice = new USR_NoticeMod();
                m_notice.Condition = txtWhere.Text.Trim();
                m_notice.Context = txtContext.Text.Trim();
                m_notice.DR = (int)AppEnum.State.prepare;
                m_notice.Title = txtTitle.Text.Trim();
                m_notice.TS = DateTime.Now;
                m_notice.CustomerNum = 0;
                USR_NoticeBll.GetInstance().Add(m_notice);

                LogManagement.getInstance().WriteTrace(m_notice.SysNo, "Notice.Send", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);

                ltrNotice.Text = "该消息已添加到发送队列中！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);

                PrepareForm();
            }
            catch(Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "Notice.Send", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                ltrError.Text = "系统错误，请检查！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
        }
    }
}
