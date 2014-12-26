using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Apps;

namespace AppDal.Apps
{
    /// <summary>
    /// 数据访问类TopicSendRecord。
    /// </summary>
    public class TopicSendRecordDal
    {
        public TopicSendRecordDal() { }
        private static TopicSendRecordDal _instance;
        public TopicSendRecordDal GetInstance()
        {
            if (_instance == null)
            { _instance = new TopicSendRecordDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(TopicSendRecordMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TopicSendRecord(");
            strSql.Append("UserSysNo,TopicSysNo,IsReturn,TS)");
            strSql.Append(" values (");
            strSql.Append("@UserSysNo,@TopicSysNo,@IsReturn,@TS)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@UserSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TopicSysNo",SqlDbType.Int,4),
                 new SqlParameter("@IsReturn",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.UserSysNo != AppConst.IntNull)
                parameters[0].Value = model.UserSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.TopicSysNo != AppConst.IntNull)
                parameters[1].Value = model.TopicSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.IsReturn != AppConst.IntNull)
                parameters[2].Value = model.IsReturn;
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

        public int Update(TopicSendRecordMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TopicSendRecord set ");
            strSql.Append("UserSysNo=@UserSysNo,");
            strSql.Append("TopicSysNo=@TopicSysNo,");
            strSql.Append("IsReturn=@IsReturn,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@UserSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TopicSysNo",SqlDbType.Int,4),
                 new SqlParameter("@IsReturn",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.UserSysNo != AppConst.IntNull)
                parameters[1].Value = model.UserSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.TopicSysNo != AppConst.IntNull)
                parameters[2].Value = model.TopicSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.IsReturn != AppConst.IntNull)
                parameters[3].Value = model.IsReturn;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[4].Value = model.TS;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete TopicSendRecord ");
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

        public TopicSendRecordMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, UserSysNo, TopicSysNo, IsReturn, TS from  TopicSendRecord");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            TopicSendRecordMod model = new TopicSendRecordMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserSysNo"].ToString() != "")
                {
                    model.UserSysNo = int.Parse(ds.Tables[0].Rows[0]["UserSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TopicSysNo"].ToString() != "")
                {
                    model.TopicSysNo = int.Parse(ds.Tables[0].Rows[0]["TopicSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsReturn"].ToString() != "")
                {
                    model.IsReturn = int.Parse(ds.Tables[0].Rows[0]["IsReturn"].ToString());
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
