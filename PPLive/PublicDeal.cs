using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppCmn;
using PPLive.Astro;

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

        #region 八字相关

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

        #endregion

        #region 占星术相关

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

        public bool HasPhase(Star a, Star b, PublicValue.Phase phase, decimal offset)
        {
            if (offset == AppConst.DecimalNull)
            {
                switch (phase)
                {
                    case PublicValue.Phase.he:
                        offset = 10;
                        break;
                    case PublicValue.Phase.xing:
                        offset = 8;
                        break;
                    case PublicValue.Phase.chong:
                        offset = 8;
                        break;
                    case PublicValue.Phase.gong:
                        offset = 8;
                        break;
                    case PublicValue.Phase.bangong:
                        offset = 5;
                        break;
                }
            }

            decimal degreeA = ((int)a.Constellation-1) * 30 + a.Degree + a.Cent / 60;
            decimal degreeB = ((int)b.Constellation-1) * 30 + b.Degree + b.Cent / 60;

            decimal angle = Math.Abs(degreeA - degreeB);
            if (angle > 180)
            {
                angle = 360 - angle;
            }

            if (angle <= offset + (int)phase && angle >= (int)phase - offset)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否有任何主相位，0,60,90,120,180，四轴只判定合相
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool HasAnyMainPhase(Star a, Star b)
        {
            if (HasPhase(a, b, PublicValue.Phase.he, AppConst.DecimalNull) 
                || (HasPhase(a, b, PublicValue.Phase.chong, AppConst.DecimalNull) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.xing, AppConst.DecimalNull) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.gong, AppConst.DecimalNull) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.bangong, AppConst.DecimalNull) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasAnyMainPhase(Star a, Star b, decimal offset)
        {
            if (HasPhase(a, b, PublicValue.Phase.he, offset) 
                || (HasPhase(a, b, PublicValue.Phase.chong, offset) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.xing, offset) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.gong, offset) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.bangong, offset) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否有任何负相位，0,90,180，四轴只判定合相
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool HasAnyBadPhase(Star a, Star b)
        {
            if (HasPhase(a, b, PublicValue.Phase.he, AppConst.DecimalNull) || (HasPhase(a, b, PublicValue.Phase.chong, AppConst.DecimalNull) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.xing, AppConst.DecimalNull) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasAnyBadPhase(Star a, Star b, decimal offset)
        {
            if (HasPhase(a, b, PublicValue.Phase.he, offset) || (HasPhase(a, b, PublicValue.Phase.chong, offset) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33))
                || (HasPhase(a, b, PublicValue.Phase.xing, offset) && !((int)a.StarName > 20 && (int)a.StarName < 33) && !((int)b.StarName > 20 && (int)b.StarName < 33)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获取宫主星
        /// </summary>
        /// <param name="stars"></param>
        /// <param name="gong"></param>
        /// <returns></returns>
        public List<PublicValue.AstroStar> GetGongMasters(Star[] stars,int gong,bool second)
        {
            List<PublicValue.AstroStar> ret = new List<PublicValue.AstroStar>();
            List<PublicValue.AstroStar> tmp = new List<PublicValue.AstroStar>();
            int gongafter = gong+1;
                if(gongafter==13)
                {
                    gongafter=1;
                }
            int gongconst = 0;
            foreach (Star tmpstar in stars)
            {
                if ((int)tmpstar.StarName == gong + 20)
                {
                    gongconst = (int)tmpstar.Constellation;
                    tmp = GetShouHu(tmpstar.Constellation,false);
                    foreach (PublicValue.AstroStar tmps in tmp)
                    {
                        ret.Add(tmps);
                    }
                }
            }
            foreach (Star tmpstar in stars)
            {
                //劫夺
                if ((int)tmpstar.StarName == gongafter + 20)
                {
                    if ((int)tmpstar.Constellation - gongconst == 2 || (int)tmpstar.Constellation - gongconst == -10)
                    {
                        int gongplus = gongconst + 1;
                        if (gongplus == 13)
                        {
                            gongplus = 1;
                        }
                        tmp = GetShouHu((PublicValue.Constellation)(gongplus), false);
                        foreach (PublicValue.AstroStar tmps in tmp)
                        {
                            ret.Add(tmps);
                        }
                    }
                }
            }
            ret = ret.Distinct().ToList();
            return ret;
        }

        /// <summary>
        /// 获取守护星
        /// </summary>
        /// <param name="second">是否包括第二守护星</param> 
        /// <returns></returns>
        public List<PublicValue.AstroStar> GetShouHu(PublicValue.Constellation input,bool second)
        {
            List<PublicValue.AstroStar> ret = new List<PublicValue.AstroStar>();

            switch (input)
            {
                case PublicValue.Constellation.Ari:
                    ret.Add(PublicValue.AstroStar.Mar);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Sun);
                    break;
                case PublicValue.Constellation.Tau:
                    ret.Add(PublicValue.AstroStar.Ven);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Moo);
                    break;
                case PublicValue.Constellation.Gem:
                    ret.Add(PublicValue.AstroStar.Mer);
                    break;
                case PublicValue.Constellation.Can:
                    ret.Add(PublicValue.AstroStar.Moo);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Jup);
                    break;
                case PublicValue.Constellation.Leo:
                    ret.Add(PublicValue.AstroStar.Sun);
                    break;
                case PublicValue.Constellation.Vir:
                    ret.Add(PublicValue.AstroStar.Mer);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Plu);
                    break;
                case PublicValue.Constellation.Lib:
                    ret.Add(PublicValue.AstroStar.Ven);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Sat);
                    break;
                case PublicValue.Constellation.Sco:
                    ret.Add(PublicValue.AstroStar.Plu);
                    ret.Add(PublicValue.AstroStar.Mar);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Ura);
                    break;
                case PublicValue.Constellation.Sag:
                    ret.Add(PublicValue.AstroStar.Jup);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Nep);
                    break;
                case PublicValue.Constellation.Cap:
                    ret.Add(PublicValue.AstroStar.Sat);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Mar);
                    break;
                case PublicValue.Constellation.Aqu:
                    ret.Add(PublicValue.AstroStar.Ura);
                    ret.Add(PublicValue.AstroStar.Sat);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Mer);
                    break;
                case PublicValue.Constellation.Pis:
                    ret.Add(PublicValue.AstroStar.Jup);
                    ret.Add(PublicValue.AstroStar.Nep);
                    if (second)
                        ret.Add(PublicValue.AstroStar.Ven);
                    break;
            }

            return ret;
        }

        /// <summary>
        /// 计算互溶关系
        /// </summary>
        /// <param name="stars"></param>
        /// <param name="isWang">是否包括旺相互溶</param>
        /// <returns></returns>
        public List<List<PublicValue.AstroStar>> GetHuRong(Star[] stars, bool isWang)
        {
            List<List<PublicValue.AstroStar>> ret = new List<List<PublicValue.AstroStar>>();
            List<PublicValue.AstroStar> checkedstar = new List<PublicValue.AstroStar>();
            foreach (Star tmpstar in stars)//遍历盘中所有星体
            {
                if ((int)tmpstar.StarName > 10)//只选取主星体
                {
                    continue;
                }
                if (checkedstar.Contains(tmpstar.StarName))//排除已排查过的星体
                {
                    continue;
                }

                checkedstar.Add(tmpstar.StarName);
                List<List<Star>> checkingstars = new List<List<Star>>();//创建当前主星体引申出的互溶链
                checkingstars.Add(new List<Star>() { tmpstar });

                while (checkingstars.Count > 0)//循环处理当前互溶链组
                {
                    List<Star> nowline = checkingstars[0];//拿出顶端链
                    List<PublicValue.AstroStar> shouhuxing = GetShouHu(checkingstars[0].Last().Constellation, isWang);//获取当前链最后星体所在星座的守护星
                   
                    checkingstars.RemoveAt(0);
                    foreach (PublicValue.AstroStar sh in shouhuxing)//逐一处理守护星
                    {
                        checkedstar.Add(sh);//守护星加入已排查队列
                        if (sh == nowline.Last().StarName)//当前互溶链中最后一个星体入庙，排除该守护星
                        {
                            continue;
                        }
                        bool isexist = false;
                        foreach (Star tmps in nowline)//该守护星存在于互溶链中，拼出该链，加入返回列表中
                        {
                            if (tmps.StarName == sh)
                            {
                                List<PublicValue.AstroStar> tmpinput = new List<PublicValue.AstroStar>();
                                int index = nowline.IndexOf(tmps);
                                for (int i = index; i < nowline.Count; i++)
                                {
                                    tmpinput.Add(nowline[i].StarName);
                                }
                                ret.Add(tmpinput);
                                isexist = true;
                                break;
                            }
                        }
                        if (!isexist)
                        {
                            foreach (Star tmps in stars)//原互溶链中不存在该守护星，将该链完善重新加入待处理互溶链组中
                            {
                                if (tmps.StarName == sh)
                                {
                                    List<Star> tmplist = new List<Star>();
                                    foreach (Star ttmp in nowline)
                                    {
                                        tmplist.Add(ttmp);
                                    }
                                    tmplist.Add(tmps);
                                    checkingstars.Add(tmplist);
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            for (int i = 0; i < ret.Count; i++)
            {
                for (int j = i + 1; j < ret.Count; j++)
                {
                    if (ret[i].Except(ret[j]).Count() == 0 && ret[j].Except(ret[i]).Count() == 0)
                    {
                        ret.RemoveAt(j);
                        j--;
                    }
                }
            }
            return ret;
        }

        public int GetGongPower(Star[] stars, int gong)
        {
            int ret = 0;
            List<List<PublicValue.AstroStar>> m_hurong = GetHuRong(stars, true);
            List<PublicValue.AstroStar> m_gongzhu = GetGongMasters(stars, gong, true);//获取宫主星列表，包括第二宫主星

            Dictionary<PublicValue.AstroStar, Star> m_star = new Dictionary<PublicValue.AstroStar, Star>();
            foreach (Star nowstar in stars)
            {
                m_star.Add(nowstar.StarName, nowstar);
            }

            //金木是否落入宫内
            if (m_star[PublicValue.AstroStar.Ven].Gong == gong)
            {
                ret++;
            }
            if (m_star[PublicValue.AstroStar.Jup].Gong == gong)
            {
                ret++;
            }

            
            foreach (PublicValue.AstroStar tmpgongzhu in m_gongzhu)
            {
                //宫主星(非金木)与金木是否有相位
                if (tmpgongzhu != PublicValue.AstroStar.Jup && HasAnyMainPhase(m_star[PublicValue.AstroStar.Jup], m_star[tmpgongzhu]))
                {
                    ret++;
                }
                if (tmpgongzhu != PublicValue.AstroStar.Ven && HasAnyMainPhase(m_star[PublicValue.AstroStar.Ven], m_star[tmpgongzhu]))
                {
                    ret++;
                }
                
                //宫主星(非金木)与金木是否互溶
                foreach (List<PublicValue.AstroStar> hurong in m_hurong)
                {
                    if (tmpgongzhu != PublicValue.AstroStar.Jup)
                    {
                        if (hurong.Contains(PublicValue.AstroStar.Jup) && hurong.Contains(tmpgongzhu))
                        {
                            ret++;
                        }
                    }
                    if (tmpgongzhu != PublicValue.AstroStar.Ven)
                    {
                        if (hurong.Contains(PublicValue.AstroStar.Ven) && hurong.Contains(tmpgongzhu))
                        {
                            ret++;
                        }
                    }
                }

                //宫主星与宫内行星(非金木)是否有相位或互溶
                foreach (Star tmpstar in stars)
                {
                    if (tmpstar.Gong == gong && tmpstar.StarName != tmpgongzhu && tmpstar.StarName != PublicValue.AstroStar.Jup && tmpstar.StarName != PublicValue.AstroStar.Ven)
                    {
                        if (HasAnyMainPhase(tmpstar, m_star[tmpgongzhu]))
                        {
                            ret++;
                        }
                        foreach (List<PublicValue.AstroStar> hurong in m_hurong)
                        {
                            if (hurong.Contains(tmpstar.StarName) && hurong.Contains(tmpgongzhu))
                            {
                                ret++;
                            }
                        }
                    }
                }

                //宫主星落在本宫内
                if (m_star[tmpgongzhu].Gong == gong)
                {
                    ret++;
                }
            }
            return ret;
        }

        #endregion

        #region 公共
/// <summary>
/// 
/// </summary>
/// <param name="input"></param>
/// <param name="type">国家类型0为中国大陆</param>
/// <returns></returns>
        public bool IsDayLight(DateTime input, int type)
        {
            bool ret = false;
            if (type == 0 && type == AppConst.IntNull)
            {
                if (input.Year >= 1945 && input.Year <= 1949 && input.Month >= 5 && input.Month <= 9)
                {
                    ret = true;
                }
                else if (input >= new DateTime(1986, 5, 4, 0, 0, 0) && input <= new DateTime(1986, 9, 14, 23, 59, 59)
                    && input >= new DateTime(1987, 4, 12, 0, 0, 0) && input <= new DateTime(1987, 9, 13, 23, 59, 59)
                    && input >= new DateTime(1988, 4, 10, 0, 0, 0) && input <= new DateTime(1988, 9, 11, 23, 59, 59)
                    && input >= new DateTime(1989, 4, 16, 0, 0, 0) && input <= new DateTime(1989, 9, 17, 23, 59, 59)
                    && input >= new DateTime(1990, 4, 15, 0, 0, 0) && input <= new DateTime(1990, 9, 16, 23, 59, 59)
                    && input >= new DateTime(1991, 4, 14, 0, 0, 0) && input <= new DateTime(1991, 9, 15, 23, 59, 59)
                    )
                {
                    ret = true;
                }
            }
            return ret;
        }

        public DateTime RealTime(DateTime input, LatLng poi)
        {
            TimeSpan latspan = new TimeSpan(0, 0, Convert.ToInt32((poi.longitude - 120) * 4 * 60));
            int daycount = input.DayOfYear;
            if (!((input.Year % 4 == 0 && input.Year % 100 != 0) || input.Year % 400 == 0))
            {
                if (daycount > 59)
                {
                    daycount++;
                }
            }
            TimeSpan timespan = new TimeSpan(0, int.Parse(realtime[daycount].Split(new char[] { '|' })[0]), int.Parse(realtime[daycount].Substring(0, 1) + realtime[daycount].Split(new char[] { '|' })[1]));
            return input + latspan + timespan;
        }
        #region 节气造成的真太阳时差
        private string[] realtime = 
        {
"-3|9",
"-3|38",
"-4|6",
"-4|33",
"-5|1",
"-5|27",
"-5|54",
"-6|20",
"-6|45",
"-7|10",
"-7|35",
"-7|59",
"-8|22",
"-8|45",
"-9|7",
"-9|28",
"-9|49",
"-10|9",
"-10|28",
"-10|47",
"-11|5",
"-11|22",
"-11|38",
"-11|54",
"-12|8",
"-12|22",
"-12|35",
"-12|59",
"-13|10",
"-13|19",
"-13|37",
"-13|44",
"-13|50",
"-13|56",
"-14|1",
"-14|5",
"-14|9",
"-14|11",
"-14|13",
"-14|14",
"-14|15",
"-14|14",
"-14|13",
"-14|11",
"-14|8",
"-14|5",
"-14|1",
"-13|56",
"-13|51",
"-13|44",
"-13|38",
"-13|30",
"-13|22",
"-13|13",
"-11|4",
"-12|54",
"-12|43",
"-12|32",
"-12|21",
"-12|8",
"-11|56",
"-11|43",
"-11|29",
"-11|15",
"-11|1",
"-10|47",
"-10|32",
"-10|16",
"-10|1",
"-9|45",
"-9|28",
"-9|12",
"-8|55",
"-8|38",
"-8|21",
"-8|4",
"-7|46",
"-7|29",
"-7|11",
"-6|53",
"-6|35",
"-6|17",
"-5|58",
"-5|40",
"-5|22",
"-5|4",
"-4|45",
"-4|27",
"-4|9",
"-3|51",
"-3|33",
"-3|16",
"-2|58",
"-2|41",
"-2|24",
"-2|7",
"-1|50",
"-1|33",
"-1|17",
"-1|1",
"+0|46",
"+0|30",
"+0|16",
"+0|1",
"+0|13",
"+0|27",
"+0|41",
"+0|54",
"+1|6",
"+1|19",
"+1|31",
"+1|42",
"+1|53",
"+2|4",
"+2|14",
"+2|23",
"+2|33",
"+2|41",
"+2|49",
"+2|57",
"+3|4",


"+1|10",
"+3|16",
"+3|21",
"+3|26",
"+3|30",
"+3|37",
"+3|36",
"+3|39",
"+3|40",
"+3|42",
"+3|42",
"+3|42",
"+3|42",
"+3|41",
"+3|39",
"+3|37",
"+3|34",
"+3|31",
"+3|27",
"+3|23",
"+3|18",
"+3|13",
"+3|7",
"+3|1",
"+2|54",
"+2|47",
"+2|39",
"+2|31",
"+2|22",
"+2|13",
"+2|4",
"+1|54",
"+1|44",
"+1|34",
"+1|23",
"+1|12",
"+1|0",
"+0|48",
"+0|36",
"+0|24",
"+0|12",
"+0|1",
"+0|14",
"+0|39",
"+0|52",
"-1|5",
"-1|18",
"-1|31",
"-1|45",
"-1|57",
"-2|10",
"-2|23",
"-2|36",
"-2|48",
"-3|1",
"-3|13",
"-3|25",
"-3|37",
"-3|49",
"-4|0",
"-4|11",
"-4|22",
"-4|33",
"-4|43",
"-4|53",
"-5|2",
"-5|11",
"-5|20",
"-5|28",
"-5|36",
"-5|43",
"-5|50",
"-5|56",
"-6|2",
"-6|8",
"-6|12",
"-6|16",
"-6|20",
"-6|23",
"-6|25",
"-6|27",
"-6|29",
"-6|29",
"-6|29",
"-6|29",
"-6|28",
"-6|26",
"-6|24",
"-6|21",
"-6|17",
"-6|13",
"-6|8",
"-6|3",
"-5|57",
"-5|51",
"-5|44",
"-5|36",
"-5|28",
"-5|19",
"-5|10",
"-5|0",
"-4|50",
"-4|39",
"-4|27",
"-4|15",
"-4|2",
"-3|49",
"-3|36",
"-3|21",
"-3|7",
"-2|51",
"-2|36",
"-2|20",
"-2|3",
"-1|47",
"-1|29",
"-1|12",
"+0|54",
"+0|35",
"+0|17",
"+0|2",
"+0|21",
"+0|41",


"+1|0",
"+1|20",
"+1|40",
"+2|1",
"+2|21",
"+2|42",
"+3|3",
"+3|3",
"+3|24",
"+3|45",
"+4|6",
"+4|27",
"+4|48",
"+5|10",
"+5|31",
"+5|53",
"+6|14",
"+6|35",
"+6|57",
"+7|18",
"+7|39",
"+8|0",
"+8|21",
"+8|42",
"+9|2",
"+9|22",
"+9|42",
"+10|2",
"+10|21",
"+10|40",
"+10|59",
"+11|18",
"+11|36",
"+11|36",
"+11|53",
"+12|11",
"+12|28",
"+12|44",
"+12|60",
"+13|16",
"+13|16",
"+13|31",
"+13|45",
"+13|59",
"+14|13",
"+14|26",
"+14|38",
"+14|50",
"+15|1",
"+15|12",
"+15|21",
"+15|31",
"+15|40",
"+15|48",
"+15|55",
"+16|1",
"+16|7",
"+16|12",
"+16|16",
"+16|20",
"+16|22",
"+16|24",
"+16|25",
"+16|25",
"+16|24",
"+16|23",
"+16|21",
"+16|17",
"+16|13",
"+16|9",
"+16|3",
"+15|56",
"+15|49",
"+15|41",
"+15|32",
"+15|22",
"+15|11",
"+14|60",
"+14|47",
"+14|34",
"+14|20",
"+14|6",
"+13|50",
"+13|34",
"+13|17",
"+12|59",
"+12|40",
"+12|21",
"+12|1",
"+11|40",
"+11|18",
"+10|56",
"+10|33",
"+10|9",
"+9|45",
"+9|21",
"+8|55",
"+8|29",
"+8|3",
"+7|36",
"+7|9",
"+6|42",
"+6|14",
"+5|46",
"+5|17",
"+4|48",
"+4|19",
"+3|50",
"+3|21",
"+2|51",
"+2|22",
"+1|52",
"+1|22",
"+0|52",
"+0|23",
"+0|7",
"+0|37",
"-1|6",
"-1|36",
"-2|5",
"-2|34",
"-3|3"
        };
        #endregion
        #endregion
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