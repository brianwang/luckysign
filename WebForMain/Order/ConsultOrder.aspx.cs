using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.Order;
using AppMod.Order;

namespace WebForMain.Order
{
    public partial class ConsultOrder : PageBase
    {
        public string orderid = "";
        public string price = "";
        private int ordersysno = 0;
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
            else
            {
                ShowError("");
            }
            ORD_CashMod m_order = ORD_CashBll.GetInstance().GetModel(ordersysno);
            if (m_order.CustomerSysNo != GetSession().CustomerEntity.SysNo)
            {
                ShowError("");//非当前用户的订单
            }
            orderid = m_order.OrderID;
            price = m_order.PayAmount.ToString("￥0.00");

            PayPannel1.orderSysNo = ordersysno;
            PayPannel1.orderID = orderid;
            PayPannel1.orderType = 1;
            PayPannel1.initial();
        }
    }
}