<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MyNotice.aspx.cs" Inherits="WebForMain.Qin.MyNotice" %>
    <%@ Register Src="../ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/QinRightPannel.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>系统消息-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="height20">
    </div>
    <div class="page_left">
        <div class="page_con_item">
            <%--<div class="page_submit">
                <a href="#">发消息</a></div>--%>
            <ul>
                <%--<li><a href="MyComment.aspx">• 评论</a></li>--%>
                <li class="on"><a href="MyNotice.aspx">• 系统消息</a></li>
                <li><a href="MyMessage.aspx">• 私信</a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="height20">
        </div>
        <asp:Repeater ID="rptMsg" runat="server">
        <ItemTemplate>
        <div class="page_box">
            <div class="page_box_l">
                <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/man2.jpg" /></div>
            <div class="page_box_r">
                <div class="page_corner">
                </div>
                <div class="page_box_all">
                    <div class="page_person_name">
                         <%# Eval("Title")%>  <%# DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd HH:mm")%></div>
                    <div class="page_person_yanz">
                        <%# Eval("Context")%>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        </ItemTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
        <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
    </div>
    <div class="page_right">
        <div class="page_person_search" style="margin: 0; padding: 0">
            <uc1:Search ID="Search1" runat="server">
            </uc1:Search></div>
        <div class="height20">
        </div>
        <div class="page_right_box">
            <uc1:RightPannel ID="RightPannel1" runat="server"></uc1:RightPannel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
