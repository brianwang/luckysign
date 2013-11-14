using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.User;
using AppMod.User;
using AppCmn;
using System.Data;
using WebMonitor;

namespace WebForMain.Qin
{
    public partial class MsgDetail : PageBase
    {
        public string TargetName = "";
        private int SysNo = 0;
        private int UserSysNo = 0;
        public int TargetID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Login(Request.Url.ToString());
            WebForMain.Master.Qin m_master = (WebForMain.Master.Qin)Master;
            m_master.SetTab(4);
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("../Error.aspx");
                }
            }
            else if (Request.QueryString["UserSysNo"] != null)
            {
                try
                {
                    TargetID = int.Parse(Request.QueryString["UserSysNo"]);
                    TargetName = USR_CustomerBll.GetInstance().GetModel(TargetID).NickName;
                }
                catch
                {
                    Response.Redirect("../Error.aspx");
                }
            }
            else
            {
                Response.Redirect("../Error.aspx");
            }
            if (!IsPostBack)
            {
                if (SysNo != 0)
                {
                    BindList();
                }

                imgPhoto.ImageUrl = "../ControlLibrary/ShowPhoto.aspx?type=t&id=" + GetSession().CustomerEntity.Photo;
                RightPannel1.m_user = GetSession().CustomerEntity;
            }
        }

        protected void BindList()
        {
            DataTable m_dt = USR_SMSBll.GetInstance().GetTalk(SysNo);
            rptMsg.DataSource = m_dt;
            rptMsg.DataBind();

            if (m_dt.Rows.Count > 0)
            {
                if (m_dt.Rows[0]["FromSysNo"].ToString() == GetSession().CustomerEntity.SysNo.ToString())
                {
                    TargetID = int.Parse(m_dt.Rows[0]["ToSysNo"].ToString());
                    TargetName = m_dt.Rows[0]["ToNickName"].ToString();
                }
                else if (m_dt.Rows[0]["ToSysNo"].ToString() == GetSession().CustomerEntity.SysNo.ToString())
                {
                    TargetID = int.Parse(m_dt.Rows[0]["FromSysNo"].ToString());
                    TargetName = m_dt.Rows[0]["FromNickName"].ToString();
                }
                else 
                {
                    Response.Redirect("../Error.aspx");
                }

                ViewState["targetsysno"] = TargetID;
            }
            else
            {
                Response.Redirect("../Error.aspx");
            } 
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                USR_SMSMod m_sms = new USR_SMSMod();
                m_sms.Context = SQLData.SQLFilter(txtReply.Text.Trim());
                m_sms.DR = (int)AppEnum.State.normal;
                m_sms.FromSysNo = GetSession().CustomerEntity.SysNo;
                m_sms.IsFromDeleted = (int)AppEnum.BOOL.False;
                m_sms.IsRead = (int)AppEnum.BOOL.False;
                m_sms.IsToDeleted = (int)AppEnum.BOOL.False;
                if (SysNo != 0)
                {
                    m_sms.Parent = SysNo;
                }
                else
                {
                    m_sms.Parent = 0;
                }
                m_sms.ReplyCount = 0;
                m_sms.Title = "";
                m_sms.TS = DateTime.Now;
                m_sms.ToSysNo = TargetID;

                int tmp = USR_SMSBll.GetInstance().AddSMS(m_sms);

                if (SysNo != 0)
                {
                    BindList();
                    ClientScript.RegisterStartupScript(this.GetType(), "reply", "alert('发送成功！');", true);
                }
                else
                {
                    Response.Redirect("MsgDetail.aspx?id="+tmp);
                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "reply", "alert('系统故障，请重新尝试');", true);
                LogManagement.getInstance().WriteException(ex, "SMS-reply", Request.UserHostAddress, "发送短信失败");
            }
        }
    }
}