using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.BLG
{
    [Serializable]
    public class BLG_ReplyMod : IComparable<BLG_ReplyMod>
    {
        public BLG_ReplyMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CommentSysNo;
        private string _Title;
        private string _Context;
        private int _CustomerSysNo;
        private int _DR;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int CommentSysNo
        {
            set { _CommentSysNo = value; }
            get { return _CommentSysNo; }
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

        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
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
            CommentSysNo = AppConst.IntNull;
            Title = AppConst.StringNull;
            Context = AppConst.StringNull;
            CustomerSysNo = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(BLG_ReplyMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
