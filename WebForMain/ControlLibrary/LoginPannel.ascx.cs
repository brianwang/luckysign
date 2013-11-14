using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMod.User;
using AppBll.User;
using AppCmn;

namespace WebForMain.ControlLibrary
{
    public partial class LoginPannel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            #region 判定登录信息
            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(TextBox1.Text.Trim(), TextBox2.Text.Trim());
            if (m_user.SysNo != AppConst.IntNull)
            {
                PageBase m_base = new PageBase();
                m_base.SetSession(m_user);
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Literal1.Text = "账号或密码错误，请重新输入！";
                ModalPopupExtender2.Show();
            }
            #endregion
        }
        public void ShowLogin()
        {
            ModalPopupExtender2.Show();
        }
    }
}