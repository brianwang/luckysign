using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;

namespace AppMod.User
{
    [Serializable]
    public class USR_GradeMod : IComparable<USR_GradeMod>
    {
        public USR_GradeMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private string _Name;
        private int _LevelNum;
        private int _Exp;
        private int _DR;
        private DateTime _TS;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        public int LevelNum
        {
            set { _LevelNum = value; }
            get { return _LevelNum; }
        }

        public int Exp
        {
            set { _Exp = value; }
            get { return _Exp; }
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
            Name = AppConst.StringNull;
            LevelNum = AppConst.IntNull;
            Exp = AppConst.IntNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(USR_GradeMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
