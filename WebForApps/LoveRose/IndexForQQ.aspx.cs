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
namespace WebForApps.LoveRose
{
    public partial class IndexForQQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton1.ImageUrl = "";
        }

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {
            AstroMod m_astro = new AstroMod();
            m_astro.type = PublicValue.AstroType.benming;
            #region 设置实体各种参数
            m_astro.birth = DatePicker1.SelectedTime;
            m_astro.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(District1.Area3SysNo));
            //if (chkDaylight1.Checked)
            //{
            //    m_astro.IsDaylight = AppEnum.BOOL.True;
            //}
            //else
            //{
            //    m_astro.IsDaylight = AppEnum.BOOL.False;
            //}
            m_astro.IsDaylight = AppEnum.BOOL.False;
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

            //吉星
            List<PublicValue.AstroStar> goodstars = new List<PublicValue.AstroStar>();
            goodstars.Add(PublicValue.AstroStar.Jup);
            goodstars.Add(PublicValue.AstroStar.Ven);
            //凶星
            List<PublicValue.AstroStar> badstars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 12,false);
            List<PublicValue.AstroStar> eight = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 12,false);
            foreach (PublicValue.AstroStar tmp in eight)
            {
                badstars.Add(tmp);
            }
            List<PublicValue.AstroStar> mingzhu = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 1,false);
            foreach (PublicValue.AstroStar tmp in mingzhu)
            {
                badstars.Add(tmp);
            }
            badstars.Add(PublicValue.AstroStar.Sat);
            badstars.Add(PublicValue.AstroStar.Ura);
            badstars.Add(PublicValue.AstroStar.Nep);
            badstars.Add(PublicValue.AstroStar.Plu);
            badstars.Distinct();

            #region 花
            Label1.Text = "1.金星星座为：" + PublicValue.GetAstroStar(m_star[PublicValue.AstroStar.Ven].StarName) + "<br/>";
            #endregion

            #region 金星元素
            int venusEle = 0;
            foreach (Star tmpstar in m_astro.Stars)
            {
                m_star.Add(tmpstar.StarName, tmpstar);
                if (tmpstar.StarName == PublicValue.AstroStar.Ven)
                {
                    venusEle = (int)PublicDeal.GetInstance().GetConstellationElement(tmpstar.Constellation);
                }
            }
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
            Label1.Text += "4.蜜蜂指数为:" + beecount + "<br />";
            #endregion

            #region 花盆
            Label1.Text += "5.花盆为:" + PublicValue.GetConstellation(m_star[PublicValue.AstroStar.Jun].Constellation) + "<br />";
            #endregion

            #region 裂痕
            int breakcount = 0;

            List<PublicValue.AstroStar> breakstars = PublicDeal.GetInstance().GetGongMasters(m_astro.Stars, 7, false);
            breakstars.Add(PublicValue.AstroStar.Ven);
            breakstars.Add(PublicValue.AstroStar.Jun);
            breakstars.Add(PublicValue.AstroStar.Des);
            breakstars.Distinct();
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
            List<List<PublicValue.AstroStar>> hurong = new List<List<PublicValue.AstroStar>>();
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


            //Page.ClientScript.RegisterStartupScript(this.GetType(), "showflash",
            //        @"swfobject.embedSWF('LoveRose.swf', 'flashmov', '816', '459', '9.0.0',null,{ele:'"+ele+"'});",true);

            #region 记录用户数据
            LoveRoseMod m_record = new LoveRoseMod();
            m_record.Area = District1.Area3SysNo;
            m_record.BirthTime = DatePicker1.SelectedTime;
            m_record.Source = (int)AppEnum.AppsSourceType.qq;
            m_record.TS = DateTime.Now;
            LoveRoseBll.GetInstance().Add(m_record);
            #endregion
        }


       


    }
}