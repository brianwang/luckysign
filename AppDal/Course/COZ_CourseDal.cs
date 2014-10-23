using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using AppCmn;
using AppMod.Course;
namespace AppDal.Course
{
    /// <summary>
    /// 数据访问类COZ_Course。
    /// </summary>
    public class COZ_CourseDal
    {
        public COZ_CourseDal() { }
        private static COZ_CourseDal _instance;
        public COZ_CourseDal GetInstance()
        {
            if (_instance == null)
            { _instance = new COZ_CourseDal(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(COZ_CourseMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into COZ_Course(");
            strSql.Append("Title,Pic,Teacher,TeacherSysNo,Hour,CourseBegin,Period,Deadline,Count,StudentDesc,ClassType,Price,Description,TS,DR,CateSysNo)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Pic,@Teacher,@TeacherSysNo,@Hour,@CourseBegin,@Period,@Deadline,@Count,@StudentDesc,@ClassType,@Price,@Description,@TS,@DR,@CateSysNo)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Title",SqlDbType.NVarChar,200),
                 new SqlParameter("@Pic",SqlDbType.VarChar,200),
                 new SqlParameter("@Teacher",SqlDbType.NVarChar,40),
                 new SqlParameter("@TeacherSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Hour",SqlDbType.Int,4),
                 new SqlParameter("@CourseBegin",SqlDbType.DateTime),
                 new SqlParameter("@Period",SqlDbType.NVarChar,100),
                 new SqlParameter("@Deadline",SqlDbType.DateTime),
                 new SqlParameter("@Count",SqlDbType.Int,4),
                 new SqlParameter("@StudentDesc",SqlDbType.NVarChar,200),
                 new SqlParameter("@ClassType",SqlDbType.Int,4),
                 new SqlParameter("@Price",SqlDbType.Decimal,20),
                 new SqlParameter("@Description",SqlDbType.NText,2147483646),
                 new SqlParameter("@TS",SqlDbType.DateTime),
                 new SqlParameter("@DR",SqlDbType.Int,4),
                 new SqlParameter("@CateSysNo",SqlDbType.Int,4),
             };
            if (model.Title != AppConst.StringNull)
                parameters[0].Value = model.Title;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Pic != AppConst.StringNull)
                parameters[1].Value = model.Pic;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Teacher != AppConst.StringNull)
                parameters[2].Value = model.Teacher;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TeacherSysNo != AppConst.IntNull)
                parameters[3].Value = model.TeacherSysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Hour != AppConst.IntNull)
                parameters[4].Value = model.Hour;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.CourseBegin != AppConst.DateTimeNull)
                parameters[5].Value = model.CourseBegin;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Period != AppConst.StringNull)
                parameters[6].Value = model.Period;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Deadline != AppConst.DateTimeNull)
                parameters[7].Value = model.Deadline;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Count != AppConst.IntNull)
                parameters[8].Value = model.Count;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.StudentDesc != AppConst.StringNull)
                parameters[9].Value = model.StudentDesc;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.ClassType != AppConst.IntNull)
                parameters[10].Value = model.ClassType;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Price != AppConst.DecimalNull)
                parameters[11].Value = model.Price;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.Description != AppConst.StringNull)
                parameters[12].Value = model.Description;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.TS != AppConst.DateTimeNull)
                parameters[13].Value = model.TS;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.DR != AppConst.IntNull)
                parameters[14].Value = model.DR;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.CateSysNo != AppConst.IntNull)
                parameters[15].Value = model.CateSysNo;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(cmd, parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(COZ_CourseMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update COZ_Course set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Title != AppConst.StringNull)
            {
                strSql.Append("Title=@Title,");
                SqlParameter param = new SqlParameter("@Title", SqlDbType.NVarChar, 200);
                param.Value = model.Title;
                cmd.Parameters.Add(param);
            }
            if (model.Pic != AppConst.StringNull)
            {
                strSql.Append("Pic=@Pic,");
                SqlParameter param = new SqlParameter("@Pic", SqlDbType.VarChar, 200);
                param.Value = model.Pic;
                cmd.Parameters.Add(param);
            }
            if (model.Teacher != AppConst.StringNull)
            {
                strSql.Append("Teacher=@Teacher,");
                SqlParameter param = new SqlParameter("@Teacher", SqlDbType.NVarChar, 40);
                param.Value = model.Teacher;
                cmd.Parameters.Add(param);
            }
            if (model.TeacherSysNo != AppConst.IntNull)
            {
                strSql.Append("TeacherSysNo=@TeacherSysNo,");
                SqlParameter param = new SqlParameter("@TeacherSysNo", SqlDbType.Int, 4);
                param.Value = model.TeacherSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Hour != AppConst.IntNull)
            {
                strSql.Append("Hour=@Hour,");
                SqlParameter param = new SqlParameter("@Hour", SqlDbType.Int, 4);
                param.Value = model.Hour;
                cmd.Parameters.Add(param);
            }
            if (model.CourseBegin != AppConst.DateTimeNull)
            {
                strSql.Append("CourseBegin=@CourseBegin,");
                SqlParameter param = new SqlParameter("@CourseBegin", SqlDbType.DateTime);
                param.Value = model.CourseBegin;
                cmd.Parameters.Add(param);
            }
            if (model.Period != AppConst.StringNull)
            {
                strSql.Append("Period=@Period,");
                SqlParameter param = new SqlParameter("@Period", SqlDbType.NVarChar, 100);
                param.Value = model.Period;
                cmd.Parameters.Add(param);
            }
            if (model.Deadline != AppConst.DateTimeNull)
            {
                strSql.Append("Deadline=@Deadline,");
                SqlParameter param = new SqlParameter("@Deadline", SqlDbType.DateTime);
                param.Value = model.Deadline;
                cmd.Parameters.Add(param);
            }
            if (model.Count != AppConst.IntNull)
            {
                strSql.Append("Count=@Count,");
                SqlParameter param = new SqlParameter("@Count", SqlDbType.Int, 4);
                param.Value = model.Count;
                cmd.Parameters.Add(param);
            }
            if (model.StudentDesc != AppConst.StringNull)
            {
                strSql.Append("StudentDesc=@StudentDesc,");
                SqlParameter param = new SqlParameter("@StudentDesc", SqlDbType.NVarChar, 200);
                param.Value = model.StudentDesc;
                cmd.Parameters.Add(param);
            }
            if (model.ClassType != AppConst.IntNull)
            {
                strSql.Append("ClassType=@ClassType,");
                SqlParameter param = new SqlParameter("@ClassType", SqlDbType.Int, 4);
                param.Value = model.ClassType;
                cmd.Parameters.Add(param);
            }
            if (model.Price != AppConst.DecimalNull)
            {
                strSql.Append("Price=@Price,");
                SqlParameter param = new SqlParameter("@Price", SqlDbType.Decimal, 20);
                param.Value = model.Price;
                cmd.Parameters.Add(param);
            }
            if (model.Description != AppConst.StringNull)
            {
                strSql.Append("Description=@Description,");
                SqlParameter param = new SqlParameter("@Description", SqlDbType.NText, 2147483646);
                param.Value = model.Description;
                cmd.Parameters.Add(param);
            }
            if (model.TS != AppConst.DateTimeNull)
            {
                strSql.Append("TS=@TS,");
                SqlParameter param = new SqlParameter("@TS", SqlDbType.DateTime);
                param.Value = model.TS;
                cmd.Parameters.Add(param);
            }
            if (model.DR != AppConst.IntNull)
            {
                strSql.Append("DR=@DR,");
                SqlParameter param = new SqlParameter("@DR", SqlDbType.Int, 4);
                param.Value = model.DR;
                cmd.Parameters.Add(param);
            }
            if (model.CateSysNo != AppConst.IntNull)
            {
                strSql.Append("CateSysNo=@CateSysNo,");
                SqlParameter param = new SqlParameter("@CateSysNo", SqlDbType.Int, 4);
                param.Value = model.CateSysNo;
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
            strSql.Append("delete COZ_Course ");
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
        public COZ_CourseMod GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysNo, Title, Pic, Teacher, TeacherSysNo, Hour, CourseBegin, Period, Deadline, Count, StudentDesc, ClassType, Price, Description, TS, DR, CateSysNo from  dbo.COZ_Course");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            COZ_CourseMod model = new COZ_CourseMod();
            DataSet ds = SqlHelper.ExecuteDataSet(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Pic = ds.Tables[0].Rows[0]["Pic"].ToString();
                model.Teacher = ds.Tables[0].Rows[0]["Teacher"].ToString();
                if (ds.Tables[0].Rows[0]["TeacherSysNo"].ToString() != "")
                {
                    model.TeacherSysNo = int.Parse(ds.Tables[0].Rows[0]["TeacherSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Hour"].ToString() != "")
                {
                    model.Hour = int.Parse(ds.Tables[0].Rows[0]["Hour"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CourseBegin"].ToString() != "")
                {
                    model.CourseBegin = DateTime.Parse(ds.Tables[0].Rows[0]["CourseBegin"].ToString());
                }
                model.Period = ds.Tables[0].Rows[0]["Period"].ToString();
                if (ds.Tables[0].Rows[0]["Deadline"].ToString() != "")
                {
                    model.Deadline = DateTime.Parse(ds.Tables[0].Rows[0]["Deadline"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }
                model.StudentDesc = ds.Tables[0].Rows[0]["StudentDesc"].ToString();
                if (ds.Tables[0].Rows[0]["ClassType"].ToString() != "")
                {
                    model.ClassType = int.Parse(ds.Tables[0].Rows[0]["ClassType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["TS"].ToString() != "")
                {
                    model.TS = DateTime.Parse(ds.Tables[0].Rows[0]["TS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DR"].ToString() != "")
                {
                    model.DR = int.Parse(ds.Tables[0].Rows[0]["DR"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CateSysNo"].ToString() != "")
                {
                    model.CateSysNo = int.Parse(ds.Tables[0].Rows[0]["CateSysNo"].ToString());
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
