using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [DataContract]
    public class QA_OrderMod : IComparable<QA_OrderMod>
    {
        public QA_OrderMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _AnswerSysNo;
        private int _QuestionSysNo;
        private int _CustomerSysNo;
        private decimal _Price;
        private int _Status;
        private DateTime _TS;
        private int _Words;
        private string _Description;
        private int _Score;
        private string _Trial;
        private DateTime _ReplyTime;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int AnswerSysNo
        {
            set { _AnswerSysNo = value; }
            get { return _AnswerSysNo; }
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
        public decimal Price
        {
            set { _Price = value; }
            get { return _Price; }
        }

        [DataMember]
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }

        [DataMember]
        public int Words
        {
            set { _Words = value; }
            get { return _Words; }
        }

        [DataMember]
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        [DataMember]
        public int Score
        {
            set { _Score = value; }
            get { return _Score; }
        }

        [DataMember]
        public string Trial
        {
            set { _Trial = value; }
            get { return _Trial; }
        }

        [DataMember]
        public DateTime ReplyTime
        {
            set { _ReplyTime = value; }
            get { return _ReplyTime; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            AnswerSysNo = AppConst.IntNull;
            QuestionSysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            Price = AppConst.DecimalNull;
            Status = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Words = AppConst.IntNull;
            Description = AppConst.StringNull;
            Score = AppConst.IntNull;
            Trial = AppConst.StringNull;
            ReplyTime = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(QA_OrderMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}

