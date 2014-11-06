using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPLive;

namespace PPLive.BaZi
{
    /// <summary>
    /// PublicDeal 的摘要说明
    /// </summary>
    public class BaZiBiz
    {
        private BaZiBiz()
        {
        }
        private static BaZiBiz _instance;
        public static BaZiBiz GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BaZiBiz();
            }
            return _instance;
        }

        #region 细节算法

        public PublicValue.TianGan YearTG(int year)
        {
            int temp = (year + 6) % 10;
            PublicValue.TianGan ret = new PublicValue.TianGan();
            ret = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), (temp).ToString());
            
            return ret;
        }

        public PublicValue.DiZhi YearDZ(int year)
        {
            int temp = (year + 8) % 12;
            PublicValue.DiZhi ret = new PublicValue.DiZhi();
            ret = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), (temp).ToString());
            
            return ret;
        }

        private PublicValue.TianGan MonthTG(int year, int mon)
        {
            int temp = (year * 12 + mon+2) % 10 ;
            PublicValue.TianGan ret = new PublicValue.TianGan();
            ret = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), (temp).ToString());
            
            return ret;
        }

        private PublicValue.DiZhi MonthDZ(int mon)
        {
            PublicValue.DiZhi ret = new PublicValue.DiZhi();
            ret = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), (mon%12).ToString());
            switch (mon)
            {
                case 12:
                    ret = PublicValue.DiZhi.zi;
                    break;
                case 1:
                    ret = PublicValue.DiZhi.chou;
                    break;
                case 2:
                    ret = PublicValue.DiZhi.yin;
                    break;
                case 3:
                    ret = PublicValue.DiZhi.mao;
                    break;
                case 4:
                    ret = PublicValue.DiZhi.chen;
                    break;
                case 5:
                    ret = PublicValue.DiZhi.si;
                    break;
                case 6:
                    ret = PublicValue.DiZhi.wu;
                    break;
                case 7:
                    ret = PublicValue.DiZhi.wei;
                    break;
                case 8:
                    ret = PublicValue.DiZhi.shen;
                    break;
                case 9:
                    ret = PublicValue.DiZhi.you;
                    break;
                case 10:
                    ret = PublicValue.DiZhi.xu;
                    break;
                case 11:
                    ret = PublicValue.DiZhi.hai;
                    break;
            }
            return ret;
        }

        private PublicValue.TianGan DayTG(int year, int mon, int day)
        {
            int c = year / 100;
            int y = year % 100;
            if (mon <= 2)
            {
                mon = mon + 12;
                y = y - 1;
            }
            int tmp = 4 * c + (c / 4) + 5 * y + (y / 4) + (3 * (mon + 1) / 5) + day - 4;

            PublicValue.TianGan ret = new PublicValue.TianGan();
            ret = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), (tmp%10).ToString());
            
            return ret;
        }

        private PublicValue.DiZhi DayDZ(int year, int mon, int day)
        {
            int c = year / 100;
            int y = year % 100;
            int i = 0;
            if (mon <= 2)
            {
                mon = mon + 12;
                y = y - 1;
            }
            if (mon % 2 == 0)
            {
                i = 6;
            }
            int tmp = 8 * c + (c / 4) + 5 * y + (y / 4) + (3 * (mon + 1) / 5) + day +i + 6;

            PublicValue.DiZhi ret = new PublicValue.DiZhi();
            ret = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), (tmp % 12).ToString());
           
            return ret;
        }

        private PublicValue.TianGan HourTG(PublicValue.TianGan dayTG, int hour)
        {
            if (hour == 23)
            {
                hour = 0;
            }
            int flag = ((int)dayTG) % 5 * 2;
            PublicValue.TianGan ret;
            ret = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), ((flag+(hour+1)/2)%10).ToString());
            
            return ret;
        }

        private PublicValue.DiZhi HourDZ(int hour)
        {
            PublicValue.DiZhi ret = new PublicValue.DiZhi();
            ret = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), ((hour + 1) / 2%12).ToString());
            
            return ret;
        }

        public PublicValue.TianGan MinuteTG(PublicValue.TianGan hourTG, int minute)
        {
            int flag = ((int)hourTG) % 5*2;
            PublicValue.TianGan ret;
            ret = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), ((flag + minute / 10) % 10).ToString());

            return ret;
        }

        public PublicValue.DiZhi MinuteDZ(int minute)
        {
            PublicValue.DiZhi ret = new PublicValue.DiZhi();
            ret = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), (minute/10).ToString());

            return ret;
        }

        private int CheckMon(DateEntity DateEntity)
        {
            int mon = DateEntity.Date.Month;
            if (DateEntity.Date < DateEntity.BeginMonth[mon - 1])
            {
                mon--;
            }
            if (mon == 0)
            {
                mon = 12;
            }
            return mon;
        }

        private int CheckYear(DateEntity DateEntity)
        {
            int year = DateEntity.Date.Year;
            if (DateEntity.Date < DateEntity.BeginMonth[1])
            {
                year--;
            }
            return year;
        }

        /// <summary>
        /// 设置旬空
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mon"></param>
        /// <param name="day"></param>
        /// <param name="BaZi"></param>
        private void XunKongDay(ref BaZiMod bazi)
        {
            int temp = 0;
            temp = (9 - (int)bazi.DayTG + (int)bazi.DayDZ+1) % 12;

            bazi.XunKong0 = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), temp.ToString());
            bazi.XunKong1 = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), (temp+1).ToString());
        }

        /// <summary>
        /// 年干阴阳
        /// </summary>
        /// <param name="bazi"></param>
        private void SetYinYang(ref BaZiMod bazi)
        {
            if ((int)bazi.YearTG % 2 == 0)
            {
                bazi.YinYang = PublicValue.ShuXing.yang;
            }
            else
            {
                bazi.YinYang = PublicValue.ShuXing.yin;
            }
        }

        private void SetWangShuai(ref BaZiMod bazi)
        {
            bazi.WangShuai[0] = GetWangShuai(bazi.YearDZ, bazi.DayTG);
            bazi.WangShuai[1] = GetWangShuai(bazi.MonthDZ, bazi.DayTG);
            bazi.WangShuai[2] = GetWangShuai(bazi.DayDZ, bazi.DayTG);
            bazi.WangShuai[3] = GetWangShuai(bazi.HourDZ, bazi.DayTG);
        }

        /// <summary>
        /// 旺衰，十天干生旺死绝
        /// </summary>
        /// <param name="source"></param>
        /// <param name="riyuan"></param>
        /// <returns></returns>
        private PublicValue.ZiWeiChangSheng GetWangShuai(PublicValue.DiZhi source, PublicValue.TianGan riyuan)
        {
            int[] begins = { 11, 6, 2, 9, 2, 9, 5, 0, 8, 3 };
            PublicValue.ZiWeiChangSheng ret = new PublicValue.ZiWeiChangSheng();
            if ((int)riyuan % 2 == 0)//阳干
            {
                int begin = begins[(int)riyuan];
                ret = (PublicValue.ZiWeiChangSheng)(((int)source - begin + 12) % 12);
            }
            else //阴干
            {
                int begin = begins[(int)riyuan];
                ret = (PublicValue.ZiWeiChangSheng)((begin-(int)source + 12) % 12);
            }
            return ret;
        }

        
        private void SetNaYin(ref BaZiMod bazi)
        {
            bazi.NaYin[0] = (PublicValue.Nayin)(10000+(int)bazi.YearTG*100+(int)bazi.YearDZ);
            bazi.NaYin[1] = (PublicValue.Nayin)(10000 + (int)bazi.MonthTG * 100 + (int)bazi.MonthDZ);
            bazi.NaYin[2] = (PublicValue.Nayin)(10000 + (int)bazi.DayTG * 100 + (int)bazi.DayDZ);
            bazi.NaYin[3] = (PublicValue.Nayin)(10000 + (int)bazi.HourTG * 100 + (int)bazi.HourDZ);
        }

        private void SetQiYun(ref BaZiMod bazi)
        {
            DateTime[] jieqi = new DateTime[2];
            PublicValue.JieQi[] jieqiname = new PublicValue.JieQi[2];
            if (bazi.BirthTime.Date < bazi.BirthTime.BeginMonth[0])
            {
                DateEntity tmpdate = new DateEntity(bazi.BirthTime.Date.AddMonths(-3));
                jieqi[0] = tmpdate.BeginMonth[11];
                jieqi[1] = bazi.BirthTime.BeginMonth[0];
                jieqiname[0] = (PublicValue.JieQi)(11);
                jieqiname[1] = (PublicValue.JieQi)(0);
            }
            else if (bazi.BirthTime.Date > bazi.BirthTime.BeginMonth[11])
            {
                DateEntity tmpdate = new DateEntity(bazi.BirthTime.Date.AddMonths(+3));
                jieqi[1] = tmpdate.BeginMonth[0];
                jieqi[0] = bazi.BirthTime.BeginMonth[11];
                jieqiname[0] = (PublicValue.JieQi)(11);
                jieqiname[1] = (PublicValue.JieQi)(0);
            }
            else
            {
                for (int i = 0; i <= 10; i++)
                {
                    if (bazi.BirthTime.Date >= bazi.BirthTime.BeginMonth[i] && bazi.BirthTime.Date <= bazi.BirthTime.BeginMonth[i + 1])
                    {
                        jieqi[0] = bazi.BirthTime.BeginMonth[i];
                        jieqi[1] = bazi.BirthTime.BeginMonth[i + 1];
                        jieqiname[0] = (PublicValue.JieQi)(i);
                        jieqiname[1] = (PublicValue.JieQi)(i + 1);
                        break;
                    }
                }
            }
            //DateTime[] zhongqi = new DateTime[2];
            //PublicValue.ZhongQi[] zhongqiname = new PublicValue.ZhongQi[2];
            //if (bazi.BirthTime.Date < bazi.BirthTime.BeginZodiac[0])
            //{
            //    DateEntity tmpdate = new DateEntity(bazi.BirthTime.Date.AddMonths(-3));
            //    zhongqi[0] = tmpdate.BeginZodiac[11];
            //    zhongqi[1] = bazi.BirthTime.BeginZodiac[0];
            //    zhongqiname[0] = (PublicValue.ZhongQi)(11);
            //    zhongqiname[1] = (PublicValue.ZhongQi)(0);
            //}
            //else if (bazi.BirthTime.Date > bazi.BirthTime.BeginZodiac[11])
            //{
            //    DateEntity tmpdate = new DateEntity(bazi.BirthTime.Date.AddMonths(+3));
            //    zhongqi[1] = tmpdate.BeginZodiac[0];
            //    zhongqi[0] = bazi.BirthTime.BeginZodiac[11];
            //    zhongqiname[0] = (PublicValue.ZhongQi)(11);
            //    zhongqiname[1] = (PublicValue.ZhongQi)(0);
            //}
            //else
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        if (bazi.BirthTime.Date >= bazi.BirthTime.BeginZodiac[i] && bazi.BirthTime.Date <= bazi.BirthTime.BeginZodiac[i + 1])
            //        {
            //            zhongqi[0] = bazi.BirthTime.BeginZodiac[i];
            //            zhongqi[1] = bazi.BirthTime.BeginZodiac[i + 1];
            //            zhongqiname[0] = (PublicValue.ZhongQi)(i);
            //            zhongqiname[1] = (PublicValue.ZhongQi)(i + 1);
            //            break;
            //        }
            //    }
            //}

            bazi.JieQi[0] = jieqi[0];
            bazi.JieQiName[0] = (PublicValue.AllJieQi)((int)jieqiname[0] * 2);
            bazi.JieQi[1] = jieqi[1];
            bazi.JieQiName[1] = (PublicValue.AllJieQi)((int)jieqiname[1] * 2);

            //if (jieqi[0] > zhongqi[0])
            //{
            //    bazi.JieQi[0] = jieqi[0];
            //    bazi.JieQiName[0] = (PublicValue.AllJieQi)((int)jieqiname[0] * 2);
            //}
            //else
            //{
            //    bazi.JieQi[0] = zhongqi[0];
            //    bazi.JieQiName[0] = (PublicValue.AllJieQi)((int)zhongqiname[0] * 2+1);
            //}
            //if (jieqi[1] < zhongqi[1])
            //{
            //    bazi.JieQi[1] = jieqi[1];
            //    bazi.JieQiName[1] = (PublicValue.AllJieQi)((int)jieqiname[1] * 2);
            //}
            //else
            //{
            //    bazi.JieQi[1] = zhongqi[1];
            //    bazi.JieQiName[1] = (PublicValue.AllJieQi)((int)zhongqiname[1] * 2 + 1);
            //}
            
            //TimeSpan tmp = bazi.JieQi[1] - bazi.JieQi[0];//两节气差

            if ((bazi.YinYang == PublicValue.ShuXing.yang && bazi.Gender == AppCmn.AppEnum.Gender.male) ||
                (bazi.YinYang == PublicValue.ShuXing.yin && bazi.Gender == AppCmn.AppEnum.Gender.female))
            {
                TimeSpan tmp1 = new TimeSpan();
                tmp1 = bazi.JieQi[1] - bazi.BirthTime.Date;
                bazi.QiYun = new TimeSpan(Convert.ToInt64(tmp1.Ticks / 3 * 365.25636));
            }
            else
            {
                TimeSpan tmp1 = new TimeSpan();
                tmp1 = bazi.BirthTime.Date - bazi.JieQi[0];
                bazi.QiYun = new TimeSpan(Convert.ToInt64(tmp1.Ticks / 3 * 365.25636));
            }
            bazi.JiaoYun = bazi.BirthTime.Date.Add(bazi.QiYun);
        }

        private void SetDayun(ref BaZiMod bazi)
        {
            for (int i = 0; i < bazi.Dayun.Length; i++)
            {
                bazi.Dayun[i] = new BaZiDaYun();
                if ((bazi.YinYang == PublicValue.ShuXing.yang && bazi.Gender == AppCmn.AppEnum.Gender.male) ||
                    (bazi.YinYang == PublicValue.ShuXing.yin && bazi.Gender == AppCmn.AppEnum.Gender.female))//顺
                {
                    bazi.Dayun[i].YearTG = (PublicValue.TianGan)(((int)bazi.MonthTG + 1 + i) % 10);
                    bazi.Dayun[i].YearDZ = (PublicValue.DiZhi)(((int)bazi.MonthDZ + 1 + i) % 12);
                }
                else//逆
                {
                    bazi.Dayun[i].YearTG = (PublicValue.TianGan)(((int)bazi.MonthTG - 1 - i + 20) % 10);
                    bazi.Dayun[i].YearDZ = (PublicValue.DiZhi)(((int)bazi.MonthDZ - 1 - i + 24) % 12);
                }
                bazi.Dayun[i].Begin = bazi.JiaoYun.Year + 10 * i;
                bazi.Dayun[i].End = bazi.Dayun[i].Begin + 9;
                bazi.Dayun[i].NaYin = (PublicValue.Nayin)(10000+(int)bazi.Dayun[i].YearTG * 100 + bazi.Dayun[i].YearDZ);
                bazi.Dayun[i].WangShuai = GetWangShuai(bazi.Dayun[i].YearDZ, bazi.DayTG);
                bazi.Dayun[i].ShiShen = PublicDeal.GetInstance().GZWuXing(new WuXingRelation(bazi.Dayun[i].YearTG,bazi.DayTG)).ShiShen;
            }
        }

        private void Xiaoyun(ref BaZiMod bazi)
        {

        }

        private void SetCangGan(ref BaZiMod bazi)
        {
            string[] cang = { "9", "975", "024", "1", "149", "624", "35", "153", "468", "7", "734", "08", };

            int tmp = cang[(int)bazi.YearDZ].Length;
            for (int j = 0; j < tmp; j++)
            {
                bazi.CangGan[0, j] = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), cang[(int)bazi.YearDZ].Substring(j, 1));
            }
            tmp = cang[(int)bazi.MonthDZ].Length;
            for (int j = 0; j < tmp; j++)
            {
                bazi.CangGan[1, j] = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), cang[(int)bazi.MonthDZ].Substring(j, 1));
            }
            tmp = cang[(int)bazi.DayDZ].Length;
            for (int j = 0; j < tmp; j++)
            {
                bazi.CangGan[2, j] = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), cang[(int)bazi.DayDZ].Substring(j, 1));
            }
            tmp = cang[(int)bazi.HourDZ].Length;
            for (int j = 0; j < tmp; j++)
            {
                bazi.CangGan[3, j] = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), cang[(int)bazi.HourDZ].Substring(j, 1));
            }
        }
        #endregion

        /// <summary>
        /// 按时间排八字
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mon"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="BaZi"></param>
        public void TimeToBaZi(ref BaZiMod ret)
        {
            DateTime date = ret.BirthTime.Date;
            int year = date.Year;
            int mon = date.Month;
            int day = date.Day;
            int hour = date.Hour;

            int daytemp = day;
            if (hour == 23)
            {
                daytemp++;
            }
            ret.DayTG = DayTG(year, mon, daytemp);
            ret.DayDZ = DayDZ(year, mon, daytemp);
         
            ret.HourTG = HourTG(ret.DayTG, hour);
            ret.HourDZ = HourDZ(hour);

            int montemp = CheckMon(ret.BirthTime);
            int yeartemp = CheckYear(ret.BirthTime);

            ret.MonthTG = MonthTG(yeartemp, montemp);
            ret.MonthDZ = MonthDZ(montemp);

            
            ret.YearTG = YearTG(yeartemp);
            ret.YearDZ = YearDZ(yeartemp);
            XunKongDay(ref ret);
            SetYinYang(ref ret);
            SetNaYin(ref ret);
            SetCangGan(ref ret);
            SetWangShuai(ref ret);
            SetQiYun(ref ret);
            SetDayun(ref ret);

        }

        public string BaziToHTML(BaZiMod bazi,bool all)
        {
            string ret = "";
            int dayun = 8;
            ret += b("姓名：") + bazi.Name + "　"+b("排盘类型：");
            if (bazi.RealTime)
            {
                ret += "真太阳时";
            }
            else
            {
                ret += "普通排盘";
            }
            ret += "<br />";
            if (bazi.RealTime)
            {
                ret += b("出生地：") + bazi.AreaName + "　" + b("经度：")+bazi.Longitude+"<br />";
            }
            ret += "上上签神秘学社区四柱八字排盘系统　<a href='" + AppCmn.AppConfig.HomeUrl() + "'>" + AppCmn.AppConfig.HomeUrl() + "</a><br /><br />";
            ret += b("公历：") + fa(bazi.BirthTime.Date.Year.ToString("0000")) + "年" + fa(bazi.BirthTime.Date.Month.ToString("00")) + "月" +
                fa(bazi.BirthTime.Date.Day.ToString("00")) + "日" + fa(bazi.BirthTime.Date.Hour.ToString("00")) + "时" + fa(bazi.BirthTime.Date.Minute.ToString("00")) + "分" + "<br />";
            ret += b("阴历：") + PublicValue.GetTianGan(bazi.BirthTime.NongliTG) + PublicValue.GetDiZhi(bazi.BirthTime.NongliDZ) + "年[" + PublicValue.GetNayin(10000+(int)bazi.BirthTime.NongliTG * 100 + (int)bazi.BirthTime.NongliDZ) + "]" +
                PublicValue.GetNongliMonth(bazi.BirthTime.NongliMonth) +"月"+ PublicValue.GetNongliDay(bazi.BirthTime.NongliDay) + PublicValue.GetDiZhi(bazi.BirthTime.NongliHour) + "时<br /><br />";
            ret += PublicValue.GetAllJieQi(bazi.JieQiName[0]) + "：" +fa(bazi.JieQi[0].Year.ToString("0000")) + "年" + fa(bazi.JieQi[0].Month.ToString("00")) + "月" +fa(bazi.JieQi[0].Day.ToString("00")) + "日"
                 + fa(bazi.JieQi[0].Hour.ToString("00")) + "时" + fa(bazi.JieQi[0].Minute.ToString("00")) + "分" + fa(bazi.JieQi[0].Second.ToString("00")) + "秒" + "　(高精度天文算法)<br />";
            ret += PublicValue.GetAllJieQi(bazi.JieQiName[1]) + "：" + fa(bazi.JieQi[1].Year.ToString("0000")) + "年" + fa(bazi.JieQi[1].Month.ToString("00")) + "月" + fa(bazi.JieQi[1].Day.ToString("00")) + "日"
                 + fa(bazi.JieQi[1].Hour.ToString("00")) + "时" + fa(bazi.JieQi[1].Minute.ToString("00")) + "分" + fa(bazi.JieQi[1].Second.ToString("00")) + "秒" + "<br /><br />";
            ret += b("起运：") + "于出生后" + fa(bazi.QiYun.Days.ToString()) + "天" + fa(bazi.QiYun.Hours.ToString()) + "小时" + fa(bazi.QiYun.Minutes.ToString()) + "分钟起运<br />";
            ret += b("交运：") + "于公历" + fa(bazi.JiaoYun.Year.ToString()) + "年" + fa(bazi.JiaoYun.Month.ToString()) + "月" + fa(bazi.JiaoYun.Day.ToString()) + "日" + fa(bazi.JiaoYun.Hour.ToString()) + "时" + fa(bazi.JiaoYun.Hour.ToString()) + "分交运<br /><br />";
            ret += "　　　　" + fc(PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(bazi.YearTG, bazi.DayTG)).ShiShen)) + "　　" +
                 fc(PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(bazi.MonthTG, bazi.DayTG)).ShiShen)) + "　　"+fc("日主")+"　　" +
                 fc(PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(bazi.HourTG, bazi.DayTG)).ShiShen)) +"<br />";
            if(bazi.Gender == AppCmn.AppEnum.Gender.male)
            {
                ret += b("乾造：")+"　";
            }
            else
            {
                ret += b("坤造：")+"　";
            }
            ret += fa(PublicValue.GetTianGan(bazi.YearTG)) + "　　　" + fa(PublicValue.GetTianGan(bazi.MonthTG)) + "　　　" +
                fa(PublicValue.GetTianGan(bazi.DayTG)) + "　　　" + fa(PublicValue.GetTianGan(bazi.HourTG)) + "　　（" +
                fd(PublicValue.GetDiZhi(bazi.XunKong0)) + fd(PublicValue.GetDiZhi(bazi.XunKong1)) + "空）<br />";
            ret += b("　　　")+"　" + fa(PublicValue.GetDiZhi(bazi.YearDZ)) + "　　　" + fa(PublicValue.GetDiZhi(bazi.MonthDZ)) + "　　　" +
                fa(PublicValue.GetDiZhi(bazi.DayDZ)) + "　　　" + fa(PublicValue.GetDiZhi(bazi.HourDZ)) + "<br /><br />";
            for (int j = 0; j < 3; j++)
            {
                ret += b("　　　")+"　";
                for (int i = 0; i < 4; i++)
                {
                    if (!(j != 0 && (int)bazi.CangGan[i, j] == 0))
                        ret += PublicValue.GetTianGan(bazi.CangGan[i, j]) + fc(PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(bazi.CangGan[i, j], bazi.DayTG)).ShiShen)) + "　";
                }
                ret += "<br />";
            }
            ret += b("旺衰：")+"　";
            for (int i = 0; i < 4; i++)
            {
                ret += PublicValue.GetZiWeiChangSheng(bazi.WangShuai[i]).Replace("　", "");
                for (int j = 0; j < 4 - PublicValue.GetZiWeiChangSheng(bazi.WangShuai[i]).Replace("　", "").Length; j++)
                {
                    ret += "　";
                }
            }
            ret += "<br />";
            ret += b("纳音：")+"　";
            for (int i = 0; i < 4; i++)
            {
                ret += fb(PublicValue.GetNayin(bazi.NaYin[i])) + "　";
            }
            ret += "<br /><br />";

            //大运
            ret += b("纳音：");
            for (int i = 0; i < dayun; i++)
            {
                ret += fb(PublicValue.GetNayin(bazi.Dayun[i].NaYin)) + "　";
            }
            ret += "<br />";
            ret += b("旺衰：");
            for (int i = 0; i < dayun; i++)
            {
                ret += PublicValue.GetZiWeiChangSheng(bazi.Dayun[i].WangShuai).Replace("　", "");
                for (int j = 0; j < 4 - PublicValue.GetZiWeiChangSheng(bazi.Dayun[i].WangShuai).Replace("　", "").Length; j++)
                {
                    ret += "　";
                }
            }
            ret += "<br />";
            ret += b("十神：");
            for (int i = 0; i < dayun; i++)
            {
                ret += fc(PublicValue.GetShiShen(bazi.Dayun[i].ShiShen)) + "　　";
            }
            ret += "<br />";
            ret += b("大运：");
            for (int i = 0; i < dayun; i++)
            {
                ret += fa(PublicValue.GetTianGan(bazi.Dayun[i].YearTG) +PublicValue.GetDiZhi(bazi.Dayun[i].YearDZ))+ "　　";
            }
            ret += "<br />";
            ret += b("　　　 ");
            for (int i = 0; i < dayun; i++)
            {
                ret += bazi.Dayun[i].Begin-bazi.BirthTime.Date.Year +  "岁　　";
            }
            ret += "<br />";
            //流年
            if (all)
            {
                ret += b("始于：");
                for (int i = 0; i < dayun; i++)
                {
                    ret += fc(bazi.Dayun[i].Begin.ToString("")) + "　　";
                }
                ret += "<br />";
                ret += b("流年：");
                for (int i = 0; i < 10; i++)
                {
                    if (i != 0)
                    {
                        ret += b("　　　");
                    }
                    for (int j = 0; j < dayun; j++)
                    {
                        ret += PublicValue.GetTianGan(BaZiBiz.GetInstance().YearTG(bazi.Dayun[j].Begin + i)) +
                            PublicValue.GetDiZhi(BaZiBiz.GetInstance().YearDZ(bazi.Dayun[j].Begin + i)).Replace(PublicValue.GetDiZhi(bazi.XunKong0), fd(PublicValue.GetDiZhi(bazi.XunKong0))).Replace(PublicValue.GetDiZhi(bazi.XunKong1), fd(PublicValue.GetDiZhi(bazi.XunKong1))) + "　　";
                    }
                    ret += "<br />";
                }

                ret += b("止于：");
                for (int i = 0; i < dayun; i++)
                {
                    ret += fc(bazi.Dayun[i].End.ToString()) + "　　";
                }
                ret += "<br />";

            }
                return ret;
        }

        #region 打印算法
        private string fa(string input)
        {
            input = "<font color='#ff2a01'>" + input + "</font>";
            return input;
        }
        private string fb(string input)
        {
            input = "<font color='#149e11'>" + input + "</font>";
            return input;
        }
        private string fc(string input)
        {
            input = "<font color='#1a85c2'>" + input + "</font>";
            return input;
        }
        private string fd(string input)
        {
            input = "<font color='#fe30d9'>" + input + "</font>";
            return input;
        }
        
        private string b(string input)
        {
            input = "<b>" + input + "</b>";
            return input;
        }
        #endregion

    }

}
