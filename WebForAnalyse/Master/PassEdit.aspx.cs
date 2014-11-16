using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.WebSys;
using AppMod.WebSys;

namespace WebForAnalyse.Master
{
    public partial class PassEdit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                SYS_AdminMod m_admin = SYS_AdminBll.GetInstance().GetModel(GetSession().AdminEntity.SysNo);
                if (txtOldPsd.Text.Trim() == m_admin.Password)
                {
                    if (txtNewPsd.Text.Trim() == txtNewAgain.Text.Trim())
                    {
                        m_admin.Password = txtNewPsd.Text.Trim();
                        SYS_AdminBll.GetInstance().Update(m_admin);

                        ltrNotice.Text = "密码修改成功！";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('masternoticediv').style.display='';document.getElementById('masternoticediv').style.display;", true);
                    }
                    else
                    {
                        ltrError.Text = "两次密码输入不一致，请重新输入！";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('mastererrordiv').style.display='';jQuery.facebox('PassWord');", true);
                    }
                }
                else
                {
                    ltrError.Text = "旧密码错误，请重新输入！";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('mastererrordiv').style.display='';jQuery.facebox('PassWord');", true);
                }
            }
            catch
            {
                ltrError.Text = "系统错误，密码修改失败！";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('mastererrordiv').style.display='';jQuery.facebox('PassWord');", true);
            }
        }
    }
}