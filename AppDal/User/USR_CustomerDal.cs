using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AppCmn;
using AppMod.User;
namespace AppDal.User
{
    /// <summary>
    /// 数据访问类USR_Customer。
    /// </summary>
    public class USR_CustomerDal
    {
        public USR_CustomerDal() { }
        private static USR_CustomerDal _instance;
        public USR_CustomerDal GetInstance()
        {
            if (_instance == null)
            { _instance = new USR_CustomerDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_CustomerMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USR_Customer(");
            strSql.Append("Email,Password,GradeSysNo,NickName,Gender,Photo,Credit,Point,birth,FateType,RegTime,LastLoginTime,Status,IsStar,Signature,Exp,TotalAnswer,TotalQuest,BestAnswer,HomeTown,Intro,Icons,IsShowBirth,TotalReply,HasNewInfo,TotalTalk,TotalTalkReply,Phone)");
            strSql.Append(" values (");
            strSql.Append("@Email,@Password,@GradeSysNo,@NickName,@Gender,@Photo,@Credit,@Point,@birth,@FateType,@RegTime,@LastLoginTime,@Status,@IsStar,@Signature,@Exp,@TotalAnswer,@TotalQuest,@BestAnswer,@HomeTown,@Intro,@Icons,@IsShowBirth,@TotalReply,@HasNewInfo,@TotalTalk,@TotalTalkReply,@Phone)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Email",SqlDbType.VarChar,100),
                 new SqlParameter("@Password",SqlDbType.VarChar,20),
                 new SqlParameter("@GradeSysNo",SqlDbType.Int,4),
                 new SqlParameter("@NickName",SqlDbType.NVarChar,40),
                 new SqlParameter("@Gender",SqlDbType.Int,4),
                 new SqlParameter("@Photo",SqlDbType.VarChar,500),
                 new SqlParameter("@Credit",SqlDbType.Int,4),
                 new SqlParameter("@Point",SqlDbType.Int,4),
                 new SqlParameter("@birth",SqlDbType.DateTime),
                 new SqlParameter("@FateType",SqlDbType.TinyInt,1),
                 new SqlParameter("@RegTime",SqlDbType.DateTime),
                 new SqlParameter("@LastLoginTime",SqlDbType.DateTime),
                 new SqlParameter("@Status",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsStar",SqlDbType.TinyInt,1),
                 new SqlParameter("@Signature",SqlDbType.NVarChar,600),
                 new SqlParameter("@Exp",SqlDbType.Int,4),
                 new SqlParameter("@TotalAnswer",SqlDbType.Int,4),
                 new SqlParameter("@TotalQuest",SqlDbType.Int,4),
                 new SqlParameter("@BestAnswer",SqlDbType.Int,4),
                 new SqlParameter("@HomeTown",SqlDbType.Int,4),
                 new SqlParameter("@Intro",SqlDbType.NVarChar,1000),
                 new SqlParameter("@Icons",SqlDbType.VarChar,500),
                 new SqlParameter("@IsShowBirth",SqlDbType.TinyInt,1),
                 new SqlParameter("@TotalReply",SqlDbType.Int,4),
                 new SqlParameter("@HasNewInfo",SqlDbType.Int,4),
                 new SqlParameter("@TotalTalk",SqlDbType.Int,4),
                 new SqlParameter("@TotalTalkReply",SqlDbType.Int,4),
                 new SqlParameter("@Phone",SqlDbType.VarChar,50),
             };
            if (model.Email != AppConst.StringNull)
                parameters[0].Value = model.Email;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Password != AppConst.StringNull)
                parameters[1].Value = model.Password;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.GradeSysNo != AppConst.IntNull)
                parameters[2].Value = model.GradeSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.NickName != AppConst.StringNull)
                parameters[3].Value = model.NickName;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Gender != AppConst.IntNull)
                parameters[4].Value = model.Gender;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Photo != AppConst.StringNull)
                parameters[5].Value = model.Photo;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Credit != AppConst.IntNull)
                parameters[6].Value = model.Credit;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Point != AppConst.IntNull)
                parameters[7].Value = model.Point;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.birth != AppConst.DateTimeNull)
                parameters[8].Value = model.birth;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.FateType != AppConst.IntNull)
                parameters[9].Value = model.FateType;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.RegTime != AppConst.DateTimeNull)
                parameters[10].Value = model.RegTime;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.LastLoginTime != AppConst.DateTimeNull)
                parameters[11].Value = model.LastLoginTime;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.Status != AppConst.IntNull)
                parameters[12].Value = model.Status;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.IsStar != AppConst.IntNull)
                parameters[13].Value = model.IsStar;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.Signature != AppConst.StringNull)
                parameters[14].Value = model.Signature;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.Exp != AppConst.IntNull)
                parameters[15].Value = model.Exp;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.TotalAnswer != AppConst.IntNull)
                parameters[16].Value = model.TotalAnswer;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.TotalQuest != AppConst.IntNull)
                parameters[17].Value = model.TotalQuest;
            else
                parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.BestAnswer != AppConst.IntNull)
                parameters[18].Value = model.BestAnswer;
            else
                parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);
            if (model.HomeTown != AppConst.IntNull)
                parameters[19].Value = model.HomeTown;
            else
                parameters[19].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[19]);
            if (model.Intro != AppConst.StringNull)
                parameters[20].Value = model.Intro;
            else
                parameters[20].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[20]);
            if (model.Icons != AppConst.StringNull)
                parameters[21].Value = model.Icons;
            else
                parameters[21].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[21]);
            if (model.IsShowBirth != AppConst.IntNull)
                parameters[22].Value = model.IsShowBirth;
            else
                parameters[22].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[22]);
            if (model.TotalReply != AppConst.IntNull)
                parameters[23].Value = model.TotalReply;
            else
                parameters[23].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[23]);
            if (model.HasNewInfo != AppConst.IntNull)
                parameters[24].Value = model.HasNewInfo;
            else
                parameters[24].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[24]);
            if (model.TotalTalk != AppConst.IntNull)
                parameters[25].Value = model.TotalTalk;
            else
                parameters[25].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[25]);
            if (model.TotalTalkReply != AppConst.IntNull)
                parameters[26].Value = model.TotalTalkReply;
            else
                parameters[26].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[26]);
            if (model.Phone != AppConst.StringNull)
                parameters[27].Value = model.Phone;
            else
                parameters[27].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[27]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public int Update(USR_CustomerMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_Customer set ");
            strSql.Append("Email=@Email,");
            strSql.Append("Password=@Password,");
            strSql.Append("GradeSysNo=@GradeSysNo,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("Credit=@Credit,");
            strSql.Append("Point=@Point,");
            strSql.Append("birth=@birth,");
            strSql.Append("FateType=@FateType,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("Status=@Status,");
            strSql.Append("IsStar=@IsStar,");
            strSql.Append("Signature=@Signature,");
            strSql.Append("Exp=@Exp,");
            strSql.Append("TotalAnswer=@TotalAnswer,");
            strSql.Append("TotalQuest=@TotalQuest,");
            strSql.Append("BestAnswer=@BestAnswer,");
            strSql.Append("HomeTown=@HomeTown,");
            strSql.Append("Intro=@Intro,");
            strSql.Append("Icons=@Icons,");
            strSql.Append("IsShowBirth=@IsShowBirth,");
            strSql.Append("TotalReply=@TotalReply,");
            strSql.Append("HasNewInfo=@HasNewInfo,");
            strSql.Append("TotalTalk=@TotalTalk,");
            strSql.Append("TotalTalkReply=@TotalTalkReply,");
            strSql.Append("Phone=@Phone");
            strSql.Append(" where SysNo=@SysNo ");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Email",SqlDbType.VarChar,100),
                 new SqlParameter("@Password",SqlDbType.VarChar,20),
                 new SqlParameter("@GradeSysNo",SqlDbType.Int,4),
                 new SqlParameter("@NickName",SqlDbType.NVarChar,40),
                 new SqlParameter("@Gender",SqlDbType.Int,4),
                 new SqlParameter("@Photo",SqlDbType.VarChar,500),
                 new SqlParameter("@Credit",SqlDbType.Int,4),
                 new SqlParameter("@Point",SqlDbType.Int,4),
                 new SqlParameter("@birth",SqlDbType.DateTime),
                 new SqlParameter("@FateType",SqlDbType.TinyInt,1),
                 new SqlParameter("@RegTime",SqlDbType.DateTime),
                 new SqlParameter("@LastLoginTime",SqlDbType.DateTime),
                 new SqlParameter("@Status",SqlDbType.TinyInt,1),
                 new SqlParameter("@IsStar",SqlDbType.TinyInt,1),
                 new SqlParameter("@Signature",SqlDbType.NVarChar,600),
                 new SqlParameter("@Exp",SqlDbType.Int,4),
                 new SqlParameter("@TotalAnswer",SqlDbType.Int,4),
                 new SqlParameter("@TotalQuest",SqlDbType.Int,4),
                 new SqlParameter("@BestAnswer",SqlDbType.Int,4),
                 new SqlParameter("@HomeTown",SqlDbType.Int,4),
                 new SqlParameter("@Intro",SqlDbType.NVarChar,1000),
                 new SqlParameter("@Icons",SqlDbType.VarChar,500),
                 new SqlParameter("@IsShowBirth",SqlDbType.TinyInt,1),
                 new SqlParameter("@TotalReply",SqlDbType.Int,4),
                 new SqlParameter("@HasNewInfo",SqlDbType.Int,4),
                 new SqlParameter("@TotalTalk",SqlDbType.Int,4),
                 new SqlParameter("@TotalTalkReply",SqlDbType.Int,4),
                 new SqlParameter("@Phone",SqlDbType.VarChar,50)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Email != AppConst.StringNull)
                parameters[1].Value = model.Email;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Password != AppConst.StringNull)
                parameters[2].Value = model.Password;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.GradeSysNo != AppConst.IntNull)
                parameters[3].Value = model.GradeSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.NickName != AppConst.StringNull)
                parameters[4].Value = model.NickName;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.Gender != AppConst.IntNull)
                parameters[5].Value = model.Gender;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Photo != AppConst.StringNull)
                parameters[6].Value = model.Photo;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Credit != AppConst.IntNull)
                parameters[7].Value = model.Credit;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Point != AppConst.IntNull)
                parameters[8].Value = model.Point;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.birth != AppConst.DateTimeNull)
                parameters[9].Value = model.birth;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.FateType != AppConst.IntNull)
                parameters[10].Value = model.FateType;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.RegTime != AppConst.DateTimeNull)
                parameters[11].Value = model.RegTime;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.LastLoginTime != AppConst.DateTimeNull)
                parameters[12].Value = model.LastLoginTime;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.Status != AppConst.IntNull)
                parameters[13].Value = model.Status;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.IsStar != AppConst.IntNull)
                parameters[14].Value = model.IsStar;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.Signature != AppConst.StringNull)
                parameters[15].Value = model.Signature;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.Exp != AppConst.IntNull)
                parameters[16].Value = model.Exp;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.TotalAnswer != AppConst.IntNull)
                parameters[17].Value = model.TotalAnswer;
            else
                parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.TotalQuest != AppConst.IntNull)
                parameters[18].Value = model.TotalQuest;
            else
                parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);
            if (model.BestAnswer != AppConst.IntNull)
                parameters[19].Value = model.BestAnswer;
            else
                parameters[19].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[19]);
            if (model.HomeTown != AppConst.IntNull)
                parameters[20].Value = model.HomeTown;
            else
                parameters[20].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[20]);
            if (model.Intro != AppConst.StringNull)
                parameters[21].Value = model.Intro;
            else
                parameters[21].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[21]);
            if (model.Icons != AppConst.StringNull)
                parameters[22].Value = model.Icons;
            else
                parameters[22].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[22]);
            if (model.IsShowBirth != AppConst.IntNull)
                parameters[23].Value = model.IsShowBirth;
            else
                parameters[23].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[23]);
            if (model.TotalReply != AppConst.IntNull)
                parameters[24].Value = model.TotalReply;
            else
                parameters[24].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[24]);
            if (model.HasNewInfo != AppConst.IntNull)
                parameters[25].Value = model.HasNewInfo;
            else
                parameters[25].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[25]);
            if (model.TotalTalk != AppConst.IntNull)
                parameters[26].Value = model.TotalTalk;
            else
                parameters[26].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[26]);
            if (model.TotalTalkReply != AppConst.IntNull)
                parameters[27].Value = model.TotalTalkReply;
            else
                parameters[27].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[27]);
            if (model.Phone != AppConst.StringNull)
                parameters[28].Value = model.Phone;
            else
                parameters[28].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[28]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public int Delete(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete USR_Customer ");
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

        public USR_CustomerMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Email, Password, GradeSysNo, NickName, Gender, Photo, Credit, Point, birth, FateType, RegTime, LastLoginTime, Status, IsStar, Signature, Exp, TotalAnswer, TotalQuest, BestAnswer, HomeTown, Intro, Icons, IsShowBirth, TotalReply, HasNewInfo, TotalTalk, TotalTalkReply, Phone from  USR_Customer");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            USR_CustomerMod model = new USR_CustomerMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                if (ds.Tables[0].Rows[0]["GradeSysNo"].ToString() != "")
                {
                    model.GradeSysNo = int.Parse(ds.Tables[0].Rows[0]["GradeSysNo"].ToString());
                }
                model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                model.Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                if (ds.Tables[0].Rows[0]["Credit"].ToString() != "")
                {
                    model.Credit = int.Parse(ds.Tables[0].Rows[0]["Credit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Point"].ToString() != "")
                {
                    model.Point = int.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
                }
                if (ds.Tables[0].Rows[0]["birth"].ToString() != "")
                {
                    model.birth = DateTime.Parse(ds.Tables[0].Rows[0]["birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FateType"].ToString() != "")
                {
                    model.FateType = int.Parse(ds.Tables[0].Rows[0]["FateType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsStar"].ToString() != "")
                {
                    model.IsStar = int.Parse(ds.Tables[0].Rows[0]["IsStar"].ToString());
                }
                model.Signature = ds.Tables[0].Rows[0]["Signature"].ToString();
                if (ds.Tables[0].Rows[0]["Exp"].ToString() != "")
                {
                    model.Exp = int.Parse(ds.Tables[0].Rows[0]["Exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalAnswer"].ToString() != "")
                {
                    model.TotalAnswer = int.Parse(ds.Tables[0].Rows[0]["TotalAnswer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalQuest"].ToString() != "")
                {
                    model.TotalQuest = int.Parse(ds.Tables[0].Rows[0]["TotalQuest"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BestAnswer"].ToString() != "")
                {
                    model.BestAnswer = int.Parse(ds.Tables[0].Rows[0]["BestAnswer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HomeTown"].ToString() != "")
                {
                    model.HomeTown = int.Parse(ds.Tables[0].Rows[0]["HomeTown"].ToString());
                }
                model.Intro = ds.Tables[0].Rows[0]["Intro"].ToString();
                model.Icons = ds.Tables[0].Rows[0]["Icons"].ToString();
                if (ds.Tables[0].Rows[0]["IsShowBirth"].ToString() != "")
                {
                    model.IsShowBirth = int.Parse(ds.Tables[0].Rows[0]["IsShowBirth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalReply"].ToString() != "")
                {
                    model.TotalReply = int.Parse(ds.Tables[0].Rows[0]["TotalReply"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HasNewInfo"].ToString() != "")
                {
                    model.HasNewInfo = int.Parse(ds.Tables[0].Rows[0]["HasNewInfo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalTalk"].ToString() != "")
                {
                    model.TotalTalk = int.Parse(ds.Tables[0].Rows[0]["TotalTalk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalTalkReply"].ToString() != "")
                {
                    model.TotalTalkReply = int.Parse(ds.Tables[0].Rows[0]["TotalTalkReply"].ToString());
                }
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
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
