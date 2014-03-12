using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.Fate
{
    [DataContract]
    public class FATE_AstroMod : IComparable<FATE_AstroMod>
    {
        public FATE_AstroMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private string _ID;
        private DateTime _LastTime;
        private int _DR;
        private DateTime _TS;

        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }

        public DateTime LastTime
        {
            set { _LastTime = value; }
            get { return _LastTime; }
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
            ID = AppConst.StringNull;
            LastTime = AppConst.DateTimeNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据ID字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(FATE_AstroMod other)
        {
            return ID.CompareTo(other.ID);
        }
        #endregion
    }


}
