using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;
namespace AppMod.CMS
{
    [DataContract]
    public class CMS_CategoryMod : IComparable<CMS_CategoryMod>
    {
        public CMS_CategoryMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private int _ParentSysNo;
        private int _TopSysNo;
        private int _IsHide;
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

        public int TopSysNo
        {
            set { _TopSysNo = value; }
            get { return _TopSysNo; }
        }

        public int IsHide
        {
            set { _IsHide = value; }
            get { return _IsHide; }
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
            TopSysNo = AppConst.IntNull;
            IsHide = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(CMS_CategoryMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}
