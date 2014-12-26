<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="Content.aspx.cs" Inherits="WebForMain.Article.Content" %>
<%@ Register Src="~/ControlLibrary/ArticleRightPanel.ascx" TagName="Right" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="leftbox left">
            <h3 class="left">
                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></h3>
            <asp:HyperLink ID="lnkPreTop" CssClass="btn_04 btn_03" runat="server">上一篇</asp:HyperLink><asp:HyperLink
                ID="lnkAftTop" CssClass="btn_04 btn_03" runat="server">下一篇</asp:HyperLink><asp:HyperLink
                    ID="lnkReturn" CssClass="btn_04 btn_03" runat="server">返回</asp:HyperLink>
            <div class="clear">
            </div>
            <div class="line_03">
            </div>
            <div class="block show pp">
                <asp:Repeater runat="server">
                    <HeaderTemplate>
                        <div class="spans">
                    </HeaderTemplate>
                    <FooterTemplate>
                        </div></FooterTemplate>
                    <ItemTemplate>
                        <span class="sp_<%#Eval("Color")%>">
                            <%#Eval("KeyWord")%></span>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="conts">
                    <asp:Literal ID="ltrContent" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="plinks">
                <asp:HyperLink ID="lnkPreBtm" runat="server">
                    <asp:Literal ID="ltrPre" runat="server"></asp:Literal><%--<strong>上一篇：</strong>婚身星--%></asp:HyperLink>
                <asp:HyperLink ID="lnkAftBtm" runat="server">
                    <asp:Literal ID="ltrAft" runat="server"></asp:Literal><%--<strong>下一篇：</strong>婚身星--%></asp:HyperLink></div>
        </div>
        <div class="rightbox left">
            <uc1:Right ID="Right1" runat="server"></uc1:Right>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
<script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>
</asp:Content>
