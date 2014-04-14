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
    public class  QA_QuestionShowMini<T>
    {

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CateSysNo;
        private int _CustomerSysNo;
        private string _Title;
        private string _Context;
        private int _Award;
        private DateTime _EndTime;
        private int _IsSecret;
        private DateTime _LastReplyTime;
        private int _LastReplyUser;
        private int _ReplyCount;
        private int _ReadCount;
        private int _DR;
        private DateTime _TS;

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
            get { return CommonTools.CutStr(_Context,100); }
        }
        [DataMember]
        public int Award
        {
            set { _Award = value; }
            get { return _Award; }
        }
        [DataMember]
        public long EndTime
        {
            set { _EndTime = (value*1000).MilliSecondsFrom1970ToDateTime(); }
            get { return _EndTime.ToMilliSecondsFrom1970L()/1000; }
        }
        [DataMember]
        public int IsSecret
        {
            set { _IsSecret = value; }
            get { return _IsSecret; }
        }
        [DataMember]
        public long LastReplyTime
        {
            set { _LastReplyTime = (value * 1000).MilliSecondsFrom1970ToDateTime(); }
            get { return _LastReplyTime.ToMilliSecondsFrom1970L() / 1000; }
        }
        [DataMember]
        public int LastReplyUser
        {
            set { _LastReplyUser = value; }
            get { return _LastReplyUser; }
        }
        [DataMember]
        public int ReplyCount
        {
            set { _ReplyCount = value; }
            get { return _ReplyCount; }
        }
        [DataMember]
        public int ReadCount
        {
            set { _ReadCount = value; }
            get { return _ReadCount; }
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

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CateSysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            Title = AppConst.StringNull;
            Context = AppConst.StringNull;
            Award = AppConst.IntNull;
            _EndTime = AppConst.DateTimeNull;
            IsSecret = AppConst.IntNull;
            _LastReplyTime = AppConst.DateTimeNull;
            LastReplyUser = AppConst.IntNull;
            ReplyCount = AppConst.IntNull;
            ReadCount = AppConst.IntNull;
            DR = AppConst.IntNull;
            _TS = AppConst.DateTimeNull;

        }

        #region 扩展属性
        private List<T> _chart = new List<T>();
        [DataMember]
        public List<T> Chart
        {
            get { return _chart; }
            set { _chart = value; }
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
