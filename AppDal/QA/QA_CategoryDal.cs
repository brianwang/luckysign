﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.QA;

namespace AppDal.QA
{
    public class QA_CategoryDal
    {
        public QA_CategoryDal() { }
        private static QA_CategoryDal _instance;
        public QA_CategoryDal GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_CategoryDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_CategoryMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QA_Category(");
            strSql.Append("Name,ParentSysNo,TopSysNo,DR,TS,Pic,Intro,OrderID)");
            strSql.Append(" values (");
            strSql.Append("@Name,@ParentSysNo,@TopSysNo,@DR,@TS,@Pic,@Intro,@OrderID)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@ParentSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TopSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Pic",SqlDbType.NVarChar,500),
                 new SqlParameter("@Intro",SqlDbType.NVarChar,1000),
                 new SqlParameter("@OrderID",SqlDbType.Int,4),
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
            if (model.Pic != AppConst.StringNull)
                parameters[5].Value = model.Pic;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Intro != AppConst.StringNull)
                parameters[6].Value = model.Intro;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.OrderID != AppConst.IntNull)
                parameters[7].Value = model.OrderID;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(QA_CategoryMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QA_Category set ");
            strSql.Append("Name=@Name,");
            strSql.Append("ParentSysNo=@ParentSysNo,");
            strSql.Append("TopSysNo=@TopSysNo,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append("Pic=@Pic");
            strSql.Append("Intro=@Intro");
            strSql.Append("OrderID=@OrderID");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Name",SqlDbType.NVarChar,200),
                 new SqlParameter("@ParentSysNo",SqlDbType.Int,4),
                 new SqlParameter("@TopSysNo",SqlDbType.Int,4),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Pic",SqlDbType.NVarChar,500),
                 new SqlParameter("@Intro",SqlDbType.NVarChar,1000),
                 new SqlParameter("@OrderID",SqlDbType.Int,4),
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
            if (model.Pic != AppConst.StringNull)
                parameters[6].Value = model.Pic;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Intro != AppConst.StringNull)
                parameters[7].Value = model.Intro;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.OrderID != AppConst.IntNull)
                parameters[8].Value = model.OrderID;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete QA_Category ");
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

        public QA_CategoryMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Name, ParentSysNo, TopSysNo, DR, TS, Pic, Intro, OrderID from QA_Category");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            QA_CategoryMod model = new QA_CategoryMod();
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
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.Pic = ds.Tables[0].Rows[0]["Pic"].ToString();
                model.Intro = ds.Tables[0].Rows[0]["Intro"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
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
