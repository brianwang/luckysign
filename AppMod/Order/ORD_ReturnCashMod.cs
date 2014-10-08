using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.Order
{
    [DataContract]
    public class ORD_ReturnCashMod : IComparable<ORD_ReturnCashMod>
    {
        public ORD_ReturnCashMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _OrderSysNo;
        private int _ReasonType;
        private string _Detail;
        private decimal _Amount;
        private DateTime _TS;
        private int _Status;
        private DateTime _ReturnTime;
        private string _ReturnID;
        private string _CurrentID;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int OrderSysNo
        {
            set { _OrderSysNo = value; }
            get { return _OrderSysNo; }
        }

        [DataMember]
        public int ReasonType
        {
            set { _ReasonType = value; }
            get { return _ReasonType; }
        }

        [DataMember]
        public string Detail
        {
            set { _Detail = value; }
            get { return _Detail; }
        }

        [DataMember]
        public decimal Amount
        {
            set { _Amount = value; }
            get { return _Amount; }
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
        public DateTime ReturnTime
        {
            set { _ReturnTime = value; }
            get { return _ReturnTime; }
        }

        [DataMember]
        public string ReturnID
        {
            set { _ReturnID = value; }
            get { return _ReturnID; }
        }

        [DataMember]
        public string CurrentID
        {
            set { _CurrentID = value; }
            get { return _CurrentID; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            OrderSysNo = AppConst.IntNull;
            ReasonType = AppConst.IntNull;
            Detail = AppConst.StringNull;
            Amount = AppConst.DecimalNull;
            TS = AppConst.DateTimeNull;
            Status = AppConst.IntNull;
            ReturnTime = AppConst.DateTimeNull;
            ReturnID = AppConst.StringNull;
            CurrentID = AppConst.StringNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(ORD_ReturnCashMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

