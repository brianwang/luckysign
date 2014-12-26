using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.CMS
{
    [DataContract]
    public class SYS_ArticleContentMod : IComparable<SYS_ArticleContentMod>
    {
        public SYS_ArticleContentMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _ArticleSysNo;
        private int _Page;
        private string _Context;
        private int _DR;
        private DateTime _TS;

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

        public int Page
        {
            set { _Page = value; }
            get { return _Page; }
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


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            ArticleSysNo = AppConst.IntNull;
            Page = AppConst.IntNull;
            Context = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_ArticleContentMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
