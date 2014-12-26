<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Astro.aspx.cs" Inherits="WebForPPLive.PP.Astro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="drpType" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="drpTransit" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="drpCompose" runat="server">
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server" Text="阳历生日："></asp:Label>
                <asp:DropDownList ID="drpYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpYear_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="年"></asp:Label>
                <asp:DropDownList ID="drpMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpMonth_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Text="月"></asp:Label>
                <asp:DropDownList ID="drpDay" runat="server">
                </asp:DropDownList>
                <asp:Label ID="Label4" runat="server" Text="日"></asp:Label>
                <asp:DropDownList ID="drpHour" runat="server">
                </asp:DropDownList>
                <asp:Label ID="Label5" runat="server" Text="时"></asp:Label>
                <asp:DropDownList ID="drpMinute" runat="server">
                </asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Text="分"></asp:Label>
                &nbsp;&nbsp;<asp:CheckBox ID="chkDaylight" runat="server" Text="夏令时" />
                <br />
                <asp:DropDownList ID="drpDistrict1" runat="server" class="small-input" AutoPostBack="true"
                    OnSelectedIndexChanged="drpDistrict1_SelectedIndexChanged">
                </asp:DropDownList>
                <span>—</span><asp:DropDownList ID="drpDistrict2" runat="server" class="small-input"
                    OnSelectedIndexChanged="drpDistrict2_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <span>—</span><asp:DropDownList ID="drpDistrict3" runat="server" class="small-input"
                    OnSelectedIndexChanged="drpDistrict3_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblPosition" runat="server" CssClass="input-notification information png_bg"
                    Text="" Visible="false"></asp:Label><br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="Label7" runat="server" Text="星体显示："></asp:Label>
        <asp:CheckBoxList ID="chkStar" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="太阳" Value="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="月亮" Value="2" Selected="True"></asp:ListItem>
            <asp:ListItem Text="水星" Value="3" Selected="True"></asp:ListItem>
            <asp:ListItem Text="金星" Value="4" Selected="True"></asp:ListItem>
            <asp:ListItem Text="火星" Value="5" Selected="True"></asp:ListItem>
            <asp:ListItem Text="木星" Value="6" Selected="True"></asp:ListItem>
            <asp:ListItem Text="土星" Value="7" Selected="True"></asp:ListItem>
            <asp:ListItem Text="天王星" Value="8" Selected="True"></asp:ListItem>
            <asp:ListItem Text="海王星" Value="9" Selected="True"></asp:ListItem>
            <asp:ListItem Text="冥王星" Value="10" Selected="True"></asp:ListItem>
            <asp:ListItem Text="凯龙星" Value="11"></asp:ListItem>
            <asp:ListItem Text="谷神星" Value="12"></asp:ListItem>
            <asp:ListItem Text="智神星" Value="13"></asp:ListItem>
            <asp:ListItem Text="婚神星" Value="14"></asp:ListItem>
            <asp:ListItem Text="灶神星" Value="15"></asp:ListItem>
            <asp:ListItem Text="北交点" Value="16"></asp:ListItem>
            <asp:ListItem Text="南交点" Value="17"></asp:ListItem>
            <asp:ListItem Text="莉莉丝" Value="18"></asp:ListItem>
            <asp:ListItem Text="福点" Value="19"></asp:ListItem>
            <asp:ListItem Text="宿命点" Value="20"></asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:Label ID="Label8" runat="server" Text="分宫："></asp:Label>
        <asp:DropDownList ID="drpSOH" runat="server">
            <asp:ListItem Text="Placidus" Value="0" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Koch" Value="1"></asp:ListItem>
            <asp:ListItem Text="Equal" Value="2"></asp:ListItem>
            <asp:ListItem Text="Campanus" Value="3"></asp:ListItem>
            <asp:ListItem Text="Meridian" Value="4"></asp:ListItem>
            <asp:ListItem Text="Regiomontanus" Value="5"></asp:ListItem>
            <asp:ListItem Text="Porphyry" Value="6"></asp:ListItem>
            <asp:ListItem Text="Morinus" Value="7"></asp:ListItem>
            <asp:ListItem Text="Topocentric" Value="8"></asp:ListItem>
            <asp:ListItem Text="Alcabitius" Value="9"></asp:ListItem>
            <asp:ListItem Text="Equal (MC)" Value="10"></asp:ListItem>
            <asp:ListItem Text="Neo-Porphyry" Value="11"></asp:ListItem>
            <asp:ListItem Text="Whole" Value="12"></asp:ListItem>
            <asp:ListItem Text="Vedic" Value="13"></asp:ListItem>
            <asp:ListItem Text="None" Value="14"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label9" runat="server" Text="容许度："></asp:Label><br />
        <asp:CheckBox ID="chkAspect1" runat="server" Text="合相（0°）" Checked="true" />
        <asp:TextBox ID="txtAspect1" runat="server" Text="10.0"></asp:TextBox><br />
        <asp:CheckBox ID="chkAspect2" runat="server" Text="冲相（180°）" Checked="true" />
        <asp:TextBox ID="txtAspect2" runat="server" Text="8.0"></asp:TextBox><br />
        <asp:CheckBox ID="chkAspect3" runat="server" Text="拱相（120°）" Checked="true" />
        <asp:TextBox ID="txtAspect3" runat="server" Text="8.0"></asp:TextBox><br />
        <asp:CheckBox ID="chkAspect4" runat="server" Text="刑相（90°）" Checked="true" />
        <asp:TextBox ID="txtAspect4" runat="server" Text="8.0"></asp:TextBox><br />
        <asp:CheckBox ID="chkAspect5" runat="server" Text="六分相（60°）" Checked="true" />
        <asp:TextBox ID="txtAspect5" runat="server" Text="5.0"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="排盘" OnClick="Unnamed10_Click" />
        <br />
        <asp:Image ID="Image1" runat="server" Visible="false" />
    </div>
    </form>
</body>
</html>
