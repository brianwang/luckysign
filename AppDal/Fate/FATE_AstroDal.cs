using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using AppMod.Fate;

namespace AppDal.Fate
{
    /// <summary>
    /// 数据访问类FATE_Astro。
    /// </summary>
    public class FATE_AstroDal
    {
        public FATE_AstroDal() { }
        private static FATE_AstroDal _instance;
        public FATE_AstroDal GetInstance()
        {
            if (_instance == null)
            { _instance = new FATE_AstroDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(FATE_AstroMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FATE_Astro(");
            strSql.Append("ID,LastTime)");
            strSql.Append(" values (");
            strSql.Append("@ID,@LastTime)");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@ID",SqlDbType.VarChar,200),
                 new SqlParameter("@LastTime",SqlDbType.DateTime),
                 new SqlParameter("@DR",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.ID != AppConst.StringNull)
                parameters[0].Value = model.ID;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.LastTime != AppConst.DateTimeNull)
                parameters[1].Value = model.LastTime;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.DR != AppConst.IntNull)
                parameters[2].Value = model.DR;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[3].Value = model.TS;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(FATE_AstroMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FATE_Astro set ");
            strSql.Append("LastTime=@LastTime,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where ID=@ID ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@ID",SqlDbType.VarChar,200),
                 new SqlParameter("@LastTime",SqlDbType.DateTime),
                 new SqlParameter("@DR",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.ID != AppConst.StringNull)
                parameters[0].Value = model.ID;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.LastTime != AppConst.DateTimeNull)
                parameters[1].Value = model.LastTime;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.DR != AppConst.IntNull)
                parameters[2].Value = model.DR;
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
        /// 删除一条数据
        /// </summary>

        public int Delete(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FATE_Astro ");
            strSql.Append(" where ID=@ID");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
			new SqlParameter("@ID", SqlDbType.VarChar,200)
		};
            parameters[0].Value = ID;

            parameters[0].Value = System.DBNull.Value;
            parameters[0].Value = ID;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public FATE_AstroMod GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, LastTime, DR, TS from FATE_Astro");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = { 
		  new SqlParameter("@ID", SqlDbType.VarChar,200 )
 		};
            parameters[0].Value = ID;
            FATE_AstroMod model = new FATE_AstroMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                if (ds.Tables[0].Rows[0]["LastTime"].ToString() != "")
                {
                    model.LastTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastTime"].ToString());
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
