using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.QA;

namespace AppDal.QA
{
    public class QA_AnswerDal
    {
        public QA_AnswerDal() { }
        private static QA_AnswerDal _instance;
        public QA_AnswerDal GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_AnswerDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_AnswerMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QA_Answer(");
            strSql.Append("QuestionSysNo,CustomerSysNo,Title,Context,Love,Hate,Award,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@QuestionSysNo,@CustomerSysNo,@Title,@Context,@Love,@Hate,@Award,@DR,@TS)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@QuestionSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,-1),
                 new SqlParameter("@Love",SqlDbType.Int,4),
                 new SqlParameter("@Hate",SqlDbType.Int,4),
                 new SqlParameter("@Award",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.QuestionSysNo != AppConst.IntNull)
                parameters[0].Value = model.QuestionSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[1].Value = model.CustomerSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Title != AppConst.StringNull)
                parameters[2].Value = model.Title;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Context != AppConst.StringNull)
                parameters[3].Value = model.Context;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Love != AppConst.IntNull)
                parameters[4].Value = model.Love;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Hate != AppConst.IntNull)
                parameters[5].Value = model.Hate;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Award != AppConst.IntNull)
                parameters[6].Value = model.Award;
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

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(QA_AnswerMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QA_Answer set ");
            strSql.Append("QuestionSysNo=@QuestionSysNo,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("Title=@Title,");
            strSql.Append("Context=@Context,");
            strSql.Append("Love=@Love,");
            strSql.Append("Hate=@Hate,");
            strSql.Append("Award=@Award,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@QuestionSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.NVarChar,-1),
                 new SqlParameter("@Love",SqlDbType.Int,4),
                 new SqlParameter("@Hate",SqlDbType.Int,4),
                 new SqlParameter("@Award",SqlDbType.Int,4),
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
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[2].Value = model.CustomerSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Title != AppConst.StringNull)
                parameters[3].Value = model.Title;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Context != AppConst.StringNull)
                parameters[4].Value = model.Context;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Love != AppConst.IntNull)
                parameters[5].Value = model.Love;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Hate != AppConst.IntNull)
                parameters[6].Value = model.Hate;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Award != AppConst.IntNull)
                parameters[7].Value = model.Award;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.DR != AppConst.IntNull)
                parameters[8].Value = model.DR;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[9].Value = model.TS;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete QA_Answer ");
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

        public QA_AnswerMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, QuestionSysNo, CustomerSysNo, Title, Context, Love, Hate, Award, DR, TS from  QA_Answer");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            QA_AnswerMod model = new QA_AnswerMod();
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
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["Love"].ToString() != "")
                {
                    model.Love = int.Parse(ds.Tables[0].Rows[0]["Love"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Hate"].ToString() != "")
                {
                    model.Hate = int.Parse(ds.Tables[0].Rows[0]["Hate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Award"].ToString() != "")
                {
                    model.Award = int.Parse(ds.Tables[0].Rows[0]["Award"].ToString());
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
