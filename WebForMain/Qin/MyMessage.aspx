<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MyMessage.aspx.cs" Inherits="WebForMain.Qin.MyMessage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/QinRightPannel.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的私信-上上签</title>
        <style type="text/css">
        .popup {
            filter: alpha(opacity=20);
			 -moz-opacity:0.2;
			 opacity:0.2;
            background-color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="height20">
    </div>
    <div class="page_left">
        <div class="page_con_item">
            <div class="page_submit">
                <asp:LinkButton ID="LinkButton1" runat="server">发消息</asp:LinkButton></div>
            <ul>
                <%--<li><a href="MyComment.aspx">评论</a></li>--%>
                <li><a href="MyNotice.aspx">系统消息</a></li>
                <li class="on"><a href="MyMessage.aspx">私信</a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="height20">
        </div>
        <asp:Repeater ID="rptMsg" runat="server">
            <ItemTemplate>
                <div class="page_box">
                    <%# Eval("msgcontent") %>
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
            </uc1:Search>
        </div>
        <div class="height20">
        </div>
        <div class="page_right_box">
            <uc1:RightPannel ID="RightPannel1" runat="server"></uc1:RightPannel>
        </div>
    </div>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="popup" TargetControlID="LinkButton1" CancelControlID="Button6"  PopupControlID="Panel1"  BehaviorID="Panel1" runat="server"></asp:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" Style="display: none;">
        <div class="mr_left_name">
            <asp:Literal ID="ltrInfo" runat="server"></asp:Literal></div>
        <div class="setting_box">
            <ul class="setting_ul">
                <li><span>收件人：</span><div class="setting_r">
                    <div>
                        <asp:TextBox ID="txtName" runat="server" CssClass="setting_input" Width="208px"></asp:TextBox>
                    </div>
                    <h1></h1>
                </div>
                    <div class="clear"></div>
                </li>
                <li><span>&nbsp;</span>
                    <div class="setting_r">
                        <asp:Button ID="Button5" runat="server" CssClass="setting_button1" OnClick="Button5_Click" Text="确定" />
                        <asp:Button ID="Button6" runat="server" CssClass="setting_button2" Text="取消" />
                    </div>
                    <div class="clear"></div>
                </li>
            </ul>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
