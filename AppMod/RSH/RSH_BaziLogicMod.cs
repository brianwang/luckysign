using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.Research
{
    [DataContract]
    public class RSH_BaziLogicMod : IComparable<RSH_BaziLogicMod>
    {
        public RSH_BaziLogicMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private string _Description;
        private string _Logic;
        private int _Type;
        private int _DR;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        [DataMember]
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        [DataMember]
        public string Logic
        {
            set { _Logic = value; }
            get { return _Logic; }
        }

        [DataMember]
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

        [DataMember]
        public int DR
        {
            set { _DR = value; }
            get { return _DR; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Name = AppConst.StringNull;
            Description = AppConst.StringNull;
            Logic = AppConst.StringNull;
            Type = AppConst.IntNull;
            DR = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(RSH_BaziLogicMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

