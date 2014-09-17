<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MyAccount.aspx.cs" Inherits="WebForMain.Qin.MyAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/ComboShow.ascx" TagName="ComboShow" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/QinAccountRight.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的账户-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="height20"></div>

    <div class="page_left">

        <div class="setting_box" style="margin-top: 0">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="account_yue"><a href="#">充值</a>灵签余额：<asp:Literal ID="ltrPoint" runat="server"></asp:Literal></div>
                    <div class="clear"></div>
                    <div class="account_table">
                        <div class="account_table_t"><span>灵签账户收支记录</span></div>
                        <div class="account_table_c">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>交易单号</td>
                                    <td>消费时间</td>
                                    <td>内容</td>
                                    <td>灵签数</td>
                                    <td>交易状态</td>
                                    <td>操作</td>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("OrderID")%></td>
                                            <td><%# DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                            <td><%# Eval("content")%></td>
                                            <td><%# Eval("point")%>灵签</td>
                                            <td><%# AppCmn.AppEnum.GetPointOrderStatus(int.Parse(Eval("status").ToString()))%></td>
                                            <td>——</td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>
                            <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="account_yue"><a href="#">提现</a>账户余额：<asp:Literal ID="ltrCash" runat="server"></asp:Literal></div>
                    <div class="clear"></div>
                    <div class="account_table">
                        <div class="account_table_t"><span>现金账户收支记录</span></div>
                        <div class="account_table_c">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>交易单号</td>
                                    <td>交易时间</td>
                                    <td>内容</td>
                                    <td>对方</td>
                                    <td>金额</td>
                                    <td>交易状态</td>
                                    <td>操作</td>
                                </tr>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("OrderID")%></td>
                                            <td><%# Eval("PayTime")==null||Eval("PayTime").ToString()==""? "" : DateTime.Parse(Eval("PayTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                            <td><a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Consult/<%#Eval("productsysno")%>" target="_blank"><%# Eval("content")%></a></td>
                                            <td><%# Eval("target")%></td>
                                            <td>￥<%# Eval("PayAmount")%></td>
                                            <td><%# AppCmn.AppEnum.GetPointOrderStatus(int.Parse(Eval("status").ToString()))%></td>
                                            <td>——</td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>
                            <uc1:Pager ID="Pager2" runat="server"></uc1:Pager>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>

        </div>

    </div>

    <div class="page_right" style="width: 242px;">
        <uc1:RightPannel ID="RightPannel1" runat="server"></uc1:RightPannel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
