using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.WebSys
{
    [Serializable]
    public class SYS_Famous_KeyWordsMod : IComparable<SYS_Famous_KeyWordsMod>
    {
        public SYS_Famous_KeyWordsMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _KeyWords;
        private int _DR;
        private DateTime _TS;
        private int _IsTop;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string KeyWords
        {
            set { _KeyWords = value; }
            get { return _KeyWords; }
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

        public int IsTop
        {
            set { _IsTop = value; }
            get { return _IsTop; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            KeyWords = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            IsTop = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_Famous_KeyWordsMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
