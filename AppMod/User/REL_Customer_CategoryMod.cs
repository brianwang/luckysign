using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.User
{
    [Serializable]
    public class REL_Customer_CategoryMod : IComparable<REL_Customer_CategoryMod>
    {
        public REL_Customer_CategoryMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private int _CategorySysNo;
        private int _Type;
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

        public int CategorySysNo
        {
            set { _CategorySysNo = value; }
            get { return _CategorySysNo; }
        }

        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
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
            CategorySysNo = AppConst.IntNull;
            Type = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(REL_Customer_CategoryMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
