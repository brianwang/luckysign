﻿using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;
using System.Runtime.Serialization;

namespace AppMod.User
{
    [DataContract]
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
        private DateTime _Birth;
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
        private int _SetOrderCount;
        private int _BuyOrderCount;
        private int _SellOrderCount;
        private decimal _TotalSellRMB;
        private decimal _TotalBuyRMB;
        private int _TotalBuyPoint;

        [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        [DataMember]
        public string Email
        {
            set { _Email = value; }
            get { return _Email; }
        }

        [DataMember]
        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
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

        [DataMember]
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

        [DataMember]
        public DateTime Birth
        {
            set { _Birth = value; }
            get { return _Birth; }
        }

        [DataMember]
        public int FateType
        {
            set { _FateType = value; }
            get { return _FateType; }
        }

        [DataMember]
        public DateTime RegTime
        {
            set { _RegTime = value; }
            get { return _RegTime; }
        }

        [DataMember]
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

        [DataMember]
        public string Signature
        {
            set { _Signature = value; }
            get { return _Signature; }
        }

        [DataMember]
        public int Exp
        {
            set { _Exp = value; }
            get { return _Exp; }
        }

        [DataMember]
        public int TotalAnswer
        {
            set { _TotalAnswer = value; }
            get { return _TotalAnswer; }
        }

        [DataMember]
        public int TotalQuest
        {
            set { _TotalQuest = value; }
            get { return _TotalQuest; }
        }

        [DataMember]
        public int BestAnswer
        {
            set { _BestAnswer = value; }
            get { return _BestAnswer; }
        }

        [DataMember]
        public int HomeTown
        {
            set { _HomeTown = value; }
            get { return _HomeTown; }
        }

        [DataMember]
        public string Intro
        {
            set { _Intro = value; }
            get { return _Intro; }
        }

        [DataMember]
        public string Icons
        {
            set { _Icons = value; }
            get { return _Icons; }
        }

        [DataMember]
        public int IsShowBirth
        {
            set { _IsShowBirth = value; }
            get { return _IsShowBirth; }
        }

        [DataMember]
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

        [DataMember]
        public int TotalTalk
        {
            set { _TotalTalk = value; }
            get { return _TotalTalk; }
        }

        [DataMember]
        public int TotalTalkReply
        {
            set { _TotalTalkReply = value; }
            get { return _TotalTalkReply; }
        }

        [DataMember]
        public string Phone
        {
            set { _Phone = value; }
            get { return _Phone; }
        }

        [DataMember]
        public int SetOrderCount
        {
            set { _SetOrderCount = value; }
            get { return _SetOrderCount; }
        }

        [DataMember]
        public int BuyOrderCount
        {
            set { _BuyOrderCount = value; }
            get { return _BuyOrderCount; }
        }

        [DataMember]
        public int SellOrderCount
        {
            set { _SellOrderCount = value; }
            get { return _SellOrderCount; }
        }

        [DataMember]
        public decimal TotalSellRMB
        {
            set { _TotalSellRMB = value; }
            get { return _TotalSellRMB; }
        }

        [DataMember]
        public decimal TotalBuyRMB
        {
            set { _TotalBuyRMB = value; }
            get { return _TotalBuyRMB; }
        }

        [DataMember]
        public int TotalBuyPoint
        {
            set { _TotalBuyPoint = value; }
            get { return _TotalBuyPoint; }
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
            Birth = AppConst.DateTimeNull;
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
            Phone = AppConst.StringNull;
            SetOrderCount = AppConst.IntNull;
            BuyOrderCount = AppConst.IntNull;
            SellOrderCount = AppConst.IntNull;
            TotalSellRMB = AppConst.DecimalNull;
            TotalBuyRMB = AppConst.DecimalNull;
            TotalBuyPoint = AppConst.IntNull;

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

