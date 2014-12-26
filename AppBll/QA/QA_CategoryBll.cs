using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
using System.Data.SqlClient;
using System.Text;
using System.Web.Caching;
using System.Web;

namespace AppBll.QA
{
    public class QA_CategoryBll
    {
        private readonly QA_CategoryDal dal = new QA_CategoryDal();
        private QA_CategoryBll()
        {
        }
        private static QA_CategoryBll _instance;
        public static QA_CategoryBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QA_CategoryBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_CategoryMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(QA_CategoryMod model)
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

        public QA_CategoryMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public DataTable GetCates(int parent)
        {
            string cachyname = "QACate";
            if (HttpRuntime.Cache[cachyname+parent] == null)
            {
                DataTable tables = new DataTable();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                        builder.Append(@"SELECT [SysNo]
                              ,[Name]
                              ,[ParentSysNo]
                              ,[TopSysNo]
                              ,[Pic]
                              ,[Intro]
                              ,[OrderID]
                              ,[DR]
                              ,[TS]
                          FROM [QA_Category] where dr=").Append((int)AppEnum.State.normal)
                           .Append(" and [ParentSysNo] = ").Append(parent).Append(" order by [OrderID];");
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

        public DataTable GetAllCates()
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
                          FROM [QA_Category] where dr=").Append((int)AppEnum.State.normal);
                       
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
        
        /// <summary>
        /// 获取目录中贴数，返回四个表，分别为总主题数，总回帖评论数，24小时内新主题数，24小时内新回帖评论数
        /// </summary>
        /// <returns></returns>
        public DataSet GetCatesPostNum()
        {
            string cachyname = "QACatePostNum";
            if (HttpRuntime.Cache[cachyname] == null)
            {
                DataSet tables = new DataSet();
                using (SQLData data = new SQLData())
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(@"

SELECT COUNT(*) as questnum
      ,[CateSysNo],(case EndTime when null then '0' else '1' end) as IsSolved
  FROM [QA_Question] where dr=0 group by [CateSysNo],(case EndTime when null then '0' else '1' end);


select * from 
(SELECT COUNT(*) as AnswerNum
      ,[CateSysNo]
  FROM QA_Answer left join [QA_Question] on QA_Answer.QuestionSysNo = QA_Question.SysNo  where QA_Answer.dr=0 group by [CateSysNo]
  ) as PP,


(SELECT COUNT(*) as CommentNum
      ,[CateSysNo]
  FROM QA_Comment left join [QA_Question] on QA_Comment.QuestionSysNo = QA_Question.SysNo where QA_Comment.dr=0 group by [CateSysNo]
) as KK where PP.CateSysNo = KK.CateSysNo;

                    SELECT COUNT(*) as questnum
      ,[CateSysNo]
  FROM [QA_Question] where datediff(day,TS,getdate())<1 and dr=0 group by [CateSysNo];


select * from 
(SELECT COUNT(*) as AnswerNum
      ,[CateSysNo]
  FROM QA_Answer left join [QA_Question] on QA_Answer.QuestionSysNo = QA_Question.SysNo where datediff(day,QA_Answer.TS,getdate())<1 and QA_Answer.dr=0 group by [CateSysNo]
  ) as PP,


(SELECT COUNT(*) as CommentNum
      ,[CateSysNo]
  FROM QA_Comment left join [QA_Question] on QA_Comment.QuestionSysNo = QA_Question.SysNo where datediff(day,QA_Comment.TS,getdate())<1 and QA_Comment.dr=0 group by [CateSysNo]
) as KK where PP.CateSysNo = KK.CateSysNo");

                    try
                    {
                        tables = data.CmdtoDataSet(builder.ToString());
                        HttpRuntime.Cache.Insert(cachyname, tables, null, DateTime.Now.AddHours(1), TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.High, null);
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            return (HttpRuntime.Cache[cachyname] as DataSet).Copy();
        }
        #endregion
    }

}
