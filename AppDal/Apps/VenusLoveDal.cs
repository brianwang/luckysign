using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Apps;

namespace AppDal.Apps
{
    public class VenusLoveDal
    {
        public VenusLoveDal() { }
        private static VenusLoveDal _instance;
        public VenusLoveDal GetInstance()
        {
            if (_instance == null)
            { _instance = new VenusLoveDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(VenusLoveMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Apps.dbo.VenusLove(");
            strSql.Append("BirthTime,Area,Source,UserSysNo,TS)");
            strSql.Append(" values (");
            strSql.Append("@BirthTime,@Area,@Source,@UserSysNo,@TS)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@BirthTime",SqlDbType.DateTime),
                 new SqlParameter("@Area",SqlDbType.Int,4),
                 new SqlParameter("@Source",SqlDbType.Int,4),
                 new SqlParameter("@UserSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.BirthTime != AppConst.DateTimeNull)
                parameters[0].Value = model.BirthTime;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Area != AppConst.IntNull)
                parameters[1].Value = model.Area;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Source != AppConst.IntNull)
                parameters[2].Value = model.Source;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.UserSysNo != AppConst.IntNull)
                parameters[3].Value = model.UserSysNo;
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
        /// 更新一条数据
        /// </summary>

        public int Update(VenusLoveMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Apps.dbo.VenusLove set ");
            strSql.Append("BirthTime=@BirthTime,");
            strSql.Append("Area=@Area,");
            strSql.Append("Source=@Source,");
            strSql.Append("UserSysNo=@UserSysNo,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@BirthTime",SqlDbType.DateTime),
                 new SqlParameter("@Area",SqlDbType.Int,4),
                 new SqlParameter("@Source",SqlDbType.Int,4),
                 new SqlParameter("@UserSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.BirthTime != AppConst.DateTimeNull)
                parameters[1].Value = model.BirthTime;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Area != AppConst.IntNull)
                parameters[2].Value = model.Area;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Source != AppConst.IntNull)
                parameters[3].Value = model.Source;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.UserSysNo != AppConst.IntNull)
                parameters[4].Value = model.UserSysNo;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[5].Value = model.TS;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Apps.dbo.VenusLove ");
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

        public VenusLoveMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, BirthTime, Area, Source, UserSysNo, TS from  Apps.dbo.VenusLove");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            VenusLoveMod model = new VenusLoveMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BirthTime"].ToString() != "")
                {
                    model.BirthTime = DateTime.Parse(ds.Tables[0].Rows[0]["BirthTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Area"].ToString() != "")
                {
                    model.Area = int.Parse(ds.Tables[0].Rows[0]["Area"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Source"].ToString() != "")
                {
                    model.Source = int.Parse(ds.Tables[0].Rows[0]["Source"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserSysNo"].ToString() != "")
                {
                    model.UserSysNo = int.Parse(ds.Tables[0].Rows[0]["UserSysNo"].ToString());
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
