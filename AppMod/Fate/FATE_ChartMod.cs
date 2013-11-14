using System;
using System.Collections.Generic;
using AppCmn;
using System.Text;

namespace AppMod.Fate
{
    [Serializable]
    public class FATE_ChartMod : IComparable<FATE_ChartMod>
    {
        public FATE_ChartMod()
        {
            Init();
        }

        #region 成员变量和公共属性
        private int _SysNo;
        private DateTime _FirstBirth;
        private string _FirstPoi;
        private DateTime _Transit;
        private string _TransitPoi;
        private DateTime _SecondBirth;
        private string _SecondPoi;
        private int _CharType;
        private int _TheoryType;
        private string _Bitvalue;
        private int _DR;
        private DateTime _TS;
        private int _FirstDayLight;
        private int _SecondDayLight;
        private string _FirstPoiName;
        private string _SecondPoiName;
        private int _FirstTimeZone;
        private int _SecondTimeZone;
        private int _FirstGender;
        private int _SecondGender;

        public int SysNo
        {
            set { _SysNo = value; }
            get { return _SysNo; }
        }

        public DateTime FirstBirth
        {
            set { _FirstBirth = value; }
            get { return _FirstBirth; }
        }

        public string FirstPoi
        {
            set { _FirstPoi = value; }
            get { return _FirstPoi; }
        }

        public DateTime Transit
        {
            set { _Transit = value; }
            get { return _Transit; }
        }

        public string TransitPoi
        {
            set { _TransitPoi = value; }
            get { return _TransitPoi; }
        }

        public DateTime SecondBirth
        {
            set { _SecondBirth = value; }
            get { return _SecondBirth; }
        }

        public string SecondPoi
        {
            set { _SecondPoi = value; }
            get { return _SecondPoi; }
        }

        public int CharType
        {
            set { _CharType = value; }
            get { return _CharType; }
        }

        public int TheoryType
        {
            set { _TheoryType = value; }
            get { return _TheoryType; }
        }

        public string Bitvalue
        {
            set { _Bitvalue = value; }
            get { return _Bitvalue; }
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

        public int FirstDayLight
        {
            set { _FirstDayLight = value; }
            get { return _FirstDayLight; }
        }

        public int SecondDayLight
        {
            set { _SecondDayLight = value; }
            get { return _SecondDayLight; }
        }

        public string FirstPoiName
        {
            set { _FirstPoiName = value; }
            get { return _FirstPoiName; }
        }

        public string SecondPoiName
        {
            set { _SecondPoiName = value; }
            get { return _SecondPoiName; }
        }

        public int FirstTimeZone
        {
            set { _FirstTimeZone = value; }
            get { return _FirstTimeZone; }
        }

        public int SecondTimeZone
        {
            set { _SecondTimeZone = value; }
            get { return _SecondTimeZone; }
        }

        public int FirstGender
        {
            set { _FirstGender = value; }
            get { return _FirstGender; }
        }

        public int SecondGender
        {
            set { _SecondGender = value; }
            get { return _SecondGender; }
        }


        #endregion

        public void Init()
        {
            SysNo = AppConst.IntNull;
            FirstBirth = AppConst.DateTimeNull;
            FirstPoi = AppConst.StringNull;
            Transit = AppConst.DateTimeNull;
            TransitPoi = AppConst.StringNull;
            SecondBirth = AppConst.DateTimeNull;
            SecondPoi = AppConst.StringNull;
            CharType = AppConst.IntNull;
            TheoryType = AppConst.IntNull;
            Bitvalue = AppConst.StringNull;
            DR = AppConst.IntNull;
            TS = AppConst.DateTimeNull;
            FirstDayLight = AppConst.IntNull;
            SecondDayLight = AppConst.IntNull;
            FirstPoiName = AppConst.StringNull;
            SecondPoiName = AppConst.StringNull;
            FirstTimeZone = AppConst.IntNull;
            SecondTimeZone = AppConst.IntNull;
            FirstGender = AppConst.IntNull;
            SecondGender = AppConst.IntNull;

        }

        #region 实现IComparable<T>接口的泛型排序方法
        /// <sumary> 
        /// 根据SysNo字段实现的IComparable<T>接口的泛型排序方法 
        /// </sumary> 
        /// <param name="other"></param> 
        /// <returns></returns> 
        public int CompareTo(FATE_ChartMod other)
        {
            return SysNo.CompareTo(other.SysNo);
        }
        #endregion

    }


}
