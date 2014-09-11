﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.Order;
using AppMod.Order;
using AppBll.QA;
using AppMod.QA;
using Com.Alipay;

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

        protected void BtnAlipay_Click(ORD_CashMod m_order)
        {
            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //支付类型
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url = "http://www.xxx.com/create_direct_pay_by_user-CSHARP-UTF-8/notify_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = "http://www.xxx.com/create_direct_pay_by_user-CSHARP-UTF-8/return_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

            //卖家支付宝帐户
            string seller_email = AppCmn.AppConfig.AlipayAccount;
            //必填

            //商户订单号
            string out_trade_no = m_order.OrderID;
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = "咨询服务费";
            //必填

            //付款金额
            string total_fee = m_order.PayAmount.ToString("0.00");
            //必填

            //订单描述

            string body = "";
            //商品展示地址
            string show_url = AppCmn.AppConfig.HomeUrl();
            //需以http://开头的完整路径，例如：http://www.xxx.com/myorder.html

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //若要使用请调用类文件submit中的query_timestamp函数

            //客户端的IP地址
            string exter_invoke_ip = Request.UserHostAddress;
            //非局域网的外网IP地址，如：221.0.0.1


            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("seller_email", seller_email);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            Response.Write(sHtmlText);

        }
    }
}