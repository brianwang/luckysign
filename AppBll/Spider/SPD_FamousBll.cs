using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.Spider;
using AppDal.Spider;
using AppCmn;
namespace AppBll.Spider
{
    public class SPD_FamousBll
    {
        private readonly SPD_FamousDal dal = new SPD_FamousDal();
        private SPD_FamousBll()
        {
        }
        private static SPD_FamousBll _instance;
        public static SPD_FamousBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SPD_FamousBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SPD_FamousMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(SPD_FamousMod model)
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

        public SPD_FamousMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法

        public DataTable GetList(int pagesize, int pageindex, string name, int isinput, DateTime timeBegin, DateTime timeEnd,string nation, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = "SysNo, FamousName, Birthtmp, FamousSysNo, HomeTown, IsUnknow, AstroThemeID, Gender";
            tables = "SPD_Famous";
            order = "SysNo asc";
            where = "1=1";
            if (name != "")
            {
                where += " and (";
                string[] tmpstr = name.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " FamousName like '%" + tmpstr[i] + "%' and ";
                }
                where += " 1=1)";
            }
            if (isinput == 1)
            {
                where += " and FamousSysNo is not null";
            }
            else if(isinput == 0)
            {
                where += " and FamousSysNo is null";
            }
            if (timeBegin != AppCmn.AppConst.DateTimeNull)
            {
                where += " and Birth>='" +timeBegin.ToString("yyyy-MM-dd 00:00:00")+"'";
            }
            if (timeEnd != AppCmn.AppConst.DateTimeNull)
            {
                where += " and Birth<='" + timeEnd.ToString("yyyy-MM-dd 23:59:59")+"'";
            }
            if (nation != "")
            {
                where += " and hometown like '%" + nation + "%'";
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

        /// <summary>
        /// 蜘蛛导入记录去除时恢复导入标示
        /// </summary>
        /// <param name="sysno"></param>
        public void InputReturn(int sysno)
        {
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"Update [SPD_Famous] set [FamousSysNo]=null where [FamousSysNo]=").Append(sysno);
                try
                {
                    data.CmdtoNone(builder.ToString());
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
        #endregion
    }

}
