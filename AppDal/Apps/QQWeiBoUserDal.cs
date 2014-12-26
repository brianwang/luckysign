using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Apps;


namespace AppDal.Apps
{
    public class QQWeiBoUserDal
    {
        public QQWeiBoUserDal() { }
        private static QQWeiBoUserDal _instance;
        public QQWeiBoUserDal GetInstance()
        {
            if (_instance == null)
            { _instance = new QQWeiBoUserDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QQWeiBoUserMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Apps.dbo.QQWeiBoUser(");
            strSql.Append("OpenId,WB_Name,WB_Nick,Oauth2Token,Expire,TS,Location,FansNum,IsVIP,OpenId1,Oauth2Token1,Expire1,CustomerSysNo)");
            strSql.Append(" values (");
            strSql.Append("@OpenId,@WB_Name,@WB_Nick,@Oauth2Token,@Expire,@TS,@Location,@FansNum,@IsVIP,@OpenId1,@Oauth2Token1,@Expire1,@CustomerSysNo)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@OpenId",SqlDbType.VarChar,100),
                 new SqlParameter("@WB_Name",SqlDbType.VarChar,100),
                 new SqlParameter("@WB_Nick",SqlDbType.NVarChar,200),
                 new SqlParameter("@Oauth2Token",SqlDbType.VarChar,100),
                 new SqlParameter("@Expire",SqlDbType.DateTime),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Location",SqlDbType.NVarChar,200),
                 new SqlParameter("@FansNum",SqlDbType.Int,4),
                 new SqlParameter("@IsVIP",SqlDbType.Int,4),
                 new SqlParameter("@OpenId1",SqlDbType.VarChar,100),
                 new SqlParameter("@Oauth2Token1",SqlDbType.VarChar,100),
                 new SqlParameter("@Expire1",SqlDbType.DateTime),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4),
             };
            if (model.OpenId != AppConst.StringNull)
                parameters[0].Value = model.OpenId;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.WB_Name != AppConst.StringNull)
                parameters[1].Value = model.WB_Name;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.WB_Nick != AppConst.StringNull)
                parameters[2].Value = model.WB_Nick;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Oauth2Token != AppConst.StringNull)
                parameters[3].Value = model.Oauth2Token;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Expire != AppConst.DateTimeNull)
                parameters[4].Value = model.Expire;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[5].Value = model.TS;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Location != AppConst.StringNull)
                parameters[6].Value = model.Location;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.FansNum != AppConst.IntNull)
                parameters[7].Value = model.FansNum;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.IsVIP != AppConst.IntNull)
                parameters[8].Value = model.IsVIP;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.OpenId1 != AppConst.StringNull)
                parameters[9].Value = model.OpenId1;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.Oauth2Token1 != AppConst.StringNull)
                parameters[10].Value = model.Oauth2Token1;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Expire1 != AppConst.DateTimeNull)
                parameters[11].Value = model.Expire1;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[12].Value = model.CustomerSysNo;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);

            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(QQWeiBoUserMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Apps.dbo.QQWeiBoUser set ");
            strSql.Append("OpenId=@OpenId,");
            strSql.Append("WB_Name=@WB_Name,");
            strSql.Append("WB_Nick=@WB_Nick,");
            strSql.Append("Oauth2Token=@Oauth2Token,");
            strSql.Append("Expire=@Expire,");
            strSql.Append("TS=@TS,");
            strSql.Append("Location=@Location,");
            strSql.Append("FansNum=@FansNum,");
            strSql.Append("IsVIP=@IsVIP,");
            strSql.Append("OpenId1=@OpenId1,");
            strSql.Append("Oauth2Token1=@Oauth2Token1,");
            strSql.Append("Expire1=@Expire1,");
            strSql.Append("CustomerSysNo=@CustomerSysNo");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@OpenId",SqlDbType.VarChar,100),
                 new SqlParameter("@WB_Name",SqlDbType.VarChar,100),
                 new SqlParameter("@WB_Nick",SqlDbType.NVarChar,200),
                 new SqlParameter("@Oauth2Token",SqlDbType.VarChar,100),
                 new SqlParameter("@Expire",SqlDbType.DateTime),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@Location",SqlDbType.NVarChar,200),
                 new SqlParameter("@FansNum",SqlDbType.Int,4),
                 new SqlParameter("@IsVIP",SqlDbType.Int,4),
                 new SqlParameter("@OpenId1",SqlDbType.VarChar,100),
                 new SqlParameter("@Oauth2Token1",SqlDbType.VarChar,100),
                 new SqlParameter("@Expire1",SqlDbType.DateTime),
                 new SqlParameter("@CustomerSysNo",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.OpenId != AppConst.StringNull)
                parameters[1].Value = model.OpenId;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.WB_Name != AppConst.StringNull)
                parameters[2].Value = model.WB_Name;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.WB_Nick != AppConst.StringNull)
                parameters[3].Value = model.WB_Nick;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Oauth2Token != AppConst.StringNull)
                parameters[4].Value = model.Oauth2Token;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Expire != AppConst.DateTimeNull)
                parameters[5].Value = model.Expire;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[6].Value = model.TS;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Location != AppConst.StringNull)
                parameters[7].Value = model.Location;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.FansNum != AppConst.IntNull)
                parameters[8].Value = model.FansNum;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.IsVIP != AppConst.IntNull)
                parameters[9].Value = model.IsVIP;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.OpenId1 != AppConst.StringNull)
                parameters[10].Value = model.OpenId1;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Oauth2Token1 != AppConst.StringNull)
                parameters[11].Value = model.Oauth2Token1;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.Expire1 != AppConst.DateTimeNull)
                parameters[12].Value = model.Expire1;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.CustomerSysNo != AppConst.IntNull)
                parameters[13].Value = model.CustomerSysNo;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            return SqlHelper.ExecuteNonQuery(cmd,parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Apps.dbo.QQWeiBoUser ");
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

        public QQWeiBoUserMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, OpenId, WB_Name, WB_Nick, Oauth2Token, Expire, TS, Location, FansNum, IsVIP, OpenId1, Oauth2Token1, Expire1, CustomerSysNo from  Apps.dbo.QQWeiBoUser");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            QQWeiBoUserMod model = new QQWeiBoUserMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.OpenId = ds.Tables[0].Rows[0]["OpenId"].ToString();
                model.WB_Name = ds.Tables[0].Rows[0]["WB_Name"].ToString();
                model.WB_Nick = ds.Tables[0].Rows[0]["WB_Nick"].ToString();
                model.Oauth2Token = ds.Tables[0].Rows[0]["Oauth2Token"].ToString();
                if (ds.Tables[0].Rows[0]["Expire"].ToString() != "")
                {
                    model.Expire = DateTime.Parse(ds.Tables[0].Rows[0]["Expire"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                model.Location = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["FansNum"].ToString() != "")
                {
                    model.FansNum = int.Parse(ds.Tables[0].Rows[0]["FansNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsVIP"].ToString() != "")
                {
                    model.IsVIP = int.Parse(ds.Tables[0].Rows[0]["IsVIP"].ToString());
                }
                model.OpenId1 = ds.Tables[0].Rows[0]["OpenId1"].ToString();
                model.Oauth2Token1 = ds.Tables[0].Rows[0]["Oauth2Token1"].ToString();
                if (ds.Tables[0].Rows[0]["Expire1"].ToString() != "")
                {
                    model.Expire1 = DateTime.Parse(ds.Tables[0].Rows[0]["Expire1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerSysNo"].ToString() != "")
                {
                    model.CustomerSysNo = int.Parse(ds.Tables[0].Rows[0]["CustomerSysNo"].ToString());
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
