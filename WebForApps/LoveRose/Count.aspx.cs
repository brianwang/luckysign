using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive.Astro;
using PPLive;
using AppCmn;
using AppMod.WebSys;
using AppBll.WebSys;
using AppBll.Apps;
using AppMod.Apps;
using System.Data;

namespace WebForApps.LoveRose
{
    public partial class Count : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime now = DatePicker1.SelectedTime;
            Dictionary<string, SortedDictionary<int, int>> result = new Dictionary<string, SortedDictionary<int, int>>();
            int count = 0;
            for (DateTime tmpnow = now; tmpnow < now.AddYears(1); tmpnow = tmpnow.AddHours(1))
            {
                #region 计算
                AstroMod m_astro = new AstroMod();
                m_astro.type = PublicValue.AstroType.benming;
                #region 设置实体各种参数
                m_astro.birth = tmpnow;
                m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(1));
                //if (chkDaylight1.Checked)
                //{
                //    m_astro.IsDayLight = AppEnum.BOOL.True;
                //}
                //else
                //{
                //    m_astro.IsDayLight = AppEnum.BOOL.False;
                //}
                m_astro.IsDayLight = AppEnum.BOOL.False;
                m_astro.zone = -8;

                for (int i = 1; i < 21; i++)
                {
                    m_astro.startsShow.Add(i, "");
                }
                m_astro.aspectsShow.Clear();
                for (int i = 1; i < 6; i++)
                {
                    m_astro.aspectsShow.Add(i, 5);
                }
                #endregion

                AstroBiz.GetInstance().GetParamters(ref m_astro);
                Dictionary<PublicValue.AstroStar, Star> m_star = new Dictionary<PublicValue.AstroStar, Star>();
                foreach (Star tmpstar in m_astro.Stars)
                {
                    m_star.Add(tmpstar.StarName, tmpstar);
                }
                string jsstr = "";
                //吉星
                List<PublicValue.AstroStar> goodstars = new List<PublicValue.AstroStar>();
                goodstars.Add(PublicValue.AstroStar.Jup);
                goodstars.Add(PublicValue.AstroStar.Ven);
                //凶星
                Dictionary<PublicValue.AstroStar, int> badstars = new Dictionary<PublicValue.AstroStar, int>();
                List<PublicValue.AstroStar> tmpbad = new List<PublicValue.AstroStar>();
                tmpbad.Add(PublicValue.AstroStar.Mar);
                tmpbad.Add(PublicValue.AstroStar.Sat);
                tmpbad.Add(PublicValue.AstroStar.Ura);
                tmpbad.Add(PublicValue.AstroStar.Nep);
                tmpbad.Add(PublicValue.AstroStar.Plu);
                List<PublicValue.AstroStar> twelve = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 12, false);
                List<PublicValue.AstroStar> eight = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 8, false);
                List<PublicValue.AstroStar> seven = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
                List<PublicValue.AstroStar> two = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 2, false);
                foreach (PublicValue.AstroStar tmp in tmpbad)
                {
                    badstars.Add(tmp, 1);
                }
                foreach (PublicValue.AstroStar tmp in eight)
                {
                    if (!tmpbad.Contains(tmp))
                    {
                        if (!badstars.ContainsKey(tmp))
                            badstars.Add(tmp, 1);
                    }
                    else
                    {
                        badstars[tmp]++;
                    }
                }
                foreach (PublicValue.AstroStar tmp in twelve)
                {
                    if (!tmpbad.Contains(tmp))
                    {
                        if (!badstars.ContainsKey(tmp))
                            badstars.Add(tmp, 1);
                    }
                    else
                    {
                        badstars[tmp]++;
                    }
                }
                List<PublicValue.AstroStar> mingzhu = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 1, false);
                foreach (PublicValue.AstroStar tmp in mingzhu)
                {
                    if (!tmpbad.Contains(tmp))
                    {
                        if (!badstars.ContainsKey(tmp))
                            badstars.Add(tmp, 1);
                    }
                    else
                    {
                        badstars[tmp]++;
                    }
                }


                #region 红杏
                bool hongxing = false;
                if (PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.he, AppConst.DecimalNull)
                    || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.chong, AppConst.DecimalNull)
                    || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.xing, AppConst.DecimalNull))
                {
                    hongxing = true;
                }
                if (!result.ContainsKey("红杏"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    tmpdic.Add(0, 0);
                    tmpdic.Add(1, 0);
                    result.Add("红杏", tmpdic);
                }
                if (!hongxing)
                {
                    result["红杏"][0]++;
                }
                else
                {
                    result["红杏"][1]++;
                }
                #endregion

                #region 蜜蜂
                int beecount = 0;
                List<PublicValue.AstroStar> beestars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);

                beestars.Add(PublicValue.AstroStar.Des);
                beestars.Add(PublicValue.AstroStar.Jun);
                foreach (PublicValue.AstroStar tmpstar in beestars)
                {
                    int tmpflag = 0;
                    if (tmpstar != goodstars[0] && PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstar], m_star[goodstars[0]]))
                    {
                        beecount++;
                        tmpflag = 1;
                    }
                    if (tmpstar != goodstars[1] && PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstar], m_star[goodstars[1]]))
                    {
                        beecount++;
                        if (tmpflag == 1)
                        {
                            beecount++;
                        }
                    }
                }

                if (!result.ContainsKey("蜜蜂"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("蜜蜂", tmpdic);
                }
                if (!result["蜜蜂"].ContainsKey(beecount))
                {
                    result["蜜蜂"].Add(beecount, 0);
                }
                result["蜜蜂"][beecount]++;
                #endregion

                #region 花盆

                #endregion

                #region 负面
                Dictionary<string, int> showele = new Dictionary<string, int>();
                showele.Add("paopao", 0);
                showele.Add("chongzi", 0);
                showele.Add("cu", 0);
                showele.Add("liehen", 0);
                showele.Add("bingdong", 0);
                showele.Add("zhezhi", 0);
                showele.Add("kuye", 0);

                List<PublicValue.AstroStar> breakstars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
                breakstars.Add(PublicValue.AstroStar.Ven);
                breakstars.Add(PublicValue.AstroStar.Jun);
                breakstars.Add(PublicValue.AstroStar.Des);
                breakstars = breakstars.Distinct().ToList();
                foreach (PublicValue.AstroStar tmp in badstars.Keys)
                {
                    //if (tmp != goodstars[0])
                    //    continue;
                    int tmpflag = 0;
                    for (int i = 0; i < breakstars.Count; i++)
                    {
                        if (PublicDeal.GetInstance().HasAnyBadPhase(m_star[tmp], m_star[breakstars[i]]))
                        {
                            bool Exact = false;
                            if (PublicDeal.GetInstance().HasAnyBadPhase(m_star[tmp], m_star[breakstars[i]], 1))
                            {
                                Exact = true;
                            }
                            switch (tmp)
                            {
                                case PublicValue.AstroStar.Mar:
                                case PublicValue.AstroStar.Sun:
                                    showele["zhezhi"] += badstars[tmp];
                                    if (Exact)
                                        showele["zhezhi"]++;
                                    break;
                                case PublicValue.AstroStar.Jup:
                                case PublicValue.AstroStar.Ven:
                                    showele["kuye"] += badstars[tmp];
                                    if (Exact)
                                        showele["kuye"]++;
                                    break;
                                case PublicValue.AstroStar.Sat:
                                    showele["liehen"] += badstars[tmp];
                                    if (Exact)
                                        showele["liehen"]++;
                                    break;
                                case PublicValue.AstroStar.Ura:
                                    showele["bingdong"] += badstars[tmp];
                                    if (Exact)
                                        showele["bingdong"]++;
                                    break;
                                case PublicValue.AstroStar.Nep:
                                    showele["paopao"] += badstars[tmp];
                                    if (Exact)
                                        showele["paopao"]++;
                                    break;
                                case PublicValue.AstroStar.Plu:
                                case PublicValue.AstroStar.Moo:
                                    showele["cu"] += badstars[tmp];
                                    if (Exact)
                                        showele["cu"]++;
                                    break;
                                case PublicValue.AstroStar.Mer:
                                    showele["chongzi"] += badstars[tmp];
                                    if (Exact)
                                        showele["chongzi"]++;
                                    break;
                            }
                            tmpflag++;
                            if (tmpflag > 1)
                            {
                                switch (tmp)
                                {
                                    case PublicValue.AstroStar.Mar:
                                    case PublicValue.AstroStar.Sun:
                                        showele["zhezhi"]++;
                                        break;
                                    case PublicValue.AstroStar.Jup:
                                    case PublicValue.AstroStar.Ven:
                                        showele["kuye"]++;
                                        break;
                                    case PublicValue.AstroStar.Sat:
                                        showele["liehen"]++;
                                        break;
                                    case PublicValue.AstroStar.Ura:
                                        showele["bingdong"]++;
                                        break;
                                    case PublicValue.AstroStar.Nep:
                                        showele["paopao"]++;
                                        break;
                                    case PublicValue.AstroStar.Plu:
                                    case PublicValue.AstroStar.Moo:
                                        showele["cu"]++;
                                        break;
                                    case PublicValue.AstroStar.Mer:
                                        showele["chongzi"]++;
                                        break;
                                }
                            }

                        }
                    }
                }
                if (!result.ContainsKey("泡泡"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("泡泡", tmpdic);
                }
                if (!result["泡泡"].ContainsKey(showele["paopao"]))
                {
                    result["泡泡"].Add(showele["paopao"], 0);
                }
                result["泡泡"][showele["paopao"]]++;

                if (!result.ContainsKey("虫子"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("虫子", tmpdic);
                }
                if (!result["虫子"].ContainsKey(showele["chongzi"]))
                {
                    result["虫子"].Add(showele["chongzi"], 0);
                }
                result["虫子"][showele["chongzi"]]++;

                if (!result.ContainsKey("醋"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("醋", tmpdic);
                }
                if (!result["醋"].ContainsKey(showele["cu"]))
                {
                    result["醋"].Add(showele["cu"], 0);
                }
                result["醋"][showele["cu"]]++;

                if (!result.ContainsKey("裂痕"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("裂痕", tmpdic);
                }
                if (!result["裂痕"].ContainsKey(showele["liehen"]))
                {
                    result["裂痕"].Add(showele["liehen"], 0);
                }
                result["裂痕"][showele["liehen"]]++;

                if (!result.ContainsKey("冰冻"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("冰冻", tmpdic);
                }
                if (!result["冰冻"].ContainsKey(showele["bingdong"]))
                {
                    result["冰冻"].Add(showele["bingdong"], 0);
                }
                result["冰冻"][showele["bingdong"]]++;

                if (!result.ContainsKey("折枝"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("折枝", tmpdic);
                }
                if (!result["折枝"].ContainsKey(showele["zhezhi"]))
                {
                    result["折枝"].Add(showele["zhezhi"], 0);
                }
                result["折枝"][showele["zhezhi"]]++;

                if (!result.ContainsKey("枯叶"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("枯叶", tmpdic);
                }
                if (!result["枯叶"].ContainsKey(showele["kuye"]))
                {
                    result["枯叶"].Add(showele["kuye"], 0);
                }
                result["枯叶"][showele["kuye"]]++;

                if (!result.ContainsKey("总负面"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("总负面", tmpdic);
                }
                int tmpbadd = showele["paopao"] + showele["chongzi"] + showele["cu"] + showele["liehen"] + showele["bingdong"] + showele["zhezhi"] + showele["kuye"];
                if (!result["总负面"].ContainsKey(tmpbadd))
                {
                    result["总负面"].Add(tmpbadd, 0);
                }
                result["总负面"][tmpbadd]++;


                #endregion

                #region 花心指数
                int flowercount = 0;
                foreach (PublicValue.AstroStar tmpstar in goodstars)
                {
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[tmpstar]))
                    {
                        flowercount++;
                    }
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Chi], m_star[tmpstar]))
                    {
                        flowercount++;
                    }
                    foreach (PublicValue.AstroStar tmpstarr in eight)
                    {
                        if (tmpstar != tmpstarr && PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstarr], m_star[tmpstar]))
                        {
                            flowercount++;
                        }
                    }
                }
                if (m_star[PublicValue.AstroStar.Moo].Constellation == PublicValue.Constellation.Gem ||
                    m_star[PublicValue.AstroStar.Moo].Constellation == PublicValue.Constellation.Sag ||
                    m_star[PublicValue.AstroStar.Moo].Constellation == PublicValue.Constellation.Pis)
                {
                    flowercount++;
                }
                if (m_star[PublicValue.AstroStar.Ven].Constellation == PublicValue.Constellation.Gem ||
                   m_star[PublicValue.AstroStar.Ven].Constellation == PublicValue.Constellation.Sag ||
                   m_star[PublicValue.AstroStar.Ven].Constellation == PublicValue.Constellation.Pis)
                {
                    flowercount++;
                }
                if (m_star[PublicValue.AstroStar.Des].Constellation == PublicValue.Constellation.Gem ||
                    m_star[PublicValue.AstroStar.Des].Constellation == PublicValue.Constellation.Sag ||
                    m_star[PublicValue.AstroStar.Des].Constellation == PublicValue.Constellation.Pis)
                {
                    flowercount++;
                }
                if (m_star[PublicValue.AstroStar.Moo].Gong == 12)
                {
                    flowercount++;
                }
                if (m_star[PublicValue.AstroStar.Ven].Gong == 12)
                {
                    flowercount++;
                }
                if (PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Sun].Constellation) == PublicValue.Element.wind && PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Moo].Constellation) == PublicValue.Element.earth)
                {
                    flowercount++;
                }
                if (PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Sun].Constellation) == PublicValue.Element.fire && PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Moo].Constellation) == PublicValue.Element.wind)
                {
                    flowercount++;
                }
                if (m_astro.Gender == AppEnum.Gender.male)
                {
                    flowercount++;
                }
                if (!result.ContainsKey("花心"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("花心", tmpdic);
                }
                if (!result["花心"].ContainsKey(flowercount))
                {
                    result["花心"].Add(flowercount, 0);
                }
                result["花心"][flowercount]++;
                #endregion

                #region 魅力指数
                int meilicount = beecount;
                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Ura], m_star[PublicValue.AstroStar.For]))
                {
                    meilicount++;
                }
                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Ura], m_star[PublicValue.AstroStar.Ven]))
                {
                    meilicount++;
                }
                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.For], m_star[PublicValue.AstroStar.Ven]))
                {
                    meilicount++;
                }
                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Sun], m_star[PublicValue.AstroStar.Jup]))
                {
                    meilicount++;
                }

                if (!result.ContainsKey("魅力"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("魅力", tmpdic);
                }
                if (!result["魅力"].ContainsKey(meilicount))
                {
                    result["魅力"].Add(meilicount, 0);
                }
                result["魅力"][meilicount]++;
                #endregion

                #region 对方有钱
                int richcount = PublicDeal.GetInstance().GetGongPower(m_astro.Stars, 8);
                if (richcount > 15)
                {
                    richcount = 15;
                }
                foreach (PublicValue.AstroStar tmpstar in seven)
                {
                    if (m_star[tmpstar].Gong == 8 || m_star[tmpstar].Gong == 7)
                    {
                        richcount = richcount + 5;
                    }
                }
                foreach (PublicValue.AstroStar tmpstar in eight)
                {
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[tmpstar]) && PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.For], m_star[tmpstar]))
                    {
                        richcount = richcount + 5;
                    }
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.For], m_star[tmpstar]) && PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[PublicValue.AstroStar.For]))
                    {
                        richcount = richcount + 5;
                    }
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[tmpstar]) && PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[PublicValue.AstroStar.For]))
                    {
                        richcount = richcount + 5;
                    }
                }
                foreach (PublicValue.AstroStar tmpstar in two)
                {
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[tmpstar]) && PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.For], m_star[tmpstar]))
                    {
                        richcount = richcount + 5;
                    }
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.For], m_star[tmpstar]) && PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[PublicValue.AstroStar.For]))
                    {
                        richcount = richcount + 5;
                    }
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[tmpstar]) && PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[PublicValue.AstroStar.For]))
                    {
                        richcount = richcount + 5;
                    }
                }
                if (m_star[PublicValue.AstroStar.Jun].Gong == 11)
                {
                    richcount = richcount + 5;
                }
                if (m_star[PublicValue.AstroStar.Ura].Gong == 8)
                {
                    richcount = richcount + 5;
                }
                if (richcount >= 60)
                {
                    Label1.Text += m_astro.birth.ToString("yyyy-MM-dd HH:mm:ss") + "<br />";
                    //return;
                }

                List<List<PublicValue.AstroStar>> hurong = PublicDeal.GetInstance().GetHuRong(m_astro.Stars, true); ;
                if (!result.ContainsKey("对方有钱"))
                {
                    SortedDictionary<int, int> tmpdic = new SortedDictionary<int, int>();
                    result.Add("对方有钱", tmpdic);
                }
                if (!result["对方有钱"].ContainsKey(richcount))
                {
                    result["对方有钱"].Add(richcount, 0);
                }
                result["对方有钱"][richcount]++;
                #endregion
                #endregion
                count++;
            }
            #region 打印
            Label1.Text += now.ToString("yyyy-MM-dd") + "至" + DatePicker1.SelectedTime.ToString("yyyy-MM-dd") + "<br />";
            foreach (KeyValuePair<string, SortedDictionary<int, int>> s in result)
            {
                Label1.Text += s.Key + "：<br />";
                foreach (KeyValuePair<int, int> ss in s.Value)
                {
                    
                    Label1.Text += ss.Key + "：" + ss.Value + "个<br />";
                }
            }
            #endregion
        }




    }
}