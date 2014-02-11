using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [Serializable]
    public class QA_AnswerShow : QA_AnswerMod
    {

        #region 父类属性
        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }
        [DataMember]
        public int QuestionSysNo
        {
            set { _QuestionSysNo = value; }
            get { return _QuestionSysNo; }
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
        public int Love
        {
            set { _Love = value; }
            get { return _Love; }
        }
        [DataMember]
        public int Hate
        {
            set { _Hate = value; }
            get { return _Hate; }
        }
        [DataMember]
        public int Award
        {
            set { _Award = value; }
            get { return _Award; }
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


        #endregion


    }

}
