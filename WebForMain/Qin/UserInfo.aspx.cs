using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using AppCmn;
using AppMod.User;
using AppBll.User;
using AppMod.WebSys;
using AppBll.WebSys;
using AppMod.CMS;
using AppBll.CMS;
using AppMod.QA;
using AppBll.QA;
using WebMonitor;

namespace WebForMain.Qin
{
    public partial class UserInfo : PageBase
    {
        public USR_CustomerMod m_user = new USR_CustomerMod();

        private int tab = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Login(Request.Url.ToString());
            if (Request.QueryString["tab"] != null)
            {
                try
                {
                    tab = int.Parse(Request.QueryString["tab"]);
                }
                catch
                { }
            }
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    m_user = USR_CustomerBll.GetInstance().GetModel(int.Parse(Request.QueryString["id"]));
                    if (m_user.SysNo == AppConst.IntNull)
                    {
                        Response.Redirect("../Error.aspx");
                    }                    
                    if (m_user.SysNo != GetSession().CustomerEntity.SysNo)
                    {
                        Response.Redirect("../Error.aspx");
                    }
                    if (!IsPostBack)
                    {
                        FormPrepare();
                    }
                }
                catch
                {
                    Response.Redirect("../Error.aspx");
                }
            }
            else
            {
                Response.Redirect("../Error.aspx");
            }
            MultiView1.ActiveViewIndex = tab;
        }

        protected void FormPrepare()
        {
            switch (tab)
            {
                case 1:
                    RadioButtonList1.DataSource = AppEnum.GetGender();
                    RadioButtonList1.DataTextField = "value";
                    RadioButtonList1.DataValueField = "key";
                    RadioButtonList1.DataBind();
                    District2.IsShowLatLng = false;
                    District2.IsShowOnlyChina = false;

                    drpFateType.SelectedIndex = drpFateType.Items.IndexOf(drpFateType.Items.FindByValue(m_user.FateType.ToString()));
                    drpBirthType.SelectedIndex = drpBirthType.Items.IndexOf(drpBirthType.Items.FindByValue(m_user.IsShowBirth.ToString()));
                    if (m_user.birth != AppConst.DateTimeNull)
                    {
                        DatePicker2.SelectedTime = m_user.birth;
                    }
                    else 
                    {
                        DatePicker2.SelectedTime = new DateTime(1990, 1, 1);
                    }
                    if(m_user.HomeTown!=AppConst.IntNull)
                    {
                        District2.Area3SysNo = m_user.HomeTown;
                    }
                    if (m_user.Gender != AppConst.IntNull)
                    {
                        RadioButtonList1.SelectedIndex = RadioButtonList1.Items.IndexOf(RadioButtonList1.Items.FindByValue(m_user.Gender.ToString()));
                    }
                    txtIntro.Text = m_user.Intro;
                    break;
            }
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            UploadIMG m_upload = new UploadIMG();
            m_upload.Path = @"WebResources\UpUserFiles\Photos\Tmp";
            m_upload.IsThumbnail = false;
            try
            {
                if (m_upload.UpLoadIMG(FileUpload1))
                {
                    ImageDrag.ImageUrl = "../ControlLibrary/ShowPhoto.aspx?type=tmp&id="+ m_upload.OFileName.Replace("o", "");
                    ImageIcon.ImageUrl = "../ControlLibrary/ShowPhoto.aspx?type=tmp&id=" + m_upload.OFileName.Replace("o", "");
                    hdfPicID.Value = m_upload.OFileName.Replace("o", "");
                    MultiView1.ActiveViewIndex = 4;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "photook", "alert('"+m_upload.MSG+"');", true);
                }
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "WebForMain.Userphoto.Upload", Request.UserHostAddress);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photook", "alert('系统故障，请联系管理员');", true);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("View.aspx?id=" + m_user.SysNo);
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            #region 检查输入
            if (RadioButtonList1.SelectedIndex == -1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "nogender", "alert('请选择性别');", true);
                return;
            }
            #endregion
            try
            {
                m_user = USR_CustomerBll.GetInstance().GetModel(int.Parse(Request.QueryString["id"]));
                m_user.FateType = int.Parse(drpFateType.SelectedValue);
                m_user.Gender = int.Parse(RadioButtonList1.SelectedValue);
                m_user.birth = DatePicker2.SelectedTime;
                m_user.IsShowBirth = int.Parse(drpBirthType.SelectedValue);
                m_user.HomeTown = District2.Area3SysNo;
                m_user.Intro = txtIntro.Text;

                USR_CustomerBll.GetInstance().UpDate(m_user);

                SessionInfo m_session = new SessionInfo();
                m_session.CustomerEntity = m_user;
                m_session.GradeEntity = USR_GradeBll.GetInstance().GetModel(m_user.SysNo);
                Session[AppConfig.CustomerSession] = m_session;

                Page.ClientScript.RegisterStartupScript(this.GetType(), "infook", "alert('用户信息更新成功');", true);
            }
            catch(Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "WebForMain.UserInfo.Edit", Request.UserHostAddress);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "noinfo", "alert('系统故障，请联系管理员');", true);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "passwrong", "alert('请输入旧密码');", true);
                return;
            }
            if (txtNewPass.Text.Trim() == "" || txtPassAgain.Text.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "passwrong", "alert('新的密码不能为空');", true);
                return;
            }
            if (txtNewPass.Text.Trim().Length < 6 || txtNewPass.Text.Trim().Length > 16)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "passwrong", "alert('密码长度必须在6-16字符内！');", true);
                return;
            }
            if (txtPassAgain.Text.Trim() != txtPassAgain.Text.Trim())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "passwrong", "alert('密码输入不一致！');", true);
                return;
            }

            if (txtOldPass.Text.Trim() != GetSession().CustomerEntity.Password)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "passwrong", "alert('您输入的旧密码与原密码不一致，请重新输入!');", true);
                return;
            }
            if (CommonTools.CheckPasswordLevel(txtNewPass.Text.Trim()) == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "passwrong", "alert('您的密码实在太过简单，请重新输入!');", true);
                return;
            }
            else
            {
                try
                {
                    //更新数据库中的用户密码
                    m_user = USR_CustomerBll.GetInstance().GetModel(int.Parse(Request.QueryString["id"]));
                    m_user.Password = txtNewPass.Text.Trim();
                    USR_CustomerBll.GetInstance().UpDate(m_user);

                    //更新session中的密码
                    SessionInfo m_session = new SessionInfo();
                    m_session.CustomerEntity = m_user;
                    m_session.GradeEntity = USR_GradeBll.GetInstance().GetModel(m_user.SysNo);
                    Session[AppConfig.CustomerSession] = m_session;

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "passok", "alert('修改成功');", true);
                }
                catch (Exception ex)
                {
                    LogManagement.getInstance().WriteException(ex, "WebForMain.UserPass.Edit", Request.UserHostAddress);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "nopass", "alert('系统故障，请联系管理员');", true);
                }
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string OPath = @"~\WebResources\UpUserFiles\Photos\O";
            try
            {
                int imageWidth = Int32.Parse(txt_width.Text);
                int imageHeight = Int32.Parse(txt_height.Text);
                int cutTop = Int32.Parse(txt_top.Text);
                int cutLeft = Int32.Parse(txt_left.Text);
                int dropWidth = Int32.Parse(txt_DropWidth.Text);
                int dropHeight = Int32.Parse(txt_DropHeight.Text);

                string filename = ImageHelper.SaveCutPic(Server.MapPath(@"~\WebResources\UpUserFiles\Photos\Tmp\o" + hdfPicID.Value), Server.MapPath(OPath), 0, 0, dropWidth,
                                    dropHeight, cutLeft, cutTop, imageWidth, imageHeight);
                ImageHelper.SaveThumbnail(Server.MapPath(OPath + @"\" + filename), Server.MapPath(@"~\WebResources\UpUserFiles\Photos\T"), filename, 70, 70, true);
                m_user = USR_CustomerBll.GetInstance().GetModel(int.Parse(Request.QueryString["id"]));
                m_user.Photo = filename.Replace(".jpg", "");
                USR_CustomerBll.GetInstance().UpDate(m_user);
                MultiView1.ActiveViewIndex = 0;
                //DataBind();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photook", "alert('头像更新成功');", true);

            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "WebForMain.Userphoto.Upload", Request.UserHostAddress);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "photook", "alert('系统故障，请联系管理员');", true);
            }

        }
    }
}