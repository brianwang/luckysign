using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.Order
{
    [DataContract]
    public class ORD_CashMod : IComparable<ORD_CashMod>
    {
        public ORD_CashMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private int _ProductType;
        private int _ProductSysNo;
        private decimal _Price;
        private int _PayType;
        private decimal _Discount;
        private decimal _PayAmount;
        private DateTime _TS;
        private int _Status;
        private string _OrderID;
        private string _CurrentID;
        private DateTime _PayTime;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }

        [DataMember]
        public int ProductType
        {
            set { _ProductType = value; }
            get { return _ProductType; }
        }

        [DataMember]
        public int ProductSysNo
        {
            set { _ProductSysNo = value; }
            get { return _ProductSysNo; }
        }

        [DataMember]
        public decimal Price
        {
            set { _Price = value; }
            get { return _Price; }
        }

        [DataMember]
        public int PayType
        {
            set { _PayType = value; }
            get { return _PayType; }
        }

        [DataMember]
        public decimal Discount
        {
            set { _Discount = value; }
            get { return _Discount; }
        }

        [DataMember]
        public decimal PayAmount
        {
            set { _PayAmount = value; }
            get { return _PayAmount; }
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
        public string OrderID
        {
            set { _OrderID = value; }
            get { return _OrderID; }
        }

        [DataMember]
        public string CurrentID
        {
            set { _CurrentID = value; }
            get { return _CurrentID; }
        }

        [DataMember]
        public DateTime PayTime
        {
            set { _PayTime = value; }
            get { return _PayTime; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            ProductType = AppConst.IntNull;
            ProductSysNo = AppConst.IntNull;
            Price = AppConst.DecimalNull;
            PayType = AppConst.IntNull;
            Discount = AppConst.DecimalNull;
            PayAmount = AppConst.DecimalNull;
            TS = AppConst.DateTimeNull;
            Status = AppConst.IntNull;
            OrderID = AppConst.StringNull;
            CurrentID = AppConst.StringNull;
            PayTime = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(ORD_CashMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

