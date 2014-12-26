using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.User;
using AppDal.User;
using AppCmn;
using System.Data;


namespace AppBll.User
{
    public class USR_NoticeBll
    {
        private readonly USR_NoticeDal dal = new USR_NoticeDal();
        private static USR_NoticeBll _instance;
        public static USR_NoticeBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_NoticeBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_NoticeMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(USR_NoticeMod model)
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

        public USR_NoticeMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法


        public DataTable GetList(int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "*";
            string tables = "USR_Notice";
            string where = "1=1";
            string order = "SysNo desc";
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

    }
}
