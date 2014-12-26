using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;
namespace AppMod.QA
{
    [DataContract]
    public class REL_Question_ChartMod : IComparable<REL_Question_ChartMod>
    {
        public REL_Question_ChartMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _Question_SysNo;
        private int _Chart_SysNo;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int Question_SysNo
        {
            set { _Question_SysNo = value; }
            get { return _Question_SysNo; }
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
            Question_SysNo = AppConst.IntNull;
            Chart_SysNo = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(REL_Question_ChartMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
