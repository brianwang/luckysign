using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMod.User;
using AppBll.User;

namespace WebForMain.ControlLibrary
{
    public partial class QinRightPannel : System.Web.UI.UserControl
    {
        public USR_CustomerMod m_user = new USR_CustomerMod();
        public USR_GradeMod m_grade = new USR_GradeMod();
        public string ltr_me = "我";
        protected void Page_Load(object sender, EventArgs e)
        {
            PageBase m_base = new PageBase();
            if (m_user.SysNo != m_base.GetSession().CustomerEntity.SysNo)
            {
                ltr_me = "TA";
            }
            m_grade = USR_GradeBll.GetInstance().GetModel(m_user.GradeSysNo);
        }
    }
}