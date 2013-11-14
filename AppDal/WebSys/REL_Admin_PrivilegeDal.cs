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
    /// 数据访问类REL_Admin_Privilege。
    /// </summary>
    public class REL_Admin_PrivilegeDal
    {
        public REL_Admin_PrivilegeDal() { }
        private static REL_Admin_PrivilegeDal _instance;
        public REL_Admin_PrivilegeDal GetInstance()
        {
            if (_instance == null)
            { _instance = new REL_Admin_PrivilegeDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Admin_PrivilegeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into REL_Admin_Privilege(");
            strSql.Append("Admin_SysNo,Privilege_SysNo)");
            strSql.Append(" values (");
            strSql.Append("@Admin_SysNo,@Privilege_SysNo)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Admin_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Privilege_SysNo",SqlDbType.Int,4),
             };
            if (model.Admin_SysNo != AppConst.IntNull)
                parameters[0].Value = model.Admin_SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Privilege_SysNo != AppConst.IntNull)
                parameters[1].Value = model.Privilege_SysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(REL_Admin_PrivilegeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update REL_Admin_Privilege set ");
            strSql.Append("Admin_SysNo=@Admin_SysNo,");
            strSql.Append("Privilege_SysNo=@Privilege_SysNo");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Admin_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Privilege_SysNo",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Admin_SysNo != AppConst.IntNull)
                parameters[1].Value = model.Admin_SysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Privilege_SysNo != AppConst.IntNull)
                parameters[2].Value = model.Privilege_SysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete REL_Admin_Privilege ");
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

        public REL_Admin_PrivilegeMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Admin_SysNo, Privilege_SysNo from  REL_Admin_Privilege");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            REL_Admin_PrivilegeMod model = new REL_Admin_PrivilegeMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Admin_SysNo"].ToString() != "")
                {
                    model.Admin_SysNo = int.Parse(ds.Tables[0].Rows[0]["Admin_SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Privilege_SysNo"].ToString() != "")
                {
                    model.Privilege_SysNo = int.Parse(ds.Tables[0].Rows[0]["Privilege_SysNo"].ToString());
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
