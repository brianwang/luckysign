using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.Spider
{
    [Serializable]
    public class SPD_FamousMod : IComparable<SPD_FamousMod>
    {
        public SPD_FamousMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _FamousName;
        private string _Biography;
        private DateTime _Birth;
        private DateTime _Death;
        private string _Scource;
        private int _FamousSysNo;
        private string _ChartASC;
        private string _Country;
        private string _HomeTown;
        private int _IsUnknow;
        private string _Height;
        private int _DR;
        private DateTime _TS;
        private string _AstroThemeID;
        private string _BirthTmp;
        private int _Gender;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string FamousName
        {
            set { _FamousName = value; }
            get { return _FamousName; }
        }

        public string Biography
        {
            set { _Biography = value; }
            get { return _Biography; }
        }

        public DateTime Birth
        {
            set { _Birth = value; }
            get { return _Birth; }
        }

        public DateTime Death
        {
            set { _Death = value; }
            get { return _Death; }
        }

        public string Scource
        {
            set { _Scource = value; }
            get { return _Scource; }
        }

        public int FamousSysNo
        {
            set { _FamousSysNo = value; }
            get { return _FamousSysNo; }
        }

        public string ChartASC
        {
            set { _ChartASC = value; }
            get { return _ChartASC; }
        }

        public string Country
        {
            set { _Country = value; }
            get { return _Country; }
        }

        public string HomeTown
        {
            set { _HomeTown = value; }
            get { return _HomeTown; }
        }

        public int IsUnknow
        {
            set { _IsUnknow = value; }
            get { return _IsUnknow; }
        }

        public string Height
        {
            set { _Height = value; }
            get { return _Height; }
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

        public string AstroThemeID
        {
            set { _AstroThemeID = value; }
            get { return _AstroThemeID; }
        }

        public string BirthTmp
        {
            set { _BirthTmp = value; }
            get { return _BirthTmp; }
        }

        public int Gender
        {
            set { _Gender = value; }
            get { return _Gender; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            FamousName = AppConst.StringNull;
            Biography = AppConst.StringNull;
            Birth = AppConst.DateTimeNull;
            Death = AppConst.DateTimeNull;
            Scource = AppConst.StringNull;
            FamousSysNo = AppConst.IntNull;
            ChartASC = AppConst.StringNull;
            Country = AppConst.StringNull;
            HomeTown = AppConst.StringNull;
            IsUnknow = AppConst.IntNull;
            Height = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            AstroThemeID = AppConst.StringNull;
            BirthTmp = AppConst.StringNull;
            Gender = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SPD_FamousMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion

    }

}
