using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.WebSys
{
    [Serializable]
    public class SYS_Famous_CategoryMod : IComparable<SYS_Famous_CategoryMod>
    {
        public SYS_Famous_CategoryMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private int _ParentSysNo;
        private int _DR;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public int ParentSysNo
        {
            set { _ParentSysNo = value; }
            get { return _ParentSysNo; }
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
            Name = AppConst.StringNull;
            ParentSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_Famous_CategoryMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}

