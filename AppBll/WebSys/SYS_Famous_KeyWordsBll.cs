using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;

namespace AppBll.WebSys
{
    public class SYS_Famous_KeyWordsBll
    {
        private readonly SYS_Famous_KeyWordsDal dal = new SYS_Famous_KeyWordsDal();
        private SYS_Famous_KeyWordsBll()
        {
        }
        private static SYS_Famous_KeyWordsBll _instance;
        public static SYS_Famous_KeyWordsBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_Famous_KeyWordsBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_Famous_KeyWordsMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(SYS_Famous_KeyWordsMod model)
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

        public SYS_Famous_KeyWordsMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public int GetSysNoByName(string key)
        {
            int ret = AppConst.IntNull;
            StringBuilder builder = new StringBuilder();
            builder.Append("select SysNo from SYS_Famous_KeyWords where KeyWords='").Append(key).Append("' and DR=").Append((int)AppEnum.State.normal);
            try
            {

                ret = (int)SqlHelper.ExecuteScalar(builder.ToString());
            }
            catch (Exception exception)
            {
                return AppConst.IntNull;
            }
            return ret;
        }

        public DataTable GetCloserKeys(string input, int count)
        {
            DataTable ret = new DataTable();
            string key = input.Split(new char[] { ' ' })[input.Split(new char[] { ' ' }).Length - 1];
            StringBuilder builder = new StringBuilder();
            builder.Append("select top " + count.ToString() + " KeyWords from SYS_Famous_KeyWords where KeyWords like '%").Append(key).Append("%' and DR=").Append((int)AppEnum.State.normal);
            try
            {
                ret = SqlHelper.ExecuteDataSet(builder.ToString()).Tables[0];
            }
            catch (Exception exception)
            {
                return null;
            }
            return ret;
        }

        public DataTable GetList(int pagesize, int pageindex, string name,string status,bool istop, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"[SysNo]
                      ,[KeyWords]
                      ,[DR]
                      ,[IsTop]";
            tables = "SYS_Famous_KeyWords";
            order = "SYS_Famous_KeyWords.SysNo asc";
            where = "1=1";
            if (name != "")
            {
                where += " and (";
                string[] tmpstr = name.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " SYS_Famous_KeyWords.[KeyWords] like '%" + tmpstr[i] + "%' and ";
                }
                where += " 1=1)";
            }
            if (status == "0" || status == "1")
            {
                where += " and dr=" + status;
            }
            if (istop)
            {
                where += " and istop=" + (int)AppEnum.BOOL.True;
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
