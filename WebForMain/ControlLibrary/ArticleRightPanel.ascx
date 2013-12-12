<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleRightPanel.ascx.cs" Inherits="WebForMain.ControlLibrary.ArticleRightPanel" %>
<div class="new_right_item">象牙塔</div>
<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
    <ItemTemplate>
        <div class="new_right_t"><%#Eval("Name")%></div>
        <div class="new_right_menu">
            <ul>
                <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                    <ItemTemplate>
                        <li id="li<%#Eval("SysNo")%>" class="<%#Eval("currect")%>">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/new/icon<%#Eval("SysNo")%>.gif" align="absmiddle" /><a href="javascript:void(0);" onclick='showsub(this);'><%#Eval("Name")%></a></li>
                        <div id="sub<%#Eval("SysNo")%>" style="display:none;" class="new_right_submenu">
                            <asp:Repeater ID="Repeater3" runat="server">
                                <ItemTemplate>
                                    <a style='<%#Eval("currect")%>' href='../Article/Index.aspx?cate=<%#Eval("SysNo")%>'><%#Eval("Name")%></a>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="clear"></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </ItemTemplate>
</asp:Repeater>
<script type="text/javascript">
    function showsub(input)
    {
        $(input).parent().parent().children(".new_right_submenu").css("display", "none");
        document.getElementById($(input).parent().attr('id').replace('li', 'sub')).style.display = "";
    }

</script>

