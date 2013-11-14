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

namespace WebForMain.Qin
{
    public partial class MyMessage : PageBase
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
            DataTable m_dt = USR_SMSBll.GetInstance().GetTopicByUser(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);
            m_dt.Columns.Add("msgcontent");
            #region 设置显示格式
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                //别人发起的
                if (m_dt.Rows[i]["ToSysNo"].ToString() == GetSession().CustomerEntity.SysNo.ToString())
                {
                    m_dt.Rows[i]["msgcontent"] = @"<div class='page_box_l'>
                <img src='../WebResources/" + m_dt.Rows[i]["FromPhoto"].ToString() + @"' /></div>
            <div class='page_box_r'>
                <div class='page_corner'>
                </div>
                <div class='page_box_all'>
                    <div class='page_person_name'>
                        <a href='View.aspx?id=" + m_dt.Rows[i]["FromSysNo"].ToString() + @"'>来自：" + m_dt.Rows[i]["FromName"].ToString() + @"</a>" + DateTime.Parse(m_dt.Rows[i]["TS"].ToString()).ToString("yyyy-MM-dd HH:mm") + @"</div>
                    <div class='page_person_con'>
                        <div class='page_person_letter'>
                            " + CommonTools.CutStr(m_dt.Rows[i]["Context"].ToString(), 200) + @"
                            <div class='page_person_letter_a'>
                                共" + m_dt.Rows[i]["ReplyCount"].ToString() + @"条消息<a href='MsgDetail.aspx?id=" + m_dt.Rows[i]["sysno"].ToString() + @"'>+展开</a> <a href='MsgDetail.aspx?id=" + m_dt.Rows[i]["sysno"].ToString() + @"#comm'>+回复</a>
                            </div>
                        </div>
                        <div class='clear'>
                        </div>
                    </div>
                </div>
            </div>";
                }
                //自己发起的
                else if (m_dt.Rows[i]["FromSysNo"].ToString() == GetSession().CustomerEntity.SysNo.ToString())
                {
                    m_dt.Rows[i]["msgcontent"] = @"<div class='page_box_letter_l'>
                <div class='page_corner_r'>
                </div>
                <div class='page_box_all'>
                    <div class='page_person_name'>
                        <a href='View.aspx?id=" + m_dt.Rows[i]["ToSysNo"].ToString() + @"'>发给：" + m_dt.Rows[i]["ToName"].ToString() + @"</a>" + DateTime.Parse(m_dt.Rows[i]["TS"].ToString()).ToString("yyyy-MM-dd HH:mm") + @"</div>
                    <div class='page_person_con'>
                        <div class='page_person_letter'>
                            " + CommonTools.CutStr(m_dt.Rows[i]["Context"].ToString(), 200) + @"
                            <div class='page_person_letter_a'>
                                共" + m_dt.Rows[i]["ReplyCount"].ToString() + @"条消息<a href='MsgDetail.aspx?id=" + m_dt.Rows[i]["sysno"].ToString() + @"'>+展开</a> <a href='MsgDetail.aspx?id=" + m_dt.Rows[i]["sysno"].ToString() + @"#comm'>+回复</a>
                            </div>
                        </div>
                        <div class='clear'>
                        </div>
                    </div>
                </div>
            </div>
            <div class='page_box_letter_r'>
                <img src='ControlLibrary/ShowPhoto.aspx?type=t&id=" + m_dt.Rows[i]["ToPhoto"].ToString() + @"' /></div>";
                }
            }
            #endregion
            rptMsg.DataSource = m_dt;
            rptMsg.DataBind();

            Pager1.url = "MyMessage.aspx?pn=";
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckNickName(txtName.Text.Trim());
            if (m_user.SysNo == AppConst.IntNull)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SendMsg", "alert('找不到该用户，请重新输入！');", true);
                ModalPopupExtender1.Show();
            }
            else
            {
                Response.Redirect("MsgDetail.aspx?UserSysNo=" + m_user.SysNo);
            }
        }
    }
}