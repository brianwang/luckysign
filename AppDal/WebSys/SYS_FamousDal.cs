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
    /// 数据访问类SYS_Famous。
    /// </summary>
    public class SYS_FamousDal
    {
        public SYS_FamousDal() { }
        private static SYS_FamousDal _instance;
        public SYS_FamousDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_FamousDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_FamousMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_Famous(");
            strSql.Append("Name,Description,BirthYear,BirthTime,Death,CateSysNo,Level,CustomerSysNo,DR,TS,Source,Gender,HomeTown,Height,FullName,TimeUnknown,IsTop,Photo,CollectCount)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Description,@BirthYear,@BirthTime,@Death,@CateSysNo,@Level,@CustomerSysNo,@DR,@TS,@Source,@Gender,@HomeTown,@Height,@FullName,@TimeUnknown,@IsTop,@Photo,@CollectCount)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@Description",SqlDbType.NText,2147483646),
                 new SqlParameter("@BirthYear",SqlDbType.Int,4),
                 new SqlParameter("@BirthTime",SqlDbType.DateTime),
                 new SqlParameter("@Death",SqlDbType.DateTime),
                 new SqlParameter("@CateSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Level",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Source",SqlDbType.VarChar,50),
                 new SqlParameter("@Gender",SqlDbType.TinyInt,1),
                 new SqlParameter("@HomeTown",SqlDbType.Int,4),
                 new SqlParameter("@Height",SqlDbType.Int,4),
                 new SqlParameter("@FullName",SqlDbType.VarChar,100),
                 new SqlParameter("@TimeUnknown",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsTop",SqlDbType.Int,4),
                 new SqlParameter("@Photo",SqlDbType.VarChar,500),
                 new SqlParameter("@CollectCount",SqlDbType.Int,4),
             };
            if (model.Name != AppConst.StringNull)
                parameters[0].Value = model.Name;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Description != AppConst.StringNull)
                parameters[1].Value = model.Description;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.BirthYear != AppConst.IntNull)
                parameters[2].Value = model.BirthYear;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.BirthTime != AppConst.DateTimeNull)
                parameters[3].Value = model.BirthTime;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Death != AppConst.DateTimeNull)
                parameters[4].Value = model.Death;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.CateSysNo != AppConst.IntNull)
                parameters[5].Value = model.CateSysNo;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Level != AppConst.IntNull)
                parameters[6].Value = model.Level;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[7].Value = model.CustomerSysNo;
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
            if (model.Source != AppConst.StringNull)
                parameters[10].Value = model.Source;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Gender != AppConst.IntNull)
                parameters[11].Value = model.Gender;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.HomeTown != AppConst.IntNull)
                parameters[12].Value = model.HomeTown;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.Height != AppConst.IntNull)
                parameters[13].Value = model.Height;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.FullName != AppConst.StringNull)
                parameters[14].Value = model.FullName;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.TimeUnknown != AppConst.IntNull)
                parameters[15].Value = model.TimeUnknown;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.IsTop != AppConst.IntNull)
                parameters[16].Value = model.IsTop;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.Photo != AppConst.StringNull)
                parameters[17].Value = model.Photo;
            else
                parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.CollectCount != AppConst.IntNull)
                parameters[18].Value = model.CollectCount;
            else
                parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(SYS_FamousMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_Famous set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Description=@Description,");
            strSql.Append("BirthYear=@BirthYear,");
            strSql.Append("BirthTime=@BirthTime,");
            strSql.Append("Death=@Death,");
            strSql.Append("CateSysNo=@CateSysNo,");
            strSql.Append("Level=@Level,");
            strSql.Append("CustomerSysNo=@CustomerSysNo,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS,");
            strSql.Append("Source=@Source,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("HomeTown=@HomeTown,");
            strSql.Append("Height=@Height,");
            strSql.Append("FullName=@FullName,");
            strSql.Append("TimeUnknown=@TimeUnknown,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("CollectCount=@CollectCount");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@Description",SqlDbType.NText,2147483646),
                 new SqlParameter("@BirthYear",SqlDbType.Int,4),
                 new SqlParameter("@BirthTime",SqlDbType.DateTime),
                 new SqlParameter("@Death",SqlDbType.DateTime),
                 new SqlParameter("@CateSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Level",SqlDbType.Int,4),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Source",SqlDbType.VarChar,50),
                 new SqlParameter("@Gender",SqlDbType.TinyInt,1),
                 new SqlParameter("@HomeTown",SqlDbType.Int,4),
                 new SqlParameter("@Height",SqlDbType.Int,4),
                 new SqlParameter("@FullName",SqlDbType.VarChar,100),
                 new SqlParameter("@TimeUnknown",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsTop",SqlDbType.Int,4),
                 new SqlParameter("@Photo",SqlDbType.VarChar,500),
                 new SqlParameter("@CollectCount",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Name != AppConst.StringNull)
                parameters[1].Value = model.Name;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Description != AppConst.StringNull)
                parameters[2].Value = model.Description;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.BirthYear != AppConst.IntNull)
                parameters[3].Value = model.BirthYear;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.BirthTime != AppConst.DateTimeNull)
                parameters[4].Value = model.BirthTime;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Death != AppConst.DateTimeNull)
                parameters[5].Value = model.Death;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.CateSysNo != AppConst.IntNull)
                parameters[6].Value = model.CateSysNo;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Level != AppConst.IntNull)
                parameters[7].Value = model.Level;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[8].Value = model.CustomerSysNo;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.DR != AppConst.IntNull)
                parameters[9].Value = model.DR;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[10].Value = model.TS;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Source != AppConst.StringNull)
                parameters[11].Value = model.Source;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.Gender != AppConst.IntNull)
                parameters[12].Value = model.Gender;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.HomeTown != AppConst.IntNull)
                parameters[13].Value = model.HomeTown;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.Height != AppConst.IntNull)
                parameters[14].Value = model.Height;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.FullName != AppConst.StringNull)
                parameters[15].Value = model.FullName;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.TimeUnknown != AppConst.IntNull)
                parameters[16].Value = model.TimeUnknown;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.IsTop != AppConst.IntNull)
                parameters[17].Value = model.IsTop;
            else
                parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.Photo != AppConst.StringNull)
                parameters[18].Value = model.Photo;
            else
                parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);
            if (model.CollectCount != AppConst.IntNull)
                parameters[19].Value = model.CollectCount;
            else
                parameters[19].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[19]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_Famous ");
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

        public SYS_FamousMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Name, Description, BirthYear, BirthTime, Death, CateSysNo, Level, CustomerSysNo, DR, TS, Source, Gender, HomeTown, Height, FullName, TimeUnknown, IsTop, Photo, CollectCount from  SYS_Famous");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_FamousMod model = new SYS_FamousMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["BirthYear"].ToString() != "")
                {
                    model.BirthYear = int.Parse(ds.Tables[0].Rows[0]["BirthYear"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BirthTime"].ToString() != "")
                {
                    model.BirthTime = DateTime.Parse(ds.Tables[0].Rows[0]["BirthTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Death"].ToString() != "")
                {
                    model.Death = DateTime.Parse(ds.Tables[0].Rows[0]["Death"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CateSysNo"].ToString() != "")
                {
                    model.CateSysNo = int.Parse(ds.Tables[0].Rows[0]["CateSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HomeTown"].ToString() != "")
                {
                    model.HomeTown = int.Parse(ds.Tables[0].Rows[0]["HomeTown"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Height"].ToString() != "")
                {
                    model.Height = int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
                }
                model.FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                if (ds.Tables[0].Rows[0]["TimeUnknown"].ToString() != "")
                {
                    model.TimeUnknown = int.Parse(ds.Tables[0].Rows[0]["TimeUnknown"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                model.Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                if (ds.Tables[0].Rows[0]["CollectCount"].ToString() != "")
                {
                    model.CollectCount = int.Parse(ds.Tables[0].Rows[0]["CollectCount"].ToString());
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
