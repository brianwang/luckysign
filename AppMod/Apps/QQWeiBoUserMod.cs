using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.Apps
{
    [DataContract]
    [Serializable]
    public class QQWeiBoUserMod : IComparable<QQWeiBoUserMod>
    {
        public QQWeiBoUserMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _OpenId;
        private string _WB_Name;
        private string _WB_Nick;
        private string _Oauth2Token;
        private DateTime _Expire;
        private DateTime _TS;
        private string _Location;
        private int _FansNum;
        private int _IsVIP;
        private string _OpenId1;
        private string _Oauth2Token1;
        private DateTime _Expire1;
        private int _CustomerSysNo;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string OpenId
        {
            set { _OpenId = value; }
            get { return _OpenId; }
        }

        public string WB_Name
        {
            set { _WB_Name = value; }
            get { return _WB_Name; }
        }

        public string WB_Nick
        {
            set { _WB_Nick = value; }
            get { return _WB_Nick; }
        }

        public string Oauth2Token
        {
            set { _Oauth2Token = value; }
            get { return _Oauth2Token; }
        }

        public DateTime Expire
        {
            set { _Expire = value; }
            get { return _Expire; }
        }

        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }

        public string Location
        {
            set { _Location = value; }
            get { return _Location; }
        }

        public int FansNum
        {
            set { _FansNum = value; }
            get { return _FansNum; }
        }

        public int IsVIP
        {
            set { _IsVIP = value; }
            get { return _IsVIP; }
        }

        public string OpenId1
        {
            set { _OpenId1 = value; }
            get { return _OpenId1; }
        }

        public string Oauth2Token1
        {
            set { _Oauth2Token1 = value; }
            get { return _Oauth2Token1; }
        }

        public DateTime Expire1
        {
            set { _Expire1 = value; }
            get { return _Expire1; }
        }

        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            OpenId = AppConst.StringNull;
            WB_Name = AppConst.StringNull;
            WB_Nick = AppConst.StringNull;
            Oauth2Token = AppConst.StringNull;
            Expire = AppConst.DateTimeNull;
            TS = AppConst.DateTimeNull;
            Location = AppConst.StringNull;
            FansNum = AppConst.IntNull;
            IsVIP = AppConst.IntNull;
            OpenId1 = AppConst.StringNull;
            Oauth2Token1 = AppConst.StringNull;
            Expire1 = AppConst.DateTimeNull;
            CustomerSysNo = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(QQWeiBoUserMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
