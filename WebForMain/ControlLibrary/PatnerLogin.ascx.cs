using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using NetDimension.Weibo;
using AppCmn;

namespace WebForMain.ControlLibrary
{
    public partial class PatnerLogin : System.Web.UI.UserControl
    {
        public string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data/ThirdLogin.xml")));
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//AppID");
            XmlNode node1 = xmlDoc.SelectSingleNode("//ThirdLogin//WeiBo//Key");
            string returnurl = AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx";
            if (url != "")
            {
                returnurl += "?url=" + url;
            }
            var oauth = new NetDimension.Weibo.OAuth(node.InnerText, node1.InnerText, returnurl);
            
            //第一步获取新浪授权页面的地址
            var authUrl = oauth.GetAuthorizeURL(); //VS2008需要指定全部4个参数，这里是VS2010等支持“可选参数”的开发环境的写法
            // 第二步访问这个地址。
            Response.Redirect(authUrl);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data/ThirdLogin.xml")));
            XmlNode node = xmlDoc.SelectSingleNode("//ThirdLogin//QQ//AppID");
            string returnurl = AppConfig.HomeUrl() + "Passport/ThirdLogin.aspx";
            if (url != "")
            {
                returnurl += "?url=" + url;
            }
            Response.Redirect("https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=" + node.InnerText + "&redirect_uri=" + returnurl + "&state=test");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ImageButton1_Click(sender, new ImageClickEventArgs(0,0));
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ImageButton2_Click(sender, new ImageClickEventArgs(0, 0));
        }
    }
}