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
    /// 数据访问类AdvTopicContent。
    /// </summary>
    public class AdvTopicContentDal
    {
        public AdvTopicContentDal() { }
        private static AdvTopicContentDal _instance;
        public AdvTopicContentDal GetInstance()
        {
            if (_instance == null)
            { _instance = new AdvTopicContentDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(AdvTopicContentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdvTopicContent(");
            strSql.Append("TopicSysNo,Title,Content,DR,TS)");
            strSql.Append(" values (");
            strSql.Append("@TopicSysNo,@Title,@Content,@DR,@TS)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@TopicSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,400),
                 new SqlParameter("@Content",SqlDbType.NVarChar,2000),
                 new SqlParameter("@DR",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime),
             };
            if (model.TopicSysNo != AppConst.IntNull)
                parameters[0].Value = model.TopicSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Title != AppConst.StringNull)
                parameters[1].Value = model.Title;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Content != AppConst.StringNull)
                parameters[2].Value = model.Content;
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

        public int Update(AdvTopicContentMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdvTopicContent set ");
            strSql.Append("TopicSysNo=@TopicSysNo,");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("DR=@DR,");
            strSql.Append("TS=@TS");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@TopicSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Title",SqlDbType.NVarChar,400),
                 new SqlParameter("@Content",SqlDbType.NVarChar,2000),
                 new SqlParameter("@DR",SqlDbType.Int,4),
                 new SqlParameter("@TS",SqlDbType.DateTime)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.TopicSysNo != AppConst.IntNull)
                parameters[1].Value = model.TopicSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Title != AppConst.StringNull)
                parameters[2].Value = model.Title;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Content != AppConst.StringNull)
                parameters[3].Value = model.Content;
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
            strSql.Append("delete AdvTopicContent ");
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

        public AdvTopicContentMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, TopicSysNo, Title, Content, DR, TS from  AdvTopicContent");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            AdvTopicContentMod model = new AdvTopicContentMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TopicSysNo"].ToString() != "")
                {
                    model.TopicSysNo = int.Parse(ds.Tables[0].Rows[0]["TopicSysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
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
