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
    public class USR_CustomerMaintain : USR_CustomerMod
    {

        #region 父类属性


        //[DataMember]
        //public int SysNo
        //{
        //    set { _SysNo = value; }
        //    get { return _SysNo; }
        //}

        public new string Email
        {
            set;
            get;
        }

        public new string Password
        {
            set;
            get;
        }

        //[DataMember]
        //public int GradeSysNo
        //{
        //    set { _GradeSysNo = value; }
        //    get { return _GradeSysNo; }
        //}

        public new string NickName
        {
            set;
            get;
        }

        //[DataMember]
        //public int Gender
        //{
        //    set { _Gender = value; }
        //    get { return _Gender; }
        //}

        
        public new string Photo
        {
            set;
            get;
        }

        //[DataMember]
        //public int Credit
        //{
        //    set { _Credit = value; }
        //    get { return _Credit; }
        //}

        //[DataMember]
        //public int Point
        //{
        //    set { _Point = value; }
        //    get { return _Point; }
        //}

        //[DataMember]
        //public DateTime birth
        //{
        //    set { _birth = value; }
        //    get { return _birth; }
        //}

        //[DataMember]
        //public int FateType
        //{
        //    set { _FateType = value; }
        //    get { return _FateType; }
        //}

        public new DateTime RegTime
        {
            set;
            get;
        }

        public new DateTime LastLoginTime
        {
            set;
            get;
        }

        //public new int Status
        //{
        //    set { base.Status = value; }
        //    //get { return base.Status; }
        //}

        //[DataMember]
        //public int IsStar
        //{
        //    set { _IsStar = value; }
        //    get { return _IsStar; }
        //}

        //[DataMember]
        //public string Signature
        //{
        //    set { _Signature = value; }
        //    get { return _Signature; }
        //}

        //[DataMember]
        //public int Exp
        //{
        //    set { _Exp = value; }
        //    get { return _Exp; }
        //}

        //[DataMember]
        //public int TotalAnswer
        //{
        //    set { _TotalAnswer = value; }
        //    get { return _TotalAnswer; }
        //}

        //[DataMember]
        //public int TotalQuest
        //{
        //    set { _TotalQuest = value; }
        //    get { return _TotalQuest; }
        //}

        //[DataMember]
        //public int BestAnswer
        //{
        //    set { _BestAnswer = value; }
        //    get { return _BestAnswer; }
        //}

        //[DataMember]
        //public int HomeTown
        //{
        //    set { _HomeTown = value; }
        //    get { return _HomeTown; }
        //}

        //[DataMember]
        //public string Intro
        //{
        //    set { _Intro = value; }
        //    get { return _Intro; }
        //}

        public new string Icons
        {
            set;
            get;
        }

        //[DataMember]
        //public int IsShowBirth
        //{
        //    set { _IsShowBirth = value; }
        //    get { return _IsShowBirth; }
        //}

        //[DataMember]
        //public int TotalReply
        //{
        //    set { _TotalReply = value; }
        //    get { return _TotalReply; }
        //}

        //[DataMember]
        //public int HasNewInfo
        //{
        //    set { _HasNewInfo = value; }
        //    get { return _HasNewInfo; }
        //}

        //[DataMember]
        //public int TotalTalk
        //{
        //    set { _TotalTalk = value; }
        //    get { return _TotalTalk; }
        //}

        //[DataMember]
        //public int TotalTalkReply
        //{
        //    set { _TotalTalkReply = value; }
        //    get { return _TotalTalkReply; }
        //}

        public new string Phone
        {
            set;
            get;
        }

        #endregion

        #region 扩展成员属性

        [DataMember]
        public string GradeShow
        {
            get { return base.GradeSysNo.ToString()+"级"; }
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
            get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=t&id=" + base.Photo; }
            set { }
        }

        [DataMember]
        public string smallPhotoShow
        {
            get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=o&id=" + base.Photo; }
            set { }
        }

        [DataMember]
        public string BirthShow
        {
            get { return base.birth.ToString("yyyy-MM-dd") ; }
            set { }
        }

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

        [DataMember]
        public string LastLoginTimeShow
        {
            get { return base.birth.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { }
        }

        #endregion

    }

}
