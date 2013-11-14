using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.WebSys
{
    [Serializable]
    public class SYS_AdminMod : IComparable<SYS_AdminMod>
    {
        public SYS_AdminMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Username;
        private string _Password;
        private int _CustomerSysNo;
        private DateTime _TS;
        private int _DR;
        private DateTime _LastLogin;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string Username
        {
            set { _Username = value; }
            get { return _Username; }
        }

        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }

        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
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

        public DateTime LastLogin
        {
            set { _LastLogin = value; }
            get { return _LastLogin; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Username = AppConst.StringNull;
            Password = AppConst.StringNull;
            CustomerSysNo = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            DR = AppConst.IntNull;
            LastLogin = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_AdminMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
