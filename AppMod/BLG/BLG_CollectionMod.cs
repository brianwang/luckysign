using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.BLG
{
    [Serializable]
    public class BLG_CollectionMod : IComparable<BLG_CollectionMod>
    {
        public BLG_CollectionMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private string _Name;
        private string _Detail;
        private int _Type;
        private string _RefUrl;
        private int _RefSysNo;
        private int _DR;
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

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public string Detail
        {
            set { _Detail = value; }
            get { return _Detail; }
        }

        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

        public string RefUrl
        {
            set { _RefUrl = value; }
            get { return _RefUrl; }
        }

        public int RefSysNo
        {
            set { _RefSysNo = value; }
            get { return _RefSysNo; }
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
            CustomerSysNo = AppConst.IntNull;
            Name = AppConst.StringNull;
            Detail = AppConst.StringNull;
            Type = AppConst.IntNull;
            RefUrl = AppConst.StringNull;
            RefSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(BLG_CollectionMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }


}
