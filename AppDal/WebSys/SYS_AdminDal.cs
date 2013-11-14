using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using AppMod.WebSys;
namespace AppDal.WebSys
{
    /// <summary>
    /// 数据访问类SYS_Admin。
    /// </summary>
    public class SYS_AdminDal
    {
        public SYS_AdminDal() { }
        private static SYS_AdminDal _instance;
        public SYS_AdminDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_AdminDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_AdminMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_Admin(");
            strSql.Append("Username,Password,CustomerSysNo,TS,DR,LastLogin)");
            strSql.Append(" values (");
            strSql.Append("@Username,@Password,@CustomerSysNo,@TS,@DR,@LastLogin)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Username",SqlDbType.VarChar,100),
                 new SqlParameter("@Password",SqlDbType.VarChar,100),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@LastLogin",SqlDbType.DateTime),
             };
            if (model.Username != AppConst.StringNull)
                parameters[0].Value = model.Username;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Password != AppConst.StringNull)
                parameters[1].Value = model.Password;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[2].Value = model.CustomerSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[3].Value = model.TS;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.DR != AppConst.IntNull)
                parameters[4].Value = model.DR;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.LastLogin != AppConst.DateTimeNull)
                parameters[5].Value = model.LastLogin;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(SYS_AdminMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_Admin set ");
            strSql.Append("Username=@Username,");
            strSql.Append("Password=@Password,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("TS=@TS,");
            strSql.Append("DR=@DR,");
            strSql.Append("LastLogin=@LastLogin");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Username",SqlDbType.VarChar,100),
                 new SqlParameter("@Password",SqlDbType.VarChar,100),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@LastLogin",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Username != AppConst.StringNull)
                parameters[1].Value = model.Username;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Password != AppConst.StringNull)
                parameters[2].Value = model.Password;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[3].Value = model.CustomerSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[4].Value = model.TS;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.DR != AppConst.IntNull)
                parameters[5].Value = model.DR;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.LastLogin != AppConst.DateTimeNull)
                parameters[6].Value = model.LastLogin;
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
            strSql.Append("delete SYS_Admin ");
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

        public SYS_AdminMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Username, Password, CustomerSysNo, TS, DR, LastLogin from  SYS_Admin");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_AdminMod model = new SYS_AdminMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLogin"].ToString() != "")
                {
                    model.LastLogin = DateTime.Parse(ds.Tables[0].Rows[0]["LastLogin"].ToString());
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
