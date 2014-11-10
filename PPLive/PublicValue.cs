using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Runtime.Serialization;


namespace PPLive
{
    [DataContract]
    public static class PublicValue
    {
        #region 工具函数

        private static SortedList GetStatus(System.Type t)
        {
            SortedList list = new SortedList();

            Array a = Enum.GetValues(t);
            for (int i = 0; i < a.Length; i++)
            {
                string enumName = a.GetValue(i).ToString();
                int enumKey = (int)System.Enum.Parse(t, enumName);
                string enumDescription = GetDescription(t, enumKey);
                list.Add(enumKey, enumDescription);
            }
            return list;
        }

        private static string GetName(System.Type t, object v)
        {
            try
            {
                return Enum.GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// 返回指定枚举类型的指定值的描述
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <param name="v">枚举值</param>
        /// <returns></returns>
        private static string GetDescription(System.Type t, object v)
        {
            try
            {
                FieldInfo fi = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }
        #endregion

        #region 天干地支
        [DataContract(Name = "TianGan")]
        public enum TianGan
        {
            [EnumMember]
            [Description("甲")]
            jia = 0,
            [EnumMember]
            [Description("乙")]
            yi = 1,
            [EnumMember]
            [Description("丙")]
            bing = 2,
            [EnumMember]
            [Description("丁")]
            ding = 3,
            [EnumMember]
            [Description("戊")]
            wu = 4,
            [EnumMember]
            [Description("己")]
            ji = 5,
            [EnumMember]
            [Description("庚")]
            geng = 6,
            [EnumMember]
            [Description("辛")]
            xin = 7,
            [EnumMember]
            [Description("壬")]
            ren = 8,
            [EnumMember]
            [Description("癸")]
            gui = 9
        };
        public static string GetTianGan(object v)
        {
            return GetDescription(typeof(TianGan), v);
        }
        public static SortedList GetTianGan()
        {
            return GetStatus(typeof(TianGan));
        }

        [DataContract(Name = "DiZhi")]
        public enum DiZhi
        {
            [EnumMember]
            [Description("子")]
            zi = 0,
            [EnumMember]
            [Description("丑")]
            chou = 1,
            [EnumMember]
            [Description("寅")]
            yin = 2,
            [EnumMember]
            [Description("卯")]
            mao = 3,
            [EnumMember]
            [Description("辰")]
            chen = 4,
            [EnumMember]
            [Description("巳")]
            si = 5,
            [EnumMember]
            [Description("午")]
            wu = 6,
            [EnumMember]
            [Description("未")]
            wei = 7,
            [EnumMember]
            [Description("申")]
            shen = 8,
            [EnumMember]
            [Description("酉")]
            you = 9,
            [EnumMember]
            [Description("戌")]
            xu = 10,
            [EnumMember]
            [Description("亥")]
            hai = 11
        };
        public static string GetDiZhi(object v)
        {
            return GetDescription(typeof(DiZhi), v);
        }
        public static SortedList GetDiZhi()
        {
            return GetStatus(typeof(DiZhi));
        }

        [DataContract(Name = "ShiShen")]
        public enum ShiShen
        {
            [EnumMember]
            [Description("比肩")]
            bijian = 0,
            [EnumMember]
            [Description("劫财")]
            jiecai = 1,
            [EnumMember]
            [Description("正印")]
            zhengyin = 2,
            [EnumMember]
            [Description("枭神")]
            pianyin = 3,
            [EnumMember]
            [Description("食神")]
            shishen = 4,
            [EnumMember]
            [Description("伤官")]
            shangguan = 5,
            [EnumMember]
            [Description("正财")]
            zhengcai = 6,
            [EnumMember]
            [Description("偏财")]
            piancai = 7,
            [EnumMember]
            [Description("正官")]
            zhengguan = 8,
            [EnumMember]
            [Description("七杀")]
            qisha = 9,

        };
        public static string GetShiShen(object v)
        {
            return GetDescription(typeof(ShiShen), v);
        }
        #endregion

        #region 公共

        [DataContract(Name = "ShuXing")]
        public enum ShuXing
        {
            [EnumMember][Description("阴")]
            yin = 0,
            [EnumMember][Description("阳")]
            yang = 1
        }
        public static SortedList GetShuXing()
        {
            return GetStatus(typeof(ShuXing));
        }
        public static string GetShuXing(object v)
        {
            return GetDescription(typeof(ShuXing), v);
        }

        [DataContract(Name = "Nayin")]
        public enum Nayin
        {
            [EnumMember][Description("海中金")]
            jiazi = 10000,
            [EnumMember][Description("海中金")]
            yichou = 10101,
            [EnumMember][Description("炉中火")]
            bingyin = 10202,
            [EnumMember][Description("炉中火")]
            dingmao = 10303,
            [EnumMember][Description("大林木")]
            wuchen = 10404,
            [EnumMember][Description("大林木")]
            jisi = 10505,
            [EnumMember][Description("路旁土")]
            gengwu = 10606,
            [EnumMember][Description("路旁土")]
            xinwei = 10707,
            [EnumMember][Description("剑锋金")]
            renshen = 10808,
            [EnumMember][Description("剑锋金")]
            guiyou = 10909,
            [EnumMember][Description("山头火")]
            jiaxu = 10010,
            [EnumMember][Description("山头火")]
            yihai = 10111,
            [EnumMember][Description("涧下水")]
            bingzi = 10200,
            [EnumMember][Description("涧下水")]
            dingchou = 10301,
            [EnumMember][Description("城头土")]
            wuyin = 10402,
            [EnumMember][Description("城头土")]
            jimao = 10503,
            [EnumMember][Description("白蜡金")]
            gengchen = 10604,
            [EnumMember][Description("白蜡金")]
            xinsi = 10705,
            [EnumMember][Description("杨柳木")]
            renwu = 10806,
            [EnumMember][Description("杨柳木")]
            guiwei = 10907,
            [EnumMember][Description("泉中水")]
            jiashen = 10008,
            [EnumMember][Description("泉中水")]
            yiyou = 10109,
            [EnumMember][Description("屋上土")]
            bingxu = 10210,
            [EnumMember][Description("屋上土")]
            dinghai = 10311,
            [EnumMember][Description("霹雳火")]
            wuzi = 10400,
            [EnumMember][Description("霹雳火")]
            jichou = 10501,
            [EnumMember][Description("松柏木")]
            gengyin = 10602,
            [EnumMember][Description("松柏木")]
            xinmao = 10703,
            [EnumMember][Description("长流水")]
            renchen = 10804,
            [EnumMember][Description("长流水")]
            guisi = 10905,
            [EnumMember][Description("砂中金")]
            jiawu = 10006,
            [EnumMember][Description("砂中金")]
            yiwei = 10107,
            [EnumMember][Description("山下火")]
            bingshen = 10208,
            [EnumMember][Description("山下火")]
            dingyou = 10309,
            [EnumMember][Description("平地木")]
            wuxu = 10410,
            [EnumMember][Description("平地木")]
            jihai = 10511,
            [EnumMember][Description("壁上土")]
            gengzi = 10600,
            [EnumMember][Description("壁上土")]
            xinchou = 10701,
            [EnumMember][Description("金箔金")]
            renyin = 10802,
            [EnumMember][Description("金箔金")]
            guimao = 10903,
            [EnumMember][Description("覆灯火")]
            jiachen = 10004,
            [EnumMember][Description("覆灯火")]
            yisi = 10105,
            [EnumMember][Description("天河水")]
            bingwu = 10206,
            [EnumMember][Description("天河水")]
            dingwei = 10307,
            [EnumMember][Description("大驿土")]
            wushen = 10408,
            [EnumMember][Description("大驿土")]
            jiyou = 10509,
            [EnumMember][Description("钗钏金")]
            gengxu = 10610,
            [EnumMember][Description("钗钏金")]
            xinhai = 10711,
            [EnumMember][Description("桑松木")]
            renzi = 10800,
            [EnumMember][Description("桑松木")]
            guichou = 10901,
            [EnumMember][Description("大溪水")]
            jiayin = 10002,
            [EnumMember][Description("大溪水")]
            yimao = 10103,
            [EnumMember][Description("沙中土")]
            bingchen = 10204,
            [EnumMember][Description("沙中土")]
            dingsi = 10305,
            [EnumMember][Description("天上火")]
            wuwu = 10406,
            [EnumMember][Description("天上火")]
            jiwei = 10507,
            [EnumMember][Description("石榴木")]
            gengshen = 10608,
            [EnumMember][Description("石榴木")]
            xinyou = 10709,
            [EnumMember][Description("大海水")]
            renxu = 10810,
            [EnumMember][Description("大海水")]
            guihai = 10911,
        }
        public static string GetNayin(object v)
        {
            return GetDescription(typeof(Nayin), v);
        }

        [DataContract(Name = "JieQi")]
        public enum JieQi
        {
            [EnumMember][Description("小寒")]
            xiaohan = 0,
            [EnumMember][Description("立春")]
            lichun = 1,
            [EnumMember][Description("惊蛰")]
            jingzhe = 2,
            [EnumMember][Description("清明")]
            qingming = 3,
            [EnumMember][Description("立夏")]
            lixia = 4,
            [EnumMember][Description("芒种")]
            mangzhong = 5,
            [EnumMember][Description("小暑")]
            xiaoshu = 6,
            [EnumMember][Description("立秋")]
            liqiu = 7,
            [EnumMember][Description("白露")]
            bailu = 8,
            [EnumMember][Description("寒露")]
            hanlu = 9,
            [EnumMember][Description("立冬")]
            lidong = 10,
            [EnumMember][Description("大雪")]
            daxue = 11,
        }
        public static SortedList GetJieQi()
        {
            return GetStatus(typeof(JieQi));
        }
        public static string GetJieQi(object v)
        {
            return GetDescription(typeof(JieQi), v);
        }

        [DataContract(Name = "ZhongQi")]
        public enum ZhongQi
        {
            [EnumMember][Description("大寒")]
            dahan = 0,
            [EnumMember][Description("雨水")]
            yushui = 1,
            [EnumMember][Description("春分")]
            chunfen = 2,
            [EnumMember][Description("谷雨")]
            guyu = 3,
            [EnumMember][Description("小满")]
            xiaoman = 4,
            [EnumMember][Description("夏至")]
            xiazhi = 5,
            [EnumMember][Description("大暑")]
            dashu = 6,
            [EnumMember][Description("处暑")]
            chushu = 7,
            [EnumMember][Description("秋分")]
            qiufen = 8,
            [EnumMember][Description("霜降")]
            shuangjiang = 9,
            [EnumMember][Description("小雪")]
            xiaoxue = 10,
            [EnumMember][Description("冬至")]
            dongzhi = 11,
        }
        public static SortedList GetZhongQi()
        {
            return GetStatus(typeof(ZhongQi));
        }
        public static string GetZhongQi(object v)
        {
            return GetDescription(typeof(ZhongQi), v);
        }

        [DataContract(Name = "AllJieQi")]
        public enum AllJieQi
        {
            [EnumMember][Description("小寒")]
            xiaohan = 0,
            [EnumMember][Description("大寒")]
            dahan = 1,
            [EnumMember][Description("立春")]
            lichun = 2,
            [EnumMember][Description("雨水")]
            yushui = 3,
            [EnumMember][Description("惊蛰")]
            jingzhe = 4,
            [EnumMember][Description("春分")]
            chunfen = 5,
            [EnumMember][Description("清明")]
            qingming = 6,
            [EnumMember][Description("谷雨")]
            guyu = 7,
            [EnumMember][Description("立夏")]
            lixia = 8,
            [EnumMember][Description("小满")]
            xiaoman = 9,
            [EnumMember][Description("芒种")]
            mangzhong = 10,
            [EnumMember][Description("夏至")]
            xiazhi = 11,
            [EnumMember][Description("小暑")]
            xiaoshu = 12,
            [EnumMember][Description("大暑")]
            dashu = 13,
            [EnumMember][Description("立秋")]
            liqiu = 14,
            [EnumMember][Description("处暑")]
            chushu = 15,
            [EnumMember][Description("白露")]
            bailu = 16,
            [EnumMember][Description("秋分")]
            qiufen = 17,
            [EnumMember][Description("寒露")]
            hanlu = 18,
            [EnumMember][Description("霜降")]
            shuangjiang = 19,
            [EnumMember][Description("立冬")]
            lidong = 20,
            [EnumMember][Description("小雪")]
            xiaoxue = 21,
            [EnumMember][Description("大雪")]
            daxue = 22,
            [EnumMember][Description("冬至")]
            dongzhi = 23,
        }
        public static SortedList GetAllJieQi()
        {
            return GetStatus(typeof(AllJieQi));
        }
        public static string GetAllJieQi(object v)
        {
            return GetDescription(typeof(AllJieQi), v);
        }
        #endregion

        #region 农历
        [DataContract(Name = "NongliMonth")]
        public enum NongliMonth
        {
            [EnumMember][Description("正")]
            jan = 1,
            [EnumMember][Description("二")]
            feb = 2,
            [EnumMember][Description("三")]
            mar = 3,
            [EnumMember][Description("四")]
            apr = 4,
            [EnumMember][Description("五")]
            may = 5,
            [EnumMember][Description("六")]
            jun = 6,
            [EnumMember][Description("七")]
            jul = 7,
            [EnumMember][Description("八")]
            aug = 8,
            [EnumMember][Description("九")]
            spet = 9,
            [EnumMember][Description("十")]
            oct = 10,
            [EnumMember][Description("十一")]
            nov = 11,
            [EnumMember][Description("腊")]
            dec = 12,
            [EnumMember][Description("润正")]
            janleap = 101,
            [EnumMember][Description("润二")]
            fableap = 102,
            [EnumMember][Description("润三")]
            marleap = 103,
            [EnumMember][Description("闰四")]
            aprleap = 104,
            [EnumMember][Description("闰五")]
            mayleap = 105,
            [EnumMember][Description("闰六")]
            junleap = 106,
            [EnumMember][Description("闰七")]
            julleap = 107,
            [EnumMember][Description("闰八")]
            augleap = 108,
            [EnumMember][Description("闰九")]
            septleap = 109,
            [EnumMember][Description("润十")]
            orcleap = 110,
            [EnumMember][Description("润十一")]
            novleap = 111,
            [EnumMember][Description("润腊")]
            decleap = 112,
        }
        public static string GetNongliMonth(object v)
        {
            return GetDescription(typeof(NongliMonth), v);
        }

        [DataContract(Name = "NongliDay")]
        public enum NongliDay
        {
            [EnumMember][Description("初一")]
            a = 1,
            [EnumMember][Description("初二")]
            b = 2,
            [EnumMember][Description("初三")]
            c = 3,
            [EnumMember][Description("初四")]
            d = 4,
            [EnumMember][Description("初五")]
            e = 5,
            [EnumMember][Description("初六")]
            f = 6,
            [EnumMember][Description("初七")]
            g = 7,
            [EnumMember][Description("初八")]
            h = 8,
            [EnumMember][Description("初九")]
            i = 9,
            [EnumMember][Description("初十")]
            j = 10,
            [EnumMember][Description("十一")]
            k = 11,
            [EnumMember][Description("十二")]
            l = 12,
            [EnumMember][Description("十三")]
            m = 13,
            [EnumMember][Description("十四")]
            n = 14,
            [EnumMember][Description("十五")]
            o = 15,
            [EnumMember][Description("十六")]
            p = 16,
            [EnumMember][Description("十七")]
            q = 17,
            [EnumMember][Description("十八")]
            r = 18,
            [EnumMember][Description("十九")]
            s = 19,
            [EnumMember][Description("二十")]
            t = 20,
            [EnumMember][Description("廿一")]
            u = 21,
            [EnumMember][Description("廿二")]
            v = 22,
            [EnumMember][Description("廿三")]
            w = 23,
            [EnumMember][Description("廿四")]
            x = 24,
            [EnumMember][Description("廿五")]
            y = 25,
            [EnumMember][Description("廿六")]
            z = 26,
            [EnumMember][Description("廿七")]
            aa = 27,
            [EnumMember][Description("廿八")]
            bb = 28,
            [EnumMember][Description("廿九")]
            cc = 29,
            [EnumMember][Description("三十")]
            dd = 30
        }
        public static string GetNongliDay(object v)
        {
            return GetDescription(typeof(NongliDay), v);
        }
        #endregion

        #region 六爻基础
        [DataContract(Name = "LYLiuQin")]
        public enum LYLiuQin
        {
            [EnumMember][Description("父母")]
            fumu = 0,
            [EnumMember][Description("官鬼")]
            guanggui = 1,
            [EnumMember][Description("兄弟")]
            xiongdi = 2,
            [EnumMember][Description("妻财")]
            qicai = 3,
            [EnumMember][Description("子孙")]
            zisun = 4
        }
        public static string GetLYLiuQin(object v)
        {
            return GetDescription(typeof(LYLiuQin), v);
        }
        #endregion

        #region 紫薇基础
        [DataContract(Name = "ZiWeiRunYue")]
        public enum ZiWeiRunYue
        {
            [EnumMember][Description("按当月算")]
            
            dang = 1,
            [EnumMember][Description("按下月算")]
            xia = 2,
            [EnumMember][Description("前15日算当月，后15日算下月")]
            dangxia = 3,
        }
        public static SortedList GetZiWeiRunYue()
        {
            return GetStatus(typeof(ZiWeiRunYue));
        }
        public static string GetZiWeiRunYue(object v)
        {
            return GetDescription(typeof(ZiWeiRunYue), v);
        }

        [DataContract(Name = "ZiWeiMingJu")]
        public enum ZiWeiMingJu
        {
            [EnumMember][Description("水二局")]
            shui = 2,
            [EnumMember][Description("木三局")]
            mu = 3,
            [EnumMember][Description("金四局")]
            jin = 4,
            [EnumMember][Description("土五局")]
            tu = 5,
            [EnumMember][Description("火六局")]
            huo = 6
        }
        public static string GetZiWeiMingJu(object v)
        {
            return GetDescription(typeof(ZiWeiMingJu), v);
        }

        [DataContract(Name = "ZiWeiGong")]
        public enum ZiWeiGong
        {
            [EnumMember][Description("★命宫")]
            ming = 0,
            [EnumMember][Description("兄弟宫")]
            xiongdi = 1,
            [EnumMember][Description("夫妻宫")]
            fuqi = 2,
            [EnumMember][Description("子女宫")]
            zinv = 3,
            [EnumMember][Description("财帛宫")]
            caibo = 4,
            [EnumMember][Description("疾厄宫")]
            jie = 5,
            [EnumMember][Description("迁移宫")]
            qianyi = 6,
            [EnumMember][Description("仆役宫")]
            puyi = 7,
            [EnumMember][Description("官禄宫")]
            guanlu = 8,
            [EnumMember][Description("田宅宫")]
            tianzhai = 9,
            [EnumMember][Description("福德宫")]
            fude = 10,
            [EnumMember][Description("父母宫")]
            fumu = 11,
        }
        public static string GetZiWeiGong(object v)
        {
            return GetDescription(typeof(ZiWeiGong), v);
        }
        public static SortedList GetZiWeiGong()
        {
            return GetStatus(typeof(ZiWeiGong));
        }

        [DataContract(Name = "ZiWeiStar")]
        public enum ZiWeiStar
        {
            [EnumMember][Description("无")]
            wu = -1,
            //北斗主星
            [EnumMember][Description("紫薇")]
            ziwei = 0,
            [EnumMember][Description("天机")]
            tianji = 1,
            [EnumMember][Description("太阳")]
            taiyang = 2,
            [EnumMember][Description("武曲")]
            wuqu = 3,
            [EnumMember][Description("天同")]
            tiantong = 4,
            [EnumMember][Description("廉贞")]
            lianzhen = 5,
            //南斗主星
            [EnumMember][Description("天府")]
            tianfu = 6,
            [EnumMember][Description("太阴")]
            taiyin = 7,
            [EnumMember][Description("贪狼")]
            tanlang = 8,
            [EnumMember][Description("巨门")]
            jvmen = 9,
            [EnumMember][Description("天相")]
            tianxiang = 10,
            [EnumMember][Description("天梁")]
            tianliang = 11,
            [EnumMember][Description("七杀")]
            qisha = 12,
            [EnumMember][Description("破军")]
            pojun = 13,
            //6辅星
            [EnumMember][Description("文曲")]
            wenqu = 14,
            [EnumMember][Description("文昌")]
            wenchang = 15,
            [EnumMember][Description("左辅")]
            zuofu = 16,
            [EnumMember][Description("右弼")]
            youbi = 17,
            [EnumMember][Description("天魁")]
            tiankui = 18,
            [EnumMember][Description("天钺")]
            tianyue = 19,
            //禄存，天马
            [EnumMember][Description("禄存")]
            lucun = 20,
            [EnumMember][Description("天马")]
            tianma = 21,
            //四凶星
            [EnumMember][Description("擎羊")]
            qingyang = 22,
            [EnumMember][Description("陀罗")]
            tuoluo = 23,
            [EnumMember][Description("火星")]
            huoxing = 24,
            [EnumMember][Description("铃星")]
            lingxing = 25,
            //地空，地截
            [EnumMember][Description("地空")]
            dikong = 26,
            [EnumMember][Description("地劫")]
            dijie = 27,
            //贵人星
            [EnumMember][Description("天官")]
            tianguan = 28,
            [EnumMember][Description("天福")]
            tianfo = 29,
            //众星
            [EnumMember][Description("截空")]
            jiekong = 30,
            [EnumMember][Description("旬空")]
            xunkong = 31,

            [EnumMember][Description("红鸾")]
            hongluan = 32,
            [EnumMember][Description("天喜")]
            tianxi = 33,

            [EnumMember][Description("龙池")]
            longchi = 34,
            [EnumMember][Description("凤阁")]
            fengge = 35,
            [EnumMember][Description("三台")]
            santai = 36,
            [EnumMember][Description("八座")]
            bazuo = 37,

            [EnumMember][Description("天才")]
            tiancai = 38,
            [EnumMember][Description("天寿")]
            tianshou = 39,

            [EnumMember][Description("孤辰")]
            guchen = 40,
            [EnumMember][Description("寡宿")]
            guasu = 41,

            [EnumMember][Description("台辅")]
            taifu = 42,
            [EnumMember][Description("封诰")]
            fenggao = 43,

            [EnumMember][Description("天刑")]
            tianxing = 44,
            [EnumMember][Description("天姚")]
            tianyao = 45,
            [EnumMember][Description("解神")]
            jieshen = 46,
            [EnumMember][Description("天巫")]
            tianwu = 47,
            [EnumMember][Description("天月")]
            tianyu = 48,
            [EnumMember][Description("阴煞")]
            yinsha = 49,

            [EnumMember][Description("天伤")]
            tianshang = 50,
            [EnumMember][Description("天使")]
            tianshi = 51,
            [EnumMember][Description("恩光")]
            enguang = 52,
            [EnumMember][Description("天贵")]
            tiangui = 53,

            [EnumMember][Description("天厨")]
            tianchu = 54,
            [EnumMember][Description("天空")]
            tiankong = 55,
            [EnumMember][Description("天哭")]
            tianku = 56,
            [EnumMember][Description("天虚")]
            tianxu = 57,
            [EnumMember][Description("劫杀")]
            jiesha = 58,
            [EnumMember][Description("大耗")]
            dahao = 59,
            [EnumMember][Description("蜚廉")]
            chilian = 60,
            [EnumMember][Description("破碎")]
            posui = 61,
            [EnumMember][Description("华盖")]
            huagai = 62,
            [EnumMember][Description("咸池")]
            xianchi = 63,
            [EnumMember][Description("龙德")]
            longde = 64,
            [EnumMember][Description("月德")]
            yuede = 65,
            [EnumMember][Description("天德")]
            tiande = 66,
            [EnumMember][Description("年解")]
            nianjie = 67,
        }
        public static string GetZiWeiStar(object v)
        {
            return GetDescription(typeof(ZiWeiStar), v);
        }
        public static SortedList GetZiWeiStar()
        {
            return GetStatus(typeof(ZiWeiStar));
        }

        [DataContract(Name = "ZiWeiSihua")]
        public enum ZiWeiSihua
        {
            [EnumMember][Description("　")]
            none = 0,
            [EnumMember][Description("禄")]
            lu = 1,
            [EnumMember][Description("权")]
            quan = 2,
            [EnumMember][Description("科")]
            ke = 3,
            [EnumMember][Description("忌")]
            ji = 4
        }
        public static string GetZiWeiSihua(object v)
        {
            return GetDescription(typeof(ZiWeiSihua), v);
        }
        public static SortedList GetZiWeiSihua()
        {
            return GetStatus(typeof(ZiWeiSihua));
        }

        [DataContract(Name = "ZiWeiMiaowang")]
        public enum ZiWeiMiaowang
        {
            [EnumMember][Description("　")]
            none = 0,
            [EnumMember][Description("庙")]
            miao = 1,
            [EnumMember][Description("旺")]
            wang = 2,
            [EnumMember][Description("平")]
            ping = 3,
            [EnumMember][Description("地")]
            di = 4,
            [EnumMember][Description("闲")]
            xia = 5,
            [EnumMember][Description("陷")]
            xian = 6
        }
        public static string GetZiWeiMiaowang(object v)
        {
            return GetDescription(typeof(ZiWeiMiaowang), v);
        }

        [DataContract(Name = "ZiWeiChangSheng")]
        public enum ZiWeiChangSheng
        {
            [EnumMember][Description("长生")]
            changsheng = 0,
            [EnumMember][Description("沐浴")]
            muyu = 1,
            [EnumMember][Description("冠带")]
            guandai = 2,
            [EnumMember][Description("临官")]
            linguan = 3,
            [EnumMember][Description("帝旺")]
            diwang = 4,
            [EnumMember][Description("　衰")]
            shuai = 5,
            [EnumMember][Description("　病")]
            bing = 6,
            [EnumMember][Description("　死")]
            si = 7,
            [EnumMember][Description("　墓")]
            mu = 8,
            [EnumMember][Description("　绝")]
            jue = 9,
            [EnumMember][Description("　胎")]
            tai = 10,
            [EnumMember][Description("　养")]
            yang = 11
        }
        public static string GetZiWeiChangSheng(object v)
        {
            return GetDescription(typeof(ZiWeiChangSheng), v);
        }

        [DataContract(Name = "ZiWeiTaiSui")]
        public enum ZiWeiTaiSui
        {
            [EnumMember][Description("岁建")]
            suijian = 0,
            [EnumMember][Description("晦气")]
            huiqi = 1,
            [EnumMember][Description("丧门")]
            sangmen = 2,
            [EnumMember][Description("贯索")]
            guansuo = 3,
            [EnumMember][Description("官符")]
            guanfu = 4,
            [EnumMember][Description("小耗")]
            xiaohao = 5,
            [EnumMember][Description("大耗")]
            dahao = 6,
            [EnumMember][Description("龙德")]
            longde = 7,
            [EnumMember][Description("白虎")]
            baihu = 8,
            [EnumMember][Description("天德")]
            tiande = 9,
            [EnumMember][Description("吊客")]
            diaoke = 10,
            [EnumMember][Description("病符")]
            bingfu = 11
        }
        public static string GetZiWeiTaiSui(object v)
        {
            return GetDescription(typeof(ZiWeiTaiSui), v);
        }

        [DataContract(Name = "ZiWeiJiangQian")]
        public enum ZiWeiJiangQian
        {
            [EnumMember][Description("将星")]
            jiangxing = 0,
            [EnumMember][Description("攀鞍")]
            panan = 1,
            [EnumMember][Description("岁驿")]
            suiyi = 2,
            [EnumMember][Description("息神")]
            xishen = 3,
            [EnumMember][Description("华盖")]
            huagai = 4,
            [EnumMember][Description("劫煞")]
            jiesha = 5,
            [EnumMember][Description("灾煞")]
            zaisha = 6,
            [EnumMember][Description("天煞")]
            tiansha = 7,
            [EnumMember][Description("指背")]
            zhibei = 8,
            [EnumMember][Description("咸池")]
            xianchi = 9,
            [EnumMember][Description("月煞")]
            yuesha = 10,
            [EnumMember][Description("亡神")]
            wangshen = 11
        }
        public static string GetZiWeiJiangQian(object v)
        {
            return GetDescription(typeof(ZiWeiJiangQian), v);
        }

        [DataContract(Name = "ZiWeiBoShi")]
        public enum ZiWeiBoShi
        {
            [EnumMember][Description("博士")]
            boshi = 0,
            [EnumMember][Description("力士")]
            lishi = 1,
            [EnumMember][Description("青龙")]
            qinglong = 2,
            [EnumMember][Description("小耗")]
            xiaohao = 3,
            [EnumMember][Description("将军")]
            jiangjun = 4,
            [EnumMember][Description("奏书")]
            qinshu = 5,
            [EnumMember][Description("飞廉")]
            feilian = 6,
            [EnumMember][Description("喜神")]
            xishen = 7,
            [EnumMember][Description("病符")]
            bingfu = 8,
            [EnumMember][Description("大耗")]
            dahao = 9,
            [EnumMember][Description("伏兵")]
            fubing = 10,
            [EnumMember][Description("官府")]
            guanfu = 11
        }
        public static string GetZiWeiBoShi(object v)
        {
            return GetDescription(typeof(ZiWeiBoShi), v);
        }
        #endregion

        #region 占星术基础
        [DataContract(Name = "AstroType")]
        public enum AstroType
        {
            [EnumMember][Description("本命盘")]
            benming = 1,
            [EnumMember][Description("合盘")]
            hepan = 2,
            [EnumMember][Description("推运盘")]
            tuiyun = 3,
        }

        public static SortedList GetAstroType()
        {
            return GetStatus(typeof(AstroType));
        }
        public static string GetAstroType(object v)
        {
            return GetDescription(typeof(AstroType), v);
        }

        [DataContract(Name = "AstroZuhe")]
        public enum AstroZuhe
        {
            [EnumMember][Description("比较盘(comparison)")]
            bijiao = 1,
            [EnumMember][Description("组合盘(composite)")]
            zuhe = 2,
            [EnumMember][Description("时空中点盘(midpoint)")]
            shikong = 3,
            [EnumMember][Description("合并盘(synastry)")]
            hebing = 4,
        }

        public static SortedList GetAstroZuhe()
        {
            return GetStatus(typeof(AstroZuhe));
        }
        public static string GetAstroZuhe(object v)
        {
            return GetDescription(typeof(AstroZuhe), v);
        }

        [DataContract(Name = "AstroTuiyun")]
        public enum AstroTuiyun
        {
            [EnumMember][Description("行运VS本命(Transit)")]
            xingyun = 1,
            [EnumMember][Description("月亮次限法(365.25636)")]
            cixian = 2,
            [EnumMember][Description("月亮三限法(29.530588)")]
            sanxian = 3,
            [EnumMember][Description("月亮三限法(27.321582)")]
            sanxian1 = 4,
            [EnumMember][Description("太阳反照法(Solar Return)")]
            rifanzhao = 5,
            [EnumMember][Description("月亮反照法(Lunar Return)")]
            yuefanzhao = 6,
            [EnumMember][Description("太阳弧法(Solar Arc)")]
            taiyanghu = 7,
        }

        public static SortedList GetAstroTuiyun()
        {
            return GetStatus(typeof(AstroTuiyun));
        }
        public static string GetAstroTuiyun(object v)
        {
            return GetDescription(typeof(AstroTuiyun), v);
        }

        [DataContract(Name = "AstroStar")]
        public enum AstroStar
        {
            [EnumMember][Description("太阳")]
            Sun = 1,
            [EnumMember][Description("月亮")]
            Moo = 2,
            [EnumMember][Description("水星")]
            Mer = 3,
            [EnumMember][Description("金星")]
            Ven = 4,
            [EnumMember][Description("火星")]
            Mar = 5,
            [EnumMember][Description("木星")]
            Jup = 6,
            [EnumMember][Description("土星")]
            Sat = 7,
            [EnumMember][Description("天王星")]
            Ura = 8,
            [EnumMember][Description("海王星")]
            Nep = 9,
            [EnumMember][Description("冥王星")]
            Plu = 10,
            [EnumMember][Description("凯龙星")]
            Chi = 11,
            [EnumMember][Description("谷神星")]
            Cer = 12,
            [EnumMember][Description("智神星")]
            Pal = 13,
            [EnumMember][Description("婚神星")]
            Jun = 14,
            [EnumMember][Description("灶神星")]
            Ves = 15,
            [EnumMember][Description("北交点")]
            Nod = 16,
            [EnumMember][Description("莉莉丝")]
            Lil = 17,
            [EnumMember][Description("福点")]
            For = 18,
            [EnumMember][Description("宿命点")]
            Ver = 19,
            [EnumMember][Description("东升点")]
            Eas = 20,
            [EnumMember][Description("上升点")]
            Asc = 21,
            [EnumMember][Description("二宫头")]
            Second = 22,
            [EnumMember][Description("三宫头")]
            Third = 23,
            [EnumMember][Description("天底")]
            Nad = 24,
            [EnumMember][Description("五宫头")]
            Fifth = 25,
            [EnumMember][Description("六宫头")]
            Sixth = 26,
            [EnumMember][Description("下降点")]
            Des = 27,
            [EnumMember][Description("八宫头")]
            Eighth = 28,
            [EnumMember][Description("九宫头")]
            Ninth = 29,
            [EnumMember][Description("中天")]
            Mid = 30,
            [EnumMember][Description("十一宫头")]
            Eleventh = 31,
            [EnumMember][Description("十二宫头")]
            Twelveth = 32,
            [EnumMember][Description("南交点")]
            AntiNod = 33,
        }

        public static SortedList GetAstroStar()
        {
            return GetStatus(typeof(AstroStar));
        }
        public static string GetAstroStar(object v)
        {
            return GetDescription(typeof(AstroStar), v);
        }

        [DataContract(Name = "Constellation")]
        public enum Constellation
        {
            [EnumMember][Description("白羊座")]
            Ari = 1,
            [EnumMember][Description("金牛座")]
            Tau = 2,
            [EnumMember][Description("双子座")]
            Gem = 3,
            [EnumMember][Description("巨蟹座")]
            Can = 4,
            [EnumMember][Description("狮子座")]
            Leo = 5,
            [EnumMember][Description("处女座")]
            Vir = 6,
            [EnumMember][Description("天秤座")]
            Lib = 7,
            [EnumMember][Description("天蝎座")]
            Sco = 8,
            [EnumMember][Description("射手座")]
            Sag = 9,
            [EnumMember][Description("摩羯座")]
            Cap = 10,
            [EnumMember][Description("水瓶座")]
            Aqu = 11,
            [EnumMember][Description("双鱼座")]
            Pis = 12,
            
        }

        public static SortedList GetConstellation()
        {
            return GetStatus(typeof(Constellation));
        }
        public static string GetConstellation(object v)
        {
            return GetDescription(typeof(Constellation), v);
        }

        [DataContract(Name = "Element")]
        public enum Element
        {
            [EnumMember][Description("风")]
            wind = 3,
            [EnumMember][Description("火")]
            fire = 1,
            [EnumMember][Description("水")]
            aqua = 4,
            [EnumMember][Description("土")]
            earth = 2,
            

        }

        public static SortedList GetElement()
        {
            return GetStatus(typeof(Element));
        }
        public static string GetElement(object v)
        {
            return GetDescription(typeof(Element), v);
        }

        [DataContract(Name = "Phase")]
        public enum Phase
        {
            [EnumMember][Description("合")]
            he = 0,
            [EnumMember][Description("刑")]
            xing = 90,
            [EnumMember][Description("拱")]
            gong = 120,
            [EnumMember][Description("冲")]
            chong = 180,
            [EnumMember][Description("半拱")]
            bangong = 60,

        }

        public static SortedList GetPhase()
        {
            return GetStatus(typeof(Phase));
        }
        public static string GetPhase(object v)
        {
            return GetDescription(typeof(Phase), v);
        }

       

        #endregion

        #region 盲派八字

        [DataContract(Name = "BaZiLogicItem")]
        public enum BaZiLogicItem
        {
            [EnumMember]
            [Description("年干")]
            niangan = 1,
            [EnumMember]
            [Description("年支")]
            nianzhi = 2,
            [EnumMember]
            [Description("月干")]
            yuegan = 3,
            [EnumMember]
            [Description("月支")]
            yuezhi = 4,
            [EnumMember]
            [Description("日干")]
            rigan = 5,
            [EnumMember]
            [Description("日支")]
            rizhi = 6,
            [EnumMember]
            [Description("时干")]
            shigan = 7,
            [EnumMember]
            [Description("时支")]
            shizhi = 8,
            [EnumMember]
            [Description("年柱藏干")]
            niancanggan = 11,
            [EnumMember]
            [Description("月柱藏干")]
            yuecanggan = 12,
            [EnumMember]
            [Description("日柱藏干")]
            ricanggan = 13,
            [EnumMember]
            [Description("时柱藏干")]
            shicanggan = 14,
            [EnumMember]
            [Description("大运天干")]
            dayungan = 21,
            [EnumMember]
            [Description("大运地支")]
            dayunzhi = 22,
            [EnumMember]
            [Description("流年天干")]
            liuniangan = 23,
            [EnumMember]
            [Description("流年地支")]
            liunianzhi = 24,
            [EnumMember]
            [Description("旬空")]
            xunkong = 9,
            [EnumMember]
            [Description("性别")]
            xingbie = 0,
            [EnumMember]
            [Description("夫妻宫")]
            fuqigong = 31,
            [EnumMember]
            [Description("夫妻星")]
            fuqixing = 41,
        }
        public static SortedList GetBaZiLogicItem()
        {
            return GetStatus(typeof(BaZiLogicItem));
        }
        public static string GetBaZiLogicItem(object v)
        {
            return GetDescription(typeof(BaZiLogicItem), v);
        }

        [DataContract(Name = "BaZiLogicType")]
        public enum BaZiLogicType
        {
            [EnumMember]
            [Description("年干")]
            niangan = 1,
            [EnumMember]
            [Description("年支")]
            niangan = 1,
        }
        public static SortedList GetBaZiLogicType()
        {
            return GetStatus(typeof(BaZiLogicType));
        }
        public static string GetBaZiLogicType(object v)
        {
            return GetDescription(typeof(BaZiLogicType), v);
        }

        #endregion

    }
}
