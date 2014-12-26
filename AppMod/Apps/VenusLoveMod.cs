using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;

namespace AppMod.Apps
{
    [DataContract]
    public class VenusLoveMod : IComparable<VenusLoveMod>
    {
        public VenusLoveMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private DateTime _BirthTime;
        private int _Area;
        private int _Source;
        private int _UserSysNo;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public DateTime BirthTime
        {
            set { _BirthTime = value; }
            get { return _BirthTime; }
        }

        public int Area
        {
            set { _Area = value; }
            get { return _Area; }
        }

        public int Source
        {
            set { _Source = value; }
            get { return _Source; }
        }

        public int UserSysNo
        {
            set { _UserSysNo = value; }
            get { return _UserSysNo; }
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
            BirthTime = AppConst.DateTimeNull;
            Area = AppConst.IntNull;
            Source = AppConst.IntNull;
            UserSysNo = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(VenusLoveMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
