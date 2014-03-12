using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.User
{
    [DataContract]
    public class USR_MedalMod : IComparable<USR_MedalMod>
    {
        public USR_MedalMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _MedalName;
        private string _Detail;
        private int _DR;
        private DateTime _TS;
        private int _Type;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string MedalName
        {
            set { _MedalName = value; }
            get { return _MedalName; }
        }

        public string Detail
        {
            set { _Detail = value; }
            get { return _Detail; }
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

        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            MedalName = AppConst.StringNull;
            Detail = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Type = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_MedalMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion

    }

}
