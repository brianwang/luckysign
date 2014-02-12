using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [Serializable]
    public class QA_AnswerMod : IComparable<QA_AnswerMod>
    {
        public QA_AnswerMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _QuestionSysNo;
        private int _CustomerSysNo;
        private string _Title;
        private string _Context;
        private int _Love;
        private int _Hate;
        private int _Award;
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

        public void Init()
        {
            SysNo = AppConst.IntNull;
            QuestionSysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            Title = AppConst.StringNull;
            Context = AppConst.StringNull;
            Love = AppConst.IntNull;
            Hate = AppConst.IntNull;
            Award = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(QA_AnswerMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
