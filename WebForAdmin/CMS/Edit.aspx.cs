using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions; 
using System.Data;
using WebMonitor;
using AppBll.CMS;
using AppMod.CMS;
using AppCmn;

namespace WebForAdmin.CMS
{
    public partial class Edit : PageBase
    {
        public string type = "";
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "添加/修改文章";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Article2);
            #endregion

            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {
                type = Request.QueryString["type"].ToUpper().Trim();
            }
            if (!IsPostBack)
            {
                PrepareForm();
            }
        }

        protected void PrepareForm()
        {
            #region 选项绑定
            DataTable parent = CMS_CategoryBll.GetInstance().GetCates(0);
            DataTable m_dt = new DataTable();
            m_dt.Columns.Add("SysNo");
            m_dt.Columns.Add("Name");
            for (int i = 0; i < parent.Rows.Count; i++)
            {
                DataTable tmp = CMS_CategoryBll.GetInstance().GetCates(int.Parse(parent.Rows[i]["SysNo"].ToString()));
                for (int j = 0; j < tmp.Rows.Count; j++)
                {
                    DataTable tmpp = CMS_CategoryBll.GetInstance().GetCates(int.Parse(tmp.Rows[j]["SysNo"].ToString()));
                    for (int k = 0; k < tmpp.Rows.Count; k++)
                    {
                        DataRow m_dr = m_dt.NewRow();
                        m_dr["SysNo"] = tmpp.Rows[k]["SysNo"];
                        m_dr["Name"] = parent.Rows[i]["Name"].ToString() + "-" + tmp.Rows[j]["Name"].ToString() + "-" + tmpp.Rows[k]["Name"].ToString();
                        m_dt.Rows.Add(m_dr);
                    }
                }
            }

            drpCate.DataSource = m_dt;
            drpCate.DataTextField = "Name";
            drpCate.DataValueField = "SysNo";
            drpCate.DataBind();
            drpCate.Items.Insert(0, new ListItem("请选择", "0"));
            #endregion

            if (type == "ADD")
            {
            }
            else if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        SysNo = int.Parse(Request.QueryString["id"]);
                        CMS_ArticleMod m_cms = CMS_ArticleBll.GetInstance().GetModel(SysNo);
                        SYS_ArticleMod m_article = SYS_ArticleBll.GetInstance().GetModel(m_cms.ArticleSysNo);
                        Dictionary<int, SYS_ArticleContentMod> m_content = SYS_ArticleContentBll.GetInstance().GetContentByArticle(m_cms.ArticleSysNo);

                        txtSysNo.Text = m_cms.SysNo.ToString();
                        txtContext.Text = m_content[1].Context;
                        txtDesc.Text = m_article.Description;
                        txtKeyWords.Text = m_article.KeyWords;
                        txtOrder.Text = m_cms.OrderID.ToString();
                        txtPoint.Text = m_article.Cost.ToString();
                        txtSource.Text = m_cms.Source;
                        txtTitle.Text = m_article.Title;
                        txtAuthor.Text = m_cms.Author;

                        drpCate.SelectedIndex = drpCate.Items.IndexOf(drpCate.Items.FindByValue(m_cms.CateSysNo.ToString()));
                    }
                    catch
                    {
                        Response.Redirect("../Error.aspx?msg=");
                        return;
                    }
                }
            }
            else if (type == "INPUT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        int articleSysno = int.Parse(Request.QueryString["id"]);
                        SYS_ArticleMod m_article = SYS_ArticleBll.GetInstance().GetModel(articleSysno);
                        SYS_ArticleContentMod m_content = SYS_ArticleContentBll.GetInstance().GetModel(articleSysno);
                        txtSysNo.Text = "自动生成";
                        txtTitle.Text = m_article.Title;
                        txtContext.Text = m_content.Context;
                        txtDesc.Text = m_article.Description;
                        txtKeyWords.Text = m_article.KeyWords;
                        txtPoint.Text = m_article.Cost.ToString();
                        txtOrder.Text = "0";
                        txtTitle.Enabled = false;
                        txtContext.Enabled = false;
                        txtDesc.Enabled = false;
                        txtKeyWords.Enabled = false;
                        txtPoint.Enabled = false;
                    }
                    catch 
                    {
                        Response.Redirect("../Error.aspx?msg=");
                        return;
                    }
                }
            }
        }


        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            SYS_ArticleMod m_article = new SYS_ArticleMod();
            Dictionary<int, SYS_ArticleContentMod> m_content = new Dictionary<int, SYS_ArticleContentMod>();
            CMS_ArticleMod m_cms = new CMS_ArticleMod();
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                }
                m_cms = CMS_ArticleBll.GetInstance().GetModel(SysNo);
                m_article = SYS_ArticleBll.GetInstance().GetModel(m_cms.ArticleSysNo);
                m_content = SYS_ArticleContentBll.GetInstance().GetContentByArticle(m_cms.ArticleSysNo);
            }
            try
            {
                if (drpCate.SelectedValue == "0")
                {
                    ltrError.Text = "请选择分类！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    return;
                }
                m_article.Title = txtTitle.Text;
                if (type == "EDIT")
                {
                    m_content[1].Context = txtContext.Text;
                }
                m_article.Description = txtDesc.Text;
                m_article.KeyWords = txtKeyWords.Text;
                m_article.Cost = int.Parse(txtPoint.Text);
                m_cms.CateSysNo = int.Parse(drpCate.SelectedValue);
                m_cms.Source = txtSource.Text;
                m_cms.Author = txtAuthor.Text;
                if (txtOrder.Text.Trim() != "")
                {
                    m_cms.OrderID = int.Parse(txtOrder.Text.Trim());
                }
                else
                {
                    m_cms.OrderID = 0;
                }
            }
            catch
            {
                ltrError.Text = "输入资料格式有误，请检查！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            try
            {
                if (type == "ADD")
                {
                    m_article.CustomerSysNo = GetSession().AdminEntity.CustomerSysNo;
                    m_article.Limited = (int)AppEnum.ArticleLimit.everyone;
                    m_article.ReadCount = 0;
                    m_article.TS = DateTime.Now;
                    m_article.DR = (int)AppEnum.State.normal;
                    m_cms.ArticleSysNo = SYS_ArticleBll.GetInstance().Add(m_article);
                    m_cms.TS = DateTime.Now;
                    m_cms.DR = (int)AppEnum.State.normal;
                    CMS_ArticleBll.GetInstance().Add(m_cms);
                    SYS_ArticleContentMod m_newcontent = new SYS_ArticleContentMod();
                    m_newcontent.ArticleSysNo = m_cms.ArticleSysNo;
                    m_newcontent.Context = txtContext.Text;
                    m_newcontent.Page = 1;
                    m_newcontent.TS = DateTime.Now;
                    m_newcontent.DR = (int)AppEnum.State.normal;
                    SYS_ArticleContentBll.GetInstance().Add(m_newcontent);
                    
                    LogManagement.getInstance().WriteTrace(m_cms.SysNo, "Article.Add", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                }
                else if (type == "EDIT")
                {
                    CMS_ArticleBll.GetInstance().Update(m_cms);
                    SYS_ArticleBll.GetInstance().Update(m_article);
                    SYS_ArticleContentBll.GetInstance().Update(m_content[1]);
                    
                    LogManagement.getInstance().WriteTrace(m_cms.SysNo, "Article.Edit", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                }
                else if (type == "INPUT")
                {
                    m_cms.ArticleSysNo = SYS_ArticleBll.GetInstance().Add(m_article);
                    CMS_ArticleBll.GetInstance().Add(m_cms);

                    LogManagement.getInstance().WriteTrace(m_cms.SysNo, "Article.Input", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                }
                ltrNotice.Text = "该记录已保存成功！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            catch (Exception ex)
            {
                ltrError.Text = "系统错误，保存失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                LogManagement.getInstance().WriteException(ex, "Article.Save", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UploadIMG m_upload = new UploadIMG();
            m_upload.Path = @"..\MainSite\WebResources\ArticleImg\";
            m_upload.IsThumbnail = false;
            try
            {
                if (m_upload.UpLoadIMG(FileUpload1))
                {
                    Image1.ImageUrl = AppConfig.WebResourcesPath()+"ArticleImg/" + m_upload.OFileName;
                    Image1.Visible = true;
                    TextBox1.Text = AppConfig.WebResourcesPath() + "ArticleImg/" + m_upload.OFileName;
                    TextBox1.Visible = true;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "photook", "alert('" + m_upload.MSG + "');", true);
                }
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "WebForMain.Userphoto.Upload", Request.UserHostAddress);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photook", "alert('系统故障，请联系管理员');", true);
            }
        }

        
    }

}
