using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.BLG;

namespace AppDal.BLG
{
    public class BLG_ArticleDal
    {
        public BLG_ArticleDal() { }
        private static BLG_ArticleDal _instance;
        public BLG_ArticleDal GetInstance()
        {
            if (_instance == null)
            { _instance = new BLG_ArticleDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_ArticleMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLG_Article(");
            strSql.Append("Title,Context,CustomerSysNo,LastReplyTime,Love,Hate,Spread,Type,TargetUrl,ChartSysNo,CommentCount,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Context,@CustomerSysNo,@LastReplyTime,@Love,@Hate,@Spread,@Type,@TargetUrl,@ChartSysNo,@CommentCount,@DR,@TS)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Title",SqlDbType.NVarChar,1000),
                 new SqlParameter("@Context",SqlDbType.NText,2147483646),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@LastReplyTime",SqlDbType.DateTime),
                 new SqlParameter("@Love",SqlDbType.Int,4),
                 new SqlParameter("@Hate",SqlDbType.Int,4),
                 new SqlParameter("@Spread",SqlDbType.Int,4),
                 new SqlParameter("@Type",SqlDbType.Int,4),
                 new SqlParameter("@TargetUrl",SqlDbType.NVarChar,600),
                 new SqlParameter("@ChartSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CommentCount",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.Title != AppConst.StringNull)
                parameters[0].Value = model.Title;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Context != AppConst.StringNull)
                parameters[1].Value = model.Context;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[2].Value = model.CustomerSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.LastReplyTime != AppConst.DateTimeNull)
                parameters[3].Value = model.LastReplyTime;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Love != AppConst.IntNull)
                parameters[4].Value = model.Love;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Hate != AppConst.IntNull)
                parameters[5].Value = model.Hate;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Spread != AppConst.IntNull)
                parameters[6].Value = model.Spread;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Type != AppConst.IntNull)
                parameters[7].Value = model.Type;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.TargetUrl != AppConst.StringNull)
                parameters[8].Value = model.TargetUrl;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.ChartSysNo != AppConst.IntNull)
                parameters[9].Value = model.ChartSysNo;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.CommentCount != AppConst.IntNull)
                parameters[10].Value = model.CommentCount;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.DR != AppConst.IntNull)
                parameters[11].Value = model.DR;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[12].Value = model.TS;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(BLG_ArticleMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLG_Article set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Context=@Context,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("LastReplyTime=@LastReplyTime,");
            strSql.Append("Love=@Love,");
            strSql.Append("Hate=@Hate,");
            strSql.Append("Spread=@Spread,");
            strSql.Append("Type=@Type,");
            strSql.Append("TargetUrl=@TargetUrl,");
            strSql.Append("ChartSysNo=@ChartSysNo,");
            strSql.Append("CommentCount=@CommentCount,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,1000),
                 new SqlParameter("@Context",SqlDbType.NText,2147483646),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@LastReplyTime",SqlDbType.DateTime),
                 new SqlParameter("@Love",SqlDbType.Int,4),
                 new SqlParameter("@Hate",SqlDbType.Int,4),
                 new SqlParameter("@Spread",SqlDbType.Int,4),
                 new SqlParameter("@Type",SqlDbType.Int,4),
                 new SqlParameter("@TargetUrl",SqlDbType.NVarChar,600),
                 new SqlParameter("@ChartSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CommentCount",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Title != AppConst.StringNull)
                parameters[1].Value = model.Title;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Context != AppConst.StringNull)
                parameters[2].Value = model.Context;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[3].Value = model.CustomerSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.LastReplyTime != AppConst.DateTimeNull)
                parameters[4].Value = model.LastReplyTime;
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
            if (model.Spread != AppConst.IntNull)
                parameters[7].Value = model.Spread;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Type != AppConst.IntNull)
                parameters[8].Value = model.Type;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.TargetUrl != AppConst.StringNull)
                parameters[9].Value = model.TargetUrl;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.ChartSysNo != AppConst.IntNull)
                parameters[10].Value = model.ChartSysNo;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.CommentCount != AppConst.IntNull)
                parameters[11].Value = model.CommentCount;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.DR != AppConst.IntNull)
                parameters[12].Value = model.DR;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[13].Value = model.TS;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete BLG_Article ");
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

        public BLG_ArticleMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Title, Context, CustomerSysNo, LastReplyTime, Love, Hate, Spread, Type, TargetUrl, ChartSysNo, CommentCount, DR, TS from  BLG_Article");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            BLG_ArticleMod model = new BLG_ArticleMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastReplyTime"].ToString() != "")
                {
                    model.LastReplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastReplyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Love"].ToString() != "")
                {
                    model.Love = int.Parse(ds.Tables[0].Rows[0]["Love"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Hate"].ToString() != "")
                {
                    model.Hate = int.Parse(ds.Tables[0].Rows[0]["Hate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Spread"].ToString() != "")
                {
                    model.Spread = int.Parse(ds.Tables[0].Rows[0]["Spread"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                model.TargetUrl = ds.Tables[0].Rows[0]["TargetUrl"].ToString();
                if (ds.Tables[0].Rows[0]["ChartSysNo"].ToString() != "")
                {
                    model.ChartSysNo = int.Parse(ds.Tables[0].Rows[0]["ChartSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CommentCount"].ToString() != "")
                {
                    model.CommentCount = int.Parse(ds.Tables[0].Rows[0]["CommentCount"].ToString());
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
