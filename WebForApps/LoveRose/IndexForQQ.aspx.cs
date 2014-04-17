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
            #endregion

            #region 花盆
            Label1.Text += "5.花盆为:" + PublicValue.GetConstellation(m_star[PublicValue.AstroStar.Jun].Constellation) + "<br />";
            jsstr += "showItem('huapen', " + ((int)m_star[PublicValue.AstroStar.Jun].Constellation % 3 + 1) + ");";
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
            jsstr += "showItem('zhezhi', " + (showele["zhezhi"] > 0 ? 1 : 0) + ");";
            if (showele["zhezhi"] > 0)
            {
                li3.Style["display"] = "";
            }
            jsstr += "showItem('kuye', " + (showele["kuye"] > 0 ? 1 : 0) + ");";
            if (showele["kuye"] > 0)
            {
                li9.Style["display"] = "";
            }
            int totalbad = showele["paopao"] + showele["chongzi"] + showele["cu"] + showele["liehen"] + showele["bingdong"] + showele["zhezhi"] + showele["kuye"];
            span1.Style["width"] = ((6400 -totalbad * 128) / 50).ToString() + "px";
            ltr1.Text = ((5000-totalbad * 100) / 50).ToString();

            Label1.Text += "5.泡泡：" + showele["paopao"] +"; 虫子："+showele["chongzi"] + "; 醋："+ showele["cu"] + "; 裂痕："+ showele["liehen"] + "; 冰冻："+showele["bingdong"] + "; 折枝：" + showele["zhezhi"] + "<br />";
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
            if (PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Sun].Constellation) == PublicValue.Element.wind)
            {
                flowercount++;
            }
            if (PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Moo].Constellation) == PublicValue.Element.earth)
            {
                flowercount++;
            }
            if (m_astro.Gender == AppEnum.Gender.male)
            {
                flowercount++;
            }
            span3.Style["width"] = (flowercount * 128 / 10).ToString() + "px";
            ltr3.Text = (flowercount * 100 / 10).ToString();
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
            if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Sun], m_star[PublicValue.AstroStar.For]))
            {
                meilicount++;
            }
            #endregion

            #region 对方有钱
            int richcount = PublicDeal.GetInstance().GetGongPower(m_astro.Stars, 7);
            span4.Style["width"] = (richcount * 128 / 70).ToString() + "px";
            ltr4.Text = (richcount * 100 / 70).ToString();
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
            ltrTipContent.Text = content[i];
            tip.Style["display"] = "";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "showtmp", ViewState["jsstr"].ToString(), true);
        }

        #region 解释

        string[] title = 
        {
            "金星白羊一串红  花语：甜蜜，热烈",
            "金星金牛向日葵   花语：自信，忠诚",
            "金星双子蝴蝶兰，花语：博学，多才",
            "金星巨蟹勿忘我，花语：不要忘了我，记得想我噢",
            "金星狮子红玫瑰，花语：我爱你，热情而浪漫",
            "金星处女水仙花，花语：自恋，细腻",
            "金星天枰百合花，花语：隐忍宽容，百年好合",
            "金星天蝎彼岸花，花语：执着，无尽的爱",
            "金星射手天堂鸟，花语：潇洒自由，热恋中的情人",
            "金星摩羯非洲菊，花语：负责任，互敬互爱，不畏艰难",
            "金星水瓶郁金香  花语：",
            "金星双鱼紫罗兰，花语：在梦境中爱上你",
            "天王星：冰冻",
            "水星：虫子",
            "海王：泡泡",
            "火星（太阳）：折枝",
            "木星（金星）：黄叶子",
            "土星：裂痕",
            "冥王（月亮）：醋瓶",
        };
        string[] content = { 
            "犹如一串红甜甜的花蕊，跟你恋爱也是一件快乐的事。你一旦发现心仪的对象，就会毫不犹豫地发起热烈的攻势，无论男生女生都有主动表白的勇气，不管是情敌的挑衅，还是家人的反对，在你看来这都不是事儿。但你也较缺乏耐心，一旦久攻不破，难保你不会打消念头，因为你就是干净利落绝不多话，率直又有个性。一串红代表你喜欢个性开朗，独立单纯的异性，很容易一见钟情，并容易将爱情理想化，“我也许喜欢怀念你，多于看见你。我也许喜欢想象你，多于得到你” 有时候，与其说你爱着对方，不如说是你与自己的精神在谈恋爱。正因如此，你在爱情中常给人三分钟热情的感觉，你希望你们永远都是快乐的，缺乏为对方排忧解难的耐心，不想太操心，可能关注自己比关注对方更多一些，如果对方的负能量太多，会成为导致感情危机的定时炸弹，说不定哪天就爆发了。",
            @"让我们先来看一个关于向日葵的美丽传说：克丽泰是一位水泽仙女。一天，她在树林里遇见了正在狩猎的太阳神阿波罗，疯狂地爱上了他。可是，阿波罗连正眼也不瞧她一下就走了。克丽泰热切地盼望有一天阿波罗能对她说说话，但她却再也没有遇见过他。她只能每天仰望天空，看着阿波罗驾着金碧辉煌的太阳轮划过天空，直到他下山。后来，众神怜悯她，把她了一朵很大的向日葵，永远向着太阳，诉说她永远不变的爱慕。<br />
因此，向日葵寓意传说中的高富帅才是你的梦中情人，犹如太阳神阿波罗，是古希腊神话中的花样美男，超高的音乐才华，九头身的完美身材，以至于古希腊的雕刻艺术常借他的形象来表现男性之美，并且家世显赫，是众神之王宙斯与暗夜女神之子。向日葵也代表你是很有品味的人，所以对待异性的要求自然不低。就性格而言，你也喜欢心智成熟，霸道一点的异性，一定要是超自信超幽默的，唯唯诺诺，害羞胆怯的男生是难入你法眼的。<br />
向日葵也代表你对爱情的忠诚与专一，不管你以什么方式开始一段感情，你都希望能有一个好的结果，对对方也是尽心尽力，关怀备至。但时间长了，你可能会比较迟钝，明明你们的感情已经出现了问题，但你还是一如既往的认为你们感情很好很恩爱，所以裂痕一旦显露出来，就会让你难以接受，伤心复原期通常会是别人的两倍。",
            "蝴蝶兰代表你对博闻多识，眼界开阔，知书达礼的异性情有独钟，最好能聪明过人，知道很多你不知道的，带给你很多闻所未闻，见所未见的全新体验，相反，你就最讨厌见识浅薄，遇到问题啥都不能解决的人了。因此文化知识，学历高低在你这里还是蛮加分的。你就像是爱情里的花蝴蝶，左右逢源，异性缘极佳，从来不会寂寞，因为你害怕寂寞。蝴蝶兰也寓意你是比较粘人的另一半，希望跟对方有说不完的话，可以一起学习，相互陪伴，共同进步，建立紧密的联系，犹如“八月蝴蝶黄，双双花上飞”，总是看见你们出双入对是再平常不过了。你也是体贴入微，善解人意的另一半，“把你的快乐告诉我，快乐就会多一倍；把你的烦恼告诉我，你的烦恼就会少一半”你希望你们是无话不说的，对方不要把心事藏起来，你很乐意为他分担忧愁，出谋划策，如果对方要求很多独立的空间，凡事都要自己扛，总是冷落你，那你对他的感情也就走远了。",
            @"如花语所言，勿忘我寓意你在爱情中对对方的要求比较多，像小孩子一样，会提出一些任性的要求，比如“我现在就要去找你，不管你到底忙不忙，不管你到底会不会耽误其他事”可能在别人看来有点无理取闹，但这正是你爱对方的独特方式——你需要他，依赖他。如果我不爱你，我还会让你帮我做这做那吗？我还会要粘着你吗？你说是不是？因为你希望对方爱你多一点，再多一点，对你好一点，再好一点。在爱情上你是贪婪的，需要被溺爱的感觉。你希望你在对方心里就是最重要的，基友，工作，统统靠后。所以当要求没有被满足的时候，你就很容易闹情绪了。<br />
因为你在感情中比较被动和缺乏安全感，所以你喜欢主动，强势一点的异性，最好能看穿你的心，知你所想，无条件满足你的各种要求。坚强有责任感，不会轻易的妥协和放弃。最好不要太枯燥太无聊，浪漫惊喜多多益善。",
            @"就像地球人都知道红玫瑰代表我爱你一样，你的爱情也要让大家都知道。我爱你，就要告诉全世界，让大家见证幸福，分享喜悦。你是甜蜜而热烈的恋人，我好爱你啊，好爱好爱你啊，你巴不得让对方到你心里去看看，你爱他的心。你就是如此冲动与张扬，你无法压抑你对他的爱，你渴望轰轰烈烈的爱一场，跟你谈恋爱还真有做show的感觉呢。你会为对方做很多浪漫的事情，甜言蜜语更不会少，绝不会吝啬付出。<br />
红玫瑰也代表你重视感觉，所以你一见钟情的几率也很高，喜欢甜美单纯的萝莉，或阳光洒脱的正太，有原则有主见，乐观向上，传递正能量。讨厌对方老是翻旧账，拿过去说事儿。因为曾经深爱过，所以即使到了不得不分手的时候，你也是极有风度的，你甚至不愿主动提出，不想亲口说出无情的话，不想伤害对方，好聚好散才是你所希望的。",
            @"我们先来看一个关于水仙花的美丽传说：希腊神话中有一个男孩叫那格索斯，身下来就有预言，他只要不看见自己的脸就能一直活下去，孩子长大后英俊漂亮，许多姑娘爱上了她，但他对她们冷淡，追求者们生气了，要求众神惩罚傲慢的人。有一次，那格索斯打猎回来，往清泉里看见自己，并爱上了自己的形象，目光离不开自己的脸，直到死在清泉边。就这样，在他死去的地方长出了一株鲜花----水仙花。这也就是为什么水仙花总是长在水边的原因。<br />
水仙花代表你对自己的评价通常不错，自信，甚至自恋，所以你在爱情中对待异性的要求也颇高，甚至有点完美主义倾向，身材相貌不能差，能力财力不能少，总之就是各种比较与挑剔，所以成为剩男剩女的几率相当大。水仙也代表你是心思细腻，感情敏锐的人，会非常的重视细节，比如设计很多有特殊意义的约会，或是简单愉快的旅行，也会非常重视自己是不是可以帮到对方，让对方很有面子，一旦你们的感情出现任何蛛丝马迹，也会第一时间被你察觉。",
            "百合花代表你喜欢外貌出众会打扮，温柔体贴善照顾，处事圆滑有分寸的异性，还要不时表现出对你的迷恋。你具有处理感情问题的天赋，“忍一时风平浪静，退一步海阔天空。”所以常常能把矛盾化解在无形之中。因此，你也希望对方能有一颗宽容的心，如果你们吵架了，TA能主动认错和讨好你，那你也就更爱TA了。跟你谈恋爱也是一件惬意的事，因为你出了名的好脾气，以及极高的配合度，会说各种对方想听的话讨他们欢心，也会心甘情愿的满足对方的要求，比如奔波的帮对方买东买西，自己没有很想看电影也会陪TA去等等。说到底，还是因为你很在乎陪伴的感觉，需要人陪也愿意陪伴，所以你也是很容易妥协的。但如果就此以为你是好欺负的软柿子，那可就错了。别看你爱的时候喜欢腻在一起，想分手了可是很决绝的，从话痨变成无话可说，直接人间蒸发了。",
            "彼岸花寓意你对爱情非常的真诚与执着。你喜欢善解人意，很有亲和力，能够未雨绸缪关心你的异性，或是能跟你心有灵犀，出淤泥而不染，坚忍不拔的人。你在爱情之初，会因为胆怯和不自信，不敢直接表白，默默关注，在不经意间暗示对方，一个暧昧的眼神，一条关怀的短信，多希望TA能读懂你的心。而一但关系确定，你会用你的浓情蜜意去馈赠，天真的像个小孩，毫无心机可言，你是值得信赖和依靠的伴侣。彼岸花也代表你很难从一段感情中抽离出来，甚至是长时间的单恋，难有结果的感情，或已经结束的感情。你可以不顾一切的爱上对方，为对方牺牲和付出很多，总之就是很难放弃，必须要给自己找到一个很好的借口，属于不到黄河心不死，不撞南墙不回头的类型。就像彼岸花一样，花开时看不到叶，有叶子时看不到花，花叶两不相见，生生相惜。切记不要因为过于执着而受伤。",
            "天堂鸟代表在爱情的世界里，你是要求自由与空间的人，希望对方想着你，但又不要打扰你，但也不要离开你，不要给你太多的要求与压力，不然爱情就像笼子，没有了自由，即使对你再好，也没有快乐可言了。你也不喜欢对方太过热情，因为你希望你才是这段感情的主导者。有时候你热情似火，有时候又消失不见，这种忽冷忽热会让对方缺乏安全感，但你只是不那么粘人罢了，你很重视内心的感觉，对方爱不爱你不重要，你爱不爱TA才是最重要。为了爱情，你可以做出很冲动很疯狂的事情，比如不远千里，只为给对方一个惊喜，尤其重要的节日纪念日，浪漫惊喜不会少。你喜欢心无旁骛，没有心计，清纯简单的异性，最讨厌俗不可耐，唯利是图的人。拜金女，或吃软饭的男生，都是你最看不起的。爱情那么纯粹，一旦和金钱利益混为一谈，还会那么美好吗？",
            "非洲菊代表你喜欢成熟稳重的男生，或庄重矜持的女生，太过轻浮和热情的，在你看来都不靠谱。当然最重要的一点是尊重你和你的家人，认可你和你做的事。在开始一段感情之前，你通常都会想很多，家庭背景是否匹配，以后的生活怎么样，生几个孩子等等，因为你不想在没有结果的感情上浪费时间和精力，所以恋爱经历通常较少。不以结婚为目的恋爱就是耍流氓，说的就是你了。非洲菊又叫扶郎花，顾名思义，代表了对另一半的扶持，也就是贤内助的意思。所以一旦认可一段感情，你也同时肩负起了一份责任，会为对方各种操心和服务，生怕对方受苦受委屈，专一也是没话说。当然，如果当你想要分手的时候，就会放下这份责任，不再管对方的任何事情，因为你已经失望至极，不想再忍受了。",
            "郁金香代表你喜欢圆融低调有内涵，古灵精怪有个性的异性，不要太过鲁莽和冲动。你是爱情里的现实主义者，从来不做亏本生意，什么默默付出不计回报的事怎么也不可能发生在你身上。当你为对方做这做那的时候，会在心中有一些美好的期许，你希望对方能够给你想要的，但如果在付出了一段时间后发现自己什么也没有得到，你就会质疑或是选择离开了。说到底，还是你害怕被辜负被伤害的心态作怪，自我保护意识比较强。对你而言，不爱你的你不爱，没有回应的爱情多可悲，因此，你喜欢跟伴侣相互分享，相互陪伴，一起成长。如果对方达不到你的要求，你会变得很冷漠，也会很快用新恋情去代替旧恋情，理性洒脱向前看，相信下一个会更好。",
            "紫罗兰代表你喜欢个性坚强又独立的女生，或是坚韧有经历的男生，遇到困难和挫折从不抱怨，抗压能力强，可以承受很多痛苦的人，最能激起你的同情心。紫罗兰也代表你可能比较早熟，很小就对爱情有着如梦如幻的憧憬，脑海中有无数美丽动人的画面，渴望一场属于自己的恋爱，你真的很想爱，很敢爱。但你表达爱情的方式却是委婉而暧昧的，羞涩而温暖的，一切仿佛都若无其事，对方却一步步自投罗网了。而在爱情中，你可能会因为迷恋对方给你的某种感觉，而一次次的美化对方和自我欺骗，可能对方并没有那么的好，但你却把他的优点扩大化了，可能自己还没有很爱对方，却告诉自己很爱对方，明明你们的感情已经出现了问题，却告诉自己他是不会变心的。总之就是有很多的幻想和不切实际。",
            "冰冻是影响你恋爱与婚姻的不利因素，代表你在恋爱或婚姻中可能出现以下问题：恋爱次数较多，容易频繁的分手，每一次都轰轰烈烈，但都难有完美的结局；试图改造对方，忽略对方的感受；遇到问题，固执己见，不沟通冷暴力，不想问对方也懒得听解释；突然的分手或离婚。如果只是少量冰冻，并无大碍，需要增进与对方的沟通交流，彼此分享快乐，分担忧愁；如果爱情花中还同时出现醋瓶，折枝，裂痕，泡泡，虫子，黄叶等其他不利因素（出现的越多暗示你的婚姻问题就越严重），可能情路坎坷，婚姻不幸，渐行渐远，难以圆满。",
            "虫子是影响你恋爱与婚姻的不利因素，代表你在恋爱与婚姻关系中计较比较多，过于保护自己，过于计较得失，希望对方更爱你，自己不愿吃亏；会因为一些客观因素被迫的分开，难以偕老，伴侣早逝，异地恋，家庭因素等等，非常的无奈无助。如果只是少量的虫子，你就需要自我反省一下，送人玫瑰手有余香，付出也是一种快乐，能吃亏也是一种福气，感情中不要太计较。如果虫子比较多，再加上爱情花中又同时出现冰冻，醋瓶，折枝，裂痕，泡泡，黄叶等不利因素（出现的越多暗示你的婚姻问题就越严重），那么感情的变故通常自己很难改变，有种天意弄人的感觉，难以圆满。",
            "泡泡是影响你恋爱与婚姻的不利因素，象征了隐瞒与欺骗，代表你们之间不够透明，有些难以启齿的秘密或欺骗；可能遭遇地下情或第三者；你会过度美化对方，把对方想得太好，之后又觉得不满意，经常看错人。如果只是少量泡泡，说明症状轻微，婚前波折或是隐藏的问题不一定会暴露出来，不一定会对婚恋产生特别明显的影响。如果泡泡数量较多，爱情花中又同时出现冰冻，醋瓶，折枝，裂痕，虫子，黄叶等不利因素（出现的越多暗示你的婚姻问题就越严重），这时会因为真相的暴露而带来伤害，关系破裂难以避免。所以还需多加注意。",
            "折枝的出现代表你在恋爱或是婚姻关系中比较敏感，常把对方无心的言行误认为是对抗自己，针对自己，易感情用事；容易产生敌对情绪，缺乏耐性和包容心；容易起无名火，心直口快，有什么话一定要说出来；过于坚持自己的原则，甚至无法为了顾全大局而暂时的让步，锋芒毕露，不圆滑，一意孤行。如果只出现了一个折枝，说明症状轻微，你需要学习软化的交际手腕，避免不必要的冲突，家和万事兴。如果折枝的数量较多，爱情花中又同时出现冰冻，醋瓶，泡泡，裂痕，虫子，黄叶等不利因素（出现的越多暗示你的婚姻问题就越严重），会经常吵架，甚至大打出手，严重影响感情，甚至因为意识形态的不同，导致离婚。",
            "黄叶是影响你恋爱与婚姻的不利因素，代表你在两性关系中过于主观，想当然，可能先结婚后恋爱；认为自己可以改变对方，结果却不行；高估了自己，轻视了困难，因为过度自信，而忽略了很多问题；神经大条，大大咧咧，觉得一切都很好，你们之间没什么问题，而恰恰掩饰了很多问题；当问题真正暴露出来的时候，你会采取半放弃的状态，原本积极努力可以改变的事情，你也懒得采取行动，这种疏忽和怠慢的态度常常让你的伴侣觉得你不在乎ta，因此导致关系的破裂。如果只是少量的黄叶，说明症状轻微，你需要更客观的看待你的伴侣和你们的未来，凡事多个心眼。如果黄叶较多，爱情花中又同时出现冰冻，醋瓶，泡泡，裂痕，虫子，折枝等不利因素（出现的越多暗示你的婚姻问题就越严重），就需要特别注意了，否则婚姻不幸，难以圆满。",
            "裂痕是影响你恋爱与婚姻的不利因素，代表你在恋爱与婚姻关系中可能出现以下问题：容易晚恋，晚婚，甚至不婚；在感情方面缺乏自信，总是害怕自己不会幸福，对待感情想而不敢；比较苛刻和严厉，对方怎么做都难让你满意；不会换位思考，老是挑剔对方；让对方觉得你不够温柔，争吵不断，感情不睦。如果只是轻微的裂痕，大多婚前波折，缺乏甜蜜感。如遇到较大的裂痕，并且爱情花中同时出现冰冻，醋瓶，泡泡，黄叶，虫子，折枝等不利因素（出现的越多暗示你的婚姻问题就越严重），会严重影响夫妻感情，毫无快乐可言，导致离婚。",
            "醋瓶的出现代表你是一个比较敏感，容易生气容易吃醋的人，控制欲和占有欲比较强，容易觉得对方背叛了自己；缺乏耐性，情绪化；比较强势和任性，想做的一定要做，原本理智一点可以避免的冲突却因一时任性后悔莫及。如果只是少量的醋，或许你只是容易产生嫉妒的情绪而已，对方并没什么过错，你需要调节自己的心态，减少一些不必要的负能量。但如果是满瓶的醋，就极大的增强了对一段感情的破坏性，遭遇第三者，被劈腿的可能性很大。如果爱情花中还同时出现冰冻，裂痕，泡泡，黄叶，虫子，折枝等不利因素（出现的越多暗示你的婚姻问题就越严重），会完全无法信任对方，极度缺乏安全感，导致离婚。",
        };
        #endregion




    }
}