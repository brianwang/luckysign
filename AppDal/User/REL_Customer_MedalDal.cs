using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.User;

namespace AppDal.User
{
    public class REL_Customer_MedalDal
    {
        public REL_Customer_MedalDal() { }
        private static REL_Customer_MedalDal _instance;
        public REL_Customer_MedalDal GetInstance()
        {
            if (_instance == null)
            { _instance = new REL_Customer_MedalDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Customer_MedalMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into REL_Customer_Medal(");
            strSql.Append("MedalSysNo,CustomerSysNo,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@MedalSysNo,@CustomerSysNo,@DR,@TS)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@MedalSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.MedalSysNo != AppConst.IntNull)
                parameters[0].Value = model.MedalSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[1].Value = model.CustomerSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.DR != AppConst.IntNull)
                parameters[2].Value = model.DR;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[3].Value = model.TS;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(REL_Customer_MedalMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update REL_Customer_Medal set ");
            strSql.Append("MedalSysNo=@MedalSysNo,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@MedalSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.MedalSysNo != AppConst.IntNull)
                parameters[1].Value = model.MedalSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[2].Value = model.CustomerSysNo;
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
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete REL_Customer_Medal ");
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

        public REL_Customer_MedalMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, MedalSysNo, CustomerSysNo, DR, TS from  REL_Customer_Medal");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            REL_Customer_MedalMod model = new REL_Customer_MedalMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MedalSysNo"].ToString() != "")
                {
                    model.MedalSysNo = int.Parse(ds.Tables[0].Rows[0]["MedalSysNo"].ToString());
                }
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
