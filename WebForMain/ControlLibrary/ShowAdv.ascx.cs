using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using AppCmn;
using System.Net;
using System.IO;
using System.Text;

namespace WebForMain.ControlLibrary
{
    /// <summary>
    ///		Summary description for ShowAdv
    /// </summary>
    public partial class ShowAdv : System.Web.UI.UserControl
    {
        public string AdvFrom;
        public string HtmlOrg;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // AdvFromN = "http://www.zuanj.com/xdd/" + AdvFrom;
            // Put user code to initialize the page here
            ShowContent();
        }

        protected string ShowContent()
        {
            if (string.IsNullOrEmpty(AdvFrom) == true)
                return AppConst.StringNull;
            else
            {
                // string filePath = "http://www.zuanj.com/xdd/ " + AdvFrom;
                string filePath = AppConfig.AdvFolderPath + AdvFrom;
                return CommonTools.ReadHtmFile(filePath);
            }
        }

        public string AnotherShowContent()
        {
            try
            {
                string source = string.Empty;

                //  string filePath = AppConfig.Adv + @"\" + AdvFrom; 

                string filePath = AppConfig.AdvFolderPath + AdvFrom;
                string html = string.Empty;
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(filePath);
                HttpWebResponse loWebResponse = (HttpWebResponse)http.GetResponse();
                StreamReader loResponseStream = new StreamReader(loWebResponse.GetResponseStream(), Encoding.Default);
                html = loResponseStream.ReadToEnd();
                loWebResponse.Close();

                loResponseStream.Close();
                return html;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        
    }
}
