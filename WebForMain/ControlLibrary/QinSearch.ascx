<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QinSearch.ascx.cs" Inherits="WebForMain.ControlLibrary.QinSearch" %>
<asp:TextBox ID="txtSearch" runat="server" Text="寻找你感兴趣的内容"></asp:TextBox>
<button onclick="document.getElementById('<%=btmSearch.ClientID %>').click();">
    GO</button><asp:Button ID="btmSearch" runat="server" Style="display: none;" Text=""
        OnClick="btmSearch_Click" />