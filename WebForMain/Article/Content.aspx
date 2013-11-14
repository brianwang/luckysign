<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="Content.aspx.cs" Inherits="WebForMain.Article.Content" %>

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
            <h2>
                象牙塔</h2>
            <asp:Repeater ID="rptCateMain" runat="server" OnItemDataBound="rptCateMain_ItemDataBound">
                <ItemTemplate>
                    <div class="sidebox">
                        <div class="side_t">
                            <%#Eval("Name")%></div>
                        <ul>
                            <asp:Repeater ID="rptCateSub" runat="server">
                                <ItemTemplate>
                                    <li class="icon<%#Eval("SysNo")%>"><a href='Index.aspx?cate=<%#Eval("SysNo")%>' title='<%#Eval("Name")%>'>
                                        <%#Eval("Name")%></a></li></ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="clear">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="side_banner">
                <a href="#" target="_blank">
                    <img src="../WebResources/IMAGES/banner_01.jpg" width="242" height="191" /></a>
            </div>
            <div class="tabs tabs2">
                <a href="javascript:void(0)" title="最新" class="on">最新</a> <a href="javascript:void(0)"
                    title="推荐">推荐</a> <a href="javascript:void(0)" title="热门">热门</a>
            </div>
            <div class="block show">
                <asp:Repeater ID="rptNew" runat="server">
                    <ItemTemplate>
                        <div class="side_b">
                            <h4>
                                <a href="Content.aspx?id=<%#Eval("SysNo")%>" title="<%#Eval("title")%>">
                                    <%#Eval("title")%></a></h4>
                            <a href="Content.aspx?id=<%#Eval("SysNo")%>">
                                <%#Eval("Description")%></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="block">
                <asp:Repeater ID="rptGood" runat="server">
                    <ItemTemplate>
                        <div class="side_b">
                            <h4>
                                <a href="Content.aspx?id=<%#Eval("SysNo")%>" title="<%#Eval("title")%>">
                                    <%#Eval("title")%></a></h4>
                            <a href="Content.aspx?id=<%#Eval("SysNo")%>">
                                <%#Eval("Description")%></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="block">
                <asp:Repeater ID="rptHot" runat="server">
                    <ItemTemplate>
                        <div class="side_b">
                            <h4>
                                <a href="Content.aspx?id=<%#Eval("SysNo")%>" title="<%#Eval("title")%>">
                                    <%#Eval("title")%></a></h4>
                            <a href="Content.aspx?id=<%#Eval("SysNo")%>">
                                <%#Eval("Description")%></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
<script language="javascript" src="../WebResources/JS/comm.js" type="text/javascript"></script>
</asp:Content>
