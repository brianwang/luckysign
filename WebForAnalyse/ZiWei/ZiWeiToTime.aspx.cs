using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using PPLive;
using PPLive.ZiWei;
using System.Data;

namespace WebForAnalyse.ZiWei
{
    public partial class ZiWeiToTime : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            //Login(Request.RawUrl);
            WebForAnalyse.Master.AdminMaster m_master = (WebForAnalyse.Master.AdminMaster)this.Master;
            m_master.PageName = "紫薇格局分析";
            m_master.SetCate(WebForAnalyse.Master.AdminMaster.CateType.ZiWei1);
            #endregion
            if (!IsPostBack)
            {
                DataTable m_dt = new DataTable();
                m_dt.Columns.Add("id");
                for(int i=0;i<10;i++)
                {
                    DataRow m_dr = m_dt.NewRow();
                    m_dr["id"] = i;
                    m_dt.Rows.Add(m_dr);
                }
                Repeater1.DataSource =m_dt;
                Repeater1.DataBind();
                Repeater2.DataSource = m_dt;
                Repeater2.DataBind();

                this.ClientScript.RegisterStartupScript(this.GetType(), "", "plus(1);", true);
            }
        }

        private int dayun = 6;
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ltrResult.Text = "";
            if (txtDate.Text == "" || txtDate1.Text == "")
            {
                ltrNotice.Text = "请选择日期";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';closeforseconds();", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "plus(1);", true);
                return;
            }
            DateEntity m_date = new DateEntity(new DateTime(int.Parse(txtDate.Text.Split(new char[] { '-' })[0]), int.Parse(txtDate.Text.Split(new char[] { '-' })[1]), int.Parse(txtDate.Text.Split(new char[] { '-' })[2]),
               0, 0, 0));
            DateEntity m_date1 = new DateEntity(new DateTime(int.Parse(txtDate1.Text.Split(new char[] { '-' })[0]), int.Parse(txtDate1.Text.Split(new char[] { '-' })[1]), int.Parse(txtDate1.Text.Split(new char[] { '-' })[2]),
               0, 0, 0));
            if (m_date.Date >= m_date1.Date)
            {
                ltrNotice.Text = "开始日期必须在结束日期前";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';closeforseconds();", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "plus(1);", true);
                return;
            }
            DataTable m_dt1 = new DataTable();
            m_dt1.Columns.Add("star");
            m_dt1.Columns.Add("gong");
            m_dt1.Columns.Add("wei");
            m_dt1.Columns.Add("hua");

            DataTable m_dt2 = new DataTable();
            m_dt2.Columns.Add("star");
            m_dt2.Columns.Add("star1");
            m_dt2.Columns.Add("hua1");
            m_dt2.Columns.Add("hua");
            m_dt2.Columns.Add("rel");

            for (int i = 0; i < 10; i++)
            {
                DataRow m_dr1 = m_dt1.NewRow();
                m_dr1["star"] = ((DropDownList)Repeater1.Items[i].FindControl("drpStar")).SelectedValue;
                m_dr1["gong"] = ((DropDownList)Repeater1.Items[i].FindControl("drpGong")).SelectedItem.Text;
                m_dr1["wei"] = ((DropDownList)Repeater1.Items[i].FindControl("drpWei")).SelectedItem.Text;
                m_dr1["hua"] = ((DropDownList)Repeater1.Items[i].FindControl("drpHua")).SelectedItem.Text;
                m_dt1.Rows.Add(m_dr1);

                DataRow m_dr2 = m_dt2.NewRow();
                m_dr2["star"] = ((DropDownList)Repeater2.Items[i].FindControl("drpStar")).SelectedValue;
                m_dr2["star1"] = ((DropDownList)Repeater2.Items[i].FindControl("drpStar1")).SelectedValue;
                //m_dr2["hua1"] = ((DropDownList)Repeater2.Items[i].FindControl("drpHua1")).SelectedValue;
                //m_dr2["hua"] = ((DropDownList)Repeater2.Items[i].FindControl("drpHua")).SelectedValue;
                m_dr2["rel"] = ((DropDownList)Repeater2.Items[i].FindControl("drpRel")).SelectedValue;
                m_dt2.Rows.Add(m_dr2);
            }

            for (int i = 0; m_date.Date < m_date1.Date; i++)
            {
                m_date = new DateEntity(m_date.Date.AddHours(2));
                ZiWeiMod tmpzw = ZiWeiBiz.GetInstance().TimeToZiWei(m_date, AppEnum.Gender.male, new int[] { 1, 1, 0,1 });
                bool flag = true;
                for (int j = 0; j < 10; j++)
                {
                    if (m_dt1.Rows[j]["star"].ToString() != "-1")
                    {
                        if (m_dt1.Rows[j]["gong"].ToString() != "请选择")
                        {
                            if (PublicValue.GetZiWeiGong(tmpzw.Gong[tmpzw.Xing[int.Parse(m_dt1.Rows[j]["star"].ToString())].Gong].GongName) != m_dt1.Rows[j]["gong"].ToString())
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (m_dt1.Rows[j]["wei"].ToString() != "请选择")
                        {
                            if (PublicValue.GetDiZhi(tmpzw.Gong[tmpzw.Xing[int.Parse(m_dt1.Rows[j]["star"].ToString())].Gong].DZ) != m_dt1.Rows[j]["wei"].ToString())
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (m_dt1.Rows[j]["hua"].ToString() != "　")
                        {
                            if (PublicValue.GetZiWeiSihua(tmpzw.Xing[int.Parse(m_dt1.Rows[j]["star"].ToString())].Hua) != m_dt1.Rows[j]["hua"].ToString())
                            {
                                flag = false;
                                break;
                            }
                        }
                    }

                    if (m_dt2.Rows[j]["star"].ToString() != "-1" && m_dt2.Rows[j]["star1"].ToString() != "-1")
                    {
                        if (m_dt2.Rows[j]["rel"].ToString() == "0" && !(tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star"].ToString())].Gong == tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star1"].ToString())].Gong))
                        {
                            flag = false;
                            break;
                        }
                        else if (m_dt2.Rows[j]["rel"].ToString() == "1" && !(Math.Abs(tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star"].ToString())].Gong - tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star1"].ToString())].Gong) == 6))
                        {
                            flag = false;
                            break;
                        }
                        else if (m_dt2.Rows[j]["rel"].ToString() == "2" && !((Math.Abs(tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star"].ToString())].Gong - tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star1"].ToString())].Gong) == 4|| 
                            Math.Abs(tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star"].ToString())].Gong - tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star1"].ToString())].Gong) == 8)))
                        {
                            flag = false;
                            break;
                        }
                        else if (m_dt2.Rows[j]["rel"].ToString() == "3" && !((Math.Abs(tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star"].ToString())].Gong - tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star1"].ToString())].Gong) == 6 ||
                            Math.Abs(tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star"].ToString())].Gong - tmpzw.Xing[int.Parse(m_dt2.Rows[j]["star1"].ToString())].Gong) %4==0)))
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    ltrResult.Text += m_date.Date.ToString("yyyy-MM-dd HH:00:00 ")+"<a href='http://pp.ssqian.com/PPLive/AstroChart.aspx?ID=-qb_"+m_date.Date.ToString("MM dd yyyy HH;00;00")+" 0_-8_120E42_21N93_-c_0_-YAo_1_5_10_8_8_8_5_-R0_1_2_3_4_5_6_7_8_9_10 14 18_21_24_27_30' target='_blank'>查看星盘</a><br />";
                }
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "plus(1);", true);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList drpStar = (DropDownList)e.Item.FindControl("drpStar");
            drpStar.DataSource = PublicValue.GetZiWeiStar();
            drpStar.DataTextField = "value";
            drpStar.DataValueField = "key";
            drpStar.DataBind();
            drpStar.Items.Insert(0, new ListItem("请选择", "-1"));

            DropDownList drpGong = (DropDownList)e.Item.FindControl("drpGong");
            drpGong.DataSource = PublicValue.GetZiWeiGong();
            drpGong.DataTextField = "value";
            drpGong.DataValueField = "key";
            drpGong.DataBind();
            drpGong.Items.Insert(0, new ListItem("请选择", "-1"));

            DropDownList drpWei = (DropDownList)e.Item.FindControl("drpWei");
            drpWei.DataSource = PublicValue.GetDiZhi();
            drpWei.DataTextField = "value";
            drpWei.DataValueField = "key";
            drpWei.DataBind();
            drpWei.Items.Insert(0, new ListItem("请选择", "-1"));

            DropDownList drpHua = (DropDownList)e.Item.FindControl("drpHua");
            drpHua.DataSource = PublicValue.GetZiWeiSihua();
            drpHua.DataTextField = "value";
            drpHua.DataValueField = "key";
            drpHua.DataBind();
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList drpStar = (DropDownList)e.Item.FindControl("drpStar");
            drpStar.DataSource = PublicValue.GetZiWeiStar();
            drpStar.DataTextField = "value";
            drpStar.DataValueField = "key";
            drpStar.DataBind();
            drpStar.Items.Insert(0, new ListItem("请选择", "-1"));

            DropDownList drpStar1 = (DropDownList)e.Item.FindControl("drpStar1");
            drpStar1.DataSource = PublicValue.GetZiWeiStar();
            drpStar1.DataTextField = "value";
            drpStar1.DataValueField = "key";
            drpStar1.DataBind();
            drpStar1.Items.Insert(0, new ListItem("请选择", "-1"));

            //DropDownList drpHua = (DropDownList)e.Item.FindControl("drpHua");
            //drpHua.DataSource = PublicValue.GetZiWeiSihua();
            //drpHua.DataTextField = "value";
            //drpHua.DataValueField = "key";
            //drpHua.DataBind();

            //DropDownList drpHua1 = (DropDownList)e.Item.FindControl("drpHua1");
            //drpHua1.DataSource = PublicValue.GetZiWeiSihua();
            //drpHua1.DataTextField = "value";
            //drpHua1.DataValueField = "key";
            //drpHua1.DataBind();
        }
    }
}