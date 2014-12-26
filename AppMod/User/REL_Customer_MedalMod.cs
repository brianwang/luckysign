using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.User
{
    [DataContract]
    public class REL_Customer_MedalMod : IComparable<REL_Customer_MedalMod>
    {
        public REL_Customer_MedalMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _MedalSysNo;
        private int _CustomerSysNo;
        private int _DR;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int MedalSysNo
        {
            set { _MedalSysNo = value; }
            get { return _MedalSysNo; }
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


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            MedalSysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(REL_Customer_MedalMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
