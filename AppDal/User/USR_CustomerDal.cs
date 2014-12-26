using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
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
            strSql.Append("Email,Password,GradeSysNo,NickName,Gender,Photo,Credit,Point,Birth,FateType,RegTime,LastLoginTime,Status,IsStar,Signature,Exp,TotalAnswer,TotalQuest,BestAnswer,HomeTown,Intro,Icons,IsShowBirth,TotalReply,HasNewInfo,TotalTalk,TotalTalkReply,Phone,SetOrderCount,BuyOrderCount,SellOrderCount,TotalSellRMB,TotalBuyRMB,TotalBuyPoint)");
            strSql.Append(" values (");
            strSql.Append("@Email,@Password,@GradeSysNo,@NickName,@Gender,@Photo,@Credit,@Point,@Birth,@FateType,@RegTime,@LastLoginTime,@Status,@IsStar,@Signature,@Exp,@TotalAnswer,@TotalQuest,@BestAnswer,@HomeTown,@Intro,@Icons,@IsShowBirth,@TotalReply,@HasNewInfo,@TotalTalk,@TotalTalkReply,@Phone,@SetOrderCount,@BuyOrderCount,@SellOrderCount,@TotalSellRMB,@TotalBuyRMB,@TotalBuyPoint)");
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
                 new SqlParameter("@Birth",SqlDbType.DateTime),
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
                 new SqlParameter("@SetOrderCount",SqlDbType.Int,4),
                 new SqlParameter("@BuyOrderCount",SqlDbType.Int,4),
                 new SqlParameter("@SellOrderCount",SqlDbType.Int,4),
                 new SqlParameter("@TotalSellRMB",SqlDbType.Decimal,20),
                 new SqlParameter("@TotalBuyRMB",SqlDbType.Decimal,20),
                 new SqlParameter("@TotalBuyPoint",SqlDbType.Int,4),
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
            if (model.Birth != AppConst.DateTimeNull)
                parameters[8].Value = model.Birth;
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
            if (model.SetOrderCount != AppConst.IntNull)
                parameters[28].Value = model.SetOrderCount;
            else
                parameters[28].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[28]);
            if (model.BuyOrderCount != AppConst.IntNull)
                parameters[29].Value = model.BuyOrderCount;
            else
                parameters[29].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[29]);
            if (model.SellOrderCount != AppConst.IntNull)
                parameters[30].Value = model.SellOrderCount;
            else
                parameters[30].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[30]);
            if (model.TotalSellRMB != AppConst.DecimalNull)
                parameters[31].Value = model.TotalSellRMB;
            else
                parameters[31].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[31]);
            if (model.TotalBuyRMB != AppConst.DecimalNull)
                parameters[32].Value = model.TotalBuyRMB;
            else
                parameters[32].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[32]);
            if (model.TotalBuyPoint != AppConst.IntNull)
                parameters[33].Value = model.TotalBuyPoint;
            else
                parameters[33].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[33]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(USR_CustomerMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USR_Customer set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Email != AppConst.StringNull)
            {
                strSql.Append("Email=@Email,");
                SqlParameter param = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                param.Value = model.Email;
                cmd.Parameters.Add(param);
            }
            if (model.Password != AppConst.StringNull)
            {
                strSql.Append("Password=@Password,");
                SqlParameter param = new SqlParameter("@Password", SqlDbType.VarChar, 20);
                param.Value = model.Password;
                cmd.Parameters.Add(param);
            }
            if (model.GradeSysNo != AppConst.IntNull)
            {
                strSql.Append("GradeSysNo=@GradeSysNo,");
                SqlParameter param = new SqlParameter("@GradeSysNo", SqlDbType.Int, 4);
                param.Value = model.GradeSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.NickName != AppConst.StringNull)
            {
                strSql.Append("NickName=@NickName,");
                SqlParameter param = new SqlParameter("@NickName", SqlDbType.NVarChar, 40);
                param.Value = model.NickName;
                cmd.Parameters.Add(param);
            }
            if (model.Gender != AppConst.IntNull)
            {
                strSql.Append("Gender=@Gender,");
                SqlParameter param = new SqlParameter("@Gender", SqlDbType.Int, 4);
                param.Value = model.Gender;
                cmd.Parameters.Add(param);
            }
            if (model.Photo != AppConst.StringNull)
            {
                strSql.Append("Photo=@Photo,");
                SqlParameter param = new SqlParameter("@Photo", SqlDbType.VarChar, 500);
                param.Value = model.Photo;
                cmd.Parameters.Add(param);
            }
            if (model.Credit != AppConst.IntNull)
            {
                strSql.Append("Credit=@Credit,");
                SqlParameter param = new SqlParameter("@Credit", SqlDbType.Int, 4);
                param.Value = model.Credit;
                cmd.Parameters.Add(param);
            }
            if (model.Point != AppConst.IntNull)
            {
                strSql.Append("Point=@Point,");
                SqlParameter param = new SqlParameter("@Point", SqlDbType.Int, 4);
                param.Value = model.Point;
                cmd.Parameters.Add(param);
            }
            if (model.Birth != AppConst.DateTimeNull)
            {
                strSql.Append("Birth=@Birth,");
                SqlParameter param = new SqlParameter("@Birth", SqlDbType.DateTime);
                param.Value = model.Birth;
                cmd.Parameters.Add(param);
            }
            if (model.FateType != AppConst.IntNull)
            {
                strSql.Append("FateType=@FateType,");
                SqlParameter param = new SqlParameter("@FateType", SqlDbType.TinyInt, 1);
                param.Value = model.FateType;
                cmd.Parameters.Add(param);
            }
            if (model.RegTime != AppConst.DateTimeNull)
            {
                strSql.Append("RegTime=@RegTime,");
                SqlParameter param = new SqlParameter("@RegTime", SqlDbType.DateTime);
                param.Value = model.RegTime;
                cmd.Parameters.Add(param);
            }
            if (model.LastLoginTime != AppConst.DateTimeNull)
            {
                strSql.Append("LastLoginTime=@LastLoginTime,");
                SqlParameter param = new SqlParameter("@LastLoginTime", SqlDbType.DateTime);
                param.Value = model.LastLoginTime;
                cmd.Parameters.Add(param);
            }
            if (model.Status != AppConst.IntNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.TinyInt, 1);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.IsStar != AppConst.IntNull)
            {
                strSql.Append("IsStar=@IsStar,");
                SqlParameter param = new SqlParameter("@IsStar", SqlDbType.TinyInt, 1);
                param.Value = model.IsStar;
                cmd.Parameters.Add(param);
            }
            if (model.Signature != AppConst.StringNull)
            {
                strSql.Append("Signature=@Signature,");
                SqlParameter param = new SqlParameter("@Signature", SqlDbType.NVarChar, 600);
                param.Value = model.Signature;
                cmd.Parameters.Add(param);
            }
            if (model.Exp != AppConst.IntNull)
            {
                strSql.Append("Exp=@Exp,");
                SqlParameter param = new SqlParameter("@Exp", SqlDbType.Int, 4);
                param.Value = model.Exp;
                cmd.Parameters.Add(param);
            }
            if (model.TotalAnswer != AppConst.IntNull)
            {
                strSql.Append("TotalAnswer=@TotalAnswer,");
                SqlParameter param = new SqlParameter("@TotalAnswer", SqlDbType.Int, 4);
                param.Value = model.TotalAnswer;
                cmd.Parameters.Add(param);
            }
            if (model.TotalQuest != AppConst.IntNull)
            {
                strSql.Append("TotalQuest=@TotalQuest,");
                SqlParameter param = new SqlParameter("@TotalQuest", SqlDbType.Int, 4);
                param.Value = model.TotalQuest;
                cmd.Parameters.Add(param);
            }
            if (model.BestAnswer != AppConst.IntNull)
            {
                strSql.Append("BestAnswer=@BestAnswer,");
                SqlParameter param = new SqlParameter("@BestAnswer", SqlDbType.Int, 4);
                param.Value = model.BestAnswer;
                cmd.Parameters.Add(param);
            }
            if (model.HomeTown != AppConst.IntNull)
            {
                strSql.Append("HomeTown=@HomeTown,");
                SqlParameter param = new SqlParameter("@HomeTown", SqlDbType.Int, 4);
                param.Value = model.HomeTown;
                cmd.Parameters.Add(param);
            }
            if (model.Intro != AppConst.StringNull)
            {
                strSql.Append("Intro=@Intro,");
                SqlParameter param = new SqlParameter("@Intro", SqlDbType.NVarChar, 1000);
                param.Value = model.Intro;
                cmd.Parameters.Add(param);
            }
            if (model.Icons != AppConst.StringNull)
            {
                strSql.Append("Icons=@Icons,");
                SqlParameter param = new SqlParameter("@Icons", SqlDbType.VarChar, 500);
                param.Value = model.Icons;
                cmd.Parameters.Add(param);
            }
            if (model.IsShowBirth != AppConst.IntNull)
            {
                strSql.Append("IsShowBirth=@IsShowBirth,");
                SqlParameter param = new SqlParameter("@IsShowBirth", SqlDbType.TinyInt, 1);
                param.Value = model.IsShowBirth;
                cmd.Parameters.Add(param);
            }
            if (model.TotalReply != AppConst.IntNull)
            {
                strSql.Append("TotalReply=@TotalReply,");
                SqlParameter param = new SqlParameter("@TotalReply", SqlDbType.Int, 4);
                param.Value = model.TotalReply;
                cmd.Parameters.Add(param);
            }
            if (model.HasNewInfo != AppConst.IntNull)
            {
                strSql.Append("HasNewInfo=@HasNewInfo,");
                SqlParameter param = new SqlParameter("@HasNewInfo", SqlDbType.Int, 4);
                param.Value = model.HasNewInfo;
                cmd.Parameters.Add(param);
            }
            if (model.TotalTalk != AppConst.IntNull)
            {
                strSql.Append("TotalTalk=@TotalTalk,");
                SqlParameter param = new SqlParameter("@TotalTalk", SqlDbType.Int, 4);
                param.Value = model.TotalTalk;
                cmd.Parameters.Add(param);
            }
            if (model.TotalTalkReply != AppConst.IntNull)
            {
                strSql.Append("TotalTalkReply=@TotalTalkReply,");
                SqlParameter param = new SqlParameter("@TotalTalkReply", SqlDbType.Int, 4);
                param.Value = model.TotalTalkReply;
                cmd.Parameters.Add(param);
            }
            if (model.Phone != AppConst.StringNull)
            {
                strSql.Append("Phone=@Phone,");
                SqlParameter param = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
                param.Value = model.Phone;
                cmd.Parameters.Add(param);
            }
            if (model.SetOrderCount != AppConst.IntNull)
            {
                strSql.Append("SetOrderCount=@SetOrderCount,");
                SqlParameter param = new SqlParameter("@SetOrderCount", SqlDbType.Int, 4);
                param.Value = model.SetOrderCount;
                cmd.Parameters.Add(param);
            }
            if (model.BuyOrderCount != AppConst.IntNull)
            {
                strSql.Append("BuyOrderCount=@BuyOrderCount,");
                SqlParameter param = new SqlParameter("@BuyOrderCount", SqlDbType.Int, 4);
                param.Value = model.BuyOrderCount;
                cmd.Parameters.Add(param);
            }
            if (model.SellOrderCount != AppConst.IntNull)
            {
                strSql.Append("SellOrderCount=@SellOrderCount,");
                SqlParameter param = new SqlParameter("@SellOrderCount", SqlDbType.Int, 4);
                param.Value = model.SellOrderCount;
                cmd.Parameters.Add(param);
            }
            if (model.TotalSellRMB != AppConst.DecimalNull)
            {
                strSql.Append("TotalSellRMB=@TotalSellRMB,");
                SqlParameter param = new SqlParameter("@TotalSellRMB", SqlDbType.Decimal, 20);
                param.Value = model.TotalSellRMB;
                cmd.Parameters.Add(param);
            }
            if (model.TotalBuyRMB != AppConst.DecimalNull)
            {
                strSql.Append("TotalBuyRMB=@TotalBuyRMB,");
                SqlParameter param = new SqlParameter("@TotalBuyRMB", SqlDbType.Decimal, 20);
                param.Value = model.TotalBuyRMB;
                cmd.Parameters.Add(param);
            }
            if (model.TotalBuyPoint != AppConst.IntNull)
            {
                strSql.Append("TotalBuyPoint=@TotalBuyPoint,");
                SqlParameter param = new SqlParameter("@TotalBuyPoint", SqlDbType.Int, 4);
                param.Value = model.TotalBuyPoint;
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
            strSql.Append("select SysNo, Email, Password, GradeSysNo, NickName, Gender, Photo, Credit, Point, Birth, FateType, RegTime, LastLoginTime, Status, IsStar, Signature, Exp, TotalAnswer, TotalQuest, BestAnswer, HomeTown, Intro, Icons, IsShowBirth, TotalReply, HasNewInfo, TotalTalk, TotalTalkReply, Phone, SetOrderCount, BuyOrderCount, SellOrderCount, TotalSellRMB, TotalBuyRMB, TotalBuyPoint from  dbo.USR_Customer");
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
                if (ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    model.Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
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
                if (ds.Tables[0].Rows[0]["SetOrderCount"].ToString() != "")
                {
                    model.SetOrderCount = int.Parse(ds.Tables[0].Rows[0]["SetOrderCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyOrderCount"].ToString() != "")
                {
                    model.BuyOrderCount = int.Parse(ds.Tables[0].Rows[0]["BuyOrderCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellOrderCount"].ToString() != "")
                {
                    model.SellOrderCount = int.Parse(ds.Tables[0].Rows[0]["SellOrderCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalSellRMB"].ToString() != "")
                {
                    model.TotalSellRMB = decimal.Parse(ds.Tables[0].Rows[0]["TotalSellRMB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalBuyRMB"].ToString() != "")
                {
                    model.TotalBuyRMB = decimal.Parse(ds.Tables[0].Rows[0]["TotalBuyRMB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalBuyPoint"].ToString() != "")
                {
                    model.TotalBuyPoint = int.Parse(ds.Tables[0].Rows[0]["TotalBuyPoint"].ToString());
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
