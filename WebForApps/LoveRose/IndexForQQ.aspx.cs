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


            int ele = 0;
            foreach (Star tmpstar in m_astro.Stars)
            {
                if (tmpstar.StarName == PublicValue.AstroStar.Ven)
                {
                    ele = (int)PublicDeal.GetInstance().GetConstellationElement(tmpstar.Constellation);
                }
                
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "showflash",
                    @"swfobject.embedSWF('LoveRose.swf', 'flashmov', '816', '459', '9.0.0',null,{ele:'"+ele+"'});",true);
            
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