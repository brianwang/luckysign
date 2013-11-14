using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using AppMod.BLG;
using System.Data;
using System.Data.SqlClient;

namespace AppDal.BLG
{
    /// <summary>
    /// 数据访问类BLG_Collection。
    /// </summary>
    public class BLG_CollectionDal
    {
        public BLG_CollectionDal() { }
        private static BLG_CollectionDal _instance;
        public BLG_CollectionDal GetInstance()
        {
            if (_instance == null)
            { _instance = new BLG_CollectionDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(BLG_CollectionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLG_Collection(");
            strSql.Append("CustomerSysNo,Name,Detail,Type,RefUrl,RefSysNo,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@CustomerSysNo,@Name,@Detail,@Type,@RefUrl,@RefSysNo,@DR,@TS)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@Detail",SqlDbType.NVarChar,2000),
                 new SqlParameter("@Type",SqlDbType.TinyInt,1),
                 new SqlParameter("@RefUrl",SqlDbType.VarChar,500),
                 new SqlParameter("@RefSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[0].Value = model.CustomerSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Name != AppConst.StringNull)
                parameters[1].Value = model.Name;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Detail != AppConst.StringNull)
                parameters[2].Value = model.Detail;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Type != AppConst.IntNull)
                parameters[3].Value = model.Type;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.RefUrl != AppConst.StringNull)
                parameters[4].Value = model.RefUrl;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.RefSysNo != AppConst.IntNull)
                parameters[5].Value = model.RefSysNo;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.DR != AppConst.IntNull)
                parameters[6].Value = model.DR;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[7].Value = model.TS;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(BLG_CollectionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLG_Collection set ");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("Name=@Name,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("Type=@Type,");
            strSql.Append("RefUrl=@RefUrl,");
            strSql.Append("RefSysNo=@RefSysNo,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@Detail",SqlDbType.NVarChar,2000),
                 new SqlParameter("@Type",SqlDbType.TinyInt,1),
                 new SqlParameter("@RefUrl",SqlDbType.VarChar,500),
                 new SqlParameter("@RefSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
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
            if (model.Name != AppConst.StringNull)
                parameters[2].Value = model.Name;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Detail != AppConst.StringNull)
                parameters[3].Value = model.Detail;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Type != AppConst.IntNull)
                parameters[4].Value = model.Type;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.RefUrl != AppConst.StringNull)
                parameters[5].Value = model.RefUrl;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.RefSysNo != AppConst.IntNull)
                parameters[6].Value = model.RefSysNo;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.DR != AppConst.IntNull)
                parameters[7].Value = model.DR;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[8].Value = model.TS;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete BLG_Collection ");
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

        public BLG_CollectionMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerSysNo, Name, Detail, Type, RefUrl, RefSysNo, DR, TS from  BLG_Collection");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            BLG_CollectionMod model = new BLG_CollectionMod();
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
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Detail = ds.Tables[0].Rows[0]["Detail"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                model.RefUrl = ds.Tables[0].Rows[0]["RefUrl"].ToString();
                if (ds.Tables[0].Rows[0]["RefSysNo"].ToString() != "")
                {
                    model.RefSysNo = int.Parse(ds.Tables[0].Rows[0]["RefSysNo"].ToString());
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
