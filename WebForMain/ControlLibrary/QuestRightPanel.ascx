<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestRightPanel.ascx.cs" Inherits="WebForMain.ControlLibrary.QuestRightPanel" %>

<asp:Repeater ID="rptCateMain" runat="server" OnItemDataBound="rptCateMain_ItemDataBound">
    <ItemTemplate>
        <div class="new_right_t"><%#Eval("Name")%></div>
        <div class="new_right_c">
            <ul>
                <asp:Repeater ID="rptCateSub" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="new_right_l">
                                <img src="../WebResources/img/new/ico<%#Eval("SysNo")%>.gif" align="absmiddle" />
                            </div>
                            <div class="new_right_r">
                                <a href="../Quest/Index.aspx?cate=<%#Eval("SysNo")%>"><%#Eval("Name")%> （<%#Eval("Replys")%>）<br />
                                    <span style="font-size:12px">问题数：<%#Eval("QuestNum")%>    已解决：<%#Eval("SolvedNum")%></span></a>
                            </div>
                            <div class="clear"></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </ItemTemplate>
</asp:Repeater>

