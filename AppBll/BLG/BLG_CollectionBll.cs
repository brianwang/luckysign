using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.BLG;
using AppDal.BLG;
using AppCmn;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace AppBll.BLG
{
    public class BLG_CollectionBll
    {
        private readonly BLG_CollectionDal dal = new BLG_CollectionDal();
        private BLG_CollectionBll()
        {
        }
        private static BLG_CollectionBll _instance;
        public static BLG_CollectionBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BLG_CollectionBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_CollectionMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(BLG_CollectionMod model)
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

        public BLG_CollectionMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法

        public DataTable GetChartCollection(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Collection.SysNo desc";

            #region  设置参数
            columns = @"BLG_Collection.[SysNo]
                      ,[CustomerSysNo]
                      ,[Name]
                      ,[Detail]
                      ,[Type]
                      ,[RefSysNo]
                      ,BLG_Collection.[TS]
                      ,BLG_Collection.[DR]
                      , FirstBirth
                      , FirstPoi
                      , Transit
                      , TransitPoi
                      , SecondBirth
                      , SecondPoi
                      , CharType
                      , TheoryType
                      , Bitvalue";
            tables = "BLG_Collection left join Fate_Chart on RefSysNo=Fate_Chart.SysNo";
            where = "CustomerSysNo = "+UserSysno+" and BLG_Collection.dr=" + (int)AppEnum.State.normal + " and Type=" + (int)AppEnum.CollectionType.chart;

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

        public DataTable GetQuestCollection(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Collection.SysNo desc";

            #region  设置参数
            columns = @"BLG_Collection.[SysNo]
                      ,QA_Question.SysNo as QuestSysNo
                      ,BLG_Collection.[CustomerSysNo]
                      ,[Name]
                      ,[Type]
                      ,[RefSysNo]
                      , QA_Question.[TS]
                      , photo
                      , CateSysNo
                      , QA_Question.CustomerSysNo
                      , Title
                      , Context
                      , Award
                      , EndTime
                      , IsSecret
                      , LastReplyTime
                      , ReplyCount";
            tables = "BLG_Collection left join QA_Question on RefSysNo=QA_Question.SysNo left join USR_Customer on QA_Question.CustomerSysNo = USR_Customer.SysNo";
            where = "BLG_Collection.CustomerSysNo = " + UserSysno + " and BLG_Collection.dr=" + (int)AppEnum.State.normal + " and QA_Question.dr=" + (int)AppEnum.State.normal + " and Type=" + (int)AppEnum.CollectionType.quest;

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

        public DataTable GetArticleCollection(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Collection.SysNo desc";

            #region  设置参数
            columns = @"BLG_Collection.[SysNo]
                      ,BLG_Collection.[CustomerSysNo]
                      ,[Name]
                      ,[Type]
                      ,[RefSysNo]
                      ,BLG_Collection.[TS]
                      ,BLG_Collection.[DR]
                      ,ArticleSysNo
                      ,CateSysNo
                      ,Source
                      ,OrderID
                      ,Title
                      ,CMS_ArticleView.CustomerSysNo
                      ,KeyWords
                      ,Limited
                      ,ReadCount
                      ,Description
                      ,Cost ";
            tables = "BLG_Collection left join CMS_ArticleView on RefSysNo=CMS_ArticleView.SysNo";
            where = "BLG_Collection.CustomerSysNo = " + UserSysno + " and BLG_Collection.dr=" + (int)AppEnum.State.normal + " and CMS_ArticleView.dr=" + (int)AppEnum.State.normal + " and Type=" + (int)AppEnum.CollectionType.article;

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

        public DataTable GetFamousCollection(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Collection.SysNo desc";

            #region  设置参数
            columns = @"BLG_Collection.[SysNo]
                      ,BLG_Collection.[CustomerSysNo]
                      ,BLG_Collection.[Name]
                      ,[Type]
                      ,[RefSysNo]
                      ,BLG_Collection.[TS]
                      ,BLG_Collection.[DR]
                      , SYS_Famous.Name as FamousName
                      , Description
                      , BirthYear
                      , BirthTime
                      , Death
                      , CateSysNo
                      , Level
                      , SYS_Famous.CustomerSysNo as CreateCustomerSysNo
                      , Source
                      , Gender
                      , HomeTown
                      , Height
                      , FullName
                      , TimeUnknown
                      , CollectCount  ";
            tables = "BLG_Collection left join SYS_Famous on RefSysNo=SYS_Famous.SysNo";
            where = "BLG_Collection.CustomerSysNo = " + UserSysno + " and BLG_Collection.dr=" + (int)AppEnum.State.normal + " and SYS_Famous.dr=" + (int)AppEnum.State.normal + " and Type=" + (int)AppEnum.CollectionType.famous;

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

        public DataTable GetUrlCollection(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Collection.SysNo desc";

            #region  设置参数
            columns = @"BLG_Collection.[SysNo]
                      ,[CustomerSysNo]
                      ,BLG_Collection.[Name]
                      ,[Type]
                      ,[RefUrl]
                      ,Detail
                      ,BLG_Collection.[TS]
                      ,BLG_Collection.[DR]";
            tables = "BLG_Collection";
            where = "CustomerSysNo = " + UserSysno + " and BLG_Collection.dr=" + (int)AppEnum.State.normal + " and Type=" + (int)AppEnum.CollectionType.url;

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

        public void AddCollection(BLG_CollectionMod model)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                int sysno = Add(model);
                AppMod.User.USR_RecordMod m_record = new AppMod.User.USR_RecordMod();
                m_record.CustomerSysNo = model.CustomerSysNo;
                m_record.TargetSysNo = sysno;
                m_record.TS = DateTime.Now;
                m_record.Type = 100 + model.Type * 10 + 1;
                User.USR_RecordBll.GetInstance().Add(m_record);
                scope.Complete();
            }
        }
        #endregion
    }

}
