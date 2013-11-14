using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;

namespace WebForMain.ControlLibrary
{
    public partial class ShowPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pPath = "t";
                if (base.Request.QueryString["type"] == null)
                {
                    return;
                }
                string type = base.Request.QueryString["type"].ToLower();
                if (type == null)
                {
                    return;
                }
                if (!(type == "tmp"))
                {
                    if (type != "t")
                    {
                        if (type != "o")
                        {
                            return;
                        }
                        goto Label_0108;
                    }
                }
                else
                {
                    pPath = base.Server.MapPath(@"~\WebResources\UpUserFiles\Photos\Tmp\o");
                    goto Label_0189;
                }
                if (base.Request.QueryString["id"].Contains("http://app.qlogo.cn"))
                {
                    base.Response.Redirect(base.Server.UrlDecode(base.Request.QueryString["id"]) + "/100");
                }
                pPath = base.Server.MapPath(@"~\WebResources\UpUserFiles\Photos\T\");
                goto Label_0189;
            Label_0108:
                if (base.Request.QueryString["id"].Contains("http://app.qlogo.cn"))
                {
                    base.Response.Redirect(base.Server.UrlDecode(base.Request.QueryString["id"]) + "/180");
                }
                pPath = base.Server.MapPath(@"~\WebResources\UpUserFiles\Photos\O\");
            Label_0189:
                if (base.Request.QueryString["id"] != null)
                {
                    pPath = pPath + base.Request.QueryString["id"];
                    if (!pPath.Contains("."))
                    {
                        pPath = pPath + ".jpg";
                    }
                    if (!File.Exists(pPath))
                    {
                        pPath = base.Server.MapPath(@"~\WebResources\Images\tx_03.jpg");
                    }
                    MemoryStream ms = new MemoryStream();
                    Image originalImg = Image.FromFile(pPath);
                    Bitmap image = new Bitmap(originalImg);
                    image.Save(ms, ImageFormat.Jpeg);
                    this.Context.Response.ClearContent();
                    this.Context.Response.ContentType = "image/Jpeg";
                    this.Context.Response.BinaryWrite(ms.GetBuffer());
                    ms.Close();
                    ms = null;
                    image.Dispose();
                    image = null;
                    originalImg.Dispose();
                    originalImg = null;
                }
            }
            catch
            {
            }
        }
    }
}