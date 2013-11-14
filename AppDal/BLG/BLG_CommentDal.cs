using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.BLG;
namespace AppDal.BLG
{
    public class BLG_CommentDal
    {
        public BLG_CommentDal() { }
        private static BLG_CommentDal _instance;
        public BLG_CommentDal GetInstance()
        {
            if (_instance == null)
            { _instance = new BLG_CommentDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_CommentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLG_Comment(");
            strSql.Append("SysNo,ArticleSysNo,Title,Context,CustomerSysNo,Love,Hate,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@SysNo,@ArticleSysNo,@Title,@Context,@CustomerSysNo,@Love,@Hate,@DR,@TS)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@ArticleSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Love",SqlDbType.Int,4),
                 new SqlParameter("@Hate",SqlDbType.Int,4),
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
            if (model.Title != AppConst.StringNull)
                parameters[2].Value = model.Title;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Context != AppConst.StringNull)
                parameters[3].Value = model.Context;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[4].Value = model.CustomerSysNo;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Love != AppConst.IntNull)
                parameters[5].Value = model.Love;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Hate != AppConst.IntNull)
                parameters[6].Value = model.Hate;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.DR != AppConst.IntNull)
                parameters[7].Value = model.DR;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[8].Value = model.TS;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(BLG_CommentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLG_Comment set ");
            strSql.Append("ArticleSysNo=@ArticleSysNo,");
            strSql.Append("Title=@Title,");
            strSql.Append("Context=@Context,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("Love=@Love,");
            strSql.Append("Hate=@Hate,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@ArticleSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Love",SqlDbType.Int,4),
                 new SqlParameter("@Hate",SqlDbType.Int,4),
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
            if (model.Title != AppConst.StringNull)
                parameters[2].Value = model.Title;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Context != AppConst.StringNull)
                parameters[3].Value = model.Context;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[4].Value = model.CustomerSysNo;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Love != AppConst.IntNull)
                parameters[5].Value = model.Love;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Hate != AppConst.IntNull)
                parameters[6].Value = model.Hate;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.DR != AppConst.IntNull)
                parameters[7].Value = model.DR;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[8].Value = model.TS;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete BLG_Comment ");
            strSql.Append(" where SysNo=@SysNo");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
			new SqlParameter("@SysNo", SqlDbType.Int,4)
		};
            parameters[0].Value = SysNo;

            parameters[0].Value = System.DBNull.Value;
            parameters[0].Value = SysNo;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public BLG_CommentMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, ArticleSysNo, Title, Context, CustomerSysNo, Love, Hate, DR, TS from BLG_Comment");
            strSql.Append(" where SysNo=@SysNo");
            SqlParameter[] parameters = { 
		  new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            BLG_CommentMod model = new BLG_CommentMod();
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
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Love"].ToString() != "")
                {
                    model.Love = int.Parse(ds.Tables[0].Rows[0]["Love"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Hate"].ToString() != "")
                {
                    model.Hate = int.Parse(ds.Tables[0].Rows[0]["Hate"].ToString());
                }
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
