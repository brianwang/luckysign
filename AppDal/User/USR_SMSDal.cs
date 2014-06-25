using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using AppMod.User;
using System.Data;
using System.Data.SqlClient;

namespace AppDal.User
{
    public class USR_SMSDal
    {
        public USR_SMSDal() { }
        private static USR_SMSDal _instance;
        public USR_SMSDal GetInstance()
        {
            if (_instance == null)
            { _instance = new USR_SMSDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_SMSMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_SMS(");
            strSql.Append("FromSysNo,ToSysNo,Title,Context,IsRead,IsFromDeleted,IsToDeleted,Parent,DR,TS,ReplyCount)");
            strSql.Append(" values (");
            strSql.Append("@FromSysNo,@ToSysNo,@Title,@Context,@IsRead,@IsFromDeleted,@IsToDeleted,@Parent,@DR,@TS,@ReplyCount)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@FromSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ToSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@IsRead",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsFromDeleted",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsToDeleted",SqlDbType.TinyInt,1),
                 new SqlParameter("@Parent",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@ReplyCount",SqlDbType.Int,4),
             };
            if (model.FromSysNo != AppConst.IntNull)
                parameters[0].Value = model.FromSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.ToSysNo != AppConst.IntNull)
                parameters[1].Value = model.ToSysNo;
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
            if (model.IsRead != AppConst.IntNull)
                parameters[4].Value = model.IsRead;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.IsFromDeleted != AppConst.IntNull)
                parameters[5].Value = model.IsFromDeleted;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.IsToDeleted != AppConst.IntNull)
                parameters[6].Value = model.IsToDeleted;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Parent != AppConst.IntNull)
                parameters[7].Value = model.Parent;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.DR != AppConst.IntNull)
                parameters[8].Value = model.DR;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[9].Value = model.TS;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.ReplyCount != AppConst.IntNull)
                parameters[10].Value = model.ReplyCount;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(USR_SMSMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_SMS set ");
            strSql.Append("FromSysNo=@FromSysNo,");
            strSql.Append("ToSysNo=@ToSysNo,");
            strSql.Append("Title=@Title,");
            strSql.Append("Context=@Context,");
            strSql.Append("IsRead=@IsRead,");
            strSql.Append("IsFromDeleted=@IsFromDeleted,");
            strSql.Append("IsToDeleted=@IsToDeleted,");
            strSql.Append("Parent=@Parent,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS,");
            strSql.Append("ReplyCount=@ReplyCount");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@FromSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ToSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@IsRead",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsFromDeleted",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsToDeleted",SqlDbType.TinyInt,1),
                 new SqlParameter("@Parent",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@ReplyCount",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.FromSysNo != AppConst.IntNull)
                parameters[1].Value = model.FromSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.ToSysNo != AppConst.IntNull)
                parameters[2].Value = model.ToSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Title != AppConst.StringNull)
                parameters[3].Value = model.Title;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Context != AppConst.StringNull)
                parameters[4].Value = model.Context;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.IsRead != AppConst.IntNull)
                parameters[5].Value = model.IsRead;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.IsFromDeleted != AppConst.IntNull)
                parameters[6].Value = model.IsFromDeleted;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.IsToDeleted != AppConst.IntNull)
                parameters[7].Value = model.IsToDeleted;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Parent != AppConst.IntNull)
                parameters[8].Value = model.Parent;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.DR != AppConst.IntNull)
                parameters[9].Value = model.DR;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[10].Value = model.TS;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.ReplyCount != AppConst.IntNull)
                parameters[11].Value = model.ReplyCount;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete USR_SMS ");
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

        public USR_SMSMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, FromSysNo, ToSysNo, Title, Context, IsRead, IsFromDeleted, IsToDeleted, Parent, DR, TS, ReplyCount from  USR_SMS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            USR_SMSMod model = new USR_SMSMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FromSysNo"].ToString() != "")
                {
                    model.FromSysNo = int.Parse(ds.Tables[0].Rows[0]["FromSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ToSysNo"].ToString() != "")
                {
                    model.ToSysNo = int.Parse(ds.Tables[0].Rows[0]["ToSysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["IsRead"].ToString() != "")
                {
                    model.IsRead = int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsFromDeleted"].ToString() != "")
                {
                    model.IsFromDeleted = int.Parse(ds.Tables[0].Rows[0]["IsFromDeleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsToDeleted"].ToString() != "")
                {
                    model.IsToDeleted = int.Parse(ds.Tables[0].Rows[0]["IsToDeleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Parent"].ToString() != "")
                {
                    model.Parent = int.Parse(ds.Tables[0].Rows[0]["Parent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReplyCount"].ToString() != "")
                {
                    model.ReplyCount = int.Parse(ds.Tables[0].Rows[0]["ReplyCount"].ToString());
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
