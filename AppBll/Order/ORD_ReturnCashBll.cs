﻿using System;
using System.Data;
using AppMod.Order;
using AppDal.Order;
using AppCmn;
namespace AppBll.Order
{
    public class ORD_ReturnCashBll
    {
        private readonly ORD_ReturnCashDal dal = new ORD_ReturnCashDal();
        private static ORD_ReturnCashBll _instance;
        public static ORD_ReturnCashBll GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_ReturnCashBll(); }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(ORD_ReturnCashMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(ORD_ReturnCashMod model)
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

        public ORD_ReturnCashMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public DataTable GetList(int pagesize, int pageindex, int customersysno, int type, int ordersysno, int status, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"*";
            tables = "ORD_CashReturnEntity";
            where = "1=1";
            if (customersysno != 0)
            {
                where += " and CustomerSysNo=" + customersysno;
            }
            if (type != AppConst.IntNull)
            {
                where += " and ReasonType=" + type;
            }
            if (status != AppConst.IntNull)
            {
                where += " and status=" + status;
            }
            if (ordersysno != AppConst.IntNull)
            {
                where += " and ordersysno=" + ordersysno;
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
        #endregion  扩展成员方法
    }
}
