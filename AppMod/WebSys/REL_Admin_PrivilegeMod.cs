using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.WebSys
{
    [Serializable]
    public class REL_Admin_PrivilegeMod : IComparable<REL_Admin_PrivilegeMod>
    {
        public REL_Admin_PrivilegeMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _Admin_SysNo;
        private int _Privilege_SysNo;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int Admin_SysNo
        {
            set { _Admin_SysNo = value; }
            get { return _Admin_SysNo; }
        }

        public int Privilege_SysNo
        {
            set { _Privilege_SysNo = value; }
            get { return _Privilege_SysNo; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Admin_SysNo = AppConst.IntNull;
            Privilege_SysNo = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(REL_Admin_PrivilegeMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
