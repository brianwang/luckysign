using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AppMod.BLG;
using AppCmn;

namespace AppDal.BLG
{
    public class BLG_ReplyDal
    {
        public BLG_ReplyDal() { }
        private static BLG_ReplyDal _instance;
        public BLG_ReplyDal GetInstance()
        {
            if (_instance == null)
            { _instance = new BLG_ReplyDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_ReplyMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLG_Reply(");
            strSql.Append("CommentSysNo,Title,Context,CustomerSysNo,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@CommentSysNo,@Title,@Context,@CustomerSysNo,@DR,@TS)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CommentSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.CommentSysNo != AppConst.IntNull)
                parameters[0].Value = model.CommentSysNo;
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

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(BLG_ReplyMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLG_Reply set ");
            strSql.Append("CommentSysNo=@CommentSysNo,");
            strSql.Append("Title=@Title,");
            strSql.Append("Context=@Context,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CommentSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CommentSysNo != AppConst.IntNull)
                parameters[1].Value = model.CommentSysNo;
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
            if (model.DR != AppConst.IntNull)
                parameters[5].Value = model.DR;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[6].Value = model.TS;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete BLG_Reply ");
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

        public BLG_ReplyMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CommentSysNo, Title, Context, CustomerSysNo, DR, TS from  BLG_Reply");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            BLG_ReplyMod model = new BLG_ReplyMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CommentSysNo"].ToString() != "")
                {
                    model.CommentSysNo = int.Parse(ds.Tables[0].Rows[0]["CommentSysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
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
