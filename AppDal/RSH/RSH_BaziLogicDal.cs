using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Research;
namespace AppDal.Research
{
    /// <summary>
    /// 数据访问类RSH_BaziLogic。
    /// </summary>
    public class RSH_BaziLogicDal
    {
        public RSH_BaziLogicDal() { }
        private static RSH_BaziLogicDal _instance;
        public RSH_BaziLogicDal GetInstance()
        {
            if (_instance == null)
            { _instance = new RSH_BaziLogicDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RSH_BaziLogicMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RSH_BaziLogic(");
            strSql.Append("Name,Description,Logic,Type,DR)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Description,@Logic,@Type,@DR)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@Description",SqlDbType.NVarChar,2000),
                 new SqlParameter("@Logic",SqlDbType.VarChar,1000),
                 new SqlParameter("@Type",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.Int,4),
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
            if (model.Logic != AppConst.StringNull)
                parameters[2].Value = model.Logic;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Type != AppConst.IntNull)
                parameters[3].Value = model.Type;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.DR != AppConst.IntNull)
                parameters[4].Value = model.DR;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(RSH_BaziLogicMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RSH_BaziLogic set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Name != AppConst.StringNull)
            {
                strSql.Append("Name=@Name,");
                SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar, 200);
                param.Value = model.Name;
                cmd.Parameters.Add(param);
            }
            if (model.Description != AppConst.StringNull)
            {
                strSql.Append("Description=@Description,");
                SqlParameter param = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
                param.Value = model.Description;
                cmd.Parameters.Add(param);
            }
            if (model.Logic != AppConst.StringNull)
            {
                strSql.Append("Logic=@Logic,");
                SqlParameter param = new SqlParameter("@Logic", SqlDbType.VarChar, 1000);
                param.Value = model.Logic;
                cmd.Parameters.Add(param);
            }
            if (model.Type != AppConst.IntNull)
            {
                strSql.Append("Type=@Type,");
                SqlParameter param = new SqlParameter("@Type", SqlDbType.Int, 4);
                param.Value = model.Type;
                cmd.Parameters.Add(param);
            }
            if (model.DR != AppConst.IntNull)
            {
                strSql.Append("DR=@DR,");
                SqlParameter param = new SqlParameter("@DR", SqlDbType.Int, 4);
                param.Value = model.DR;
                cmd.Parameters.Add(param);
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append(" where SysNo=@SysNo ");
            cmd.CommandText = strSql.ToString();
            return SqlHelper.ExecuteNonQuery(cmd, null);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete RSH_BaziLogic ");
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
        public RSH_BaziLogicMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Name, Description, Logic, Type, DR from  dbo.RSH_BaziLogic");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            RSH_BaziLogicMod model = new RSH_BaziLogicMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.Logic = ds.Tables[0].Rows[0]["Logic"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
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
