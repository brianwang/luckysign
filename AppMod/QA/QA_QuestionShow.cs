using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using AppMod.Fate;
using AppMod.User;
using System.Runtime.Serialization;
using XMS.Core;

namespace AppMod.QA
{
    [DataContract]
    public class QA_QuestionShow<T>
    {

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


        #endregion

        #region 扩展属性

        private List<T> _chart = new List<T>();
        [DataMember]
        public List<T> Chart
        {
            get { return _chart; }
            set { _chart = value; }
        }
        
        private USR_CustomerShow _Customer;
        [DataMember]
        public USR_CustomerShow Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }
        [DataMember]
        public bool IsEnd
        {
            get { return _EndTime==null||EndTime==AppCmn.AppConst.DateTimeNull ?false:true; }
            set {  }
        }
        #endregion


    }

}
