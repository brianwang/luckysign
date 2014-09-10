using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForMain.ControlLibrary
{
    public partial class PayPannel : System.Web.UI.UserControl
    {
        private string _orderID;
        private int _orderType;
        private int _orderSysno;
        
        public string orderID
        {
            get
            {
                return _orderID;
            }
            set
            {
                _orderID = value;
            }
        }
        public int orderType
        {
            get
            {
                return _orderType;
            }
            set
            {
                _orderType = value;
            }
        }
        public int orderSysNo
        {
            get
            {
                return _orderSysno;
            }
            set
            {
                _orderSysno = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(AppCmn.AppConfig.HomeUrl() + "Order/PayResult.aspx?orderID=" + _orderID);
        }
        public void initial()
        { }
    }
}