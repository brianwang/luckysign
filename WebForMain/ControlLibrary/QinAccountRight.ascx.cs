using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForMain.ControlLibrary
{
    public partial class QinAccountRight : System.Web.UI.UserControl
    {
        public int tab = 0;
        public string[] on = { "current", "", "", "", "" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetTab(tab);
            }
        }

        public void SetTab(int input)
        {
            for (int i = 0; i < on.Length; i++)
            {
                if (i == input)
                {
                    on[i] = "current";
                }
                else
                {
                    on[i] = "";
                }
            }
        }
    }
}