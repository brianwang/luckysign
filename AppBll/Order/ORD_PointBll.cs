using System;
using System.Data;
using AppMod.Order;
using AppDal.Order;
using AppCmn;
namespace AppBll.Order
{
    public class ORD_PointBll
    {
        private readonly ORD_PointDal dal = new ORD_PointDal();
        private static ORD_PointBll _instance;
        public static ORD_PointBll GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_PointBll(); }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(ORD_PointMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(ORD_PointMod model)
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

        public ORD_PointMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public DataTable GetList(int pagesize, int pageindex, int customersysno, int type,int productsysno, int status, string orderby, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"[SysNo]
      ,[OrderID]
      ,[CustomerSysNo]
      ,[ProductSysNo]
      ,[Point]
      ,[Type]
      ,[TS]
      ,[Status]";
            tables = "ORD_Point ";
            where = "1=1";
            if (customersysno != 0)
            {
                where += " and CustomerSysNo=" + customersysno;
            }
            if (type != AppConst.IntNull)
            {
                where += " and Type=" + type;
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

        #endregion
    }
}
