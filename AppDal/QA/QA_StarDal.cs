using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.QA;

namespace AppDal.QA
{
    public class QA_StarDal
    {
        public QA_StarDal() { }
        private static QA_StarDal _instance;
        public QA_StarDal GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_StarDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(QA_StarMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_Star(");
            strSql.Append("SysNo,CustomerSysNo,OrderID,Intro)");
            strSql.Append(" values (");
            strSql.Append("@SysNo,@CustomerSysNo,@OrderID,@Intro)");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@OrderID",SqlDbType.Int,4),
                 new SqlParameter("@Intro",SqlDbType.NVarChar,2000)
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
            if (model.OrderID != AppConst.IntNull)
                parameters[2].Value = model.OrderID;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Intro != AppConst.StringNull)
                parameters[3].Value = model.Intro;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(QA_StarMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_Star set ");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("Intro=@Intro");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@OrderID",SqlDbType.Int,4),
                 new SqlParameter("@Intro",SqlDbType.NVarChar,2000)
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
            if (model.OrderID != AppConst.IntNull)
                parameters[2].Value = model.OrderID;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Intro != AppConst.StringNull)
                parameters[3].Value = model.Intro;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete USR_Star ");
            strSql.Append(" where SysNo=@SysNo");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
			new SqlParameter("@SysNo", SqlDbType.Int,4)
		};
            parameters[0].Value = SysNo;

            parameters[0].Value = System.DBNull.Value;
            parameters[0].Value = SysNo;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public QA_StarMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerSysNo, OrderID, Intro from USR_Star");
            strSql.Append(" where SysNo=@SysNo");
            SqlParameter[] parameters = { 
		  new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            QA_StarMod model = new QA_StarMod();
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
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.Intro = ds.Tables[0].Rows[0]["Intro"].ToString();
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
