<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiWei.aspx.cs" Inherits="WebForPPLive.PP.ZiWei" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label runat="server" Text="阳历生日："></asp:Label>
                <asp:DropDownList ID="drpYear" runat="server" AutoPostBack="true"
                    onselectedindexchanged="drpYear_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label runat="server" Text="年"></asp:Label>
                <asp:DropDownList ID="drpMonth" runat="server" AutoPostBack="true"
                    onselectedindexchanged="drpMonth_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label runat="server" Text="月"></asp:Label>
                <asp:DropDownList ID="drpDay" runat="server">
                </asp:DropDownList>
                <asp:Label runat="server" Text="日"></asp:Label>
                <asp:DropDownList ID="drpHour" runat="server">
                </asp:DropDownList>
                <asp:Label runat="server" Text="时"></asp:Label>
                <asp:DropDownList ID="drpMinute" runat="server">
                </asp:DropDownList>
                <asp:Label runat="server" Text="分"></asp:Label>
                <br />
                <asp:Label runat="server" Text="性别："></asp:Label>
                <asp:DropDownList ID="drpGender" runat="server">
                    <asp:ListItem Text="男" Value="1"></asp:ListItem>
                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label runat="server" Text="类别："></asp:Label>
                <asp:DropDownList ID="drpType" runat="server">
                    <asp:ListItem Text="天盘" Value="1"></asp:ListItem>
                    <asp:ListItem Text="流限盘" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label runat="server" Text="推运时间："></asp:Label>
                <asp:DropDownList ID="drpLiuYear" runat="server" AutoPostBack="true"
                    onselectedindexchanged="drpLiuYear_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label runat="server" Text="年"></asp:Label>
                <asp:DropDownList ID="drpLiuMonth" runat="server" AutoPostBack="true"
                    onselectedindexchanged="drpLiuMonth_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label runat="server" Text="月"></asp:Label>
                <asp:DropDownList ID="drpLiuDay" runat="server">
                </asp:DropDownList>
                <asp:Label runat="server" Text="日"></asp:Label>
                <br />
                <asp:Button runat="server" Text="排盘" onclick="Unnamed10_Click" />
                <br />
                <div align="center" style="font-family:宋体; color:#666666; border-bottom: 1px; border-left: 1px; padding-bottom: 2px; line-height: 14px; padding-left: 2px; padding-right: 2px; font-size: 9pt; border-top: 1px; border-right: 1px; padding-top: 2px;">
                <asp:Literal ID="ltrPan" runat="server"></asp:Literal></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
