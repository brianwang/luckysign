using System;
using System.Data;
using AppMod.BLG;
using AppDal.BLG;
using AppCmn;
using System.Transactions;

namespace AppBll.BLG
{
    public class BLG_CommentBll
    {
        private readonly BLG_CommentDal dal = new BLG_CommentDal();
        private BLG_CommentBll()
        {
        }
        private static BLG_CommentBll _instance;
        public static BLG_CommentBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BLG_CommentBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_CommentMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(BLG_CommentMod model)
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

        public BLG_CommentMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region  扩展成员方法

        public DataTable GetArticleComments(int ArticleSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Comment.SysNo desc";

            #region  设置参数
            columns = @"BLG_Comment.SysNo
                        , ArticleSysNo
                        , Title
                        , Context
                        , CustomerSysNo
                        , Love
                        , Hate
                        , BLG_Comment.TS
                      ,[NickName]
                      ,[Photo]
                      ,[Credit]
                      ,[Point]";
            tables = "BLG_Comment left join USR_Customer on CustomerSysNo=USR_Customer.SysNo";
            where = "BLG_Comment.ArticleSysNo = " + ArticleSysno + " and BLG_Comment.dr=" + (int)AppEnum.State.normal + " and USR_Customer.dr=" + (int)AppEnum.State.normal;

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

        public DataTable GetUserArticleComments(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Comment.SysNo desc";

            #region  设置参数
            columns = @"BLG_Comment.SysNo
                        , ArticleSysNo
                        , BLG_Comment.Title
                        , BLG_Comment.Context
                        , BLG_Comment.CustomerSysNo
                        , BLG_Article.Title as articletitle
                        , BLG_Article.Type
                        , BLG_Comment.Love
                        , BLG_Comment.Hate
                        , BLG_Comment.TS";
            tables = "BLG_Comment left join USR_Customer on CustomerSysNo=USR_Customer.SysNo left join BLG_Article on ArticleSysNo = BLG_Article.SysNo";
            where = "BLG_Comment.CustomerSysNo = " + UserSysno + " and BLG_Comment.dr=" + (int)AppEnum.State.normal + " and USR_Customer.Status=" + (int)AppEnum.State.normal;

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
        #endregion
    }
}