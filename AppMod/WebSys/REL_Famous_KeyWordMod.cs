using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.WebSys
{
    [DataContract]
    public class REL_Famous_KeyWordMod : IComparable<REL_Famous_KeyWordMod>
    {
        public REL_Famous_KeyWordMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _Famous_SysNo;
        private int _KeyWord_SysNo;
        private int _Value;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int Famous_SysNo
        {
            set { _Famous_SysNo = value; }
            get { return _Famous_SysNo; }
        }

        public int KeyWord_SysNo
        {
            set { _KeyWord_SysNo = value; }
            get { return _KeyWord_SysNo; }
        }

        public int Value
        {
            set { _Value = value; }
            get { return _Value; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Famous_SysNo = AppConst.IntNull;
            KeyWord_SysNo = AppConst.IntNull;
            Value = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(REL_Famous_KeyWordMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
