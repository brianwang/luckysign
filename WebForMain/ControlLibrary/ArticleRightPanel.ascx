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
                        <div id="sub<%#Eval("SysNo")%>" style="display: none;" class="new_right_submenu">
                            <asp:Repeater ID="Repeater3" runat="server">
                                <ItemTemplate>
                                    <a style='<%#Eval("currect")%>' href='<%=AppCmn.AppConfig.HomeUrl() %>Article/<%#Eval("SysNo")%>'><%#Eval("Name")%></a>
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
<%-- <div class="side_banner">
                <a href="#" target="_blank">
                    <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/banner_01.jpg" width="242" height="191" /></a>
            </div>--%>
<div class="tabs tabs2">
    <a href="javascript:void(0)" title="最新" class="on">最新</a> <a href="javascript:void(0)"
        title="推荐">推荐</a> <a href="javascript:void(0)" title="热门">热门</a>
</div>
<div class="block show">
    <asp:Repeater ID="rptNew" runat="server">
        <ItemTemplate>
            <div class="side_b">
                <h4>
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>" title="<%#Eval("title")%>">
                        <%#Eval("title")%></a></h4>
                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>">
                    <%#Eval("Description")%></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="block">
    <asp:Repeater ID="rptGood" runat="server">
        <ItemTemplate>
            <div class="side_b">
                <h4>
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>" title="<%#Eval("title")%>">
                        <%#Eval("title")%></a></h4>
                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>">
                    <%#Eval("Description")%></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="block">
    <asp:Repeater ID="rptHot" runat="server">
        <ItemTemplate>
            <div class="side_b">
                <h4>
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>" title="<%#Eval("title")%>">
                        <%#Eval("title")%></a></h4>
                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>">
                    <%#Eval("Description")%></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<script type="text/javascript">
    function showsub(input) {
        $(input).parent().parent().children(".new_right_submenu").css("display", "none");
        document.getElementById($(input).parent().attr('id').replace('li', 'sub')).style.display = "";
    }

</script>

