using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PPLive.Astro;
using PPLive;
using AppCmn;
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
            m_astro.birth = new DateTime(int.Parse(yearspan.InnerText), int.Parse(monthspan.InnerText), int.Parse(dayspan.InnerText), int.Parse(hourspan.InnerText), int.Parse(minitespan.InnerText),0);
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(int.Parse(HiddenField2.Value)));
            if (HiddenField1.Value=="1")
            {
                m_astro.IsDaylight = AppEnum.BOOL.True;
            }
            else if (HiddenField1.Value == "0")
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
            }
            else
            {
                m_astro.IsDaylight = AppEnum.BOOL.False;
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
            List<PublicValue.AstroStar> badstars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 12, false);
            List<PublicValue.AstroStar> eight = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 12, false);
            foreach (PublicValue.AstroStar tmp in eight)
            {
                badstars.Add(tmp);
            }
            List<PublicValue.AstroStar> mingzhu = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 1, false);
            foreach (PublicValue.AstroStar tmp in mingzhu)
            {
                badstars.Add(tmp);
            }
            badstars.Add(PublicValue.AstroStar.Sat);
            badstars.Add(PublicValue.AstroStar.Ura);
            badstars.Add(PublicValue.AstroStar.Nep);
            badstars.Add(PublicValue.AstroStar.Plu);
            badstars = badstars.Distinct().ToList();

            #region 花
            Label1.Text = "1.金星星座为：" + PublicValue.GetConstellation(m_star[PublicValue.AstroStar.Ven].Constellation) + "<br/>";
            jsstr += "showItem('hua', " + (int)m_star[PublicValue.AstroStar.Ven].Constellation + ");";
            #endregion

            #region 金星元素
            int venusEle = 0;
            venusEle = (int)PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Ven].Constellation);
            Label1.Text += "2.金星星座元素为：" + PublicValue.GetElement(PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Ven].Constellation)) + "<br />";
            #endregion

            #region 红杏
            bool hongxing = false;
            if (PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.he, AppConst.IntNull)
                || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.chong, AppConst.IntNull)
                || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.xing, AppConst.IntNull))
            {
                hongxing = true;
            }
            Label1.Text += "3.是否有红杏:" + (hongxing ? "有" : "没有") + "<br />";
            jsstr += "showItem('hongxing', " + (hongxing ? "1" : "0") + ");";
            #endregion

            #region 蜜蜂
            int beecount = 0;
            List<PublicValue.AstroStar> beestars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
            beestars.Add(PublicValue.AstroStar.Des);
            beestars.Add(PublicValue.AstroStar.Jun);
            foreach (PublicValue.AstroStar tmpstar in beestars)
            {
                if (tmpstar != goodstars[0])
                    continue;
                int tmpflag = 0;
                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstar], m_star[goodstars[0]]))
                {
                    beecount++;
                    tmpflag = 1;
                }
                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstar], m_star[goodstars[1]]))
                {
                    beecount++;
                    if (tmpflag == 1)
                    {
                        beecount++;
                    }
                }
            }
            Label1.Text +="7宫主：";
            foreach(PublicValue.AstroStar tmpstar in beestars)
            {
                Label1.Text += PublicValue.GetAstroStar(tmpstar);
            }
            Label1.Text += "4.蜜蜂指数为:" + beecount + "<br />";
            jsstr += "showItem('mifeng', " + (beecount+1>2 ? 3 : beecount) + ");";
            #endregion

            #region 花盆
            Label1.Text += "5.花盆为:" + PublicValue.GetConstellation(m_star[PublicValue.AstroStar.Jun].Constellation) + "<br />";
            jsstr += "showItem('huapen', " + (int)m_star[PublicValue.AstroStar.Jun].Constellation%3+1 + ");";
            #endregion

            #region 裂痕
            int breakcount = 0;
            Dictionary<string, int> showele = new Dictionary<string, int>();
            showele.Add("paopao", 0);
            showele.Add("chongzi", 0);
            showele.Add("cu", 0);
            showele.Add("liehen", 0);
            showele.Add("bingdong", 0);
            showele.Add("zhezhi", 0);

            List<PublicValue.AstroStar> breakstars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
            breakstars.Add(PublicValue.AstroStar.Ven);
            breakstars.Add(PublicValue.AstroStar.Jun);
            breakstars.Add(PublicValue.AstroStar.Des);
            breakstars = breakstars.Distinct().ToList();
            foreach (PublicValue.AstroStar tmp in breakstars)
            {
                if (tmp != goodstars[0])
                    continue;
                int tmpflag = 0;
                for (int i = 0; i < badstars.Count; i++)
                {
                    if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmp], m_star[badstars[i]]))
                    {
                        breakcount++;
                        if (tmpflag == 0)
                        {
                            tmpflag++;
                        }
                        else
                        {
                            tmpflag = 0;
                            breakcount++;
                        }
                    }
                }
            }
            Label1.Text += "4.裂痕指数为:" + breakcount + "<br />";
            jsstr += "showItem('liehen', " + (breakcount > 1 ? 2 : breakcount) + ");";
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
            Label1.Text += "5.花心指数为:" + flowercount + "<br />";
            #endregion

            #region 对方有钱
            int richcount = PublicDeal.GetInstance().GetGongPower(m_astro.Stars, 7);
            List<List<PublicValue.AstroStar>> hurong = PublicDeal.GetInstance().GetHuRong(m_astro.Stars, true); ;
            Label1.Text += "6.对方有钱指数为:" + richcount + "<br />";
            //测试显示互溶关系
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
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    DateTime now = DatePicker1.SelectedTime;
        //    Dictionary<string, Dictionary<int, int>> result = new Dictionary<string, Dictionary<int, int>>();
        //    int count = 0;
        //    for (DateTime tmpnow = now; tmpnow < now.AddYears(1); tmpnow = tmpnow.AddHours(1))
        //    {
        //        #region 计算
        //        AstroMod m_astro = new AstroMod();
        //        m_astro.type = PublicValue.AstroType.benming;
        //        #region 设置实体各种参数
        //        m_astro.birth = tmpnow;
        //        m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(District1.Area3SysNo));
        //        //if (chkDaylight1.Checked)
        //        //{
        //        //    m_astro.IsDaylight = AppEnum.BOOL.True;
        //        //}
        //        //else
        //        //{
        //        //    m_astro.IsDaylight = AppEnum.BOOL.False;
        //        //}
        //        m_astro.IsDaylight = AppEnum.BOOL.False;
        //        m_astro.zone = -8;

        //        for (int i = 1; i < 21; i++)
        //        {
        //            m_astro.startsShow.Add(i, "");
        //        }
        //        m_astro.aspectsShow.Clear();
        //        for (int i = 1; i < 6; i++)
        //        {
        //            m_astro.aspectsShow.Add(i, 5);
        //        }
        //        #endregion

        //        AstroBiz.GetInstance().GetParamters(ref m_astro);
        //        Dictionary<PublicValue.AstroStar, Star> m_star = new Dictionary<PublicValue.AstroStar, Star>();
        //        foreach (Star tmpstar in m_astro.Stars)
        //        {
        //            m_star.Add(tmpstar.StarName, tmpstar);
        //        }

        //        //吉星
        //        List<PublicValue.AstroStar> goodstars = new List<PublicValue.AstroStar>();
        //        goodstars.Add(PublicValue.AstroStar.Jup);
        //        goodstars.Add(PublicValue.AstroStar.Ven);
        //        //凶星
        //        List<PublicValue.AstroStar> badstars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 12, false);
        //        List<PublicValue.AstroStar> eight = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 12, false);
        //        foreach (PublicValue.AstroStar tmp in eight)
        //        {
        //            badstars.Add(tmp);
        //        }
        //        List<PublicValue.AstroStar> mingzhu = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 1, false);
        //        foreach (PublicValue.AstroStar tmp in mingzhu)
        //        {
        //            badstars.Add(tmp);
        //        }
        //        badstars.Add(PublicValue.AstroStar.Sat);
        //        badstars.Add(PublicValue.AstroStar.Ura);
        //        badstars.Add(PublicValue.AstroStar.Nep);
        //        badstars.Add(PublicValue.AstroStar.Plu);
        //        badstars = badstars.Distinct().ToList();

        //        #region 红杏
        //        bool hongxing = false;
        //        if (PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.he, AppConst.IntNull)
        //            || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.chong, AppConst.IntNull)
        //            || PublicDeal.GetInstance().HasPhase(m_star[PublicValue.AstroStar.Ven], m_star[PublicValue.AstroStar.Jun], PublicValue.Phase.xing, AppConst.IntNull))
        //        {
        //            hongxing = true;
        //        }
        //        //Label1.Text += "3.是否有红杏:" + (hongxing ? "有" : "没有") + "<br />";
        //        if (!result.ContainsKey("红杏"))
        //        {
        //            Dictionary<int, int> tmpdic = new Dictionary<int, int>();
        //            tmpdic.Add(0, 0);
        //            tmpdic.Add(1, 0);
        //            result.Add("红杏", tmpdic);
        //        }
        //        if (!hongxing)
        //        {
        //            result["红杏"][0]++;
        //        }
        //        else
        //        {
        //            result["红杏"][1]++;
        //        }
        //        #endregion

        //        #region 蜜蜂
        //        int beecount = 0;
        //        List<PublicValue.AstroStar> beestars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
        //        beestars.Add(PublicValue.AstroStar.Des);
        //        beestars.Add(PublicValue.AstroStar.Jun);
        //        foreach (PublicValue.AstroStar tmpstar in beestars)
        //        {
        //            if (tmpstar != goodstars[0])
        //                continue;
        //            int tmpflag = 0;
        //            if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstar], m_star[goodstars[0]]))
        //            {
        //                beecount++;
        //                tmpflag = 1;
        //            }
        //            if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstar], m_star[goodstars[1]]))
        //            {
        //                beecount++;
        //                if (tmpflag == 1)
        //                {
        //                    beecount++;
        //                }
        //            }
        //        }
        //        if (!result.ContainsKey("蜜蜂"))
        //        {
        //            Dictionary<int, int> tmpdic = new Dictionary<int, int>();
        //            result.Add("蜜蜂", tmpdic);
        //        }
        //        if (!result["蜜蜂"].ContainsKey(beecount))
        //        {
        //            result["蜜蜂"].Add(beecount, 0);
        //        }
        //        result["蜜蜂"][beecount]++;
        //        //Label1.Text += "4.蜜蜂指数为:" + beecount + "<br />";
        //        #endregion

        //        #region 花盆
        //        //Label1.Text += "5.花盆为:" + PublicValue.GetConstellation(m_star[PublicValue.AstroStar.Jun].Constellation) + "<br />";
        //        if (!result.ContainsKey("花盆"))
        //        {
        //            Dictionary<int, int> tmpdic = new Dictionary<int, int>();
        //            result.Add("花盆", tmpdic);
        //        }
        //        if (!result["花盆"].ContainsKey((int)m_star[PublicValue.AstroStar.Jun].Constellation))
        //        {
        //            result["花盆"].Add((int)m_star[PublicValue.AstroStar.Jun].Constellation, 0);
        //        }
        //        result["花盆"][(int)m_star[PublicValue.AstroStar.Jun].Constellation]++;
        //        #endregion

        //        #region 裂痕
        //        int breakcount = 0;

        //        List<PublicValue.AstroStar> breakstars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
        //        breakstars.Add(PublicValue.AstroStar.Ven);
        //        breakstars.Add(PublicValue.AstroStar.Jun);
        //        breakstars.Add(PublicValue.AstroStar.Des);
        //        breakstars = breakstars.Distinct().ToList();
        //        foreach (PublicValue.AstroStar tmp in breakstars)
        //        {
        //            if (tmp != goodstars[0])
        //                continue;
        //            int tmpflag = 0;
        //            for (int i = 0; i < badstars.Count; i++)
        //            {
        //                if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmp], m_star[badstars[i]]))
        //                {
        //                    breakcount++;
        //                    if (tmpflag == 0)
        //                    {
        //                        tmpflag++;
        //                    }
        //                    else
        //                    {
        //                        tmpflag = 0;
        //                        breakcount++;
        //                    }
        //                }
        //            }
        //        }
        //        //Label1.Text += "4.裂痕指数为:" + breakcount + "<br />";
        //        if (!result.ContainsKey("裂痕"))
        //        {
        //            Dictionary<int, int> tmpdic = new Dictionary<int, int>();
        //            result.Add("裂痕", tmpdic);
        //        }
        //        if (!result["裂痕"].ContainsKey(breakcount))
        //        {
        //            result["裂痕"].Add(breakcount, 0);
        //        }
        //        result["裂痕"][breakcount]++;
        //        #endregion

        //        #region 花心指数
        //        int flowercount = 0;
        //        foreach (PublicValue.AstroStar tmpstar in goodstars)
        //        {
        //            if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Jun], m_star[tmpstar]))
        //            {
        //                flowercount++;
        //            }
        //            if (PublicDeal.GetInstance().HasAnyMainPhase(m_star[PublicValue.AstroStar.Chi], m_star[tmpstar]))
        //            {
        //                flowercount++;
        //            }
        //            foreach (PublicValue.AstroStar tmpstarr in eight)
        //            {
        //                if (tmpstar != tmpstarr && PublicDeal.GetInstance().HasAnyMainPhase(m_star[tmpstarr], m_star[tmpstar]))
        //                {
        //                    flowercount++;
        //                }
        //            }
        //        }
        //        //Label1.Text += "5.花心指数为:" + flowercount + "<br />";
        //        if (!result.ContainsKey("花心"))
        //        {
        //            Dictionary<int, int> tmpdic = new Dictionary<int, int>();
        //            result.Add("花心", tmpdic);
        //        }
        //        if (!result["花心"].ContainsKey(flowercount))
        //        {
        //            result["花心"].Add(flowercount, 0);
        //        }
        //        result["花心"][flowercount]++;
        //        #endregion

        //        #region 对方有钱
        //        int richcount = PublicDeal.GetInstance().GetGongPower(m_astro.Stars, 7);
        //        List<List<PublicValue.AstroStar>> hurong = PublicDeal.GetInstance().GetHuRong(m_astro.Stars, true);
        //        if (!result.ContainsKey("对方有钱"))
        //        {
        //            Dictionary<int, int> tmpdic = new Dictionary<int, int>();
        //            result.Add("对方有钱", tmpdic);
        //        }
        //        if (!result["对方有钱"].ContainsKey(richcount))
        //        {
        //            result["对方有钱"].Add(richcount, 0);
        //        }
        //        result["对方有钱"][richcount]++;
        //        //Label1.Text += "6.对方有钱指数为:" + richcount + "<br />";
        //        //测试显示互溶关系
        //        //foreach (List<PublicValue.AstroStar> tmplist in hurong)
        //        //{
        //        //    foreach (PublicValue.AstroStar tmpstar in tmplist)
        //        //    {
        //        //        Label1.Text += PublicValue.GetAstroStar(tmpstar) + "->";
        //        //    }
        //        //    Label1.Text += "<br />";
        //        //}
        //        #endregion
        //        #endregion
        //        count++;
        //    }
        //    #region 打印
        //    Label1.Text = now.ToString("yyyy-MM-dd") + "至" + DatePicker1.SelectedTime.ToString("yyyy-MM-dd") + "<br />";
        //    foreach (KeyValuePair<string, Dictionary<int, int>> s in result)
        //    {
        //        Label1.Text += s.Key + "：<br />";
        //        foreach (KeyValuePair<int, int> ss in s.Value)
        //        {
        //            Label1.Text += ss.Key + "：" + ss.Value + "个<br />";
        //        }
        //    }
        //    #endregion
        //}

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable m_dt =SYS_DistrictBll.GetInstance().GetSubLevel(int.Parse(HiddenField3.Value));
            Repeater2.DataSource = m_dt;
            Repeater2.DataBind();
            if(m_dt.Rows.Count>0)
            district2.InnerText = m_dt.Rows[0]["name"].ToString();
            HiddenField2.Value = m_dt.Rows[0]["sysno"].ToString();
            if (IsPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "refresh", "refreshdistrict();", true);
            }
            //UpdatePanel2.Update();
        }

        

       


    }
}