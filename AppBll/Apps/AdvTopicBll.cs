using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.Apps;
using AppDal.Apps;
using AppCmn;
using System.Data;
using System.Web;

namespace AppBll.Apps
{
    public class AdvTopicBll
    {
        private readonly AdvTopicDal dal = new AdvTopicDal();
        private static AdvTopicBll _instance;
        public static AdvTopicBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AdvTopicBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(AdvTopicMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(AdvTopicMod model)
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

        public AdvTopicMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region  扩展成员方法
        public DataTable GetTopicList()
        {
            string cachyname = "AdvTopic";
            if (HttpRuntime.Cache[cachyname] == null)
            {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"SELECT * FROM [AdvTopic] where dr=").Append((int)AppEnum.State.normal);
                    try
                    {
                        tables = data.CmdtoDataTable(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname, tables, null, DateTime.Now.AddHours(2), TimeSpan.Zero,
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
