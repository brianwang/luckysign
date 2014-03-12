using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPLive;
using System.Runtime.Serialization;

namespace PPLive.BaZi
{
    [DataContract]
    public class BaZiMod
    {
        public BaZiMod()
        { }
        #region 私有变量
        private PublicValue.TianGan yearTG = new PublicValue.TianGan();
        private PublicValue.DiZhi yearDZ = new PublicValue.DiZhi();

        private PublicValue.TianGan monthTG = new PublicValue.TianGan();
        private PublicValue.DiZhi monthDZ = new PublicValue.DiZhi();

        private PublicValue.TianGan dayTG = new PublicValue.TianGan();
        private PublicValue.DiZhi dayDZ = new PublicValue.DiZhi();

        private PublicValue.TianGan hourTG = new PublicValue.TianGan();
        private PublicValue.DiZhi hourDZ = new PublicValue.DiZhi();

        private DateEntity birthTime = new DateEntity();
        private AppCmn.AppEnum.Gender gender = new AppCmn.AppEnum.Gender();
        private PublicValue.ShuXing yinyang = new PublicValue.ShuXing();//根据年干判断的阴阳

        private PublicValue.DiZhi[] xunkong = new PublicValue.DiZhi[2];

        private string name = "";
        private bool realtime = false;
        private int areaSysno = 0;
        private string areaname = "";
        private string longitude = "";
        private TimeSpan realtimespan = new TimeSpan();

        private BaZiDaYun[] dayun = new BaZiDaYun[10];
        private DateTime jiaoyun = new DateTime();//交运时间
        private TimeSpan qiyun = new TimeSpan();//起运时距离出生的时间差

        private PublicValue.TianGan[,] canggan = new PublicValue.TianGan[4, 3];//藏干，俺天干顺序从大到小排，后为空则填甲
        private PublicValue.Nayin[] nayin = new PublicValue.Nayin[4];
        private PublicValue.ZiWeiChangSheng[] wangshuai = new PublicValue.ZiWeiChangSheng[4];

        private DateTime[] jieqi = new DateTime[2];//相邻节气
        private PublicValue.AllJieQi[] jieqiname = new PublicValue.AllJieQi[2];//相邻节气名
        #endregion

        #region 属性
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public PublicValue.TianGan YearTG
        {
            get { return yearTG; }
            set { yearTG = value; }
        }
        
        public PublicValue.DiZhi YearDZ
        {
            get { return yearDZ; }
            set { yearDZ = value; }
        }
        
        public PublicValue.TianGan MonthTG
        {
            get { return monthTG; }
            set { monthTG = value; }
        }
        
        public PublicValue.DiZhi MonthDZ
        {
            get { return monthDZ; }
            set { monthDZ = value; }
        }
        
        public PublicValue.TianGan DayTG
        {
            get { return dayTG; }
            set { dayTG = value; }
        }
        
        public PublicValue.DiZhi DayDZ
        {
            get { return dayDZ; }
            set { dayDZ = value; }
        }
        
        public PublicValue.TianGan HourTG
        {
            get { return hourTG; }
            set { hourTG = value; }
        }
        
        public PublicValue.DiZhi HourDZ
        {
            get { return hourDZ; }
            set { hourDZ = value; }
        }
        
        public DateEntity BirthTime
        {
            get { return birthTime; }
            set { birthTime = value; }
        }
        
        public PublicValue.DiZhi XunKong0
        {
            get { return xunkong[0]; }
            set { xunkong[0] = value; }
        }
        
        public PublicValue.DiZhi XunKong1
        {
            get { return xunkong[1]; }
            set { xunkong[1] = value; }
        }
        
        public PublicValue.ShuXing YinYang
        {
            get { return yinyang; }
            set { yinyang = value; }
        }
        
        public AppCmn.AppEnum.Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        
        public BaZiDaYun[] Dayun
        {
            get { return dayun; }
            set { dayun = value; }
        }
        
        public DateTime JiaoYun
        {
            get { return jiaoyun; }
            set { jiaoyun = value; }
        }
        public TimeSpan QiYun
        {
            get { return qiyun; }
            set { qiyun = value; }
        }
        
        public PublicValue.TianGan[,] CangGan
        {
            get { return canggan; }
            set { canggan = value; }
        }
        
        public PublicValue.Nayin[] NaYin
        {
            get { return nayin; }
            set { nayin = value; }
        }
        
        public PublicValue.ZiWeiChangSheng[] WangShuai
        {
            get { return wangshuai; }
            set { wangshuai = value; }
        }
        
        public DateTime[] JieQi
        {
            get { return jieqi; }
            set { jieqi = value; }
        }
        
        public PublicValue.AllJieQi[] JieQiName
        {
            get { return jieqiname; }
            set { jieqiname = value; }
        }
        
        public bool RealTime
        {
            get { return realtime; }
            set { realtime = value; }
        }
        
        public int AreaSysNo
        {
            get { return areaSysno; }
            set { areaSysno = value; }
        }
        
        public string AreaName
        {
            get { return areaname; }
            set { areaname = value; }
        }
        
        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        
        public TimeSpan RealTimeSpan
        {
            get { return realtimespan; }
            set { realtimespan = value; }
        }
        #endregion


    }


    [DataContract]
    public class BaZiDaYun
    {
        public BaZiDaYun()
        { }
        #region 私有变量
        private PublicValue.TianGan yearTG = new PublicValue.TianGan();
        private PublicValue.DiZhi yearDZ = new PublicValue.DiZhi();

        private PublicValue.ShiShen shishen = new PublicValue.ShiShen();
        private int begin = 0;
        private int end = 0;
        private PublicValue.ZiWeiChangSheng wangshuai = new PublicValue.ZiWeiChangSheng();
        private PublicValue.Nayin nayin = new PublicValue.Nayin();
        #endregion

        #region 属性
        [DataMember]
        public PublicValue.TianGan YearTG
        {
            get { return yearTG; }
            set { yearTG = value; }
        }
        [DataMember]
        public PublicValue.DiZhi YearDZ
        {
            get { return yearDZ; }
            set { yearDZ = value; }
        }
        [DataMember]
        public PublicValue.ShiShen ShiShen
        {
            get { return shishen; }
            set { shishen = value; }
        }
        [DataMember]
        public int Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        [DataMember]
        public int End
        {
            get { return end; }
            set { end = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiChangSheng WangShuai
        {
            get { return wangshuai; }
            set { wangshuai = value; }
        }
        [DataMember]
        public PublicValue.Nayin NaYin
        {
            get { return nayin; }
            set { nayin = value; }
        }
        #endregion
    }
}
