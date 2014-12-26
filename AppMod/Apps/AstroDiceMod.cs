using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using System.Runtime.Serialization;
namespace AppMod.Apps
{
    [DataContract]
    public class AstroDiceMod : IComparable<AstroDiceMod>
    {
        public AstroDiceMod ()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Question;
        private int _Constellation;
        private int _House;
        private int _Star;
        private DateTime _TS;
        private string _Pic;
        private int _UserSysNo;
        private int _Source;

        public int SysNo
        {
            set{ _SysNo = value; }
            get{ return _SysNo; }
        }

        public string Question
        {
            set{ _Question = value; }
            get{ return _Question; }
        }

        public int Constellation
        {
            set{ _Constellation = value; }
            get{ return _Constellation; }
        }

        public int House
        {
            set{ _House = value; }
            get{ return _House; }
        }

        public int Star
        {
            set{ _Star = value; }
            get{ return _Star; }
        }

        public DateTime TS
        {
            set{ _TS = value; }
            get{ return _TS; }
        }

        public string Pic
        {
            set{ _Pic = value; }
            get{ return _Pic; }
        }

        public int UserSysNo
        {
            set{ _UserSysNo = value; }
            get{ return _UserSysNo; }
        }

        public int Source
        {
            set{ _Source = value; }
            get{ return _Source; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            Question = AppConst.StringNull;
            Constellation = AppConst.IntNull;
            House = AppConst.IntNull;
            Star = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            Pic = AppConst.StringNull;
            UserSysNo = AppConst.IntNull;
            Source = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(AstroDiceMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }
}
