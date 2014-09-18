using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.Order;
using AppBll.QA;
using AppCmn;

namespace WebForMain.Qin
{
    public partial class MyComplain : PageBase
    {
        private int tab;
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
                    ltrPoint.Text = GetSession().CustomerEntity.Point.ToString();

                    m_dt = ORD_PointBll.GetInstance().GetList(pagesize, pageindex, GetSession().CustomerEntity.SysNo, AppConst.IntNull, AppConst.IntNull, AppConst.IntNull, "", ref total);
                    m_dt.Columns.Add("content");
                    for (int i = 0; i < m_dt.Rows.Count; i++)
                    {
                        m_dt.Rows[i]["content"] = AppEnum.GetPointOrderType(int.Parse(m_dt.Rows[i]["type"].ToString()));
                        if (m_dt.Rows[i]["type"].ToString() == ((int)AppEnum.PointOrderType.appconsume).ToString())
                        {
                            m_dt.Rows[i]["content"] += "应用-" + AppEnum.GetApps(int.Parse(m_dt.Rows[i]["productsysno"].ToString()));
                        }
                        else if (m_dt.Rows[i]["type"].ToString() == ((int)AppEnum.PointOrderType.questaward).ToString())
                        {
                            m_dt.Rows[i]["content"] = "悬赏-" + "<a href='" + AppConfig.HomeUrl() + "Quest/Question/" + m_dt.Rows[i]["productsysno"].ToString() + "' target='_blank'>" + CommonTools.CutStr(m_dt.Rows[i]["content"].ToString(), 10) + "</a>";
                        }
                    }
                    Repeater1.DataSource = m_dt;
                    Repeater1.DataBind();
                    break;
                case 1:
                    ltrCash.Text = GetSession().CustomerEntity.Credit.ToString();

                    m_dt = ORD_CashBll.GetInstance().GetList(pagesize, pageindex, GetSession().CustomerEntity.SysNo, AppConst.IntNull, AppConst.IntNull, AppConst.IntNull, "", ref total);
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

        
    }
}