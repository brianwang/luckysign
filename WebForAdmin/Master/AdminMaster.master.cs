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

namespace WebForAdmin.Master
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        public string PageName = "";
        #region Cate
        public Dictionary<int, string> CateList = new Dictionary<int, string>();
        
        public enum CateType
        {
            [Description("欢迎")]
            Welcome = 0,
            [Description("会员管理")]
            Customer = 10,
            [Description("问答管理")]
            QA = 20,
            [Description("群组管理")]
            Group = 30,
            [Description("文章管理")]
            Article = 40,
            [Description("名人案例库")]
            Famous = 50,
            [Description("App管理")]
            App = 70,
            [Description("权限管理")]
            Privilege = 60,
            [Description("公告管理")]
            Notice = 80,

            [Description("查询名人案例库")]
            Famous1 = 51,
            [Description("添加新的案例")]
            Famous2 = 52,
            [Description("蜘蛛抓取结果导入")]
            Famous3 = 53,
            [Description("案例关键字")]
            Famous4 = 54,
            [Description("地区管理")]
            Famous5 = 55,

            [Description("查询文章")]
            Article1 = 41,
            [Description("添加新文章")]
            Article2 = 42,
            [Description("文章分类管理")]
            Article3 = 43,

            [Description("推广主题管理")]
            App1 = 71,
            [Description("推广内容管理")]
            App2 = 72,
            [Description("推广结果统计")]
            App3 = 73,

            [Description("会员管理")]
            Customer1 = 11,
            [Description("设置勋章")]
            Customer2 = 12,
            [Description("版主管理")]
            Customer3 = 13,
            [Description("设置版主")]
            Customer4 = 14,

            [Description("问答类别管理")]
            QA1 = 21,
            [Description("问题列表")]
            QA2 = 22,
            [Description("回答列表")]
            QA3 = 23,

            [Description("发送系统通知")]
            Notice1 = 81,

            [Description("查询后台管理员")]
            Privilege1 = 61,
            [Description("添加/修改后台管理员")]
            Privilege2 = 62,
            [Description("设置管理员权限")]
            Privilege3 = 63,
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
