using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.BLG;
using AppMod.BLG;
using AppBll.Fate;
using AppBll.WebSys;
using AppMod.Fate;
using System.Data;
using AppCmn;
using WebMonitor;
using AppMod.User;

namespace WebForMain.Qin
{
    public partial class MyCollection : PageBase
    {
        private int type;
        private int pageindex = 1;
        private int pagesize = AppConst.PageSize;
        public string[] tabs = {"","","","now",""};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                try
                {
                    type = int.Parse(Request.QueryString["type"]);
                }
                catch
                {
                    type = (int)AppCmn.AppEnum.CollectionType.chart;
                }
            }
            else
            {
                type = (int)AppCmn.AppEnum.CollectionType.chart;
            }
            for (int i = 0; i < tabs.Length; i++)
            {
                if (i == type - 1)
                {
                    tabs[i] = "now";
                }
                else
                {
                    tabs[i] = "";
                }
            }
            if (!IsPostBack)
            {
                Login(Request.Url.ToString());
                WebForMain.Master.Qin m_master = (WebForMain.Master.Qin)Master;
                m_master.SetTab(1);

                #region 添加收藏 显示弹出层完善信息
                if (Request.QueryString["add"] != null && Request.QueryString["add"] == "1" && ltrInfo.Text == "")
                {
                    switch (type)
                    {
                        case (int)AppCmn.AppEnum.CollectionType.chart:
                            ltrInfo.Text = "收藏命盘：<br/>请完善以下收藏信息";
                            if (Request.QueryString["minitype"].ToUpper() == "ASTRO")
                            {
                                Literal1.Visible = true;
                                //drpGender.Visible = true;
                            }
                            ModalPopupExtender1.Show();
                            break;
                        case (int)AppCmn.AppEnum.CollectionType.url:
                            ltrInfo.Text = "收藏站外资源：<br/>请完善以下收藏信息";
                            urlli.Visible = true;
                            ModalPopupExtender1.Show();
                            break;
                        default:
                            AddCollection(sender, e);
                            break;
                    }

                    //return;
                }
                #endregion
                if (Request.QueryString["pn"] != null)
                {
                    try
                    {
                        pageindex = int.Parse(Request.QueryString["pn"]);
                    }
                    catch
                    { }
                }
                BindList();

            }
            RightPannel1.m_user = GetSession().CustomerEntity;
            imgPhoto.ImageUrl = "~/ControlLibrary/ShowPhoto.aspx?type=o&id=" + RightPannel1.m_user.Photo;
            ImageButton1.ImageUrl = AppCmn.AppConfig.WebResourcesPath()+"img/page/button4.jpg";
            ImageButton2.ImageUrl = AppCmn.AppConfig.WebResourcesPath()+"img/page/button5.jpg";
        }

        #region channel
        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCollection.aspx?type="+(int)AppCmn.AppEnum.CollectionType.quest);
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCollection.aspx?type=" + (int)AppCmn.AppEnum.CollectionType.article);
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCollection.aspx?type=" + (int)AppCmn.AppEnum.CollectionType.chart);
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCollection.aspx?type=" + (int)AppCmn.AppEnum.CollectionType.url);
        }

        protected void Unnamed7_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCollection.aspx?type=" + (int)AppCmn.AppEnum.CollectionType.famous);
        }
        #endregion

        protected void AddCollection(object sender, EventArgs e)
        {
            int addsysno = 0;
            BLG_CollectionMod m_collection = new BLG_CollectionMod();
            try
            {
                switch (type)
                {
                    case (int)AppCmn.AppEnum.CollectionType.quest:
                        if (Request.QueryString["sysno"] == null)
                        {
                            Response.Redirect("../Error.aspx?msg=");
                        }
                        try
                        {
                            addsysno = int.Parse(Request.QueryString["sysno"]);
                        }
                        catch
                        {
                            Response.Redirect("../Error.aspx?msg=");
                        }
                        m_collection.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                        m_collection.DR = (int)AppEnum.State.normal;
                        m_collection.Name = "";
                        m_collection.TS = DateTime.Now;
                        m_collection.Type = (int)AppEnum.CollectionType.quest;
                        m_collection.RefSysNo = addsysno;
                        BLG_CollectionBll.GetInstance().Add(m_collection);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "addquestok", "alert('问题收藏成功');", true);
                        break;
                    case (int)AppCmn.AppEnum.CollectionType.article:
                        if (Request.QueryString["sysno"] == null)
                        {
                            Response.Redirect("../Error.aspx?msg=");
                        }
                        try
                        {
                            addsysno = int.Parse(Request.QueryString["sysno"]);
                        }
                        catch
                        {
                            Response.Redirect("../Error.aspx?msg=");
                        }
                        m_collection.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                        m_collection.DR = (int)AppEnum.State.normal;
                        m_collection.Name = "";
                        m_collection.TS = DateTime.Now;
                        m_collection.Type = (int)AppEnum.CollectionType.article;
                        m_collection.RefSysNo = addsysno;
                        BLG_CollectionBll.GetInstance().Add(m_collection);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "addquestok", "alert('文章收藏成功');", true);
                        break;
                    case (int)AppCmn.AppEnum.CollectionType.famous:
                        if (Request.QueryString["sysno"] == null)
                        {
                            Response.Redirect("../Error.aspx?msg=");
                        }
                        try
                        {
                            addsysno = int.Parse(Request.QueryString["sysno"]);
                        }
                        catch
                        {
                            Response.Redirect("../Error.aspx?msg=");
                        }
                        m_collection.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                        m_collection.DR = (int)AppEnum.State.normal;
                        m_collection.Name = "";
                        m_collection.TS = DateTime.Now;
                        m_collection.Type = (int)AppEnum.CollectionType.famous;
                        m_collection.RefSysNo = addsysno;
                        BLG_CollectionBll.GetInstance().Add(m_collection);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "addquestok", "alert('名人收藏成功');", true);
                        break;
                    case (int)AppCmn.AppEnum.CollectionType.chart:
                        FATE_ChartMod m_fate = new FATE_ChartMod();
                        try
                        {
                            string[] tmps = Request.QueryString["p"].Split(new char[] { '_' });
                            switch (Request.QueryString["minitype"].ToUpper())
                            {
                                case "ASTRO":
                                    m_fate.CharType = (int)AppEnum.ChartType.personal;
                                    m_fate.FirstBirth = new DateTime(int.Parse(tmps[0]), int.Parse(tmps[1]), int.Parse(tmps[2]), int.Parse(tmps[3]), int.Parse(tmps[4]), 0);
                                    m_fate.FirstPoi = tmps[7] + "|" + tmps[6];
                                    m_fate.Transit = DateTime.Now;
                                    m_fate.TransitPoi = m_fate.FirstPoi;
                                    m_fate.TheoryType = 0;
                                    DataTable m_dist = SYS_DistrictBll.GetInstance().GetInfoByPoi(tmps[6], tmps[7]);
                                    if (m_dist.Rows.Count > 0)
                                    {
                                        m_fate.FirstPoiName = m_dist.Rows[0]["Name1"] + "-" + m_dist.Rows[0]["Name2"] + "-" + m_dist.Rows[0]["Name3"];
                                    }
                                    else
                                    {
                                        m_fate.FirstPoiName = "未知";
                                    }
                                    m_fate.FirstTimeZone = int.Parse(tmps[8]);
                                    m_fate.FirstGender = int.Parse(drpGender.SelectedValue);
                                    if (tmps[5] == "1")
                                    {
                                        m_fate.FirstDayLight = (int)AppEnum.BOOL.True;
                                    }
                                    else
                                    {
                                        m_fate.FirstDayLight = (int)AppEnum.BOOL.False;
                                    }
                                    break;
                                case "ZIWEI":
                                    m_fate.CharType = (int)AppEnum.ChartType.personal;
                                    m_fate.FirstBirth = new DateTime(int.Parse(tmps[0]), int.Parse(tmps[1]), int.Parse(tmps[2]), int.Parse(tmps[3]), int.Parse(tmps[4]), 0);
                                    m_fate.FirstPoi = "120.129798|30.259497";
                                    m_fate.Transit = DateTime.Now;
                                    m_fate.TransitPoi = m_fate.FirstPoi;
                                    m_fate.TheoryType = 0;
                                    m_fate.FirstPoiName = "浙江省-杭州市-西湖区";
                                    m_fate.FirstTimeZone = -8;
                                    m_fate.FirstGender = int.Parse(tmps[5]);
                                    m_fate.FirstDayLight = (int)AppEnum.BOOL.False;
                                    break;
                                case "BAZI":
                                    m_fate.CharType = (int)AppEnum.ChartType.personal;
                                    m_fate.FirstBirth = new DateTime(int.Parse(tmps[0]), int.Parse(tmps[1]), int.Parse(tmps[2]), int.Parse(tmps[3]), int.Parse(tmps[4]), 0);
                                    m_fate.FirstPoi = "120.129798|30.259497";
                                    m_fate.Transit = DateTime.Now;
                                    m_fate.TransitPoi = m_fate.FirstPoi;
                                    m_fate.TheoryType = 0;
                                    m_fate.FirstPoiName = "浙江省-杭州市-西湖区";
                                    m_fate.FirstTimeZone = -8;
                                    m_fate.FirstGender = int.Parse(tmps[5]);
                                    m_fate.FirstDayLight = (int)AppEnum.BOOL.False;
                                    break;
                                default:
                                    Response.Redirect("../Error.aspx?msg=");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogManagement.getInstance().WriteException(ex, "Collection-AddFate", Request.UserHostAddress, "收藏命盘失败");
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "addwrong", "alert('系统错误，请联系管理员');", true);
                        }
                        m_collection.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                        m_collection.DR = (int)AppEnum.State.normal;
                        m_collection.Name = Server.HtmlEncode(txtName.Text.Trim());
                        m_collection.TS = DateTime.Now;
                        m_collection.Type = (int)AppEnum.CollectionType.chart;
                        m_collection.Detail = Server.HtmlEncode(txtDetail.Text.Trim());
                        m_collection.RefSysNo = FATE_ChartBll.GetInstance().Add(m_fate);

                        BLG_CollectionBll.GetInstance().Add(m_collection);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "addfateok", "alert('命盘收藏成功');", true);
                        ModalPopupExtender1.Hide();
                        break;
                    case (int)AppCmn.AppEnum.CollectionType.url:
                        m_collection.CustomerSysNo = GetSession().CustomerEntity.SysNo;
                        m_collection.DR = (int)AppEnum.State.normal;
                        m_collection.Name = Server.HtmlEncode(txtName.Text.Trim());
                        m_collection.TS = DateTime.Now;
                        m_collection.Type = (int)AppEnum.CollectionType.url;
                        m_collection.RefUrl = Server.HtmlEncode(txtUrl.Text.Trim());
                        m_collection.Detail = Server.HtmlEncode(txtDetail.Text.Trim());
                        BLG_CollectionBll.GetInstance().Add(m_collection);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "addquestok", "alert('站外资源收藏成功');", true);
                        break;
                    default:
                        Response.Redirect("../Error.aspx?msg=");//type无效
                        break;
                }
            }
            catch(Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "Collection-Add", Request.UserHostAddress, "添加收藏失败");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "addwrong", "alert('系统错误，请联系管理员');", true);
            }
            Response.Redirect("MyCollection.aspx?type="+type);
        }
        protected void BindList()
        {
            DataTable m_dt = new DataTable();
            int total = 0;
            switch (type)
            {
                case (int)AppCmn.AppEnum.CollectionType.quest:
                    ComboShow1.Type = ControlLibrary.ComboShow.ComboShowType.Quest;
                    m_dt = BLG_CollectionBll.GetInstance().GetQuestCollection(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);
                    break;
                case (int)AppCmn.AppEnum.CollectionType.article:
                    ComboShow1.Type = ControlLibrary.ComboShow.ComboShowType.Article;
                    m_dt = BLG_CollectionBll.GetInstance().GetArticleCollection(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);
                    break;
                case (int)AppCmn.AppEnum.CollectionType.famous:
                    ComboShow1.Type = ControlLibrary.ComboShow.ComboShowType.Famous;
                    m_dt = BLG_CollectionBll.GetInstance().GetFamousCollection(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);
                    break;
                case (int)AppCmn.AppEnum.CollectionType.chart:
                    ComboShow1.Type = ControlLibrary.ComboShow.ComboShowType.Chart;
                    m_dt = BLG_CollectionBll.GetInstance().GetChartCollection(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);
                    break;
                case (int)AppCmn.AppEnum.CollectionType.url:
                    ComboShow1.Type = ControlLibrary.ComboShow.ComboShowType.Link;
                    m_dt = BLG_CollectionBll.GetInstance().GetUrlCollection(GetSession().CustomerEntity.SysNo, pagesize, pageindex, ref total);
                    break;
            }
            ComboShow1.IsWide = true;
            ComboShow1.DataList = m_dt;


            Pager1.url = "MyCollection.aspx?type="+type+"&pn=";
            Pager1.totalrecord = total;
            if (total % AppConst.PageSize == 0)
            {
                this.Pager1.total = total / pagesize;
            }
            else
            {
                this.Pager1.total = total / pagesize + 1;
            }
            this.Pager1.index = pageindex;
            this.Pager1.numlenth = 3;
        }

        #region 点击按钮添加外链与命盘
        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MyCollection.aspx?type=" + (int)AppEnum.CollectionType.url+"&add=1");
        }

        protected void Unnamed_Click1(object sender, ImageClickEventArgs e)
        {
            switch (GetSession().CustomerEntity.FateType)
                {
                    case (int)AppEnum.FateType.astro:
                        Response.Redirect("../PPLive/Astro.aspx");
                        break;
                    case (int)AppEnum.FateType.ziwei:
                        Response.Redirect("../PPLive/ZiWei.aspx");
                        break;
                    case (int)AppEnum.FateType.bazi:
                        Response.Redirect("../PPLive/BaZi.aspx");
                        break;
                }
        }
        #endregion
    }
}