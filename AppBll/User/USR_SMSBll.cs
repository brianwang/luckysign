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
    public class USR_SMSBll
    {
        private readonly USR_SMSDal dal = new USR_SMSDal();
        private USR_SMSBll()
        {
        }
        private static USR_SMSBll _instance;
        public static USR_SMSBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_SMSBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_SMSMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(USR_SMSMod model)
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

        public USR_SMSMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public DataTable GetTopicByReciever(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "SysNo desc";

            #region  设置参数
            columns = @"USR_SMS.SysNo, FromSysNo, Title, Context, IsRead, USR_SMS.DR, USR_SMS.TS, NickName, Photo,ReplyCount";
            tables = "USR_SMS left join USR_Customer on FromSysNo= customer.sysNo";
            where = "ToSysNo=" + UserSysno + " and Parent=0 and dr=" + (int)AppEnum.State.normal + " and IsToDeleted="+(int)AppEnum.BOOL.False;
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

        public DataTable GetTopicBySender(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "SysNo desc";

            #region  设置参数
            columns = @"USR_SMS.SysNo, ToSysNo, Title, Context, IsRead, USR_SMS.DR, USR_SMS.TS, NickName, Photo,ReplyCount";
            tables = "USR_SMS left join USR_Customer on ToSysNo= customer.sysNo";
            where = "FromSysNo=" + UserSysno + " and Parent=0 and dr=" + (int)AppEnum.State.normal + " and IsFromDeleted=" + (int)AppEnum.BOOL.False;
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

        public DataTable GetTopicByUser(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "USR_SMS.SysNo desc";

            #region  设置参数
            columns = @"USR_SMS.SysNo, ToSysNo, FromSysNo, Title, Context,ReplyCount, IsRead, USR_SMS.DR, USR_SMS.TS, aaa.NickName as FromName,bbb.NickName as ToName,  aaa.Photo as ToPhoto,bbb.Photo as FromPhoto";
            tables = "USR_SMS left join USR_Customer aaa on ToSysNo= aaa.sysNo left join USR_Customer bbb on FromSysNo= bbb.sysNo";
            where = "(FromSysNo=" + UserSysno + " or ToSysNo=" + UserSysno + ") and Parent=0 and dr=" + (int)AppEnum.State.normal + " and IsFromDeleted=" + (int)AppEnum.BOOL.False;
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

        public DataTable GetTalk(int Sysno)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select USR_SMS.SysNo, FromSysNo, ToSysNo, Title, Context, IsRead, Parent, USR_SMS.DR, USR_SMS.TS,a.NickName as FromNickName,a.photo as FromPhoto,b.NickName as ToNickName,b.photo as ToPhoto
                                from USR_SMS left join USR_Customer a on FromSysNo = a.sysno left join USR_Customer b on ToSysNo = b.sysno 
                                where ([Parent]=" + Sysno + @" or (Parent=0 and USR_SMS.SysNo=" + Sysno + ")) and dr=").Append((int)AppEnum.State.normal)
                  .Append(" order by USR_SMS.TS asc");
                try
                {
                    table = data.CmdtoDataTable(builder.ToString());
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return table;
        }

        public int AddSMS(USR_SMSMod model)
        {
            int ret = 0;
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                ret = Add(model);
                USR_CustomerBll.GetInstance().AddUnReadInfo(model.ToSysNo);

                scope.Complete();
            }
            return ret;
        }

        #endregion  扩展成员方法
    }

}
