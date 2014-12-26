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
    public class SYS_FamousBll
    {
        private readonly SYS_FamousDal dal = new SYS_FamousDal();
        private SYS_FamousBll()
        {
        }
        private static SYS_FamousBll _instance;
        public static SYS_FamousBll GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_FamousBll(); }
            return _instance;
        }
        #region  基本成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_FamousMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(SYS_FamousMod model)
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

        public SYS_FamousMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region  扩展成员方法

        public DataTable GetList(int pagesize, int pageindex, string name, DateTime timeBegin, DateTime timeEnd,string status,bool istop, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"SYS_Famous.[SysNo]
                      ,SYS_Famous.[Name]
                      ,Description
                      ,[FullName]
                      ,[BirthYear]
                      ,[BirthTime]
                      ,[Source]
                      ,[Gender]
                      ,[HomeTown]
                      ,[Name1]
                      ,[Name3]
                      ,[EnglishName1]
                      ,[EnglishName3]
                      ,[TimeUnknown]
                      ,[IsTop]
                      ,[photo]
                      ,SYS_Famous.[DR]";
            tables = "SYS_Famous left join District3Level on [HomeTown] = District3Level.SysNo3";
            order = "SYS_Famous.SysNo asc";
            where = "1=1";
            if (name != "")
            {
                where += " and (";
                string[] tmpstr = name.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " (SYS_Famous.[Name] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' or SYS_Famous.FullName like '%" + SQLData.SQLFilter(tmpstr[i]) + "%') and ";
                }
                where += " 1=1)";
            }
            if (timeBegin != AppCmn.AppConst.DateTimeNull)
            {
                where += " and (BirthYear>" + timeBegin.Year.ToString() +
                    " or (BirthYear=" + timeBegin.Year.ToString() + " and BirthTime>='" + timeBegin.AddYears(AppConst.DateTimeNull.Year - timeBegin.Year).ToString("yyyy-MM-dd 00:00:00") + "'))";
            }
            if (timeEnd != AppCmn.AppConst.DateTimeNull)
            {
                where += " and (BirthYear<" + timeEnd.Year.ToString() +
                    " or (BirthYear=" + timeEnd.Year.ToString() + " and BirthTime<='" + timeEnd.AddYears(AppConst.DateTimeNull.Year - timeEnd.Year).ToString("yyyy-MM-dd 23:59:59") + "'))";
            }
            if (status != "" && status != "100")
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

        public DataTable GetListByKeys(int pagesize, int pageindex, int key, string status, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"SYS_Famous.[SysNo]
                      ,SYS_Famous.[Name]
                      ,Description
                      ,[FullName]
                      ,[BirthYear]
                      ,[BirthTime]
                      ,[Source]
                      ,[Gender]
                      ,[HomeTown]
                      ,[Name1]
                      ,[Name3]
                      ,[EnglishName1]
                      ,[EnglishName3]
                      ,[TimeUnknown]
                      ,[IsTop]
                      ,[photo]
                      ,SYS_Famous.[DR]";
            tables = "SYS_Famous left join District3Level on [HomeTown] = District3Level.SysNo3";
            order = "SYS_Famous.SysNo asc";
            where = "1=1";
            if (key != 0)
            {
                where += " and SYS_Famous.[SysNo] in (select Famous_SysNo from REL_Famous_KeyWord where KeyWord_SysNo="+key+")";
            }
            if (status != "" && status != "100")
            {
                where += " and dr=" + status;
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


        public DataTable GetTodayTopList(int count)
        {
            DataTable m_dt = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select top ").Append(count).Append(" SysNo,[Name],[FullName],[Gender],photo from SYS_Famous where istop=").Append((int)AppEnum.BOOL.True)
                    .Append(" and BirthTime>='").Append(new DateTime(AppConst.DateTimeNull.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0))
                    .Append("' and BirthTime<='").Append(new DateTime(AppConst.DateTimeNull.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59))
                    .Append("' and dr=").Append((int)AppEnum.State.normal);
                try
                {
                    m_dt = data.CmdtoDataTable(builder.ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            return m_dt;
        }
        
        #endregion

    }

}
