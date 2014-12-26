using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.User;

namespace AppDal.User
{
    public class USR_NoticeDal
    {
        public USR_NoticeDal() { }
        private static USR_NoticeDal _instance;
        public USR_NoticeDal GetInstance()
        {
            if (_instance == null)
            { _instance = new USR_NoticeDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_NoticeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_Notice(");
            strSql.Append("CustomerNum,Title,Context,DR,TS,Condition)");
            strSql.Append(" values (");
            strSql.Append("@CustomerNum,@Title,@Context,@DR,@TS,@Condition)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CustomerNum",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,200),
                 new SqlParameter("@Context",SqlDbType.VarChar,1000),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Condition",SqlDbType.VarChar,200),
             };
            if (model.CustomerNum != AppConst.IntNull)
                parameters[0].Value = model.CustomerNum;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Title != AppConst.StringNull)
                parameters[1].Value = model.Title;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Context != AppConst.StringNull)
                parameters[2].Value = model.Context;
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
            if (model.Condition != AppConst.StringNull)
                parameters[5].Value = model.Condition;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(USR_NoticeMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_Notice set ");
            strSql.Append("CustomerNum=@CustomerNum,");
            strSql.Append("Title=@Title,");
            strSql.Append("Context=@Context,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS,");
            strSql.Append("Condition=@Condition");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CustomerNum",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,200),
                 new SqlParameter("@Context",SqlDbType.VarChar,1000),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Condition",SqlDbType.VarChar,200)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CustomerNum != AppConst.IntNull)
                parameters[1].Value = model.CustomerNum;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Title != AppConst.StringNull)
                parameters[2].Value = model.Title;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Context != AppConst.StringNull)
                parameters[3].Value = model.Context;
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
            if (model.Condition != AppConst.StringNull)
                parameters[6].Value = model.Condition;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete USR_Notice ");
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

        public USR_NoticeMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, CustomerNum, Title, Context, DR, TS, Condition from  USR_Notice");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            USR_NoticeMod model = new USR_NoticeMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerNum"].ToString() != "")
                {
                    model.CustomerNum = int.Parse(ds.Tables[0].Rows[0]["CustomerNum"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.Condition = ds.Tables[0].Rows[0]["Condition"].ToString();
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
