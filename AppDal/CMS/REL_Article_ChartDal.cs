using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.CMS;

namespace AppDal.CMS
{
    public class REL_Article_ChartDal
    {
        public REL_Article_ChartDal() { }
        private static REL_Article_ChartDal _instance;
        public REL_Article_ChartDal GetInstance()
        {
            if (_instance == null)
            { _instance = new REL_Article_ChartDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Article_ChartMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into REL_Article_Chart(");
            strSql.Append("Article_SysNo,Chart_SysNo)");
            strSql.Append(" values (");
            strSql.Append("@Article_SysNo,@Chart_SysNo)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Article_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Chart_SysNo",SqlDbType.Int,4),
             };
            if (model.Article_SysNo != AppConst.IntNull)
                parameters[0].Value = model.Article_SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Chart_SysNo != AppConst.IntNull)
                parameters[1].Value = model.Chart_SysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(REL_Article_ChartMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update REL_Article_Chart set ");
            strSql.Append("Article_SysNo=@Article_SysNo,");
            strSql.Append("Chart_SysNo=@Chart_SysNo");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Article_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Chart_SysNo",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Article_SysNo != AppConst.IntNull)
                parameters[1].Value = model.Article_SysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Chart_SysNo != AppConst.IntNull)
                parameters[2].Value = model.Chart_SysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete REL_Article_Chart ");
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

        public REL_Article_ChartMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Article_SysNo, Chart_SysNo from  REL_Article_Chart");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            REL_Article_ChartMod model = new REL_Article_ChartMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Article_SysNo"].ToString() != "")
                {
                    model.Article_SysNo = int.Parse(ds.Tables[0].Rows[0]["Article_SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Chart_SysNo"].ToString() != "")
                {
                    model.Chart_SysNo = int.Parse(ds.Tables[0].Rows[0]["Chart_SysNo"].ToString());
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
