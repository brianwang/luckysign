using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;

namespace WebForMain.Qin
{
    public partial class AddBlog : PageBase
    {
        public AppEnum.BlogArticleType type = AppEnum.BlogArticleType.Article;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Login(Request.Url.ToString());
                WebForMain.Master.Qin master = (WebForMain.Master.Qin)this.Master;
                master.HideManu();
                //AsyncFileUpload1.Style.Add("display", "none");
                if (Request.QueryString["type"] != null)
                {
                    try
                    {
                        type = (AppEnum.BlogArticleType)int.Parse(Request.QueryString["type"]);
                    }
                    catch
                    {
                        Response.Redirect("Error.aspx");
                    }
                }

                switch (type)
                {
                    case AppEnum.BlogArticleType.Article:
                        fileadd.Style["display"] = "none";
                        filebox.Style["display"] = "none";
                        ltrTip.Visible = false;
                        break;
                    case AppEnum.BlogArticleType.Chart:
                        break;
                    case AppEnum.BlogArticleType.File:
                        ltrAddBtn.Text = "+添加文件";
                        break;
                    case AppEnum.BlogArticleType.Link:
                        break;
                    case AppEnum.BlogArticleType.Picture:
                        ltrAddBtn.Text = "+添加图片";
                        break;
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                string fileExtend = System.IO.Path.GetExtension(AsyncFileUpload1.FileName).ToLower();
                if (fileExtend == ".jpg" || fileExtend == ".png")
                {
                    string file = string.Format(@"{0}\{1}", Server.MapPath(".") + "\\Uploads", System.Guid.NewGuid() + fileExtend);
                    try
                    {
                        AsyncFileUpload1.SaveAs(file);
                        System.Threading.Thread.Sleep(3600);
                    }
                    catch
                    { }
                }
            }
        }

        protected void AsyncFileUpload1_UploadedFileError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

        }


    }
}