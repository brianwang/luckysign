using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.BLG;
using AppCmn;

namespace WebForMain.Qin
{
	public partial class Index : PageBase
	{
        private int pageindex = 1;
        private int pagesize = 12;
        public int TotalFriends = 0;
        public int TotalFans = 0;
        public int TotalLike = 0;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Login(Request.Url.ToString());

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
                BindLike();

                imgPhoto.ImageUrl = "<%=AppCmn.AppConfig.WebResourcesPath() %>" + GetSession().CustomerEntity.Photo;
            }
		}

        #region Add button

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Unnamed5_Click(object sender, ImageClickEventArgs e)
        {

        }
        #endregion topbutton

        protected void Unnamed7_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {

        }

        #region 绑定列表
        protected void BindList()
        {
            int total = 0;
            DataTable m_dt = BLG_ArticleBll.GetInstance().GetAttendtionArticle(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);
            ComboShow1.DataList = m_dt;

            Pager1.url = "Index.aspx?pn=";
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
        }

        protected void BindFriend()
        {
            int total = 0;
            DataTable m_dt = BLG_AttentionBll.GetInstance().GetUserAttentions(GetSession().CustomerEntity.SysNo, 12, 1, ref total);
            rptFriend.DataSource = m_dt;
            rptFriend.DataBind();
            TotalFriends = total;
        }

        protected void BindFans()
        {
            int total = 0;
            DataTable m_dt = BLG_AttentionBll.GetInstance().GetUserFans(GetSession().CustomerEntity.SysNo, 12, 1, ref total);
            rptFriend.DataSource = m_dt;
            rptFriend.DataBind();
            TotalFans = total;
        }

        protected void BindLike()
        {
            
        }

        #endregion 

        #region right more
        protected void Unnamed9_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed11_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}