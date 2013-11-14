using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
using System.Web;
using System.Text;

namespace AppBll.QA
{
    public class QA_StarBll
    {
        private readonly QA_StarDal dal = new QA_StarDal();
        private QA_StarBll()
        {
        }
        private static QA_StarBll _instance;
        public static QA_StarBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QA_StarBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(QA_StarMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(QA_StarMod model)
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

        public QA_StarMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public DataTable GetStarsList(int count,int type)
        {
            string cachyname = "QAStars";
            if (HttpRuntime.Cache[cachyname + type.ToString() + "-" + count.ToString()] == null)
            {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"SELECT top " + count + @" [QA_Star].[SysNo]
                                      ,[NickName]
                                      ,[CustomerSysNo]
                                      ,[OrderID]
                                      ,[QA_Star].[Intro]
                                      ,[QA_Star].[FateType]
                                      ,[Photo]
                                      ,[Credit]
                                      ,[Point]
                                  FROM [QA_Star] left join USR_Customer on CustomerSysNo = USR_Customer.SysNo where status=").Append((int)AppEnum.State.normal);
                    if(type!= 0)
                    {
                        builder.Append(" and [FateType] = ").Append(type);
                    }
                    builder.Append(" order by [OrderID] desc;");
                    try
                    {
                        tables = data.CmdtoDataTable(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname + type.ToString() + "-" + count.ToString(), tables, null, DateTime.Now.AddHours(2), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            return (HttpRuntime.Cache[cachyname + type.ToString() + "-" + count.ToString()] as DataTable).Copy();
        }

        #endregion 扩展成员方法
    }

}
