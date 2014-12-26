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
    /// 数据访问类QA_Question。
    /// </summary>
    public class QA_QuestionDal
    {
        public QA_QuestionDal() { }
        private static QA_QuestionDal _instance;
        public QA_QuestionDal GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_QuestionDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(QA_QuestionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QA_Question(");
            strSql.Append("SysNo,CateSysNo,CustomerSysNo,Title,Context,Award,EndTime,IsSecret,LastReplyTime,LastReplyUser,ReplyCount,ReadCount,DR,TS,SubQuest,OrderCount,BuyCount)");
            strSql.Append(" values (");
            strSql.Append("@SysNo,@CateSysNo,@CustomerSysNo,@Title,@Context,@Award,@EndTime,@IsSecret,@LastReplyTime,@LastReplyUser,@ReplyCount,@ReadCount,@DR,@TS,@SubQuest,@OrderCount,@BuyCount)");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CateSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,600),
                 new SqlParameter("@Context",SqlDbType.Text,2147483647),
                 new SqlParameter("@Award",SqlDbType.Int,4),
                 new SqlParameter("@EndTime",SqlDbType.DateTime),
                 new SqlParameter("@IsSecret",SqlDbType.TinyInt,1),
                 new SqlParameter("@LastReplyTime",SqlDbType.DateTime),
                 new SqlParameter("@LastReplyUser",SqlDbType.Int,4),
                 new SqlParameter("@ReplyCount",SqlDbType.Int,4),
                 new SqlParameter("@ReadCount",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@SubQuest",SqlDbType.NVarChar,1000),
                 new SqlParameter("@OrderCount",SqlDbType.Int,4),
                 new SqlParameter("@BuyCount",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CateSysNo != AppConst.IntNull)
                parameters[1].Value = model.CateSysNo;
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
            if (model.Award != AppConst.IntNull)
                parameters[5].Value = model.Award;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.EndTime != AppConst.DateTimeNull)
                parameters[6].Value = model.EndTime;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.IsSecret != AppConst.IntNull)
                parameters[7].Value = model.IsSecret;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.LastReplyTime != AppConst.DateTimeNull)
                parameters[8].Value = model.LastReplyTime;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.LastReplyUser != AppConst.IntNull)
                parameters[9].Value = model.LastReplyUser;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.ReplyCount != AppConst.IntNull)
                parameters[10].Value = model.ReplyCount;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.ReadCount != AppConst.IntNull)
                parameters[11].Value = model.ReadCount;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.DR != AppConst.IntNull)
                parameters[12].Value = model.DR;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[13].Value = model.TS;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.SubQuest != AppConst.StringNull)
                parameters[14].Value = model.SubQuest;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.OrderCount != AppConst.IntNull)
                parameters[15].Value = model.OrderCount;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.BuyCount != AppConst.IntNull)
                parameters[16].Value = model.BuyCount;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(QA_QuestionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QA_Question set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                strSql.Append("SysNo=@SysNo,");
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.CateSysNo != AppConst.IntNull)
            {
                strSql.Append("CateSysNo=@CateSysNo,");
                SqlParameter param = new SqlParameter("@CateSysNo", SqlDbType.Int, 4);
                param.Value = model.CateSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.CustomerSysNo != AppConst.IntNull)
            {
                strSql.Append("CustomerSysNo=@CustomerSysNo,");
                SqlParameter param = new SqlParameter("@CustomerSysNo", SqlDbType.Int, 4);
                param.Value = model.CustomerSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Title != AppConst.StringNull)
            {
                strSql.Append("Title=@Title,");
                SqlParameter param = new SqlParameter("@Title", SqlDbType.NVarChar, 600);
                param.Value = model.Title;
                cmd.Parameters.Add(param);
            }
            if (model.Context != AppConst.StringNull)
            {
                strSql.Append("Context=@Context,");
                SqlParameter param = new SqlParameter("@Context", SqlDbType.Text, 2147483647);
                param.Value = model.Context;
                cmd.Parameters.Add(param);
            }
            if (model.Award != AppConst.IntNull)
            {
                strSql.Append("Award=@Award,");
                SqlParameter param = new SqlParameter("@Award", SqlDbType.Int, 4);
                param.Value = model.Award;
                cmd.Parameters.Add(param);
            }
            if (model.EndTime != AppConst.DateTimeNull)
            {
                strSql.Append("EndTime=@EndTime,");
                SqlParameter param = new SqlParameter("@EndTime", SqlDbType.DateTime);
                param.Value = model.EndTime;
                cmd.Parameters.Add(param);
            }
            if (model.IsSecret != AppConst.IntNull)
            {
                strSql.Append("IsSecret=@IsSecret,");
                SqlParameter param = new SqlParameter("@IsSecret", SqlDbType.TinyInt, 1);
                param.Value = model.IsSecret;
                cmd.Parameters.Add(param);
            }
            if (model.LastReplyTime != AppConst.DateTimeNull)
            {
                strSql.Append("LastReplyTime=@LastReplyTime,");
                SqlParameter param = new SqlParameter("@LastReplyTime", SqlDbType.DateTime);
                param.Value = model.LastReplyTime;
                cmd.Parameters.Add(param);
            }
            if (model.LastReplyUser != AppConst.IntNull)
            {
                strSql.Append("LastReplyUser=@LastReplyUser,");
                SqlParameter param = new SqlParameter("@LastReplyUser", SqlDbType.Int, 4);
                param.Value = model.LastReplyUser;
                cmd.Parameters.Add(param);
            }
            if (model.ReplyCount != AppConst.IntNull)
            {
                strSql.Append("ReplyCount=@ReplyCount,");
                SqlParameter param = new SqlParameter("@ReplyCount", SqlDbType.Int, 4);
                param.Value = model.ReplyCount;
                cmd.Parameters.Add(param);
            }
            if (model.ReadCount != AppConst.IntNull)
            {
                strSql.Append("ReadCount=@ReadCount,");
                SqlParameter param = new SqlParameter("@ReadCount", SqlDbType.Int, 4);
                param.Value = model.ReadCount;
                cmd.Parameters.Add(param);
            }
            if (model.DR != AppConst.IntNull)
            {
                strSql.Append("DR=@DR,");
                SqlParameter param = new SqlParameter("@DR", SqlDbType.TinyInt, 1);
                param.Value = model.DR;
                cmd.Parameters.Add(param);
            }
            if (model.TS != AppConst.DateTimeNull)
            {
                strSql.Append("TS=@TS,");
                SqlParameter param = new SqlParameter("@TS", SqlDbType.DateTime);
                param.Value = model.TS;
                cmd.Parameters.Add(param);
            }
            if (model.SubQuest != AppConst.StringNull)
            {
                strSql.Append("SubQuest=@SubQuest,");
                SqlParameter param = new SqlParameter("@SubQuest", SqlDbType.NVarChar, 1000);
                param.Value = model.SubQuest;
                cmd.Parameters.Add(param);
            }
            if (model.OrderCount != AppConst.IntNull)
            {
                strSql.Append("OrderCount=@OrderCount,");
                SqlParameter param = new SqlParameter("@OrderCount", SqlDbType.Int, 4);
                param.Value = model.OrderCount;
                cmd.Parameters.Add(param);
            }
            if (model.BuyCount != AppConst.IntNull)
            {
                strSql.Append("BuyCount=@BuyCount,");
                SqlParameter param = new SqlParameter("@BuyCount", SqlDbType.Int, 4);
                param.Value = model.BuyCount;
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
            strSql.Append("delete QA_Question ");
            strSql.Append(" where SysNo=@SysNo");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
			new SqlParameter("@SysNo", SqlDbType.Int,4)
		};
            parameters[0].Value = SysNo;

            parameters[0].Value = System.DBNull.Value;
            parameters[0].Value = SysNo;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd, null);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public QA_QuestionMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CateSysNo, CustomerSysNo, Title, Context, Award, EndTime, IsSecret, LastReplyTime, LastReplyUser, ReplyCount, ReadCount, DR, TS, SubQuest, OrderCount, BuyCount from dbo.QA_Question");
            strSql.Append(" where SysNo=@SysNo");
            SqlParameter[] parameters = { 
		  new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            QA_QuestionMod model = new QA_QuestionMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CateSysNo"].ToString() != "")
                {
                    model.CateSysNo = int.Parse(ds.Tables[0].Rows[0]["CateSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["Award"].ToString() != "")
                {
                    model.Award = int.Parse(ds.Tables[0].Rows[0]["Award"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSecret"].ToString() != "")
                {
                    model.IsSecret = int.Parse(ds.Tables[0].Rows[0]["IsSecret"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastReplyTime"].ToString() != "")
                {
                    model.LastReplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastReplyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastReplyUser"].ToString() != "")
                {
                    model.LastReplyUser = int.Parse(ds.Tables[0].Rows[0]["LastReplyUser"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReplyCount"].ToString() != "")
                {
                    model.ReplyCount = int.Parse(ds.Tables[0].Rows[0]["ReplyCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReadCount"].ToString() != "")
                {
                    model.ReadCount = int.Parse(ds.Tables[0].Rows[0]["ReadCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.SubQuest = ds.Tables[0].Rows[0]["SubQuest"].ToString();
                if (ds.Tables[0].Rows[0]["OrderCount"].ToString() != "")
                {
                    model.OrderCount = int.Parse(ds.Tables[0].Rows[0]["OrderCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyCount"].ToString() != "")
                {
                    model.BuyCount = int.Parse(ds.Tables[0].Rows[0]["BuyCount"].ToString());
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
