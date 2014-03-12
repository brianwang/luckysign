using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.WebSys
{
    [DataContract]
    public class SYS_DistrictMod : IComparable<SYS_DistrictMod>
    {
        public SYS_DistrictMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _UpSysNo;
        private string _Name;
        private string _EnglishName;
        private int _Level;
        private int _UseType;
        private int _DR;
        private DateTime _TS;
        private string _Latitude;
        private string _longitude;
        private int _TopSysNo;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int UpSysNo
        {
            set { _UpSysNo = value; }
            get { return _UpSysNo; }
        }

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public string EnglishName
        {
            set { _EnglishName = value; }
            get { return _EnglishName; }
        }

        public int Level
        {
            set { _Level = value; }
            get { return _Level; }
        }

        public int UseType
        {
            set { _UseType = value; }
            get { return _UseType; }
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

        public string Latitude
        {
            set { _Latitude = value; }
            get { return _Latitude; }
        }

        public string longitude
        {
            set { _longitude = value; }
            get { return _longitude; }
        }

        public int TopSysNo
        {
            set { _TopSysNo = value; }
            get { return _TopSysNo; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            UpSysNo = AppConst.IntNull;
            Name = AppConst.StringNull;
            EnglishName = AppConst.StringNull;
            Level = AppConst.IntNull;
            UseType = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Latitude = AppConst.StringNull;
            longitude = AppConst.StringNull;
            TopSysNo = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_DistrictMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
