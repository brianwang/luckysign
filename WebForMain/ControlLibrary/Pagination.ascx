<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagination.ascx.cs"
    Inherits="WebForMain.ControlLibrary.Pagination" %>
<div class="pages">
    <asp:Literal ID="ltrpre" runat="server"></asp:Literal>
    <asp:Literal ID="ltrnum" runat="server"></asp:Literal>
    <asp:Literal ID="ltrnext" runat="server"></asp:Literal>
</div>
<div class="line_02">
</div>
<p class="ps">
    <strong>共<%=totalrecord%>条 当前页
        <%=index%>/<%=total%></strong></p>
