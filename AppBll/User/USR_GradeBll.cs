using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.User;
using AppDal.User;
using AppCmn;
using System.Data;
using System.Web;

namespace AppBll.User
{
    public class USR_GradeBll
    {
        private readonly USR_GradeDal dal = new USR_GradeDal();
        private USR_GradeBll()
        {
        }
        private static USR_GradeBll _instance;
        public static USR_GradeBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_GradeBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_GradeMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(USR_GradeMod model)
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

        public USR_GradeMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法

        public DataTable GetList()
        {
            string cachyname = "UserGrade";
            if (HttpRuntime.Cache[cachyname] == null)
            {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"SELECT *
                          FROM [USR_Grade] where dr=").Append((int)AppEnum.State.normal);
                    try
                    {
                        tables = data.CmdtoDataTable(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname, tables, null, DateTime.Now.AddHours(10), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            return (HttpRuntime.Cache[cachyname] as DataTable).Copy();
        }
        #endregion
    }

}
