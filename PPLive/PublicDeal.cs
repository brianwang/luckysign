using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLive
{
    public class PublicDeal
    {
        private PublicDeal()
        {
        }
        private static PublicDeal _instance;
        public static PublicDeal GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PublicDeal();
            }
            return _instance;
        }

        // <summary>
        // 五行判断,A对B的作用,B的能量增减.
        // 分同异: (同,异)帮,生,克,耗,泄,晦,脆,帮克,帮耗
        // 分增减: 合(增,减),生合
        // 其他: 对冲,互刑,相害,
        // </summary>
        // <param name="a">A</param>
        // <param name="b">B</param>
        // <returns></returns>
        // 


        /// <summary>
        /// source对于target是什么，source对于target的影响
        /// </summary>
        /// <param name="input">sourceType与targetType均不可为2</param>
        /// <returns></returns>
        public WuXingRelation GZWuXing(WuXingRelation input)
        {
            #region 天干与天干
            if (input.SourceType == 0 && input.TargetType == 0)
            {
                switch (input.SourceTG)
                {
                    case PublicValue.TianGan.jia:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.yi:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.bing:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.ding:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.wu:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.ji:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.geng:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.xin:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.ren:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                        }
                        break;
                    case PublicValue.TianGan.gui:
                        switch (input.TargetTG)
                        {
                            case PublicValue.TianGan.jia:
                                input.ShiShen = PublicValue.ShiShen.zhengyin;
                                break;
                            case PublicValue.TianGan.yi:
                                input.ShiShen = PublicValue.ShiShen.pianyin;
                                break;
                            case PublicValue.TianGan.bing:
                                input.ShiShen = PublicValue.ShiShen.zhengguan;
                                break;
                            case PublicValue.TianGan.ding:
                                input.ShiShen = PublicValue.ShiShen.qisha;
                                break;
                            case PublicValue.TianGan.wu:
                                input.ShiShen = PublicValue.ShiShen.zhengcai;
                                break;
                            case PublicValue.TianGan.ji:
                                input.ShiShen = PublicValue.ShiShen.piancai;
                                break;
                            case PublicValue.TianGan.geng:
                                input.ShiShen = PublicValue.ShiShen.shangguan;
                                break;
                            case PublicValue.TianGan.xin:
                                input.ShiShen = PublicValue.ShiShen.shishen;
                                break;
                            case PublicValue.TianGan.ren:
                                input.ShiShen = PublicValue.ShiShen.jiecai;
                                break;
                            case PublicValue.TianGan.gui:
                                input.ShiShen = PublicValue.ShiShen.bijian;
                                break;
                        }
                        break;
                }
            }
            #endregion
            #region 地支与地支
            #endregion
            return input;

        }

        public PublicValue.Element GetConstellationElement(PublicValue.Constellation input)
        {

            if (input == PublicValue.Constellation.Ari ||
                        input == PublicValue.Constellation.Leo ||
                        input == PublicValue.Constellation.Sag)
            {
                return PublicValue.Element.fire;
            }
            else if (input == PublicValue.Constellation.Aqu ||
                input == PublicValue.Constellation.Gem ||
               input == PublicValue.Constellation.Lib)
            {
                return PublicValue.Element.wind;
            }
            else if (input == PublicValue.Constellation.Can ||
                input == PublicValue.Constellation.Pis ||
               input == PublicValue.Constellation.Sco)
            {
                return PublicValue.Element.aqua;
            }
            else if (input == PublicValue.Constellation.Cap ||
                input == PublicValue.Constellation.Tau ||
                input == PublicValue.Constellation.Vir)
            {
                return PublicValue.Element.earth;
            }
            else
            {
                return PublicValue.Element.fire;
            }
        }

    }

    public class WuXingRelation
    {
        public WuXingRelation(PublicValue.TianGan source ,PublicValue.TianGan target)
        {
            sourcetg = source;
            sourceType = 0;
            targettg = target;
            targetType = 0;
        }
        public WuXingRelation(PublicValue.TianGan source, PublicValue.DiZhi target)
        {
            sourcetg = source;
            sourceType = 0;
            targetdz = target;
            targetType = 1;
        }
        public WuXingRelation(PublicValue.DiZhi source, PublicValue.TianGan target)
        {
            sourcedz = source;
            sourceType = 1;
            targettg = target;
            targetType = 0;
        }
        public WuXingRelation(PublicValue.DiZhi source, PublicValue.DiZhi target)
        {
            sourcedz = source;
            sourceType = 1;
            targetdz = target;
            targetType = 1;
        }
        
        #region 私有变量
        private PublicValue.TianGan sourcetg = new PublicValue.TianGan();
        private PublicValue.DiZhi sourcedz = new PublicValue.DiZhi();
        private int sourceType = 0;//0为仅天干，1为仅地支，2为天干地支

        private PublicValue.TianGan targettg = new PublicValue.TianGan();
        private PublicValue.DiZhi targetdz = new PublicValue.DiZhi();
        private int targetType = 0;//0为仅天干，1为仅地支，2为天干地支

        private PublicValue.ShiShen shishen = new PublicValue.ShiShen();
        #endregion
        #region 接口
        public PublicValue.TianGan SourceTG
        {
            get { return sourcetg; }
            set { sourcetg = value; }
        }
        public PublicValue.DiZhi SourceDZ
        {
            get { return sourcedz; }
            set { sourcedz = value; }
        }
        public int SourceType
        {
            get { return sourceType; }
            set { sourceType = value; }
        }
        public PublicValue.TianGan TargetTG
        {
            get { return targettg; }
            set { targettg = value; }
        }
        public PublicValue.DiZhi TargetDZ
        {
            get { return targetdz; }
            set { targetdz = value; }
        }
        public int TargetType
        {
            get { return targetType; }
            set { targetType = value; }
        }
        public PublicValue.ShiShen ShiShen
        {
            get { return shishen; }
            set { shishen = value; }
        }
        #endregion
    }



    
}