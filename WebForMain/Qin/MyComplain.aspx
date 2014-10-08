<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MyComplain.aspx.cs" Inherits="WebForMain.Qin.MyComplain" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/QinAccountRight.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的投诉-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="height20"></div>

    <div class="page_left">

        <div class="setting_box" style="margin-top: 0">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="index_left_new_list">
                        <div class="pay_140218">
                            <div class="pay_140218_t" style="margin-top: 10px">投诉申请</div>
                            <div class="pay_140218_content">
                                报价单号：<span class="c"><samp><asp:Literal ID="Literal1" runat="server"></asp:Literal></samp></span><br />
                                问题名称：<span class="c"><samp><asp:Literal ID="Literal2" runat="server"></asp:Literal></samp></span><br />
                                回答者：<span class="c"><asp:Image ID="Image1" runat="server" /><br />
                                    <samp>
                                        <asp:Literal ID="Literal3" runat="server"></asp:Literal></samp></span><br />
                                投诉原因：<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><span id="ReasonTip" runat="server"></span><br />
                                退款金额：<asp:TextBox ID="TextBox1" Text="0" runat="server"></asp:TextBox><span id="AmountTip" runat="server">如需退款请输入金额</span><br />
                                详情说明：<FTB:FreeTextBox ID="txtContext" runat="Server" EnableHtmlMode="false" EnableToolbars="false" DesignModeCss="tarea" Width="360px" Height="200px" />
                                <br />
                            </div>
                        </div>
                        <div class="clear"></div>

                        <div class="pay_140218_btn">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">提交</asp:LinkButton>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="account_table">
                        <div class="account_table_t"><span>投诉记录</span></div>
                        <div class="account_table_c">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>投诉编号</td>
                                    <td>报价单号</td>
                                    <td>被投诉方</td>
                                    <td>投诉原因</td>
                                    <td>状态</td>
                                    <td>操作</td>
                                </tr>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("OrderID")%></td>
                                            <td><%# Eval("PayTime")==null||Eval("PayTime").ToString()==""? "" : DateTime.Parse(Eval("PayTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                            <td><a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Consult/<%#Eval("productsysno")%>" target="_blank"><%# Eval("content")%></a></td>
                                            <td><%# Eval("target")%></td>
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
            </asp:MultiView>

        </div>

    </div>

    <div class="page_right" style="width: 242px;">
        <uc1:RightPannel ID="RightPannel1" runat="server"></uc1:RightPannel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
