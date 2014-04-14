using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using AppMod.Fate;
using AppMod.User;
using System.Runtime.Serialization;

namespace AppMod.QA
{
    [DataContract]
    public class  QA_QuestionShowMini<T>: QA_QuestionMod
    {

        #region 父类属性

        
        //public int SysNo
        //{
        //    set { _SysNo = value; }
        //    get { return _SysNo; }
        //}

        //public int CateSysNo
        //{
        //    set { _CateSysNo = value; }
        //    get { return _CateSysNo; }
        //}

        //public int CustomerSysNo
        //{
        //    set { _CustomerSysNo = value; }
        //    get { return _CustomerSysNo; }
        //}

        //public string Title
        //{
        //    set { _Title = value; }
        //    get { return _Title; }
        //}

        [DataMember]
        public new string Context
        {
            set {}
            get { return CommonTools.CutStr(base.Context, 100); }
        }

        //public int Award
        //{
        //    set { _Award = value; }
        //    get { return _Award; }
        //}

        public new DateTime EndTime
        {
            set { base.EndTime = value; }
            get { return base.EndTime; }
        }

        public new int IsSecret
        {
            set { base.IsSecret = value; }
            get { return base.IsSecret; }
        }

        //public DateTime LastReplyTime
        //{
        //    set { _LastReplyTime = value; }
        //    get { return _LastReplyTime; }
        //}

        //public int LastReplyUser
        //{
        //    set { _LastReplyUser = value; }
        //    get { return _LastReplyUser; }
        //}

        //public int ReplyCount
        //{
        //    set { _ReplyCount = value; }
        //    get { return _ReplyCount; }
        //}

        //public int ReadCount
        //{
        //    set { _ReadCount = value; }
        //    get { return _ReadCount; }
        //}

        public new int DR
        {
            set { base.DR = value; }
            get { return base.DR; }
        }

        //public DateTime TS
        //{
        //    set { _TS = value; }
        //    get { return _TS; }
        //}


        #endregion

        #region 扩展属性
        private List<T> _chart = new List<T>();
        [DataMember]
        public List<T> Chart
        {
            get { return _chart; }
            set { _chart = value; }
        }
        [DataMember]
        public string LastReplyTimeShow
        {
            get { return base.LastReplyTime.ToString("yyyy-MM-dd HH:mm"); }
            set { }
        }
        [DataMember]
        public string TSShow
        {
            get { return base.TS.ToString("yyyy-MM-dd HH:mm"); }
            set { }
        }
        private string _CustomerPhoto;
        public string CustomerPhoto
        {
            get { return _CustomerPhoto; }
            set { _CustomerPhoto = value; }
        }
        private string _CustomerNickName;
        [DataMember]
        public string CustomerNickName
        {
            get { return _CustomerNickName; }
            set { _CustomerNickName = value; }
        }

        [DataMember]
        public string BigPhotoShow
        {
            get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=t&id=" + CustomerPhoto; }
            set { }
        }

        [DataMember]
        public string smallPhotoShow
        {
            get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=o&id=" + CustomerPhoto; }
            set { }
        }

        #endregion


    }

}
