using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using AppMod.User;
namespace AppDal.User
{
    /// <summary>
    /// 数据访问类USR_Grade。
    /// </summary>
    public class USR_GradeDal
    {
        public USR_GradeDal() { }
        private static USR_GradeDal _instance;
        public USR_GradeDal GetInstance()
        {
            if (_instance == null)
            { _instance = new USR_GradeDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_GradeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_Grade(");
            strSql.Append("Name,LevelNum,Exp)");
            strSql.Append(" values (");
            strSql.Append("@Name,@LevelNum,@Exp)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@LevelNum",SqlDbType.Int,4),
                 new SqlParameter("@Exp",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.Name != AppConst.StringNull)
                parameters[0].Value = model.Name;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.LevelNum != AppConst.IntNull)
                parameters[1].Value = model.LevelNum;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Exp != AppConst.IntNull)
                parameters[2].Value = model.Exp;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.DR != AppConst.IntNull)
                parameters[3].Value = model.DR;
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

        public int Update(USR_GradeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_Grade set ");
            strSql.Append("Name=@Name,");
            strSql.Append("LevelNum=@LevelNum,");
            strSql.Append("Exp=@Exp,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@LevelNum",SqlDbType.Int,4),
                 new SqlParameter("@Exp",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
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
            if (model.LevelNum != AppConst.IntNull)
                parameters[2].Value = model.LevelNum;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Exp != AppConst.IntNull)
                parameters[3].Value = model.Exp;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.DR != AppConst.IntNull)
                parameters[4].Value = model.DR;
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
            strSql.Append("delete USR_Grade ");
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

        public USR_GradeMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Name, LevelNum, Exp, DR, TS from  USR_Grade");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            USR_GradeMod model = new USR_GradeMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["LevelNum"].ToString() != "")
                {
                    model.LevelNum = int.Parse(ds.Tables[0].Rows[0]["LevelNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Exp"].ToString() != "")
                {
                    model.Exp = int.Parse(ds.Tables[0].Rows[0]["Exp"].ToString());
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
