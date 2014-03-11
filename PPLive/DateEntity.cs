using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PPLive
{
    /// <summary>
    /// 综合时间实体，包括公历时间，农历日期，农历润年月信息，干支等
    /// </summary>
    [DataContract]
    [KnownType(typeof(PublicValue.TianGan))]
    [KnownType(typeof(PublicValue.DiZhi))]
    [KnownType(typeof(PublicValue.NongliMonth))]
    [KnownType(typeof(PublicValue.NongliDay))]
    public class DateEntity
    {
        public DateEntity()
        { }
        public DateEntity(DateTime date)
        {
            this.Date = date;
        }
        
        #region 私有变量
        DateTime _date = new DateTime();
        DateTime[] _BeginMonth = new DateTime[12];
        DateTime[] _BeginZodiac = new DateTime[12];

        PublicValue.TianGan nongliTG = new PublicValue.TianGan();
        PublicValue.DiZhi nongliDZ = new PublicValue.DiZhi();
        bool nongliyearflag = false;//true表示农历年未过
        PublicValue.Nayin yearNayin = new PublicValue.Nayin();
        PublicValue.NongliMonth nonglimonth = new PublicValue.NongliMonth();
        PublicValue.NongliDay nongliday = new PublicValue.NongliDay();
        PublicValue.DiZhi nonglihour = new PublicValue.DiZhi();
        int nonglimonthdays = 0;//当前农历月总天数
        #endregion

        #region 属性
        [DataMember]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; Initial(); }
        }
        [DataMember]
        public DateTime[] BeginMonth
        {
            get { return _BeginMonth; }
            set { _BeginMonth = value;  }
        }
        [DataMember]
        public DateTime[] BeginZodiac
        {
            get { return _BeginZodiac; }
            set { _BeginZodiac = value; }
        }
        [DataMember]
        public PublicValue.TianGan NongliTG
        {
            get { return nongliTG; }
            set { nongliTG = value; }
        }
        [DataMember]
        public PublicValue.DiZhi NongliDZ
        {
            get { return nongliDZ; }
            set { nongliDZ = value; }
        }
        [DataMember]
        public PublicValue.NongliMonth NongliMonth
        {
            get { return nonglimonth; }
            set { nonglimonth = value; }
        }
        [DataMember]
        public PublicValue.NongliDay NongliDay
        {
            get { return nongliday; }
            set { nongliday = value; }
        }
        [DataMember]
        public PublicValue.DiZhi NongliHour
        {
            get { return nonglihour; }
            set { nonglihour = value; }
        }
        [DataMember]
        public bool NongliYearFlag
        {
            get { return nongliyearflag; }
            set { nongliyearflag = value; }
        }
        [DataMember]
        public int NongliMonthDays
        {
            get { return nonglimonthdays; }
            set { nonglimonthdays = value; }
        }
        #endregion

        public void Initial()
        {
            MyCalendar m_c = new MyCalendar();
            DateEntity tmp = new DateEntity();
            tmp._date = this._date;
            m_c.SetDateEntity(ref tmp);
            this._BeginMonth = tmp._BeginMonth;
            this._BeginZodiac = tmp._BeginZodiac;
            this.nonglimonth = tmp.nonglimonth;
            this.nongliday = tmp.nongliday;
            this.nonglihour = tmp.nonglihour;
            this.nongliyearflag = tmp.nongliyearflag;
            this.NongliMonthDays = tmp.NongliMonthDays;
            if (nongliyearflag)
            {
                BaZi.BaZiBiz m_bz = PPLive.BaZi.BaZiBiz.GetInstance();
                this.nongliTG = m_bz.YearTG(_date.Year - 1);
                this.nongliDZ = m_bz.YearDZ(_date.Year - 1);
            }
            else
            {
                BaZi.BaZiBiz m_bz = PPLive.BaZi.BaZiBiz.GetInstance();
                this.nongliTG = m_bz.YearTG(_date.Year);
                this.nongliDZ = m_bz.YearDZ(_date.Year);
            }
        }
    }
}
