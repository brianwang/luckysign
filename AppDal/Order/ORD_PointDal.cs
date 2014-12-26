using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Order;
namespace AppDal.Order
{
    /// <summary>
    /// 数据访问类ORD_Point。
    /// </summary>
    public class ORD_PointDal
    {
        public ORD_PointDal() { }
        private static ORD_PointDal _instance;
        public ORD_PointDal GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_PointDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ORD_PointMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ORD_Point(");
            strSql.Append("CustomerSysNo,ProductSysNo,Point,Type,TS,Status)");
            strSql.Append(" values (");
            strSql.Append("@CustomerSysNo,@ProductSysNo,@Point,@Type,@TS,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ProductSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Point",SqlDbType.Int,4),
                 new SqlParameter("@Type",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Status",SqlDbType.Int,4),
             };
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[0].Value = model.CustomerSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.ProductSysNo != AppConst.IntNull)
                parameters[1].Value = model.ProductSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Point != AppConst.IntNull)
                parameters[2].Value = model.Point;
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
            if (model.Status != AppConst.IntNull)
                parameters[5].Value = model.Status;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ORD_PointMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ORD_Point set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.CustomerSysNo != AppConst.IntNull)
            {
                strSql.Append("CustomerSysNo=@CustomerSysNo,");
                SqlParameter param = new SqlParameter("@CustomerSysNo", SqlDbType.Int, 4);
                param.Value = model.CustomerSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.ProductSysNo != AppConst.IntNull)
            {
                strSql.Append("ProductSysNo=@ProductSysNo,");
                SqlParameter param = new SqlParameter("@ProductSysNo", SqlDbType.Int, 4);
                param.Value = model.ProductSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Point != AppConst.IntNull)
            {
                strSql.Append("Point=@Point,");
                SqlParameter param = new SqlParameter("@Point", SqlDbType.Int, 4);
                param.Value = model.Point;
                cmd.Parameters.Add(param);
            }
            if (model.Type != AppConst.IntNull)
            {
                strSql.Append("Type=@Type,");
                SqlParameter param = new SqlParameter("@Type", SqlDbType.Int, 4);
                param.Value = model.Type;
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
            strSql.Append("delete ORD_Point ");
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
        public ORD_PointMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerSysNo, ProductSysNo, Point, Type, TS, Status from  dbo.ORD_Point");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            ORD_PointMod model = new ORD_PointMod();
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
                if (ds.Tables[0].Rows[0]["ProductSysNo"].ToString() != "")
                {
                    model.ProductSysNo = int.Parse(ds.Tables[0].Rows[0]["ProductSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Point"].ToString() != "")
                {
                    model.Point = int.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
