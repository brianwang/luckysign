using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.WebSys
{
    [Serializable]
    public class SYS_PrivilegeMod : IComparable<SYS_PrivilegeMod>
    {
        public SYS_PrivilegeMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private DateTime _TS;
        private int _DR;
        private string _URL;

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

        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }

        public int DR
        {
            set { _DR = value; }
            get { return _DR; }
        }

        public string URL
        {
            set { _URL = value; }
            get { return _URL; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Name = AppConst.StringNull;
            TS = AppConst.DateTimeNull;
            DR = AppConst.IntNull;
            URL = AppConst.StringNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_PrivilegeMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
