using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AppCmn;
using AppMod.Spider;
namespace AppDal.Spider
{
    /// <summary>
    /// 数据访问类SPD_Famous。
    /// </summary>
    public class SPD_FamousDal
    {
        public SPD_FamousDal() { }
        private static SPD_FamousDal _instance;
        public SPD_FamousDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SPD_FamousDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SPD_FamousMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SPD_Famous(");
            strSql.Append("FamousName,Biography,Birth,Death,Scource,FamousSysNo,ChartASC,Country,HomeTown,IsUnknow,Height,AstroThemeID,BirthTmp,Gender)");
            strSql.Append(" values (");
            strSql.Append("@FamousName,@Biography,@Birth,@Death,@Scource,@FamousSysNo,@ChartASC,@Country,@HomeTown,@IsUnknow,@Height,@AstroThemeID,@BirthTmp,@Gender)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@FamousName",SqlDbType.VarChar,100),
                 new SqlParameter("@Biography",SqlDbType.VarChar,5000),
                 new SqlParameter("@Birth",SqlDbType.DateTime),
                 new SqlParameter("@Death",SqlDbType.DateTime),
                 new SqlParameter("@Scource",SqlDbType.NVarChar,200),
                 new SqlParameter("@FamousSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ChartASC",SqlDbType.VarChar,100),
                 new SqlParameter("@Country",SqlDbType.VarChar,100),
                 new SqlParameter("@HomeTown",SqlDbType.VarChar,100),
                 new SqlParameter("@IsUnknow",SqlDbType.TinyInt,1),
                 new SqlParameter("@Height",SqlDbType.VarChar,100),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@AstroThemeID",SqlDbType.VarChar,100),
                 new SqlParameter("@BirthTmp",SqlDbType.VarChar,100),
                 new SqlParameter("@Gender",SqlDbType.TinyInt,1),
             };
            if (model.FamousName != AppConst.StringNull)
                parameters[0].Value = model.FamousName;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Biography != AppConst.StringNull)
                parameters[1].Value = model.Biography;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Birth != AppConst.DateTimeNull)
                parameters[2].Value = model.Birth;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Death != AppConst.DateTimeNull)
                parameters[3].Value = model.Death;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Scource != AppConst.StringNull)
                parameters[4].Value = model.Scource;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.FamousSysNo != AppConst.IntNull)
                parameters[5].Value = model.FamousSysNo;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.ChartASC != AppConst.StringNull)
                parameters[6].Value = model.ChartASC;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Country != AppConst.StringNull)
                parameters[7].Value = model.Country;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.HomeTown != AppConst.StringNull)
                parameters[8].Value = model.HomeTown;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.IsUnknow != AppConst.IntNull)
                parameters[9].Value = model.IsUnknow;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.Height != AppConst.StringNull)
                parameters[10].Value = model.Height;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.DR != AppConst.IntNull)
                parameters[11].Value = model.DR;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[12].Value = model.TS;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.AstroThemeID != AppConst.StringNull)
                parameters[13].Value = model.AstroThemeID;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.BirthTmp != AppConst.StringNull)
                parameters[14].Value = model.BirthTmp;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.Gender != AppConst.IntNull)
                parameters[15].Value = model.Gender;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(SPD_FamousMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SPD_Famous set ");
            strSql.Append("FamousName=@FamousName,");
            strSql.Append("Biography=@Biography,");
            strSql.Append("Birth=@Birth,");
            strSql.Append("Death=@Death,");
            strSql.Append("Scource=@Scource,");
            strSql.Append("FamousSysNo=@FamousSysNo,");
            strSql.Append("ChartASC=@ChartASC,");
            strSql.Append("Country=@Country,");
            strSql.Append("HomeTown=@HomeTown,");
            strSql.Append("IsUnknow=@IsUnknow,");
            strSql.Append("Height=@Height,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS,");
            strSql.Append("AstroThemeID=@AstroThemeID,");
            strSql.Append("BirthTmp=@BirthTmp,");
            strSql.Append("Gender=@Gender");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@FamousName",SqlDbType.VarChar,100),
                 new SqlParameter("@Biography",SqlDbType.VarChar,5000),
                 new SqlParameter("@Birth",SqlDbType.DateTime),
                 new SqlParameter("@Death",SqlDbType.DateTime),
                 new SqlParameter("@Scource",SqlDbType.NVarChar,200),
                 new SqlParameter("@FamousSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ChartASC",SqlDbType.VarChar,100),
                 new SqlParameter("@Country",SqlDbType.VarChar,100),
                 new SqlParameter("@HomeTown",SqlDbType.VarChar,100),
                 new SqlParameter("@IsUnknow",SqlDbType.TinyInt,1),
                 new SqlParameter("@Height",SqlDbType.VarChar,100),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@AstroThemeID",SqlDbType.VarChar,100),
                 new SqlParameter("@BirthTmp",SqlDbType.VarChar,100),
                 new SqlParameter("@Gender",SqlDbType.TinyInt,1)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.FamousName != AppConst.StringNull)
                parameters[1].Value = model.FamousName;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Biography != AppConst.StringNull)
                parameters[2].Value = model.Biography;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Birth != AppConst.DateTimeNull)
                parameters[3].Value = model.Birth;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Death != AppConst.DateTimeNull)
                parameters[4].Value = model.Death;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Scource != AppConst.StringNull)
                parameters[5].Value = model.Scource;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.FamousSysNo != AppConst.IntNull)
                parameters[6].Value = model.FamousSysNo;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.ChartASC != AppConst.StringNull)
                parameters[7].Value = model.ChartASC;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Country != AppConst.StringNull)
                parameters[8].Value = model.Country;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.HomeTown != AppConst.StringNull)
                parameters[9].Value = model.HomeTown;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.IsUnknow != AppConst.IntNull)
                parameters[10].Value = model.IsUnknow;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Height != AppConst.StringNull)
                parameters[11].Value = model.Height;
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
            if (model.AstroThemeID != AppConst.StringNull)
                parameters[14].Value = model.AstroThemeID;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.BirthTmp != AppConst.StringNull)
                parameters[15].Value = model.BirthTmp;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.Gender != AppConst.IntNull)
                parameters[16].Value = model.Gender;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SPD_Famous ");
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

        public SPD_FamousMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, FamousName, Biography, Birth, Death, Scource, FamousSysNo, ChartASC, Country, HomeTown, IsUnknow, Height, DR, TS, AstroThemeID, BirthTmp, Gender from  SPD_Famous");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SPD_FamousMod model = new SPD_FamousMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.FamousName = ds.Tables[0].Rows[0]["FamousName"].ToString();
                model.Biography = ds.Tables[0].Rows[0]["Biography"].ToString();
                if (ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    model.Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Death"].ToString() != "")
                {
                    model.Death = DateTime.Parse(ds.Tables[0].Rows[0]["Death"].ToString());
                }
                model.Scource = ds.Tables[0].Rows[0]["Scource"].ToString();
                if (ds.Tables[0].Rows[0]["FamousSysNo"].ToString() != "")
                {
                    model.FamousSysNo = int.Parse(ds.Tables[0].Rows[0]["FamousSysNo"].ToString());
                }
                model.ChartASC = ds.Tables[0].Rows[0]["ChartASC"].ToString();
                model.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                model.HomeTown = ds.Tables[0].Rows[0]["HomeTown"].ToString();
                if (ds.Tables[0].Rows[0]["IsUnknow"].ToString() != "")
                {
                    model.IsUnknow = int.Parse(ds.Tables[0].Rows[0]["IsUnknow"].ToString());
                }
                model.Height = ds.Tables[0].Rows[0]["Height"].ToString();
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.AstroThemeID = ds.Tables[0].Rows[0]["AstroThemeID"].ToString();
                model.BirthTmp = ds.Tables[0].Rows[0]["BirthTmp"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
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
