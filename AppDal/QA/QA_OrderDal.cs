using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.QA;
namespace AppDal.QA
{
    /// <summary>
    /// 数据访问类QA_Order。
    /// </summary>
    public class QA_OrderDal
    {
        public QA_OrderDal() { }
        private static QA_OrderDal _instance;
        public QA_OrderDal GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_OrderDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(QA_OrderMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QA_Order(");
            strSql.Append("AnswerSysNo,QuestionSysNo,CustomerSysNo,Price,Status,TS,Words,Description,Score,Trial,ReplyTime)");
            strSql.Append(" values (");
            strSql.Append("@AnswerSysNo,@QuestionSysNo,@CustomerSysNo,@Price,@Status,@TS,@Words,@Description,@Score,@Trial,@ReplyTime)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@AnswerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@QuestionSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Price",SqlDbType.Decimal,20),
                 new SqlParameter("@Status",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Words",SqlDbType.Int,4),
                 new SqlParameter("@Description",SqlDbType.NVarChar,1000),
                 new SqlParameter("@Score",SqlDbType.Int,4),
                 new SqlParameter("@Trial",SqlDbType.NVarChar,1000),
                 new SqlParameter("@ReplyTime",SqlDbType.DateTime),
             };
            if (model.AnswerSysNo != AppConst.IntNull)
                parameters[0].Value = model.AnswerSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.QuestionSysNo != AppConst.IntNull)
                parameters[1].Value = model.QuestionSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[2].Value = model.CustomerSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Price != AppConst.DecimalNull)
                parameters[3].Value = model.Price;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Status != AppConst.IntNull)
                parameters[4].Value = model.Status;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[5].Value = model.TS;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Words != AppConst.IntNull)
                parameters[6].Value = model.Words;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Description != AppConst.StringNull)
                parameters[7].Value = model.Description;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Score != AppConst.IntNull)
                parameters[8].Value = model.Score;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.Trial != AppConst.StringNull)
                parameters[9].Value = model.Trial;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.ReplyTime != AppConst.DateTimeNull)
                parameters[10].Value = model.ReplyTime;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(QA_OrderMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QA_Order set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.AnswerSysNo != AppConst.IntNull)
            {
                strSql.Append("AnswerSysNo=@AnswerSysNo,");
                SqlParameter param = new SqlParameter("@AnswerSysNo", SqlDbType.Int, 4);
                param.Value = model.AnswerSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.QuestionSysNo != AppConst.IntNull)
            {
                strSql.Append("QuestionSysNo=@QuestionSysNo,");
                SqlParameter param = new SqlParameter("@QuestionSysNo", SqlDbType.Int, 4);
                param.Value = model.QuestionSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.CustomerSysNo != AppConst.IntNull)
            {
                strSql.Append("CustomerSysNo=@CustomerSysNo,");
                SqlParameter param = new SqlParameter("@CustomerSysNo", SqlDbType.Int, 4);
                param.Value = model.CustomerSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Price != AppConst.DecimalNull)
            {
                strSql.Append("Price=@Price,");
                SqlParameter param = new SqlParameter("@Price", SqlDbType.Decimal, 20);
                param.Value = model.Price;
                cmd.Parameters.Add(param);
            }
            if (model.Status != AppConst.IntNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.Int, 4);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.TS != AppConst.DateTimeNull)
            {
                strSql.Append("TS=@TS,");
                SqlParameter param = new SqlParameter("@TS", SqlDbType.DateTime);
                param.Value = model.TS;
                cmd.Parameters.Add(param);
            }
            if (model.Words != AppConst.IntNull)
            {
                strSql.Append("Words=@Words,");
                SqlParameter param = new SqlParameter("@Words", SqlDbType.Int, 4);
                param.Value = model.Words;
                cmd.Parameters.Add(param);
            }
            if (model.Description != AppConst.StringNull)
            {
                strSql.Append("Description=@Description,");
                SqlParameter param = new SqlParameter("@Description", SqlDbType.NVarChar, 1000);
                param.Value = model.Description;
                cmd.Parameters.Add(param);
            }
            if (model.Score != AppConst.IntNull)
            {
                strSql.Append("Score=@Score,");
                SqlParameter param = new SqlParameter("@Score", SqlDbType.Int, 4);
                param.Value = model.Score;
                cmd.Parameters.Add(param);
            }
            if (model.Trial != AppConst.StringNull)
            {
                strSql.Append("Trial=@Trial,");
                SqlParameter param = new SqlParameter("@Trial", SqlDbType.NVarChar, 1000);
                param.Value = model.Trial;
                cmd.Parameters.Add(param);
            }
            if (model.ReplyTime != AppConst.DateTimeNull)
            {
                strSql.Append("ReplyTime=@ReplyTime,");
                SqlParameter param = new SqlParameter("@ReplyTime", SqlDbType.DateTime);
                param.Value = model.ReplyTime;
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
            strSql.Append("delete QA_Order ");
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
        public QA_OrderMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, AnswerSysNo, QuestionSysNo, CustomerSysNo, Price, Status, TS, Words, Description, Score, Trial, ReplyTime from  dbo.QA_Order");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            QA_OrderMod model = new QA_OrderMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AnswerSysNo"].ToString() != "")
                {
                    model.AnswerSysNo = int.Parse(ds.Tables[0].Rows[0]["AnswerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QuestionSysNo"].ToString() != "")
                {
                    model.QuestionSysNo = int.Parse(ds.Tables[0].Rows[0]["QuestionSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Words"].ToString() != "")
                {
                    model.Words = int.Parse(ds.Tables[0].Rows[0]["Words"].ToString());
                }
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                model.Trial = ds.Tables[0].Rows[0]["Trial"].ToString();
                if (ds.Tables[0].Rows[0]["ReplyTime"].ToString() != "")
                {
                    model.ReplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReplyTime"].ToString());
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
