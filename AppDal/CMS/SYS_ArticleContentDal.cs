using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.CMS;

namespace AppDal.CMS
{
    /// <summary>
    /// 数据访问类SYS_ArticleContent。
    /// </summary>
    public class SYS_ArticleContentDal
    {
        public SYS_ArticleContentDal() { }
        private static SYS_ArticleContentDal _instance;
        public SYS_ArticleContentDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_ArticleContentDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_ArticleContentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_ArticleContent(");
            strSql.Append("ArticleSysNo,Page,Context,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@ArticleSysNo,@Page,@Context,@DR,@TS)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@ArticleSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Page",SqlDbType.Int,4),
                 new SqlParameter("@Context",SqlDbType.NVarChar,-1),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.ArticleSysNo != AppConst.IntNull)
                parameters[0].Value = model.ArticleSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Page != AppConst.IntNull)
                parameters[1].Value = model.Page;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Context != AppConst.StringNull)
                parameters[2].Value = model.Context;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.DR != AppConst.IntNull)
                parameters[3].Value = model.DR;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[4].Value = model.TS;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(SYS_ArticleContentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_ArticleContent set ");
            strSql.Append("ArticleSysNo=@ArticleSysNo,");
            strSql.Append("Page=@Page,");
            strSql.Append("Context=@Context,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@ArticleSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Page",SqlDbType.Int,4),
                 new SqlParameter("@Context",SqlDbType.NVarChar,-1),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.ArticleSysNo != AppConst.IntNull)
                parameters[1].Value = model.ArticleSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Page != AppConst.IntNull)
                parameters[2].Value = model.Page;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Context != AppConst.StringNull)
                parameters[3].Value = model.Context;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.DR != AppConst.IntNull)
                parameters[4].Value = model.DR;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[5].Value = model.TS;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_ArticleContent ");
            strSql.Append(" where SysNo=@SysNo");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = { new SqlParameter("@SysNo", SqlDbType.Int, 4) };
            parameters[0].Value = SysNo;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public SYS_ArticleContentMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, ArticleSysNo, Page, Context, DR, TS from  SYS_ArticleContent");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_ArticleContentMod model = new SYS_ArticleContentMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ArticleSysNo"].ToString() != "")
                {
                    model.ArticleSysNo = int.Parse(ds.Tables[0].Rows[0]["ArticleSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Page"].ToString() != "")
                {
                    model.Page = int.Parse(ds.Tables[0].Rows[0]["Page"].ToString());
                }
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion  成员方法
    }

}
