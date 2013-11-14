using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.OleDb;


namespace PPLive.LiuYao
{
    /// <summary>
    /// PublicDeal 的摘要说明
    /// </summary>
    public class PublicDeal
    {
        public PublicDeal()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public string lypp (string nums, string years,string months,string days,string hours)
        {
            int year = Int16.Parse(years.ToString());
            int month = Int16.Parse(months.ToString());
            int day = Int16.Parse(days.ToString());
            int hour = Int16.Parse(hours.ToString());

            int num = Int32.Parse(nums.ToString());
            string[,] yao = new string[9, 7];

            bool[] tempbool = new bool[6];
            string[] mybazi = new string[10];
            LiuYao lypptemp = new LiuYao();
            lypptemp.NumToBool(num, ref tempbool, ref yao);
            lypptemp.BitToYao(tempbool[0], tempbool[1], tempbool[2], tempbool[3], tempbool[4], tempbool[5], ref yao);

            BaZi.BaZiBiz mybz = new BaZi.BaZiBiz();
            mybz.TimeToBaZi(new DateEntity(new DateTime(year, month, day, hour,0,0)),AppCmn.AppEnum.Gender.male);

            string ret = "";
            string shi = yao[2, Int32.Parse(yao[1, 0])];
            //PublicDeal.PublicDeal tempdeal = new PublicDeal.PublicDeal();
            
            //this.Label62.Text = tempdeal.LYWangShuai(shi, mybazi).ToString();
            string ying = yao[2, Int32.Parse(yao[2, 0])];
            int yingqr = YaoQR(yao, 2, Int32.Parse(yao[2, 0]), mybazi);
            if (YongJiShen(yao, 2, Int32.Parse(yao[2, 0]), mybazi, LYWangShuai(shi, mybazi)))
            {
                //this.Label63.Text = ying.ToString() + "为用神";
                if (yingqr >= 0)
                    ret = "非常好";
                if (yingqr >= -4 || yingqr <= -2)
                    ret = "好";
                if (yingqr >= -8 || yingqr <= -5)
                    ret = "一般";
                if (yingqr >= -14 || yingqr <= -9)
                    ret = "坏";
                if (yingqr <= -15)
                    ret = "非常坏";
            }


            else
            {
               // this.Label63.Text = ying.ToString() + "为忌神";
                //int yingqr = tempdeal.YaoQR(yao, 2, Int32.Parse(yao[2, 0]), mybazi);
                if (yingqr >= 0)
                    ret = "非常坏";
                if (yingqr >= -4 || yingqr <= -2)
                    ret = "坏";
                if (yingqr >= -8 || yingqr <= -5)
                    ret = "一般";
                if (yingqr >= -14 || yingqr <= -9)
                    ret = "好";
                if (yingqr <= -15)
                    ret = "非常好";
            }
            return ret;
        }






        /// <summary>
        /// 五行判断,A对B的作用,B的能量增减.
        /// 分同异: (同,异)帮,生,克,耗,泄,晦,脆,帮克,帮耗
        /// 分增减: 合(增,减),生合
        /// 其他: 对冲,互刑,相害,
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns></returns>
        public string GZWuXing(string a, string b)
        {
            string ret = "";
            if (a == "子")
            {
                if (b == "子")
                    ret = "同帮";
                else if (b == "丑")
                    ret = "合减";
                else if (b == "寅")
                    ret = "同生";
                else if (b == "卯")
                    ret = "异生";
                else if (b == "辰")
                    ret = "合减";
                else if (b == "巳")
                    ret = "异克";
                else if (b == "午")
                    ret = "对冲";
                else if (b == "未")
                    ret = "相害";
                else if (b == "申")
                    ret = "同泄";
                else if (b == "酉")
                    ret = "异泄";
                else if (b == "戌")
                    ret = "同耗";
                else if (b == "亥")
                    ret = "异帮";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "丑")
            {
                if (b == "子")
                    ret = "合减";
                else if (b == "丑")
                    ret = "同帮";
                else if (b == "寅")
                    ret = "异耗";
                else if (b == "卯")
                    ret = "同耗";
                else if (b == "辰")
                    ret = "异帮";
                else if (b == "巳")
                    ret = "同晦";
                else if (b == "午")
                    ret = "异晦";
                else if (b == "未")
                    ret = "对冲";
                else if (b == "申")
                    ret = "异生";
                else if (b == "酉")
                    ret = "合增";
                else if (b == "戌")
                    ret = "互刑";
                else if (b == "亥")
                    ret = "同帮克";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "寅")
            {
                if (b == "子")
                    ret = "同泄";
                else if (b == "丑")
                    ret = "异克";
                else if (b == "寅")
                    ret = "同帮";
                else if (b == "卯")
                    ret = "异帮";
                else if (b == "辰")
                    ret = "同克";
                else if (b == "巳")
                    ret = "异泄";
                else if (b == "午")
                    ret = "同泄";
                else if (b == "未")
                    ret = "异克";
                else if (b == "申")
                    ret = "对冲";
                else if (b == "酉")
                    ret = "异耗";
                else if (b == "戌")
                    ret = "同克";
                else if (b == "亥")
                    ret = "合减";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "卯")
            {
                if (b == "子")
                    ret = "异泄";
                else if (b == "丑")
                    ret = "同克";
                else if (b == "寅")
                    ret = "异帮";
                else if (b == "卯")
                    ret = "同帮";
                else if (b == "辰")
                    ret = "异克";
                else if (b == "巳")
                    ret = "同生";
                else if (b == "午")
                    ret = "异生";
                else if (b == "未")
                    ret = "合减";
                else if (b == "申")
                    ret = "异耗";
                else if (b == "酉")
                    ret = "对冲";
                else if (b == "戌")
                    ret = "合增";
                else if (b == "亥")
                    ret = "合减";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "辰")
            {
                if (b == "子")
                    ret = "合减";
                else if (b == "丑")
                    ret = "异帮";
                else if (b == "寅")
                    ret = "同耗";
                else if (b == "卯")
                    ret = "异耗";
                else if (b == "辰")
                    ret = "同帮";
                else if (b == "巳")
                    ret = "异晦";
                else if (b == "午")
                    ret = "同晦";
                else if (b == "未")
                    ret = "互刑";
                else if (b == "申")
                    ret = "同生";
                else if (b == "酉")
                    ret = "合增";
                else if (b == "戌")
                    ret = "对冲";
                else if (b == "亥")
                    ret = "异帮克";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "巳")
            {
                if (b == "子")
                    ret = "异耗";
                else if (b == "丑")
                    ret = "同生";
                else if (b == "寅")
                    ret = "异泄";
                else if (b == "卯")
                    ret = "同泄";
                else if (b == "辰")
                    ret = "异生";
                else if (b == "巳")
                    ret = "同帮";
                else if (b == "午")
                    ret = "异帮";
                else if (b == "未")
                    ret = "同生";
                else if (b == "申")
                    ret = "合减";
                else if (b == "酉")
                    ret = "合减";
                else if (b == "戌")
                    ret = "异生";
                else if (b == "亥")
                    ret = "对冲";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "午")
            {
                if (b == "子")
                    ret = "对冲";
                else if (b == "丑")
                    ret = "异生";
                else if (b == "寅")
                    ret = "同泄";
                else if (b == "卯")
                    ret = "异泄";
                else if (b == "辰")
                    ret = "同生";
                else if (b == "巳")
                    ret = "异帮";
                else if (b == "午")
                    ret = "同帮";
                else if (b == "未")
                    ret = "合增";
                else if (b == "申")
                    ret = "同克";
                else if (b == "酉")
                    ret = "异克";
                else if (b == "戌")
                    ret = "合增";
                else if (b == "亥")
                    ret = "异耗";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "未")
            {
                if (b == "子")
                    ret = "相害";
                else if (b == "丑")
                    ret = "对冲";
                else if (b == "寅")
                    ret = "异耗";
                else if (b == "卯")
                    ret = "合减";
                else if (b == "辰")
                    ret = "互刑";
                else if (b == "巳")
                    ret = "同生";
                else if (b == "午")
                    ret = "合减";
                else if (b == "未")
                    ret = "同帮";
                else if (b == "申")
                    ret = "异脆";
                else if (b == "酉")
                    ret = "同脆";
                else if (b == "戌")
                    ret = "异帮";
                else if (b == "亥")
                    ret = "同克";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "申")
            {
                if (b == "子")
                    ret = "同生";
                else if (b == "丑")
                    ret = "异泄";
                else if (b == "寅")
                    ret = "对冲";
                else if (b == "卯")
                    ret = "异克";
                else if (b == "辰")
                    ret = "同泄";
                else if (b == "巳")
                    ret = "合减";
                else if (b == "午")
                    ret = "同耗";
                else if (b == "未")
                    ret = "异泄";
                else if (b == "申")
                    ret = "同帮";
                else if (b == "酉")
                    ret = "异帮";
                else if (b == "戌")
                    ret = "同泄";
                else if (b == "亥")
                    ret = "异生";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "酉")
            {
                if (b == "子")
                    ret = "异生";
                else if (b == "丑")
                    ret = "合减";
                else if (b == "寅")
                    ret = "异克";
                else if (b == "卯")
                    ret = "对冲";
                else if (b == "辰")
                    ret = "合减";
                else if (b == "巳")
                    ret = "合减";
                else if (b == "午")
                    ret = "异耗";
                else if (b == "未")
                    ret = "同泄";
                else if (b == "申")
                    ret = "异帮";
                else if (b == "酉")
                    ret = "同帮";
                else if (b == "戌")
                    ret = "异泄";
                else if (b == "亥")
                    ret = "同生";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "戌")
            {
                if (b == "子")
                    ret = "同克";
                else if (b == "丑")
                    ret = "互刑";
                else if (b == "寅")
                    ret = "同耗";
                else if (b == "卯")
                    ret = "合减";
                else if (b == "辰")
                    ret = "对冲";
                else if (b == "巳")
                    ret = "异生";
                else if (b == "午")
                    ret = "合减";
                else if (b == "未")
                    ret = "异帮";
                else if (b == "申")
                    ret = "同脆";
                else if (b == "酉")
                    ret = "异脆";
                else if (b == "戌")
                    ret = "同帮";
                else if (b == "亥")
                    ret = "异克";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "亥")
            {
                if (b == "子")
                    ret = "异帮";
                else if (b == "丑")
                    ret = "同帮耗";
                else if (b == "寅")
                    ret = "合增";
                else if (b == "卯")
                    ret = "合增";
                else if (b == "辰")
                    ret = "异帮耗";
                else if (b == "巳")
                    ret = "对冲";
                else if (b == "午")
                    ret = "异克";
                else if (b == "未")
                    ret = "同耗";
                else if (b == "申")
                    ret = "异泄";
                else if (b == "酉")
                    ret = "同泄";
                else if (b == "戌")
                    ret = "异耗";
                else if (b == "亥")
                    ret = "同帮";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "甲")
            {
                if (b == "子")
                    ret = "同泄";
                else if (b == "丑")
                    ret = "异克";
                else if (b == "寅")
                    ret = "同帮";
                else if (b == "卯")
                    ret = "异帮";
                else if (b == "辰")
                    ret = "同克";
                else if (b == "巳")
                    ret = "异生";
                else if (b == "午")
                    ret = "同生";
                else if (b == "未")
                    ret = "异克";
                else if (b == "申")
                    ret = "同耗";
                else if (b == "酉")
                    ret = "异耗";
                else if (b == "戌")
                    ret = "同克";
                else if (b == "亥")
                    ret = "异泄";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "乙")
            {
                if (b == "子")
                    ret = "";
                else if (b == "丑")
                    ret = "";
                else if (b == "寅")
                    ret = "";
                else if (b == "卯")
                    ret = "";
                else if (b == "辰")
                    ret = "";
                else if (b == "巳")
                    ret = "";
                else if (b == "午")
                    ret = "";
                else if (b == "未")
                    ret = "";
                else if (b == "申")
                    ret = "";
                else if (b == "酉")
                    ret = "";
                else if (b == "戌")
                    ret = "";
                else if (b == "亥")
                    ret = "";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "丙")
            {
                if (b == "子")
                    ret = "同耗";
                else if (b == "丑")
                    ret = "异生";
                else if (b == "寅")
                    ret = "同泄";
                else if (b == "卯")
                    ret = "异泄";
                else if (b == "辰")
                    ret = "同生";
                else if (b == "巳")
                    ret = "异帮";
                else if (b == "午")
                    ret = "异帮";
                else if (b == "未")
                    ret = "同生";
                else if (b == "申")
                    ret = "异克";
                else if (b == "酉")
                    ret = "同克";
                else if (b == "戌")
                    ret = "异生";
                else if (b == "亥")
                    ret = "异耗";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "丁")
            {
                if (b == "子")
                    ret = "";
                else if (b == "丑")
                    ret = "";
                else if (b == "寅")
                    ret = "";
                else if (b == "卯")
                    ret = "";
                else if (b == "辰")
                    ret = "";
                else if (b == "巳")
                    ret = "";
                else if (b == "午")
                    ret = "";
                else if (b == "未")
                    ret = "";
                else if (b == "申")
                    ret = "";
                else if (b == "酉")
                    ret = "";
                else if (b == "戌")
                    ret = "";
                else if (b == "亥")
                    ret = "";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "戊")
            {
                if (b == "子")
                    ret = "同克";
                else if (b == "丑")
                    ret = "异帮";
                else if (b == "寅")
                    ret = "同耗";
                else if (b == "卯")
                    ret = "异耗";
                else if (b == "辰")
                    ret = "同帮";
                else if (b == "巳")
                    ret = "异泄";
                else if (b == "午")
                    ret = "同泄";
                else if (b == "未")
                    ret = "异帮";
                else if (b == "申")
                    ret = "同生";
                else if (b == "酉")
                    ret = "异生";
                else if (b == "戌")
                    ret = "同帮";
                else if (b == "亥")
                    ret = "异克";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "己")
            {
                if (b == "子")
                    ret = "";
                else if (b == "丑")
                    ret = "";
                else if (b == "寅")
                    ret = "";
                else if (b == "卯")
                    ret = "";
                else if (b == "辰")
                    ret = "";
                else if (b == "巳")
                    ret = "";
                else if (b == "午")
                    ret = "";
                else if (b == "未")
                    ret = "";
                else if (b == "申")
                    ret = "";
                else if (b == "酉")
                    ret = "";
                else if (b == "戌")
                    ret = "";
                else if (b == "亥")
                    ret = "";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "庚")
            {
                if (b == "子")
                    ret = "同生";
                else if (b == "丑")
                    ret = "异泄";
                else if (b == "寅")
                    ret = "同克";
                else if (b == "卯")
                    ret = "异克";
                else if (b == "辰")
                    ret = "同泄";
                else if (b == "巳")
                    ret = "异耗";
                else if (b == "午")
                    ret = "同耗";
                else if (b == "未")
                    ret = "异泄";
                else if (b == "申")
                    ret = "同帮";
                else if (b == "酉")
                    ret = "异帮";
                else if (b == "戌")
                    ret = "同泄";
                else if (b == "亥")
                    ret = "异生";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "辛")
            {
                if (b == "子")
                    ret = "";
                else if (b == "丑")
                    ret = "";
                else if (b == "寅")
                    ret = "";
                else if (b == "卯")
                    ret = "";
                else if (b == "辰")
                    ret = "";
                else if (b == "巳")
                    ret = "";
                else if (b == "午")
                    ret = "";
                else if (b == "未")
                    ret = "";
                else if (b == "申")
                    ret = "";
                else if (b == "酉")
                    ret = "";
                else if (b == "戌")
                    ret = "";
                else if (b == "亥")
                    ret = "";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "壬")
            {
                if (b == "子")
                    ret = "同帮";
                else if (b == "丑")
                    ret = "异耗";
                else if (b == "寅")
                    ret = "同生";
                else if (b == "卯")
                    ret = "异生";
                else if (b == "辰")
                    ret = "同耗";
                else if (b == "巳")
                    ret = "异克";
                else if (b == "午")
                    ret = "同克";
                else if (b == "未")
                    ret = "异耗";
                else if (b == "申")
                    ret = "同泄";
                else if (b == "酉")
                    ret = "异泄";
                else if (b == "戌")
                    ret = "同耗";
                else if (b == "亥")
                    ret = "异帮";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            else if (a == "癸")
            {
                if (b == "子")
                    ret = "";
                else if (b == "丑")
                    ret = "";
                else if (b == "寅")
                    ret = "";
                else if (b == "卯")
                    ret = "";
                else if (b == "辰")
                    ret = "";
                else if (b == "巳")
                    ret = "";
                else if (b == "午")
                    ret = "";
                else if (b == "未")
                    ret = "";
                else if (b == "申")
                    ret = "";
                else if (b == "酉")
                    ret = "";
                else if (b == "戌")
                    ret = "";
                else if (b == "亥")
                    ret = "";
                else if (b == "甲")
                    ret = "";
                else if (b == "乙")
                    ret = "";
                else if (b == "丙")
                    ret = "";
                else if (b == "丁")
                    ret = "";
                else if (b == "戊")
                    ret = "";
                else if (b == "己")
                    ret = "";
                else if (b == "庚")
                    ret = "";
                else if (b == "辛")
                    ret = "";
                else if (b == "壬")
                    ret = "";
                else if (b == "癸")
                    ret = "";

            }
            return ret;

        }


        /// <summary>
        /// 判断是否旬空,返回BOOL值
        /// </summary>
        /// <param name="yao">某爻值</param>
        /// <param name="xuna">旬空值1</param>
        /// <param name="xunb">旬空值2</param>
        /// <returns></returns>
        public bool XunKong(string yao, string xuna, string xunb)
        {
            if (yao == xuna || yao == xunb)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断是否伏吟,返回BOOL值
        /// </summary>
        /// <param name="yao">全卦</param>
        /// <param name="a">列数,yao [a,*]</param>
        /// <param name="b">列数,yao [*,b]</param>
        /// xuna xunb为旬空值
        /// <returns></returns>
        public bool FuYing(ref string[,] yao, int a , int b, string [] bazi)
        {
            int temp = b;
            bool ret = false;
            if (temp == 6)
                temp = 1;
            else
                temp = temp + 1;
            if (XunKong(yao[a, temp], bazi[8], bazi[9]))
            {
                if (temp == 6)
                    temp = 1;
                else
                    temp = temp + 1;
            }
            if (XunKong(yao[a, temp], bazi[8], bazi[9]))
            {
                if (temp == 6)
                    temp = 1;
                else
                    temp = temp + 1;
            }
            if (yao[a, temp] == yao[a, b])
            {
                ret = true;
                yao[0,0] = yao[a, b];
            }
            temp = b;
            if (temp == 1)
                temp = 6;
            else
                temp = temp - 1;
            if (XunKong(yao[a, temp], bazi[8], bazi[9]))
            {
                if (temp == 1)
                    temp = 6;
                else
                    temp = temp - 1;
            }
            if (XunKong(yao[a, temp], bazi[8], bazi[9]))
            {
                if (temp == 1)
                    temp = 6;
                else
                    temp = temp - 1;
            }
            if (yao[a, temp] == yao[a, b])
            {
                ret = true;
                yao[0, 0] = yao[a, b];
            }
            return ret;
        }



        /// <summary>
        /// 判卦旺衰,返回"从弱,弱,旺,从强"
        /// </summary>
        /// <param name="shi">世爻</param>
        /// <param name="bazi">日八字</param>
        /// <returns></returns>
        public string LYWangShuai(string shi, string[] bazi)
        {
            string wangshuai = "";
            int tempcong = 0;
            string year = GZWuXing(bazi[1], shi);
            string month = GZWuXing(bazi[3], shi);

            if (((LYLiangHua(GZWuXing(bazi[1], bazi[3])) == "-" || LYLiangHua(GZWuXing(bazi[1], bazi[3])) == "生合减" || LYLiangHua(GZWuXing(bazi[1], bazi[3])) == "同帮克" || LYLiangHua(GZWuXing(bazi[1], bazi[3])) == "异帮克") && (LYLiangHua(GZWuXing(bazi[5], bazi[3])) == "-" || LYLiangHua(GZWuXing(bazi[5], bazi[3])) == "生合减" || LYLiangHua(GZWuXing(bazi[5], bazi[3])) == "同帮克" || LYLiangHua(GZWuXing(bazi[5], bazi[3])) == "异帮克")) || XunKong(bazi[3], bazi[8], bazi[9]))
            {
                if (LYLiangHua(year) == "+")//(LYLiangHua(year) = "-" || LYLiangHua(year) = "生合增" || LYLiangHua(year) = "生合减" || LYLiangHua(year) = "同耗"|| LYLiangHua(year) = "异耗" || LYLiangHua(year) = "同帮克" || LYLiangHua(year) = "异帮克" || LYLiangHua(year) = "同帮耗" || LYLiangHua(year) = "异帮耗"  )
                    tempcong++;
                else
                    tempcong--;
            }
            else
            {
                if (LYLiangHua(month) == "+" || LYLiangHua(month) == "生合增")
                    tempcong++;
                else
                    tempcong--;
                if (LYLiangHua(year) == "+" || LYLiangHua(month) == "生合增")
                    tempcong++;
                else
                    tempcong--;
            }
            if (NGHeShen(bazi[0], shi) == "+")
            {
                if (tempcong >= 1)
                    wangshuai = "从强";
                else
                    wangshuai = "旺";
            }
            if (NGHeShen(bazi[0], shi) == "-")
            {
                if (tempcong <= -1)
                    wangshuai = "从弱";
                else
                    wangshuai = "弱";
            }
            return wangshuai;

        }





        /// <summary>
        /// 六爻五行量化判断,返回+ ,-,(同,异)耗,(同,异)帮克,(同,异)帮耗,生合(增减)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string LYLiangHua(string a)
        {
            string ret = a;
            if (a == "同帮" || a == "异帮" || a == "同生" || a == "异生" || a == "合生")
                ret = "+";
            if (a == "同克" || a == "异克" || a == "同晦" || a == "异晦" || a == "同脆" || a == "异脆" || a == "同泄" || a == "异泄" || a == "对冲" || a == "互刑" || a == "相害" || a == "合减")
                ret = "-";
            return ret;
        }




        /// <summary>
        /// 六爻五行量化判断特别针对爻间判断,返回+ ,-,(同,异)耗,对冲
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string YaoLiangHua(string a)
        {
            string ret = a;
            if (a == "同帮" || a == "异帮" || a == "同生" || a == "异生" || a == "合生" || a == "同帮克" || a == "同帮耗" || a == "异帮克" || a == "异帮耗" || a == "生合增")
                ret = "+";
            if (a == "同克" || a == "异克" || a == "同晦" || a == "异晦" || a == "同脆" || a == "异脆" || a == "同泄" || a == "异泄" || a == "互刑" || a == "相害" || a == "合减" || a == "生合减")
                ret = "-";
            return ret;
        }


        /// <summary>
        /// 判断爻是用神还是忌神,返回BOOL,用为True,忌为False;
        /// </summary>
        /// <param name="shi">世爻</param>
        /// <param name="yao">某爻</param>
        /// <returns></returns>
        public bool YongJiShen(string[,] yao, int a,int b, string[] bazi,string wangshuai)
        { 
            bool ret = false;
            string shi = yao[2,Int32.Parse(yao[1,0])];
            string temp = YaoLiangHua(GZWuXing(yao[a, b], shi));
            if(temp =="+" || temp =="同帮克" || temp =="异帮克" || temp =="同帮耗" || temp =="同帮耗" || temp =="生合增")
               ret = true;
           if (XunKong(yao[a, b], bazi[8], bazi[9]) && (FuYing(ref yao, a, b, bazi) == false || yao[0,0] != yao[a,b]))
               ret = notbool(ret);
           if (XunKong(yao[a, b], bazi[8], bazi[9]) == false && (FuYing(ref yao, a, b, bazi)|| yao[0,0] == yao[a,b]))
           {
               if (temp != "对冲")
                   ret = notbool(ret);
           }
           if (FuYing(ref yao, 2, Int32.Parse(yao[1, 0]), bazi) || yao[2, Int32.Parse(yao[1, 0])] == yao[0,0])
               ret = notbool(ret);

           if (wangshuai == "从弱" || wangshuai == "旺")
               ret = notbool(ret);
           return ret;
        }







        public bool YaoYongJi(string a, string[,] yao, string[] bazi, string wangshuai)
        {
            bool ret = false;
            string shi = yao[2, Int32.Parse(yao[1, 0])];
            string temp = YaoLiangHua(GZWuXing(a, shi));
            if (temp == "+" || temp == "生合增")
                ret = true;
            if (XunKong(a, bazi[8], bazi[9]) && yao[0, 0] != a)
                ret = notbool(ret);
            if (XunKong(a, bazi[8], bazi[9]) == false && yao[0, 0] == a)
            {
                if (temp != "对冲")
                    ret = notbool(ret);
            }
            if (FuYing(ref yao, 2, Int32.Parse(yao[1, 0]), bazi) || yao[2, Int32.Parse(yao[1, 0])] == yao[0, 0])
                ret = notbool(ret);

            if (wangshuai == "从弱" || wangshuai == "旺")
                ret = notbool(ret);
            return ret;
        }



        /// <summary>
        /// 判断爻的强弱,受各方影响,返回一个整数量值
        /// </summary>
        /// <param name="yao">全卦</param>
        /// <param name="a">爻的列yao [a,*]</param>
        /// <param name="b">爻的行yao [*,b]</param>
        /// <returns></returns>
        public int YaoQR(string[,] yao, int a, int b,string[] bazi)
        { 
            int ret = 0;
            bool tempret = false;
            string temp = "";

            if (a != 5)
            {
                if (a == 2)
                    temp = yao[5, b];
                if (a == 7)
                    temp = yao[5, b];
                if (XunKong(temp, bazi[8], bazi[9]) == false)
                {
                    if (YaoLiangHua(GZWuXing(temp, yao[a, b])) == "+")
                        tempret = true;
                    if (FuYing(ref yao, 5, b, bazi) || yao[5, b] == yao[0, 0])
                    {
                        if (YaoLiangHua(GZWuXing(temp, yao[a, b])) != "对冲")
                            tempret = notbool(tempret);
                    }
                    if (FuYing(ref yao, 2, Int32.Parse(yao[1, 0]), bazi) || yao[2, Int32.Parse(yao[1, 0])] == yao[0, 0])
                        tempret = notbool(tempret);

                }

                if (tempret)
                    ret++;
                if (tempret == false && XunKong(temp, bazi[8], bazi[9]) == false && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "同耗" && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "异耗")
                    ret = ret - 5;
                tempret = false;
            }



            if (a != 7)
            {
                if (a == 2)
                    temp = yao[7, b];
                if (a == 5)
                    temp = yao[7, b];
                if (XunKong(temp, bazi[8], bazi[9]) == false)
                {
                    if (YaoLiangHua(GZWuXing(temp, yao[a, b])) == "+")
                        tempret = true;
                    if (FuYing(ref yao, 7, b, bazi) || yao[7, b] == yao[0, 0])
                    {
                        if (YaoLiangHua(GZWuXing(temp, yao[a, b])) != "对冲")
                            tempret = notbool(tempret);
                    }
                    if (FuYing(ref yao, 2, Int32.Parse(yao[1, 0]), bazi) || yao[2, Int32.Parse(yao[1, 0])] == yao[0, 0])
                        tempret = notbool(tempret);

                }

                if (tempret && ifbian(yao))
                    ret++;
                if (tempret == false && ifbian(yao) && XunKong(temp, bazi[8], bazi[9]) == false && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "同耗" && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "异耗")
                    ret = ret - 5;
                tempret = false;
            }




            if (a != 2)
            {

                if (a == 5)
                    temp = yao[2, b];
                if (a == 7)
                    temp = yao[2, b];
                if (XunKong(temp, bazi[8], bazi[9]) == false)
                {
                    if (YaoLiangHua(GZWuXing(temp, yao[a, b])) == "+")
                        tempret = true;
                    if (FuYing(ref yao, 2, b, bazi) || yao[2, b] == yao[0, 0])
                    {
                        if (YaoLiangHua(GZWuXing(temp, yao[a, b])) != "对冲")
                            tempret = notbool(tempret);
                    }
                    if (FuYing(ref yao, 2, Int32.Parse(yao[1, 0]), bazi) || yao[2, Int32.Parse(yao[1, 0])] == yao[0, 0])
                        tempret = notbool(tempret);

                }
                if (tempret)
                    ret++;
                if (tempret == false && XunKong(temp, bazi[8], bazi[9]) == false && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "同耗" && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "异耗")
                    ret = ret - 5;
                tempret = false;
            }

            //上下

            int i = b;
            if (i == 6)
                i = 1;
            else
                i++;
            if(XunKong(yao[a,i],bazi[8],bazi[9]))
            {
                if (i == 6)
                    i = 1;
                else
                    i++;
            }
            if (XunKong(yao[a, i], bazi[8], bazi[9]))
            {
                if (i == 6)
                    i = 1;
                else
                    i++;
            }
            
            if (YaoLiangHua(GZWuXing(yao[a,i], yao[a, b])) == "+")
                 tempret = true;
            if (FuYing(ref yao, a, i, bazi) || yao[a, i] == yao[0, 0])
            {
                 if (YaoLiangHua(GZWuXing(yao[a,i], yao[a, b])) != "对冲")
                       tempret = notbool(tempret);
            }
            if (FuYing(ref yao, 2, Int32.Parse(yao[1, 0]), bazi) || yao[2, Int32.Parse(yao[1, 0])] == yao[0, 0])
                 tempret = notbool(tempret);
             if (tempret)
                 ret++;
             if (tempret == false && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "同耗" && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "异耗")
                 ret = ret - 5;
             tempret = false;


             i = b;
             if (i == 1)
                 i = 6;
             else
                 i--;
             if (XunKong(yao[a, i], bazi[8], bazi[9]))
             {
                 if (i == 1)
                     i = 6;
                 else
                     i--;
             }
             if (XunKong(yao[a, i], bazi[8], bazi[9]))
             {
                 if (i == 1)
                     i = 6;
                 else
                     i--;
             }

             if (YaoLiangHua(GZWuXing(yao[a, i], yao[a, b])) == "+")
                 tempret = true;
             if (FuYing(ref yao, a, i, bazi) || yao[a, i] == yao[0, 0])
             {
                 if (YaoLiangHua(GZWuXing(yao[a, i], yao[a, b])) != "对冲")
                     tempret = notbool(tempret);
             }
             if (FuYing(ref yao, 2, Int32.Parse(yao[1, 0]), bazi) || yao[2, Int32.Parse(yao[1, 0])] == yao[0, 0])
                 tempret = notbool(tempret);
             if (tempret)
                 ret++;
             if (tempret == false && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "同耗" && YaoLiangHua(GZWuXing(temp, yao[a, b])) != "异耗")
                 ret = ret - 5;
             tempret = false;
            
           return ret;
    }


        /// <summary>
        /// 判断年干合神对世爻的旺衰,返回旺衰
        /// </summary>
        /// <param name="yearG">年干</param>
        /// <param name="shi">世爻</param>
        /// <returns></returns>
        public string NGHeShen(string yearG, string shi)
        {
            string temp = "";
            if (yearG == "甲" || yearG == "己")
                temp = GZWuXing("戊", shi);
            if (yearG == "乙" || yearG == "庚")
                temp = GZWuXing("庚", shi);
            if (yearG == "丙" || yearG == "辛")
                temp = GZWuXing("壬", shi);
            if (yearG == "丁" || yearG == "壬")
                temp = GZWuXing("甲", shi);
            if (yearG == "戊" || yearG == "癸")
                temp = GZWuXing("丙", shi);
            if (temp == "同生" || temp == "异生" || temp == "同帮" || temp == "异帮")
                temp = "+";
            else
                temp = "-";
            return temp;
        }



        public void FindYao(string[,] yao, string a, ref int[] yaohao)
        {
            int temp = 0;
            int shi;
            for (int i = 1; i <= 6; i++)
            {
                if ((yao[0, i] == "1" && Int32.Parse(yao[1, 0]) != i) || Int32.Parse(yao[2, 0]) == i)
                {
                    if (yao[2, i] == a)
                    {
                        yaohao[temp++] = 2;
                        yaohao[temp++] = i;
                    }
                }
            }
                
                
                    if (yao[1, 0] == "1")
                        shi = 6;
                    else
                        shi = Int32.Parse(yao[1, 0]) - 1;
                    if (yao[2, shi] == a)
                    {
                        yaohao[temp++] = 2;
                        yaohao[temp++] = shi;
                    }

                    if (yao[1, 0] == "6")
                        shi = 1;
                    else
                        shi = Int32.Parse(yao[1, 0]) + 1;
                    if (yao[2, shi] == a)
                    {
                        yaohao[temp++] = 2;
                        yaohao[temp++] = shi;
                    }
                
            
                if (yao[5, Int32.Parse(yao[1, 0])] == a)
                {
                    yaohao[temp++] = 5;
                    yaohao[temp++] = Int32.Parse(yao[1, 0]);
                }
                if (yao[7, Int32.Parse(yao[1, 0])] == a && ifbian(yao))
                {
                    yaohao[temp++] = 7;
                    yaohao[temp++] = Int32.Parse(yao[1, 0]);
                }
            
        }
        
        
        
        private bool notbool(bool a)
        {
            bool ret;
            if (a)
                ret = false;
            else
                ret = true;
            return ret;
        }


        private bool ifbian(string[,] yao)
        {
            bool ret = false;
            for (int i = 1; i <= 6; i++)
            {
                if (yao[0, i] == "1")
                    ret = true;
            }
            return ret;
        }
/// <summary>
/// 返回1为弱,从强,0为强,从弱
/// </summary>
/// <param name="name"></param>
/// <returns></returns>
        public string fixsstrong(string name,string[] bazi)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ppconn"].ConnectionString;
            string cmdTexta = "SELECT * FROM Sign_64 WHERE name = '" + name.ToString() +"'";


            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand commanda = new OleDbCommand(cmdTexta, conn);
            conn.Open();

            OleDbDataReader myreadera = commanda.ExecuteReader();

            myreadera.Read();
            
            string strong = myreadera["strong"].ToString();
            if (converse(name, bazi[8]))
            {
                if (strong == "弱" || strong == "从强")
                    strong = "旺";
                if (strong == "旺" || strong == "从弱")
                    strong = "弱";
            }
            

            conn.Close();
            conn.Dispose();
            return strong;
        }

        public bool converse(string name, string kong)
        {
            bool ret = false;
            if (name == "坎为水" && kong == "寅" )
                ret = true;
            else if (name == "山地剥" && (kong == "辰" || kong == "戌"))
                ret = true;
            

            else if (name == "天风姤" && kong == "申")
                ret = true;
            else if (name == "地风升" && (kong == "子" || kong == "戌" || kong == "申"))
                ret = true;
            else if (name == "地火明夷" && kong == "子")
                ret = true;
            else if (name == "山泽损" && kong == "戌")
                ret = true;


            else if (name == "择水困" && (kong == "申" || kong == "辰" || kong == "午"))
                ret = true;
            else if (name == "水雷屯" && (kong == "子" || kong == "申" || kong == "辰"))
                ret = true;
            else if (name == "艮为山" && (kong == "子" || kong == "戌" || kong == "申"))
                ret = true;
            else if (name == "山天大畜" && kong == "辰")
                ret = true;


            else if (name == "天地否" && kong == "申")
                ret = true;
            else if (name == "巽为风" && (kong == "寅" || kong == "申" || kong == "子"))
                ret = true;
            else if (name == "山火贲" && kong == "戌")
                ret = true;
            else if (name == "水地比" && kong == "辰")
                ret = true;


            else if (name == "火天大有" && kong == "申")
                ret = true;
            else if (name == "火山旅" && (kong == "申" || kong == "午"))
                ret = true;
            else if (name == "地天泰" && (kong == "申" || kong == "子" || kong == "戌"))
                ret = true;


            else if (name == "泽地淬" && (kong == "申" || kong == "午" || kong == "戌"))
                ret = true;
            else if (name == "离为火" && kong == "寅")
                ret = true;
            else if (name == "风水涣" && (kong == "寅" || kong == "午"))
                ret = true;
            else if (name == "水泽节" && kong == "子")
                ret = true;


            else if (name == "天山遁" && (kong == "辰" || kong == "午" || kong == "戌" || kong == "申"))
                ret = true;
            else if (name == "雷山小过" && kong == "申")
                ret = true;
            else if (name == "火水未济" && (kong == "寅" || kong == "午" || kong == "申"))
                ret = true;
            else if (name == "天水讼" && (kong == "戌" || kong == "申"))
                ret = true;
            else if (name == "天雷无妄" && (kong == "午" || kong == "申"))
                ret = true;
            else if (name == "地水师" && (kong == "戌" || kong == "辰" || kong == "申"))
                ret = true;
            else if (name == "雷天大壮" && kong == "午")
                ret = true;


            else if (name == "风地观" && (kong == "午" || kong == "辰" || kong == "寅"))
                ret = true;
            else if (name == "兑为泽" && kong == "午")
                ret = true;
            else if (name == "雷地豫" && kong == "申")
                ret = true;
            else if (name == "火雷噬嗑" && (kong == "午" || kong == "子" || kong == "申"))
                ret = true;


            else if (name == "水山蹇" && kong == "午")
                ret = true;
            else if (name == "天泽履" && (kong == "午" || kong == "辰" || kong == "戌"))
                ret = true;
            else if (name == "风山渐" && (kong == "辰" || kong == "申"))
                ret = true;
            else if (name == "水天需" && kong == "申")
                ret = true;


            else if (name == "火地晋" && kong == "午")
                ret = true;
            else if (name == "山风蛊" && (kong == "寅" || kong == "戌"))
                ret = true;
            else if (name == "雷风恒" && (kong == "午" || kong == "申" || kong == "戌"))
                ret = true;


            else if (name == "乾为天" && (kong == "午" || kong == "申" || kong == "子"))
                ret = true;
            else if (name == "山水蒙" && kong == "戌")
                ret = true;
            else if (name == "震为雷" && (kong == "戌" || kong == "午"))
                ret = true;
            else if (name == "山雷颐" && (kong == "子" || kong == "辰"))
                ret = true;
            else if (name == "水风井" && (kong == "子" || kong == "申"))
                ret = true;


            else if (name == "火风鼎" && (kong == "子" || kong == "申"))
                ret = true;
            else if (name == "天火同人" && kong == "申")
                ret = true;
            else if (name == "泽风大过" && kong == "申")
                ret = true;
            else if (name == "水火既济" && (kong == "子" || kong == "申"))
                ret = true;
            return ret;
        }

        public string except(string name, string[] bazi)
        {
            string ret ="";
            if(name =="坎为水" && bazi[8]=="午" && bazi[5]=="酉")
                ret = "好";
            else if (name == "山地剥" && bazi[8] == "午" && bazi[5] == "酉")
                ret = "好";
            else if (name == "风天小畜" && bazi[8] == "午" && bazi[5] == "酉")
                ret = "好";


            else if (name == "地火明夷" && bazi[8] == "午" && bazi[5] == "酉")
                ret = "好";
            else if (name == "山泽损" && bazi[8] == "午" && bazi[5] == "酉")
                ret = "好";


            else if (name == "水雷屯" && bazi[8] == "申" && bazi[5] == "未")
                ret = "好";


            else if (name == "巽为风" && bazi[8] == "午" && bazi[5] == "寅" && bazi[3] == "申")
                ret = "好";


            else if (name == "火天大有" && bazi[8] == "戌" && bazi[5] == "丑" && bazi[3] == "未")
                ret = "好";
            else if (name == "风雷益" && bazi[8] == "戌" && bazi[5] == "丑" && bazi[3] == "未")
                ret = "好";
            else if (name == "地天泰" && bazi[8] == "午" && bazi[5] == "申")
                ret = "好";


            else if (name == "雷山小过" && ((bazi[8] == "子" && bazi[5] == "寅") || (bazi[8] == "申" && (bazi[5] == "卯" || bazi[5] == "未"))))
                ret = "好";
            else if (name == "火水未济" && ((bazi[8] == "子" && bazi[5] == "戌") || (bazi[8] == "申" && (bazi[5] == "卯" || bazi[5] == "未"))))
                ret = "好";


            else if (name == "风地观" && ((bazi[8] == "申" && bazi[5] == "辰") || (bazi[8] == "子" && bazi[5] == "寅" )))
                ret = "好";
            else if (name == "兑为泽" && bazi[8] == "子" && bazi[5] == "未")
                ret = "好";
            else if (name == "火雷噬嗑" && bazi[8] == "戌" && bazi[5] == "巳")
                ret = "好";


            else if (name == "水天需" && bazi[8] == "申" && bazi[5] == "丑")
                ret = "好";


            else if (name == "火地晋" && bazi[8] == "午" && bazi[5] == "寅")
                ret = "好";
            else if (name == "山风蛊" && bazi[8] == "申" && bazi[5] == "丑")
                ret = "好";
            else if (name == "火泽睽" && bazi[8] == "戌" && bazi[5] == "丑" && bazi[3] == "未")
                ret = "好";


            else if (name == "乾为天" && ((bazi[8] == "子" && bazi[5] == "寅") || (bazi[8] == "午" && bazi[5] == "申")))
                ret = "好";
            else if (name == "山水蒙" && (bazi[8] == "子" || bazi[8] == "戌") && (bazi[5] == "寅" || bazi[5] == "卯"))
                ret = "好";
            else if (name == "震为雷" && bazi[8] == "午" && bazi[5] == "戌")
                ret = "好";
            else if (name == "山雷颐" && bazi[8] == "午" && bazi[5] == "戌")
                ret = "好";
            else if (name == "水风井" && bazi[8] == "寅" && bazi[5] == "戌")
                ret = "好";


            else if (name == "火风鼎" && bazi[8] == "申" && (bazi[5] == "戌" || bazi[5] == "亥"))
                ret = "好";
            else if (name == "泽风大过" && bazi[8] == "申" && bazi[5] == "亥")
                ret = "好";
            else if (name == "水火既济" && bazi[8] == "辰" && bazi[5] == "丑")
                ret = "好";
            return ret;
        }

        public bool newifgood(string[,] yao, string[] bazi)
        {
            string name = yao[3, 0].ToString();
            string shi = yao[2, Int32.Parse(yao[1, 0])];
            bool ret = false;
            if (except(name, bazi) == "好")
            {
                ret = true;
            }
            else
            {
                string strong = fixsstrong(name, bazi);

                
                
                string temp = YaoLiangHua(GZWuXing(bazi[5], shi));
                if (temp == "+" || temp == "同帮克" || temp == "异帮克" || temp == "同帮耗" || temp == "同帮耗" || temp == "生合增")
                    ret = true;
                if (XunKong(bazi[5], bazi[8], bazi[9]))
                    ret = notbool(ret);
                if (strong == "从弱" || strong == "旺")
                    ret = notbool(ret);
            }
            return ret;
        }

    }

}