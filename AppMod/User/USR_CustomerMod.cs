using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.User
{
    [Serializable]
    public class USR_CustomerMod : IComparable<USR_CustomerMod>
    {
        public USR_CustomerMod()
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

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string Email
        {
            set { _Email = value; }
            get { return _Email; }
        }

        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }

        public int GradeSysNo
        {
            set { _GradeSysNo = value; }
            get { return _GradeSysNo; }
        }

        public string NickName
        {
            set { _NickName = value; }
            get { return _NickName; }
        }

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

        public int Credit
        {
            set { _Credit = value; }
            get { return _Credit; }
        }

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

        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

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

        public string Icons
        {
            set { _Icons = value; }
            get { return _Icons; }
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
            Email = AppConst.StringNull;
            Password = AppConst.StringNull;
            GradeSysNo = AppConst.IntNull;
            NickName = AppConst.StringNull;
            Gender = AppConst.IntNull;
            Photo = AppConst.StringNull;
            Credit = AppConst.IntNull;
            Point = AppConst.IntNull;
            birth = AppConst.DateTimeNull;
            FateType = AppConst.IntNull;
            RegTime = AppConst.DateTimeNull;
            LastLoginTime = AppConst.DateTimeNull;
            Status = AppConst.IntNull;
            IsStar = AppConst.IntNull;
            Signature = AppConst.StringNull;
            Exp = AppConst.IntNull;
            TotalAnswer = AppConst.IntNull;
            TotalQuest = AppConst.IntNull;
            BestAnswer = AppConst.IntNull;
            HomeTown = AppConst.IntNull;
            Intro = AppConst.StringNull;
            Icons = AppConst.StringNull;
            IsShowBirth = AppConst.IntNull;
            TotalReply = AppConst.IntNull;
            HasNewInfo = AppConst.IntNull;
            TotalTalk = AppConst.IntNull;
            TotalTalkReply = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_CustomerMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion

    }

}
