using System;
using System.Data;
using AppMod.CMS;
using AppDal.CMS;
using AppCmn;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace AppBll.CMS
{
    public class CMS_CategoryBll
    {
        private readonly CMS_CategoryDal dal = new CMS_CategoryDal();
        private CMS_CategoryBll()
        {
        }
        private static CMS_CategoryBll _instance;
        public static CMS_CategoryBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CMS_CategoryBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(CMS_CategoryMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(CMS_CategoryMod model)
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

        public CMS_CategoryMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法


        #region 扩展成员方法
        public DataTable GetCates(int parent)
        {
            string cachyname = "CMSCate";
            if (HttpRuntime.Cache[cachyname + parent] == null)
            {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"SELECT [SysNo]
                              ,[Name]
                              ,[ParentSysNo]
                              ,[DR]
                              ,[TS]
                          FROM [CMS_Category] where dr=").Append((int)AppEnum.State.normal)
                        .Append(" and IsHide=").Append((int)AppEnum.BOOL.False)
                       .Append(" and [ParentSysNo] = ").Append(parent).Append(" order by [Name];");
                    try
                    {
                        tables = data.CmdtoDataTable(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname + parent, tables, null, DateTime.Now.AddHours(2), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            return (HttpRuntime.Cache[cachyname + parent] as DataTable).Copy();
        }

        public DataTable GetCatesForAdmin(int parent)
        {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"SELECT [SysNo]
                              ,[Name]
                              ,[ParentSysNo]
                              ,IsHide
                              ,[DR]
                              ,[TS]
                          FROM [CMS_Category] where ")
                       .Append(" [ParentSysNo] = ").Append(parent).Append(" order by [Name];");
                    try
                    {
                        tables = data.CmdtoDataTable(builder.ToString());
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }

            return tables;
        }

        #endregion
    }

}
