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
    /// 数据访问类RSH_BaziCondition。
    /// </summary>
    public class RSH_BaziConditionDal
    {
        public RSH_BaziConditionDal() { }
        private static RSH_BaziConditionDal _instance;
        public RSH_BaziConditionDal GetInstance()
        {
            if (_instance == null)
            { _instance = new RSH_BaziConditionDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RSH_BaziConditionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RSH_BaziCondition(");
            strSql.Append("Item,Type,Condition,LogicSysNo,Target,Negative)");
            strSql.Append(" values (");
            strSql.Append("@Item,@Type,@Condition,@LogicSysNo,@Target,@Negative)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Item",SqlDbType.Int,4),
                 new SqlParameter("@Type",SqlDbType.Int,4),
                 new SqlParameter("@Condition",SqlDbType.Int,4),
                 new SqlParameter("@LogicSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Target",SqlDbType.Int,4),
                 new SqlParameter("@Negative",SqlDbType.Int,4),
             };
            if (model.Item != AppConst.IntNull)
                parameters[0].Value = model.Item;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Type != AppConst.IntNull)
                parameters[1].Value = model.Type;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Condition != AppConst.IntNull)
                parameters[2].Value = model.Condition;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.LogicSysNo != AppConst.IntNull)
                parameters[3].Value = model.LogicSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Target != AppConst.IntNull)
                parameters[4].Value = model.Target;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Negative != AppConst.IntNull)
                parameters[5].Value = model.Negative;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(RSH_BaziConditionMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RSH_BaziCondition set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Item != AppConst.IntNull)
            {
                strSql.Append("Item=@Item,");
                SqlParameter param = new SqlParameter("@Item", SqlDbType.Int, 4);
                param.Value = model.Item;
                cmd.Parameters.Add(param);
            }
            if (model.Type != AppConst.IntNull)
            {
                strSql.Append("Type=@Type,");
                SqlParameter param = new SqlParameter("@Type", SqlDbType.Int, 4);
                param.Value = model.Type;
                cmd.Parameters.Add(param);
            }
            if (model.Condition != AppConst.IntNull)
            {
                strSql.Append("Condition=@Condition,");
                SqlParameter param = new SqlParameter("@Condition", SqlDbType.Int, 4);
                param.Value = model.Condition;
                cmd.Parameters.Add(param);
            }
            if (model.LogicSysNo != AppConst.IntNull)
            {
                strSql.Append("LogicSysNo=@LogicSysNo,");
                SqlParameter param = new SqlParameter("@LogicSysNo", SqlDbType.Int, 4);
                param.Value = model.LogicSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Target != AppConst.IntNull)
            {
                strSql.Append("Target=@Target,");
                SqlParameter param = new SqlParameter("@Target", SqlDbType.Int, 4);
                param.Value = model.Target;
                cmd.Parameters.Add(param);
            }
            if (model.Negative != AppConst.IntNull)
            {
                strSql.Append("Negative=@Negative,");
                SqlParameter param = new SqlParameter("@Negative", SqlDbType.Int, 4);
                param.Value = model.Negative;
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
            strSql.Append("delete RSH_BaziCondition ");
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
        public RSH_BaziConditionMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Item, Type, Condition, LogicSysNo, Target, Negative from  dbo.RSH_BaziCondition");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            RSH_BaziConditionMod model = new RSH_BaziConditionMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Item"].ToString() != "")
                {
                    model.Item = int.Parse(ds.Tables[0].Rows[0]["Item"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Condition"].ToString() != "")
                {
                    model.Condition = int.Parse(ds.Tables[0].Rows[0]["Condition"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LogicSysNo"].ToString() != "")
                {
                    model.LogicSysNo = int.Parse(ds.Tables[0].Rows[0]["LogicSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Target"].ToString() != "")
                {
                    model.Target = int.Parse(ds.Tables[0].Rows[0]["Target"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Negative"].ToString() != "")
                {
                    model.Negative = int.Parse(ds.Tables[0].Rows[0]["Negative"].ToString());
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
