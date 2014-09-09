using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
using System.Transactions;
using System.Text;
using AppBll.User;

namespace AppBll.QA
{
    public class QA_AnswerBll
    {
        private readonly QA_AnswerDal dal = new QA_AnswerDal();
        private QA_AnswerBll()
        {
        }
        private static QA_AnswerBll _instance;
        public static QA_AnswerBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QA_AnswerBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_AnswerMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(QA_AnswerMod model)
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

        public QA_AnswerMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public DataTable GetListByQuest(int pagesize, int pageindex, int qid, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "[QA_Answer].TS asc";

            #region  设置参数
            columns = @"[QA_Answer].[SysNo]
                      ,[QuestionSysNo]
                      ,[CustomerSysNo]
                      ,[Title]
                      ,[Context]
                      ,[Love]
                      ,[Hate]
                      ,[Award]
                      ,[QA_Answer].[DR]
                      ,[QA_Answer].[TS]
                      ,NickName
                      ,Point
                      ,TotalAnswer
                      ,BestAnswer
                      ,photo
                      ,USR_Grade.Name
                      ,USR_Grade.LevelNum";
            tables = "[QA_Answer] left join USR_Customer on CustomerSysNo=USR_Customer.SysNo left join USR_Grade on GradeSysNo = USR_Grade.SysNo";
            where = "[QA_Answer].dr=" + (int)AppEnum.State.normal;
           
            if (qid != 0)
            {
                where += " and QuestionSysNo=" + qid;
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
        public DataTable GetListByQuestForConsult(int pagesize, int pageindex, int qid, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "[QA_Answer].TS asc";

            #region  设置参数
            columns = @"[QA_Answer].[SysNo]
                      ,[QA_Answer].[QuestionSysNo]
                      ,[QA_Answer].[CustomerSysNo]
                      ,[Title]
                      ,[Context]
                      ,[Love]
                      ,[Hate]
                      ,[Award]
                      ,[QA_Answer].[DR]
                      ,[QA_Answer].[TS]
                      ,NickName
                      ,Point
                      ,TotalAnswer
                      ,BestAnswer
                      ,photo
                      ,USR_Grade.Name
                      ,USR_Grade.LevelNum
                      ,Price
                      ,QA_Order.status
                      ,description
                      ,score
                      ,trial
                      ,Words";
            tables = "[QA_Answer] left join USR_Customer on CustomerSysNo=USR_Customer.SysNo left join USR_Grade on GradeSysNo = USR_Grade.SysNo left join QA_Order on QA_Answer.sysno = QA_Order.answersysno";
            where = "[QA_Answer].dr=" + (int)AppEnum.State.normal;

            if (qid != 0)
            {
                where += " and [QA_Answer].QuestionSysNo=" + qid;
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
        public DataTable GetListByQuestForAdmin(int pagesize, int pageindex, int qid,int user, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "[QA_Answer].TS desc";

            #region  设置参数
            columns = @"[QA_Answer].[SysNo]
                      ,[QuestionSysNo]
                      ,[CustomerSysNo]
                      ,[Title]
                      ,[Context]
                      ,[Love]
                      ,[Hate]
                      ,[Award]
                      ,[QA_Answer].[DR]
                      ,[QA_Answer].[TS]
                      ,NickName
                      ,photo";
            tables = "[QA_Answer] left join USR_Customer on CustomerSysNo=USR_Customer.SysNo";
            where = "[QA_Answer].dr=" + (int)AppEnum.State.normal;

            if (qid != 0)
            {
                where += " and QuestionSysNo=" + qid;
            }
            if (user != 0)
            {
                where += " and CustomerSysNo=" + user;
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

        public DataTable GetSimpleListByQuest(int qid)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "[QA_Answer].TS asc";

            #region  设置参数
            columns = @"[QA_Answer].[SysNo]
                      ,[CustomerSysNo]
                      ,[QA_Answer].[TS]";
            tables = "[QA_Answer]";
            where = "[QA_Answer].dr=" + (int)AppEnum.State.normal;

            if (qid != 0)
            {
                where += " and QuestionSysNo=" + qid;
            }

            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", 1);
                m_data.AddParameter("pagesize", 1000);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                }
            }
            return m_dt;
        }

        public int AddAnswer(QA_AnswerMod model)
        {
            bool isquest = false;
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                int sysno = Add(model);

                QA_QuestionMod m_qa = QA_QuestionBll.GetInstance().GetModel(model.QuestionSysNo);
                m_qa.ReplyCount++;
                m_qa.LastReplyUser = model.CustomerSysNo;
                m_qa.LastReplyTime = DateTime.Now;
                QA_QuestionBll.GetInstance().Update(m_qa);
                if (QA_CategoryBll.GetInstance().GetModel(m_qa.CateSysNo).TopSysNo == 1)
                {
                    isquest = true;
                }

                AppMod.User.USR_RecordMod m_record = new AppMod.User.USR_RecordMod();
                m_record.CustomerSysNo = model.CustomerSysNo;
                m_record.TargetSysNo = sysno;
                m_record.TS = DateTime.Now;
                m_record.Type = (int)AppEnum.ActionType.ReplyQuest;
                User.USR_RecordBll.GetInstance().Add(m_record);

                User.USR_CustomerBll.GetInstance().AddPoint(AppConst.AnswerPoint, model.CustomerSysNo);
                User.USR_CustomerBll.GetInstance().AddExp(AppConst.AnswerExp, model.CustomerSysNo);
                if (model.CustomerSysNo != m_qa.CustomerSysNo)
                {
                    AppMod.User.USR_MessageMod m_notice = new AppMod.User.USR_MessageMod();
                    m_notice.CustomerSysNo = m_qa.CustomerSysNo;
                    m_notice.Context = "";
                    m_notice.DR = 0;
                    m_notice.IsRead = 0;
                    m_notice.Title = AppConst.AnswerReport.Replace("@url", AppConfig.HomeUrl() + "Quest/Question.aspx?id=" + m_qa.SysNo).Replace("@question", m_qa.Title);
                    m_notice.TS = DateTime.Now;
                    m_notice.Type = (int)AppEnum.MessageType.notice;
                    User.USR_MessageBll.GetInstance().AddMessage(m_notice);
                    if (isquest)
                    {
                        User.USR_CustomerBll.GetInstance().AddCount(model.CustomerSysNo, 0, 1, 0, 0, 0, 0, 0, 0, 0);
                    }
                    else
                    {
                        User.USR_CustomerBll.GetInstance().AddCount(model.CustomerSysNo, 0, 0, 0, 0, 0, 1, 0, 0, 0);
                    }
                }
                else
                {
                    User.USR_CustomerBll.GetInstance().AddCount(model.CustomerSysNo, 0, 0, 0, 0, 0, 1, 0, 0, 0);
                }
                scope.Complete();
                return sysno;
            }
        }


        /// <summary>
        /// 获取某提问的已分配悬赏值
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        public int GetUsedAward(int sysno)
        {
            int sum = 0;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select sum(Award) from QA_Answer where QuestionSysNo=").Append(sysno);
                try
                {
                    sum = Convert.ToInt32(data.CmdtoDataTable(builder.ToString()).Rows[0][0]);
                }
                catch (Exception exception)
                {
                    return sum;
                }
            }
            return sum;
        }

        public DataTable GetListByUser(int pagesize, int pageindex, int usersysno, string key, int cate, bool best, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"QA_Answer.[SysNo]
                      ,QA_Question.[SysNo] as QuestSysNo
                      ,[CateSysNo]
                      ,QA_Question.[CustomerSysNo] as QuestCustomer
                      ,QA_Answer.[Title]
                      ,QA_Answer.[Context]
                      ,QA_Answer.[Award]
                      ,QA_Question.[Title] as QuestTitle
                      ,[EndTime]
                      ,[IsSecret]
                      ,[LastReplyTime]
                      ,[ReplyCount]
                      ,QA_Answer.[DR]
                      ,QA_Answer.[TS]
                      ,Photo
                      ,NickName";
            tables = " QA_Answer left join QA_Question on QA_Answer.QuestionSysNo = QA_Question.SysNo left join USR_Customer on QA_Question.CustomerSysNo=USR_Customer.SysNo";
            where = "QA_Answer.CustomerSysNo=" + usersysno + " and QA_Answer.dr=" + (int)AppEnum.State.normal;
            if (key != "")
            {
                where += " and (";
                string[] tmpstr = key.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " QA_Answer.[Title] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' and ";
                }
                where += " 1=1)";
            }
            if (best)
            {
                where += " and QA_Answer.Award>0";
            }
            if (cate != 0)
            {
                where += " and CateSysNo=" + cate;
            }
            if (orderby == "timedown")
            {
                order = "QA_Answer.TS desc";
            }
            else if (orderby == "timeup")
            {
                order = "QA_Answer.TS asc";
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
                order = "QA_Answer.Award desc";
            }
            else if (orderby == "pointup")
            {
                order = "QA_Answer.Award asc";
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

        public void SetAward(QA_AnswerMod m_answer, QA_QuestionMod m_quest, int score)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                if (m_answer.Award == AppConst.IntNull)
                {
                    m_answer.Award = score;
                }
                else
                {
                    m_answer.Award += score;
                }
                QA_AnswerBll.GetInstance().Update(m_answer);

                USR_CustomerBll.GetInstance().AddPoint(score, m_answer.CustomerSysNo);
                USR_CustomerBll.GetInstance().AddCount(m_answer.CustomerSysNo, 0, 0, 1, 0, 0, 0, 0, 0, 0);
                int usedAward = QA_AnswerBll.GetInstance().GetUsedAward(m_quest.SysNo);
                if (score == m_quest.Award - usedAward)
                {
                    m_quest.EndTime = DateTime.Now;
                    QA_QuestionBll.GetInstance().Update(m_quest);
                }
                scope.Complete();
            }
        }

        #endregion 扩展成员方法
    }

}
