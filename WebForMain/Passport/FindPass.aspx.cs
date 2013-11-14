using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using AppMod.User;
using AppBll.User;
using WebMonitor;

namespace WebForMain.Passport
{
    public partial class FindPass : PageBase
    {
        USR_CustomerMod m_user = new USR_CustomerMod();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (ValidateCode() && ValidateEmail())
            {
                try
                {
                    //生成6位随机新密码,并MD5加密;
                    string[] arr = ("A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,2,3,4,5,6,7,8,9").Split(',');
                    string Password = "";
                    int randValue = -1;
                    Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
                    for (int i = 0; i < 6; i++)
                    {
                        randValue = rand.Next(0, arr.Length - 1);
                        Password += arr[randValue];
                    }
                    m_user.Password = Password;
                    USR_CustomerBll.GetInstance().UpDate(m_user);
                    //TCPMail oMail = new TCPMail();
                    //string url = "http://www.diafans.com/Login/LoginSuccess.aspx?opt=ValidateEmail&ID=" + this.txt_NickName.Text.Trim() + "&Email=" + this.txt_Email.Text.Trim();
                    string mailadd = m_user.Email;
                    string mailSubject = "上上签密码找回";

                    #region SetEmailContent
                    string mailBody = CommonTools.ReadHtmFile(AppConfig.AdvFolderPath + @"EmailTemplate/FindPassword.htm");
                    mailBody.Replace("@nickname", m_user.NickName);
                    mailBody.Replace("@password", m_user.Password);
                    //mailBody.Replace("@userid", m_user.SysNo.ToString());
                    //mailBody.Replace("@md5",CommonTools.md5(m_user.NickName+m_user.Password+DateTime.Now.ToString("yyyyMMddHHmmss"),32);
                    #endregion SetEmailContent

                    //邮件发送
                    TCPMail oMail = new TCPMail();
                    oMail.Html = true;
                    if (oMail.Send(mailadd,
                        mailSubject,
                        mailBody))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "emailsend", "alert('邮件已发送，请注意查收！');", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "emailsend", "alert('发送邮件失败，请联系管理员！');", true);
                    }


                }
                catch (Exception exp)
                {
                    LogManagement.getInstance().WriteException(exp, "FindPass", Request.UserHostAddress);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "emailsend", "alert('发送邮件失败，请联系管理员！');", true);
                }
            }
        }

        private bool ValidateCode()
        {
            if (code.Text.Trim().ToUpper() == CommonTools.Decode(CookiesHelper.GetCookie("CheckCode").Value).ToUpper())
            {
                return true;
            }
            else
            {
                ltrCode.Text = "验证码输入错误，请重新输入";
                code.Text = "";
                return false;
            }
        }

        private bool ValidateEmail()
        {
            m_user = USR_CustomerBll.GetInstance().CheckUser(email.Text.Trim());
            if (m_user.SysNo != AppConst.IntNull)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "emailwrong", "document.getElementById('ctl00_ContentPlaceHolder1_emailTip').innerHTML = '该邮箱已注册，请重新输入!';", true);
                return false;
            }
            return true;
        }
    }
}