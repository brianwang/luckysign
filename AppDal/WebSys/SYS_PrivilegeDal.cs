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
    /// 数据访问类SYS_Privilege。
    /// </summary>
    public class SYS_PrivilegeDal
    {
        public SYS_PrivilegeDal() { }
        private static SYS_PrivilegeDal _instance;
        public SYS_PrivilegeDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_PrivilegeDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_PrivilegeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_Privilege(");
            strSql.Append("Name,TS,DR,URL)");
            strSql.Append(" values (");
            strSql.Append("@Name,@TS,@DR,@URL)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@URL",SqlDbType.VarChar,100),
             };
            if (model.Name != AppConst.StringNull)
                parameters[0].Value = model.Name;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[1].Value = model.TS;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.DR != AppConst.IntNull)
                parameters[2].Value = model.DR;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.URL != AppConst.StringNull)
                parameters[3].Value = model.URL;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(SYS_PrivilegeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_Privilege set ");
            strSql.Append("Name=@Name,");
            strSql.Append("TS=@TS,");
            strSql.Append("DR=@DR,");
            strSql.Append("URL=@URL");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@URL",SqlDbType.VarChar,100)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Name != AppConst.StringNull)
                parameters[1].Value = model.Name;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[2].Value = model.TS;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.DR != AppConst.IntNull)
                parameters[3].Value = model.DR;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.URL != AppConst.StringNull)
                parameters[4].Value = model.URL;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_Privilege ");
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

        public SYS_PrivilegeMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Name, TS, DR, URL from  SYS_Privilege");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_PrivilegeMod model = new SYS_PrivilegeMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                model.URL = ds.Tables[0].Rows[0]["URL"].ToString();
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
