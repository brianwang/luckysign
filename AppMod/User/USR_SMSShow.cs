using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
using System.Web;

namespace AppMod.User
{
    [DataContract]
    public class USR_SMSShow : IComparable<USR_SMSMod>
    {
        public USR_SMSShow()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _FromSysNo;
        private int _ToSysNo;
        private string _Title;
        private string _Context;
        private int _IsRead;
        private int _IsFromDeleted;
        private int _IsToDeleted;
        private int _Parent;
        private int _DR;
        private DateTime _TS;
        private int _ReplyCount;
         [DataMember]
        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }
         [DataMember]
        public int FromSysNo
        {
            set { _FromSysNo = value; }
            get { return _FromSysNo; }
        }
         [DataMember]
        public int ToSysNo
        {
            set { _ToSysNo = value; }
            get { return _ToSysNo; }
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
        public int IsRead
        {
            set { _IsRead = value; }
            get { return _IsRead; }
        }
         [DataMember]
        public int IsFromDeleted
        {
            set { _IsFromDeleted = value; }
            get { return _IsFromDeleted; }
        }
         [DataMember]
        public int IsToDeleted
        {
            set { _IsToDeleted = value; }
            get { return _IsToDeleted; }
        }

        public int Parent
        {
            set { _Parent = value; }
            get { return _Parent; }
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
         [DataMember]
        public int ReplyCount
        {
            set { _ReplyCount = value; }
            get { return _ReplyCount; }
        }


        #endregion

         #region 扩展成员变量

         private string _FromPhoto;
         public string FromPhoto
         {
             get { return _FromPhoto; }
             set { _FromPhoto = value; }
         }
         private string _FromName;
         [DataMember]
         public string FromName
         {
             get { return _FromName; }
             set { _FromName = value; }
         }
         private string _ToPhoto;
         public string ToPhoto
         {
             get { return _ToPhoto; }
             set { _ToPhoto = value; }
         }
         private string _ToName;
         [DataMember]
         public string ToName
         {
             get { return _ToName; }
             set { _ToName = value; }
         }

         //[DataMember]
         //public string BigPhotoShow
         //{
         //    get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=t&id=" + HttpUtility.UrlEncode(CustomerPhoto); }
         //    set { }
         //}

         [DataMember]
         public string smallFromPhotoShow
         {
             get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=o&id=" + HttpUtility.UrlEncode(FromPhoto); }
             set { }
         }
         [DataMember]
         public string smallToPhotoShow
         {
             get { return AppConfig.HomeUrl() + "ControlLibrary/ShowPhoto.aspx?type=o&id=" + HttpUtility.UrlEncode(ToPhoto); }
             set { }
         }

         #endregion

         public void Init()
         {
             SysNo = AppConst.IntNull;
             FromSysNo = AppConst.IntNull;
             ToSysNo = AppConst.IntNull;
             Title = AppConst.StringNull;
             Context = AppConst.StringNull;
             IsRead = AppConst.IntNull;
             IsFromDeleted = AppConst.IntNull;
             IsToDeleted = AppConst.IntNull;
             Parent = AppConst.IntNull;
             DR = AppConst.IntNull;
             TS = AppConst.DateTimeNull;
             ReplyCount = AppConst.IntNull;
             FromName = AppConst.StringNull;
             ToName = AppConst.StringNull;
             FromPhoto = AppConst.StringNull;
             ToPhoto = AppConst.StringNull;
         }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_SMSMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion

    }

}
