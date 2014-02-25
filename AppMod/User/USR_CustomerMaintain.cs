using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using AppCmn;

namespace AppMod.User
{
    /// <summary>
    /// 用于API输出完整用户信息
    /// </summary>
    [DataContract]
    public class USR_CustomerMaintain
    {
        public USR_CustomerMaintain()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Email;
        private string _Password;
        private int _GradeSysNo;
        private string _NickName;
        private int _Gender;
        private string _Photo;
        private int _Credit;
        private int _Point;
        private DateTime _birth;
        private int _FateType;
        private DateTime _RegTime;
        private DateTime _LastLoginTime;
        private int _Status;
        private int _IsStar;
        private string _Signature;
        private int _Exp;
        private int _TotalAnswer;
        private int _TotalQuest;
        private int _BestAnswer;
        private int _HomeTown;
        private string _Intro;
        private string _Icons;
        private int _IsShowBirth;
        private int _TotalReply;
        private int _HasNewInfo;
        private int _TotalTalk;
        private int _TotalTalkReply;
        private string _Phone;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public int GradeSysNo
        {
            set { _GradeSysNo = value; }
            get { return _GradeSysNo; }
        }

        [DataMember]
        public string NickName
        {
            set { _NickName = value; }
            get { return _NickName; }
        }

        [DataMember]
        public int Gender
        {
            set { _Gender = value; }
            get { return _Gender; }
        }

        
        public string Photo
        {
            set { _Photo = value; }
            get { return _Photo; }
        }

        [DataMember]
        public int Credit
        {
            set { _Credit = value; }
            get { return _Credit; }
        }

        [DataMember]
        public int Point
        {
            set { _Point = value; }
            get { return _Point; }
        }

        
        public DateTime birth
        {
            set { _birth = value; }
            get { return _birth; }
        }

        [DataMember]
        public int FateType
        {
            set { _FateType = value; }
            get { return _FateType; }
        }

        
        public DateTime RegTime
        {
            set { _RegTime = value; }
            get { return _RegTime; }
        }

        
        public DateTime LastLoginTime
        {
            set { _LastLoginTime = value; }
            get { return _LastLoginTime; }
        }

        [DataMember]
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        [DataMember]
        public int IsStar
        {
            set { _IsStar = value; }
            get { return _IsStar; }
        }

        
        public string Signature
        {
            set { _Signature = value; }
            get { return _Signature; }
        }

        
        public int Exp
        {
            set { _Exp = value; }
            get { return _Exp; }
        }

        
        public int TotalAnswer
        {
            set { _TotalAnswer = value; }
            get { return _TotalAnswer; }
        }

        
        public int TotalQuest
        {
            set { _TotalQuest = value; }
            get { return _TotalQuest; }
        }

        
        public int BestAnswer
        {
            set { _BestAnswer = value; }
            get { return _BestAnswer; }
        }

        
        public int HomeTown
        {
            set { _HomeTown = value; }
            get { return _HomeTown; }
        }

        
        public string Intro
        {
            set { _Intro = value; }
            get { return _Intro; }
        }

        
        public int IsShowBirth
        {
            set { _IsShowBirth = value; }
            get { return _IsShowBirth; }
        }

        
        public int TotalReply
        {
            set { _TotalReply = value; }
            get { return _TotalReply; }
        }

        [DataMember]
        public int HasNewInfo
        {
            set { _HasNewInfo = value; }
            get { return _HasNewInfo; }
        }

        
        public int TotalTalk
        {
            set { _TotalTalk = value; }
            get { return _TotalTalk; }
        }

        
        public int TotalTalkReply
        {
            set { _TotalTalkReply = value; }
            get { return _TotalTalkReply; }
        }



        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            GradeSysNo = AppConst.IntNull;
            Gender = AppConst.IntNull;
            Credit = AppConst.IntNull;
            Point = AppConst.IntNull;
            birth = AppConst.DateTimeNull;
            FateType = AppConst.IntNull;
            Status = AppConst.IntNull;
            IsStar = AppConst.IntNull;
            Signature = AppConst.StringNull;
            Exp = AppConst.IntNull;
            TotalAnswer = AppConst.IntNull;
            TotalQuest = AppConst.IntNull;
            BestAnswer = AppConst.IntNull;
            HomeTown = AppConst.IntNull;
            Intro = AppConst.StringNull;
            IsShowBirth = AppConst.IntNull;
            TotalReply = AppConst.IntNull;
            HasNewInfo = AppConst.IntNull;
            TotalTalk = AppConst.IntNull;
            TotalTalkReply = AppConst.IntNull;

        }
        
       

        #region 扩展成员属性

        [DataMember]
        public string GradeShow
        {
            get { return _GradeSysNo.ToString()+"级"; }
            set { }
        }

        //[DataMember]
        //public string GenderShow
        //{
        //    get { return AppEnum.GetGender(base.Phone); }
        //}

        [DataMember]
        public string BigPhotoShow
        {
            get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=t&id=" + _Photo; }
            set { }
        }

        [DataMember]
        public string smallPhotoShow
        {
            get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=o&id=" + _Photo; }
            set { }
        }

        //[DataMember]
        //public string BirthShow
        //{
        //    get { return _birth.ToString("yyyy-MM-dd") ; }
        //    set { }
        //}

        //[DataMember]
        //public string HomeTownShow
        //{
        //    get { return appb _Phone; }
        //}

        //[DataMember]
        //public string FateTypeShow
        //{
        //    set { _Phone = value; }
        //    get { return _Phone; }
        //}

        //[DataMember]
        //public string LastLoginTimeShow
        //{
        //    get { return _LastLoginTime.ToString("yyyy-MM-dd HH:mm:ss"); }
        //    set { }
        //}

        //[DataMember]
        //public string RegTimeShow
        //{
        //    get { return _RegTime.ToString("yyyy-MM-dd HH:mm:ss"); }
        //    set { }
        //}

        #endregion

    }

}
