using System;
using System.Data;
using AppMod.Research;
using AppDal.Research;
using AppCmn;
namespace AppBll.Research
{
    public class RSH_BaziLogicBll
    {
        private readonly RSH_BaziLogicDal dal = new RSH_BaziLogicDal();
        private static RSH_BaziLogicBll _instance;
        public static RSH_BaziLogicBll GetInstance()
        {
            if (_instance == null)
            { _instance = new RSH_BaziLogicBll(); }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(RSH_BaziLogicMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(RSH_BaziLogicMod model)
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

        public RSH_BaziLogicMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
        public DataTable GetList(int pagesize, int pageindex, string name, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"SysNo, [Name], [Description], Logic, Type, DR";
            tables = "RSH_BaziLogic";
            order = "SysNo desc";
            where = "1=1";
            if (name != "")
            {
                where += " and (";
                string[] tmpstr = name.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " [Name] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' and ";
                }
                where += " 1=1)";
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
        #region 扩展成员方法

        #endregion
    }
}
