<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs"
    Inherits="WebForApps.ControlLibrary.DatePicker" %>
<asp:DropDownList ID="drpYear" runat="server" CssClass="sel_2" AutoPostBack="true" OnSelectedIndexChanged="drpYear_SelectedIndexChanged">
</asp:DropDownList>
年
<asp:DropDownList ID="drpMonth" runat="server" CssClass="sel_2" AutoPostBack="true" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged">
</asp:DropDownList>
月
<asp:DropDownList ID="drpDay" runat="server" CssClass="sel_2">
</asp:DropDownList>
日
<asp:DropDownList ID="drpHour" runat="server" CssClass="sel_2" style="display:none;">
</asp:DropDownList>
<asp:Literal ID="shi" runat="server" Text=""></asp:Literal>
<asp:DropDownList ID="drpMinute" runat="server" CssClass="sel_2"  style="display:none;">
</asp:DropDownList>
<asp:Literal ID="fen" runat="server" Text=""></asp:Literal>
<asp:DropDownList ID="drpSecond" runat="server" CssClass="sel_2"  style="display:none;">
</asp:DropDownList>
<asp:Literal ID="miao" runat="server" Text=""></asp:Literal>