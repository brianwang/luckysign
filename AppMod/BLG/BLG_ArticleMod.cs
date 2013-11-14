using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;

namespace AppMod.BLG
{
    [Serializable]
    public class BLG_ArticleMod : IComparable<BLG_ArticleMod>
    {
        public BLG_ArticleMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Title;
        private string _Context;
        private int _CustomerSysNo;
        private DateTime _LastReplyTime;
        private int _Love;
        private int _Hate;
        private int _Spread;
        private int _Type;
        private string _TargetUrl;
        private int _ChartSysNo;
        private int _CommentCount;
        private int _DR;
        private DateTime _TS;

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

        public DateTime LastReplyTime
        {
            set { _LastReplyTime = value; }
            get { return _LastReplyTime; }
        }

        public int Love
        {
            set { _Love = value; }
            get { return _Love; }
        }

        public int Hate
        {
            set { _Hate = value; }
            get { return _Hate; }
        }

        public int Spread
        {
            set { _Spread = value; }
            get { return _Spread; }
        }

        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }

        public string TargetUrl
        {
            set { _TargetUrl = value; }
            get { return _TargetUrl; }
        }

        public int ChartSysNo
        {
            set { _ChartSysNo = value; }
            get { return _ChartSysNo; }
        }

        public int CommentCount
        {
            set { _CommentCount = value; }
            get { return _CommentCount; }
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
            Title = AppConst.StringNull;
            Context = AppConst.StringNull;
            CustomerSysNo = AppConst.IntNull;
            LastReplyTime = AppConst.DateTimeNull;
            Love = AppConst.IntNull;
            Hate = AppConst.IntNull;
            Spread = AppConst.IntNull;
            Type = AppConst.IntNull;
            TargetUrl = AppConst.StringNull;
            ChartSysNo = AppConst.IntNull;
            CommentCount = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(BLG_ArticleMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
