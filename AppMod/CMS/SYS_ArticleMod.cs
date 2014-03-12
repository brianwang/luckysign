using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;
namespace AppMod.CMS
{
    [DataContract]
    public class SYS_ArticleMod : IComparable<SYS_ArticleMod>
    {
        public SYS_ArticleMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Title;
        private int _CustomerSysNo;
        private string _KeyWords;
        private int _DR;
        private DateTime _TS;
        private int _Limited;
        private int _ReadCount;
        private string _Description;
        private int _Cost;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
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

        public int Limited
        {
            set { _Limited = value; }
            get { return _Limited; }
        }

        public int ReadCount
        {
            set { _ReadCount = value; }
            get { return _ReadCount; }
        }

        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        public int Cost
        {
            set { _Cost = value; }
            get { return _Cost; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Title = AppConst.StringNull;
            CustomerSysNo = AppConst.IntNull;
            KeyWords = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Limited = AppConst.IntNull;
            ReadCount = AppConst.IntNull;
            Description = AppConst.StringNull;
            Cost = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_ArticleMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
