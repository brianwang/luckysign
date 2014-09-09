using System;
using System.Data;
using AppMod.Order;
using AppDal.Order;
using AppCmn;
using System.Text;
using System.Transactions;
using AppMod.QA;
using AppBll.QA;

namespace AppBll.Order
{
    public class ORD_CashBll
    {
        private readonly ORD_CashDal dal = new ORD_CashDal();
        private static ORD_CashBll _instance;
        public static ORD_CashBll GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_CashBll(); }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(ORD_CashMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(ORD_CashMod model)
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

        public ORD_CashMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public DataTable GetList(int pagesize, int pageindex, int customersysno, int type, int productsysno, int status, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"[SysNo]
      ,[CustomerSysNo]
      ,[ProductType]
      ,[ProductSysNo]
      ,[Price]
      ,[PayType]
      ,[Discount]
      ,[PayAmount]
      ,[TS]
      ,[Status]
      ,[OrderID]
      ,[CurrentID]
      ,[PayTime]";
            tables = "ORD_Cash";
            where = "1=1";
            if (customersysno != 0)
            {
                where += " and CustomerSysNo=" + customersysno;
            }
            if (type != AppConst.IntNull)
            {
                where += " and ProductType=" + type;
            }
            if (status != AppConst.IntNull)
            {
                where += " and status=" + status;
            }
            if (productsysno != 0)
            {
                where += " and productsysno=" + productsysno;
            }
            if (orderby == "timedown")
            {
                order = "TS desc";
            }
            else if (orderby == "timeup")
            {
                order = "TS asc";
            }
            else
            {
                order = "TS desc";
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

        public ORD_CashMod GetModelByOrderID(string OrderID)
        {
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select SysNo from ORD_Cash where OrderID=").Append(OrderID);
                try
                {
                    int sysno = Convert.ToInt32(data.CmdtoDataTable(builder.ToString()).Rows[0][0]);
                    return GetModel(sysno);
                }
                catch (Exception exception)
                {
                    return null;
                }
            }
        }

        public bool SetPaySucc(ORD_CashMod m_mod)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                m_mod.CurrentID = "";
                m_mod.PayTime = DateTime.Now;
                m_mod.Status = (int)AppEnum.CashOrderStatus.succed;
                ORD_CashBll.GetInstance().Update(m_mod);
                switch (m_mod.ProductType)
                {
                    case 1://咨询订单
                        QA_OrderMod m_order = QA_OrderBll.GetInstance().GetModel(m_mod.ProductSysNo);
                        m_order.Status = (int)AppEnum.ConsultOrderStatus.payed;
                        QA_OrderBll.GetInstance().Update(m_order);
                        break;
                }
                scope.Complete();
                return true;
            }
        }
        #endregion
    }
}
