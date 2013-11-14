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
    public class USR_ThirdLoginDal
    {
        public USR_ThirdLoginDal() { }
        private static USR_ThirdLoginDal _instance;
        public USR_ThirdLoginDal GetInstance()
        {
            if (_instance == null)
            { _instance = new USR_ThirdLoginDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_ThirdLoginMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_ThirdLogin(");
            strSql.Append("CustomerSysNo,OpenID,AccessKey,ExpireTime,ThirdType)");
            strSql.Append(" values (");
            strSql.Append("@CustomerSysNo,@OpenID,@AccessKey,@ExpireTime,@ThirdType)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@OpenID",SqlDbType.VarChar,100),
                 new SqlParameter("@AccessKey",SqlDbType.VarChar,100),
                 new SqlParameter("@ExpireTime",SqlDbType.DateTime),
                 new SqlParameter("@ThirdType",SqlDbType.Int,4),
             };
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[0].Value = model.CustomerSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.OpenID != AppConst.StringNull)
                parameters[1].Value = model.OpenID;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.AccessKey != AppConst.StringNull)
                parameters[2].Value = model.AccessKey;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.ExpireTime != AppConst.DateTimeNull)
                parameters[3].Value = model.ExpireTime;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.ThirdType != AppConst.IntNull)
                parameters[4].Value = model.ThirdType;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(USR_ThirdLoginMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_ThirdLogin set ");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("OpenID=@OpenID,");
            strSql.Append("AccessKey=@AccessKey,");
            strSql.Append("ExpireTime=@ExpireTime,");
            strSql.Append("ThirdType=@ThirdType");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@OpenID",SqlDbType.VarChar,100),
                 new SqlParameter("@AccessKey",SqlDbType.VarChar,100),
                 new SqlParameter("@ExpireTime",SqlDbType.DateTime),
                 new SqlParameter("@ThirdType",SqlDbType.Int,4)
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
            if (model.OpenID != AppConst.StringNull)
                parameters[2].Value = model.OpenID;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.AccessKey != AppConst.StringNull)
                parameters[3].Value = model.AccessKey;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.ExpireTime != AppConst.DateTimeNull)
                parameters[4].Value = model.ExpireTime;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.ThirdType != AppConst.IntNull)
                parameters[5].Value = model.ThirdType;
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
            strSql.Append("delete USR_ThirdLogin ");
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

        public USR_ThirdLoginMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerSysNo, OpenID, AccessKey, ExpireTime, ThirdType from  USR_ThirdLogin");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            USR_ThirdLoginMod model = new USR_ThirdLoginMod();
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
                model.OpenID = ds.Tables[0].Rows[0]["OpenID"].ToString();
                model.AccessKey = ds.Tables[0].Rows[0]["AccessKey"].ToString();
                if (ds.Tables[0].Rows[0]["ExpireTime"].ToString() != "")
                {
                    model.ExpireTime = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ThirdType"].ToString() != "")
                {
                    model.ThirdType = int.Parse(ds.Tables[0].Rows[0]["ThirdType"].ToString());
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
