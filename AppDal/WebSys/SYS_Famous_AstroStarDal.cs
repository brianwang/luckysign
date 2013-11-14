using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.WebSys;

namespace AppDal.WebSys
{
    public class SYS_Famous_AstroStarDal
    {
        public SYS_Famous_AstroStarDal() { }
        private static SYS_Famous_AstroStarDal _instance;
        public SYS_Famous_AstroStarDal GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_Famous_AstroStarDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_Famous_AstroStarMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_Famous_AstroStar(");
            strSql.Append("FamousSysNo,Star,Gong,Degree,Cent,Constellation,Progress)");
            strSql.Append(" values (");
            strSql.Append("@FamousSysNo,@Star,@Gong,@Degree,@Cent,@Constellation,@Progress)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@FamousSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Star",SqlDbType.Int,4),
                 new SqlParameter("@Gong",SqlDbType.Int,4),
                 new SqlParameter("@Degree",SqlDbType.Int,4),
                 new SqlParameter("@Cent",SqlDbType.Decimal,18),
                 new SqlParameter("@Constellation",SqlDbType.Int,4),
                 new SqlParameter("@Progress",SqlDbType.Decimal,18),
             };
            if (model.FamousSysNo != AppConst.IntNull)
                parameters[0].Value = model.FamousSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Star != AppConst.IntNull)
                parameters[1].Value = model.Star;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Gong != AppConst.IntNull)
                parameters[2].Value = model.Gong;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Degree != AppConst.IntNull)
                parameters[3].Value = model.Degree;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Cent != AppConst.DecimalNull)
                parameters[4].Value = model.Cent;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Constellation != AppConst.IntNull)
                parameters[5].Value = model.Constellation;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Progress != AppConst.DecimalNull)
                parameters[6].Value = model.Progress;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(SYS_Famous_AstroStarMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_Famous_AstroStar set ");
            strSql.Append("FamousSysNo=@FamousSysNo,");
            strSql.Append("Star=@Star,");
            strSql.Append("Gong=@Gong,");
            strSql.Append("Degree=@Degree,");
            strSql.Append("Cent=@Cent,");
            strSql.Append("Constellation=@Constellation,");
            strSql.Append("Progress=@Progress");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@FamousSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Star",SqlDbType.Int,4),
                 new SqlParameter("@Gong",SqlDbType.Int,4),
                 new SqlParameter("@Degree",SqlDbType.Int,4),
                 new SqlParameter("@Cent",SqlDbType.Decimal,20),
                 new SqlParameter("@Constellation",SqlDbType.Int,4),
                 new SqlParameter("@Progress",SqlDbType.Decimal,20)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.FamousSysNo != AppConst.IntNull)
                parameters[1].Value = model.FamousSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Star != AppConst.IntNull)
                parameters[2].Value = model.Star;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Gong != AppConst.IntNull)
                parameters[3].Value = model.Gong;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Degree != AppConst.IntNull)
                parameters[4].Value = model.Degree;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Cent != AppConst.DecimalNull)
                parameters[5].Value = model.Cent;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Constellation != AppConst.IntNull)
                parameters[6].Value = model.Constellation;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Progress != AppConst.DecimalNull)
                parameters[7].Value = model.Progress;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SYS_Famous_AstroStar ");
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

        public SYS_Famous_AstroStarMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, FamousSysNo, Star, Gong, Degree, Cent, Constellation, Progress from  SYS_Famous_AstroStar");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SYS_Famous_AstroStarMod model = new SYS_Famous_AstroStarMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FamousSysNo"].ToString() != "")
                {
                    model.FamousSysNo = int.Parse(ds.Tables[0].Rows[0]["FamousSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Star"].ToString() != "")
                {
                    model.Star = int.Parse(ds.Tables[0].Rows[0]["Star"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Gong"].ToString() != "")
                {
                    model.Gong = int.Parse(ds.Tables[0].Rows[0]["Gong"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Degree"].ToString() != "")
                {
                    model.Degree = int.Parse(ds.Tables[0].Rows[0]["Degree"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Cent"].ToString() != "")
                {
                    model.Cent = decimal.Parse(ds.Tables[0].Rows[0]["Cent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Constellation"].ToString() != "")
                {
                    model.Constellation = int.Parse(ds.Tables[0].Rows[0]["Constellation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Progress"].ToString() != "")
                {
                    model.Progress = decimal.Parse(ds.Tables[0].Rows[0]["Progress"].ToString());
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
