using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.Order;
using AppMod.Order;
using AppBll.QA;
using AppCmn;

namespace WebForMain.Qin
{
    public partial class MyComplain : PageBase
    {
        private int tab;
        private int sysno = 0;
        private int pageindex = 1;
        private int pagesize = AppConst.PageSize;
        public string[] on = { "now",""};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Login(Request.Url.ToString());
                WebForMain.Master.Qin m_master = (WebForMain.Master.Qin)Master;
                m_master.SetTab(3);
                if (Request.QueryString["tab"] != null)
                {
                    try
                    {
                        tab = int.Parse(Request.QueryString["tab"]);
                    }
                    catch
                    {
                        tab = 0;
                    }
                }
                else
                {
                    tab = 0;
                }

                if (Request.QueryString["pn"] != null)
                {
                    try
                    {
                        pageindex = int.Parse(Request.QueryString["pn"]);
                    }
                    catch
                    { }
                }
                if (Request.QueryString["order"] != null)
                {
                    try
                    {
                        sysno = int.Parse(Request.QueryString["order"]);
                    }
                    catch
                    { }
                }
                if (tab == 0 && sysno == 0)
                {
                    ShowError("");
                }
                RightPannel1.SetTab(tab);
                BindList();
                MultiView1.ActiveViewIndex = tab;
            }
        }

        protected void BindList()
        {
            DataTable m_dt = new DataTable();
            int total = 0;
            switch (tab)
            {
                case 0:
                    DropDownList1.DataSource = AppEnum.GetCashReturnReason();
                    DropDownList1.DataTextField = "value";
                    DropDownList1.DataValueField = "key";
                    DropDownList1.DataBind();
                    break;
                case 1:
                    m_dt = ORD_ReturnCashBll.GetInstance().GetList(pagesize, pageindex, GetSession().CustomerEntity.SysNo, AppConst.IntNull, AppConst.IntNull, AppConst.IntNull, "", ref total);
                    m_dt.Columns.Add("content");
                    m_dt.Columns.Add("target");
                    for (int i = 0; i < m_dt.Rows.Count; i++)
                    {
                        if ((m_dt.Rows[i]["producttype"].ToString() == ((int)AppEnum.CashOrderType.consultget).ToString() || m_dt.Rows[i]["producttype"].ToString() == ((int)AppEnum.CashOrderType.consultpay).ToString())
                            && m_dt.Rows[i]["productsysno"] != null && m_dt.Rows[i]["productsysno"].ToString() != "")
                        {
                            try
                            {
                                DataTable tmp_dt = QA_OrderBll.GetInstance().GetOrderDetail(int.Parse(m_dt.Rows[i]["productsysno"].ToString()));
                                if (tmp_dt.Rows.Count > 0)
                                {
                                    m_dt.Rows[i]["content"] = AppEnum.GetCashOrderType(int.Parse(m_dt.Rows[i]["producttype"].ToString()));
                                    if (m_dt.Rows[i]["producttype"].ToString() == ((int)AppEnum.CashOrderType.consultget).ToString())
                                        m_dt.Rows[i]["target"] = tmp_dt.Rows[0]["questuname"].ToString();
                                    else if (m_dt.Rows[i]["producttype"].ToString() == ((int)AppEnum.CashOrderType.consultpay).ToString())
                                        m_dt.Rows[i]["target"] = tmp_dt.Rows[0]["orderuname"].ToString();
                                }
                            }
                            catch { }
                        }
                    }
                    Repeater2.DataSource = m_dt;
                    Repeater2.DataBind();
                    break;
            }

            Pager1.url = "MyAccount.aspx?tab=" + tab + "&pn=";
            Pager1.totalrecord = total;
            if (total % AppConst.PageSize == 0)
            {
                this.Pager1.total = total / pagesize;
            }
            else
            {
                this.Pager1.total = total / pagesize + 1;
            }
            this.Pager1.index = pageindex;
            this.Pager1.numlenth = 3;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int amount = 0;
            #region 判断输入项
            if (DropDownList1.SelectedIndex == 0)
            {
                ReasonTip.InnerHtml = "请选择原因";
                ReasonTip.Attributes["class"] = "err";
                return;
            }
            if (TextBox1.Text != "")
            {
                try
                {
                    amount = int.Parse(TextBox1.Text);
                }
                catch
                {
                    AmountTip.InnerHtml = "请输入整数";
                    AmountTip.Attributes["class"] = "err";
                }
                return;
            }

            #endregion

            try
            {
                ORD_ReturnCashMod m_return = new ORD_ReturnCashMod();
                m_return.Amount = amount;
                m_return.Detail = txtContext.Text;
                m_return.OrderSysNo = sysno;
                m_return.ReasonType = int.Parse(DropDownList1.SelectedValue);
                m_return.Status = (int)AppEnum.CashReturnStatus.confirming;
                m_return.TS = DateTime.Now;
                m_return.ReturnID = "R" + m_return.ReasonType.ToString("00") + m_return.TS.ToString("yyyyMMdd") + m_return.OrderSysNo + CommonTools.ThrowRandom(0, 99999).ToString("00000");
                ORD_ReturnCashBll.GetInstance().Add(m_return);
                tab = 1;
                MultiView1.ActiveViewIndex = tab;
                BindList();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "returnok", "alert('退款申请提交成功，占卜师会在" + AppConst.ReturnConfirmTime + "小时内做出答复')", true);
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "returnfail", "alert('系统故障，提交失败')", true);
            }
        }

        
    }
}