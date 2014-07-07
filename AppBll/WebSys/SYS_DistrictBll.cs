using System;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;

namespace AppBll.WebSys
{
    public class SYS_DistrictBll
    {
        private readonly SYS_DistrictDal dal = new SYS_DistrictDal();
        private SYS_DistrictBll()
        {
        }
        private static SYS_DistrictBll _instance;
        public static SYS_DistrictBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_DistrictBll();
            }
            return _instance;
        }

        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_DistrictMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(SYS_DistrictMod model)
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

        public SYS_DistrictMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public enum SpecialDistrict
        {
            [Description("海外")]
            abroad = 35,
            [Description("其他")]
            other = 36,
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UseType">全部则为0</param>
        /// <returns></returns>
        public DataTable GetFirstLevel(int UseType)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select [SysNo]
                  ,[UpSysNo]
                  ,[Name]
                  ,[EnglishName]
                  ,[Level]
                  ,[UseType]
                  ,[DR]
                  ,[TS]
                  ,[Latitude]
                  ,[longitude] 
                 from [SYS_District] where [Level]=1 and dr=").Append((int)AppEnum.State.normal);
                if (UseType != 0 && UseType != AppConst.IntNull)
                {
                    builder.Append(" and usetype=").Append(UseType);
                }
                builder.Append(" order by [Name] desc");

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

        public DataTable GetSubLevel(int upSysNo)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select [SysNo]
                  ,[UpSysNo]
                  ,[Name]
                  ,[EnglishName]
                  ,[Level]
                  ,[UseType]
                  ,[DR]
                  ,[TS]
                  ,[Latitude]
                  ,[longitude] 
                 from [SYS_District] where upsysno=").Append(upSysNo).Append(" and dr=").Append((int)AppEnum.State.normal)
                                                    .Append(" order by [Name]");
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

        /// <summary>
        /// 获取第三级元素的上级树结构
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public DataTable GetTreeDetail(int SysNo)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select *
                 from [District3Level] where SysNo3=").Append(SysNo).Append(@" union select *
                 from [District3Level] where SysNo2=").Append(SysNo).Append(@" union select *
                 from [District3Level] where SysNo1=").Append(SysNo);
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
        public DataTable GetTreeDetail(string name)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select *
                 from [District3Level] where (Name3='").Append(SQLData.SQLFilter(name)).Append("' or EnglishName3='").Append(SQLData.SQLFilter(name)).Append("')");
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

        public DataTable GetInfoByPoi(string lat, string lng)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select * 
                 from [District3Level] where [longitude3]=").Append(SQLData.SQLFilter(lng)).Append(" and [Latitude3]=").Append(SQLData.SQLFilter(lat));

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
        public SYS_DistrictMod GetNearestByPoi(string lng, string lat)
        {
            DataTable table = new DataTable();
            SYS_DistrictMod m_dist = new SYS_DistrictMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select top 1 sysno 
                 from [Sys_District] where level=3 and englishname is null and ABS([longitude]-").Append(SQLData.SQLFilter(lng)).Append(")<3 and ABS([Latitude]-").Append(SQLData.SQLFilter(lat)).Append(")<3 order by SQUARE([longitude]-").Append(SQLData.SQLFilter(lng)).Append(")+ SQUARE([Latitude]-").Append(SQLData.SQLFilter(lat)).Append(")");

                //try
                //{
                    table = data.CmdtoDataTable(builder.ToString());
                //}
                //catch (Exception exception)
                //{
                //    throw exception;
                //}
                if (table.Rows.Count > 0)
                {
                    m_dist = GetModel(int.Parse(table.Rows[0]["sysno"].ToString()));
                    table = data.CmdtoDataTable("select * from [District3Level] where SysNo3="+m_dist.SysNo);
                    m_dist.Name = (table.Rows[0]["Name1"].ToString() +"-"+ table.Rows[0]["Name2"].ToString()+"-" + table.Rows[0]["Name3"].ToString()).Replace("市辖区-","");
                }
                else
                {
                    return null;
                }
            }
            return m_dist;
        }
        #endregion
    }
}
