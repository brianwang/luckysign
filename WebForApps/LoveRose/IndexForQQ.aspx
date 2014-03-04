<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexForQQ.aspx.cs" Inherits="WebForApps.LoveRose.IndexForQQ" %>

<%@ Register Src="../ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>爱情花</title>
    <link href="css/login.css" type="text/css" rel="stylesheet">
    <script src="../WebResources/JS/swfobject.js" type="text/javascript"></script>
</head>
<body style="">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <div class="login-box">
                                <div class="login-list">
                                    <ul>
                                        <li>
                                            <div class="select">1993<img src="img/arrow.gif" align="absmiddle"></div>
                                            <div class="select">12<img src="img/arrow.gif" align="absmiddle"></div>
                                            <div class="select">12<img src="img/arrow.gif" align="absmiddle"></div>
                                            <div class="select">12<img src="img/arrow.gif" align="absmiddle"></div>
                                            <div class="select">12<img src="img/arrow.gif" align="absmiddle"></div>
                                        </li>
                                        <li style="padding-left: 50px">
                                            <div class="select">新疆<img src="img/arrow.gif" align="absmiddle"></div>
                                            <div class="select">乌鲁木齐<img src="img/arrow.gif" align="absmiddle"></div>
                                        </li>
                                        <li style="padding-left: 110px">
                                            <div class="select">自动判断<img src="img/arrow.gif" align="absmiddle"></div>
                                        </li>
                                    </ul>
                                </div>
                                <div class="login-button">
                                    <a href="#"></a>
                                </div>
                            </div>

                        </asp:View>
                        <asp:View ID="View2" runat="server">
                        </asp:View>
                    </asp:MultiView>

                    <asp:UpdatePanel ID="UpdatePanela" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <span class="fred">*</span><strong>阳历生日：</strong>
                            <uc1:DatePicker ID="DatePicker1" runat="server" Type="3"></uc1:DatePicker>
                            <%-- <asp:CheckBox ID="chkDaylight1" runat="server" />
                <span class="fsred"><strong>夏令时</strong></span>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <span class="fred">*</span><strong>出生地点：</strong>
                            <uc1:District ID="District1" runat="server"></uc1:District>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:ImageButton runat="server" ID="ImageButton1" OnClick="Unnamed1_Click" />

                    <asp:Button ID="Button1" runat="server" Text="统计" OnClick="Button1_Click" />

                    <br />
                    <br />
                    <div id="flashmov" align="center">

                        <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                        <asp:Literal ID="Label1" runat="server"></asp:Literal>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>



    </form>

</body>
</html>
