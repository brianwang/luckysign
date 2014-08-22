using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMod.Order;
using AppBll.Order;

namespace WebForMain.Order
{
    public partial class PayResult : PageBase
    {
        private int ordersysno = 0;
        private int ordertype = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Login(Request.Url.ToString());
            if (Request.QueryString["order"] != null)
            {
                try
                {
                    ordersysno = int.Parse(Request.QueryString["order"]);
                }
                catch
                {
                    ShowError("");
                }
            }
            if (Request.QueryString["type"] != null)
            {
                try
                {
                    ordertype = int.Parse(Request.QueryString["type"]);
                }
                catch
                {
                    ShowError("");
                }
            }

            if (ordersysno == 0 || ordertype == 0)
            {
                SetPay();
            }

            ShowResult();

        }

        protected void SetPay()
        { }

        protected void ShowResult()
        {
            if (ordertype == 1)
            {
                Literal1.Text = "您的订单已";
            }
            else if (ordertype == 2)
            { }
            else
            {
                ShowError("");
            }
        }
    }
}