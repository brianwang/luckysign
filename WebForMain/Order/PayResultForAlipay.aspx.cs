using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMod.Order;
using AppBll.Order;
using AppCmn;

namespace WebForMain.Order
{
    public partial class PayResultForAlipay : PageBase
    {
        private string orderID = "";
        private int ordertype = 0;
        private bool succ = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Login(Request.Url.ToString());
            if (Request.QueryString["orderID"] != null)
            {
                try
                {
                    orderID = Request.QueryString["orderID"];
                }
                catch
                {
                    ShowError("");
                }
            }
            //if (Request.QueryString["type"] != null)
            //{
            //    try
            //    {
            //        ordertype = int.Parse(Request.QueryString["type"]);
            //    }
            //    catch
            //    {
            //        ShowError("");
            //    }
            //}

            if (orderID == "")
            {
                ShowError("");
            }
            else if (orderID.Contains("C"))
            {
                ordertype = 1;
            }
            else if (orderID.Contains("P"))
            {
                ordertype = 2;
            }
            else
            {
                ShowError("");
            }
            SetPay();
            ShowResult();

        }

        protected void SetPay()
        {
            
            #region 验证支付接口返回信息
            succ = true;
            #endregion
            if (succ)
            {
                ORD_CashMod m_mod = ORD_CashBll.GetInstance().GetModelByOrderID(orderID);
                if (m_mod == null)
                {
                    ShowError("");//订单号错误
                }
                m_mod.CurrentID = "";//记录支付流水号
                ORD_CashBll.GetInstance().SetPaySucc(m_mod);
            }
        }

        protected void ShowResult()
        {
            if (ordertype == 1)
            {
                if (succ)
                {
                    Literal1.Text = "您的订单已支付成功";
                }
                else
                {
                    Literal1.Text = "您的订单支付失败，请联系客服";
                }
            }
            else if (ordertype == 2)
            {
                if (succ)
                {
                    Literal1.Text = "您的订单已支付成功";
                }
                else
                {
                    Literal1.Text = "您的订单支付失败，请联系客服";
                }
            }
            else
            {
                ShowError("");
            }
        }
    }
}