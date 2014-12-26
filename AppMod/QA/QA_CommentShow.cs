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
        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }


        #endregion


        #region 扩展成员属性


        private USR_CustomerMaintain _Customer;
        [DataMember]
        public USR_CustomerMaintain Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        #endregion
    }

    
}
