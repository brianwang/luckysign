using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.Apps
{
    [DataContract]
    public class TopicSendRecordMod : IComparable<TopicSendRecordMod>
    {
        public TopicSendRecordMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _UserSysNo;
        private int _TopicSysNo;
        private int _IsReturn;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int UserSysNo
        {
            set { _UserSysNo = value; }
            get { return _UserSysNo; }
        }

        public int TopicSysNo
        {
            set { _TopicSysNo = value; }
            get { return _TopicSysNo; }
        }

        public int IsReturn
        {
            set { _IsReturn = value; }
            get { return _IsReturn; }
        }

        public DateTime TS
        {
            set { _TS = value; }
            get { return _TS; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            UserSysNo = AppConst.IntNull;
            TopicSysNo = AppConst.IntNull;
            IsReturn = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(TopicSendRecordMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
