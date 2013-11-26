using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace PPLive
{
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
        public enum TianGan
        {
            [Description("甲")]
            jia = 0,
            [Description("乙")]
            yi = 1,
            [Description("丙")]
            bing = 2,
            [Description("丁")]
            ding = 3,
            [Description("戊")]
            wu = 4,
            [Description("己")]
            ji = 5,
            [Description("庚")]
            geng = 6,
            [Description("辛")]
            xin = 7,
            [Description("壬")]
            ren = 8,
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

        public enum DiZhi
        {
            [Description("子")]
            zi = 0,
            [Description("丑")]
            chou = 1,
            [Description("寅")]
            yin = 2,
            [Description("卯")]
            mao = 3,
            [Description("辰")]
            chen = 4,
            [Description("巳")]
            si = 5,
            [Description("午")]
            wu = 6,
            [Description("未")]
            wei = 7,
            [Description("申")]
            shen = 8,
            [Description("酉")]
            you = 9,
            [Description("戌")]
            xu = 10,
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

        public enum ShiShen
        {
            [Description("比肩")]
            bijian = 0,
            [Description("劫财")]
            jiecai = 1,
            [Description("正印")]
            zhengyin = 2,
            [Description("枭神")]
            pianyin = 3,
            [Description("食神")]
            shishen = 4,
            [Description("伤官")]
            shangguan = 5,
            [Description("正财")]
            zhengcai = 6,
            [Description("偏财")]
            piancai = 7,
            [Description("正官")]
            zhengguan = 8,
            [Description("七杀")]
            qisha = 9,

        };
        public static string GetShiShen(object v)
        {
            return GetDescription(typeof(ShiShen), v);
        }
        #endregion

        #region 公共
        
        public enum ShuXing
        {
            [Description("阴")]
            yin = 0,
            [Description("阳")]
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

        public enum Nayin
        {
            [Description("海中金")]
            jiazi = 10000,
            [Description("海中金")]
            yichou = 10101,
            [Description("炉中火")]
            bingyin = 10202,
            [Description("炉中火")]
            dingmao = 10303,
            [Description("大林木")]
            wuchen = 10404,
            [Description("大林木")]
            jisi = 10505,
            [Description("路旁土")]
            gengwu = 10606,
            [Description("路旁土")]
            xinwei = 10707,
            [Description("剑锋金")]
            renshen = 10808,
            [Description("剑锋金")]
            guiyou = 10909,
            [Description("山头火")]
            jiaxu = 10010,
            [Description("山头火")]
            yihai = 10111,
            [Description("涧下水")]
            bingzi = 10200,
            [Description("涧下水")]
            dingchou = 10301,
            [Description("城头土")]
            wuyin = 10402,
            [Description("城头土")]
            jimao = 10503,
            [Description("白蜡金")]
            gengchen = 10604,
            [Description("白蜡金")]
            xinsi = 10705,
            [Description("杨柳木")]
            renwu = 10806,
            [Description("杨柳木")]
            guiwei = 10907,
            [Description("泉中水")]
            jiashen = 10008,
            [Description("泉中水")]
            yiyou = 10109,
            [Description("屋上土")]
            bingxu = 10210,
            [Description("屋上土")]
            dinghai = 10311,
            [Description("霹雳火")]
            wuzi = 10400,
            [Description("霹雳火")]
            jichou = 10501,
            [Description("松柏木")]
            gengyin = 10602,
            [Description("松柏木")]
            xinmao = 10703,
            [Description("长流水")]
            renchen = 10804,
            [Description("长流水")]
            guisi = 10905,
            [Description("砂中金")]
            jiawu = 10006,
            [Description("砂中金")]
            yiwei = 10107,
            [Description("山下火")]
            bingshen = 10208,
            [Description("山下火")]
            dingyou = 10309,
            [Description("平地木")]
            wuxu = 10410,
            [Description("平地木")]
            jihai = 10511,
            [Description("壁上土")]
            gengzi = 10600,
            [Description("壁上土")]
            xinchou = 10701,
            [Description("金箔金")]
            renyin = 10802,
            [Description("金箔金")]
            guimao = 10903,
            [Description("覆灯火")]
            jiachen = 10004,
            [Description("覆灯火")]
            yisi = 10105,
            [Description("天河水")]
            bingwu = 10206,
            [Description("天河水")]
            dingwei = 10307,
            [Description("大驿土")]
            wushen = 10408,
            [Description("大驿土")]
            jiyou = 10509,
            [Description("钗钏金")]
            gengxu = 10610,
            [Description("钗钏金")]
            xinhai = 10711,
            [Description("桑松木")]
            renzi = 10800,
            [Description("桑松木")]
            guichou = 10901,
            [Description("大溪水")]
            jiayin = 10002,
            [Description("大溪水")]
            yimao = 10103,
            [Description("沙中土")]
            bingchen = 10204,
            [Description("沙中土")]
            dingsi = 10305,
            [Description("天上火")]
            wuwu = 10406,
            [Description("天上火")]
            jiwei = 10507,
            [Description("石榴木")]
            gengshen = 10608,
            [Description("石榴木")]
            xinyou = 10709,
            [Description("大海水")]
            renxu = 10810,
            [Description("大海水")]
            guihai = 10911,
        }
        public static string GetNayin(object v)
        {
            return GetDescription(typeof(Nayin), v);
        }

        public enum JieQi
        {
            [Description("小寒")]
            xiaohan = 0,
            [Description("立春")]
            lichun = 1,
            [Description("惊蛰")]
            jingzhe = 2,
            [Description("清明")]
            qingming = 3,
            [Description("立夏")]
            lixia = 4,
            [Description("芒种")]
            mangzhong = 5,
            [Description("小暑")]
            xiaoshu = 6,
            [Description("立秋")]
            liqiu = 7,
            [Description("白露")]
            bailu = 8,
            [Description("寒露")]
            hanlu = 9,
            [Description("立冬")]
            lidong = 10,
            [Description("大雪")]
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

        public enum ZhongQi
        {
            [Description("大寒")]
            dahan = 0,
            [Description("雨水")]
            yushui = 1,
            [Description("春分")]
            chunfen = 2,
            [Description("谷雨")]
            guyu = 3,
            [Description("小满")]
            xiaoman = 4,
            [Description("夏至")]
            xiazhi = 5,
            [Description("大暑")]
            dashu = 6,
            [Description("处暑")]
            chushu = 7,
            [Description("秋分")]
            qiufen = 8,
            [Description("霜降")]
            shuangjiang = 9,
            [Description("小雪")]
            xiaoxue = 10,
            [Description("冬至")]
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

        public enum AllJieQi
        {
            [Description("小寒")]
            xiaohan = 0,
            [Description("大寒")]
            dahan = 1,
            [Description("立春")]
            lichun = 2,
            [Description("雨水")]
            yushui = 3,
            [Description("惊蛰")]
            jingzhe = 4,
            [Description("春分")]
            chunfen = 5,
            [Description("清明")]
            qingming = 6,
            [Description("谷雨")]
            guyu = 7,
            [Description("立夏")]
            lixia = 8,
            [Description("小满")]
            xiaoman = 9,
            [Description("芒种")]
            mangzhong = 10,
            [Description("夏至")]
            xiazhi = 11,
            [Description("小暑")]
            xiaoshu = 12,
            [Description("大暑")]
            dashu = 13,
            [Description("立秋")]
            liqiu = 14,
            [Description("处暑")]
            chushu = 15,
            [Description("白露")]
            bailu = 16,
            [Description("秋分")]
            qiufen = 17,
            [Description("寒露")]
            hanlu = 18,
            [Description("霜降")]
            shuangjiang = 19,
            [Description("立冬")]
            lidong = 20,
            [Description("小雪")]
            xiaoxue = 21,
            [Description("大雪")]
            daxue = 22,
            [Description("冬至")]
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
        public enum NongliMonth
        {
            [Description("正")]
            jan = 1,
            [Description("二")]
            feb = 2,
            [Description("三")]
            mar = 3,
            [Description("四")]
            apr = 4,
            [Description("五")]
            may = 5,
            [Description("六")]
            jun = 6,
            [Description("七")]
            jul = 7,
            [Description("八")]
            aug = 8,
            [Description("九")]
            spet = 9,
            [Description("十")]
            oct = 10,
            [Description("十一")]
            nov = 11,
            [Description("腊")]
            dec = 12,
            [Description("润正")]
            janleap = 101,
            [Description("润二")]
            fableap = 102,
            [Description("润三")]
            marleap = 103,
            [Description("闰四")]
            aprleap = 104,
            [Description("闰五")]
            mayleap = 105,
            [Description("闰六")]
            junleap = 106,
            [Description("闰七")]
            julleap = 107,
            [Description("闰八")]
            augleap = 108,
            [Description("闰九")]
            septleap = 109,
            [Description("润十")]
            orcleap = 110,
            [Description("润十一")]
            novleap = 111,
            [Description("润腊")]
            decleap = 112,
        }
        public static string GetNongliMonth(object v)
        {
            return GetDescription(typeof(NongliMonth), v);
        }

        public enum NongliDay
        {
            [Description("初一")]
            a = 1,
            [Description("初二")]
            b = 2,
            [Description("初三")]
            c = 3,
            [Description("初四")]
            d = 4,
            [Description("初五")]
            e = 5,
            [Description("初六")]
            f = 6,
            [Description("初七")]
            g = 7,
            [Description("初八")]
            h = 8,
            [Description("初九")]
            i = 9,
            [Description("初十")]
            j = 10,
            [Description("十一")]
            k = 11,
            [Description("十二")]
            l = 12,
            [Description("十三")]
            m = 13,
            [Description("十四")]
            n = 14,
            [Description("十五")]
            o = 15,
            [Description("十六")]
            p = 16,
            [Description("十七")]
            q = 17,
            [Description("十八")]
            r = 18,
            [Description("十九")]
            s = 19,
            [Description("二十")]
            t = 20,
            [Description("廿一")]
            u = 21,
            [Description("廿二")]
            v = 22,
            [Description("廿三")]
            w = 23,
            [Description("廿四")]
            x = 24,
            [Description("廿五")]
            y = 25,
            [Description("廿六")]
            z = 26,
            [Description("廿七")]
            aa = 27,
            [Description("廿八")]
            bb = 28,
            [Description("廿九")]
            cc = 29,
            [Description("三十")]
            dd = 30
        }
        public static string GetNongliDay(object v)
        {
            return GetDescription(typeof(NongliDay), v);
        }
        #endregion

        #region 六爻基础
        public enum LYLiuQin
        {
            [Description("父母")]
            fumu = 0,
            [Description("官鬼")]
            guanggui = 1,
            [Description("兄弟")]
            xiongdi = 2,
            [Description("妻财")]
            qicai = 3,
            [Description("子孙")]
            zisun = 4
        }
        public static string GetLYLiuQin(object v)
        {
            return GetDescription(typeof(LYLiuQin), v);
        }
        #endregion

        #region 紫薇基础
        public enum ZiWeiRunYue
        {
            [Description("按当月算")]
            dang = 1,
            [Description("按下月算")]
            xia = 2,
            [Description("前15日算当月，后15日算下月")]
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

        public enum ZiWeiMingJu
        {
            [Description("水二局")]
            shui = 2,
            [Description("木三局")]
            mu = 3,
            [Description("金四局")]
            jin = 4,
            [Description("土五局")]
            tu = 5,
            [Description("火六局")]
            huo = 6
        }
        public static string GetZiWeiMingJu(object v)
        {
            return GetDescription(typeof(ZiWeiMingJu), v);
        }

        public enum ZiWeiGong
        {
            [Description("★命宫")]
            ming = 0,
            [Description("兄弟宫")]
            xiongdi = 1,
            [Description("夫妻宫")]
            fuqi = 2,
            [Description("子女宫")]
            zinv = 3,
            [Description("财帛宫")]
            caibo = 4,
            [Description("疾厄宫")]
            jie = 5,
            [Description("迁移宫")]
            qianyi = 6,
            [Description("仆役宫")]
            puyi = 7,
            [Description("官禄宫")]
            guanlu = 8,
            [Description("田宅宫")]
            tianzhai = 9,
            [Description("福德宫")]
            fude = 10,
            [Description("父母宫")]
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

        public enum ZiWeiStar
        {
            [Description("无")]
            wu = -1,
            //北斗主星
            [Description("紫薇")]
            ziwei = 0,
            [Description("天机")]
            tianji = 1,
            [Description("太阳")]
            taiyang = 2,
            [Description("武曲")]
            wuqu = 3,
            [Description("天同")]
            tiantong = 4,
            [Description("廉贞")]
            lianzhen = 5,
            //南斗主星
            [Description("天府")]
            tianfu = 6,
            [Description("太阴")]
            taiyin = 7,
            [Description("贪狼")]
            tanlang = 8,
            [Description("巨门")]
            jvmen = 9,
            [Description("天相")]
            tianxiang = 10,
            [Description("天梁")]
            tianliang = 11,
            [Description("七杀")]
            qisha = 12,
            [Description("破军")]
            pojun = 13,
            //6辅星
            [Description("文曲")]
            wenqu = 14,
            [Description("文昌")]
            wenchang = 15,
            [Description("左辅")]
            zuofu = 16,
            [Description("右弼")]
            youbi = 17,
            [Description("天魁")]
            tiankui = 18,
            [Description("天钺")]
            tianyue = 19,
            //禄存，天马
            [Description("禄存")]
            lucun = 20,
            [Description("天马")]
            tianma = 21,
            //四凶星
            [Description("擎羊")]
            qingyang = 22,
            [Description("陀罗")]
            tuoluo = 23,
            [Description("火星")]
            huoxing = 24,
            [Description("铃星")]
            lingxing = 25,
            //地空，地截
            [Description("地空")]
            dikong = 26,
            [Description("地劫")]
            dijie = 27,
            //贵人星
            [Description("天官")]
            tianguan = 28,
            [Description("天福")]
            tianfo = 29,
            //众星
            [Description("截空")]
            jiekong = 30,
            [Description("旬空")]
            xunkong = 31,

            [Description("红鸾")]
            hongluan = 32,
            [Description("天喜")]
            tianxi = 33,

            [Description("龙池")]
            longchi = 34,
            [Description("凤阁")]
            fengge = 35,
            [Description("三台")]
            santai = 36,
            [Description("八座")]
            bazuo = 37,

            [Description("天才")]
            tiancai = 38,
            [Description("天寿")]
            tianshou = 39,

            [Description("孤辰")]
            guchen = 40,
            [Description("寡宿")]
            guasu = 41,

            [Description("台辅")]
            taifu = 42,
            [Description("封诰")]
            fenggao = 43,

            [Description("天刑")]
            tianxing = 44,
            [Description("天姚")]
            tianyao = 45,
            [Description("解神")]
            jieshen = 46,
            [Description("天巫")]
            tianwu = 47,
            [Description("天月")]
            tianyu = 48,
            [Description("阴煞")]
            yinsha = 49,

            [Description("天伤")]
            tianshang = 50,
            [Description("天使")]
            tianshi = 51,
            [Description("恩光")]
            enguang = 52,
            [Description("天贵")]
            tiangui = 53,

            [Description("天厨")]
            tianchu = 54,
            [Description("天空")]
            tiankong = 55,
            [Description("天哭")]
            tianku = 56,
            [Description("天虚")]
            tianxu = 57,
            [Description("劫杀")]
            jiesha = 58,
            [Description("大耗")]
            dahao = 59,
            [Description("蜚廉")]
            chilian = 60,
            [Description("破碎")]
            posui = 61,
            [Description("华盖")]
            huagai = 62,
            [Description("咸池")]
            xianchi = 63,
            [Description("龙德")]
            longde = 64,
            [Description("月德")]
            yuede = 65,
            [Description("天德")]
            tiande = 66,
            [Description("年解")]
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

        public enum ZiWeiSihua
        {
            [Description("　")]
            none = 0,
            [Description("禄")]
            lu = 1,
            [Description("权")]
            quan = 2,
            [Description("科")]
            ke = 3,
            [Description("忌")]
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

        public enum ZiWeiMiaowang
        {
            [Description("　")]
            none = 0,
            [Description("庙")]
            miao = 1,
            [Description("旺")]
            wang = 2,
            [Description("平")]
            ping = 3,
            [Description("地")]
            di = 4,
            [Description("闲")]
            xia = 5,
            [Description("陷")]
            xian = 6
        }
        public static string GetZiWeiMiaowang(object v)
        {
            return GetDescription(typeof(ZiWeiMiaowang), v);
        }

        public enum ZiWeiChangSheng
        {
            [Description("长生")]
            changsheng = 0,
            [Description("沐浴")]
            muyu = 1,
            [Description("冠带")]
            guandai = 2,
            [Description("临官")]
            linguan = 3,
            [Description("帝旺")]
            diwang = 4,
            [Description("　衰")]
            shuai = 5,
            [Description("　病")]
            bing = 6,
            [Description("　死")]
            si = 7,
            [Description("　墓")]
            mu = 8,
            [Description("　绝")]
            jue = 9,
            [Description("　胎")]
            tai = 10,
            [Description("　养")]
            yang = 11
        }
        public static string GetZiWeiChangSheng(object v)
        {
            return GetDescription(typeof(ZiWeiChangSheng), v);
        }

        public enum ZiWeiTaiSui
        {
            [Description("岁建")]
            suijian = 0,
            [Description("晦气")]
            huiqi = 1,
            [Description("丧门")]
            sangmen = 2,
            [Description("贯索")]
            guansuo = 3,
            [Description("官符")]
            guanfu = 4,
            [Description("小耗")]
            xiaohao = 5,
            [Description("大耗")]
            dahao = 6,
            [Description("龙德")]
            longde = 7,
            [Description("白虎")]
            baihu = 8,
            [Description("天德")]
            tiande = 9,
            [Description("吊客")]
            diaoke = 10,
            [Description("病符")]
            bingfu = 11
        }
        public static string GetZiWeiTaiSui(object v)
        {
            return GetDescription(typeof(ZiWeiTaiSui), v);
        }

        public enum ZiWeiJiangQian
        {
            [Description("将星")]
            jiangxing = 0,
            [Description("攀鞍")]
            panan = 1,
            [Description("岁驿")]
            suiyi = 2,
            [Description("息神")]
            xishen = 3,
            [Description("华盖")]
            huagai = 4,
            [Description("劫煞")]
            jiesha = 5,
            [Description("灾煞")]
            zaisha = 6,
            [Description("天煞")]
            tiansha = 7,
            [Description("指背")]
            zhibei = 8,
            [Description("咸池")]
            xianchi = 9,
            [Description("月煞")]
            yuesha = 10,
            [Description("亡神")]
            wangshen = 11
        }
        public static string GetZiWeiJiangQian(object v)
        {
            return GetDescription(typeof(ZiWeiJiangQian), v);
        }

        public enum ZiWeiBoShi
        {
            [Description("博士")]
            boshi = 0,
            [Description("力士")]
            lishi = 1,
            [Description("青龙")]
            qinglong = 2,
            [Description("小耗")]
            xiaohao = 3,
            [Description("将军")]
            jiangjun = 4,
            [Description("奏书")]
            qinshu = 5,
            [Description("飞廉")]
            feilian = 6,
            [Description("喜神")]
            xishen = 7,
            [Description("病符")]
            bingfu = 8,
            [Description("大耗")]
            dahao = 9,
            [Description("伏兵")]
            fubing = 10,
            [Description("官府")]
            guanfu = 11
        }
        public static string GetZiWeiBoShi(object v)
        {
            return GetDescription(typeof(ZiWeiBoShi), v);
        }
        #endregion

        #region 占星术基础
        public enum AstroType
        {
            [Description("本命盘")]
            benming = 1,
            [Description("合盘")]
            hepan = 2,
            [Description("推运盘")]
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

        public enum AstroZuhe
        {
            [Description("比较盘(comparison)")]
            bijiao = 1,
            [Description("组合盘(composite)")]
            zuhe = 2,
            [Description("时空中点盘(midpoint)")]
            shikong = 3,
            [Description("合并盘(synastry)")]
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

        public enum AstroTuiyun
        {
            [Description("行运VS本命(Transit)")]
            xingyun = 1,
            [Description("月亮次限法(365.25636)")]
            cixian = 2,
            [Description("月亮三限法(29.530588)")]
            sanxian = 3,
            [Description("月亮三限法(27.321582)")]
            sanxian1 = 4,
            [Description("太阳反照法(Solar Return)")]
            rifanzhao = 5,
            [Description("月亮反照法(Lunar Return)")]
            yuefanzhao = 6,
            [Description("太阳弧法(Solar Arc)")]
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

        public enum AstroStar
        {
            [Description("太阳")]
            Sun = 1,
            [Description("月亮")]
            Moo = 2,
            [Description("水星")]
            Mer = 3,
            [Description("金星")]
            Ven = 4,
            [Description("火星")]
            Mar = 5,
            [Description("木星")]
            Jup = 6,
            [Description("土星")]
            Sat = 7,
            [Description("天王星")]
            Ura = 8,
            [Description("海王星")]
            Nep = 9,
            [Description("冥王星")]
            Plu = 10,
            [Description("凯龙星")]
            Chi = 11,
            [Description("谷神星")]
            Cer = 12,
            [Description("智神星")]
            Pal = 13,
            [Description("婚神星")]
            Jun = 14,
            [Description("灶神星")]
            Ves = 15,
            [Description("北交点")]
            Nod = 16,
            [Description("莉莉丝")]
            Lil = 17,
            [Description("福点")]
            For = 18,
            [Description("宿命点")]
            Ver = 19,
            [Description("东升点")]
            Eas = 20,
            [Description("上升点")]
            Asc = 21,
            [Description("二宫头")]
            Second = 22,
            [Description("三宫头")]
            Third = 23,
            [Description("天底")]
            Nad = 24,
            [Description("五宫头")]
            Fifth = 25,
            [Description("六宫头")]
            Sixth = 26,
            [Description("下降点")]
            Des = 27,
            [Description("八宫头")]
            Eighth = 28,
            [Description("九宫头")]
            Ninth = 29,
            [Description("中天")]
            Mid = 30,
            [Description("十一宫头")]
            Eleventh = 31,
            [Description("十二宫头")]
            Twelveth = 32,
            [Description("南交点")]
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

        public enum Constellation
        {
            [Description("白羊座")]
            Ari = 1,
            [Description("金牛座")]
            Tau = 2,
            [Description("双子座")]
            Gem = 3,
            [Description("巨蟹座")]
            Can = 4,
            [Description("狮子座")]
            Leo = 5,
            [Description("处女座")]
            Vir = 6,
            [Description("天秤座")]
            Lib = 7,
            [Description("天蝎座")]
            Sco = 8,
            [Description("射手座")]
            Sag = 9,
            [Description("摩羯座")]
            Cap = 10,
            [Description("水瓶座")]
            Aqu = 11,
            [Description("双鱼座")]
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

        public enum Element
        {
            [Description("风")]
            wind = 3,
            [Description("火")]
            fire = 1,
            [Description("水")]
            aqua = 4,
            [Description("土")]
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

        #endregion

    }
}
