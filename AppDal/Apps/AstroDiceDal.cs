using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Apps;

namespace AppDal.Apps
{
    public class AstroDiceDal
    {
        public AstroDiceDal() { }
        private static AstroDiceDal _instance;
        public AstroDiceDal GetInstance()
        {
            if (_instance == null)
            { _instance = new AstroDiceDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(AstroDiceMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Apps.dbo.AstroDice(");
            strSql.Append("Question,Constellation,House,Star,TS,Pic,UserSysNo,Source)");
            strSql.Append(" values (");
            strSql.Append("@Question,@Constellation,@House,@Star,@TS,@Pic,@UserSysNo,@Source)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Question",SqlDbType.NVarChar,600),
                 new SqlParameter("@Constellation",SqlDbType.Int,4),
                 new SqlParameter("@House",SqlDbType.Int,4),
                 new SqlParameter("@Star",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Pic",SqlDbType.VarChar,100),
                 new SqlParameter("@UserSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Source",SqlDbType.Int,4),
             };
            if (model.Question != AppConst.StringNull)
                parameters[0].Value = model.Question;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Constellation != AppConst.IntNull)
                parameters[1].Value = model.Constellation;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.House != AppConst.IntNull)
                parameters[2].Value = model.House;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Star != AppConst.IntNull)
                parameters[3].Value = model.Star;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[4].Value = model.TS;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Pic != AppConst.StringNull)
                parameters[5].Value = model.Pic;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.UserSysNo != AppConst.IntNull)
                parameters[6].Value = model.UserSysNo;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Source != AppConst.IntNull)
                parameters[7].Value = model.Source;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(AstroDiceMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Apps.dbo.AstroDice set ");
            strSql.Append("Question=@Question,");
            strSql.Append("Constellation=@Constellation,");
            strSql.Append("House=@House,");
            strSql.Append("Star=@Star,");
            strSql.Append("TS=@TS,");
            strSql.Append("Pic=@Pic,");
            strSql.Append("UserSysNo=@UserSysNo,");
            strSql.Append("Source=@Source");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Question",SqlDbType.NVarChar,600),
                 new SqlParameter("@Constellation",SqlDbType.Int,4),
                 new SqlParameter("@House",SqlDbType.Int,4),
                 new SqlParameter("@Star",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Pic",SqlDbType.VarChar,100),
                 new SqlParameter("@UserSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Source",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Question != AppConst.StringNull)
                parameters[1].Value = model.Question;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Constellation != AppConst.IntNull)
                parameters[2].Value = model.Constellation;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.House != AppConst.IntNull)
                parameters[3].Value = model.House;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Star != AppConst.IntNull)
                parameters[4].Value = model.Star;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[5].Value = model.TS;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Pic != AppConst.StringNull)
                parameters[6].Value = model.Pic;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.UserSysNo != AppConst.IntNull)
                parameters[7].Value = model.UserSysNo;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Source != AppConst.IntNull)
                parameters[8].Value = model.Source;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Apps.dbo.AstroDice ");
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

        public AstroDiceMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Question, Constellation, House, Star, TS, Pic, UserSysNo, Source from  Apps.dbo.AstroDice");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            AstroDiceMod model = new AstroDiceMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                if (ds.Tables[0].Rows[0]["Constellation"].ToString() != "")
                {
                    model.Constellation = int.Parse(ds.Tables[0].Rows[0]["Constellation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["House"].ToString() != "")
                {
                    model.House = int.Parse(ds.Tables[0].Rows[0]["House"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Star"].ToString() != "")
                {
                    model.Star = int.Parse(ds.Tables[0].Rows[0]["Star"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.Pic = ds.Tables[0].Rows[0]["Pic"].ToString();
                if (ds.Tables[0].Rows[0]["UserSysNo"].ToString() != "")
                {
                    model.UserSysNo = int.Parse(ds.Tables[0].Rows[0]["UserSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Source"].ToString() != "")
                {
                    model.Source = int.Parse(ds.Tables[0].Rows[0]["Source"].ToString());
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
