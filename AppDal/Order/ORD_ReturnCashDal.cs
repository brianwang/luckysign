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
    /// 数据访问类ORD_ReturnCash。
    /// </summary>
    public class ORD_ReturnCashDal
    {
        public ORD_ReturnCashDal() { }
        private static ORD_ReturnCashDal _instance;
        public ORD_ReturnCashDal GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_ReturnCashDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ORD_ReturnCashMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ORD_ReturnCash(");
            strSql.Append("OrderSysNo,ReasonType,Detail,Amount,TS,Status,ReturnTime,ReturnID,CurrentID)");
            strSql.Append(" values (");
            strSql.Append("@OrderSysNo,@ReasonType,@Detail,@Amount,@TS,@Status,@ReturnTime,@ReturnID,@CurrentID)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@OrderSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ReasonType",SqlDbType.Int,4),
                 new SqlParameter("@Detail",SqlDbType.NText,2147483646),
                 new SqlParameter("@Amount",SqlDbType.Decimal,20),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Status",SqlDbType.Int,4),
                 new SqlParameter("@ReturnTime",SqlDbType.DateTime),
                 new SqlParameter("@ReturnID",SqlDbType.VarChar,50),
                 new SqlParameter("@CurrentID",SqlDbType.VarChar,50),
             };
            if (model.OrderSysNo != AppConst.IntNull)
                parameters[0].Value = model.OrderSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.ReasonType != AppConst.IntNull)
                parameters[1].Value = model.ReasonType;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Detail != AppConst.StringNull)
                parameters[2].Value = model.Detail;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Amount != AppConst.DecimalNull)
                parameters[3].Value = model.Amount;
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
            if (model.ReturnTime != AppConst.DateTimeNull)
                parameters[6].Value = model.ReturnTime;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.ReturnID != AppConst.StringNull)
                parameters[7].Value = model.ReturnID;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.CurrentID != AppConst.StringNull)
                parameters[8].Value = model.CurrentID;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ORD_ReturnCashMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ORD_ReturnCash set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.OrderSysNo != AppConst.IntNull)
            {
                strSql.Append("OrderSysNo=@OrderSysNo,");
                SqlParameter param = new SqlParameter("@OrderSysNo", SqlDbType.Int, 4);
                param.Value = model.OrderSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.ReasonType != AppConst.IntNull)
            {
                strSql.Append("ReasonType=@ReasonType,");
                SqlParameter param = new SqlParameter("@ReasonType", SqlDbType.Int, 4);
                param.Value = model.ReasonType;
                cmd.Parameters.Add(param);
            }
            if (model.Detail != AppConst.StringNull)
            {
                strSql.Append("Detail=@Detail,");
                SqlParameter param = new SqlParameter("@Detail", SqlDbType.NText, 2147483646);
                param.Value = model.Detail;
                cmd.Parameters.Add(param);
            }
            if (model.Amount != AppConst.DecimalNull)
            {
                strSql.Append("Amount=@Amount,");
                SqlParameter param = new SqlParameter("@Amount", SqlDbType.Decimal, 20);
                param.Value = model.Amount;
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
            if (model.ReturnTime != AppConst.DateTimeNull)
            {
                strSql.Append("ReturnTime=@ReturnTime,");
                SqlParameter param = new SqlParameter("@ReturnTime", SqlDbType.DateTime);
                param.Value = model.ReturnTime;
                cmd.Parameters.Add(param);
            }
            if (model.ReturnID != AppConst.StringNull)
            {
                strSql.Append("ReturnID=@ReturnID,");
                SqlParameter param = new SqlParameter("@ReturnID", SqlDbType.VarChar, 50);
                param.Value = model.ReturnID;
                cmd.Parameters.Add(param);
            }
            if (model.CurrentID != AppConst.StringNull)
            {
                strSql.Append("CurrentID=@CurrentID,");
                SqlParameter param = new SqlParameter("@CurrentID", SqlDbType.VarChar, 50);
                param.Value = model.CurrentID;
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
            strSql.Append("delete ORD_ReturnCash ");
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
        public ORD_ReturnCashMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, OrderSysNo, ReasonType, Detail, Amount, TS, Status, ReturnTime, ReturnID, CurrentID from  dbo.ORD_ReturnCash");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            ORD_ReturnCashMod model = new ORD_ReturnCashMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderSysNo"].ToString() != "")
                {
                    model.OrderSysNo = int.Parse(ds.Tables[0].Rows[0]["OrderSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReasonType"].ToString() != "")
                {
                    model.ReasonType = int.Parse(ds.Tables[0].Rows[0]["ReasonType"].ToString());
                }
                model.Detail = ds.Tables[0].Rows[0]["Detail"].ToString();
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnTime"].ToString() != "")
                {
                    model.ReturnTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReturnTime"].ToString());
                }
                model.ReturnID = ds.Tables[0].Rows[0]["ReturnID"].ToString();
                model.CurrentID = ds.Tables[0].Rows[0]["CurrentID"].ToString();
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
