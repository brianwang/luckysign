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
    /// 数据访问类QA_Comment。
    /// </summary>
    public class QA_CommentDal
    {
        public QA_CommentDal() { }
        private static QA_CommentDal _instance;
        public QA_CommentDal GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_CommentDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_CommentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QA_Comment(");
            strSql.Append("QuestionSysNo,AnswerSysNo,CustomerSysNo,Context,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@QuestionSysNo,@AnswerSysNo,@CustomerSysNo,@Context,@DR,@TS)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@QuestionSysNo",SqlDbType.Int,4),
                 new SqlParameter("@AnswerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.QuestionSysNo != AppConst.IntNull)
                parameters[0].Value = model.QuestionSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.AnswerSysNo != AppConst.IntNull)
                parameters[1].Value = model.AnswerSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[2].Value = model.CustomerSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Context != AppConst.StringNull)
                parameters[3].Value = model.Context;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.DR != AppConst.IntNull)
                parameters[4].Value = model.DR;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[5].Value = model.TS;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(QA_CommentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QA_Comment set ");
            strSql.Append("QuestionSysNo=@QuestionSysNo,");
            strSql.Append("AnswerSysNo=@AnswerSysNo,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("Context=@Context,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@QuestionSysNo",SqlDbType.Int,4),
                 new SqlParameter("@AnswerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Context",SqlDbType.NVarChar,2000),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.QuestionSysNo != AppConst.IntNull)
                parameters[1].Value = model.QuestionSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.AnswerSysNo != AppConst.IntNull)
                parameters[2].Value = model.AnswerSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[3].Value = model.CustomerSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Context != AppConst.StringNull)
                parameters[4].Value = model.Context;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.DR != AppConst.IntNull)
                parameters[5].Value = model.DR;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[6].Value = model.TS;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete QA_Comment ");
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

        public QA_CommentMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, QuestionSysNo, AnswerSysNo, CustomerSysNo, Context, DR, TS from  QA_Comment");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            QA_CommentMod model = new QA_CommentMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QuestionSysNo"].ToString() != "")
                {
                    model.QuestionSysNo = int.Parse(ds.Tables[0].Rows[0]["QuestionSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AnswerSysNo"].ToString() != "")
                {
                    model.AnswerSysNo = int.Parse(ds.Tables[0].Rows[0]["AnswerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
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
