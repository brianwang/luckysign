﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCmn;
using PPLive;
using PPLive.BaZi;
using System.Data;
using AppMod.Research;
using AppBll.Research;

namespace WebForAnalyse.BaZi
{
    public partial class PatternEdit : PageBase
    {
        private int sysno=AppConst.IntNull;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            //Login(Request.RawUrl);
            WebForAnalyse.Master.AdminMaster m_master = (WebForAnalyse.Master.AdminMaster)this.Master;
            m_master.PageName = "八字格局设置";
            m_master.SetCate(WebForAnalyse.Master.AdminMaster.CateType.ZiWei1);
            #endregion
            if (!IsPostBack)
            {
                DataTable m_dt = new DataTable();
                m_dt.Columns.Add("id");
                for(int i=0;i<50;i++)
                {
                    DataRow m_dr = m_dt.NewRow();
                    m_dr["id"] = i;
                    m_dt.Rows.Add(m_dr);
                }
                Repeater1.DataSource =m_dt;
                Repeater1.DataBind();

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

            List<RSH_BaziConditionMod> m_condition = new List<RSH_BaziConditionMod>();


            for (int i = 0; i < 50; i++)
            {
                if (Repeater1.Items[i].FindControl("drpItem").Visible)
                {
                    RSH_BaziConditionMod m_tmp = new RSH_BaziConditionMod();

                    m_tmp.Item = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpItem")).SelectedValue);
                    m_tmp.Type = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpType")).SelectedValue);
                    m_tmp.Condition = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpCondition")).SelectedValue);
                    m_tmp.Target = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpTarget")).SelectedValue);
                    m_condition.Add(m_tmp);
                }
            }

            for (int i = 0; m_date.Date < m_date1.Date; i++)
            {
                m_date = new DateEntity(m_date.Date.AddHours(2));
                BaZiMod tmpzw = new BaZiMod();
                tmpzw.BirthTime = m_date;
                tmpzw.Gender = AppEnum.Gender.male;
                BaZiBiz.GetInstance().TimeToBaZi(ref tmpzw);
                bool flag = true;
                for (int j = 0; j < 50; j++)
                {
                    //逻辑筛选
                }
                if (flag)
                {
                    ltrResult.Text += m_date.Date.ToString("yyyy-MM-dd HH:00:00 ")+"<br />";
                }
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "plus(1);", true);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList drpItem = (DropDownList)e.Item.FindControl("drpItem");
            drpItem.DataSource = PublicValue.GetBaZiLogicItem();
            drpItem.DataTextField = "value";
            drpItem.DataValueField = "key";
            drpItem.DataBind();
            drpItem.Items.Insert(0, new ListItem("请选择", "-1"));

            DropDownList drpType = (DropDownList)e.Item.FindControl("drpType");
            drpType.DataSource = PublicValue.GetBaZiLogicType();
            drpType.DataTextField = "value";
            drpType.DataValueField = "key";
            drpType.DataBind();
            drpType.Items.Insert(0, new ListItem("请选择", "-1"));

            DropDownList drpTarget = (DropDownList)e.Item.FindControl("drpTarget");
            drpTarget.DataSource = PublicValue.GetBaZiLogicItem();
            drpTarget.DataTextField = "value";
            drpTarget.DataValueField = "key";
            drpTarget.DataBind();
            drpTarget.Items.Insert(0, new ListItem("无", "0"));
            drpTarget.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<int,RSH_BaziConditionMod> m_condition = new Dictionary<int,RSH_BaziConditionMod>();

            for (int i = 0; i < 50; i++)
            {
                if (Repeater1.Items[i].FindControl("drpItem").Visible)
                {
                    RSH_BaziConditionMod m_tmp = new RSH_BaziConditionMod();

                    m_tmp.Item = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpItem")).SelectedValue);
                    m_tmp.Type = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpType")).SelectedValue);
                    m_tmp.Condition = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpCondition")).SelectedValue);
                    m_tmp.Target = int.Parse(((DropDownList)Repeater1.Items[i].FindControl("drpTarget")).SelectedValue);
                    m_tmp.SysNo = RSH_BaziConditionBll.GetInstance().Add(m_tmp);
                    m_condition.Add(i,m_tmp);
                }
            }

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DropDownList m_drp = (DropDownList)e.Item.FindControl("drpLogic");
            if (m_drp.Visible)
            {
                ((Button)e.Item.FindControl("Button2")).Text = "添加已有逻辑";
                m_drp.Visible = false;
                ((DropDownList)e.Item.FindControl("drpItem")).Visible = true;
                ((DropDownList)e.Item.FindControl("drpType")).Visible = true;
                ((DropDownList)e.Item.FindControl("drpCondition")).Visible = true;
                ((DropDownList)e.Item.FindControl("drpTarget")).Visible = true;
            }
            else
            {
                ((Button)e.Item.FindControl("Button2")).Text = "添加新条件";
                m_drp.Visible = true;
                ((DropDownList)e.Item.FindControl("drpItem")).Visible = false;
                ((DropDownList)e.Item.FindControl("drpType")).Visible = false;
                ((DropDownList)e.Item.FindControl("drpCondition")).Visible = false;
                ((DropDownList)e.Item.FindControl("drpTarget")).Visible = false;
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

        }

        protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            Repeater rpt = ddl.Parent.Parent as Repeater;
            int n = ((RepeaterItem)ddl.Parent).ItemIndex;
            DropDownList ddl2 = rpt.Items[n].FindControl("drpCondition") as DropDownList;
            switch (ddl.SelectedIndex)
            {
                case 1:
                    ddl2.DataSource = PublicValue.GetShiShen();
                    ddl2.DataTextField = "value";
                    ddl2.DataValueField = "key";
                    ddl2.DataBind();
                    ddl2.Items.Insert(0, new ListItem("请选择", "-1"));
                    break;
                case 2:
                    ddl2.DataSource = PublicValue.GetShiShen();
                    ddl2.DataTextField = "value";
                    ddl2.DataValueField = "key";
                    ddl2.DataBind();
                    ddl2.Items.Insert(0, new ListItem("请选择", "-1"));
                    break;
            }
        }
    }
}