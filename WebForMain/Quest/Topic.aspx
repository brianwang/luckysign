<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Topic.aspx.cs" Inherits="WebForMain.Quest.Topic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlLibrary/AstroForQuest.ascx" TagName="Astro" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/BaZiForQuest.ascx" TagName="Bazi" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/ZiWeiForQuest.ascx" TagName="Ziwei" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/LoginPannel.ascx" TagName="Login" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/QuestRightPanel.ascx" TagName="Right" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=m_qustion.Title %>-上上签</title>
    <style type="text/css">
        .popup {
            filter: alpha(opacity=60);
            -moz-opacity: 0.6; /*Firefox私有，透明度50%*/
            opacity: 0.6; /*其他，透明度50%*/
            background-color: black;
        }
    </style>
    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>CSS/page.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>

    <div class="main">

        <div class="index_left">
            <!--煮酒论命-->
            <div class="index_left_box">
                <div class="index_new_ask_t">
                    <div class="index_new_ask_reply">浏览：<span><asp:Literal ID="ltrViewNum" runat="server"></asp:Literal></span>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;回复：<span><asp:Literal ID="ltrReply" runat="server"></asp:Literal></span></div>
                    <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                </div>

                <div class="index_left_new_list" style="padding: 18px;">

                    <div class="index_new_ask_qs">
                        <div class="index_new_ask_l">
                            <asp:Image ID="Image1" Width="70" Height="70" runat="server" /><br />
                            <span class="name">
                                <asp:Literal ID="ltrNickName" runat="server"></asp:Literal></span><br />
                            <span class="info">等级：<asp:Literal ID="ltrQALevel" runat="server"></asp:Literal><br />
                                提问数：<asp:Literal ID="ltrTotalAsk" runat="server"></asp:Literal><br />
                                反馈数：<asp:Literal ID="ltrTotalReply" runat="server"></asp:Literal></span>
                        </div>
                        <div class="index_new_ask_r">
                            <%--<div class="index_new_ask_xs" style="display:none;">
                                <span>
                                    <asp:Literal ID="ltrAward" runat="server"></asp:Literal></span><%=m_qustion.EndTime==null||m_qustion.EndTime==AppCmn.AppConst.DateTimeNull ? @"<span style=""color:#f00"">未解决</span>" : @"<span>已解决</span>"%>
                            </div>--%>
                            <div class="index_new_ask_info">
                                <asp:Literal ID="ltrContext" runat="server"></asp:Literal>
                            </div>

                        </div>

                        <div class="clear"></div>
                    </div>


                    <uc1:Astro ID="Astro1" runat="server" Visible="false"></uc1:Astro>
                    <uc1:Bazi ID="Bazi1" runat="server" Visible="false"></uc1:Bazi>
                    <uc1:Ziwei ID="Ziwei1" runat="server" Visible="false"></uc1:Ziwei>
                    <h4 style="font-weight: normal; margin-top: 55px; text-align: right;">
                        <asp:Literal ID="ltrTime" runat="server"></asp:Literal>
                           <asp:LinkButton ID="LinkButton5"  runat="server" style="display:none;" OnClick="LinkButton5_Click">删除</asp:LinkButton>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<a href="javascript:void(0);" onclick="showreply(this);" style="text-decoration: underline">回复</a></h4>

                    <div class="index_new_ask_form" style="display: none;">
                        <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:Button ID="Button2" runat="server" Text="发表回复" OnClick="lkbReply_Click" />
                    </div>
                    <div class="clear"></div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="index_new_ask_list">
                                <ul>
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                                        <ItemTemplate>

                                            <li>
                                                <div class="index_new_ask_l">
                                                    <a target="_blank" href="<%=AppCmn.AppConfig.HomeUrl() %>Qin/View.aspx?id=<%#Eval("CustomerSysNo")%>">
                                                        <img src="~/ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" width="70" height="70" /></a><br />
                                                    <span class="xz">
                                                        <asp:Repeater ID="Repeater4" runat="server">
                                                            <ItemTemplate>
                                                                <img src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/Medal/<%#Eval("MedalSysNo")%>.gif' width="22" height="23" alt="<%#Eval("MedalName")%>"  />
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <div class="clear"></div>
                                                    </span>
                                                    <%#Eval("Award").ToString()=="0"?"" : @"<span class=""xs""><img src="""+AppCmn.AppConfig.WebResourcesPath()+@"img/paipan/xz2.gif"" /><br />+"+Eval("Award")+"灵签</span>"%>
                                                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="xs_a" CommandArgument='<%#Eval("SysNo")%>'
                                                        CommandName="Award">悬赏给Ta</asp:LinkButton>--%>
                                                </div>
                                                <div class="index_new_ask_r">
                                                    <h1><a target="_blank" href="<%=AppCmn.AppConfig.HomeUrl() %>Qin/View.aspx?id=<%#Eval("CustomerSysNo")%>"><%#Eval("NickName")%></a></h1>
                                                    <h2>等级：<%#Eval("LevelNum")%>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;灵签：<%#Eval("Point")%>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;解答数：<%#Eval("TotalAnswer")%>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;被采纳数：<%#Eval("BestAnswer")%> </h2>
                                                    <h3>
                                                        <%--<div class="index_new_ask_r_qs" style="font-size:12px"><a href="#">山有扶苏:</a>哇，看来这个东西以后也可以看的。性格上部分正确，稳重，独处，但是比较内向，呵呵。不过口才真没发现，现在还不大爱说话，两三岁的时候才开始会说话。</div>--%>
                                                        <%#Eval("Context")%></h3>
                                                    <h4><%#DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>&nbsp;&nbsp;&nbsp;|  
                                                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("SysNo")%>' CommandName="Love" runat="server">赞同</asp:LinkButton>
                                                        (<%#Eval("love")%>)<asp:Literal ID="Literal1" Visible="false" runat="server" Text="&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;"></asp:Literal><asp:LinkButton ID="LinkButton5"  runat="server" Visible="false" CommandArgument='<%#Eval("SysNo")%>' CommandName="Del">删除</asp:LinkButton>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<a href="javascript:void(0);" onclick="showreply(this);">回复</a></h4>

                                                    <div class="index_new_reply_list">
                                                        <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound" OnItemCommand="Repeater3_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="index_new_reply_box">
                                                                    <div class="index_new_reply_l">
                                                                        <a href="<%=AppCmn.AppConfig.HomeUrl() %>Qin/View.aspx?id=<%#Eval("CustomerSysNo")%>">
                                                                            <img src="~/ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" width="33" height="33" /></a>
                                                                    </div>
                                                                    <div class="index_new_reply_r">
                                                                        <span class="info" style='<%#Eval("color")%>'><a target="_blank" href="../Qin/View.aspx?id=<%#Eval("CustomerSysNo")%>"><%#Eval("NickName")%></a>：<%#Eval("Context")%></span>
                                                                        <span class="time"><%#DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%><asp:Literal ID="Literal1" Visible="false" runat="server" Text="&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;"></asp:Literal><asp:LinkButton ID="LinkButton5"  runat="server" Visible="false" CommandArgument='<%#Eval("SysNo")%>' CommandName="del">删除</asp:LinkButton></span>
                                                                    </div>
                                                                    <div class="clear"></div>
                                                                </div>

                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </div>

                                                    <div class="index_new_ask_form" style="display: none;">
                                                        <asp:TextBox ID="txtRe" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:Button ID="Button10" runat="server" Text="发表看法" CommandArgument='<%#Eval("SysNo")%>' CommandName="Reply" />
                                                    </div>
                                                </div>
                                                <div class="clear"></div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </ul>
                            </div>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="page_bottom_code" style="background: none">
                    <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
                </div>

                <!--发表看法-->
                <div class="mr_form" style="background: #F7F4EE; padding: 18px; position: relative">
                    <div id="nologin" runat="server" style="display: none;" class="mr_form_tip">发帖回答，请先<asp:LinkButton ID="LinkButton3" OnClick="LinkButton3_Click" runat="server">登录</asp:LinkButton><span>|</span><asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server">注册</asp:LinkButton></div>
                    <div class="mr_form_l">
                        <asp:Image ID="Image2" runat="server"  />
                    </div>
                    <div class="mr_form_r">
                        <asp:TextBox ID="txtReply2" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:Button ID="Button3" runat="server" Text="发布" OnClick="lkbReply2_Click" />
                    </div>
                    <div class="clear"></div>
                </div>


            </div>
        </div>
        <div class="index_right">
            <div class="new_right_item">煮酒论命</div>
            <uc1:Right ID="Right1" runat="server"></uc1:Right>
        </div>
        <div class="clear"></div>
    </div>

    <asp:HiddenField ID="IsLogined" runat="server" />
    
    <asp:HiddenField ID="HiddenField2" runat="server" />
<%--    <asp:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="popup" TargetControlID="Button1" CancelControlID="Button6" PopupControlID="Panel1" BehaviorID="Panel1" runat="server"></asp:ModalPopupExtender>
    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="Button" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none;">

        <div class="setting_box" style="padding: 10px 25px 25px 25px">
            <div class="mr_left_name" style="padding-bottom: 5px; border-bottom: solid 1px #A4534B; margin-bottom: 10px">
                分配奖励
            </div>
            <ul class="setting_ul">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <li><span>奖励：</span><div class="setting_r">
                            <div>
                                <asp:TextBox ID="txtScore" runat="server" CssClass="setting_input" Width="50px"></asp:TextBox>
                            </div>
                            <h1>
                                <asp:Literal ID="ltrMax" runat="server"></asp:Literal></h1>
                        </div>
                            <div class="clear"></div>
                        </li>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <li><span>&nbsp;</span>
                    <div class="setting_r">

                        <asp:Button ID="Button5" runat="server" CssClass="setting_button1" OnClick="Button5_Click" Text="确定" />
                        <asp:Button ID="Button6" runat="server" CssClass="setting_button2" Text="取消" />
                    </div>
                    <div class="clear"></div>
                </li>
            </ul>
        </div>
    </asp:Panel>--%>
    <uc1:Login ID="Login1" runat="server"></uc1:Login>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
   <%-- <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>--%>
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showreply(input) {
            if (document.getElementById('<%=IsLogined.ClientID%>').value == 'TRUE') {
                $(input).parent().parent().children(".index_new_ask_form").css("display", "");
            }
            else {
                document.getElementById('<%=LinkButton3.ClientID%>').click();
            }
        }

    </script>
</asp:Content>
