using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.CMS;

namespace AppDal.CMS
{
    /// <summary>
    /// 数据访问类CMS_Category。
    /// </summary>
    public class CMS_CategoryDal
    {
        public CMS_CategoryDal() { }
        private static CMS_CategoryDal _instance;
        public CMS_CategoryDal GetInstance()
        {
            if (_instance == null)
            { _instance = new CMS_CategoryDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(CMS_CategoryMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Category(");
            strSql.Append("Name,ParentSysNo,TopSysNo,IsHide,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@Name,@ParentSysNo,@TopSysNo,@IsHide,@DR,@TS)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@ParentSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TopSysNo",SqlDbType.Int,4),
                 new SqlParameter("@IsHide",SqlDbType.TinyInt,1),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.Name != AppConst.StringNull)
                parameters[0].Value = model.Name;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.ParentSysNo != AppConst.IntNull)
                parameters[1].Value = model.ParentSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.TopSysNo != AppConst.IntNull)
                parameters[2].Value = model.TopSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.IsHide != AppConst.IntNull)
                parameters[3].Value = model.IsHide;
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

            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int UpDate(CMS_CategoryMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Category set ");
            strSql.Append("Name=@Name,");
            strSql.Append("ParentSysNo=@ParentSysNo,");
            strSql.Append("TopSysNo=@TopSysNo,");
            strSql.Append("IsHide=@IsHide,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@ParentSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TopSysNo",SqlDbType.Int,4),
                 new SqlParameter("@IsHide",SqlDbType.TinyInt,1),
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
            if (model.ParentSysNo != AppConst.IntNull)
                parameters[2].Value = model.ParentSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TopSysNo != AppConst.IntNull)
                parameters[3].Value = model.TopSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.IsHide != AppConst.IntNull)
                parameters[4].Value = model.IsHide;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.DR != AppConst.IntNull)
                parameters[5].Value = model.DR;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[6].Value = model.TS;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CMS_Category ");
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

        public CMS_CategoryMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Name, ParentSysNo, TopSysNo, IsHide, DR, TS from  CMS_Category");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            CMS_CategoryMod model = new CMS_CategoryMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["ParentSysNo"].ToString() != "")
                {
                    model.ParentSysNo = int.Parse(ds.Tables[0].Rows[0]["ParentSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TopSysNo"].ToString() != "")
                {
                    model.TopSysNo = int.Parse(ds.Tables[0].Rows[0]["TopSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHide"].ToString() != "")
                {
                    model.IsHide = int.Parse(ds.Tables[0].Rows[0]["IsHide"].ToString());
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
