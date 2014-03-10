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
                        offset = 5;
                        break;
                    case PublicValue.Phase.xing:
                        offset = 4;
                        break;
                    case PublicValue.Phase.chong:
                        offset = 4;
                        break;
                    case PublicValue.Phase.gong:
                        offset = 4;
                        break;
                    case PublicValue.Phase.bangong:
                        offset = (decimal)2.5;
                        break;
                }
            }

            decimal degreeA = ((int)a.Constellation) * 30 + a.Degree + a.Cent / 60 * 100;
            decimal degreeB = ((int)b.Constellation) * 30 + b.Degree + b.Cent / 60 * 100;

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
        /// 是否有任何主相位，0,60,90,120,180
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool HasAnyMainPhase(Star a, Star b)
        {
            if (HasPhase(a, b, PublicValue.Phase.he, AppConst.DecimalNull) || HasPhase(a, b, PublicValue.Phase.chong, AppConst.DecimalNull)
                || HasPhase(a, b, PublicValue.Phase.xing, AppConst.DecimalNull) || HasPhase(a, b, PublicValue.Phase.gong, AppConst.DecimalNull)
                || HasPhase(a, b, PublicValue.Phase.bangong, AppConst.DecimalNull))
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
                    if (second)
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
                    List<PublicValue.AstroStar> shouhuxing = GetShouHu(checkingstars[0].Last().Constellation,false);//获取顶端的链最后星体所在星座的守护星
                   
                    checkingstars.RemoveAt(0);
                    foreach (PublicValue.AstroStar sh in shouhuxing)//逐一处理守护星
                    {
                        checkedstar.Add(sh);//守护星加入已排查队列
                        if (sh == nowline.Last().StarName)//互溶链中最后一个星体入庙，排除该守护星
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
                            foreach (Star tmps in stars)//原互溶链中不存在该守护星，将该链完善重新加入当前互溶链组中
                            {
                                if (tmps.StarName == sh)
                                {
                                    List<Star> tmplist = nowline;
                                    tmplist.Add(tmps);
                                    checkingstars.Add(tmplist);
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            ret = ret.Distinct().ToList();
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