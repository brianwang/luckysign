using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;

namespace AppMod.WebSys
{
    [Serializable]
    public class SYS_Famous_AstroStarMod : IComparable<SYS_Famous_AstroStarMod>
    {
        public SYS_Famous_AstroStarMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private int _FamousSysNo;
        private int _Star;
        private int _Gong;
        private int _Degree;
        private decimal _Cent;
        private int _Constellation;
        private decimal _Progress;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public int FamousSysNo
        {
            set { _FamousSysNo = value; }
            get { return _FamousSysNo; }
        }

        public int Star
        {
            set { _Star = value; }
            get { return _Star; }
        }

        public int Gong
        {
            set { _Gong = value; }
            get { return _Gong; }
        }

        public int Degree
        {
            set { _Degree = value; }
            get { return _Degree; }
        }

        public decimal Cent
        {
            set { _Cent = value; }
            get { return _Cent; }
        }

        public int Constellation
        {
            set { _Constellation = value; }
            get { return _Constellation; }
        }

        public decimal Progress
        {
            set { _Progress = value; }
            get { return _Progress; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            FamousSysNo = AppConst.IntNull;
            Star = AppConst.IntNull;
            Gong = AppConst.IntNull;
            Degree = AppConst.IntNull;
            Cent = AppConst.DecimalNull;
            Constellation = AppConst.IntNull;
            Progress = AppConst.DecimalNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(SYS_Famous_AstroStarMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion
    }

}
