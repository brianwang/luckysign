using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBll.WebSys;
using AppMod.WebSys;

namespace WebForApps.ControlLibrary
{
    public partial class DistrictPicker : System.Web.UI.UserControl
    {
        private SYS_DistrictMod m_area = new SYS_DistrictMod();
        private bool onlychina = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (onlychina)
                {
                    drpDistrict1.DataSource = SYS_DistrictBll.GetInstance().GetFirstLevel(1);
                }
                else
                {
                    drpDistrict1.DataSource = SYS_DistrictBll.GetInstance().GetFirstLevel(0);
                }
                drpDistrict1.DataTextField = "Name";
                drpDistrict1.DataValueField = "SysNo";
                drpDistrict1.DataBind();
                //drpDistrict1.Items.Insert(0, new ListItem("请选择", "0"));
                drpDistrict1.SelectedIndex = drpDistrict1.Items.IndexOf(drpDistrict1.Items.FindByValue("1"));
                drpDistrict1_SelectedIndexChanged(sender, e);
                drpDistrict2.SelectedIndex = drpDistrict2.Items.IndexOf(drpDistrict2.Items.FindByValue("45052"));
                drpDistrict2_SelectedIndexChanged(sender, e);
                drpDistrict3.SelectedIndex = drpDistrict3.Items.IndexOf(drpDistrict3.Items.FindByValue("37"));
                drpDistrict3_SelectedIndexChanged(sender, e);
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
                if (drpDistrict2.Items.Count > 0)
                {
                    drpDistrict2.SelectedIndex = 0;
                    drpDistrict2_SelectedIndexChanged(sender, e);
                    if (drpDistrict3.Items.Count > 0)
                    {
                        drpDistrict3.SelectedIndex = 0;
                        drpDistrict3_SelectedIndexChanged(sender, e);
                    }
                }
                //drpDistrict2.Items.Insert(0, new ListItem("请选择", "0"));
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
                if (drpDistrict3.Items.Count > 0)
                {
                    drpDistrict3.SelectedIndex = 0;
                    drpDistrict3_SelectedIndexChanged(sender, e);
                }
                //drpDistrict3.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }

        protected void drpDistrict3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDistrict3.SelectedValue != "0")
            {
                m_area = SYS_DistrictBll.GetInstance().GetModel(int.Parse(drpDistrict3.SelectedValue));
                ltrLatLng.Text = "<br />北纬" + m_area.Latitude + "　东经" + m_area.longitude;
                ltrLatLng.Visible = true;
            }
        }

        public int Area1SysNo
        {
            get { return int.Parse(drpDistrict1.SelectedValue); }
        }
        public int Area2SysNo
        {
            get { return int.Parse(drpDistrict2.SelectedValue); }
        }
        public int Area3SysNo
        {
            get { return int.Parse(drpDistrict3.SelectedValue); }
        }

        public string Area1Name
        {
            get { return drpDistrict1.SelectedItem.Text; }
        }
        public string Area2Name
        {
            get { return drpDistrict2.SelectedItem.Text; }
        }
        public string Area3Name
        {
            get { return drpDistrict3.SelectedItem.Text; }
        }

        /// <summary>
        /// 经度
        /// </summary>
        public string lng
        {
            get { return m_area.longitude; }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        public string lat
        {
            get { return m_area.Latitude; }
        }

        protected void Unnamed1_CheckedChanged(object sender, EventArgs e)
        {
            onlychina = ((CheckBox)sender).Checked;
            Page_Load(sender, e);
        }
    }
}