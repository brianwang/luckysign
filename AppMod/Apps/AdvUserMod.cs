using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.Apps
{
    [Serializable]
    public class AdvUserMod : IComparable<AdvUserMod>
    {
        public AdvUserMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private string _CellPhone;
        private string _FirstRequestUrl;
        private int _SSQianSysNo;
        private DateTime _BirthTime;
        private int _Gender;
        private int _DistrictSysNo;
        private int _DR;
        private DateTime _TS;

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

        public string CellPhone
        {
            set { _CellPhone = value; }
            get { return _CellPhone; }
        }

        public string FirstRequestUrl
        {
            set { _FirstRequestUrl = value; }
            get { return _FirstRequestUrl; }
        }

        public int SSQianSysNo
        {
            set { _SSQianSysNo = value; }
            get { return _SSQianSysNo; }
        }

        public DateTime BirthTime
        {
            set { _BirthTime = value; }
            get { return _BirthTime; }
        }

        public int Gender
        {
            set { _Gender = value; }
            get { return _Gender; }
        }

        public int DistrictSysNo
        {
            set { _DistrictSysNo = value; }
            get { return _DistrictSysNo; }
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


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Name = AppConst.StringNull;
            CellPhone = AppConst.StringNull;
            FirstRequestUrl = AppConst.StringNull;
            SSQianSysNo = AppConst.IntNull;
            BirthTime = AppConst.DateTimeNull;
            Gender = AppConst.IntNull;
            DistrictSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(AdvUserMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
