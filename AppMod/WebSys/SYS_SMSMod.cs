using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.WebSys
{
    [DataContract]
    public class SYS_SMSMod : IComparable<SYS_SMSMod>
    {
        public SYS_SMSMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Content;
        private DateTime _TS;
        private int _Status;
        private int _ReturnCode;
        private int _CustomerSysNo;
        private int _Type;
        private string _PhoneNum;
        private DateTime _SendTime;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }

        [DataMember]
        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }

        [DataMember]
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public int ReturnCode
        {
            set { _ReturnCode = value; }
            get { return _ReturnCode; }
        }

        [DataMember]
        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }

        [DataMember]
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

        [DataMember]
        public string PhoneNum
        {
            set { _PhoneNum = value; }
            get { return _PhoneNum; }
        }

        [DataMember]
        public DateTime SendTime
        {
            set { _SendTime = value; }
            get { return _SendTime; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Content = AppConst.StringNull;
            TS = AppConst.DateTimeNull;
            Status = AppConst.IntNull;
            ReturnCode = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            Type = AppConst.IntNull;
            PhoneNum = AppConst.StringNull;
            SendTime = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_SMSMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

