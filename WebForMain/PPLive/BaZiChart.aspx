<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="BaZiChart.aspx.cs" Inherits="WebForMain.PPLive.BaZiChart" %>

<%@ Register Src="../ControlLibrary/PPPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ PreviousPageType VirtualPath="~/PPLive/BaZi.aspx" %>
<%@ Register Src="../ControlLibrary/BaZiForQuest.ascx" TagName="BaZi" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="leftbox left">
            <h3>
                四柱八字排盘</h3>
            <div class="line_03">
            </div>
            <div class="block show pp">
            <uc1:BaZi ID="BaZi1" runat="server"></uc1:BaZi>
                <%--<div id="chartdiv" class="res" style="font-family: 宋体; font-size: 9pt;color: #3f3d3e;">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>--%>
                    <%--<a href="#" onclick="javascript:window.clipboardData.setData('text',document.getElementById('chartdiv').innerHTML);alert('星盘已经复制到剪贴板中');" class="btn_03">复制星盘</a>--%>
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
<script language="javascript" src="../WebResources/JS/addition.js" type="text/javascript"></script>
<script language="javascript" src="../WebResources/JS/comm.js" type="text/javascript"></script>

</asp:Content>
