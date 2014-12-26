using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.BLG;
using AppCmn;
using AppMod.User;
using AppBll.User;

namespace WebForMain.Qin
{
    public partial class View : PageBase
    {
        private int pageindex = 1;
        private int pagesize = 12;
        public int TotalFriends = 0;
        public int TotalFans = 0;
        public int TotalLike = 0;
        public USR_CustomerMod m_user = new USR_CustomerMod();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        m_user = USR_CustomerBll.GetInstance().GetModel(int.Parse(Request.QueryString["id"]));
                    }
                    catch
                    {
                        Response.Redirect("../Error.aspx");
                    }
                }

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
                BindFriend();
                BindFans();

                if (BLG_AttentionBll.GetInstance().IsFans(GetSession().CustomerEntity.SysNo, m_user.SysNo))
                {
                    LinkButton1.Text = "取消关注";
                }
                else
                {
                    LinkButton1.Text = "添加关注";
                }
            }
        }

        #region 绑定列表
        protected void BindList()
        {
            int total = 0;
            DataTable m_dt = BLG_ArticleBll.GetInstance().GetAttendtionArticle(m_user.SysNo, pagesize, pageindex, ref total);
            ComboShow1.DataList = m_dt;

            Pager1.url = "Index.aspx?id="+m_user.SysNo+"&pn=";
            Pager1.totalrecord = total;
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

        protected void BindFriend()
        {
            int total = 0;
            DataTable m_dt = BLG_AttentionBll.GetInstance().GetUserAttentions(m_user.SysNo, 12, 1, ref total);
            rptFriend.DataSource = m_dt;
            rptFriend.DataBind();
            TotalFriends = total;
        }

        protected void BindFans()
        {
            int total = 0;
            DataTable m_dt = BLG_AttentionBll.GetInstance().GetUserFans(m_user.SysNo, 12, 1, ref total);
            rptFriend.DataSource = m_dt;
            rptFriend.DataBind();
            TotalFans = total;
        }

        #endregion 

        protected void Unnamed7_Click(object sender, EventArgs e)
        {
            if (LinkButton1.Text == "添加关注")
            {
                BLG_AttentionBll.GetInstance().AddAttention(GetSession().CustomerEntity.SysNo, m_user.SysNo);
                LinkButton1.Text = "取消关注";
            }
            else
            {
                BLG_AttentionBll.GetInstance().RemoveAttention(GetSession().CustomerEntity.SysNo, m_user.SysNo);
                LinkButton1.Text = "添加关注";
            }
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            Response.Redirect("MsgDetail.aspx?UserSysNo="+m_user.SysNo);
        }
    }
}