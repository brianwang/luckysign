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

            int venusEle = 0;
            foreach (Star tmpstar in m_astro.Stars)
            {
                m_star.Add(tmpstar.StarName, tmpstar);
                if (tmpstar.StarName == PublicValue.AstroStar.Ven)
                {
                    venusEle = (int)PublicDeal.GetInstance().GetConstellationElement(tmpstar.Constellation);
                }
            }

            bool hongxing = false;
            if(HasPhase(m_star[PublicValue.AstroStar.Ven],m_star[PublicValue.AstroStar.Jun],PublicValue.Phase.he,AppConst.IntNull)
                || HasPhase(m_star[PublicValue.AstroStar.Ven],m_star[PublicValue.AstroStar.Jun],PublicValue.Phase.chong,AppConst.IntNull)
                || HasPhase(m_star[PublicValue.AstroStar.Ven],m_star[PublicValue.AstroStar.Jun],PublicValue.Phase.xing,AppConst.IntNull))
            {
                hongxing = true;
            }



            Label1.Text = "1.金星星座为："+ PublicValue.GetAstroStar(m_star[PublicValue.AstroStar.Ven].StarName) + "<br/>";
            Label1.Text+="2.金星星座元素为：" + PublicValue.GetElement(PublicDeal.GetInstance().GetConstellationElement(m_star[PublicValue.AstroStar.Ven].Constellation));
            Label1.Text += "3.是否有红杏:" + (hongxing ? "有" : "没有");


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


        public bool HasPhase(Star a, Star b, PublicValue.Phase phase,decimal offset)
        {
            if (offset == AppConst.IntNull)
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


    }
}