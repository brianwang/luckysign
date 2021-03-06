﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MyComment.aspx.cs" Inherits="WebForMain.Qin.MyComment" %>
<%@ Register Src="~/ControlLibrary/QinRightPannel.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的评论-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="height20">
    </div>
    <div class="page_left">
        <div class="page_con_item">
            <%--<div class="page_submit">
                <a href="#">发消息</a></div>--%>
            <ul>
                <li class="on"><a href="MyComment.aspx">• 评论</a></li>
                <li><a href="MyNotice.aspx">• 系统消息</a></li>
                <li><a href="MyMessage.aspx">• 私信</a>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="height20">
        </div>
        <asp:Repeater ID="rptComm" runat="server" OnItemCommand="rptComm_ItemCommand">
            <ItemTemplate>
                <div class="page_box">
                    <div class="page_box_l">
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/index_pic.jpg" /></div>
                    <div class="page_box_r">
                        <div class="page_corner">
                        </div>
                        <div class="page_box_all">
                            <div class="page_person_name">
                                <a href="View/<%# Eval("CustomerSysNo") %>">
                                    <%# Eval("NickName")%></a><%# DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd HH:mm")%></div>
                            <div class="page_person_discuss">
                                <span>评论我的轻博客</span><a href="#"><%# AppCmn.CommonTools.CutStr(Eval("articletitle").ToString(), 20)%></a><br />
                                <%# Eval("Context")%><a href='javascript:document.getElementByID(replaydiv<%# Container.ItemIndex %>).style.display="";'>回复</a>
                            </div>
                            <div id='replaydiv<%# Container.ItemIndex %>' class="page_person_discuss_input" style="display: none;">
                                <asp:TextBox ID="txtReply" runat="server"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" Text="发表" CommandArgument='<%# Eval("SysNo") %>' CommandName="Reply" />
                                <div class="clear">
                                </div>
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
        <uc1:Pager ID="Pager1" runat="server">
        </uc1:Pager>
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
