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
    /// 数据访问类ORD_Cash。
    /// </summary>
    public class ORD_CashDal
    {
        public ORD_CashDal() { }
        private static ORD_CashDal _instance;
        public ORD_CashDal GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_CashDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ORD_CashMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ORD_Cash(");
            strSql.Append("CustomerSysNo,ProductType,ProductSysNo,Price,PayType,Discount,PayAmount,TS,Status,OrderID,CurrentID,PayTime)");
            strSql.Append(" values (");
            strSql.Append("@CustomerSysNo,@ProductType,@ProductSysNo,@Price,@PayType,@Discount,@PayAmount,@TS,@Status,@OrderID,@CurrentID,@PayTime)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ProductType",SqlDbType.Int,4),
                 new SqlParameter("@ProductSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Price",SqlDbType.Decimal,20),
                 new SqlParameter("@PayType",SqlDbType.Int,4),
                 new SqlParameter("@Discount",SqlDbType.Decimal,20),
                 new SqlParameter("@PayAmount",SqlDbType.Decimal,20),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Status",SqlDbType.Int,4),
                 new SqlParameter("@OrderID",SqlDbType.VarChar,50),
                 new SqlParameter("@CurrentID",SqlDbType.VarChar,50),
                 new SqlParameter("@PayTime",SqlDbType.DateTime),
             };
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[0].Value = model.CustomerSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.ProductType != AppConst.IntNull)
                parameters[1].Value = model.ProductType;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.ProductSysNo != AppConst.IntNull)
                parameters[2].Value = model.ProductSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Price != AppConst.DecimalNull)
                parameters[3].Value = model.Price;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.PayType != AppConst.IntNull)
                parameters[4].Value = model.PayType;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Discount != AppConst.DecimalNull)
                parameters[5].Value = model.Discount;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.PayAmount != AppConst.DecimalNull)
                parameters[6].Value = model.PayAmount;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[7].Value = model.TS;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Status != AppConst.IntNull)
                parameters[8].Value = model.Status;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.OrderID != AppConst.StringNull)
                parameters[9].Value = model.OrderID;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.CurrentID != AppConst.StringNull)
                parameters[10].Value = model.CurrentID;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.PayTime != AppConst.DateTimeNull)
                parameters[11].Value = model.PayTime;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ORD_CashMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ORD_Cash set ");
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
            if (model.ProductType != AppConst.IntNull)
            {
                strSql.Append("ProductType=@ProductType,");
                SqlParameter param = new SqlParameter("@ProductType", SqlDbType.Int, 4);
                param.Value = model.ProductType;
                cmd.Parameters.Add(param);
            }
            if (model.ProductSysNo != AppConst.IntNull)
            {
                strSql.Append("ProductSysNo=@ProductSysNo,");
                SqlParameter param = new SqlParameter("@ProductSysNo", SqlDbType.Int, 4);
                param.Value = model.ProductSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Price != AppConst.DecimalNull)
            {
                strSql.Append("Price=@Price,");
                SqlParameter param = new SqlParameter("@Price", SqlDbType.Decimal, 20);
                param.Value = model.Price;
                cmd.Parameters.Add(param);
            }
            if (model.PayType != AppConst.IntNull)
            {
                strSql.Append("PayType=@PayType,");
                SqlParameter param = new SqlParameter("@PayType", SqlDbType.Int, 4);
                param.Value = model.PayType;
                cmd.Parameters.Add(param);
            }
            if (model.Discount != AppConst.DecimalNull)
            {
                strSql.Append("Discount=@Discount,");
                SqlParameter param = new SqlParameter("@Discount", SqlDbType.Decimal, 20);
                param.Value = model.Discount;
                cmd.Parameters.Add(param);
            }
            if (model.PayAmount != AppConst.DecimalNull)
            {
                strSql.Append("PayAmount=@PayAmount,");
                SqlParameter param = new SqlParameter("@PayAmount", SqlDbType.Decimal, 20);
                param.Value = model.PayAmount;
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
            if (model.OrderID != AppConst.StringNull)
            {
                strSql.Append("OrderID=@OrderID,");
                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.VarChar, 50);
                param.Value = model.OrderID;
                cmd.Parameters.Add(param);
            }
            if (model.CurrentID != AppConst.StringNull)
            {
                strSql.Append("CurrentID=@CurrentID,");
                SqlParameter param = new SqlParameter("@CurrentID", SqlDbType.VarChar, 50);
                param.Value = model.CurrentID;
                cmd.Parameters.Add(param);
            }
            if (model.PayTime != AppConst.DateTimeNull)
            {
                strSql.Append("PayTime=@PayTime,");
                SqlParameter param = new SqlParameter("@PayTime", SqlDbType.DateTime);
                param.Value = model.PayTime;
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
            strSql.Append("delete ORD_Cash ");
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
        public ORD_CashMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerSysNo, ProductType, ProductSysNo, Price, PayType, Discount, PayAmount, TS, Status, OrderID, CurrentID, PayTime from  dbo.ORD_Cash");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            ORD_CashMod model = new ORD_CashMod();
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
                if (ds.Tables[0].Rows[0]["ProductType"].ToString() != "")
                {
                    model.ProductType = int.Parse(ds.Tables[0].Rows[0]["ProductType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductSysNo"].ToString() != "")
                {
                    model.ProductSysNo = int.Parse(ds.Tables[0].Rows[0]["ProductSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayType"].ToString() != "")
                {
                    model.PayType = int.Parse(ds.Tables[0].Rows[0]["PayType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Discount"].ToString() != "")
                {
                    model.Discount = decimal.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayAmount"].ToString() != "")
                {
                    model.PayAmount = decimal.Parse(ds.Tables[0].Rows[0]["PayAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                model.CurrentID = ds.Tables[0].Rows[0]["CurrentID"].ToString();
                if (ds.Tables[0].Rows[0]["PayTime"].ToString() != "")
                {
                    model.PayTime = DateTime.Parse(ds.Tables[0].Rows[0]["PayTime"].ToString());
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
