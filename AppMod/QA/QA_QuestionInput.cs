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
    public class QA_QuestionInput<T>
    {

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CateSysNo;
        private int _CustomerSysNo;
        private string _Title;
        private string _Context;
        private int _Award;
        private int _IsSecret;

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
        public int IsSecret
        {
            set { _IsSecret = value; }
            get { return _IsSecret; }
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
        
        #endregion


    }

}
