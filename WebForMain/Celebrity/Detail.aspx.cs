using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMod.WebSys;
using AppMod.Fate;
using AppBll.WebSys;
using WebMonitor;
using AppMod.User;
using AppCmn;
using AppBll.User;
using System.Text;
using System.Data;

namespace WebForMain.Celebrity
{
    public partial class Detail : PageBase
    {
        // Fields
        
        public SYS_FamousMod m_famous = new SYS_FamousMod();     
        private int pageindex = 1;
        private int pagesize = 10;
        public int sysno = 0;

        // Methods
        protected void BindChart()
        {
            if ((this.m_famous.SysNo != -999999) && (this.m_famous.BirthYear > 0))
            {
                FATE_ChartMod m_chart = new FATE_ChartMod
                {
                    CharType = 1,
                    FirstBirth = new DateTime(this.m_famous.BirthYear, this.m_famous.BirthTime.Month, this.m_famous.BirthTime.Day, this.m_famous.BirthTime.Hour, this.m_famous.BirthTime.Minute, this.m_famous.BirthTime.Second),
                    FirstDayLight = 0,
                    FirstGender = this.m_famous.Gender,
                    FirstPoi = this.GetHomeTown(this.m_famous.HomeTown) == "未知" ? "120E00|30N00" : this.GetHomeTown(this.m_famous.HomeTown).Replace("　", "|").Split(new char[] { '>' })[1],
                    FirstPoiName = ""
                };
                if (m_chart.FirstPoi.Contains("W"))
                {
                    m_chart.FirstTimeZone = this.GetTimeZone(decimal.Parse("-" + m_chart.FirstPoi.Trim().Split(new char[] { '|' })[0].Replace("W", ".")));
                }
                else
                {
                    m_chart.FirstTimeZone = this.GetTimeZone(decimal.Parse(m_chart.FirstPoi.Trim().Split(new char[] { '|' })[0].Replace("E", ".")));
                }
                if ((base.GetSession().CustomerEntity == null) || (base.GetSession().CustomerEntity.SysNo == -999999))
                {
                    this.Astro1.input = m_chart;
                    this.Astro1.Visible = true;
                }
                else
                {
                    switch (base.GetSession().CustomerEntity.FateType)
                    {
                        case 1:
                            this.Astro1.input = m_chart;
                            this.Astro1.Visible = true;
                            return;

                        case 2:
                            this.Ziwei1.IfRealTime = false;
                            this.Ziwei1.input = m_chart;
                            this.Ziwei1.Visible = true;
                            return;

                        case 3:
                            this.Bazi1.IfRealTime = false;
                            this.Bazi1.input = m_chart;
                            this.Bazi1.Visible = true;
                            return;
                    }
                }
            }
        }

        protected void BindComment()
        {
            int total = 0;
            this.rptComment.DataSource = SYS_Famous_CommentBll.GetInstance().GetListByFamousSysNo(this.pageindex, this.pagesize, this.sysno, ref total);
            this.rptComment.DataBind();
            this.Pager1.url = "Detail.aspx?id=" + this.sysno + "&pn=";
            this.Pager1.totalrecord = total;
            if ((total % this.pagesize) == 0)
            {
                this.Pager1.total = total / this.pagesize;
            }
            else
            {
                this.Pager1.total = (total / this.pagesize) + 1;
            }
            this.Pager1.index = this.pageindex;
            this.Pager1.numlenth = 3;
        }

        protected void BindFamous()
        {
            this.m_famous = SYS_FamousBll.GetInstance().GetModel(this.sysno);
            if (this.m_famous.Photo == "")
            {
                this.m_famous.Photo = "";
            }
            else if (!this.m_famous.Photo.Contains("//"))
            {
                this.m_famous.Photo = "../WebResources/FamousPhoto/" + this.m_famous.Photo;
            }
            this.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SYS_Famous_CommentMod m_comment = new SYS_Famous_CommentMod
                {
                    Context = base.Server.HtmlEncode(this.TextBox1.Text.Trim()),
                    CustomerSysNo = base.GetSession().CustomerEntity.SysNo,
                    DR = 0,
                    FamousSysNo = this.sysno,
                    TS = DateTime.Now
                };
                SYS_Famous_CommentBll.GetInstance().Add(m_comment);
                this.BindComment();
                this.TextBox1.Text = "";
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.UpdatePanel1.GetType(), "addcomment", "alert('评论发布成功！');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.UpdatePanel1.GetType(), "addcomment", "alert('系统错误，请联系管理员！');", true);
                LogManagement.getInstance().WriteException(ex, "FamousComment-Add", base.Request.UserHostAddress, "发布评论失败");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(this.TextBox3.Text.Trim(), this.TextBox4.Text.Trim());
            if (m_user.SysNo != -999999)
            {
                base.SetSession(m_user);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.UpdatePanel1.GetType(), "addcomment", "alert('账号或密码错误，请重新输入！');", true);
                return;
            }
            this.TextBox1.Text = this.TextBox2.Text;
            this.Button1_Click(sender, e);
            this.BindFamous();
            this.BindChart();
            this.TextBox2.Text = "";
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.UpdatePanel1.GetType(), "refresh", "location.reload();", true);
        }

        public string GetHomeTown(int input)
        {
            DataTable m_dt = SYS_DistrictBll.GetInstance().GetTreeDetail(input);
            if (m_dt.Rows.Count > 0)
            {
                StringBuilder m_sb = new StringBuilder();
                m_sb.Append(m_dt.Rows[0]["Name1"].ToString()).Append("-").Append(m_dt.Rows[0]["Name2"].ToString()).Append("-").Append(m_dt.Rows[0]["Name3"].ToString()).Append("<br />");
                if (m_dt.Rows[0]["longitude3"] != null && m_dt.Rows[0]["longitude3"].ToString() != "")
                {
                    if (decimal.Parse(m_dt.Rows[0]["longitude3"].ToString()) >= 0M)
                    {
                        m_sb.Append(m_dt.Rows[0]["longitude3"].ToString().Replace(".", "E"));
                    }
                    else
                    {
                        m_sb.Append(m_dt.Rows[0]["longitude3"].ToString().Replace(".", "W").Replace("-", ""));
                    }
                    m_sb.Append("　");
                    if (decimal.Parse(m_dt.Rows[0]["Latitude3"].ToString()) >= 0M)
                    {
                        m_sb.Append(m_dt.Rows[0]["Latitude3"].ToString().Replace(".", "N"));
                    }
                    else
                    {
                        m_sb.Append(m_dt.Rows[0]["Latitude3"].ToString().Replace(".", "S").Replace("-", ""));
                    }
                }
                else if (m_dt.Rows[0]["longitude2"] != null && m_dt.Rows[0]["longitude2"].ToString() != "")
                {
                    if (decimal.Parse(m_dt.Rows[0]["longitude2"].ToString()) >= 0M)
                    {
                        m_sb.Append(m_dt.Rows[0]["longitude2"].ToString().Replace(".", "E"));
                    }
                    else
                    {
                        m_sb.Append(m_dt.Rows[0]["longitude2"].ToString().Replace(".", "W").Replace("-", ""));
                    }
                    m_sb.Append("　");
                    if (decimal.Parse(m_dt.Rows[0]["Latitude2"].ToString()) >= 0M)
                    {
                        m_sb.Append(m_dt.Rows[0]["Latitude2"].ToString().Replace(".", "N"));
                    }
                    else
                    {
                        m_sb.Append(m_dt.Rows[0]["Latitude2"].ToString().Replace(".", "S").Replace("-", ""));
                    }
                }
                else if (m_dt.Rows[0]["longitude1"] != null && m_dt.Rows[0]["longitude1"].ToString() != "")
                {
                    if (decimal.Parse(m_dt.Rows[0]["longitude1"].ToString()) >= 0M)
                    {
                        m_sb.Append(m_dt.Rows[0]["longitude1"].ToString().Replace(".", "E"));
                    }
                    else
                    {
                        m_sb.Append(m_dt.Rows[0]["longitude1"].ToString().Replace(".", "W").Replace("-", ""));
                    }
                    m_sb.Append("　");
                    if (decimal.Parse(m_dt.Rows[0]["Latitude1"].ToString()) >= 0M)
                    {
                        m_sb.Append(m_dt.Rows[0]["Latitude1"].ToString().Replace(".", "N"));
                    }
                    else
                    {
                        m_sb.Append(m_dt.Rows[0]["Latitude1"].ToString().Replace(".", "S").Replace("-", ""));
                    }
                }
                return m_sb.ToString();
            }
            return "未知";
        }

        public string GetTimeUnknow(int input)
        {
            if (input == 1)
            {
                return "时间不精确";
            }
            return "时间精确";
        }

        public int GetTimeZone(decimal input)
        {
            input /= 15M;
            if ((input - Math.Floor(input)) > 0.5M)
            {
                return -(((int)Math.Floor(input)) + 1);
            }
            return -((int)Math.Floor(input));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((base.Request.QueryString["id"] != null) && (base.Request.QueryString["id"] != ""))
            {
                try
                {
                    this.sysno = int.Parse(CommonTools.Decode(base.Request.QueryString["id"].Replace(" ", "+")));
                }
                catch
                {
                    base.Response.Redirect("../Error.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../Error.aspx");
            }
            if (!base.IsPostBack)
            {
                this.BindFamous();
                this.BindComment();
                this.BindChart();
            }
            if ((base.GetSession().CustomerEntity == null) || (base.GetSession().CustomerEntity.SysNo == -999999))
            {
                this.MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                this.MultiView1.ActiveViewIndex = 0;
                this.Image1.ImageUrl = "../ControlLibrary/ShowPhoto.aspx?type=t&id=" + base.GetSession().CustomerEntity.Photo;
            }
        }

    }
}