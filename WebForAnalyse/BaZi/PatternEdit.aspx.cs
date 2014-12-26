using System;
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
using System.Transactions;
using System.Web.UI.HtmlControls;

namespace WebForAnalyse.BaZi
{
    public partial class PatternEdit : PageBase
    {
        private int sysno = AppConst.IntNull;
        private DataTable LogicList = new DataTable();
        private DataTable ConditionList = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化
            //Login(Request.RawUrl);
            WebForAnalyse.Master.AdminMaster m_master = (WebForAnalyse.Master.AdminMaster)this.Master;
            m_master.PageName = "八字组合设置";
            m_master.SetCate(WebForAnalyse.Master.AdminMaster.CateType.BaZi3);
            #endregion
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                sysno = int.Parse(Request.QueryString["id"]);
            }
            if (!IsPostBack)
            {
                drpType.DataSource = AppEnum.GetBaZiLogicType();
                drpType.DataTextField = "value";
                drpType.DataValueField = "key";
                drpType.DataBind();
                drpType.Items.Insert(0, new ListItem("请选择", "-1"));

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    PrepareForm();
                }

                int total = 0;
                LogicList = RSH_BaziLogicBll.GetInstance().GetList(1000, 1, "", sysno, ref total);

                DataTable m_dt = new DataTable();
                m_dt.Columns.Add("id");
                for (int i = 0; i < 50; i++)
                {
                    DataRow m_dr = m_dt.NewRow();
                    m_dr["id"] = i;
                    m_dt.Rows.Add(m_dr);
                }
                Repeater1.DataSource = m_dt;
                Repeater1.DataBind();

                //this.ClientScript.RegisterStartupScript(this.GetType(), "", "show(0);", true);
            }
            string jsstr = "";
            for (int i = 0; i <= int.Parse(HiddenField1.Value); i++)
            {
                jsstr += "show(" + i + ");";
            }
            string[] tmpstrs = HiddenField2.Value.Substring(1).Split(new char[] { '|' });
            for (int i = 0; i < tmpstrs.Length; i++)
            {
                jsstr += "convert(" + tmpstrs[i] + ");";
            }
            ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "", jsstr, true);
        }

        protected void PrepareForm()
        {
            RSH_BaziLogicMod m_logic = RSH_BaziLogicBll.GetInstance().GetModel(sysno);
            txtTitle.Text = m_logic.Name;
            txtDesc.Text = m_logic.Description;
            drpType.SelectedIndex = drpType.Items.IndexOf(drpType.Items.FindByValue(m_logic.Type.ToString()));

            string[] logic = m_logic.Logic.Split(new char[] { '_' });
            ConditionList = RSH_BaziConditionBll.GetInstance().GetListByLogic(sysno);
            ConditionList.Columns.Add("sign1");
            ConditionList.Columns.Add("sign2");
            ConditionList.Columns.Add("sign");
            ConditionList.Columns.Add("logic");
            for (int i = 0; i < logic.Length/4; i++)
            {
                if (logic[4 * i + 1].Contains("#"))
                {
                    DataRow m_dr = ConditionList.NewRow();
                    ConditionList.Rows.InsertAt(m_dr, i);
                    ConditionList.Rows[i]["logic"] = logic[4 * i + 1].Replace("#","");
                }
                else
                {
                    ConditionList.Rows[i]["logic"] = "";
                }
                ConditionList.Rows[i]["sign1"] = logic[4 * i];
                ConditionList.Rows[i]["sign2"] = logic[4 * i + 2];
                ConditionList.Rows[i]["sign"] = logic[4 * i + 3];
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ltrResult.Text = "";
            if (txtDate.Text == "" || txtDate1.Text == "")
            {
                ltrNotice.Text = "请选择日期";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('noticediv').style.display='';closeforseconds();", true);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "show(0);", true);
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
                //this.ClientScript.RegisterStartupScript(this.GetType(), "", "show(0);", true);
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
                    ltrResult.Text += m_date.Date.ToString("yyyy-MM-dd HH:00:00 ") + "<br />";
                }
            }
            //this.ClientScript.RegisterStartupScript(this.GetType(), "", "show(0);", true);
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

            DropDownList drpLogic = (DropDownList)e.Item.FindControl("drpLogic");
            drpLogic.DataSource = LogicList;
            drpLogic.DataTextField = "Name";
            drpLogic.DataValueField = "SysNo";
            drpLogic.DataBind();
            drpLogic.Items.Insert(0, new ListItem("请选择", "-1"));

            if (sysno != AppConst.IntNull)
            {
                if (e.Item.ItemIndex >= ConditionList.Rows.Count)
                {
                    return;
                }
                HiddenField2.Value = "|";
                if (ConditionList.Rows[e.Item.ItemIndex]["logic"].ToString() == "")
                {
                    drpItem.SelectedIndex = drpItem.Items.IndexOf(drpItem.Items.FindByValue(ConditionList.Rows[e.Item.ItemIndex]["item"].ToString()));
                    drpType.SelectedIndex = drpType.Items.IndexOf(drpType.Items.FindByValue(ConditionList.Rows[e.Item.ItemIndex]["type"].ToString()));
                    drpType_SelectedIndexChanged(drpType, e);
                    drpTarget.SelectedIndex = drpTarget.Items.IndexOf(drpTarget.Items.FindByValue(ConditionList.Rows[e.Item.ItemIndex]["target"].ToString()));
                    DropDownList drpCondition = (DropDownList)e.Item.FindControl("drpCondition");
                    drpCondition.SelectedIndex = drpCondition.Items.IndexOf(drpCondition.Items.FindByValue(ConditionList.Rows[e.Item.ItemIndex]["Condition"].ToString()));
                    DropDownList drpNegative = (DropDownList)e.Item.FindControl("drpNegative");
                    drpNegative.SelectedIndex = drpNegative.Items.IndexOf(drpNegative.Items.FindByValue(ConditionList.Rows[e.Item.ItemIndex]["Negative"].ToString()));
                }
                else
                {
                    drpLogic.SelectedIndex = drpLogic.Items.IndexOf(drpLogic.Items.FindByValue(ConditionList.Rows[e.Item.ItemIndex]["logic"].ToString()));
                    HiddenField2.Value += e.Item.ItemIndex + "|";
                }
                DropDownList drpSign = (DropDownList)e.Item.FindControl("drpSign");
                drpSign.SelectedIndex = drpSign.Items.IndexOf(drpSign.Items.FindByValue(ConditionList.Rows[e.Item.ItemIndex]["sign"].ToString()));
                TextBox sign1 = (TextBox)e.Item.FindControl("txtSign1");
                sign1.Text = ConditionList.Rows[e.Item.ItemIndex]["sign1"].ToString();
                TextBox sign2 = (TextBox)e.Item.FindControl("txtSign2");
                sign2.Text = ConditionList.Rows[e.Item.ItemIndex]["sign2"].ToString();
                HiddenField1.Value = e.Item.ItemIndex.ToString();
                //this.ClientScript.RegisterStartupScript(this.GetType(), "convert", jsstr, true);
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 输入检查
            int count = 0;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemIndex > int.Parse(HiddenField1.Value))
                {
                    continue;
                }
                if (((TextBox)item.FindControl("txtSign1")).Text.Trim().Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "") != "")
                {
                    ltrError.Text = "输入框只可输入括号";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    return;
                }
                if (((TextBox)item.FindControl("txtSign2")).Text.Trim().Replace("(", "").Replace(")", "").Replace("（", "").Replace("）", "") != "")
                {
                    ltrError.Text = "输入框只可输入括号";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    return;
                }
                if (HiddenField2.Value.Contains("|" + item.ItemIndex + "|") && ((DropDownList)item.FindControl("drpLogic")).SelectedValue == "-1")
                {
                    ltrError.Text = "有逻辑选择框未选择";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    return;
                }
                if (!HiddenField2.Value.Contains("|" + item.ItemIndex + "|") && ((DropDownList)item.FindControl("drpItem")).SelectedValue == "-1")
                {
                    ltrError.Text = "有主语选择框未选择";
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                    return;
                }
                string tmpstr = ((TextBox)item.FindControl("txtSign1")).Text.Trim() + ((TextBox)item.FindControl("txtSign2")).Text.Trim();
                foreach (char c in tmpstr)
                {
                    if (c == '(' || c == '（')
                    {
                        count++;
                    }
                    if (c == ')' || c == '）')
                    {
                        count--;
                    }
                }
            }
            if (count != 0)
            {
                ltrError.Text = "括号开闭数量不对称";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }

            if (drpType.SelectedValue == "-1")
            {
                ltrError.Text = "请选择类型";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                ltrError.Text = "请输入标题";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            if (txtDesc.Text.Trim() == "")
            {
                ltrError.Text = "请输入注释";
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('errordiv').style.display='';closeforseconds();", true);
                return;
            }
            #endregion


            RSH_BaziLogicMod m_logic = new RSH_BaziLogicMod();
            if (sysno == AppConst.IntNull)
            {
                m_logic.Description = txtDesc.Text.Trim();
                m_logic.DR = (int)AppEnum.State.normal;
                m_logic.Name = txtTitle.Text.Trim();
                m_logic.Type = int.Parse(drpType.SelectedValue);
                m_logic.Logic = "";
                m_logic.SysNo = RSH_BaziLogicBll.GetInstance().Add(m_logic);
            }
            else
            {
                m_logic = RSH_BaziLogicBll.GetInstance().GetModel(sysno);
                m_logic.Description = txtDesc.Text.Trim();
                m_logic.DR = (int)AppEnum.State.normal;
                m_logic.Name = txtTitle.Text.Trim();
                m_logic.Type = int.Parse(drpType.SelectedValue);
                m_logic.Logic = "";
                RSH_BaziConditionBll.GetInstance().DeleteConditionsByLogic(sysno);
            }
            //List<RSH_BaziConditionMod> m_condtions = new List<RSH_BaziConditionMod>();
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemIndex>int.Parse(HiddenField1.Value))
                {
                    continue;
                }
                m_logic.Logic += ((TextBox)item.FindControl("txtSign1")).Text + "_";
                if (HiddenField2.Value.Contains("|" + item.ItemIndex+"|"))
                {
                    m_logic.Logic += "#" + ((DropDownList)item.FindControl("drpLogic")).SelectedValue + "_";
                }
                else if (((DropDownList)item.FindControl("drpItem")).Style["display"] != "none")
                {
                    RSH_BaziConditionMod tmp_c = new RSH_BaziConditionMod();
                    tmp_c.Item = int.Parse(((DropDownList)item.FindControl("drpItem")).SelectedValue);
                    tmp_c.LogicSysNo = m_logic.SysNo;
                    tmp_c.Type = int.Parse(((DropDownList)item.FindControl("drpType")).SelectedValue);
                    tmp_c.Condition = int.Parse(((DropDownList)item.FindControl("drpCondition")).SelectedValue);
                    tmp_c.Target = int.Parse(((DropDownList)item.FindControl("drpTarget")).SelectedValue);
                    tmp_c.Negative = int.Parse(((DropDownList)item.FindControl("drpNegative")).SelectedValue);

                    tmp_c.SysNo = RSH_BaziConditionBll.GetInstance().Add(tmp_c);
                    m_logic.Logic += "@" + tmp_c.SysNo + "_";
                }
                m_logic.Logic += ((TextBox)item.FindControl("txtSign2")).Text + "_";
                m_logic.Logic += ((DropDownList)item.FindControl("drpSign")).SelectedValue + "_";
            }
            m_logic.Logic = m_logic.Logic.Substring(0, m_logic.Logic.Length - 1);
            RSH_BaziLogicBll.GetInstance().Update(m_logic);


        }

        //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    DropDownList m_drp = (DropDownList)e.Item.FindControl("drpLogic");
        //    if (m_drp.Visible)
        //    {
        //        ((Button)e.Item.FindControl("Button2")).Text = "添加已有逻辑";
        //        m_drp.Visible = false;
        //        ((DropDownList)e.Item.FindControl("drpItem")).Visible = true;
        //        ((DropDownList)e.Item.FindControl("drpType")).Visible = true;
        //        ((DropDownList)e.Item.FindControl("drpCondition")).Visible = true;
        //        ((DropDownList)e.Item.FindControl("drpTarget")).Visible = true;
        //    }
        //    else
        //    {
        //        ((Button)e.Item.FindControl("Button2")).Text = "添加新条件";
        //        m_drp.Visible = true;
        //        ((DropDownList)e.Item.FindControl("drpItem")).Visible = false;
        //        ((DropDownList)e.Item.FindControl("drpType")).Visible = false;
        //        ((DropDownList)e.Item.FindControl("drpCondition")).Visible = false;
        //        ((DropDownList)e.Item.FindControl("drpTarget")).Visible = false;
        //    }
        //}

        /// <summary>
        /// 生成解释
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click1(object sender, EventArgs e)
        {

        }

        protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            //Repeater rpt = ddl.Parent.Parent.Parent as Repeater;
            //int n = ((RepeaterItem)ddl.Parent.Parent).ItemIndex;
            DropDownList ddl2 = ddl.Parent.FindControl("drpCondition") as DropDownList;
            switch (ddl.SelectedIndex)
            {
                case 1:
                    ddl2.DataSource = PublicValue.GetWuXingRelation();
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
                case 3:
                    ddl2.DataSource = PublicValue.GetWuXingShuXing();
                    ddl2.DataTextField = "value";
                    ddl2.DataValueField = "key";
                    ddl2.DataBind();
                    ddl2.Items.Insert(0, new ListItem("请选择", "-1"));
                    break;
            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LinkButton lbn = sender as LinkButton;
            DropDownList drpLogic = lbn.Parent.FindControl("drpLogic") as DropDownList;
            DropDownList drpItem = lbn.Parent.FindControl("drpItem") as DropDownList;
            DropDownList drpNegative = lbn.Parent.FindControl("drpNegative") as DropDownList;
            DropDownList drpType = lbn.Parent.FindControl("drpType") as DropDownList;
            DropDownList drpCondition = lbn.Parent.FindControl("drpCondition") as DropDownList;
            DropDownList drpTarget = lbn.Parent.FindControl("drpTarget") as DropDownList;
            if (drpLogic.Style["display"] == "none")
            {
                drpLogic.Style["display"] = "";
                drpItem.Style["display"] = "none";
                drpNegative.Style["display"] = "none";
                drpType.Style["display"] = "none";
                drpCondition.Style["display"] = "none";
                drpTarget.Style["display"] = "none";
            }
            else
            {
                drpLogic.Style["display"] = "none";
                drpItem.Style["display"] = "";
                drpNegative.Style["display"] = "";
                drpType.Style["display"] = "";
                drpCondition.Style["display"] = "";
                drpTarget.Style["display"] = "";
            }
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            LinkButton lbn = sender as LinkButton;
            Repeater rpt = lbn.Parent.Parent.Parent as Repeater;
            int n = ((RepeaterItem)lbn.Parent.Parent).ItemIndex;
            Label lbl = rpt.Items[n + 1].FindControl("p") as Label;
            if (lbn.Text == "+")
            {
                lbn.Text = "-";
                lbl.Style["display"] = "";
            }
            else
            {
                lbn.Text = "+";
                lbl.Style["display"] = "none";
            }
        }
    }
}