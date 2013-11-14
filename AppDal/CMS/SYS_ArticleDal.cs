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
    /// 数据访问类CMS_Article。
    /// </summary>
    public class SYS_ArticleDal
    {
        public SYS_ArticleDal() { }
        private static SYS_ArticleDal _instance;
        public SYS_ArticleDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_ArticleDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_ArticleMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_Article(");
            strSql.Append("Title,CustomerSysNo,KeyWords,DR,TS,Limited,ReadCount,Description,Cost)");
            strSql.Append(" values (");
            strSql.Append("@Title,@CustomerSysNo,@KeyWords,@DR,@TS,@Limited,@ReadCount,@Description,@Cost)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@KeyWords",SqlDbType.NVarChar,200),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Limited",SqlDbType.TinyInt,1),
                 new SqlParameter("@ReadCount",SqlDbType.Int,4),
                 new SqlParameter("@Description",SqlDbType.NVarChar,1000),
                 new SqlParameter("@Cost",SqlDbType.Int,4),
             };
            if (model.Title != AppConst.StringNull)
                parameters[0].Value = model.Title;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[1].Value = model.CustomerSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.KeyWords != AppConst.StringNull)
                parameters[2].Value = model.KeyWords;
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
            if (model.Limited != AppConst.IntNull)
                parameters[5].Value = model.Limited;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.ReadCount != AppConst.IntNull)
                parameters[6].Value = model.ReadCount;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Description != AppConst.StringNull)
                parameters[7].Value = model.Description;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Cost != AppConst.IntNull)
                parameters[8].Value = model.Cost;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd,parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(SYS_ArticleMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_Article set ");
            strSql.Append("Title=@Title,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("KeyWords=@KeyWords,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS,");
            strSql.Append("Limited=@Limited,");
            strSql.Append("ReadCount=@ReadCount,");
            strSql.Append("Description=@Description,");
            strSql.Append("Cost=@Cost");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@KeyWords",SqlDbType.NVarChar,200),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Limited",SqlDbType.TinyInt,1),
                 new SqlParameter("@ReadCount",SqlDbType.Int,4),
                 new SqlParameter("@Description",SqlDbType.NVarChar,1000),
                 new SqlParameter("@Cost",SqlDbType.Int,4)
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
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[2].Value = model.CustomerSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.KeyWords != AppConst.StringNull)
                parameters[3].Value = model.KeyWords;
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
            if (model.Limited != AppConst.IntNull)
                parameters[6].Value = model.Limited;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.ReadCount != AppConst.IntNull)
                parameters[7].Value = model.ReadCount;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Description != AppConst.StringNull)
                parameters[8].Value = model.Description;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.Cost != AppConst.IntNull)
                parameters[9].Value = model.Cost;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_Article ");
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

        public SYS_ArticleMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Title, CustomerSysNo, KeyWords, DR, TS, Limited, ReadCount, Description, Cost from  SYS_Article");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_ArticleMod model = new SYS_ArticleMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                model.KeyWords = ds.Tables[0].Rows[0]["KeyWords"].ToString();
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Limited"].ToString() != "")
                {
                    model.Limited = int.Parse(ds.Tables[0].Rows[0]["Limited"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReadCount"].ToString() != "")
                {
                    model.ReadCount = int.Parse(ds.Tables[0].Rows[0]["ReadCount"].ToString());
                }
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["Cost"].ToString() != "")
                {
                    model.Cost = int.Parse(ds.Tables[0].Rows[0]["Cost"].ToString());
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
