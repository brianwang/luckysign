using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions; 
using System.Data;
using WebMonitor;
using AppBll.WebSys;
using AppBll.Spider;
using AppMod.WebSys;
using AppMod.Spider;
using AppCmn;

namespace WebForAdmin.Celebrity
{
    public partial class Edit : PageBase
    {
        public string type = "";
        public int SysNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "添加/修改案例";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Famous2);
            #endregion

            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {
                type = Request.QueryString["type"].ToUpper().Trim();
            }
            if (!IsPostBack)
            {
                PrepareForm();
            }
        }

        protected void PrepareForm()
        {
            #region 选项绑定
            drpCate.DataSource = SYS_Famous_CategoryBll.GetInstance().GetList();
            drpCate.DataTextField = "Name";
            drpCate.DataValueField = "SysNo";
            drpCate.DataBind();

            drpDistrict1.DataSource = SYS_DistrictBll.GetInstance().GetFirstLevel(0);
            drpDistrict1.DataTextField = "Name";
            drpDistrict1.DataValueField = "SysNo";
            drpDistrict1.DataBind();
            drpDistrict1.Items.Insert(0, new ListItem("请选择", "0"));

            chkTime.DataSource = AppEnum.GetTimeUnknown();
            chkTime.DataTextField = "Value";
            chkTime.DataValueField = "Key";
            chkTime.DataBind();
            #endregion

            if (type == "ADD")
            {
            }
            else if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        SysNo = int.Parse(Request.QueryString["id"]);
                        SYS_FamousMod m_famous = SYS_FamousBll.GetInstance().GetModel(SysNo);
                        txtSysNo.Text = m_famous.SysNo.ToString();
                        txtName.Text = m_famous.Name;
                        txtFullName.Text = m_famous.FullName;
                        txtDesc.Text = m_famous.Description;
                        txtYear.Text = m_famous.BirthYear.ToString();
                        txtMonth.Text = m_famous.BirthTime.Month.ToString();
                        txtDay.Text = m_famous.BirthTime.Day.ToString();
                        txtHour.Text = m_famous.BirthTime.Hour.ToString();
                        txtMinute.Text = m_famous.BirthTime.Minute.ToString();
                        if (m_famous.Height != AppConst.IntNull)
                        {
                            txtHeight.Text = m_famous.Height.ToString();
                        }

                        chkTime.SelectedIndex = chkTime.Items.IndexOf(chkTime.Items.FindByValue(m_famous.TimeUnknown.ToString()));
                        drpCate.SelectedIndex = drpCate.Items.IndexOf(drpCate.Items.FindByValue(m_famous.CateSysNo.ToString()));
                        drpGender.SelectedIndex = drpGender.Items.IndexOf(drpGender.Items.FindByValue(m_famous.Gender.ToString()));

                        DataTable m_area = SYS_DistrictBll.GetInstance().GetTreeDetail(m_famous.HomeTown);
                        if (!CommonTools.IsDataTableNoRow(m_area))
                        {
                            drpDistrict1.SelectedIndex = drpDistrict1.Items.IndexOf(drpDistrict1.Items.FindByValue(m_area.Rows[0]["SysNo1"].ToString()));
                            drpDistrict1_SelectedIndexChanged(new object(), new EventArgs());
                            drpDistrict2.SelectedIndex = drpDistrict2.Items.IndexOf(drpDistrict2.Items.FindByValue(m_area.Rows[0]["SysNo2"].ToString()));
                            drpDistrict2_SelectedIndexChanged(new object(), new EventArgs());
                            drpDistrict3.SelectedIndex = drpDistrict3.Items.IndexOf(drpDistrict3.Items.FindByValue(m_area.Rows[0]["SysNo3"].ToString()));
                            drpDistrict3_SelectedIndexChanged(new object(), new EventArgs());
                        }

                        DataTable m_keydt = REL_Famous_KeyWordBll.GetInstance().GetFamousList(SysNo);
                        if (!AppCmn.CommonTools.IsDataTableNoRow(m_keydt))
                        {
                            for (int i = 0; i < m_keydt.Rows.Count; i++)
                            {
                                txtKey.Text += m_keydt.Rows[i]["KeyWords"].ToString() + " ";
                            }
                            txtKey.Text = txtKey.Text.Trim();
                        }
                    }
                    catch
                    {
                        Response.Redirect("../Error.aspx?msg=");
                        return;
                    }
                }
            }
            else if (type == "INPUT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    try
                    {
                        int spider = int.Parse(Request.QueryString["id"]);
                        SPD_FamousMod m_spider = SPD_FamousBll.GetInstance().GetModel(spider);
                        txtSysNo.Text = "自动生成";
                        txtFullName.Text = m_spider.FamousName;
                        string[] tmp = m_spider.BirthTmp.Split(new char[] { '-', ' ', ':' });

                        if (tmp.Length > 6)
                        {
                            if (m_spider.BirthTmp.StartsWith("-"))
                            {
                                txtYear.Text = "-" + tmp[1];
                                txtMonth.Text = tmp[2].Replace("January", "1").Replace("February", "2").Replace("March", "3")
                                    .Replace("April", "4").Replace("May", "5").Replace("June", "6").Replace("July", "7")
                                    .Replace("August", "8").Replace("September", "9").Replace("October", "10")
                                    .Replace("November", "11").Replace("December", "12");
                                txtDay.Text = tmp[3];
                                if (tmp[4] == "12" && tmp[5] == "00" && tmp[6] == "PM")
                                {
                                    txtHour.Text = tmp[4];
                                    chkTime.SelectedIndex = 0;
                                }
                                else
                                {
                                    if (tmp[6] == "PM")
                                    {
                                        txtHour.Text = (int.Parse(tmp[4]) + 12).ToString();
                                    }
                                    else
                                    {
                                        txtHour.Text = tmp[4];
                                    }
                                    chkTime.SelectedIndex = 1;
                                }
                                txtMinute.Text = tmp[5];
                            }
                        }
                        else
                        {
                            txtYear.Text = tmp[0];
                            txtMonth.Text = tmp[1].Replace("January", "1").Replace("February", "2").Replace("March", "3")
                                .Replace("April", "4").Replace("May", "5").Replace("June", "6").Replace("July", "7")
                                .Replace("August", "8").Replace("September", "9").Replace("October", "10")
                                .Replace("November", "11").Replace("December", "12");
                            txtDay.Text = tmp[2];
                            if (tmp[3] == "12" && tmp[4] == "00" && tmp[5] == "PM")
                            {
                                txtHour.Text = tmp[3];
                                chkTime.SelectedIndex = 0;
                            }
                            else
                            {
                                if (tmp[5] == "PM")
                                {
                                    txtHour.Text = (int.Parse(tmp[3]) + 12).ToString();
                                }
                                else
                                {
                                    txtHour.Text = tmp[3];
                                }
                                chkTime.SelectedIndex = 1;
                            }
                            txtMinute.Text = tmp[4];
                        }

                        txtHeight.Text = m_spider.Height.Replace("m", "");
                        drpGender.SelectedIndex = drpGender.Items.IndexOf(drpGender.Items.FindByValue(m_spider.Gender.ToString()));

                        DataTable m_area = SYS_DistrictBll.GetInstance().GetTreeDetail(m_spider.HomeTown.Split(new char[] { '(',',' })[0].Trim());
                        if (!CommonTools.IsDataTableNoRow(m_area))
                        {
                            drpDistrict1.SelectedIndex = drpDistrict1.Items.IndexOf(drpDistrict1.Items.FindByValue(m_area.Rows[0]["SysNo1"].ToString()));
                            drpDistrict1_SelectedIndexChanged(new object(), new EventArgs());
                            drpDistrict2.SelectedIndex = drpDistrict2.Items.IndexOf(drpDistrict2.Items.FindByValue(m_area.Rows[0]["SysNo2"].ToString()));
                            drpDistrict2_SelectedIndexChanged(new object(), new EventArgs());
                            drpDistrict3.SelectedIndex = drpDistrict3.Items.IndexOf(drpDistrict3.Items.FindByValue(m_area.Rows[0]["SysNo3"].ToString()));
                            drpDistrict3_SelectedIndexChanged(new object(), new EventArgs());
                        }
                    }
                    catch { }
                }
            }
        }

        protected void drpDistrict1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistrict1.SelectedValue != "0")
            {
                drpDistrict2.DataSource = SYS_DistrictBll.GetInstance().GetSubLevel(int.Parse(drpDistrict1.SelectedValue));
                drpDistrict2.DataTextField = "Name";
                drpDistrict2.DataValueField = "SysNo";
                drpDistrict2.DataBind();
                drpDistrict2.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }

        protected void drpDistrict2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistrict2.SelectedValue != "0")
            {
                drpDistrict3.DataSource = SYS_DistrictBll.GetInstance().GetSubLevel(int.Parse(drpDistrict2.SelectedValue));
                drpDistrict3.DataTextField = "Name";
                drpDistrict3.DataValueField = "SysNo";
                drpDistrict3.DataBind();
                drpDistrict3.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }

        protected void drpDistrict3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistrict3.SelectedValue != "0")
            {
                SYS_DistrictMod m_area = SYS_DistrictBll.GetInstance().GetModel(int.Parse(drpDistrict3.SelectedValue));
                lblPosition.Text = "北纬" + m_area.Latitude + ",东经" + m_area.longitude;
                lblPosition.Visible = true;
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            string[] keys = this.txtKey.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            DataTable m_keys = new DataTable();
            SYS_FamousMod m_famous = new SYS_FamousMod();
            if (type == "EDIT")
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    SysNo = int.Parse(Request.QueryString["id"]);
                }
                m_famous = SYS_FamousBll.GetInstance().GetModel(SysNo);
                m_keys = REL_Famous_KeyWordBll.GetInstance().GetFamousList(SysNo);
            }
            try
            {
                m_famous.BirthYear = int.Parse(txtYear.Text);
                m_famous.BirthTime = new DateTime(AppConst.DateTimeNull.Year, int.Parse(txtMonth.Text), int.Parse(txtDay.Text),
                    int.Parse(txtHour.Text), int.Parse(txtMinute.Text), 0);
                m_famous.CateSysNo = int.Parse(drpCate.SelectedValue);
                m_famous.CustomerSysNo = GetSession().AdminEntity.CustomerSysNo;
                m_famous.Description = txtDesc.Text;
                m_famous.FullName = txtFullName.Text;
                m_famous.Gender = int.Parse(drpGender.SelectedValue);
                if (txtHeight.Text != AppConst.StringNull)
                {
                    m_famous.Height = int.Parse(txtHeight.Text);
                }
                if (drpDistrict3.SelectedValue == "0")
                {
                    ltrError.Text = "请选择第三级地区！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                }
                m_famous.HomeTown = int.Parse(drpDistrict3.SelectedValue);
                m_famous.Name = txtName.Text;
                if (type == "INPUT")
                {
                    m_famous.Source = "AstroTheme";
                }
                else
                {
                    m_famous.Source = "手动添加";
                }
                m_famous.TimeUnknown = int.Parse(chkTime.SelectedValue);

            }
            catch
            {
                ltrError.Text = "输入资料格式有误，请检查！";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
                try
                {
                    if (type == "ADD")
                    {
                        m_famous.SysNo = SYS_FamousBll.GetInstance().Add(m_famous);
                        for (int i = 0; i < keys.Length; i++)
                        {
                            SYS_Famous_KeyWordsMod tmp_key = new SYS_Famous_KeyWordsMod();
                            tmp_key.SysNo = SYS_Famous_KeyWordsBll.GetInstance().GetSysNoByName(keys[i]);
                            if (tmp_key.SysNo  == AppConst.IntNull)
                            {
                                tmp_key.KeyWords = keys[i];
                                tmp_key.SysNo = SYS_Famous_KeyWordsBll.GetInstance().Add(tmp_key);
                            }
                            REL_Famous_KeyWordMod tmp_rel = new REL_Famous_KeyWordMod();
                            tmp_rel.Famous_SysNo = m_famous.SysNo;
                            tmp_rel.KeyWord_SysNo = tmp_key.SysNo;
                            REL_Famous_KeyWordBll.GetInstance().Add(tmp_rel);
                        }
                        LogManagement.getInstance().WriteTrace(m_famous.SysNo, "Celebrity.Add", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                    }
                    else if (type == "EDIT")
                    {
                        SYS_FamousBll.GetInstance().UpDate(m_famous);
                        REL_Famous_KeyWordBll.GetInstance().RemoveAllKeyByFamous(m_famous.SysNo);
                        for (int i = 0; i < keys.Length; i++)
                        {
                            SYS_Famous_KeyWordsMod tmp_key = new SYS_Famous_KeyWordsMod();
                            tmp_key.SysNo = SYS_Famous_KeyWordsBll.GetInstance().GetSysNoByName(keys[i]);
                            if (tmp_key.SysNo == AppConst.IntNull)
                            {
                                tmp_key.KeyWords = keys[i];
                                tmp_key.SysNo = SYS_Famous_KeyWordsBll.GetInstance().Add(tmp_key);
                            }
                            REL_Famous_KeyWordMod tmp_rel = new REL_Famous_KeyWordMod();
                            tmp_rel.Famous_SysNo = m_famous.SysNo;
                            tmp_rel.KeyWord_SysNo = tmp_key.SysNo;
                            REL_Famous_KeyWordBll.GetInstance().Add(tmp_rel);
                        }
                        LogManagement.getInstance().WriteTrace(m_famous.SysNo, "Celebrity.Edit", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                    }
                    else if (type == "INPUT")
                    {
                        m_famous.SysNo = SYS_FamousBll.GetInstance().Add(m_famous);
                        int spider = int.Parse(Request.QueryString["id"]);
                        SPD_FamousMod m_spider = SPD_FamousBll.GetInstance().GetModel(spider);
                        m_spider.FamousSysNo = m_famous.SysNo;
                        SPD_FamousBll.GetInstance().UpDate(m_spider);
                        for (int i = 0; i < keys.Length; i++)
                        {
                            SYS_Famous_KeyWordsMod tmp_key = new SYS_Famous_KeyWordsMod();
                            tmp_key.SysNo = SYS_Famous_KeyWordsBll.GetInstance().GetSysNoByName(keys[i]);
                            if (tmp_key.SysNo == AppConst.IntNull)
                            {
                                tmp_key.KeyWords = keys[i];
                                tmp_key.SysNo = SYS_Famous_KeyWordsBll.GetInstance().Add(tmp_key);
                            }
                            REL_Famous_KeyWordMod tmp_rel = new REL_Famous_KeyWordMod();
                            tmp_rel.Famous_SysNo = m_famous.SysNo;
                            tmp_rel.KeyWord_SysNo = tmp_key.SysNo;
                            REL_Famous_KeyWordBll.GetInstance().Add(tmp_rel);
                        }
                        LogManagement.getInstance().WriteTrace(m_famous.SysNo, "Celebrity.Input", "IP:" + Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                    }
                    ltrNotice.Text = "该记录已保存成功！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';", true);
                }
                catch(Exception ex)
                {
                    ltrError.Text = "系统错误，保存失败！";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    LogManagement.getInstance().WriteException(ex, "Celebrity.Save", "IP:"+Request.UserHostAddress + "|AdminID:" + GetSession().AdminEntity.Username);
                }
            }

        protected void txtKey_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable m_dt = SYS_Famous_KeyWordsBll.GetInstance().GetCloserKeys(txtKey.Text, 10);
            Repeater1.DataSource = m_dt;
            Repeater1.DataBind();

            keysauto.Style["display"] = "";
            HiddenField1.Value = m_dt.Rows.Count.ToString()+"|0";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string key = txtName.Text.Split(new char[] { ' ' })[txtName.Text.Split(new char[] { ' ' }).Length - 1];
            int tmp = 0;
            DataTable m_dt = SYS_FamousBll.GetInstance().GetList(10, 1, key, AppConst.DateTimeNull, AppConst.DateTimeNull, ((int)AppEnum.State.normal).ToString(),false, ref tmp);
            Repeater2.DataSource = m_dt;
            Repeater2.DataBind();

            keysauto1.Style["display"] = "";
            HiddenField11.Value = m_dt.Rows.Count.ToString() + "|0";
        }
    }

}
