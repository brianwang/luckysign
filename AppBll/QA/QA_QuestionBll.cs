using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
using AppMod.Fate;
using System.Text;
using System.Transactions;
using System.Web;
using AppBll.Fate;

namespace AppBll.QA
{
    public class QA_QuestionBll
    {
        private readonly QA_QuestionDal dal = new QA_QuestionDal();
        private QA_QuestionBll()
        {
        }
        private static QA_QuestionBll _instance;
        public static QA_QuestionBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QA_QuestionBll();
            }
            return _instance;
        }
        #region  基本成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(QA_QuestionMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(QA_QuestionMod model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public void Delete(int SysNo)
        {
            dal.Delete(SysNo);
        }
        /// <summary>
        ///  得到一个对象实体
        /// </summary>

        public QA_QuestionMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基本成员方法

        #region 扩展成员方法
        public DataTable GetList(int pagesize, int pageindex, string key,int cate, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"QA_Question.[SysNo]
                      ,[CateSysNo]
                      ,[CustomerSysNo]
                      ,[Title]
                      ,[Context]
                      ,[Award]
                      ,[EndTime]
                      ,[IsSecret]
                      ,[LastReplyTime]
                      ,[LastReplyUser]
                      ,[ReplyCount]
                      ,[ReadCount]
                      ,QA_Question.[DR]
                      ,QA_Question.[TS]
                      ,a.NickName
                      ,a.Photo
                      ,b.NickName as ReplyNickName
                      ,b.Photo as ReplyPhoto";
            tables = "QA_Question left join USR_Customer a on CustomerSysNo=a.SysNo left join USR_Customer b on LastReplyUser=b.SysNo";
            where = "dr=" + (int)AppEnum.State.normal;
            if (!string.IsNullOrEmpty(key))
            {
                where += " and (";
                string[] tmpstr = key.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " QA_Question.[Title] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' and ";
                }
                where += " 1=1)";
            }
            if (cate != 0)
            {
                where += " and CateSysNo in (select sysno from QA_Category where TopSysNo=" + cate+" or sysno="+ cate+")";
            }
            if (orderby == "timedown")
            {
                order = "QA_Question.LastReplyTime desc";
            }
            else if (orderby == "timeup")
            {
                order = "QA_Question.LastReplyTime asc";
            }
            else if (orderby == "replydown")
            {
                order = "ReplyCount desc";
            }
            else if (orderby == "replyup")
            {
                order = "ReplyCount asc";
            }
            else if (orderby == "replytimedown")
            {
                order = "LastReplyTime desc";
                where += " and ReplyCount>0";
            }
            else if (orderby == "replytimeup")
            {
                order = "LastReplyTime asc";
                where += " and ReplyCount>0";
            }
            else if (orderby == "pointdown")
            {
                order = "Award desc";
            }
            else if (orderby == "pointup")
            {
                order = "Award asc";
            }
            else
            {
                order = "QA_Question.LastReplyTime desc";
            }
            
            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", pageindex);
                m_data.AddParameter("pagesize", pagesize);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                    total = int.Parse(m_ds.Tables[1].Rows[0][0].ToString());
                }
            }
            return m_dt;
        }

        public DataTable GetListForAdmin(int pagesize, int pageindex, string key, int cate,int user,int reply,int award,int status, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"QA_Question.[SysNo]
                      ,[CateSysNo]
                      ,[CustomerSysNo]
                      ,[Title]
                      ,[Context]
                      ,[Award]
                      ,[EndTime]
                      ,[IsSecret]
                      ,[LastReplyTime]
                      ,[ReplyCount]
                      ,QA_Question.[DR]
                      ,QA_Question.[TS]
                      ,Name
                      ,NickName";
            tables = "QA_Question left join USR_Customer on CustomerSysNo=USR_Customer.SysNo left join QA_Category on CateSysNo=QA_Category.sysno";
            where = "1=1";
            if (key != "")
            {
                where += " and (";
                string[] tmpstr = key.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " QA_Question.[Title] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' and ";
                }
                where += " 1=1)";
            }
            if (cate != 0)
            {
                where += " and CateSysNo=" + cate;
            }
            if (user != 0)
            {
                where += " and CustomerSysNo=" + user;
            }
            if (award != 0)
            {
                where += " and Award>=" + award;
            }
            if (reply != 0)
            {
                where += " and ReplyCount>=" + reply;
            }
            if (status != 100)
            {
                where += " and QA_Question.DR=" + status;
            }
            if (orderby == "timedown")
            {
                order = "QA_Question.TS desc";
            }
            else if (orderby == "timeup")
            {
                order = "QA_Question.TS asc";
            }
            else if (orderby == "replydown")
            {
                order = "ReplyCount desc";
            }
            else if (orderby == "replyup")
            {
                order = "ReplyCount asc";
            }
            else if (orderby == "pointdown")
            {
                order = "Award desc";
            }
            else if (orderby == "pointup")
            {
                order = "Award asc";
            }

            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", pageindex);
                m_data.AddParameter("pagesize", pagesize);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                    total = int.Parse(m_ds.Tables[1].Rows[0][0].ToString());
                }
            }
            return m_dt;
        }

        public DataTable GetListByUserAsk(int pagesize, int pageindex,int usersysno, string key, int cate, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"QA_Question.[SysNo]
                      ,[CateSysNo]
                      ,[CustomerSysNo]
                      ,[Title]
                      ,[Context]
                      ,[Award]
                      ,[EndTime]
                      ,[IsSecret]
                      ,[LastReplyTime]
                      ,[ReplyCount]
                      ,QA_Question.[DR]
                      ,QA_Question.[TS]
                      ,Photo
                      ,NickName";
            tables = "QA_Question left join USR_Customer on CustomerSysNo=USR_Customer.SysNo";
            where = "dr=" + (int)AppEnum.State.normal + " and CustomerSysNo="+usersysno;
            if (key != "")
            {
                where += " and (";
                string[] tmpstr = key.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " QA_Question.[Title] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' and ";
                }
                where += " 1=1)";
            }
            if (cate != 0)
            {
                where += " and CateSysNo=" + cate;
            }
            if (orderby == "timedown")
            {
                order = "QA_Question.TS desc";
            }
            else if (orderby == "timeup")
            {
                order = "QA_Question.TS asc";
            }
            else if (orderby == "replydown")
            {
                order = "ReplyCount desc";
            }
            else if (orderby == "replyup")
            {
                order = "ReplyCount asc";
            }
            else if (orderby == "pointdown")
            {
                order = "Award desc";
            }
            else if (orderby == "pointup")
            {
                order = "Award asc";
            }

            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", pageindex);
                m_data.AddParameter("pagesize", pagesize);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                    total = int.Parse(m_ds.Tables[1].Rows[0][0].ToString());
                }
            }
            return m_dt;
        }

        public DataTable GetListByUserAnswer(int pagesize, int pageindex, int usersysno, string key, int cate,bool best, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"QA_Question.[SysNo]
                      ,[CateSysNo]
                      ,[CustomerSysNo]
                      ,[Title]
                      ,[Context]
                      ,[Award]
                      ,[EndTime]
                      ,[IsSecret]
                      ,[LastReplyTime]
                      ,[ReplyCount]
                      ,QA_Question.[DR]
                      ,QA_Question.[TS]
                      ,Photo
                      ,NickName";
            tables = " (select QuestionSysNo,TS from QA_Answer where CustomerSysNo=" + usersysno + ") as T left join QA_Question on T.QuestionSysNo = QA_Question.SysNo left join USR_Customer on CustomerSysNo=USR_Customer.SysNo";
            where = "dr=" + (int)AppEnum.State.normal;
            if (key != "")
            {
                where += " and (";
                string[] tmpstr = key.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " QA_Question.[Title] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' and ";
                }
                where += " 1=1)";
            }
            if (best)
            {
                where += " and Award>0";
            }
            if (cate != 0)
            {
                where += " and CateSysNo=" + cate;
            }
            if (orderby == "timedown")
            {
                order = "T.TS desc";
            }
            else if (orderby == "timeup")
            {
                order = "T.TS asc";
            }
            else if (orderby == "replydown")
            {
                order = "ReplyCount desc";
            }
            else if (orderby == "replyup")
            {
                order = "ReplyCount asc";
            }
            else if (orderby == "pointdown")
            {
                order = "Award desc";
            }
            else if (orderby == "pointup")
            {
                order = "Award asc";
            }

            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", pageindex);
                m_data.AddParameter("pagesize", pagesize);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                    total = int.Parse(m_ds.Tables[1].Rows[0][0].ToString());
                }
            }
            return m_dt;
        }

        public DataTable GetStarsList(int customersysno,int count)
        {
            string cachyname = "QAStarsQuest";
            if (HttpRuntime.Cache[cachyname + customersysno.ToString() + "-" + count.ToString()] == null)
            {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"SELECT top " + count + @" Title
                                        , Award
                                        , EndTime
                                        , ReplyCount
                                        , Context
                                  FROM [QA_Question] where sysno in (select QuestionSysNo from QA_Answer where CustomerSysNo and Award>0 amd dr=").Append((int)AppEnum.State.normal).Append(") as T and IsSecret=0 and dr=").Append((int)AppEnum.State.normal);
                    builder.Append(" order by [OrderID] desc;");
                    try
                    {
                        tables = data.CmdtoDataTable(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname + customersysno.ToString() + "-" + count.ToString(), tables, null, DateTime.Now.AddHours(2), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            return (HttpRuntime.Cache[cachyname + customersysno.ToString() + "-" + count.ToString()] as DataTable).Copy();
        }

        public FATE_ChartMod GetChartByQuest(int SysNo)
        {
            int fatesysno = 0;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select Chart_SysNo from REL_Question_Chart where Question_SysNo=").Append(SysNo);
                try
                {
                    fatesysno = Convert.ToInt32(data.CmdtoDataTable(builder.ToString()).Rows[0]["Chart_SysNo"]);
                }
                catch (Exception exception)
                {
                    return null;
                }
            }
            return FATE_ChartBll.GetInstance().GetModel(fatesysno);
        }

        public DataSet GetNeighbor(int SysNo, int cate)
        {
            DataSet m_dt = new DataSet();
            string strsql = "select * from (select top 1 [SysNo],[Title] from QA_Question where [CateSysNo] = " + cate + " and sysno<"+SysNo+"order by sysno desc) as T "+
                " union select top 1 [SysNo],[Title] from QA_Question where sysno<" + SysNo + "order by sysno desc;" +
                "select * from (select top 1 [SysNo],[Title] from QA_Question where [CateSysNo] = " + cate + " and sysno>" + SysNo + "order by sysno asc) as P " +
                " union select top 1 [SysNo],[Title] from QA_Question where sysno>" + SysNo + "order by sysno asc;";

            using (SQLData m_data = new SQLData())
            {
                try
                {
                    m_dt = m_data.CmdtoDataSet(strsql);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return m_dt;
        }

        public DataTable GetToEndList()
        {
            DataTable m_dt = new DataTable();
            string sqlstr = "select * from QA_Question where EndTime is null and TS < '" + DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss") + "' and Award>0 and ReplyCount>0;"
                + "update QA_Question set EndTime=getdate() where EndTime is null and Award=0;";
            using (SQLData m_data = new SQLData())
            {
                m_dt = m_data.CmdtoDataTable(sqlstr);
            }
            return m_dt;
        }


        /// <summary>
        /// 前台发问题
        /// </summary>
        /// <param name="model"></param>
        public void AddQuest(ref QA_QuestionMod model, bool isquest)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (SQLData m_data = new SQLData())
                {
                    model.SysNo = m_data.GetSequence("QA_Question_Seq");
                }
                Add(model);
                AppMod.User.USR_RecordMod m_record = new AppMod.User.USR_RecordMod();
                m_record.CustomerSysNo = model.CustomerSysNo;
                m_record.TargetSysNo = model.SysNo;
                m_record.TS = DateTime.Now;
                m_record.Type = (int)AppEnum.ActionType.AddQuest;
                User.USR_RecordBll.GetInstance().Add(m_record);
                if (isquest)
                {
                    User.USR_CustomerBll.GetInstance().AddPoint(0 - model.Award, model.CustomerSysNo);
                    User.USR_CustomerBll.GetInstance().AddCount(model.CustomerSysNo, 1, 0, 0, 0, 0, 0, 0, 0, 0);
                }
                else
                {
                    User.USR_CustomerBll.GetInstance().AddPoint(AppConst.TalkPoint, model.CustomerSysNo);
                    User.USR_CustomerBll.GetInstance().AddCount(model.CustomerSysNo, 0, 0, 0, 0, 1, 0, 0, 0, 0);
                }
                User.USR_CustomerBll.GetInstance().AddExp(AppConst.TalkExp, model.CustomerSysNo);
                scope.Complete();
            }
        }

        public DataTable GetTopListByCate(int top)
        {
             string cachyname = "QACatePostTop" + top;
            if (HttpRuntime.Cache[cachyname] == null)
            {
            DataTable m_dt = new DataTable();
            string sqlstr = @"select b.*,NickName,Photo from(select * from 
(select SysNo,CateSysNo,CustomerSysNo,Title,Context,Award,LastReplyTime,row_number() over(partition by CateSysNo order by LastReplyTime desc)
as rowindex from QA_Question) a where rowindex <= " + top + ") b left join USR_Customer on CustomerSysNo=USR_Customer.sysno";
            using (SQLData m_data = new SQLData())
            {
                m_dt = m_data.CmdtoDataTable(sqlstr);
            }
            HttpRuntime.Cache.Insert(cachyname, m_dt, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
            }
            return (HttpRuntime.Cache[cachyname] as DataTable).Copy();
        }

        #endregion 扩展成员方法

    }

}
