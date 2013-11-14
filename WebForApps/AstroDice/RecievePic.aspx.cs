using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebForApps
{
    public partial class RecievePic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string newName = "";
            if (Request.QueryString["id"] != null)
            {
                newName = Server.MapPath("../WebResources/DicePic/") + Request.QueryString["id"] + ".jpg";

                int length = Request.TotalBytes;
                byte[] buffer = Request.BinaryRead(length);
                FileStream fs = new FileStream(newName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buffer);
                bw.Close();
                fs.Close();
            }
        }


    }
}