using System;
using System.Data;
using AppMod.BLG;
using AppDal.BLG;
using AppCmn;
using System.Transactions;

namespace AppBll.BLG
{
    public class BLG_ArticleBll
    {
        private readonly BLG_ArticleDal dal = new BLG_ArticleDal();
        private BLG_ArticleBll()
        {
        }
        private static BLG_ArticleBll _instance;
        public static BLG_ArticleBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BLG_ArticleBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_ArticleMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(BLG_ArticleMod model)
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

        public BLG_ArticleMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region  扩展成员方法

        /// <summary>
        /// 获取该用户轻博客首页内容
        /// </summary>
        /// <param name="UserSysno"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetAttendtionArticle(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "dbo.BLG_Article.SysNo desc";

            #region  设置参数
            columns = @"BLG_Article.SysNo
                        , Title
                        , Context
                        , CustomerSysNo
                        , LastReplyTime
                        , Love
                        , Hate
                        , Spread
                        , Type
                        , TargetUrl
                        , ChartSysNo
                        , CommentCount
                        , BLG_Article.TS                      
                      ,[NickName]
                      ,[Photo]
                      ,[Credit]
                      ,[Point]";
            tables = "dbo.BLG_Article left join USR_Customer on CustomerSysNo=USR_Customer.SysNo";
            where = "dbo.BLG_Article.CustomerSysNo in (select targetsysno from BLG_Attention where CustomerSysNo=" + UserSysno + " and BLG_Attention.dr=" + (int)AppEnum.State.normal + " aaa) and dbo.BLG_Article.dr=" + (int)AppEnum.State.normal + " and USR_Customer.dr=" + (int)AppEnum.State.normal;

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

        public void AddArticle(BLG_ArticleMod model)
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
                m_record.Type = ((int)model.Type) * 10 +1;
                User.USR_RecordBll.GetInstance().Add(m_record);
                scope.Complete();
            }
        }

        #endregion  扩展成员方法
    }

}
