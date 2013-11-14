using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.User
{
    [Serializable]
    public class USR_NoticeMod : IComparable<USR_NoticeMod>
    {
        public USR_NoticeMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerNum;
        private string _Title;
        private string _Context;
        private int _DR;
        private DateTime _TS;
        private string _Condition;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int CustomerNum
        {
            set { _CustomerNum = value; }
            get { return _CustomerNum; }
        }

        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        public string Context
        {
            set { _Context = value; }
            get { return _Context; }
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

        public string Condition
        {
            set { _Condition = value; }
            get { return _Condition; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CustomerNum = AppConst.IntNull;
            Title = AppConst.StringNull;
            Context = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Condition = AppConst.StringNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_NoticeMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
