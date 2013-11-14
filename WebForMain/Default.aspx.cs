using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMonitor;
using AppMod.User;
using AppBll.User;
using AppCmn;
using System.Data;
using AppBll.QA;
using AppBll.CMS;
using AppBll.WebSys;

namespace WebForMain
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (GetSession().CustomerEntity == null || GetSession().CustomerEntity.SysNo == AppConst.IntNull)
            //{ }
            //else
            //{
            //    Server.Transfer("Qin/Index.aspx");
            //}
            WebForMain.Master.Main m_master = (WebForMain.Master.Main)Master;
            //m_master.css = "";

            if (!IsPostBack)
            {
                BindCate();
                BindQuest();
                BindFamous();
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text.Trim();
            string password = txtPass.Text.Trim();
            #region 验证邮箱有效性
            #endregion

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(username, password);
            if (m_user.SysNo != AppConst.IntNull)//COOKIES验证成功
            {
                SessionInfo m_session = new SessionInfo();
                m_session.CustomerEntity = m_user;
                m_session.GradeEntity = USR_GradeBll.GetInstance().GetModel(m_user.SysNo);
                Session[AppConfig.CustomerSession] = m_session;
                //记住我
                if (chkRemember.Checked)
                {
                    HttpCookie Cookie = CookiesHelper.GetCookie("upup1000");
                    if (Cookie == null || Cookie.Value == null || Cookie.Value == "")
                    {
                        Cookie = new HttpCookie("upup1000");
                        Cookie.Values.Add("uname", CommonTools.Encode(username));
                        Cookie.Values.Add("psd", CommonTools.Encode(password));
                        //设置Cookie过期时间
                        Cookie.Expires = DateTime.Now.AddYears(50);
                        CookiesHelper.AddCookie(Cookie);
                    }
                    else
                    {
                        CookiesHelper.SetCookie("upup1000", "uname", CommonTools.Encode(username), DateTime.Now.AddYears(50));
                        CookiesHelper.SetCookie("upup1000", "psd", CommonTools.Encode(password), DateTime.Now.AddYears(50));
                    }
                }
                LogManagement.getInstance().WriteTrace("前台会员登录", "Login", "IP:" + Request.UserHostAddress + "|AdminID:" + m_session.CustomerEntity.Email);
                //跳转
                Response.Redirect("Qin/View.aspx?id=" + m_user.SysNo);
            }
            else
            {
                Response.Redirect("Passport/Login.aspx?email=" + txtEmail.Text.Trim() + "&error=" + (int)AppEnum.ErrorType.WrongAccount);
            }
        }

        protected void BindQuest()
        {
            int total = 0;
            DataTable dt = new DataTable();
            if (HttpRuntime.Cache[AppConst.HomePageNewCeAnswer] == null)
            {
                dt = QA_QuestionBll.GetInstance().GetList(10, 1, "", 1, "replytimedown", ref total);
                dt.Columns.Add("IsHot");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (int.Parse(dt.Rows[i]["ReplyCount"].ToString()) < 5)
                        dt.Rows[i]["IsHot"] = i + "' style='display:none;";
                }
                HttpRuntime.Cache.Insert(AppConst.HomePageNewCeAnswer, dt,
                 null, DateTime.Now.AddMinutes(1), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt = HttpRuntime.Cache[AppConst.HomePageNewCeAnswer] as DataTable;
            rptCeNew.DataSource = dt;
            rptCeNew.DataBind();

            DataTable dt1 = new DataTable();
            if (HttpRuntime.Cache[AppConst.HomePageNewCeQuest] == null)
            {
                dt1 = QA_QuestionBll.GetInstance().GetList(10, 1, "", 1, "timedown", ref total); dt1.Columns.Add("IsNew");
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if ((DateTime.Now - DateTime.Parse(dt1.Rows[i]["LastReplyTime"].ToString())).TotalHours > 10)
                        dt1.Rows[i]["IsNew"] = i + "' style='display:none;";
                }
                HttpRuntime.Cache.Insert(AppConst.HomePageNewCeQuest, dt1,
                 null, DateTime.Now.AddMinutes(1), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt1 = HttpRuntime.Cache[AppConst.HomePageNewCeQuest] as DataTable;
            tprCeHot.DataSource = dt1;
            tprCeHot.DataBind();


            DataTable dt2 = new DataTable();
            if (HttpRuntime.Cache[AppConst.HomePageNewStudyAnswer] == null)
            {
                dt2 = QA_QuestionBll.GetInstance().GetList(10, 1, "", 2, "replytimedown", ref total);
                dt2.Columns.Add("IsHot");
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (int.Parse(dt2.Rows[i]["ReplyCount"].ToString()) < 5)
                        dt2.Rows[i]["IsHot"] = i + "' style='display:none;";
                }
                HttpRuntime.Cache.Insert(AppConst.HomePageNewStudyAnswer, dt2,
                 null, DateTime.Now.AddMinutes(1), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt2 = HttpRuntime.Cache[AppConst.HomePageNewStudyAnswer] as DataTable;
            rptStudyNew.DataSource = dt2;
            rptStudyNew.DataBind();

            DataTable dt3 = new DataTable();
            if (HttpRuntime.Cache[AppConst.HomePageNewStudyQuest] == null)
            {
                dt3 = QA_QuestionBll.GetInstance().GetList(10, 1, "", 2, "timedown", ref total);
                dt3.Columns.Add("IsNew");
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if ((DateTime.Now - DateTime.Parse(dt3.Rows[i]["LastReplyTime"].ToString())).TotalHours > 10)
                        dt3.Rows[i]["IsNew"] = i + "' style='display:none;";
                }
                HttpRuntime.Cache.Insert(AppConst.HomePageNewStudyQuest, dt3,
                 null, DateTime.Now.AddMinutes(1), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt3 = HttpRuntime.Cache[AppConst.HomePageNewStudyQuest] as DataTable;
            rptStudyHot.DataSource = dt3;
            rptStudyHot.DataBind();
        }

        //protected void rptStar_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Repeater rptQuest = (Repeater)e.Item.FindControl("rptQuest");

        //        //找到分类Repeater关联的数据项 
        //        DataRowView rowv = (DataRowView)e.Item.DataItem;
        //        //提取分类ID 
        //        int CustomerId = Convert.ToInt32(rowv["CustomerSysNo"]);
        //        //根据分类ID查询该分类下的产品，并绑定产品Repeater                 

        //        DataTable dt = QA_QuestionBll.GetInstance().GetStarsList(CustomerId, 5);
        //        dt.Columns.Add("RemainTime");
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            DateTime m_dt = DateTime.Parse(dt.Rows[i]["EndTime"].ToString());
        //            if (m_dt <= DateTime.Now)
        //            {
        //                dt.Rows[i]["RemainTime"] = "已结束";
        //            }
        //            else
        //            {
        //                dt.Rows[i]["RemainTime"] = CommonTools.TimeSimpleShow(m_dt - DateTime.Now);
        //            }
        //        }
        //        rptQuest.DataSource = dt;
        //        rptQuest.DataBind();
        //    }
        //}

        protected void BindCate()
        {
            DataTable m_dt = CMS_CategoryBll.GetInstance().GetCates(0);
            m_dt.Columns.Add("on");
            m_dt.Columns.Add("show");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    m_dt.Rows[i]["on"] = "on";
                    m_dt.Rows[i]["show"] = "show";
                }
                else if (i == m_dt.Rows.Count - 1)
                {
                    m_dt.Rows[i]["on"] = "last";
                    m_dt.Rows[i]["show"] = "";
                }
                else
                {
                    m_dt.Rows[i]["on"] = "";
                    m_dt.Rows[i]["show"] = "";
                }
            }
            rptCMSCate.DataSource = m_dt;
            rptCMSCate.DataBind();
            rptCateArticle.DataSource = m_dt;
            rptCateArticle.DataBind();

        }

        protected void rptCMSCate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptQuest = (Repeater)e.Item.FindControl("rptArticle");
                Repeater rptQuest1 = (Repeater)e.Item.FindControl("rptArticle1");

                //找到分类Repeater关联的数据项 
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //提取分类ID 
                int CateId = Convert.ToInt32(rowv["SysNo"]);
                //根据分类ID查询该分类下的产品，并绑定产品Repeater     
                DataSet ds = new DataSet();
                if (HttpRuntime.Cache[AppConst.HomePageArticle + CateId] == null)
                {
                    DataTable dt = CMS_ArticleBll.GetInstance().GetIndexCateArticle(20, CateId);
                    dt.Columns.Add("IsHot");
                    DataTable dt1 = dt.Copy();
                    dt1.TableName = dt1.TableName+"1"; 
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i > 9)
                        {
                            dt.Rows.RemoveAt(i);
                            i--;
                            continue;
                        }
                        if (int.Parse(dt.Rows[i]["ReadCount"].ToString()) < 10)
                            dt.Rows[i]["IsHot"] = i + "' style='display:none;";
                    }
                    for (int i = dt1.Rows.Count-1; i >=0; i--)
                    {
                        if (i < 10)
                        {
                            dt1.Rows.RemoveAt(i);
                            continue;
                        }
                        if (int.Parse(dt1.Rows[i]["ReadCount"].ToString()) < 10)
                            dt1.Rows[i]["IsHot"] = i + "' style='display:none;";
                    }
                    //dt.Columns.Add("keys");
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    dt.Rows[i]["keys"] = "";
                //    string[] tmps = dt.Rows[i]["KeyWords"].ToString().Split(new char[] { ',', ' ', '|' });
                //    if (tmps.Length > 0)
                //    {
                //        for (int j = 0; j < tmps.Length; j++)
                //        {
                //            dt.Rows[i]["keys"] += @"<a href='Article/Index.aspx?key=" + tmps[j] + "'>tmps[j]</a>"; 
                //        }
                //    }
                //}
                    ds.Tables.Add(dt);
                    ds.Tables.Add(dt1);
                    HttpRuntime.Cache.Insert(AppConst.HomePageArticle + CateId, ds,
                 null, DateTime.Now.AddMinutes(10), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
                }

                ds = HttpRuntime.Cache[AppConst.HomePageArticle + CateId] as DataSet;
                rptQuest.DataSource = ds.Tables[0];
                rptQuest.DataBind();
                rptQuest1.DataSource = ds.Tables[1];
                rptQuest1.DataBind();
            }
        }

        protected void BindFamous()
        {
            DataTable m_dt = new DataTable();
            if (HttpRuntime.Cache[AppConst.HomePageFamous] == null)
            {
                m_dt=SYS_FamousBll.GetInstance().GetTodayTopList(6);
                for (int i = 0; i < m_dt.Rows.Count; i++)
                {
                    if (m_dt.Rows[i]["photo"].ToString() == "")
                    {
                        m_dt.Rows[i]["photo"] = AppConst.OriginalFamousPhoto;
                    }
                    else if (!m_dt.Rows[i]["photo"].ToString().Contains("//"))
                    {
                        m_dt.Rows[i]["photo"] = "WebResources/FamousPhoto/" + m_dt.Rows[i]["photo"];
                    }
                }
                HttpRuntime.Cache.Insert(AppConst.HomePageFamous, m_dt,
                 null, DateTime.Now.AddHours(1), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            m_dt = HttpRuntime.Cache[AppConst.HomePageFamous] as DataTable;

            rptFamous.DataSource = m_dt;
            rptFamous.DataBind();

            DataTable m_dt1 = new DataTable();
            if (HttpRuntime.Cache[AppConst.HomePageFamousKey] == null)
            {
                int total = 0;
                m_dt1 = SYS_Famous_KeyWordsBll.GetInstance().GetList(20,1,"","",true,ref total);
                HttpRuntime.Cache.Insert(AppConst.HomePageFamousKey, m_dt1,
                 null, DateTime.Now.AddHours(1), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            m_dt1 = HttpRuntime.Cache[AppConst.HomePageFamousKey] as DataTable;

            rptKeys.DataSource = m_dt1;
            rptKeys.DataBind();

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Passport/Register.aspx");
        }

    }
}