using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.Research
{
    [DataContract]
    public class RSH_BaziConditionMod : IComparable<RSH_BaziConditionMod>
    {
        public RSH_BaziConditionMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _Item;
        private int _Type;
        private int _Condition;
        private int _LogicSysNo;
        private int _Target;
        private int _Negative;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int Item
        {
            set { _Item = value; }
            get { return _Item; }
        }

        [DataMember]
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

        [DataMember]
        public int Condition
        {
            set { _Condition = value; }
            get { return _Condition; }
        }

        [DataMember]
        public int LogicSysNo
        {
            set { _LogicSysNo = value; }
            get { return _LogicSysNo; }
        }

        [DataMember]
        public int Target
        {
            set { _Target = value; }
            get { return _Target; }
        }

        [DataMember]
        public int Negative
        {
            set { _Negative = value; }
            get { return _Negative; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Item = AppConst.IntNull;
            Type = AppConst.IntNull;
            Condition = AppConst.IntNull;
            LogicSysNo = AppConst.IntNull;
            Target = AppConst.IntNull;
            Negative = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(RSH_BaziConditionMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

