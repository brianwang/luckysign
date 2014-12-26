<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistrictPicker.ascx.cs"
    Inherits="WebForApps.ControlLibrary.DistrictPicker" %>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:DropDownList ID="drpDistrict1" runat="server" AutoPostBack="true" CssClass="sel_0"
                OnSelectedIndexChanged="drpDistrict1_SelectedIndexChanged">
            </asp:DropDownList></td>
        <td>-</td>
        <td>
            <asp:DropDownList ID="drpDistrict2" runat="server" CssClass="sel_0" OnSelectedIndexChanged="drpDistrict2_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList></td>
        <td>-</td>
        <td>
            <asp:DropDownList ID="drpDistrict3" runat="server" CssClass="sel_0" OnSelectedIndexChanged="drpDistrict3_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td colspan="5" align="left">
            <asp:CheckBox ID="chkChina" runat="server" Text="仅显示中国地区" AutoPostBack="true" Checked="true"
                OnCheckedChanged="Unnamed1_CheckedChanged" />
            <asp:Literal ID="ltrLatLng" runat="server"></asp:Literal>
        </td>
    </tr>
</table>







