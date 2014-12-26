 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.QA;
using AppMod.QA;
using AppCmn;

namespace WebForAdmin.Quest
{
    public partial class Answer : PageBase
    {
        private int pageindex = 1;
        private int total = 0;
        private int sysno = 0;
        private string urlnow = "Answer.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "回答列表";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.QA3);
            #endregion
            if (!IsPostBack)
            {
                if (Request.QueryString["delete"] != null && Request.QueryString["delete"] != "")
                {
                    Delete();
                }

                if (Request.QueryString["pn"] != null && Request.QueryString["pn"] != "")
                {
                    try
                    {
                        pageindex = int.Parse(Request.QueryString["pn"]);
                    }
                    catch { }
                }
                urlnow += "?pn=" + pageindex;
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        sysno = int.Parse(Request.QueryString["id"]);
                        urlnow += "?id=" + Request.QueryString["id"];
                    }
                    catch
                    {
                        Response.Redirect("../Error.aspx?msg=");
                        return;
                    }

                }
                else
                {
                    Response.Redirect("../Error.aspx?msg=");
                    return;
                }
                //if (Request.QueryString["award"] != null && Request.QueryString["award"] != "")
                //{
                //    txtAward.Text = Request.QueryString["award"];
                //}
                if (Request.QueryString["user"] != null && Request.QueryString["user"] != "")
                {
                    txtUser.Text = Request.QueryString["user"];
                    urlnow += "&user=" + Request.QueryString["user"];
                }
                //if (Request.QueryString["love"] != null && Request.QueryString["love"] != "")
                //{
                //    txtLove.Text = Request.QueryString["love"];
                //}
                //if (Request.QueryString["hate"] != null && Request.QueryString["hate"] != "")
                //{
                //    txtLove.Text = Request.QueryString["hate"];
                //}
                if (Request.QueryString["status"] != null && Request.QueryString["status"] != "")
                {
                    drpStatus.SelectedIndex = drpStatus.Items.IndexOf(drpStatus.Items.FindByValue(Request.QueryString["status"]));
                    urlnow += "&status=" + Request.QueryString["status"];
                }

                BindContent();
            }
        }

        protected void BindContent()
        {
            int love = 0;
            int hate = 0;
            int award = 0;
            int user = 0;

            try 
            {
                //if (txtAward.Text.Trim() != "")
                //{
                //    award = int.Parse(txtAward.Text.Trim());
                //}
                //if (txtLove.Text.Trim() != "")
                //{
                //    love = int.Parse(txtLove.Text.Trim());
                //}
                //if (txtHate.Text.Trim() != "")
                //{
                //    love = int.Parse(txtHate.Text.Trim());
                //}
                if (txtUser.Text.Trim() != "")
                {
                    user = int.Parse(txtUser.Text.Trim());
                }
            }
            catch 
            {
                ltrError.Text = "请确认输入参数格式的正确性！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
            DataTable m_dt = QA_AnswerBll.GetInstance().GetListByQuestForAdmin(AppConst.PageSize, pageindex, sysno, user,  ref total);
            m_dt.Columns.Add("deleteurl");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                    m_dt.Rows[i]["deleteurl"] = urlnow + "&delete=";
            }
            rptFamous.DataSource = m_dt;
            rptFamous.DataBind();

            Pager1.url = "Answer.aspx?name=" + txtName.Text.Trim() + "&status=" + drpStatus.SelectedValue + "&user=" + txtUser.Text.Trim()+  "&pn=";
            if (total % AppConst.PageSize == 0)
            {
                this.Pager1.total = total / AppConst.PageSize;
            }
            else
            {
                this.Pager1.total = total / AppConst.PageSize + 1;
            }
            this.Pager1.index = pageindex;
            this.Pager1.numlenth = 3;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            int reply = 0;
            int award = 0;
            int user = 0;

            try
            {
                if (txtUser.Text.Trim() != "")
                {
                    user = int.Parse(txtUser.Text.Trim());
                }
            }
            catch
            {
                ltrError.Text = "搜索条件输入格式错误，请检查！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
            Response.Redirect("Answer.aspx?pn=1&name=" + txtName.Text.Trim() + drpStatus.SelectedValue + "&user=" + txtUser.Text.Trim());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Delete()
        {
            try
            {
                QA_AnswerMod m_famous = QA_AnswerBll.GetInstance().GetModel(int.Parse(Request.QueryString["delete"]));
                m_famous.DR = (int)AppEnum.State.deleted;
                QA_AnswerBll.GetInstance().Update(m_famous);

                ltrNotice.Text = "该记录已删除！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
            }
            catch
            {
                ltrError.Text = "系统错误，删除失败！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';", true);
            }
        }
    }
}