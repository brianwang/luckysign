using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.QA;
using AppCmn;

namespace WebForMain.Qin
{
    public partial class MyQuestion : PageBase
    {
        private int type;
        private int pageindex = 1;
        private int pagesize = 12;
        public string[] on = { "now",""};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Login(Request.Url.ToString());
                WebForMain.Master.Qin m_master = (WebForMain.Master.Qin)Master;
                m_master.SetTab(2);
                if (Request.QueryString["type"] != null)
                {
                    try
                    {
                        type = int.Parse(Request.QueryString["type"]);
                    }
                    catch
                    {
                        type = 0;
                    }
                }
                else
                {
                    type = 0;
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
                SetTab(type);
                BindList();
                BindStar();
                BindNew();
                RightPannel1.m_user = GetSession().CustomerEntity;
            }
        }

        protected void BindList()
        {
            DataTable m_dt = new DataTable();
            int total = 0;
            switch (type)
            {
                case 0:
                    m_dt = QA_QuestionBll.GetInstance().GetListByUserAsk(pagesize, pageindex, GetSession().CustomerEntity.SysNo, "", 0, "timedown", ref total);
                    break;
                case 1:
                    m_dt = QA_QuestionBll.GetInstance().GetListByUserAnswer(pagesize, pageindex, GetSession().CustomerEntity.SysNo, "", 0,false, "timedown", ref total);
                    break;
            }
            ComboShow1.DataList = m_dt;
            ComboShow1.Type = WebForMain.ControlLibrary.ComboShow.ComboShowType.Quest;

            Pager1.url = "MyQuestion.aspx?type=" + type + "&pn=";
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

        protected void BindStar()
        {
            int fatetype =  GetSession().CustomerEntity.FateType;
            DataTable m_dt = new DataTable();
            if(fatetype==0 || fatetype==AppCmn.AppConst.IntNull)
            {
                m_dt = QA_StarBll.GetInstance().GetStarsList(5, 0);
            }
            else
            {
                m_dt = QA_StarBll.GetInstance().GetStarsList(5, GetSession().CustomerEntity.FateType);
            }
            rptHotUser.DataSource = m_dt;
            rptHotUser.DataBind();
        }

        protected void BindNew()
        {
            int total = 0;
            DataTable m_dt = QA_QuestionBll.GetInstance().GetList(5, 1, "", 0, "timedown", ref total);
            m_dt.Columns.Add("LeftTime");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                if (m_dt.Rows[i]["EndTime"] == null || m_dt.Rows[i]["EndTime"].ToString() == "")
                {
                    m_dt.Rows[i]["LeftTime"] = "未解决";
                }
                else
                {
                    m_dt.Rows[i]["LeftTime"] = "已解决";
                }
                //TimeSpan tmp = DateTime.Parse(m_dt.Rows[i]["EndTime"].ToString()) - DateTime.Now;
                //if (Math.Floor(tmp.TotalDays) > 0)
                //{
                //    m_dt.Rows[i]["LeftTime"] = "剩余时间：" + Math.Floor(tmp.TotalDays).ToString("0") + "天";
                //}
                //else if (Math.Floor(tmp.TotalHours) > 0)
                //{
                //    m_dt.Rows[i]["LeftTime"] = "剩余时间：" + Math.Floor(tmp.TotalHours).ToString("0") + "小时";
                //}
                //else if (Math.Floor(tmp.TotalMinutes) > 0)
                //{
                //    m_dt.Rows[i]["LeftTime"] = "剩余时间：" + Math.Floor(tmp.TotalMinutes).ToString("0") + "分钟";
                //}
                //else if (Math.Floor(tmp.TotalSeconds) > 0)
                //{
                //    m_dt.Rows[i]["LeftTime"] = "剩余时间：小于1分钟";
                //}
                //else
                //{
                //    m_dt.Rows[i]["LeftTime"] = "已结束";
                //}
            }
            rptNewQuest.DataSource = m_dt;
            rptNewQuest.DataBind();
        }

        public string GetEnglishNum(int input)
        {
            switch (input)
            {
                case 1:
                    return "first";
                    //break;
                case 2:
                    return "second";
                    //break;
                case 3:
                    return "third";
                    //break;
                case 4:
                    return "four";
                    //break;
                case 5:
                    return "five";
                    //break;
                default:
                    return "";
                    //break;
            }
        }

        protected void SetTab(int input)
        {
            for(int i=0;i<on.Length;i++)
            {
                if (i == input)
                {
                    on[i] = "now";
                }
                else
                {
                    on[i] = "";
                }
            }
        }
    }
}