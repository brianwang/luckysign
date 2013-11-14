using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.User;
using AppDal.User;
using AppCmn;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace AppBll.User
{
    public class USR_MessageBll
    {
        private readonly USR_MessageDal dal = new USR_MessageDal();
        private USR_MessageBll()
        {
        }
        private static USR_MessageBll _instance;
        public static USR_MessageBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_MessageBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(USR_MessageMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(USR_MessageMod model)
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

        public USR_MessageMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public DataTable GetMessageByCustomer(int UserSysno, int pagesize, int pageindex, int isread,int type,  ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "SysNo desc";

            #region  设置参数
            columns = @"SysNo, CustomerSysNo, Title, Type, Context, IsRead, DR, TS";
            tables = "USR_Message";
            where = "CustomerSysNo="+UserSysno+" and type="+type+" and DR=" + (int)AppEnum.State.normal;
            if (isread == 1 || isread == 0)
            {
                where += " and IsRead=" + isread;
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

        public void AddMessage(USR_MessageMod model)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                Add(model);
                USR_CustomerBll.GetInstance().AddUnReadInfo(model.CustomerSysNo);
 
                scope.Complete();
            }
        }

        #endregion 扩展成员方法
    }

}
