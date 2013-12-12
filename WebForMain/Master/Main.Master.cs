using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using AppBll.User;

namespace WebForMain.Master
{
    public partial class Main : System.Web.UI.MasterPage
    {      
        private string[] _tab = { "now","","","","",""};
        //public string css = @"<link href="""+AppCmn.AppConfig.WebResourcesPath() +@"CSS/style.css"" rel=""stylesheet"" type=""text/css"" />";
        public string[] tab
        {
            get { return _tab; }
            set { _tab = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IsLogin();
        }

        private void IsLogin()
        {
            PageBase m_base = new PageBase();
            if(m_base.GetSession().CustomerEntity!= null&& m_base.GetSession().CustomerEntity.SysNo != AppConst.IntNull)
            {
                ltrLinks.Text = "<a href='/Passport/Login.aspx?type=logout' title='注销'>退出</a> ｜ <a href='/Qin/View.aspx?id=" + m_base.GetSession().CustomerEntity.SysNo + "' title='我的首页'>我的首页</a>";
                ltrTips.Text =  m_base.GetSession().CustomerEntity.NickName + "，欢迎回到上上签";
                int sms = USR_CustomerBll.GetInstance().GetUnReadInfoNum(m_base.GetSession().CustomerEntity.SysNo);
                if (sms > 0)
                {
                    ltrLinks.Text += @"<div class=""msg_tip_box""><a href=""../Qin/MyNotice.aspx"">您有"+sms+"条新消息</a></div>";
                }
            }
        }
        public void SetTab(int input)
        {
            for(int i=0;i<_tab.Length;i++)
            {
                if (i == input)
                {
                    _tab[i] = "now";
                }
                else
                {
                    _tab[i] = "";
                }
            }
        }
    }
}