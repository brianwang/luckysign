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
    public class REL_Famous_KeyWordDal
    {
        public REL_Famous_KeyWordDal() { }
        private static REL_Famous_KeyWordDal _instance;
        public REL_Famous_KeyWordDal GetInstance()
        {
            if (_instance == null)
            { _instance = new REL_Famous_KeyWordDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Famous_KeyWordMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into REL_Famous_KeyWord(");
            strSql.Append("Famous_SysNo,KeyWord_SysNo,Value)");
            strSql.Append(" values (");
            strSql.Append("@Famous_SysNo,@KeyWord_SysNo,@Value)");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Famous_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@KeyWord_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Value",SqlDbType.Int,4)
             };
            if (model.Famous_SysNo != AppConst.IntNull)
                parameters[0].Value = model.Famous_SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.KeyWord_SysNo != AppConst.IntNull)
                parameters[1].Value = model.KeyWord_SysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Value != AppConst.IntNull)
                parameters[2].Value = model.Value;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(REL_Famous_KeyWordMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update REL_Famous_KeyWord set ");
            strSql.Append("Famous_SysNo=@Famous_SysNo,");
            strSql.Append("KeyWord_SysNo=@KeyWord_SysNo,");
            strSql.Append("Value=@Value");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Famous_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@KeyWord_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Value",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Famous_SysNo != AppConst.IntNull)
                parameters[1].Value = model.Famous_SysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.KeyWord_SysNo != AppConst.IntNull)
                parameters[2].Value = model.KeyWord_SysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Value != AppConst.IntNull)
                parameters[3].Value = model.Value;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete REL_Famous_KeyWord ");
            strSql.Append(" where SysNo=@SysNo");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
			new SqlParameter("@SysNo", SqlDbType.Int,4)
		};
            parameters[0].Value = SysNo;

            parameters[0].Value = System.DBNull.Value;
            parameters[0].Value = SysNo;
            cmd.Parameters.Add(parameters[0]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public REL_Famous_KeyWordMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Famous_SysNo, KeyWord_SysNo, Value from REL_Famous_KeyWord");
            strSql.Append(" where SysNo=@SysNo");
            SqlParameter[] parameters = { 
		  new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            REL_Famous_KeyWordMod model = new REL_Famous_KeyWordMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Famous_SysNo"].ToString() != "")
                {
                    model.Famous_SysNo = int.Parse(ds.Tables[0].Rows[0]["Famous_SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KeyWord_SysNo"].ToString() != "")
                {
                    model.KeyWord_SysNo = int.Parse(ds.Tables[0].Rows[0]["KeyWord_SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Value"].ToString() != "")
                {
                    model.Value = int.Parse(ds.Tables[0].Rows[0]["Value"].ToString());
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
