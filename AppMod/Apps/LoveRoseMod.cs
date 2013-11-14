using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;

namespace AppMod.Apps
{
    [Serializable]
    public class LoveRoseMod : IComparable<LoveRoseMod>
    {
        public LoveRoseMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private DateTime _BirthTime;
        private int _Area;
        private int _Source;
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
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(LoveRoseMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
