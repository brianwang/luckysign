using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using AppMod.CMS;
using System.Data.SqlClient;
using System.Data;

namespace AppDal.CMS
{
    /// <summary>
    /// 数据访问类CMS_Article。
    /// </summary>
    public class CMS_ArticleDal
    {
        public CMS_ArticleDal() { }
        private static CMS_ArticleDal _instance;
        public CMS_ArticleDal GetInstance()
        {
            if (_instance == null)
            { _instance = new CMS_ArticleDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(CMS_ArticleMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Article(");
            strSql.Append("ArticleSysNo,CateSysNo,Source,DR,TS,OrderID,Author)");
            strSql.Append(" values (");
            strSql.Append("@ArticleSysNo,@CateSysNo,@Source,@DR,@TS,@OrderID,@Author)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@ArticleSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CateSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Source",SqlDbType.NVarChar,100),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@OrderID",SqlDbType.Int,4),
                 new SqlParameter("@Author",SqlDbType.NVarChar,100),
             };
            if (model.ArticleSysNo != AppConst.IntNull)
                parameters[0].Value = model.ArticleSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CateSysNo != AppConst.IntNull)
                parameters[1].Value = model.CateSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Source != AppConst.StringNull)
                parameters[2].Value = model.Source;
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
            if (model.OrderID != AppConst.IntNull)
                parameters[5].Value = model.OrderID;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Author != AppConst.StringNull)
                parameters[6].Value = model.Author;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(CMS_ArticleMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Article set ");
            strSql.Append("ArticleSysNo=@ArticleSysNo,");
            strSql.Append("CateSysNo=@CateSysNo,");
            strSql.Append("Source=@Source,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("Author=@Author");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@ArticleSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CateSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Source",SqlDbType.NVarChar,100),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@OrderID",SqlDbType.Int,4),
                 new SqlParameter("@Author",SqlDbType.NVarChar,100)
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
            if (model.CateSysNo != AppConst.IntNull)
                parameters[2].Value = model.CateSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Source != AppConst.StringNull)
                parameters[3].Value = model.Source;
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
            if (model.OrderID != AppConst.IntNull)
                parameters[6].Value = model.OrderID;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Author != AppConst.StringNull)
                parameters[7].Value = model.Author;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CMS_Article ");
            strSql.Append(" where SysNo=@SysNo");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = { new SqlParameter("@SysNo", SqlDbType.Int, 4) };
            parameters[0].Value = SysNo;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public CMS_ArticleMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, ArticleSysNo, CateSysNo, Source, DR, TS, OrderID, Author from  CMS_Article");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            CMS_ArticleMod model = new CMS_ArticleMod();
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
                if (ds.Tables[0].Rows[0]["CateSysNo"].ToString() != "")
                {
                    model.CateSysNo = int.Parse(ds.Tables[0].Rows[0]["CateSysNo"].ToString());
                }
                model.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
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
