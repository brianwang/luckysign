using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMod.Order;
using AppBll.Order;
using AppCmn;
using AppMod.QA;
using AppBll.QA;
using System.Collections.Specialized;
using System.Collections.Generic;
using Com.Alipay;
using WebMonitor;

namespace WebForMain.Order
{
    public partial class PayReturnForAlipay : PageBase
    {
        private string orderID = "";
        private int ordertype = 0;
        private bool succ = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中页面跳转同步通知参数列表

                    //商户订单号

                    string out_trade_no = Request.QueryString["out_trade_no"];
                    orderID = out_trade_no;
                    //支付宝交易号

                    string trade_no = Request.QueryString["trade_no"];

                    //交易状态
                    string trade_status = Request.QueryString["trade_status"];


                    if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        succ = true;
                        if (out_trade_no.Contains("C"))
                        {
                            ordertype = 1;
                        }
                        else if (out_trade_no.Contains("P"))
                        {
                            ordertype = 2;
                        }
                        ORD_CashMod m_mod = ORD_CashBll.GetInstance().GetModelByOrderID(out_trade_no);
                        if (m_mod == null)
                        {
                            ShowError("");//订单号错误
                        }
                        if (m_mod.Status == (int)AppEnum.CashOrderStatus.beforepay)
                        {
                            m_mod.CurrentID = trade_no;//记录支付流水号
                            ORD_CashBll.GetInstance().SetPaySucc(m_mod);
                        }
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序
                    }
                    else
                    {
                        LogManagement.getInstance().WriteTrace("订单" + orderID + "支付宝返回"+Request.QueryString["trade_status"], "PayReturnForAlipay",base.Request.UserHostAddress );
                    }

                    //打印页面
                    ShowResult();

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    LogManagement.getInstance().WriteTrace("订单" + orderID + "支付宝返回验证失败", "PayReturnForAlipay", base.Request.UserHostAddress);
                }
            }
            else
            {
                LogManagement.getInstance().WriteTrace("支付宝返回无参数", "PayReturnForAlipay", base.Request.UserHostAddress);
                ShowError("请从正确的入口进入");
            }
        }

        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
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