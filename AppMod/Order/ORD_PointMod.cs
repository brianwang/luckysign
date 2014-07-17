using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.Order
{
    [DataContract]
    public class ORD_PointMod : IComparable<ORD_PointMod>
    {
        public ORD_PointMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private int _ProductSysNo;
        private int _Point;
        private int _Type;
        private DateTime _TS;
        private int _Status;

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
        public int ProductSysNo
        {
            set { _ProductSysNo = value; }
            get { return _ProductSysNo; }
        }

        [DataMember]
        public int Point
        {
            set { _Point = value; }
            get { return _Point; }
        }

        [DataMember]
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
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


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            ProductSysNo = AppConst.IntNull;
            Point = AppConst.IntNull;
            Type = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Status = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(ORD_PointMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

