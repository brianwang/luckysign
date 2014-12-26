using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLive
{
    public class WuXing
    {
        /// <summary>
        /// 五行判断,A对B的作用,B的能量增减.
        /// 分同异: (同,异)帮,生,克,耗,泄,晦,脆,帮克,帮耗
        /// 分增减: 合(增,减),生合
        /// 其他: 对冲,互刑,相害,
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns></returns>
        public string GZWuXing(PublicValue.DiZhi a, PublicValue.DiZhi b)
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

        private bool notbool(bool a)
        {
            bool ret;
            if (a)
                ret = false;
            else
                ret = true;
            return ret;
        }

    }
}
