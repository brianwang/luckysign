using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;
using AppMod.User;

namespace AppMod.QA
{
    [DataContract]
    public class QA_AnswerShow : QA_AnswerMod
    {

        #region 父类属性
        //[DataMember]
        //public int SysNo
        //{
        //    set { _SysNo = value; }
        //    get { return _SysNo; }
        //}
        //[DataMember]
        //public int QuestionSysNo
        //{
        //    set { _QuestionSysNo = value; }
        //    get { return _QuestionSysNo; }
        //}
        //[DataMember]
        //public int CustomerSysNo
        //{
        //    set { _CustomerSysNo = value; }
        //    get { return _CustomerSysNo; }
        //}
        //[DataMember]
        //public string Title
        //{
        //    set { _Title = value; }
        //    get { return _Title; }
        //}
        //[DataMember]
        //public string Context
        //{
        //    set { _Context = value; }
        //    get { return _Context; }
        //}
        //[DataMember]
        //public int Love
        //{
        //    set { _Love = value; }
        //    get { return _Love; }
        //}
        //[DataMember]
        //public int Hate
        //{
        //    set { _Hate = value; }
        //    get { return _Hate; }
        //}
        //[DataMember]
        //public int Award
        //{
        //    set { _Award = value; }
        //    get { return _Award; }
        //}
        
        public new int DR
        {
            set { base.DR = value; }
            get { return base.DR; }
        }
        //[DataMember]
        //public DateTime TS
        //{
        //    set { _TS = value; }
        //    get { return _TS; }
        //}


        #endregion

        #region 扩展成员属性

        [DataMember]
        public string TSShow
        {
            get { return base.TS.ToString("yyyy-MM-dd HH:mm"); }
            set { }
        }

        private USR_CustomerShow _Customer;
        [DataMember]
        public USR_CustomerShow Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        private List<QA_CommentShow> _TopComments;
        [DataMember]
        public List<QA_CommentShow> TopComments
        {
            get { return _TopComments; }
            set { _TopComments = value; }
        }

        private bool _HasMoreComment;
        [DataMember]
        public bool HasMoreComment
        {
            get { return _HasMoreComment; }
            set { _HasMoreComment = value; }
        }


        #endregion


    }

}
