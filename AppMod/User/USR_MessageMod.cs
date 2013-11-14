﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.User
{
    [Serializable]
    public class USR_MessageMod : IComparable<USR_MessageMod>
    {
        public USR_MessageMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private string _Title;
        private int _Type;
        private string _Context;
        private int _IsRead;
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

        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

        public string Context
        {
            set { _Context = value; }
            get { return _Context; }
        }

        public int IsRead
        {
            set { _IsRead = value; }
            get { return _IsRead; }
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
            Title = AppConst.StringNull;
            Type = AppConst.IntNull;
            Context = AppConst.StringNull;
            IsRead = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_MessageMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
