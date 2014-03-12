using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [DataContract]
    public class QA_CommentMod : IComparable<QA_CommentMod>
    {
        public QA_CommentMod()
        {
            Init();
        }

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
        [DataMember]
        public int QuestionSysNo
        {
            set { _QuestionSysNo = value; }
            get { return _QuestionSysNo; }
        }
        [DataMember]
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

        public void Init()
        {
            SysNo = AppConst.IntNull;
            QuestionSysNo = AppConst.IntNull;
            AnswerSysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
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
        public int CompareTo(QA_CommentMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion

    }

    
}
