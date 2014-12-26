using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.Apps
{
    [DataContract]
    public class AdvTopicMod : IComparable<AdvTopicMod>
    {
        public AdvTopicMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Title;
        private int _Group;
        private int _DR;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        public int Group
        {
            set { _Group = value; }
            get { return _Group; }
        }

        public int DR
        {
            set { _DR = value; }
            get { return _DR; }
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
            Title = AppConst.StringNull;
            Group = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(AdvTopicMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
