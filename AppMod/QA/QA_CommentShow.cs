using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;
using AppMod.User;
using XMS.Core;

namespace AppMod.QA
{
    [DataContract]
    public class QA_CommentShow
    {


        #region 成员变量和公共属性
        private int _SysNo;
        private int _QuestionSysNo;
        private int _AnswerSysNo;
        private int _CustomerSysNo;
        private string _Context;
        private int _DR;
        private DateTime _TS;
        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }
        
        public int QuestionSysNo
        {
            set { _QuestionSysNo = value; }
            get { return _QuestionSysNo; }
        }
        
        public int AnswerSysNo
        {
            set { _AnswerSysNo = value; }
            get { return _AnswerSysNo; }
        }
        [DataMember]
        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }
        [DataMember]
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
        [DataMember]
        public long TS
        {
            set { _TS = (value * 1000).MilliSecondsFrom1970ToDateTime(); }
            get { return _TS.ToMilliSecondsFrom1970L() / 1000; }
        }


        #endregion


        #region 扩展成员属性


        private USR_CustomerShow _Customer;
        [DataMember]
        public USR_CustomerShow Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        #endregion
    }

    
}
