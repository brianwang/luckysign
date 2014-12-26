using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;
using AppCmn;
using AppBll.WebSys;
using AppMod.WebSys;

namespace WebForAnalyse.Master
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        public string PageName = "";
        #region Cate
        public Dictionary<int, string> CateList = new Dictionary<int, string>();
        
        public enum CateType
        {
            [Description("八字研究")]
            BaZi = 10,
            [Description("八字男女同排")]
            BaZi1 = 11,
            [Description("八字查询")]
            BaZi2 = 12,
            [Description("八字组合")]
            BaZi3 = 13,


            [Description("六爻研究")]
            LiuYao = 20,
            [Description("紫薇研究")]
            ZiWei = 30,
            [Description("紫薇格局分析")]
            ZiWei1 = 31,
            [Description("占星术研究")]
            Astro = 40,
            [Description("彩票分析")]
            Doll = 50,
            [Description("股票分析")]
            Stock = 60,
        }

        public void InitialCate()
        {
            Array a = Enum.GetValues(typeof(CateType));
            for (int i = 0; i < a.Length; i++)
            {
                string enumName = a.GetValue(i).ToString();
                CateList.Add((int)System.Enum.Parse(typeof(CateType), enumName),"");
            }
        }

        public void SetCate(CateType cate)
        {
            InitialCate();
            Dictionary<int, string> tmpcate = new Dictionary<int,string>();
            foreach (int key in CateList.Keys)
            {
                tmpcate.Add(key, CateList[key]);
                if (key == (int)cate|| key==((int)cate)/10*10)
                {
                    tmpcate[key] = "current";
                }
                else
                {
                    tmpcate[key] = "";
                }
            }
            CateList = tmpcate;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionInfo m_session = new SessionInfo();
                m_session = GetSession();
                if (m_session.AdminEntity!= null && m_session.AdminEntity.CustomerSysNo != AppConst.IntNull)
                {
                    ltrName.Text = m_session.AdminEntity.Username;
                }
                
            }
        }


        public SessionInfo GetSession()
        {
            SessionInfo oSession = (SessionInfo)Session[AppConfig.AdminSession];
            if (oSession == null)
            {
                oSession = new SessionInfo();
                Session[AppConfig.AdminSession] = oSession;
            }
            return oSession;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                SYS_AdminMod m_admin = SYS_AdminBll.GetInstance().GetModel(GetSession().AdminEntity.SysNo);
                if (txtOldPsd.Text.Trim() == m_admin.Password)
                {
                    if (txtNewPsd.Text.Trim() == txtNewAgain.Text.Trim())
                    {
                        m_admin.Password = txtNewPsd.Text.Trim();
                        SYS_AdminBll.GetInstance().Update(m_admin);

                        ltrNotice.Text = "密码修改成功！";
                        masternoticediv.Style["display"] = "";

                    }
                    else
                    {
                        ltrError.Text = "两次密码输入不一致，请重新输入！";
                        mastererrordiv.Style["display"] = "";
                    }
                }
                else
                {
                    ltrError.Text = "旧密码错误，请重新输入！";
                    mastererrordiv.Style["display"] = "";
                }
            }
            catch
            {
                ltrError.Text = "系统错误，密码修改失败！";
                mastererrordiv.Style["display"] = "";
            }
            finally
            {
                txtOldPsd.Text = "";
                txtNewAgain.Text = "";
                txtNewPsd.Text = "";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "closeforseconds();", true);
            }
        }
    }
}
