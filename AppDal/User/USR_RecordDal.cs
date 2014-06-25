using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.User;

namespace AppDal.User
{
    /// <summary>
    /// 数据访问类USR_Record。
    /// </summary>
    public class USR_RecordDal
    {
        public USR_RecordDal() { }
        private static USR_RecordDal _instance;
        public USR_RecordDal GetInstance()
        {
            if (_instance == null)
            { _instance = new USR_RecordDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_RecordMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_Record(");
            strSql.Append("CustomerSysNo,TargetSysNo,TargetValue,Type,TS)");
            strSql.Append(" values (");
            strSql.Append("@CustomerSysNo,@TargetSysNo,@TargetValue,@Type,@TS)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TargetSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TargetValue",SqlDbType.Int,4),
                 new SqlParameter("@Type",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[0].Value = model.CustomerSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.TargetSysNo != AppConst.IntNull)
                parameters[1].Value = model.TargetSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.TargetValue != AppConst.IntNull)
                parameters[2].Value = model.TargetValue;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Type != AppConst.IntNull)
                parameters[3].Value = model.Type;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[4].Value = model.TS;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(USR_RecordMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_Record set ");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("TargetSysNo=@TargetSysNo,");
            strSql.Append("TargetValue=@TargetValue,");
            strSql.Append("Type=@Type,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TargetSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TargetValue",SqlDbType.Int,4),
                 new SqlParameter("@Type",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[1].Value = model.CustomerSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.TargetSysNo != AppConst.IntNull)
                parameters[2].Value = model.TargetSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TargetValue != AppConst.IntNull)
                parameters[3].Value = model.TargetValue;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Type != AppConst.IntNull)
                parameters[4].Value = model.Type;
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
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete USR_Record ");
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

        public USR_RecordMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerSysNo, TargetSysNo, TargetValue, Type, TS from  USR_Record");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            USR_RecordMod model = new USR_RecordMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TargetSysNo"].ToString() != "")
                {
                    model.TargetSysNo = int.Parse(ds.Tables[0].Rows[0]["TargetSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TargetValue"].ToString() != "")
                {
                    model.TargetValue = int.Parse(ds.Tables[0].Rows[0]["TargetValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
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
