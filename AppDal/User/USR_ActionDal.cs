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
    /// 数据访问类USR_Action。
    /// </summary>
    public class USR_ActionDal
    {
        public USR_ActionDal() { }
        private static USR_ActionDal _instance;
        public USR_ActionDal GetInstance()
        {
            if (_instance == null)
            { _instance = new USR_ActionDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(USR_ActionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_Action(");
            strSql.Append("SysNo,CustomerSysNo,xml,Type,TS)");
            strSql.Append(" values (");
            strSql.Append("@SysNo,@CustomerSysNo,@xml,@Type,@TS)");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@xml",SqlDbType.VarChar,500),
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
            if (model.xml != AppConst.StringNull)
                parameters[2].Value = model.xml;
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
            SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(USR_ActionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_Action set ");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("xml=@xml,");
            strSql.Append("Type=@Type,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@xml",SqlDbType.VarChar,500),
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
            if (model.xml != AppConst.StringNull)
                parameters[2].Value = model.xml;
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
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete USR_Action ");
            strSql.Append(" where SysNo=@SysNo");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
			new SqlParameter("@SysNo", SqlDbType.Int,4)
		};
            parameters[0].Value = SysNo;

            parameters[0].Value = System.DBNull.Value;
            parameters[0].Value = SysNo;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public USR_ActionMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerSysNo, xml, Type, TS from USR_Action");
            strSql.Append(" where SysNo=@SysNo");
            SqlParameter[] parameters = { 
		  new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            USR_ActionMod model = new USR_ActionMod();
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
                model.xml = ds.Tables[0].Rows[0]["xml"].ToString();
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
