using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Fate;

namespace AppDal.Fate
{
    /// <summary>
    /// 数据访问类FATE_Chart。
    /// </summary>
    public class FATE_ChartDal
    {
        public FATE_ChartDal() { }
        private static FATE_ChartDal _instance;
        public FATE_ChartDal GetInstance()
        {
            if (_instance == null)
            { _instance = new FATE_ChartDal(); }
            return _instance;
        }
        #region  成员方法

         /// <summary>
         /// 增加一条数据
         /// </summary>

         public int Add(FATE_ChartMod model)
         {
             StringBuilder strSql=new StringBuilder();
             strSql.Append("insert into FATE_Chart(");
             strSql.Append("FirstBirth,FirstPoi,Transit,TransitPoi,SecondBirth,SecondPoi,CharType,TheoryType,Bitvalue,DR,TS,FirstDayLight,SecondDayLight,FirstPoiName,SecondPoiName,FirstTimeZone,SecondTimeZone,FirstGender,SecondGender)");
             strSql.Append(" values (");
             strSql.Append("@FirstBirth,@FirstPoi,@Transit,@TransitPoi,@SecondBirth,@SecondPoi,@CharType,@TheoryType,@Bitvalue,@DR,@TS,@FirstDayLight,@SecondDayLight,@FirstPoiName,@SecondPoiName,@FirstTimeZone,@SecondTimeZone,@FirstGender,@SecondGender)");
             strSql.Append(";select @@IDENTITY");
             SqlCommand cmd = new SqlCommand(strSql.ToString());
             SqlParameter[] parameters = {
                 new SqlParameter("@FirstBirth",SqlDbType.DateTime),
                 new SqlParameter("@FirstPoi",SqlDbType.VarChar,100),
                 new SqlParameter("@Transit",SqlDbType.DateTime),
                 new SqlParameter("@TransitPoi",SqlDbType.VarChar,100),
                 new SqlParameter("@SecondBirth",SqlDbType.DateTime),
                 new SqlParameter("@SecondPoi",SqlDbType.VarChar,100),
                 new SqlParameter("@CharType",SqlDbType.Int,4),
                 new SqlParameter("@TheoryType",SqlDbType.TinyInt,1),
                 new SqlParameter("@Bitvalue",SqlDbType.VarChar,100),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@FirstDayLight",SqlDbType.Int,4),
                 new SqlParameter("@SecondDayLight",SqlDbType.Int,4),
                 new SqlParameter("@FirstPoiName",SqlDbType.VarChar,100),
                 new SqlParameter("@SecondPoiName",SqlDbType.VarChar,100),
                 new SqlParameter("@FirstTimeZone",SqlDbType.Int,4),
                 new SqlParameter("@SecondTimeZone",SqlDbType.Int,4),
                 new SqlParameter("@FirstGender",SqlDbType.Int,4),
                 new SqlParameter("@SecondGender",SqlDbType.Int,4),
             };
            if (model.FirstBirth != AppConst.DateTimeNull) 
               parameters[0].Value = model.FirstBirth;
            else 
               parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.FirstPoi != AppConst.StringNull) 
               parameters[1].Value = model.FirstPoi;
            else 
               parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Transit != AppConst.DateTimeNull) 
               parameters[2].Value = model.Transit;
            else 
               parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TransitPoi != AppConst.StringNull) 
               parameters[3].Value = model.TransitPoi;
            else 
               parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.SecondBirth != AppConst.DateTimeNull) 
               parameters[4].Value = model.SecondBirth;
            else 
               parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.SecondPoi != AppConst.StringNull) 
               parameters[5].Value = model.SecondPoi;
            else 
               parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.CharType != AppConst.IntNull) 
               parameters[6].Value = model.CharType;
            else 
               parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.TheoryType != AppConst.IntNull) 
               parameters[7].Value = model.TheoryType;
            else 
               parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Bitvalue != AppConst.StringNull) 
               parameters[8].Value = model.Bitvalue;
            else 
               parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.DR != AppConst.IntNull) 
               parameters[9].Value = model.DR;
            else 
               parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.TS != AppConst.DateTimeNull) 
               parameters[10].Value = model.TS;
            else 
               parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.FirstDayLight != AppConst.IntNull) 
               parameters[11].Value = model.FirstDayLight;
            else 
               parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.SecondDayLight != AppConst.IntNull) 
               parameters[12].Value = model.SecondDayLight;
            else 
               parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.FirstPoiName != AppConst.StringNull) 
               parameters[13].Value = model.FirstPoiName;
            else 
               parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.SecondPoiName != AppConst.StringNull) 
               parameters[14].Value = model.SecondPoiName;
            else 
               parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.FirstTimeZone != AppConst.IntNull) 
               parameters[15].Value = model.FirstTimeZone;
            else 
               parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.SecondTimeZone != AppConst.IntNull) 
               parameters[16].Value = model.SecondTimeZone;
            else 
               parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.FirstGender != AppConst.IntNull) 
               parameters[17].Value = model.FirstGender;
            else 
               parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.SecondGender != AppConst.IntNull) 
               parameters[18].Value = model.SecondGender;
            else 
               parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
         }
         /// <summary>
         /// 更新一条数据
         /// </summary>

         public int UpDate(FATE_ChartMod model)
         {
             StringBuilder strSql=new StringBuilder();
             strSql.Append("update FATE_Chart set ");
             strSql.Append("FirstBirth=@FirstBirth,");
             strSql.Append("FirstPoi=@FirstPoi,");
             strSql.Append("Transit=@Transit,");
             strSql.Append("TransitPoi=@TransitPoi,");
             strSql.Append("SecondBirth=@SecondBirth,");
             strSql.Append("SecondPoi=@SecondPoi,");
             strSql.Append("CharType=@CharType,");
             strSql.Append("TheoryType=@TheoryType,");
             strSql.Append("Bitvalue=@Bitvalue,");
             strSql.Append("DR=@DR,");
             strSql.Append("TS=@TS,");
             strSql.Append("FirstDayLight=@FirstDayLight,");
             strSql.Append("SecondDayLight=@SecondDayLight,");
             strSql.Append("FirstPoiName=@FirstPoiName,");
             strSql.Append("SecondPoiName=@SecondPoiName,");
             strSql.Append("FirstTimeZone=@FirstTimeZone,");
             strSql.Append("SecondTimeZone=@SecondTimeZone,");
             strSql.Append("FirstGender=@FirstGender,");
             strSql.Append("SecondGender=@SecondGender");
             strSql.Append(" where SysNo=@SysNo ");
             SqlCommand cmd = new SqlCommand(strSql.ToString());
             SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@FirstBirth",SqlDbType.DateTime),
                 new SqlParameter("@FirstPoi",SqlDbType.VarChar,100),
                 new SqlParameter("@Transit",SqlDbType.DateTime),
                 new SqlParameter("@TransitPoi",SqlDbType.VarChar,100),
                 new SqlParameter("@SecondBirth",SqlDbType.DateTime),
                 new SqlParameter("@SecondPoi",SqlDbType.VarChar,100),
                 new SqlParameter("@CharType",SqlDbType.Int,4),
                 new SqlParameter("@TheoryType",SqlDbType.TinyInt,1),
                 new SqlParameter("@Bitvalue",SqlDbType.VarChar,100),
                 new SqlParameter("@DR",SqlDbType.TinyInt,1),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@FirstDayLight",SqlDbType.Int,4),
                 new SqlParameter("@SecondDayLight",SqlDbType.Int,4),
                 new SqlParameter("@FirstPoiName",SqlDbType.VarChar,100),
                 new SqlParameter("@SecondPoiName",SqlDbType.VarChar,100),
                 new SqlParameter("@FirstTimeZone",SqlDbType.Int,4),
                 new SqlParameter("@SecondTimeZone",SqlDbType.Int,4),
                 new SqlParameter("@FirstGender",SqlDbType.Int,4),
                 new SqlParameter("@SecondGender",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull) 
               parameters[0].Value = model.SysNo;
            else 
               parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.FirstBirth != AppConst.DateTimeNull) 
               parameters[1].Value = model.FirstBirth;
            else 
               parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.FirstPoi != AppConst.StringNull) 
               parameters[2].Value = model.FirstPoi;
            else 
               parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Transit != AppConst.DateTimeNull) 
               parameters[3].Value = model.Transit;
            else 
               parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.TransitPoi != AppConst.StringNull) 
               parameters[4].Value = model.TransitPoi;
            else 
               parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.SecondBirth != AppConst.DateTimeNull) 
               parameters[5].Value = model.SecondBirth;
            else 
               parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.SecondPoi != AppConst.StringNull) 
               parameters[6].Value = model.SecondPoi;
            else 
               parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.CharType != AppConst.IntNull) 
               parameters[7].Value = model.CharType;
            else 
               parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.TheoryType != AppConst.IntNull) 
               parameters[8].Value = model.TheoryType;
            else 
               parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.Bitvalue != AppConst.StringNull) 
               parameters[9].Value = model.Bitvalue;
            else 
               parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.DR != AppConst.IntNull) 
               parameters[10].Value = model.DR;
            else 
               parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.TS != AppConst.DateTimeNull) 
               parameters[11].Value = model.TS;
            else 
               parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.FirstDayLight != AppConst.IntNull) 
               parameters[12].Value = model.FirstDayLight;
            else 
               parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.SecondDayLight != AppConst.IntNull) 
               parameters[13].Value = model.SecondDayLight;
            else 
               parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.FirstPoiName != AppConst.StringNull) 
               parameters[14].Value = model.FirstPoiName;
            else 
               parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.SecondPoiName != AppConst.StringNull) 
               parameters[15].Value = model.SecondPoiName;
            else 
               parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.FirstTimeZone != AppConst.IntNull) 
               parameters[16].Value = model.FirstTimeZone;
            else 
               parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.SecondTimeZone != AppConst.IntNull) 
               parameters[17].Value = model.SecondTimeZone;
            else 
               parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.FirstGender != AppConst.IntNull) 
               parameters[18].Value = model.FirstGender;
            else 
               parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);
            if (model.SecondGender != AppConst.IntNull) 
               parameters[19].Value = model.SecondGender;
            else 
               parameters[19].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[19]);
            return SqlHelper.ExecuteNonQuery(cmd, parameters);
         }
	/// <summary>
	/// 删除一条数据
	/// </summary>

	public int Delete(int SysNo)
	 {
		StringBuilder strSql=new StringBuilder();
		strSql.Append("delete FATE_Chart ");
		strSql.Append(" where SysNo=@SysNo");
		SqlCommand cmd = new SqlCommand(strSql.ToString());
		SqlParameter[] parameters = {new SqlParameter("@SysNo", SqlDbType.Int,4)};
		parameters[0].Value = SysNo;
		cmd.Parameters.Add(parameters[0]);
        return SqlHelper.ExecuteNonQuery(cmd, parameters);
	 }
	/// <summary>
	/// 得到一个对象实体
	/// </summary>

   public FATE_ChartMod GetModel(int SysNo)
	{
		StringBuilder strSql=new StringBuilder();
		strSql.Append("select SysNo, FirstBirth, FirstPoi, Transit, TransitPoi, SecondBirth, SecondPoi, CharType, TheoryType, Bitvalue, DR, TS, FirstDayLight, SecondDayLight, FirstPoiName, SecondPoiName, FirstTimeZone, SecondTimeZone, FirstGender, SecondGender from  FATE_Chart");
		strSql.Append(" where SysNo=@SysNo ");
		SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
		parameters[0].Value = SysNo;
		FATE_ChartMod model = new FATE_ChartMod();
		DataSet ds=SqlHelper.ExecuteDataSet(strSql.ToString(),parameters);
		if(ds.Tables[0].Rows.Count>0)
		{
			if(ds.Tables[0].Rows[0]["SysNo"].ToString()!="")
			{
				model.SysNo=int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
			}
			if(ds.Tables[0].Rows[0]["FirstBirth"].ToString()!="")
			{
				model.FirstBirth=DateTime.Parse(ds.Tables[0].Rows[0]["FirstBirth"].ToString());
			}
			model.FirstPoi=ds.Tables[0].Rows[0]["FirstPoi"].ToString();
			if(ds.Tables[0].Rows[0]["Transit"].ToString()!="")
			{
				model.Transit=DateTime.Parse(ds.Tables[0].Rows[0]["Transit"].ToString());
			}
			model.TransitPoi=ds.Tables[0].Rows[0]["TransitPoi"].ToString();
			if(ds.Tables[0].Rows[0]["SecondBirth"].ToString()!="")
			{
				model.SecondBirth=DateTime.Parse(ds.Tables[0].Rows[0]["SecondBirth"].ToString());
			}
			model.SecondPoi=ds.Tables[0].Rows[0]["SecondPoi"].ToString();
			if(ds.Tables[0].Rows[0]["CharType"].ToString()!="")
			{
				model.CharType=int.Parse(ds.Tables[0].Rows[0]["CharType"].ToString());
			}
			if(ds.Tables[0].Rows[0]["TheoryType"].ToString()!="")
			{
				model.TheoryType=int.Parse(ds.Tables[0].Rows[0]["TheoryType"].ToString());
			}
			model.Bitvalue=ds.Tables[0].Rows[0]["Bitvalue"].ToString();
			if(ds.Tables[0].Rows[0]["DR"].ToString()!="")
			{
				model.DR=int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
			}
			if(ds.Tables[0].Rows[0]["TS"].ToString()!="")
			{
				model.TS=DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
			}
			if(ds.Tables[0].Rows[0]["FirstDayLight"].ToString()!="")
			{
				model.FirstDayLight=int.Parse(ds.Tables[0].Rows[0]["FirstDayLight"].ToString());
			}
			if(ds.Tables[0].Rows[0]["SecondDayLight"].ToString()!="")
			{
				model.SecondDayLight=int.Parse(ds.Tables[0].Rows[0]["SecondDayLight"].ToString());
			}
			model.FirstPoiName=ds.Tables[0].Rows[0]["FirstPoiName"].ToString();
			model.SecondPoiName=ds.Tables[0].Rows[0]["SecondPoiName"].ToString();
			if(ds.Tables[0].Rows[0]["FirstTimeZone"].ToString()!="")
			{
				model.FirstTimeZone=int.Parse(ds.Tables[0].Rows[0]["FirstTimeZone"].ToString());
			}
			if(ds.Tables[0].Rows[0]["SecondTimeZone"].ToString()!="")
			{
				model.SecondTimeZone=int.Parse(ds.Tables[0].Rows[0]["SecondTimeZone"].ToString());
			}
			if(ds.Tables[0].Rows[0]["FirstGender"].ToString()!="")
			{
				model.FirstGender=int.Parse(ds.Tables[0].Rows[0]["FirstGender"].ToString());
			}
			if(ds.Tables[0].Rows[0]["SecondGender"].ToString()!="")
			{
				model.SecondGender=int.Parse(ds.Tables[0].Rows[0]["SecondGender"].ToString());
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
