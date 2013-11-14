using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using System.Data;
using AppBll.User;

namespace WebForMain.Qin
{
    public partial class MyNotice : PageBase
    {
        private int pageindex = 1;
        private int pagesize = 12;
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
            DataTable m_dt = USR_MessageBll.GetInstance().GetMessageByCustomer(GetSession().CustomerEntity.SysNo, pagesize, pageindex,-1,(int)AppEnum.MessageType.notice, ref total);            
            rptMsg.DataSource = m_dt;
            rptMsg.DataBind();

            Pager1.url = "MyNotice.aspx?pn=";
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


    }
}