using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using AppMod.WebSys;

namespace AppDal.WebSys
{
    /// <summary>
    /// 数据访问类SYS_District。
    /// </summary>
    public class SYS_DistrictDal
    {
        public SYS_DistrictDal() { }
        private static SYS_DistrictDal _instance;
        public SYS_DistrictDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_DistrictDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_DistrictMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_District(");
            strSql.Append("UpSysNo,Name,EnglishName,Level,UseType,Latitude,longitude,TopSysNo)");
            strSql.Append(" values (");
            strSql.Append("@UpSysNo,@Name,@EnglishName,@Level,@UseType,@Latitude,@longitude,@TopSysNo)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@UpSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,100),
                 new SqlParameter("@EnglishName",SqlDbType.VarChar,100),
                 new SqlParameter("@Level",SqlDbType.Int,4),
                 new SqlParameter("@UseType",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Latitude",SqlDbType.VarChar,50),
                 new SqlParameter("@longitude",SqlDbType.VarChar,50),
                 new SqlParameter("@TopSysNo",SqlDbType.Int,4),
             };
            if (model.UpSysNo != AppConst.IntNull)
                parameters[0].Value = model.UpSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Name != AppConst.StringNull)
                parameters[1].Value = model.Name;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.EnglishName != AppConst.StringNull)
                parameters[2].Value = model.EnglishName;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Level != AppConst.IntNull)
                parameters[3].Value = model.Level;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.UseType != AppConst.IntNull)
                parameters[4].Value = model.UseType;
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
            if (model.Latitude != AppConst.StringNull)
                parameters[7].Value = model.Latitude;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.longitude != AppConst.StringNull)
                parameters[8].Value = model.longitude;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.TopSysNo != AppConst.IntNull)
                parameters[9].Value = model.TopSysNo;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(SYS_DistrictMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_District set ");
            strSql.Append("UpSysNo=@UpSysNo,");
            strSql.Append("Name=@Name,");
            strSql.Append("EnglishName=@EnglishName,");
            strSql.Append("Level=@Level,");
            strSql.Append("UseType=@UseType,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS,");
            strSql.Append("Latitude=@Latitude,");
            strSql.Append("longitude=@longitude,");
            strSql.Append("TopSysNo=@TopSysNo");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@UpSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,100),
                 new SqlParameter("@EnglishName",SqlDbType.VarChar,100),
                 new SqlParameter("@Level",SqlDbType.Int,4),
                 new SqlParameter("@UseType",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Latitude",SqlDbType.VarChar,50),
                 new SqlParameter("@longitude",SqlDbType.VarChar,50),
                 new SqlParameter("@TopSysNo",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.UpSysNo != AppConst.IntNull)
                parameters[1].Value = model.UpSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Name != AppConst.StringNull)
                parameters[2].Value = model.Name;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.EnglishName != AppConst.StringNull)
                parameters[3].Value = model.EnglishName;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Level != AppConst.IntNull)
                parameters[4].Value = model.Level;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.UseType != AppConst.IntNull)
                parameters[5].Value = model.UseType;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.DR != AppConst.IntNull)
                parameters[6].Value = model.DR;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[7].Value = model.TS;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Latitude != AppConst.StringNull)
                parameters[8].Value = model.Latitude;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.longitude != AppConst.StringNull)
                parameters[9].Value = model.longitude;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.TopSysNo != AppConst.IntNull)
                parameters[10].Value = model.TopSysNo;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_District ");
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

        public SYS_DistrictMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, UpSysNo, Name, EnglishName, Level, UseType, DR, TS, Latitude, longitude, TopSysNo from  SYS_District");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_DistrictMod model = new SYS_DistrictMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpSysNo"].ToString() != "")
                {
                    model.UpSysNo = int.Parse(ds.Tables[0].Rows[0]["UpSysNo"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.EnglishName = ds.Tables[0].Rows[0]["EnglishName"].ToString();
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseType"].ToString() != "")
                {
                    model.UseType = int.Parse(ds.Tables[0].Rows[0]["UseType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.Latitude = ds.Tables[0].Rows[0]["Latitude"].ToString();
                model.longitude = ds.Tables[0].Rows[0]["longitude"].ToString();
                if (ds.Tables[0].Rows[0]["TopSysNo"].ToString() != "")
                {
                    model.TopSysNo = int.Parse(ds.Tables[0].Rows[0]["TopSysNo"].ToString());
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
