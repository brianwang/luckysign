using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;
namespace AppMod.User
{
    [DataContract]
    public class USR_ActionMod : IComparable<USR_ActionMod>
    {
        public USR_ActionMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private string _xml;
        private int _Type;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }

        public string xml
        {
            set { _xml = value; }
            get { return _xml; }
        }

        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
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
            CustomerSysNo = AppConst.IntNull;
            xml = AppConst.StringNull;
            Type = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_ActionMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
