<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ConsultOrder.aspx.cs" Inherits="WebForMain.Order.ConsultOrder" %>
<%@ Register Src="~/ControlLibrary/PayPannel.ascx" TagName="PayPannel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br />
    订单编号：<%=orderid %>
    支付金额：<%=price %>
    <uc1:PayPannel ID="PayPannel1" runat="server"></uc1:PayPannel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
