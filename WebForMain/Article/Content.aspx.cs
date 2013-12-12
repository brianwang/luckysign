using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.CMS;
using AppMod.CMS;
using AppCmn;
using System.Data;

namespace WebForMain.Article
{
    public partial class Content : PageBase
    {
        private int sysno = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            m_master.SetTab(2);
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        sysno = int.Parse(Request.QueryString["id"]);
                    }
                    else
                    {
                        sysno = int.Parse(Page.RouteData.Values["id"].ToString());
                    }

                }
                catch
                {
                    ShowError("您访问的文章已删除或不存在！");
                }

                try
                {
                    string prepage = Request.UrlReferrer.ToString();
                    if (prepage.ToLower().Contains("/atricle/"))
                    {
                        lnkReturn.NavigateUrl = prepage;
                    }
                    else
                    {
                        lnkReturn.NavigateUrl = "~/Article/";
                    }
                }
                catch 
                {
                    lnkReturn.NavigateUrl = "~/Article/";
                }

                BindArticle();
            }
        }


        protected void BindArticle()
        {
            CMS_ArticleMod m_cms = CMS_ArticleBll.GetInstance().GetModel(sysno);
            SYS_ArticleMod m_article = SYS_ArticleBll.GetInstance().GetModel(m_cms.ArticleSysNo);
            Dictionary<int, SYS_ArticleContentMod> m_content = SYS_ArticleContentBll.GetInstance().GetContentByArticle(m_cms.ArticleSysNo);
            Dictionary<int, string[]> m_neighbour = CMS_ArticleBll.GetInstance().GetNeighbour(sysno,m_cms.CateSysNo);

            ltrTitle.Text = m_article.Title;
            ltrContent.Text = m_content[1].Context;

            #region 设置前一篇后一篇
            switch (m_neighbour.Count)
            {
                case 0:
                    ltrPre.Text = "已经是第一篇了";
                    ltrAft.Text = "已经是最后一篇了";
                    lnkPreTop.Enabled = false;
                    lnkPreBtm.Enabled = false;
                    lnkAftTop.Enabled = false;
                    lnkAftBtm.Enabled = false;
                    break;
                case 1:
                    if (int.Parse(m_neighbour[0][2]) > m_cms.OrderID || (int.Parse(m_neighbour[0][2]) == m_cms.OrderID && int.Parse(m_neighbour[0][2]) < m_article.SysNo))
                    {
                        ltrPre.Text = m_neighbour[0][1];
                        ltrAft.Text = "已经是最后一篇了";
                        lnkPreTop.NavigateUrl = "Content.aspx?id=" + m_neighbour[0][0];
                        lnkPreBtm.NavigateUrl = "Content.aspx?id=" + m_neighbour[0][0];
                        lnkAftTop.Enabled = false;
                        lnkAftBtm.Enabled = false;
                    }
                    else
                    {
                        ltrPre.Text = "已经是第一篇了";
                        ltrAft.Text = m_neighbour[1][1];
                        lnkPreTop.Enabled = false;
                        lnkPreBtm.Enabled = false;
                        lnkAftTop.NavigateUrl = "Content.aspx?id=" + m_neighbour[1][0];
                        lnkAftBtm.NavigateUrl = "Content.aspx?id=" + m_neighbour[1][0];
                    }
                    break;
                case 2:
                    ltrPre.Text = m_neighbour[0][1];
                    ltrAft.Text = m_neighbour[1][1];
                    lnkPreTop.NavigateUrl = "Content.aspx?id=" + m_neighbour[0][0];
                    lnkPreBtm.NavigateUrl = "Content.aspx?id=" + m_neighbour[0][0];
                    lnkAftTop.NavigateUrl = "Content.aspx?id=" + m_neighbour[1][0];
                    lnkAftBtm.NavigateUrl = "Content.aspx?id=" + m_neighbour[1][0];
                    break;
            }
            #endregion
        }

    }
}