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
    public partial class Register : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (chkAgree.Checked)
            {
                LinkButton1.CssClass = "btn_01";
            }
            LinkButton1.Focus();
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            #region 验证输入
            if (!ValidateCode())
            {
                code.Text = "";
                return;
            }
            if (!ValidateEmail())
            {
                code.Text = "";
                return;
            }
            if (!ValidatePass())
            {
                code.Text = "";
                return;
            }
            if (!ValidateNickName())
            {
                code.Text = "";
                return;
            }

            #endregion

            #region 保存数据
            USR_CustomerMod m_user = new USR_CustomerMod();
            try
            {
                m_user.Email = email.Text.Trim();
                m_user.FateType = int.Parse(drpType.SelectedValue);
                m_user.GradeSysNo = AppConst.OriginalGrade; ;
                m_user.NickName = name.Text.Trim();
                m_user.Password = password1.Text.Trim();
                m_user.RegTime = DateTime.Now;
                m_user.Point = AppConst.OriginalPoint;
                m_user.Photo = AppConst.OriginalPhoto;
                m_user.LastLoginTime = DateTime.Now;
                if (AppConfig.RegisterEmailCheck.ToLower() == "true")
                {
                    m_user.Status = (int)AppEnum.State.prepare;
                }
                else
                {  
                    m_user.Status = (int)AppEnum.State.normal;
                }
               
                m_user.Credit = 0;
                m_user.birth = AppConst.DateTimeNull;
                m_user.IsShowBirth = 1;
                m_user.IsStar = 0;
                m_user.BestAnswer = 0;
                m_user.TotalAnswer = 0;
                m_user.TotalQuest= 0;
                m_user.HomeTown = AppConst.IntNull;
                m_user.Intro = AppConst.OriginalIntro;
                m_user.Signature = AppConst.OriginalSign;
                m_user.Exp = 0;
                m_user.TotalReply = 0;
                m_user.HasNewInfo = 0;


                m_user.SysNo = USR_CustomerBll.GetInstance().Add(m_user);
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "WebForMain.Register", Request.UserHostAddress);
                return;
            }
            #endregion

            #region 发送验证邮件
            if (AppConfig.RegisterEmailCheck.ToLower() == "true")
            {
 
            }
            #endregion

            #region 登陆状态设置
            if (!(AppConfig.RegisterEmailCheck.ToLower() == "true"))
            {
                SessionInfo m_session = new SessionInfo();
                m_session.CustomerEntity = m_user;
                m_session.GradeEntity = USR_GradeBll.GetInstance().GetModel(m_user.SysNo);
                Session[AppConfig.CustomerSession] = m_session;
            }
            #endregion
            if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
            {
                Response.Redirect("RegisterSucc.aspx?url=" + Request.QueryString["url"]);
            }
            else
            {
                Response.Redirect("RegisterSucc.aspx");
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
            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(email.Text.Trim());
            if (m_user.SysNo != AppConst.IntNull)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "emailwrong", "document.getElementById('ctl00_ContentPlaceHolder1_emailTip').innerHTML = '该邮箱已注册，请重新输入!';document.getElementById('ctl00_ContentPlaceHolder1_emailTip').style['display']='block';document.getElementById('ctl00_ContentPlaceHolder1_emailTip').className='onError';", true);
                return false;
            }
            return true;
        }
        private bool ValidatePass()
        {
            if (CommonTools.CheckPasswordLevel(password1.Text.Trim()) == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "passwrong", "document.getElementById('ctl00_ContentPlaceHolder1_password1Tip').innerHTML = '您的密码实在太过简单，请重新输入!';document.getElementById('ctl00_ContentPlaceHolder1_password1Tip').style['display']='block';document.getElementById('ctl00_ContentPlaceHolder1_password1Tip').className='onError';", true);
                return false;
            }
            
            return true;
        }
        private bool ValidateNickName()
        {
            if (CommonTools.HasForbiddenWords(name.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "namewrong", "document.getElementById('ctl00_ContentPlaceHolder1_nameTip').innerHTML = '您的昵称中有违禁字符,请重新输入!';document.getElementById('ctl00_ContentPlaceHolder1_nameTip').style['display']='block';document.getElementById('ctl00_ContentPlaceHolder1_nameTip').className='onError';", true);
                return false;
            }

            return true;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null && Request.QueryString["url"] != "")
            {
                Response.Redirect("Login.aspx?url=" + Request.QueryString["url"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}