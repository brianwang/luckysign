<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True" CodeBehind="Search.aspx.cs" Inherits="WebForMain.Celebrity.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>搜索名人命盘库_上上签</title>
    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>CSS/page.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="mr_box">
            <!--内页左侧-->
            <div class="mr_left">

                <!--名人搜索-->
                <div class="mr_leftsearch">
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" CssClass="mr_button" OnClick="Button1_Click" Text="查找名人" />
                </div>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <!--名人标签-->
                        <div class="mr_a">
                            <asp:Repeater ID="rptKeys" runat="server">
                                <ItemTemplate><a href="<%=AppCmn.AppConfig.HomeUrl() %>Celebrity/<%#Eval("SysNo") %>" class="c<%#Eval("css") %>"><span></span><%#Eval("KeyWords") %></a></ItemTemplate>
                            </asp:Repeater>

                            <%--                <a href="#" class="c2"><span></span>神经病</a>
                <a href="#" class="c3"><span></span>意歌手亡</a>
                <a href="#" class="c4"><span></span>歌手歌的</a>
                <a href="#" class="c5"><span></span>神经病</a>
                <a href="#" class="c6"><span></span>意外死亡</a>
                <a href="#" class="c7"><span></span>歌手</a>
                <a href="#" class="c8"><span></span>神经病</a>
                <a href="#" class="c9"><span></span>意歌外死亡</a>
                <a href="#" class="c10"><span></span>歌手</a>
                <a href="#" class="c11"><span></span>试的经病</a>
                <a href="#" class="c12"><span></span>意外死亡</a>
                <a href="#" class="c13"><span></span>歌手</a>
                <a href="#" class="c14"><span></span>神经病</a>
                <a href="#" class="c15"><span></span>意外死亡</a>
                <a href="#" class="c16"><span></span>歌手</a>
                <a href="#" class="c17"><span></span>神经病</a>
                <a href="#" class="c18"><span></span>意外死亡</a>--%>
                        </div>

                        <div class="clear"></div>

                        <!--今天出生-->
                        <div class="mr_today">
                            <div class="mr_today_t">今天出生的名人</div>
                            <div class="mr_today_c">
                                <ul>
                                    <asp:Repeater ID="rptTop" runat="server">
                                        <ItemTemplate>
                                            <li><a target="_blank" href="<%=AppCmn.AppConfig.HomeUrl() %>Celebrity/Detail/<%#Server.UrlEncode(AppCmn.CommonTools.Encode(Eval("SysNo").ToString())) %>">
                                                <img src="<%#Eval("photo") %>" height="155" width="127" alt="<%#Eval("Name") %>命盘" /><%#Eval("Name") %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <%--<li><a href="#">
                            <img src="WebResources/img/page/mingren.jpg" />比尔盖茨</a></li>
                        <li><a href="#">
                            <img src="WebResources/img/page/mingren.jpg" />比尔盖茨</a></li>
                        <li><a href="#">
                            <img src="WebResources/img/page/mingren.jpg" />比尔盖茨</a></li>
                        <li style="margin-right: 0"><a href="#">
                            <img src="WebResources/img/page/mingren.jpg" />比尔盖茨</a></li>--%>
                                </ul>
                                
                                
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <div class="height20"></div>

                        <div class="mr_left_name">搜索结果</div>

                        <div class="mr_search_content">
                            <ul class="mr_search_ul">
                                <asp:Repeater ID="rptResult" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="mr_search_ul_l">
                                                <a target="_blank" href="<%=AppCmn.AppConfig.HomeUrl() %>Celebrity/Detail/<%#Server.UrlEncode(AppCmn.CommonTools.Encode(Eval("SysNo").ToString())) %>">
                                                    <img src="<%#Eval("photo") %>" alt="<%#Eval("Name") %>" /></a>
                                            </div>
                                            <div class="mr_search_ul_r">
                                                <a target="_blank" href="<%=AppCmn.AppConfig.HomeUrl() %>Celebrity/Detail/<%#Server.UrlEncode(AppCmn.CommonTools.Encode(Eval("SysNo").ToString())) %>">
                                                    <h1><%#Eval("Name") %>（<%#Eval("FullName") %>）</h1>
                                                </a>
                                                <%#Eval("Description") %>
                                            </div>
                                            <div class="clear"></div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>

                        <div class="mr_tip">符合搜索条件的记录共有<asp:Literal ID="Literal1" runat="server"></asp:Literal>条，以上是其中的<asp:Literal ID="Literal2" runat="server" Text="10"></asp:Literal>位，如果没有显示你要查找的名人，请用更精确的关键字重新搜索。</div>
                    </asp:View>
                </asp:MultiView>
            </div>

            <!--内页右侧-->
            <div class="mr_right">
                <div style="background: #696969; height: 190px; text-align: center; color: #fff">banner3</div>
            </div>

            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
<script type="text/javascript">
    $(function () {
        $(".mr_today_c li:nth-child(5n)").css("margin-right", 0);
        $(".mr_search_ul li:last").css("border", "none")
    })
</script>
</asp:Content>
