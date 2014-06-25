using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [DataContract]
    public class QA_QuestionMod : IComparable<QA_QuestionMod>
    {
        public QA_QuestionMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CateSysNo;
        private int _CustomerSysNo;
        private string _Title;
        private string _Context;
        private int _Award;
        private DateTime _EndTime;
        private int _IsSecret;
        private DateTime _LastReplyTime;
        private int _LastReplyUser;
        private int _ReplyCount;
        private int _ReadCount;
        private int _DR;
        private DateTime _TS;
        private string _SubQuest;
        private int _OrderCount;
        private int _BuyCount;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int CateSysNo
        {
            set { _CateSysNo = value; }
            get { return _CateSysNo; }
        }

        [DataMember]
        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }

        [DataMember]
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        [DataMember]
        public string Context
        {
            set { _Context = value; }
            get { return _Context; }
        }

        [DataMember]
        public int Award
        {
            set { _Award = value; }
            get { return _Award; }
        }

        [DataMember]
        public DateTime EndTime
        {
            set { _EndTime = value; }
            get { return _EndTime; }
        }

        [DataMember]
        public int IsSecret
        {
            set { _IsSecret = value; }
            get { return _IsSecret; }
        }

        [DataMember]
        public DateTime LastReplyTime
        {
            set { _LastReplyTime = value; }
            get { return _LastReplyTime; }
        }

        [DataMember]
        public int LastReplyUser
        {
            set { _LastReplyUser = value; }
            get { return _LastReplyUser; }
        }

        [DataMember]
        public int ReplyCount
        {
            set { _ReplyCount = value; }
            get { return _ReplyCount; }
        }

        [DataMember]
        public int ReadCount
        {
            set { _ReadCount = value; }
            get { return _ReadCount; }
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
        public string SubQuest
        {
            set { _SubQuest = value; }
            get { return _SubQuest; }
        }

        [DataMember]
        public int OrderCount
        {
            set { _OrderCount = value; }
            get { return _OrderCount; }
        }

        [DataMember]
        public int BuyCount
        {
            set { _BuyCount = value; }
            get { return _BuyCount; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CateSysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            Title = AppConst.StringNull;
            Context = AppConst.StringNull;
            Award = AppConst.IntNull;
            EndTime = AppConst.DateTimeNull;
            IsSecret = AppConst.IntNull;
            LastReplyTime = AppConst.DateTimeNull;
            LastReplyUser = AppConst.IntNull;
            ReplyCount = AppConst.IntNull;
            ReadCount = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            SubQuest = AppConst.StringNull;
            OrderCount = AppConst.IntNull;
            BuyCount = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(QA_QuestionMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

