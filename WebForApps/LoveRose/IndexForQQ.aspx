<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexForQQ.aspx.cs" Inherits="WebForApps.LoveRose.IndexForQQ" %>
<%@ Register Src="../ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../WebResources/JS/swfobject.js" type="text/javascript"></script>
</head>
<body style="background-color:Black;">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanela" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <span class="fred">*</span><strong>阳历生日：</strong>
                <uc1:datepicker id="DatePicker1" runat="server" Type="3"></uc1:datepicker>
               <%-- <asp:CheckBox ID="chkDaylight1" runat="server" />
                <span class="fsred"><strong>夏令时</strong></span>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <span class="fred">*</span><strong>出生地点：</strong>
                <uc1:district id="District1" runat="server"></uc1:district>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ImageButton runat="server" ID="ImageButton1" onclick="Unnamed1_Click" />
        <br /><br />
        <div id="flashmov" align="center">
            <asp:Literal ID="Label1" runat="server"></asp:Literal></div>
    </div>
    </form>
    
</body>
</html>
