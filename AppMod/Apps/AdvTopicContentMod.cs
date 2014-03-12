using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.Apps
{
    [DataContract]
    public class AdvTopicContentMod : IComparable<AdvTopicContentMod>
    {
        public AdvTopicContentMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _TopicSysNo;
        private string _Title;
        private string _Content;
        private int _DR;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int TopicSysNo
        {
            set { _TopicSysNo = value; }
            get { return _TopicSysNo; }
        }

        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
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
            TopicSysNo = AppConst.IntNull;
            Title = AppConst.StringNull;
            Content = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(AdvTopicContentMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
