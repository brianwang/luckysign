using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.BLG;
using AppMod.BLG;
using AppCmn;
using System.Data;
using WebMonitor;
using AppBll.User;

namespace WebForMain.Qin
{
    public partial class MyComment : PageBase
    {
        private int pageindex = 1;
        private int pagesize = AppConst.PageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Login(Request.Url.ToString());
                WebForMain.Master.Qin m_master = (WebForMain.Master.Qin)Master;
                m_master.SetTab(4);
                if (Request.QueryString["pn"] != null)
                {
                    try
                    {
                        pageindex = int.Parse(Request.QueryString["pn"]);
                    }
                    catch
                    { }
                }
                BindList();
                RightPannel1.m_user = GetSession().CustomerEntity;
            }
        }

        protected void BindList()
        {
            int total = 0;
            DataTable m_dt = BLG_CommentBll.GetInstance().GetUserArticleComments(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);

            rptComm.DataSource = m_dt;
            rptComm.DataBind();

            Pager1.url = "MyComment.aspx?pn=";
            Pager1.totalrecord = total;
            if (total % AppConst.PageSize == 0)
            {
                this.Pager1.total = total / pagesize;
            }
            else
            {
                this.Pager1.total = total / pagesize + 1;
            }
            this.Pager1.index = pageindex;
            this.Pager1.numlenth = 3;

            USR_CustomerBll.GetInstance().ZeroUnReadInfo(GetSession().CustomerEntity.SysNo);
        }

        protected void rptComm_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                BLG_ReplyMod m_reply = new BLG_ReplyMod();
                m_reply.CommentSysNo = (int)e.CommandArgument;
                m_reply.Context = ((TextBox)e.Item.FindControl("txtReply")).Text.Trim();
                m_reply.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                m_reply.DR = (int)AppEnum.State.normal;
                m_reply.Title = "";
                m_reply.TS = DateTime.Now;

                BLG_ReplyBll.GetInstance().Add(m_reply);
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('回复评论成功！');", true);
                LogManagement.getInstance().WriteTrace("前台回复评论", "Qin", "IP:" + Request.UserHostAddress + "|UID:" + GetSession().CustomerEntity.Email);
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('系统故障，请稍后再试！');", true);
                LogManagement.getInstance().WriteException(ex, "CommReply-Add", Request.UserHostAddress, "回复评论失败");
            }
        }
    }
}