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
    /// 数据访问类AdvUser。
    /// </summary>
    public class AdvUserDal
    {
        public AdvUserDal() { }
        private static AdvUserDal _instance;
        public AdvUserDal GetInstance()
        {
            if (_instance == null)
            { _instance = new AdvUserDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(AdvUserMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdvUser(");
            strSql.Append("Name,CellPhone,FirstRequestUrl,SSQianSysNo,BirthTime,Gender,DistrictSysNo,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@Name,@CellPhone,@FirstRequestUrl,@SSQianSysNo,@BirthTime,@Gender,@DistrictSysNo,@DR,@TS)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Name",SqlDbType.NVarChar,40),
                 new SqlParameter("@CellPhone",SqlDbType.VarChar,20),
                 new SqlParameter("@FirstRequestUrl",SqlDbType.NVarChar,600),
                 new SqlParameter("@SSQianSysNo",SqlDbType.Int,4),
                 new SqlParameter("@BirthTime",SqlDbType.DateTime),
                 new SqlParameter("@Gender",SqlDbType.Int,4),
                 new SqlParameter("@DistrictSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.Name != AppConst.StringNull)
                parameters[0].Value = model.Name;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CellPhone != AppConst.StringNull)
                parameters[1].Value = model.CellPhone;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.FirstRequestUrl != AppConst.StringNull)
                parameters[2].Value = model.FirstRequestUrl;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.SSQianSysNo != AppConst.IntNull)
                parameters[3].Value = model.SSQianSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.BirthTime != AppConst.DateTimeNull)
                parameters[4].Value = model.BirthTime;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Gender != AppConst.IntNull)
                parameters[5].Value = model.Gender;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.DistrictSysNo != AppConst.IntNull)
                parameters[6].Value = model.DistrictSysNo;
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

        public int Update(AdvUserMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdvUser set ");
            strSql.Append("Name=@Name,");
            strSql.Append("CellPhone=@CellPhone,");
            strSql.Append("FirstRequestUrl=@FirstRequestUrl,");
            strSql.Append("SSQianSysNo=@SSQianSysNo,");
            strSql.Append("BirthTime=@BirthTime,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("DistrictSysNo=@DistrictSysNo,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,40),
                 new SqlParameter("@CellPhone",SqlDbType.VarChar,20),
                 new SqlParameter("@FirstRequestUrl",SqlDbType.NVarChar,600),
                 new SqlParameter("@SSQianSysNo",SqlDbType.Int,4),
                 new SqlParameter("@BirthTime",SqlDbType.DateTime),
                 new SqlParameter("@Gender",SqlDbType.Int,4),
                 new SqlParameter("@DistrictSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime)
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
            if (model.CellPhone != AppConst.StringNull)
                parameters[2].Value = model.CellPhone;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.FirstRequestUrl != AppConst.StringNull)
                parameters[3].Value = model.FirstRequestUrl;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.SSQianSysNo != AppConst.IntNull)
                parameters[4].Value = model.SSQianSysNo;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.BirthTime != AppConst.DateTimeNull)
                parameters[5].Value = model.BirthTime;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Gender != AppConst.IntNull)
                parameters[6].Value = model.Gender;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.DistrictSysNo != AppConst.IntNull)
                parameters[7].Value = model.DistrictSysNo;
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
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete AdvUser ");
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

        public AdvUserMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Name, CellPhone, FirstRequestUrl, SSQianSysNo, BirthTime, Gender, DistrictSysNo, DR, TS from  AdvUser");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            AdvUserMod model = new AdvUserMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.CellPhone = ds.Tables[0].Rows[0]["CellPhone"].ToString();
                model.FirstRequestUrl = ds.Tables[0].Rows[0]["FirstRequestUrl"].ToString();
                if (ds.Tables[0].Rows[0]["SSQianSysNo"].ToString() != "")
                {
                    model.SSQianSysNo = int.Parse(ds.Tables[0].Rows[0]["SSQianSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BirthTime"].ToString() != "")
                {
                    model.BirthTime = DateTime.Parse(ds.Tables[0].Rows[0]["BirthTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DistrictSysNo"].ToString() != "")
                {
                    model.DistrictSysNo = int.Parse(ds.Tables[0].Rows[0]["DistrictSysNo"].ToString());
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
