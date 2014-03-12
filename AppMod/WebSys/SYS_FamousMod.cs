using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.WebSys
{
    [DataContract]
    public class SYS_FamousMod : IComparable<SYS_FamousMod>
    {
        public SYS_FamousMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private string _Description;
        private int _BirthYear;
        private DateTime _BirthTime;
        private DateTime _Death;
        private int _CateSysNo;
        private int _Level;
        private int _CustomerSysNo;
        private int _DR;
        private DateTime _TS;
        private string _Source;
        private int _Gender;
        private int _HomeTown;
        private int _Height;
        private string _FullName;
        private int _TimeUnknown;
        private int _IsTop;
        private string _Photo;
        private int _CollectCount;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        public int BirthYear
        {
            set { _BirthYear = value; }
            get { return _BirthYear; }
        }

        public DateTime BirthTime
        {
            set { _BirthTime = value; }
            get { return _BirthTime; }
        }

        public DateTime Death
        {
            set { _Death = value; }
            get { return _Death; }
        }

        public int CateSysNo
        {
            set { _CateSysNo = value; }
            get { return _CateSysNo; }
        }

        public int Level
        {
            set { _Level = value; }
            get { return _Level; }
        }

        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }

        public int DR
        {
            set { _DR = value; }
            get { return _DR; }
        }

        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }

        public string Source
        {
            set { _Source = value; }
            get { return _Source; }
        }

        public int Gender
        {
            set { _Gender = value; }
            get { return _Gender; }
        }

        public int HomeTown
        {
            set { _HomeTown = value; }
            get { return _HomeTown; }
        }

        public int Height
        {
            set { _Height = value; }
            get { return _Height; }
        }

        public string FullName
        {
            set { _FullName = value; }
            get { return _FullName; }
        }

        public int TimeUnknown
        {
            set { _TimeUnknown = value; }
            get { return _TimeUnknown; }
        }

        public int IsTop
        {
            set { _IsTop = value; }
            get { return _IsTop; }
        }

        public string Photo
        {
            set { _Photo = value; }
            get { return _Photo; }
        }

        public int CollectCount
        {
            set { _CollectCount = value; }
            get { return _CollectCount; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Name = AppConst.StringNull;
            Description = AppConst.StringNull;
            BirthYear = AppConst.IntNull;
            BirthTime = AppConst.DateTimeNull;
            Death = AppConst.DateTimeNull;
            CateSysNo = AppConst.IntNull;
            Level = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Source = AppConst.StringNull;
            Gender = AppConst.IntNull;
            HomeTown = AppConst.IntNull;
            Height = AppConst.IntNull;
            FullName = AppConst.StringNull;
            TimeUnknown = AppConst.IntNull;
            IsTop = AppConst.IntNull;
            Photo = AppConst.StringNull;
            CollectCount = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_FamousMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }



}

