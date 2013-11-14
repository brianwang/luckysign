<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistrictPicker.ascx.cs"
    Inherits="WebForApps.ControlLibrary.DistrictPicker" %>
<asp:DropDownList ID="drpDistrict1" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="drpDistrict1_SelectedIndexChanged">
</asp:DropDownList>
国家
<asp:DropDownList ID="drpDistrict2" runat="server" OnSelectedIndexChanged="drpDistrict2_SelectedIndexChanged" AutoPostBack="true">
</asp:DropDownList>
省
<asp:DropDownList ID="drpDistrict3" runat="server" OnSelectedIndexChanged="drpDistrict3_SelectedIndexChanged" AutoPostBack="true">
</asp:DropDownList>
市
<asp:CheckBox ID="CheckBox1" runat="server" Text="仅显示中国地区" AutoPostBack="true" Checked="true"
    oncheckedchanged="Unnamed1_CheckedChanged" />
<asp:Literal ID="ltrLatLng" runat="server"></asp:Literal>