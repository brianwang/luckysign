using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;

namespace AppMod.CMS
{
    [Serializable]
    public class REL_Article_ChartMod : IComparable<REL_Article_ChartMod>
    {
        public REL_Article_ChartMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _Article_SysNo;
        private int _Chart_SysNo;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int Article_SysNo
        {
            set { _Article_SysNo = value; }
            get { return _Article_SysNo; }
        }

        public int Chart_SysNo
        {
            set { _Chart_SysNo = value; }
            get { return _Chart_SysNo; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Article_SysNo = AppConst.IntNull;
            Chart_SysNo = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(REL_Article_ChartMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
