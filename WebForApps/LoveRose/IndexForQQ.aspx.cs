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
    public partial class IndexForQQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ImageButton1.ImageUrl = "";
            if (!IsPostBack)
            {
                Repeater1.DataSource = SYS_DistrictBll.GetInstance().GetFirstLevel(1);
                Repeater1.DataBind();
                HiddenField3.Value = "1";
                HiddenField4.Value = "1995-1-1 12:0:0";
                Button2_Click(sender, e);
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "initialselect();", true);
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            AstroMod m_astro = new AstroMod();
            m_astro.type = PublicValue.AstroType.benming;
            #region 设置实体各种参数
            m_astro.birth = DateTime.Parse(HiddenField4.Value);
            SYS_DistrictMod dis = SYS_DistrictBll.GetInstance().GetModel(int.Parse(HiddenField2.Value));
            if (string.IsNullOrEmpty(dis.Latitude) || string.IsNullOrEmpty(dis.longitude))
            {
                SYS_DistrictMod tmp = SYS_DistrictBll.GetInstance().GetModel(dis.UpSysNo);
                dis.Latitude = tmp.Latitude;
                dis.longitude = tmp.longitude;
            }
            m_astro.position = new LatLng(dis);
            if (HiddenField1.Value == "1")
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else if (HiddenField1.Value == "0")
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            else
            {
                m_astro.IsDaylight = (AppEnum.BOOL)Convert.ToInt16(PublicDeal.GetInstance().IsDayLight(m_astro.birth, 0));
            }
            if (HiddenField6.Value == "g1")
            {
                m_astro.Gender = AppEnum.Gender.male;
            }
            else
            {
                m_astro.Gender = AppEnum.Gender.female;
            }

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
            

            #region 花
            Label1.Text = "1.金星星座为：" + PublicValue.GetConstellation(m_star[PublicValue.AstroStar.Ven].Constellation) + "<br/>";
            jsstr += "showItem('hua', " + (int)m_star[PublicValue.AstroStar.Ven].Constellation + ");";
            ViewState["hua"] = (int)m_star[PublicValue.AstroStar.Ven].Constellation;
            #endregion

            #region 金星元素
            int venusEle = 0;
            venusEle = (int)PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Ven].Constellation);
            Label1.Text += "2.金星星座元素为：" + PublicValue.GetElement(PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Ven].Constellation)) + "<br />";
            #endregion

            #region 红杏
            bool hongxing = false;
            if (PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.he, AppConst.DecimalNull)
                || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.chong, AppConst.DecimalNull)
                || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.xing, AppConst.DecimalNull))
            {
                hongxing = true;
            }
            //Label1.Text += "金星：" + ((int)m_star[PublicValue.AstroStar.Ven].Constellation) * 30 + " " + m_star[PublicValue.AstroStar.Ven].Degree + " " + m_star[PublicValue.AstroStar.Ven].Cent / 60 * 100;
            //Label1.Text += "婚神：" + ((int)m_star[PublicValue.AstroStar.Jun].Constellation) * 30 + " " + m_star[PublicValue.AstroStar.Jun].Degree + " " + m_star[PublicValue.AstroStar.Jun].Cent / 60 * 100;
            Label1.Text += "3.是否有红杏:" + (hongxing==true ? "有" : "没有") + "<br />";
            jsstr += "showItem('hongxing', " + (hongxing == true ? "1" : "0") + ");";
            if (hongxing)
            {
                li5.Style["display"] = "";
            }
            #endregion

            #region 蜜蜂
            int beecount = 0;
            List<PublicValue.AstroStar> beestars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
            Label1.Text += "7宫主：";
            foreach (PublicValue.AstroStar tmpstar in beestars)
            {
                Label1.Text += PublicValue.GetAstroStar(tmpstar);
            }
            Label1.Text += "<br />";
            Label1.Text += "凶星：";
            foreach (PublicValue.AstroStar tmpstar in badstars.Keys)
            {
                Label1.Text += PublicValue.GetAstroStar(tmpstar);
            }
            Label1.Text += "<br />";
            beestars.Add(PublicValue.AstroStar.Des);
            beestars.Add(PublicValue.AstroStar.Jun);
            foreach (PublicValue.AstroStar tmpstar in beestars)
            {
                int tmpflag = 0;
                if (tmpstar!=goodstars[0]&&PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstar], m_star[goodstars[0]]))
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

            Label1.Text += "4.蜜蜂指数为:" + beecount + "<br />";
            jsstr += "showItem('mifeng', " + (beecount + 1 > 3 ? 4 : beecount + 1) + ");";
            li1.Style["display"] = "";
            ViewState["bee"] = beecount;
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
                                showele["zhezhi"]+=badstars[tmp];
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
                        if(tmpflag > 1)
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
            //Label1.Text += "4.裂痕指数为:" + breakcount + "<br />";
            jsstr += "showItem('liehen', " + (showele["liehen"] > 3 ? 4 : showele["liehen"]) + ");";
            if (showele["liehen"] > 0)
            {
                li7.Style["display"] = "";
            }
            jsstr += "showItem('paopao', " + (showele["paopao"] > 3 ? 4 : showele["paopao"]) + ");";
            if (showele["paopao"] > 0)
            {
                li2.Style["display"] = "";
            }
            jsstr += "showItem('chongzi', " + (showele["chongzi"] > 2 ? 3 : showele["chongzi"]) + ");";
            if (showele["chongzi"] > 0)
            {
                li4.Style["display"] = "";
            }
            jsstr += "showItem('cu', " + (showele["cu"] > 2 ? 3 : showele["cu"]) + ");";
            if (showele["cu"] > 0)
            {
                li8.Style["display"] = "";
            }
            jsstr += "showItem('bingdong', " + (showele["bingdong"] > 2 ? 3 : showele["bingdong"]) + ");";
            if (showele["bingdong"] > 0)
            {
                li6.Style["display"] = "";
            }
            jsstr += "showItem('zhezhi', " + (showele["zhezhi"] > 4 ? 4 : showele["zhezhi"]) + ");";
            if (showele["zhezhi"] > 0)
            {
                li3.Style["display"] = "";
            }
            jsstr += "showItem('kuzhi', " + (showele["kuye"] > 3 ? 3 : showele["kuye"]) + ");";
            if (showele["kuye"] > 0)
            {
                li9.Style["display"] = "";
            }
            int totalbad = showele["paopao"] + showele["chongzi"] + showele["cu"] + showele["liehen"] + showele["bingdong"] + showele["zhezhi"] + showele["kuye"];
            span1.Style["width"] = ((4096 -totalbad * 128) / 32).ToString() + "px";
            ltr1.Text = ((3200-totalbad * 100) / 32).ToString();
            if (ltr1.Text == "0")
            {
                span1.Style["width"] = (1 * 128 / 100).ToString() + "px";
                ltr1.Text = "1";
            }
            if (hongxing && int.Parse(ltr1.Text) >= 70)
            {
                ltr1.Text = (int.Parse(ltr1.Text) - 15).ToString();
                span1.Style["width"] = (int.Parse(ltr1.Text) * 128 / 100).ToString() + "px";
            }
            if (int.Parse(ltr1.Text) > 100)
            {
                span1.Style["width"] = "128px";
                ltr1.Text = "100";
            }
            ViewState["fumian"] = showele;
            Label1.Text += "5.泡泡：" + showele["paopao"] + "; 虫子：" + showele["chongzi"] + "; 醋：" + showele["cu"] + "; 裂痕：" + showele["liehen"] + "; 冰冻：" + showele["bingdong"] + "; 折枝：" + showele["zhezhi"] + "; 枯叶：" + showele["kuye"] + "<br />";
            #endregion

            #region 花盆
            int huapen = 1;
            if (totalbad >= 20)
            {
                huapen = 3;
            }
            else if ((totalbad >= 13 && totalbad < 20) || (hongxing && totalbad > 6))
            {
                huapen = 2;
            }
            Label1.Text += "5.花盆为:" + huapen + "<br />";
            jsstr += "showItem('huapen', " + huapen + ");";
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
            if(m_star[PublicValue.AstroStar.Moo].Constellation==PublicValue.Constellation.Gem ||
                m_star[PublicValue.AstroStar.Moo].Constellation==PublicValue.Constellation.Sag ||
                m_star[PublicValue.AstroStar.Moo].Constellation==PublicValue.Constellation.Pis )
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
            if (m_star[PublicValue.AstroStar.Moo].Gong == 12 )
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
            span3.Style["width"] = (flowercount * 128 / 10).ToString() + "px";
            ltr3.Text = (flowercount * 100 / 10).ToString();
            if (ltr3.Text == "0")
            {
                span3.Style["width"] = (1 * 128 / 100).ToString() + "px";
                ltr3.Text = "1";
            }
            if (int.Parse(ltr3.Text) > 100)
            {
                span3.Style["width"] = "128px";
                ltr3.Text = "100";
            }
            Label1.Text += "5.花心指数为:" + flowercount + "<br />";
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
            span2.Style["width"] = (meilicount * 128 / 12).ToString() + "px";
            ltr2.Text = (meilicount * 100 / 12).ToString();
            if (ltr2.Text == "0")
            {
                span2.Style["width"] = (1 * 128 / 100).ToString() + "px";
                ltr2.Text = "1";
            }
            if (int.Parse(ltr2.Text) > 100)
            {
                span2.Style["width"] = "128px";
                ltr2.Text = "100";
            }

            #endregion

            #region 对方有钱
            int richcount = PublicDeal.GetInstance().GetGongPower(m_astro.Stars, 8);
            if (richcount > 15)
            {
                richcount = 15;
            }
            foreach (PublicValue.AstroStar tmpstar in seven)
            {
                if (m_star[tmpstar].Gong == 8||m_star[tmpstar].Gong == 7)
                {
                    richcount = richcount + 5;
                }
            }
            foreach (PublicValue.AstroStar tmpstar in eight)
            {
                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[tmpstar]) && PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.For], m_star[tmpstar]))
                {
                    richcount=richcount+5;
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
            if (m_star[PublicValue.AstroStar.Jun].Gong==11)
            {
                richcount = richcount + 5;
            }
            if (m_star[PublicValue.AstroStar.Ura].Gong==8)
            {
                richcount = richcount + 5;
            }

            span4.Style["width"] = (richcount * 128 / 30).ToString() + "px";
            ltr4.Text = (richcount * 100 / 30).ToString();
            if (ltr4.Text == "0")
            {
                span4.Style["width"] = (1 * 128 / 100).ToString() + "px";
                ltr4.Text = "1";
            }
            if (int.Parse(ltr4.Text) > 100)
            {
                span4.Style["width"] = "128px";
                ltr4.Text = "100";
            }
            Label1.Text += "6.对方有钱指数为:" + richcount + "<br />";
            //测试显示互溶关系
            List<List<PublicValue.AstroStar>> hurong = PublicDeal.GetInstance().GetHuRong(m_astro.Stars, true);
            foreach (List<PublicValue.AstroStar> tmplist in hurong)
            {
                foreach (PublicValue.AstroStar tmpstar in tmplist)
                {
                    Label1.Text += PublicValue.GetAstroStar(tmpstar) + "->";
                }
                Label1.Text += "<br />";
            }
            #endregion
            jsstr += @"$("".f-box"").children(""div:not(0)"").children(""div"").each(function () {
                                        if (!$(this).is(':has(a)')&&$(this).attr(""id"")!='nohover') {
                                            $(this).bind(""mouseenter"", function () {
                                                $(this).css(""cursor"", ""pointer"")
                                                var bgimg = $(this).css(""background-image"");
                                                bgimg = bgimg.replace("".png"", ""_on.png"");
                                                $(this).css(""background-image"", bgimg);
                                            }).bind(""mouseleave"", function () { 
                                                $(this).attr(""style"", "" "");
                                                $(this).css(""display"", ""block"");
                                            })
                                        }
                                        else {
                                            //蜜蜂等区域热点
                                            $(this).children(""a"").bind(""mouseenter"", function () {
                                                var bgimg = $(this).parent().css(""background-image"");
                                                bgimg = bgimg.replace("".png"", ""_on.png"");
                                                $(this).parent().css(""background-image"", bgimg);
                                            }).bind(""mouseleave"", function () {
                                                $(this).parent().attr(""style"", "" "");
                                                $(this).parent().css(""display"", ""block"");
                                            })

                                        }

                                    })";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "show", jsstr, true);
            ViewState["jsstr"] = jsstr;
            MultiView1.ActiveViewIndex = 1;

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "showflash",
            //        @"swfobject.embedSWF('LoveRose.swf', 'flashmov', '816', '459', '9.0.0',null,{ele:'"+ele+"'});",true);

            #region 记录用户数据
            LoveRoseMod m_record = new LoveRoseMod();
            m_record.Area = int.Parse(HiddenField2.Value);
            m_record.BirthTime = m_astro.birth;
            m_record.Source = (int)AppEnum.AppsSourceType.qq;
            m_record.TS = DateTime.Now;
            LoveRoseBll.GetInstance().Add(m_record);
            #endregion

            #region 显示信息
            ltrInfo.Text = m_astro.birth.ToString("yyyy年MM月dd日 HH:mm") + @"
                    <br />
                    性别："+AppEnum.GetGender(m_astro.Gender)+@"<br />
                    所属时区： " + (m_astro.zone > 0 ? "西" + m_astro.zone.ToString() : "东" + m_astro.zone.ToString()) + @"区<br />
                    夏令时：" + (((int)m_astro.IsDaylight) == 1 ? "是" : "否") + @"
                    <br />
                    出生地： " + m_astro.position.name.Remove(m_astro.position.name.LastIndexOf("-")) + @"
                    <br />
                    (经度" + m_astro.position.Lng + @"&nbsp;纬度" + m_astro.position.Lat + @")
                    <br />";
            #endregion

            HyperLink1.NavigateUrl = "http://share.v.t.qq.com/index.php?c=share&a=index&url=" + Server.UrlEncode("http://astro.fashion.qq.com/app/aiqinghua.htm") +
                    "&pic=" + Server.UrlEncode("http://app.ssqian.com/WebResources/Images/LoveRose/img/1.jpg") + "&appkey=801402959&title="+ Server.UrlEncode("#腾讯星座爱情花# " + AppCmn.CommonTools.CutStr(content[int.Parse(ViewState["hua"].ToString()) - 1, 0],50) + "... 快来测测你的爱情花") + "&line1=&line2=&line3=";
            
        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable m_dt = SYS_DistrictBll.GetInstance().GetSubLevel(int.Parse(HiddenField3.Value));
            Repeater2.DataSource = m_dt;
            Repeater2.DataBind();
            if (m_dt.Rows.Count > 0)
            {
                district2.InnerText = m_dt.Rows[0]["name"].ToString();
                HiddenField2.Value = m_dt.Rows[0]["sysno"].ToString();
            }
            if (IsPostBack)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "refresh", "refreshdistrict();", true);
            }
            //UpdatePanel2.Update();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "initialselect();", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = int.Parse(HiddenField5.Value);
            if (i == 1)
            {
                i = int.Parse(ViewState["hua"].ToString())-1;
            }
                else
            {
                i++;
            }
            ltrTipTitle.Text = title[i];
            ltrTipContent.Text = content[i,0];
            if (i == 18)
            {
                int tmpbee = int.Parse(ViewState["bee"].ToString());
                ltrTipContent.Text = content[i, tmpbee-1];
            }
            tip.Style["display"] = "";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "showtmp", ViewState["jsstr"].ToString(), true);
        }

        #region 解释

        string[] title = 
        {
            "一串红，花语：甜蜜，热烈",
            "向日葵，花语：自信，忠诚",
            "蝴蝶兰，花语：博学，多才",
            "勿忘我，花语：不要忘了我，记得想我噢",
            "红玫瑰，花语：我爱你，热情而浪漫",
            "水仙花，花语：自恋，细腻",
            "百合花，花语：隐忍宽容，百年好合",
            "彼岸花，花语：执着，无尽的爱",
            "天堂鸟，花语：潇洒自由，热恋中的情人",
            "非洲菊，花语：负责任，互敬互爱，不畏艰难",
            "郁金香，花语：博爱，聪颖，渴望回应",
            "紫罗兰，花语：在梦境中爱上你",
            "冰冻",
            "虫子",
            "泡泡",
            "折枝",
            "黄叶子",
            "裂痕",
            "醋瓶",
            "蜜蜂",
            "红杏",
            "花盆",
        };
        string[,] content = { 
            {"犹如一串红甜甜的花蕊，跟你恋爱也是一件快乐的事。你一旦发现心仪的对象，就会毫不犹豫地发起热烈的攻势，无论男生女生都有主动表白的勇气，不管是情敌的挑衅，还是家人的反对，你都无所谓。某种程度的兴奋或危险，是你爱情的主题。你冲动而果断，很容易一见钟情，但可能随即又感到后悔。你在感情上很容易出现竞争性，越是能激起你的征服欲和危机感，你就越有爱的激情。你率直和看似天真的特质，非常具有杀伤力，常能在不经意间秒杀那些低调的土豪。因为你在爱情中不愿妥协和自我中心的倾向，“如果你爱我，就该给我我想要的一切”，“如果你爱我，就该让我做我自己”。你的伴侣也会努力把你放在第一位，给你很多礼物和惊喜。","","",""},
            {@"向日葵代表你是很有品味的人，喜欢舒适优雅的生活，享受人生。在音乐和艺术方面颇有天赋，大多拥有天生甜美的嗓音，又很会梳妆打扮，让异性为之倾倒。因此你对异性的要求不会低。你希望你们的感情是持久且有保障的，所以会很看重对方的经济实力。你的伴侣很可能是型男靓女，或是有不错的经济基础，是潜力股的可能性也很大。追求忠诚和安定的你比较慢热，总是小心翼翼的进入一段感情，不喜欢被勉强被驱迫。因为你敏锐的触觉，所以会很享受与爱人之间的身体接触，如果少了这层满足，可能会跟伴侣渐行渐远。","","",""},
            {"蝴蝶兰代表你有着多姿多彩的爱情及社交生活，往往以思维敏捷、口齿伶俐和不易捉摸引起人注意。有语言天赋或是文学诗歌的鉴赏力，让你很擅于“甜言蜜语”。你就像是爱情里的花蝴蝶，左右逢源，异性缘极佳，很轻易就能同时吸引许多对象。你喜欢调情，懂得如何让别人放松，保持轻松愉悦的氛围，但却很难安定下来。事实上，真的动情往往会浇灭你的热情，空想和幻想才能令你保持兴趣。重视沟通与交流的你，很少会被他人的外表或金钱长期的吸引，相反会很欣赏才华横溢的人，某种程度上，你是想找一个可以学习的对象。因此，你的伴侣很可能是某个领域的技术性人才，外表朴实，低调奢华有内涵，是难能可贵的灵魂伴侣。","","",""},
            {@"犹如勿忘我蓝色的小花，代表了你在爱情中的敏感与胆怯。你总以旁敲侧击的迂回方式拉近彼此的距离，不愿在感情上冒险，害怕被辜负被伤害，而你一旦投入一段感情之中，就会有粘人的倾向，难以放下对方。可能是青梅竹马的恋人，或是青涩初恋的单相思，或是长期交往的男女朋友，难以忘记过往的一切，甚至执着于过往的爱情关系。有时也会为了某些记忆而特别珍惜老旧的东西。你温柔浪漫且富有同情心，有时像个任性的小孩，渴望被宠爱被保护，因此你的伴侣很可能比你年长很多，阅历丰富，能给你足够的安全感，为你建筑一个安乐窝。","","",""},
            {@"就像地球人都知道红玫瑰代表我爱你一样，你也喜欢被追求被关注，不喜欢被忽略。爱和关注能让你更加自信。恋爱中的你殷勤而热烈，会把聚光灯完全照在对方身上，我好爱你啊，好爱好爱你啊，你巴不得让对方到你心里去看看，你爱他的心。你就是如此冲动与张扬，你无法压抑你对他的爱，你渴望轰轰烈烈的爱一场，跟你谈恋爱还真有做show的感觉呢。你会为对方做很多浪漫的事情，慷慨而热情。你会被他人的外表，创意或魅力所吸引，因此你的另一半很可能是帅哥美女，企业家，甚至是名人。","","",""},
            {@"水仙花代表你对自己的评价通常不错，非常自信，甚至自恋，所以你在爱情中对待异性的要求也颇高，甚至有点完美主义倾向，身材相貌不能差，能力财力不能少，对方的卫生习惯，礼貌礼仪，都在你的考察范围内。有时候过度的分析与挑剔，破坏了爱的感觉，所以成为剩男剩女的几率相当大。水仙也代表你是心思细腻，感情敏锐的人，会非常的重视细节，比如设计很多有特殊意义的约会，或是简单愉快的旅行，也会非常重视自己是不是可以帮到对方，让对方很有面子，一旦你们的感情出现任何蛛丝马迹，也会第一时间被你察觉。你的伴侣很可能是通过工作认识的，是那些经常被忽略被冷落的人，不太起眼却非常认真有责任感的人。","","",""},
            {"百合花代表你喜欢外貌出众会打扮，处事圆滑有分寸以及志趣相投的异性，还要不时表现出对你的迷恋。你喜欢有人陪伴，而不是独处，因此你很渴望婚姻生活，容易把婚姻理想化，也容易失望。你的伴侣可能外表姣好，并且脾气很好，但要你下定决心也不是一件容易的事，因此让你找一位更年轻的模特来代替老伴也是极少发生的。重视和谐、良好关系的你，懂得妥协，有不错的交际手腕和协商的能力，是治愈系的代表人物，懂得以得体的语言来安抚人心。你也会尽可能的避开冲突，不去面对，但等到不得不面对的时候已经一发不可收拾了，这是你要注意的地方。你的伴侣可能与艺术，法律或音乐相关，并且他们的到来会为你的经济带来巨变，变好或变坏都有可能。","","",""},
            {"彼岸花代表你不会以轻松的态度进入一段关系，也无法轻松的离开一段关系。你对感情非常的真诚、热烈而执着，不顾一切的付出，也很难从一段感情中抽离出来，总之就是很难放弃，要给自己一个很好的理由才可以。你是敢爱敢恨的人，这两种情感都很强烈。“我爱你，可以付出一切”“我恨你，恨之入骨”，一旦被抛弃或是爱情幻灭时，会有嫉妒，憎恨，痛苦，被背叛的强烈情绪，有时会有极端的表现，甚至色欲纵横。你可能很难信赖他人，永远在检视你的伴侣或密友；也可能过于信赖对方而受到严重伤害。你容易被复杂，神秘，深不可测的人吸引，你自身也散发着表面平静内心澎湃的吸引力，别人通常无法一眼看透你。你们的亲密关系可能出现某种程度的混乱和戏剧化情节，有时还带有几分禁忌，或是不被允许。比如，为了种族，宗教，过往的情感纠葛，复杂的财务状况，或是为了同性恋及其他社会偏见而抗争，争取在一起。切记，不要因为过于执着而受伤。","","",""},
            {"天堂鸟代表在爱情的世界里，你是要求自由与空间的人，渴望探索各式各样的人际关系，但很少能轻易付出承诺。勇于冒险和玩乐的你，只要一旦感觉关系紧张或沉重，就会找理由跑掉。你对爱情有很高的理想，但24小时只有7小时与伴侣在一起，关系可能很难长久，你也总觉得墙外的草会绿一些。对你而言，爱情就是一场冒险，未来比过去更有吸引力，未知的世界更精彩。你的乐观，幽默，逍遥以及观望的态度常常令人着迷，你也可能特别留意异国风情和文化，喜欢慷慨，轻松，勇于冒险的人，非常排斥狭隘平庸的生命态度，甚至展现出充沛的活力。你热爱学习，会被宗教和哲学所吸引，甚至改变你伴侣的信仰价值观。","","",""},
            {"非洲菊代表你是稳重，高尚，从容，有专业素养的女性，而男性则会被典雅有档次的女性所吸引。你总是展现出得体的举止和受人尊敬的态度，有责任感和自制力，懂得控制情绪，很可能成为有事业魅力的人，很少会沉浸在轻浮的行为里。你会认真看待你们的关系，对爱情少有幻觉，从现实出发考虑较多，会付出极大的努力让关系顺利。你在乎安全感和成就感，所以会与地位较高的人结婚，也可能与富有的人谈恋爱，你的伴侣很可能是通过工作事业认识的，可能有较大的年龄差距，他们专业，高效。一旦关系确立，你会为对方各种操心和服务，把对方的事当成自己的事，尽心尽力。","","",""},
            {"郁金香代表你是喜欢大自然和结交朋友的人。优美的风景能让你精神振奋。你也很友善，喜欢社交和宴会，朋友很多，想要和每个人都做朋友，朋友往往会变成爱人，或让爱人变成朋友，两者之间的界限不是很明显。或者说你喜欢像朋友一样的恋人。你的朋友和爱人都有可能来自各个阶层，你并不在乎他们的阶级、收入、肤色或信仰。你的爱情通常是突如其来的，未必能稳定持续。你认为在爱情与婚姻中，精神层面的契合非常重要，因此比较会被别人的内在而非外表吸引，也会偏好那些才气不凡，独立、不平凡的人。你也希望付出是有回报的，所以不计回报默默付出的事怎么也不可能发生在你身上，当你为对方做这做那的时候，会在心中有一些美好的期许，希望对方能够给你想要的。","","",""},
            {"紫罗兰代表在爱情里你是比较被动的人，你只需要眨眨眼就能引起别人的注意，不需要说太多的话或是太多的动作。有时会容易在关系里迷失自己，也会在爱情里做出牺牲，把自己完全的交出去，营造关系可能是你逃避单调乏味生活的途径。但你可能很难在感情上做出承诺，因为你不知道是否真的爱对方，或是只想沐浴在对方的爱之中，承诺之后往往就意味着没有其他可能性了。你渴望的其实是爱情开始时的浪漫和暧昧的味道，也会喜欢柏拉图式的爱情，会被精神性的爱或是大爱所吸引。在爱情中，你可能会因为迷恋对方给你的某种感觉，而一次次的美化对方和自我欺骗，可能对方并没有那么的好，但你却把他的优点扩大化了，可能自己还没有很爱对方，却告诉自己很爱对方，明明你们的感情已经出现了问题，却告诉自己他是不会变心的。因此，客观理性一些，放下一些幻想和不切实际，能让你的爱情更完美。","","",""},
            {"冰冻是影响你恋爱与婚姻的不利因素，代表你在恋爱或婚姻中可能出现以下问题：恋爱次数较多，容易频繁的分手，每一次都轰轰烈烈，但都难有完美的结局；试图改造对方，忽略对方的感受；遇到问题，固执己见，不沟通冷暴力，不想问对方也懒得听解释；突然的分手或离婚。如果只是少量冰冻，并无大碍，需要增进与对方的沟通交流，彼此分享快乐，分担忧愁；如果爱情花中还同时出现醋瓶，折枝，裂痕，泡泡，虫子，黄叶等其他不利因素（出现的越多暗示你的婚姻问题就越严重），可能情路坎坷，婚姻不幸，渐行渐远，难以圆满。","","",""},
            {"虫子是影响你恋爱与婚姻的不利因素，代表你在恋爱与婚姻关系中计较比较多，过于保护自己，过于计较得失，希望对方更爱你，自己不愿吃亏；会因为一些客观因素被迫的分开，难以偕老，伴侣早逝，异地恋，家庭因素等等，非常的无奈无助。如果只是少量的虫子，你就需要自我反省一下，送人玫瑰手有余香，付出也是一种快乐，能吃亏也是一种福气，感情中不要太计较。如果虫子比较多，再加上爱情花中又同时出现冰冻，醋瓶，折枝，裂痕，泡泡，黄叶等不利因素（出现的越多暗示你的婚姻问题就越严重），那么感情的变故通常自己很难改变，有种天意弄人的感觉，难以圆满。","","",""},
            {"泡泡是影响你恋爱与婚姻的不利因素，象征了隐瞒与欺骗，代表你们之间不够透明，有些难以启齿的秘密或欺骗；可能遭遇地下情或第三者；你会过度美化对方，把对方想得太好，之后又觉得不满意，经常看错人。如果只是少量泡泡，说明症状轻微，婚前波折或是隐藏的问题不一定会暴露出来，不一定会对婚恋产生特别明显的影响。如果泡泡数量较多，爱情花中又同时出现冰冻，醋瓶，折枝，裂痕，虫子，黄叶等不利因素（出现的越多暗示你的婚姻问题就越严重），这时会因为真相的暴露而带来伤害，关系破裂难以避免。所以还需多加注意。","","",""},
            {"折枝的出现代表你在恋爱或是婚姻关系中比较敏感，常把对方无心的言行误认为是对抗自己，针对自己，易感情用事；容易产生敌对情绪，缺乏耐性和包容心；容易起无名火，心直口快，有什么话一定要说出来；过于坚持自己的原则，甚至无法为了顾全大局而暂时的让步，锋芒毕露，不圆滑，一意孤行。如果只出现了一个折枝，说明症状轻微，你需要学习软化的交际手腕，避免不必要的冲突，家和万事兴。如果折枝的数量较多，爱情花中又同时出现冰冻，醋瓶，泡泡，裂痕，虫子，黄叶等不利因素（出现的越多暗示你的婚姻问题就越严重），会经常吵架，甚至大打出手，严重影响感情，甚至因为意识形态的不同，导致离婚。","","",""},
            {"黄叶是影响你恋爱与婚姻的不利因素，代表你在两性关系中过于主观，想当然，可能先结婚后恋爱；认为自己可以改变对方，结果却不行；高估了自己，轻视了困难，因为过度自信，而忽略了很多问题；神经大条，大大咧咧，觉得一切都很好，你们之间没什么问题，而恰恰掩饰了很多问题；当问题真正暴露出来的时候，你会采取半放弃的状态，原本积极努力可以改变的事情，你也懒得采取行动，这种疏忽和怠慢的态度常常让你的伴侣觉得你不在乎ta，因此导致关系的破裂。如果只是少量的黄叶，说明症状轻微，你需要更客观的看待你的伴侣和你们的未来，凡事多个心眼。如果黄叶较多，爱情花中又同时出现冰冻，醋瓶，泡泡，裂痕，虫子，折枝等不利因素（出现的越多暗示你的婚姻问题就越严重），就需要特别注意了，否则婚姻不幸，难以圆满。","","",""},
            {"裂痕是影响你恋爱与婚姻的不利因素，代表你在恋爱与婚姻关系中可能出现以下问题：容易晚恋，晚婚，甚至不婚；在感情方面缺乏自信，总是害怕自己不会幸福，对待感情想而不敢；比较苛刻和严厉，对方怎么做都难让你满意；不会换位思考，老是挑剔对方；让对方觉得你不够温柔，争吵不断，感情不睦。如果只是轻微的裂痕，大多婚前波折，缺乏甜蜜感。如遇到较大的裂痕，并且爱情花中同时出现冰冻，醋瓶，泡泡，黄叶，虫子，折枝等不利因素（出现的越多暗示你的婚姻问题就越严重），会严重影响夫妻感情，毫无快乐可言，导致离婚。","","",""},
            {"醋瓶的出现代表你是一个比较敏感，容易生气容易吃醋的人，控制欲和占有欲比较强，容易觉得对方背叛了自己；缺乏耐性，情绪化；比较强势和任性，想做的一定要做，原本理智一点可以避免的冲突却因一时任性后悔莫及。如果只是少量的醋，或许你只是容易产生嫉妒的情绪而已，对方并没什么过错，你需要调节自己的心态，减少一些不必要的负能量。但如果是满瓶的醋，就极大的增强了对一段感情的破坏性，遭遇第三者，被劈腿的可能性很大。如果爱情花中还同时出现冰冻，裂痕，泡泡，黄叶，虫子，折枝等不利因素（出现的越多暗示你的婚姻问题就越严重），会完全无法信任对方，极度缺乏安全感，导致离婚。","","",""},
            {@"蜜蜂的数量代表了你的异性缘，如果只出现了一只蜜蜂，说明你的异性缘比较弱，很少有人追求，或是总也追不到自己喜欢的人，可能一直单身很多年。或许你的条件也不差，但就是少有人追，说出去都没人信。看见别人总是出双入对，难免会有些羡慕。逢年过节，更是各种被逼相亲催婚，非常的无奈苦恼。","蜜蜂的数量代表了你的异性缘，如果出现了两只到三只蜜蜂，说明你的异性缘中等或偏上，不愁找不到男（女）朋友，遇到桃花运好的年份，更是桃花朵朵开，小心挑花了眼哦，只是偶尔苦恼，烂桃花太多，何时是正缘？","蜜蜂的数量代表了你的异性缘，如果出现了两只到三只蜜蜂，说明你的异性缘中等或偏上，不愁找不到男（女）朋友，遇到桃花运好的年份，更是桃花朵朵开，小心挑花了眼哦，只是偶尔苦恼，烂桃花太多，何时是正缘？","如果还出现了蝴蝶，说明你的异性缘真是超好的，可谓人见人爱，花见花开，从来不乏追求者，以致众多的追求者让你难以抉择，甚至是众人的男神女神。即使你已经名花有主了，还会有人对你表达爱慕之情。如果你还单身，那么桃花朵朵，多多益善；如果你已经结婚，就需要意志坚定的抵制那些烂桃花，减少一些不必要的麻烦，才能让爱情之花长久常开。"},
            {"红杏是影响你恋爱与婚姻的不利因素，所谓一枝红杏出墙来，代表你伴侣出轨的可能性很大，也就是你很可能被劈腿。这对任何一段感情来说，都无疑是一种打击。但具体情况还需结合爱情花的其他因素而定，如果爱情花中并无其他不利因素，那么婚姻还是可以维持稳定的，只是中途可能会有一些不愉快的插曲，你不一定会知道，也不一定很在意。如果爱情花中还同时出现冰冻，裂痕，泡泡，黄叶，虫子，折枝等不利因素（出现的越多暗示你的婚姻问题就越严重），那么暗示你的婚姻困难重重，危机四伏，遇到运势不好是流年，就很可能会离婚。","","",""},
            {@"花盆代表了你的另一半以及婚姻的状况。如果出现了两个花盆，说明你的婚姻存在一些隐患，问题比较严重，遇到运势不好的流年，有可能会离婚。如果出现了三个花盆，说明问题更加严重了，三婚不足为奇，在感情和婚姻方面很受挫折，甚至一度对爱和婚姻失去信心。具体问题，可以参考爱情花中出现的其他不利因素（冰冻，裂痕，泡泡，黄叶，虫子，折枝，醋瓶）进行分析，对症下药，未雨绸缪，多加防范。","","",""},
                           };
        #endregion




    }
}