using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;
namespace AppMod.QA
{
    [DataContract]
    public class QA_StarMod : IComparable<QA_StarMod>
    {
        public QA_StarMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private int _OrderID;
        private string _Intro;

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

        public int OrderID
        {
            set { _OrderID = value; }
            get { return _OrderID; }
        }

        public string Intro
        {
            set { _Intro = value; }
            get { return _Intro; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            OrderID = AppConst.IntNull;
            Intro = AppConst.StringNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(QA_StarMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
