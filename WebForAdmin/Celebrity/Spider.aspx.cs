using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AppBll.Spider;
using AppMod.Spider;
using AppBll.WebSys;
using AppMod.WebSys;
using AppCmn;

namespace WebForAdmin.Celebrity
{
    public partial class Spider : PageBase
    {
        private int pageindex = 1;
        private int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            Login(Request.RawUrl);CheckPrivilege(Request.RawUrl);
            WebForAdmin.Master.AdminMaster m_master = (WebForAdmin.Master.AdminMaster)this.Master;
            m_master.PageName = "蜘蛛抓取结果";
            m_master.SetCate(WebForAdmin.Master.AdminMaster.CateType.Famous3);
            #endregion
            if (!IsPostBack)
            {
                drpNation.DataSource = SYS_DistrictBll.GetInstance().GetFirstLevel(0);
                drpNation.DataTextField = "Name";
                drpNation.DataValueField = "SysNo";
                drpNation.DataBind();
                drpNation.Items.Insert(0, new ListItem("请选择", "0"));

                if (Request.QueryString["pn"] != null && Request.QueryString["pn"] != "")
                {
                    try
                    {
                        pageindex = int.Parse(Request.QueryString["pn"]);
                    }
                    catch { }
                }
                if (Request.QueryString["name"] != null && Request.QueryString["name"] != "")
                {
                    txtName.Text = Request.QueryString["name"];
                }
                if (Request.QueryString["begin"] != null && Request.QueryString["begin"] != "")
                {
                    txtTimeBegin.Text = Request.QueryString["begin"];
                }
                if (Request.QueryString["end"] != null && Request.QueryString["end"] != "")
                {
                    txtTimeEnd.Text = Request.QueryString["end"];
                }
                if (Request.QueryString["input"] != null && Request.QueryString["input"] != "")
                {
                    for (int i = 0; i < drpInput.Items.Count; i++)
                    {
                        if (drpInput.Items[i].Value == Request.QueryString["input"])
                        {
                            drpInput.SelectedIndex = i;
                            break;
                        }
                    }
                }
                if (Request.QueryString["nation"] != null && Request.QueryString["nation"] != "")
                {
                    for (int i = 0; i < drpNation.Items.Count; i++)
                    {
                        if (drpNation.Items[i].Value == Request.QueryString["nation"])
                        {
                            drpNation.SelectedIndex = i;
                            break;
                        }
                    }
                }
                BindContent();
            }
        }

        protected void BindContent()
        {
            DateTime beginTime = AppCmn.AppConst.DateTimeNull;
            DateTime endTime = AppCmn.AppConst.DateTimeNull;
            try
            {
                if (txtTimeBegin.Text != "")
                {
                    beginTime = DateTime.Parse(txtTimeBegin.Text.Trim());
                }
                if (txtTimeEnd.Text != "")
                {
                    endTime = DateTime.Parse(txtTimeEnd.Text.Trim());
                }
            }
            catch { }
            string nation = "";
            if (drpNation.SelectedValue != "0")
            {
                DataTable tmp_dt = SYS_DistrictBll.GetInstance().GetFirstLevel(0);
                for (int i = 0; i < tmp_dt.Rows.Count; i++)
                {
                    if (tmp_dt.Rows[i]["SysNo"].ToString() == drpNation.SelectedValue)
                    {
                        nation = tmp_dt.Rows[i]["EnglishName"].ToString();
                    }
                }
            }
            DataTable m_dt = SPD_FamousBll.GetInstance().GetList(AppConst.PageSize, pageindex, txtName.Text.Trim(), int.Parse(drpInput.SelectedValue), beginTime, endTime, nation, ref total);
            m_dt.Columns.Add("Display");
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                if (m_dt.Rows[i]["FamousSysNo"] != null && m_dt.Rows[i]["FamousSysNo"].ToString() != "")
                {
                    m_dt.Rows[i]["Display"] = "display:none;";
                }
                else
                {
                    m_dt.Rows[i]["Display"] = "";
                }
            }
            rptFamous.DataSource = m_dt;
            rptFamous.DataBind();

            Pager1.url = "Spider.aspx?name=" + txtName.Text.Trim() + "&begin=" + txtTimeBegin.Text.Trim() + "&end=" + txtTimeEnd.Text.Trim() + "&input=" + drpInput.SelectedValue + "&nation=" + drpNation.SelectedValue + "&pn=";
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
            Response.Redirect("Spider.aspx?pn=1&name=" + txtName.Text.Trim() + "&begin=" + txtTimeBegin.Text.Trim() + "&end=" + txtTimeEnd.Text.Trim() + "&input=" + drpInput.SelectedValue + "&nation=" + drpNation.SelectedValue);
        }

        /// <summary>
        /// 批量导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed2_Click(object sender, EventArgs e)
        {

            using (SQLData m_data = new SQLData())
            {
                for (int i = 16831; i < 40965; i++)
                {
                    DataRow m_dr = m_data.CmdtoDataRow("select * from [SPD_Famous] where sysno =" + i);
                    if (m_dr["Name"].ToString() == "" || m_dr["Biography"].ToString() == "" || m_dr["Biography"].ToString() == "SameNameError")
                    {
                        continue;
                    }
                    SYS_FamousMod m_famous = new SYS_FamousMod();
                    if (m_dr["FamousSysNo"].ToString() != "")
                    {
                        m_famous = SYS_FamousBll.GetInstance().GetModel(int.Parse(m_dr["FamousSysNo"].ToString()));
                        m_famous.Photo = m_dr["photo"].ToString();
                        SYS_FamousBll.GetInstance().UpDate(m_famous);
                        //Console.WriteLine(m_dr["sysno"] + " update ");
                        continue;
                    }


                    DataTable m_area = SYS_DistrictBll.GetInstance().GetTreeDetail(m_dr["HomeTown"].ToString().Split(new char[] { '(', ',' })[0].Trim());
                    if (!CommonTools.IsDataTableNoRow(m_area))
                    {
                        m_famous.HomeTown = int.Parse(m_area.Rows[0]["SysNo3"].ToString());
                    }

                    string[] tmp = m_dr["BirthTmp"].ToString().Split(new char[] { '-', ' ', ':' });
                    int month = 0;
                    int day = 0;
                    int hour = 0;
                    int minute = 0;

                    if (tmp.Length > 6)
                    {
                        if (m_dr["BirthTmp"].ToString().StartsWith("-"))
                        {
                            m_famous.BirthYear = int.Parse("-" + tmp[1]);
                            month = int.Parse(tmp[2].Replace("January", "1").Replace("February", "2").Replace("March", "3")
                                .Replace("April", "4").Replace("May", "5").Replace("June", "6").Replace("July", "7")
                                .Replace("August", "8").Replace("September", "9").Replace("October", "10")
                                .Replace("November", "11").Replace("December", "12"));
                            day = int.Parse(tmp[3]);
                            if (tmp[4] == "12" && tmp[5] == "00" && tmp[6] == "PM")
                            {
                                hour = int.Parse(tmp[4]);
                                m_famous.TimeUnknown = 1;
                            }
                            else
                            {
                                if (tmp[6] == "PM" && tmp[4] != "12")
                                {
                                    hour = (int.Parse(tmp[4]) + 12);
                                }
                                else
                                {
                                    hour = int.Parse(tmp[4]);
                                }
                                m_famous.TimeUnknown = 0;
                            }
                            minute = int.Parse(tmp[5]);
                        }
                    }
                    else
                    {
                        m_famous.BirthYear = int.Parse(tmp[0]);
                        month = int.Parse(tmp[1].Replace("January", "1").Replace("February", "2").Replace("March", "3")
                            .Replace("April", "4").Replace("May", "5").Replace("June", "6").Replace("July", "7")
                            .Replace("August", "8").Replace("September", "9").Replace("October", "10")
                            .Replace("November", "11").Replace("December", "12"));
                        day = int.Parse(tmp[2]);
                        if (tmp[3] == "12" && tmp[4] == "00" && tmp[5] == "PM")
                        {
                            hour = int.Parse(tmp[3]);
                            m_famous.TimeUnknown = 1;
                        }
                        else
                        {
                            if (tmp[5] == "PM" && tmp[3] != "12")
                            {
                                hour = int.Parse(tmp[3]) + 12;
                            }
                            else
                            {
                                hour = int.Parse(tmp[3]);
                            }
                            m_famous.TimeUnknown = 0;
                        }
                        minute = int.Parse(tmp[4]);
                    }

                    m_famous.BirthTime = new DateTime(8000, month, day, hour, minute, 0);
                    m_famous.CateSysNo = 1;
                    m_famous.CustomerSysNo = 1;
                    m_famous.Description = m_dr["Biography"].ToString();
                    m_famous.DR = 0;
                    m_famous.FullName = m_dr["FamousName"].ToString();
                    m_famous.Gender = int.Parse(m_dr["Gender"].ToString());
                    if (m_dr["Height"].ToString() != "")
                    {
                        m_famous.Height = int.Parse(m_dr["Height"].ToString().Replace("m", ""));
                    }
                    m_famous.IsTop = 0;
                    m_famous.Name = m_dr["Name"].ToString();
                    m_famous.Source = "AstroTheme";
                    m_famous.TS = DateTime.Now;
                    m_famous.Photo = m_dr["photo"].ToString();
                    m_famous.SysNo = SYS_FamousBll.GetInstance().Add(m_famous);
                    SPD_FamousMod m_spider = SPD_FamousBll.GetInstance().GetModel(i);
                    m_spider.FamousSysNo = m_famous.SysNo;
                    SPD_FamousBll.GetInstance().UpDate(m_spider);
                    //Console.WriteLine(m_dr["sysno"] + " add ");
                }
            }

        }



    }
}