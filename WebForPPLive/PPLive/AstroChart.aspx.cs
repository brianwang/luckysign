using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using PPLive.Astro;
using System.Drawing;
using WebMonitor;

namespace WebForPPLive.PP
{
    public partial class AstroChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                try
                {
                    //生成图片
                    AstroMod mod = new AstroMod();
                    mod.graphicID = Request.QueryString["ID"];
                    if (Request.QueryString["fa"] != "")
                    {
                        mod.composeFile1 = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\" + Request.QueryString["fa"];
                    }
                    if (Request.QueryString["fb"] != "")
                    {
                        mod.composeFile2 = AppDomain.CurrentDomain.BaseDirectory + AppConfig.AstroGraphicPath() + @"Tmp\" + Request.QueryString["fb"];
                    }
                    AstroBiz.GetInstance().GetGraphic(mod);
                    //输出
                    CreateImageOnPage(AstroBiz.GetInstance().GetGraphicPath(mod.graphicID), HttpContext.Current);

                }
                catch(Exception ex)
                {
                    LogManagement.getInstance().WriteException(ex, "星盘显示", Request.UserHostAddress);
                }
            }
        }

        public void CreateImageOnPage(string Path, HttpContext context)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Bitmap image = new Bitmap(Path);

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            context.Response.ClearContent();
            context.Response.ContentType = "image/bmp";
            context.Response.BinaryWrite(ms.GetBuffer());

            ms.Close();
            ms = null;
            image.Dispose();
            image = null;
        }
    }
}