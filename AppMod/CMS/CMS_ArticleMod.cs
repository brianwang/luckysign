using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.CMS
{
    [DataContract]
    public class CMS_ArticleMod : IComparable<CMS_ArticleMod>
    {
        public CMS_ArticleMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _ArticleSysNo;
        private int _CateSysNo;
        private string _Source;
        private int _DR;
        private DateTime _TS;
        private int _OrderID;
        private string _Author;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int ArticleSysNo
        {
            set { _ArticleSysNo = value; }
            get { return _ArticleSysNo; }
        }

        public int CateSysNo
        {
            set { _CateSysNo = value; }
            get { return _CateSysNo; }
        }

        public string Source
        {
            set { _Source = value; }
            get { return _Source; }
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

        public int OrderID
        {
            set { _OrderID = value; }
            get { return _OrderID; }
        }

        public string Author
        {
            set { _Author = value; }
            get { return _Author; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            ArticleSysNo = AppConst.IntNull;
            CateSysNo = AppConst.IntNull;
            Source = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            OrderID = AppConst.IntNull;
            Author = AppConst.StringNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(CMS_ArticleMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}
