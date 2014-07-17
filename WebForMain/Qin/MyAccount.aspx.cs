using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.Order;
using AppCmn;

namespace WebForMain.Qin
{
    public partial class MyAccount : PageBase
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
                    m_dt = ORD_PointBll.GetInstance().GetList(pagesize, pageindex, GetSession().CustomerEntity.SysNo, AppConst.IntNull, AppConst.IntNull, AppConst.IntNull, "", ref total);
                    m_dt.Columns.Add("content");
                    for (int i = 0; i < m_dt.Rows.Count; i++)
                    {
                        m_dt.Rows[i]["content"] = AppEnum.GetPointOrderType(int.Parse(m_dt.Rows[i]["type"].ToString()));
                        if (m_dt.Rows[i]["type"].ToString()== ((int)AppEnum.PointOrderType.appconsume).ToString())
                        {
                            m_dt.Rows[i]["content"] += "-"+ AppEnum.GetApps(int.Parse(m_dt.Rows[i]["productsysno"].ToString()));
                        }
                        else if(m_dt.Rows[i]["type"].ToString()== ((int)AppEnum.PointOrderType.questaward).ToString())
                        {
                            m_dt.Rows[i]["content"] = "<a href='" + AppConfig.HomeUrl() + "Quest/Question/" + m_dt.Rows[i]["productsysno"].ToString() + "' target='_blank'>" + m_dt.Rows[i]["content"] + "</a>";
                        }
                    }
                    Repeater1.DataSource = m_dt;
                    Repeater1.DataBind();
                    break;
                case 1:
                    m_dt = QA_QuestionBll.GetInstance().GetListByUserAnswer(pagesize, pageindex, GetSession().CustomerEntity.SysNo, "", 0, false, "timedown", ref total);
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