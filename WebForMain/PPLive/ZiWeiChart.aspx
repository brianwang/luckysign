<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="ZiWeiChart.aspx.cs" Inherits="WebForMain.PPLive.ZiWeiChart" %>

<%@ Register Src="../ControlLibrary/PPPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ PreviousPageType VirtualPath="~/PPLive/ZiWei.aspx" %>
<%@ Register Src="../ControlLibrary/ZiWeiForQuest.ascx" TagName="ZiWei" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>紫薇斗数排盘-在线排盘-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="leftbox left">
            <h3>
                紫微斗数排盘</h3>
            <div class="line_03">
            </div>
            <div class="block show pp">
                <uc1:ZiWei ID="ZiWei1" runat="server"></uc1:ZiWei>
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div id="chartdiv" class="res" style="font-family: 宋体; color: #3f3d3e; border-bottom: 1px;
                            border-left: 1px; padding-bottom: 2px; line-height: 13px; padding-left: 2px;
                            padding-right: 2px; font-size: 9pt; border-top: 1px; border-right: 1px; padding-top: 2px;">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
        <div class="rightbox left">
            <uc1:RightPanel ID="Panel1" runat="server"></uc1:RightPanel>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <%--<script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>--%>
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>
</asp:Content>
