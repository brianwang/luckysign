using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.User
{
    [DataContract]
    public class USR_ThirdLoginMod : IComparable<USR_ThirdLoginMod>
    {
        public USR_ThirdLoginMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _CustomerSysNo;
        private string _OpenID;
        private string _AccessKey;
        private DateTime _ExpireTime;
        private int _ThirdType;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int CustomerSysNo
        {
            set { _CustomerSysNo = value; }
            get { return _CustomerSysNo; }
        }

        public string OpenID
        {
            set { _OpenID = value; }
            get { return _OpenID; }
        }

        public string AccessKey
        {
            set { _AccessKey = value; }
            get { return _AccessKey; }
        }

        public DateTime ExpireTime
        {
            set { _ExpireTime = value; }
            get { return _ExpireTime; }
        }

        public int ThirdType
        {
            set { _ThirdType = value; }
            get { return _ThirdType; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            CustomerSysNo = AppConst.IntNull;
            OpenID = AppConst.StringNull;
            AccessKey = AppConst.StringNull;
            ExpireTime = AppConst.DateTimeNull;
            ThirdType = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_ThirdLoginMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }


}
