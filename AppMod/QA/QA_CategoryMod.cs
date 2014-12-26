using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [DataContract]
    public class QA_CategoryMod : IComparable<QA_CategoryMod>
    {
        public QA_CategoryMod()
        {
            Init();
        }



        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private int _ParentSysNo;
        private int _TopSysNo;
        private int _DR;
        private DateTime _TS;
        private string _Pic;
        private string _Intro;
        private int _OrderID;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        [DataMember]
        public int ParentSysNo
        {
            set { _ParentSysNo = value; }
            get { return _ParentSysNo; }
        }

        [DataMember]
        public int TopSysNo
        {
            set { _TopSysNo = value; }
            get { return _TopSysNo; }
        }

        [DataMember]
        public int DR
        {
            set { _DR = value; }
            get { return _DR; }
        }

        [DataMember]
        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }

        [DataMember]
        public string Pic
        {
            set { _Pic = value; }
            get { return _Pic; }
        }

        [DataMember]
        public string Intro
        {
            set { _Intro = value; }
            get { return _Intro; }
        }

        [DataMember]
        public int OrderID
        {
            set { _OrderID = value; }
            get { return _OrderID; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Name = null;
            ParentSysNo = AppConst.IntNull;
            TopSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Pic = null;
            Intro = null;
            OrderID = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(QA_CategoryMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
