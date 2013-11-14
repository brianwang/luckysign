using System;
using System.Data;
using AppMod.User;
using AppDal.User;
using AppCmn;
using System.Text;

namespace AppBll.User
{
    public class REL_Customer_CategoryBll
    {
        private readonly REL_Customer_CategoryDal dal = new REL_Customer_CategoryDal();
        private REL_Customer_CategoryBll()
        {
        }
        private static REL_Customer_CategoryBll _instance;
        public static REL_Customer_CategoryBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new REL_Customer_CategoryBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Customer_CategoryMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(REL_Customer_CategoryMod model)
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

        public REL_Customer_CategoryMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
        #region 扩展成员方法

        public DataTable GetList(string name, int cate, int type)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"REL_Customer_Category.*,nickname,Email,name";
            tables = "REL_Customer_Category left join USR_Customer on USR_Customer.SysNo=CustomerSysNo";
            order = "REL_Customer_Category.sysno desc";
            where = "1=1";
            if (name != "")
            {
                where += " and (";
                string[] tmpstr = name.Split(new char[] { ' ', '@' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " (USR_Customer.[Email] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' or USR_Customer.[NickName] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%') and ";
                }
                where += " 1=1)";
            }
            if (cate != 0)
            {
                where += " and CategorySysNo=" + cate;
            }
            if (type != 0)
            {
                where += " and REL_Customer_Category.type=" + type;
            }
            switch (type)
            {
                case (int)AppEnum.CategoryType.QA:
                    tables += " left join QA_Category on CategorySysNo=QA_Category.sysno";
                    break;
            }
            
            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", 1);
                m_data.AddParameter("pagesize", 1000);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                }
            }
            return m_dt;
        }

        public DataTable GetListByCustomer(int customersysno, int type)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"REL_Customer_Category.*,name";
            tables = "REL_Customer_Category";
            order = "REL_Customer_Category.sysno desc";
            where = "1=1";
            if (customersysno != 0)
            {
                where += " and CustomerSysNo=" + customersysno;
            }
            if (type != 0)
            {
                where += " and REL_Customer_Category.type=" + type;
            }
            switch (type)
            {
                case (int)AppEnum.CategoryType.QA:
                    tables += " left join QA_Category on CategorySysNo=QA_Category.sysno";
                    break;
            }

            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", 1);
                m_data.AddParameter("pagesize", 1000);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                }
            }
            return m_dt;
        }

        public DataTable GetListByCate(int catesysno, int type)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"USR_Customer.*";
            tables = "REL_Customer_Category left join USR_Customer on USR_Customer.sysno=customersysno";
            order = "REL_Customer_Category.sysno asc";
            where = "1=1";
            if (catesysno != 0)
            {
                where += " and CategorySysNo=" + catesysno;
            }
            if (type != 0)
            {
                where += " and REL_Customer_Category.type=" + type;
            }

            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", 1);
                m_data.AddParameter("pagesize", 1000);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                }
            }
            return m_dt;
        }

        public bool HasRecord(int usersysno, int Catesysno,int type)
        {
            bool ret = false;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select * from REL_Customer_Category where customersysno=").Append(usersysno).Append(" and Categorysysno=").Append(Catesysno).Append(" and type=").Append(type);
                try
                {
                    if (data.CmdtoDataTable(builder.ToString()).Rows.Count > 0)
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

        #endregion
    }

}
