using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.QA;
using AppCmn;

namespace WebForMain.Quest
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFreeCate();
                BindTalkCate();
                BindNewQuest();
                BindNewTalk();
            }
        }


        protected void BindFreeCate()
        {
            DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(1);
            m_dt.Columns.Add("NewCount");
            m_dt.Columns.Add("style");
            
            DataSet tmpds = QA_CategoryBll.GetInstance().GetCatesPostNum();
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                if (i % 3 == 2)
                {
                    m_dt.Rows[i]["style"] = "margin-right: 0";
                }
                m_dt.Rows[i]["NewCount"] = "0";
                for (int j = 0; j < tmpds.Tables[2].Rows.Count; j++)
                {
                    if (tmpds.Tables[2].Rows[j]["CateSysNo"].ToString() == m_dt.Rows[i]["SysNo"].ToString())
                    {
                        m_dt.Rows[i]["NewCount"] = int.Parse(tmpds.Tables[2].Rows[j]["questnum"].ToString());
                        break;
                    }
                }
                for (int j = 0; j < tmpds.Tables[3].Rows.Count; j++)
                {
                    if (tmpds.Tables[3].Rows[j]["CateSysNo"].ToString() == m_dt.Rows[i]["SysNo"].ToString())
                    {
                        m_dt.Rows[i]["NewCount"] = int.Parse(m_dt.Rows[i]["NewCount"].ToString()) + int.Parse(tmpds.Tables[3].Rows[j]["AnswerNum"].ToString()) + int.Parse(tmpds.Tables[3].Rows[j]["CommentNum"].ToString());
                        break;
                    }
                }
                
            }

            Repeater1.DataSource = m_dt;
            Repeater1.DataBind();
        }

        protected void BindTalkCate()
        {
            DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(2);
            m_dt.Columns.Add("NewCount");
            m_dt.Columns.Add("NewSysNo");
            m_dt.Columns.Add("NewTitle");
            m_dt.Columns.Add("NewContext");
            m_dt.Columns.Add("NewUser");
            m_dt.Columns.Add("NewTime");
            DataSet tmpds = QA_CategoryBll.GetInstance().GetCatesPostNum();
            DataTable tmpdt = QA_QuestionBll.GetInstance().GetTopListByCate(1);
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                m_dt.Rows[i]["NewCount"] = "0";
                for (int j = 0; j < tmpds.Tables[2].Rows.Count; j++)
                {
                    if (tmpds.Tables[2].Rows[j]["CateSysNo"].ToString() == m_dt.Rows[i]["SysNo"].ToString())
                    {
                        m_dt.Rows[i]["NewCount"] = int.Parse(tmpds.Tables[2].Rows[j]["questnum"].ToString());
                        break;
                    }
                }
                for (int j = 0; j < tmpds.Tables[3].Rows.Count; j++)
                {
                    if (tmpds.Tables[3].Rows[j]["CateSysNo"].ToString() == m_dt.Rows[i]["SysNo"].ToString())
                    {
                        m_dt.Rows[i]["NewCount"] = int.Parse(m_dt.Rows[i]["NewCount"].ToString()) + int.Parse(tmpds.Tables[3].Rows[j]["AnswerNum"].ToString()) + int.Parse(tmpds.Tables[3].Rows[j]["CommentNum"].ToString());
                        break;
                    }
                }
                for (int j = 0; j < tmpdt.Rows.Count; j++)
                {
                    if (tmpdt.Rows[j]["CateSysNo"].ToString() == m_dt.Rows[i]["SysNo"].ToString())
                    {
                        m_dt.Rows[i]["NewSysNo"] = tmpdt.Rows[j]["SysNo"];
                        m_dt.Rows[i]["NewTitle"] = tmpdt.Rows[j]["Title"];
                        m_dt.Rows[i]["NewContext"] = tmpdt.Rows[j]["Context"];
                        m_dt.Rows[i]["NewUser"] = tmpdt.Rows[j]["NickName"];
                        m_dt.Rows[i]["NewTime"] = tmpdt.Rows[j]["LastReplyTime"];

                    }
                }
                if (m_dt.Rows[i]["NewTime"].ToString() == "")
                {
                    m_dt.Rows[i]["NewTime"] = DateTime.Now;
                }
            }

            Repeater2.DataSource = m_dt;
            Repeater2.DataBind();
        }

        protected void BindNewQuest()
        {
            int total = 0;
            DataTable dt = new DataTable();
            if (HttpRuntime.Cache[AppConst.AllNewAnswer] == null)
            {
                dt = QA_QuestionBll.GetInstance().GetList(6, 1, "", 0, "replytimedown", ref total);
                dt.Columns.Add("Answer");
                dt.Columns.Add("AnswerUser");
                dt.Columns.Add("CateName");
                int tmptotal = 0;
                DataTable tmpdt = QA_CategoryBll.GetInstance().GetAllCates();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable tmpanswer = QA_AnswerBll.GetInstance().GetListByQuest(1, 1, int.Parse(dt.Rows[i]["SysNo"].ToString()), ref tmptotal);
                    dt.Rows[i]["Answer"] = tmpanswer.Rows[0]["Context"].ToString();
                    dt.Rows[i]["AnswerUser"] = tmpanswer.Rows[0]["NickName"].ToString();
                    for (int j = 0; j < tmpdt.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["CateSysNo"].ToString() == tmpdt.Rows[j]["SysNo"].ToString())
                        {
                            dt.Rows[i]["CateName"] = tmpdt.Rows[j]["Name"].ToString();
                            break;
                        }
                    }
                }
                HttpRuntime.Cache.Insert(AppConst.AllNewAnswer, dt,
                 null, DateTime.Now.AddMinutes(5), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt = HttpRuntime.Cache[AppConst.AllNewAnswer] as DataTable;
            Repeater3.DataSource = dt;
            Repeater3.DataBind();
        }

        protected void BindNewTalk()
        {
            DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(2);
            Repeater4.DataSource = m_dt;
            Repeater4.DataBind();
        }

        protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rptTopic = (Repeater)e.Item.FindControl("Repeater5");

            //找到分类Repeater关联的数据项 
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取分类ID 
            int CategoryId = Convert.ToInt32(rowv["SysNo"]);
            //根据分类ID查询该分类下的子分类，并绑定子分类Repeater  

            int total = 0;
            DataTable dt = new DataTable();
            if (HttpRuntime.Cache[AppConst.AllNewTalk + CategoryId] == null)
            {
                dt = QA_QuestionBll.GetInstance().GetList(5, 1, "", CategoryId, "timedown", ref total);
                dt.Columns.Add("CateName");
                DataTable tmpdt = QA_CategoryBll.GetInstance().GetAllCates();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < tmpdt.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["CateSysNo"].ToString() == tmpdt.Rows[j]["SysNo"].ToString())
                        {
                            dt.Rows[i]["CateName"] = tmpdt.Rows[j]["Name"].ToString();
                            break;
                        }
                    }
                }
                HttpRuntime.Cache.Insert(AppConst.AllNewTalk + CategoryId, dt,
                 null, DateTime.Now.AddMinutes(5), TimeSpan.Zero,
                 System.Web.Caching.CacheItemPriority.High, null);
            }
            dt = HttpRuntime.Cache[AppConst.AllNewTalk + CategoryId] as DataTable;
            rptTopic.DataSource = dt;
            rptTopic.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}