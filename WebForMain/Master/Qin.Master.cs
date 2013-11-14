using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;

namespace WebForMain.Master
{
    public partial class Qin : System.Web.UI.MasterPage
    {
        private string[] _tab = { "now", "", "", "", "" };
        public string[] tab
        {
            get { return _tab; }
        }

        public PageBase m_base = new PageBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void HideManu()
        {
            manudiv.Style.Add("display", "none");
        }

        public void SetTab(int input)
        {
            for (int i = 0; i < _tab.Length; i++)
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}