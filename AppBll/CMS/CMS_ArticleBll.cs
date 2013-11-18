using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.CMS;
using AppDal.CMS;
using AppCmn;
using System.Data;
using System.Web;

namespace AppBll.CMS
{
    public class CMS_ArticleBll
    {
        private readonly CMS_ArticleDal dal = new CMS_ArticleDal();
        private CMS_ArticleBll()
        {
        }
        private static CMS_ArticleBll _instance;
        public static CMS_ArticleBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CMS_ArticleBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(CMS_ArticleMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(CMS_ArticleMod model)
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

        public CMS_ArticleMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public DataTable GetList(int pagesize, int pageindex, string key, int cate,int usersysno, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "CMS_ArticleView.OrderID desc, CMS_ArticleView.SysNo desc";

            #region  设置参数
            columns = @"CMS_ArticleView.[SysNo]
                      ,[ArticleSysNo]
                      ,[CateSysNo]
                      ,[Name]
                      ,[Source]
                      ,CMS_ArticleView.[DR]
                      ,CMS_ArticleView.[TS]
                      ,[OrderID]
                      ,[Title]
                      ,[CustomerSysNo]
                      ,[KeyWords]
                      ,[Limited]
                      ,[ReadCount]
                      ,[Description]
                      ,[Cost]";
            tables = "CMS_ArticleView left join CMS_Category on CateSysNo = CMS_Category.SysNo";
            where = "CMS_ArticleView.dr=" + (int)AppEnum.State.normal;
            if (key != "")
            {
                where += " and (";
                string[] tmpstr = key.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " ([Title] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' or KeyWords like '%" + SQLData.SQLFilter(tmpstr[i]) + "%') and ";
                }
                where += " 1=1)";
            }
            if (cate != 0)
            {
                where += " and CateSysNo in (select SysNo from CMS_Category where SysNo=" + cate + " or ParentSysNo=" + cate + " or TopSysNo=" + cate + ")";
            }
            if (usersysno != 0)
            {
                where += " and CustomerSysNo=" + usersysno;
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
        public DataTable GetList(int pagesize, int pageindex, string key, int cate, int status, int usersysno, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "OrderID desc, CMS_ArticleView.SysNo desc";

            #region  设置参数
            columns = @"CMS_ArticleView.[SysNo]
                      ,[ArticleSysNo]
                      ,[CateSysNo]
                      ,[Name]
                      ,[Source]
                      ,CMS_ArticleView.[DR]
                      ,CMS_ArticleView.[TS]
                      ,[OrderID]
                      ,[Title]
                      ,[CustomerSysNo]
                      ,[KeyWords]
                      ,[Limited]
                      ,[ReadCount]
                      ,[Description]
                      ,[Cost]";
            tables = "CMS_ArticleView left join CMS_Category on CateSysNo = CMS_Category.SysNo";
            where = "1=1";
            if (status != 100)
            {
                where += " and CMS_ArticleView.dr=" + status;
            }
            if (key != "")
            {
                where += " and (";
                string[] tmpstr = key.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " [Title] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' and ";
                }
                where += " 1=1)";
            }
            if (cate != 0)
            {
                where += " and CateSysNo=" + cate;
            }
            if (usersysno != 0)
            {
                where += " and CustomerSysNo=" + usersysno;
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

        public DataTable GetIndexCateArticle(int count, int cate)
        {
            string cachyname = "IndexArticle";
            if (HttpRuntime.Cache[cachyname + cate.ToString() + "-" + count.ToString()] == null)
            {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"SELECT top " + count + @" [SysNo]
                                      ,[ArticleSysNo]
                                      ,[CateSysNo]
                                      ,[KeyWords]
                                      ,[TS]
                                      ,[OrderID]
                                      ,[Title]
                                      ,Description
                                      ,ReadCount
                                  FROM CMS_ArticleView where CateSysNo in (select SysNo from CMS_Category where SysNo=").Append(cate).Append(" or TopSysNo=").Append(cate).Append(" and dr=").Append((int)AppEnum.State.normal).Append(") and dr=").Append((int)AppEnum.State.normal);
                    builder.Append(" order by [OrderID] desc, [TS] desc;");
                    try
                    {
                        tables = data.CmdtoDataTable(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname + cate.ToString() + "-" + count.ToString(), tables, null, DateTime.Now.AddHours(2), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            return (HttpRuntime.Cache[cachyname + cate.ToString() + "-" + count.ToString()] as DataTable).Copy();
        }

        public DataSet GetRecommendList(int count)
        {
            string cachyname = "CMSRecommend";
            if (HttpRuntime.Cache[cachyname + "-" + count.ToString()] == null)
            {
                DataSet tables = new DataSet();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    //最新
                    builder.Append(@"SELECT top " + count + @" [SysNo]
                      ,[ArticleSysNo]
                      ,[CateSysNo]
                      ,[Source]
                      ,[DR]
                      ,[TS]
                      ,[OrderID]
                      ,[Title]
                      ,[CustomerSysNo]
                      ,[KeyWords]
                      ,[Limited]
                      ,[ReadCount]
                      ,[Description]
                      ,[Cost]
                                  FROM [CMS_ArticleView] where dr=").Append((int)AppEnum.State.normal);
                    builder.Append(" order by TS desc;");
                    //推荐
                    builder.Append(@"SELECT top " + count + @" [SysNo]
                      ,[ArticleSysNo]
                      ,[CateSysNo]
                      ,[Source]
                      ,[DR]
                      ,[TS]
                      ,[OrderID]
                      ,[Title]
                      ,[CustomerSysNo]
                      ,[KeyWords]
                      ,[Limited]
                      ,[ReadCount]
                      ,[Description]
                      ,[Cost]
                                  FROM [CMS_ArticleView] where dr=").Append((int)AppEnum.State.normal);
                    builder.Append(" order by [OrderID] desc;");
                    //最热
                    builder.Append(@"SELECT top " + count + @" [SysNo]
                      ,[ArticleSysNo]
                      ,[CateSysNo]
                      ,[Source]
                      ,[DR]
                      ,[TS]
                      ,[OrderID]
                      ,[Title]
                      ,[CustomerSysNo]
                      ,[KeyWords]
                      ,[Limited]
                      ,[ReadCount]
                      ,[Description]
                      ,[Cost]
                                  FROM [CMS_ArticleView] where dr=").Append((int)AppEnum.State.normal);
                    builder.Append(" order by [ReadCount] desc;");

                    try
                    {
                        tables = data.CmdtoDataSet(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname + "-" + count.ToString(), tables, null, DateTime.Now.AddHours(2), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            return (HttpRuntime.Cache[cachyname + "-" + count.ToString()] as DataSet).Copy();
        }


        public Dictionary<int, string[]> GetNeighbour(int SysNo, int Cate)
        {
            Dictionary<int, string[]> ret = new Dictionary<int, string[]>();
            DataSet m_dt = new DataSet();
            string strsql = "select top 1 sysno,ArticleSysno,title,OrderID from CMS_ArticleView where (OrderID>(select OrderID from CMS_ArticleView where sysno=" + SysNo + ") or sysno<" + SysNo + ") and CateSysNo=" + Cate + " order by OrderID asc,sysno desc;" +
                " select top 1 sysno,ArticleSysno,title,OrderID from CMS_ArticleView where (OrderID<(select OrderID from CMS_ArticleView where sysno=" + SysNo + ") or sysno>" + SysNo + ") and CateSysNo=" + Cate + " order by OrderID desc,sysno asc";

            using (SQLData m_data = new SQLData())
            {
                try
                {
                    m_dt = m_data.CmdtoDataSet(strsql);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            if(m_dt.Tables[0].Rows.Count>0)
            {
                string[] tmp = new string[3];
                tmp[0] = m_dt.Tables[0].Rows[0]["SysNo"].ToString();
                tmp[1] = m_dt.Tables[0].Rows[0]["title"].ToString();
                tmp[2] = m_dt.Tables[0].Rows[0]["OrderID"].ToString();
                ret.Add(0, tmp);
            }

            if(m_dt.Tables[1].Rows.Count>0)
            {
                string[] tmp = new string[3];
                tmp[0] = m_dt.Tables[1].Rows[0]["SysNo"].ToString();
                tmp[1] = m_dt.Tables[1].Rows[0]["title"].ToString();
                tmp[2] = m_dt.Tables[1].Rows[0]["OrderID"].ToString();
                ret.Add(1, tmp);
            }

            return ret;
        }
        #endregion
    }

}
