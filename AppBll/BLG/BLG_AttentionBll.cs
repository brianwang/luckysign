using System;
using System.Data;
using AppMod.BLG;
using AppDal.BLG;
using AppCmn;
using System.Text;
using System.Transactions;

namespace AppBll.BLG
{
    public class BLG_AttentionBll
    {
        private readonly BLG_AttentionDal dal = new BLG_AttentionDal();
        private BLG_AttentionBll()
        {
        }
        private static BLG_AttentionBll _instance;
        public static BLG_AttentionBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BLG_AttentionBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_AttentionMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(BLG_AttentionMod model)
        {
            dal.UpDate(model);
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

        public BLG_AttentionMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法

        public DataTable GetUserAttentions(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Attention.SysNo desc";

            #region  设置参数
            columns = @"BLG_Attention.[SysNo]
                      ,BLG_Attention.[CustomerSysNo]
                      ,BLG_Attention.[TargetSysNo]
                      ,[NickName]
                      ,[Photo]
                      ,[Credit]
                      ,[Point]";
            tables = "BLG_Attention left join USR_Customer on TargetSysNo=USR_Customer.SysNo";
            where = "BLG_Attention.CustomerSysNo = " + UserSysno + " and BLG_Attention.dr=" + (int)AppEnum.State.normal + " and USR_Customer.dr=" + (int)AppEnum.State.normal;

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

        public DataTable GetUserFans(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "BLG_Attention.SysNo desc";

            #region  设置参数
            columns = @"BLG_Attention.[SysNo]
                      ,BLG_Attention.[CustomerSysNo]
                      ,BLG_Attention.[TargetSysNo]
                      ,[NickName]
                      ,[Photo]
                      ,[Credit]
                      ,[Point]";
            tables = "BLG_Attention left join USR_Customer on CustomerSysNo=USR_Customer.SysNo";
            where = "BLG_Attention.TargetSysNo = " + UserSysno + " and BLG_Attention.dr=" + (int)AppEnum.State.normal + " and USR_Customer.dr=" + (int)AppEnum.State.normal;

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

        /// <summary>
        /// 判断该User是否已经关注了TargetUser
        /// </summary>
        /// <param name="UserSysNo"></param>
        /// <param name="TagetSysNo"></param>
        /// <returns></returns>
        public bool IsFans(int UserSysNo, int TagetSysNo)
        {
            bool ret = false;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from BLG_Attention where CustomerSysNo=").Append(UserSysNo).Append(" and TargetSysNo=").Append(TagetSysNo).Append(" and DR=").Append((int)AppEnum.State.normal);
                try
                {
                    if (data.CmdtoHasRow(builder.ToString()))
                    {
                        ret = true;
                    }
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            return ret;
        }

        public void AddAttention(int UserSysNo, int TagetSysNo)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                BLG_AttentionMod m_attention = new BLG_AttentionMod();
                m_attention.CustomerSysNo = UserSysNo;
                m_attention.DR = (int)AppEnum.State.normal;
                m_attention.TargetSysNo = TagetSysNo;
                m_attention.TS = DateTime.Now;
                Add(m_attention);
                scope.Complete();
            }
        }

        public void RemoveAttention(int UserSysNo, int TagetSysNo)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("update BLG_Attention set DR=").Append((int)AppEnum.State.deleted).Append(" where CustomerSysNo=").Append(UserSysNo).Append(" and TargetSysNo=").Append(TagetSysNo).Append(" and DR=").Append((int)AppEnum.State.normal);
                    try
                    {
                        data.CmdtoNone(builder.ToString());
                    }
                    catch (Exception exception)
                    {
                        //throw exception;
                    }
                }
                scope.Complete();
            }
        }

        #endregion  扩展成员方法
    }

}
