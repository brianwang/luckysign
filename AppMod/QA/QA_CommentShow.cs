using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [Serializable]
    public class QA_CommentShow : QA_CommentMod
    {


        #region 父类属性

        //[DataMember]
        //public int SysNo
        //{
        //    set { _SysNo = value; }
        //    get { return _SysNo; }
        //}

        public int QuestionSysNo
        {
            set { base.QuestionSysNo = value; }
            get { return base.QuestionSysNo; }
        }

        public int AnswerSysNo
        {
            set { base.AnswerSysNo = value; }
            get { return base.AnswerSysNo; }
        }
        //[DataMember]
        //public int CustomerSysNo
        //{
        //    set { _CustomerSysNo = value; }
        //    get { return _CustomerSysNo; }
        //}
        //[DataMember]
        //public string Context
        //{
        //    set { _Context = value; }
        //    get { return _Context; }
        //}

        public int DR
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
        }

        #endregion
    }

    
}
