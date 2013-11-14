using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;

namespace AppMod.BLG
{
    [Serializable]
    public class BLG_AttentionMod : IComparable<BLG_AttentionMod>
    {
        public BLG_AttentionMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private int _TargetSysNo;
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

        public int TargetSysNo
        {
            set { _TargetSysNo = value; }
            get { return _TargetSysNo; }
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
            TargetSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(BLG_AttentionMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
