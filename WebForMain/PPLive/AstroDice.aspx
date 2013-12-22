<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AstroDice.aspx.cs" Inherits="WebForMain.PPLive.AstroDice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>占星骰子在线测算_上上签</title>
    <meta name="keywords" content="上上签_占星骰子_占星色子_占星头子_占星投子_占星骰子网络版_占星色子网络版_占星骰子在线测算" />
    <meta name="description" content="占星骰子第一站，上上签命理网提供专业的网络版占星骰子，专业占卜师在线解答，还有各类占星骰子学习资料。" />
    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>AstroDice/common.css" rel="stylesheet" type="text/css" />
    <!--[if IE 6]>
<script type="text/javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>AstroDice/DD_belatedPNG.js"></script>
<script type="text/javascript">DD_belatedPNG.fix('.box3_item a.on');</script>
<![endif]-->
    <script type="text/javascript">
        function rolled(title, xingzuo, gong, dice) {
            document.getElementById('<%=flashtitle.ClientID%>').value = HTMLEncode(title);
                document.getElementById('<%=gong.ClientID%>').value = gong;
                document.getElementById('<%=xingzuo.ClientID%>').value = xingzuo;
                document.getElementById('<%=dice.ClientID%>').value = dice;
                document.getElementById('<%=Button1.ClientID%>').click();
            }
            function HTMLEncode(input) {
                var converter = document.createElement("DIV");
                converter.innerText = input;
                var output = converter.innerHTML;
                converter = null;
                return output;
            }
            function HTMLDecode(input) {
                var converter = document.createElement("DIV");
                converter.innerHTML = input;
                var output = converter.innerText;
                converter = null;
                return output;
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="wrapper">

            <div class="head">
                <div class="logo">
                    <a href="../">上上签</a>
                </div>

                <div class="head_account">
                    <asp:Literal runat="server" Text="您好，欢迎来到上上签" ID="ltrTips"></asp:Literal>&nbsp;<asp:Literal runat="server" ID="ltrLinks"
                        Text="<a href='..//Passport/Login.aspx' title='登录'>登录</a>｜<a href='../Passport/Register.aspx' title='免费注册'>免费注册</a>"></asp:Literal>
                </div>
                <div class="head_menu">
                    <a href="../" title="首页">首页</a>|<a href="../Quest/Index.aspx" title="煮酒论命">煮酒论命</a>|<a href="../Article/Index.aspx" title="象牙塔">象牙塔</a><%--<span>|</span> <a href="#" title="群组">群组</a>--%>|
                        <a href="../PPLive/Astro.aspx" title="在线排盘">在线排盘</a>|<a href="../Celebrity/Search.aspx" title="名人库">名人库</a>
                </div>

                <div class="clear"></div>
            </div>

            <div class="left">

                <div class="book_t">
                    <h1>占星骰子</h1>
                </div>

                <div class="box1"></div>

                <div class="box2">
                    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0" width="480" height="510" id="astro dice1" align="middle">
                        <param name="allowScriptAccess" value="sameDomain" />
                        <param name="allowFullScreen" value="false" />
                        <param name="movie" value="<%=AppCmn.AppConfig.WebResourcesPath() %>AstroDice/astro dice 480 510 1.swf" />
                        <param name="quality" value="high" />
                        <param name="bgcolor" value="#0A1D47" />
                        <param name="wmode" value="opaque" />
                        <embed src="<%=AppCmn.AppConfig.WebResourcesPath() %>AstroDice/astro dice 480 510 1.swf" quality="high" bgcolor="#0A1D47" width="480" height="510" name="astro dice" align="middle" allowscriptaccess="sameDomain" allowfullscreen="false" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
                    </object>


                </div>

                <div class="clear"></div>
            </div>

            <div class="box3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="flashtitle" runat="server" />
                        <asp:HiddenField ID="xingzuo" runat="server" />
                        <asp:HiddenField ID="gong" runat="server" />
                        <asp:HiddenField ID="dice" runat="server" />
                        <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" OnClick="Button1_Click" />
                        <asp:LinkButton ID="LinkButton1" CssClass="ask" ToolTip="让占星师解答占星骰子" OnClick="LinkButton1_Click" runat="server">我要提问</asp:LinkButton>
                        <div class="box3_t">
                            <h2 id="righttitle" runat="server">占星骰子占卜结果</h2>
                        </div>
                        <div id="rightbutton" runat="server" class="box3_item">
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" CssClass="on" OnClick="LinkButton2_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton2_Click"></asp:LinkButton>
                            <div class="clear"></div>
                        </div>

                        <div class="box3_c">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>

                        <div class="box3_a">
                            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">上一页</asp:LinkButton><asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton5_Click">下一页</asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="clear"></div>

            <div class="box4"></div>

            <div class="box5">

                <div class="content_l" style="margin-left: 27px">
                    <div class="content_l_t">最新回复</div>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="content_l_s">
                                <div class="content_left">
                                    <a href="../Qin/View.aspx?id=<%# Eval("LastReplyUser")%>">
                                        <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("ReplyPhoto")%>" /></a>
                                </div>
                                <div class="content_right">
                                    <div class="content_title">
                                        <span class="new"><a href="../Qin/View.aspx?id=<%# Eval("LastReplyUser")%>"><%# Eval("ReplyNickName")%></a>：<%# AppCmn.CommonTools.CutStr(Eval("Reply").ToString(),50)%></a></span>
                                        || <a href="../Qin/View.aspx?id=<%# Eval("CustomerSysNo")%>"><%# Eval("NickName")%></a>：<a href="../Quest/Question.aspx?id=<%# Eval("SysNo")%>">[占星骰子]<%# Eval("Title")%></a>
                                    </div>
                                    <%--<div class="content_txt1 new"></div>--%>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="content_l">
                    <div class="content_l_t">等你回答</div>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <div class="content_l_s">
                                <div class="content_left">
                                    <a href="Qin/View.aspx?id=<%# Eval("CustomerSysNo")%>">
                                        <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" /></a>
                                </div>
                                <div class="content_right">
                                    <div class="content_title"><a href="Qin/View.aspx?id=<%# Eval("CustomerSysNo")%>"><%# Eval("NickName")%></a>：<a href="../Quest/Question.aspx?id=<%# Eval("SysNo")%>">[占星骰子]<%# Eval("Title")%></a></div>

                                </div>
                                <div class="clear"></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <div class="clear"></div>

            </div>

            <div class="box6">

                <div class="buy">
                    <a href="http://item.taobao.com/item.htm?spm=a230r.1.14.1.kvfsOd&id=18372402976" target="_blank">
                        <h2>购买占星骰子</h2>
                    </a>
                </div>

                <div class="jiqiao">

                    <h2>占星骰子解答技巧</h2>

                    <ul>
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate><li><a target="_blank" href="../Article/Content.aspx?id=<%# Eval("SysNo")%>"><%# Eval("Title")%></a></li></ItemTemplate>
                        </asp:Repeater>
                    </ul>

                    <div class="clear"></div>

                </div>

                <div class="xingzuo">
                    <a href="http://app.ssqian.com/Venus/IndexForQQt.aspx" target="_blank">快来测测你的金星星座</a>
                </div>

            </div>

            <div class="clear"></div>

            <div class="box7"></div>

            <div class="foot">
                <div class="foot_div">占星骰子友情链接：<a href="http://app.t.qq.com/app/play/801272340">占星骰子腾讯微博应用：http://url.cn/GYqljE</a>&nbsp;&nbsp;&nbsp;占星骰子QQ讨论群：3036106&nbsp;</div>
            </div>
        </div>
    </form>
</body>
</html>
