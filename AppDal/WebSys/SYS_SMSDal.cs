using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.WebSys;
namespace AppDal.WebSys
{
    /// <summary>
    /// 数据访问类SYS_SMS。
    /// </summary>
    public class SYS_SMSDal
    {
        public SYS_SMSDal() { }
        private static SYS_SMSDal _instance;
        public SYS_SMSDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_SMSDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SYS_SMSMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_SMS(");
            strSql.Append("Content,TS,Status,ReturnCode,CustomerSysNo,Type,PhoneNum,SendTime)");
            strSql.Append(" values (");
            strSql.Append("@Content,@TS,@Status,@ReturnCode,@CustomerSysNo,@Type,@PhoneNum,@SendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Content",SqlDbType.NVarChar,600),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Status",SqlDbType.Int,4),
                 new SqlParameter("@ReturnCode",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Type",SqlDbType.Int,4),
                 new SqlParameter("@PhoneNum",SqlDbType.VarChar,50),
                 new SqlParameter("@SendTime",SqlDbType.DateTime),
             };
            if (model.Content != AppConst.StringNull)
                parameters[0].Value = model.Content;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[1].Value = model.TS;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Status != AppConst.IntNull)
                parameters[2].Value = model.Status;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.ReturnCode != AppConst.IntNull)
                parameters[3].Value = model.ReturnCode;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[4].Value = model.CustomerSysNo;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Type != AppConst.IntNull)
                parameters[5].Value = model.Type;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.PhoneNum != AppConst.StringNull)
                parameters[6].Value = model.PhoneNum;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.SendTime != AppConst.DateTimeNull)
                parameters[7].Value = model.SendTime;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(SYS_SMSMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_SMS set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Content != AppConst.StringNull)
            {
                strSql.Append("Content=@Content,");
                SqlParameter param = new SqlParameter("@Content", SqlDbType.NVarChar, 600);
                param.Value = model.Content;
                cmd.Parameters.Add(param);
            }
            if (model.TS != AppConst.DateTimeNull)
            {
                strSql.Append("TS=@TS,");
                SqlParameter param = new SqlParameter("@TS", SqlDbType.DateTime);
                param.Value = model.TS;
                cmd.Parameters.Add(param);
            }
            if (model.Status != AppConst.IntNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.Int, 4);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.ReturnCode != AppConst.IntNull)
            {
                strSql.Append("ReturnCode=@ReturnCode,");
                SqlParameter param = new SqlParameter("@ReturnCode", SqlDbType.Int, 4);
                param.Value = model.ReturnCode;
                cmd.Parameters.Add(param);
            }
            if (model.CustomerSysNo != AppConst.IntNull)
            {
                strSql.Append("CustomerSysNo=@CustomerSysNo,");
                SqlParameter param = new SqlParameter("@CustomerSysNo", SqlDbType.Int, 4);
                param.Value = model.CustomerSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Type != AppConst.IntNull)
            {
                strSql.Append("Type=@Type,");
                SqlParameter param = new SqlParameter("@Type", SqlDbType.Int, 4);
                param.Value = model.Type;
                cmd.Parameters.Add(param);
            }
            if (model.PhoneNum != AppConst.StringNull)
            {
                strSql.Append("PhoneNum=@PhoneNum,");
                SqlParameter param = new SqlParameter("@PhoneNum", SqlDbType.VarChar, 50);
                param.Value = model.PhoneNum;
                cmd.Parameters.Add(param);
            }
            if (model.SendTime != AppConst.DateTimeNull)
            {
                strSql.Append("SendTime=@SendTime,");
                SqlParameter param = new SqlParameter("@SendTime", SqlDbType.DateTime);
                param.Value = model.SendTime;
                cmd.Parameters.Add(param);
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append(" where SysNo=@SysNo ");
            cmd.CommandText = strSql.ToString();
            return SqlHelper.ExecuteNonQuery(cmd, null);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_SMS ");
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
        public SYS_SMSMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Content, TS, Status, ReturnCode, CustomerSysNo, Type, PhoneNum, SendTime from  dbo.SYS_SMS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_SMSMod model = new SYS_SMSMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnCode"].ToString() != "")
                {
                    model.ReturnCode = int.Parse(ds.Tables[0].Rows[0]["ReturnCode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                model.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                if (ds.Tables[0].Rows[0]["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
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
