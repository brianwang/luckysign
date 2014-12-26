using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.Course
{
    [DataContract]
    public class COZ_CourseMod : IComparable<COZ_CourseMod>
    {
        public COZ_CourseMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Title;
        private string _Pic;
        private string _Teacher;
        private int _TeacherSysNo;
        private int _Hour;
        private DateTime _CourseBegin;
        private string _Period;
        private DateTime _Deadline;
        private int _Count;
        private string _StudentDesc;
        private int _ClassType;
        private decimal _Price;
        private string _Description;
        private DateTime _TS;
        private int _DR;
        private int _CateSysNo;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        [DataMember]
        public string Pic
        {
            set { _Pic = value; }
            get { return _Pic; }
        }

        [DataMember]
        public string Teacher
        {
            set { _Teacher = value; }
            get { return _Teacher; }
        }

        [DataMember]
        public int TeacherSysNo
        {
            set { _TeacherSysNo = value; }
            get { return _TeacherSysNo; }
        }

        [DataMember]
        public int Hour
        {
            set { _Hour = value; }
            get { return _Hour; }
        }

        [DataMember]
        public DateTime CourseBegin
        {
            set { _CourseBegin = value; }
            get { return _CourseBegin; }
        }

        [DataMember]
        public string Period
        {
            set { _Period = value; }
            get { return _Period; }
        }

        [DataMember]
        public DateTime Deadline
        {
            set { _Deadline = value; }
            get { return _Deadline; }
        }

        [DataMember]
        public int Count
        {
            set { _Count = value; }
            get { return _Count; }
        }

        [DataMember]
        public string StudentDesc
        {
            set { _StudentDesc = value; }
            get { return _StudentDesc; }
        }

        [DataMember]
        public int ClassType
        {
            set { _ClassType = value; }
            get { return _ClassType; }
        }

        [DataMember]
        public decimal Price
        {
            set { _Price = value; }
            get { return _Price; }
        }

        [DataMember]
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        [DataMember]
        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }

        [DataMember]
        public int DR
        {
            set { _DR = value; }
            get { return _DR; }
        }

        [DataMember]
        public int CateSysNo
        {
            set { _CateSysNo = value; }
            get { return _CateSysNo; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Title = AppConst.StringNull;
            Pic = AppConst.StringNull;
            Teacher = AppConst.StringNull;
            TeacherSysNo = AppConst.IntNull;
            Hour = AppConst.IntNull;
            CourseBegin = AppConst.DateTimeNull;
            Period = AppConst.StringNull;
            Deadline = AppConst.DateTimeNull;
            Count = AppConst.IntNull;
            StudentDesc = AppConst.StringNull;
            ClassType = AppConst.IntNull;
            Price = AppConst.DecimalNull;
            Description = AppConst.StringNull;
            TS = AppConst.DateTimeNull;
            DR = AppConst.IntNull;
            CateSysNo = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(COZ_CourseMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

