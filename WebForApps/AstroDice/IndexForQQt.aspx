<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexForQQt.aspx.cs" Inherits="WebForApps.AstroDice.IndexForQQt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>占星骰子-上上签</title>
    <style>
        body {
            margin: 0 auto;
            background: #fff;
        }

        ul, ol, p, h1, h2, h3, form, dd, dl, dt {
            margin: 0;
            padding: 0;
            list-style: none;
        }

        .clear {
            clear: both;
            height: 0px;
            overflow: hidden;
        }

        .wrapper {
            width: 760px;
            margin: auto;
        }

        .head {
            background: url(../WebResources/Images/AstroDice/title.jpg) no-repeat;
            height: 84px;
            width: 760px;
            position: relative;
        }

        .head_a {
            display: block;
            width: 58px;
            height: 57px;
        }

        .head_btn {
            position: absolute;
            top: 42px;
            left: 360px;
            width: 109px;
            height: 39px;
            cursor: pointer;
        }

        .foot {
            background: url(../WebResources/Images/AstroDice/bj_16.jpg) no-repeat;
            height: 206px;
            width: 760px;
            position: relative;
        }

        .box01 {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: transparent;
            padding: 0px;
            overflow: hidden;
            position: absolute;
            top: 55px;
            left: 155px;
            width: 565px;
            height: 50px;
            margin-top: 10px;
            font-family: 'Microsoft YaHei';
            font-size: 14px;
            color: saddlebrown;
            line-height: 22px;
            margin-left: 0;
            margin-right: 0;
            margin-bottom: 0;
        }

        .span01 {
            font-size: 36px;
            color: #faf44a;
            font-family: 'Microsoft YaHei';
        }

        .share {
            width: 158px;
            height: 42px;
            background: url(../WebResources/Images/AstroDice/btn_zhuan_normal.jpg);
            cursor: pointer;
            position: absolute;
            top: 125px;
            left: 563px;
        }

            .share:hover {
                background: url(../WebResources/Images/AstroDice/btn_zhuan_over.jpg);
            }

            .share:active {
                background: url(../WebResources/Images/AstroDice/btn_zhuan_normal.jpg);
            }

        .continue {
            width: 112px;
            height: 42px;
            background: url(../WebResources/Images/AstroDice/shuoming_btn.jpg);
            cursor: pointer;
            position: absolute;
            top: 660px;
            left: 515px;
        }

            .continue:hover {
                background: url(../WebResources/Images/AstroDice/shuoming_btn_over.jpg);
            }

            .continue:active {
                background: url(../WebResources/Images/AstroDice/shuoming_btn_down.jpg);
            }

        .element {
            width: 74px;
            height: 31px;
            background: url(../WebResources/Images/AstroDice/btn_bule_nor.jpg);
            cursor: pointer;
            margin-top: 5px;
            line-height: 31px;
            border: none;
            font-family: 'Microsoft YaHei';
            font-weight: bolder;
            font-size: 14px;
        }

            .element:hover {
                background: url(../WebResources/Images/AstroDice/btn_bule_over.jpg);
            }

            .element:active {
                background: url(../WebResources/Images/AstroDice/btn_bule_down.jpg);
            }

        .on {
            background: url(../WebResources/Images/AstroDice/btn_red.jpg);
            cursor:auto;
        }
        .on:hover {
            background: url(../WebResources/Images/AstroDice/btn_red.jpg);
            cursor: auto;
        }

        .explain {
            font-family: 'Microsoft YaHei';
            font-size: 14px;
            color: #ffb0e0;
            line-height: 150%;
            width: 240px;
            height: 460px;
            background: url(../WebResources/Images/AstroDice/bj_2.jpg) no-repeat;
            float: left;
            padding: 45px 20px 5px 20px;
        }

        .content_reply {
            padding-left: 65px;
            font: 14px "微软雅黑";
            font-family: 'Microsoft YaHei';
            color: #fff;
            display: block;
            width: 615px;
            padding-top: 10px;
        }

        .content_left {
            width: 40px;
            float: left;
            padding-top: 5px;
        }

            .content_left img {
                width: 30px;
                height: 30px;
            }

        .content_right {
            width: 565px;
            float: left;
            padding-left: 10px;
        }
    </style>

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
                <a href="http://t.qq.com/iamsnowsnow" title="蓝雪鳯兒" class="head_a"></a>
                <div class="head_btn" id="nofriend1" runat="server">
                    <asp:LinkButton ID="LinkButton6" runat="server" ToolTip="收听" OnClick="LinkButton1_Click"><img src="../WebResources/Images/AstroDice/btn_ting.jpg" style="border:none;" /></asp:LinkButton>
                </div>
                <div class="head_btn" id="isfriend1" runat="server" style="cursor: default;">
                    <img src="../WebResources/Images/AstroDice/btn_yishouting.jpg" />
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="view2" runat="server">
                    <div class="bot1">

                        <div style="background-image: url(../WebResources/Images/AstroDice/shuoming_02.jpg); height: 117px; width: 760px;">&nbsp;</div>
                        <div style="width: 100%; height: 523px;">
                            <div style="float: left; background-image: url(../WebResources/Images/AstroDice/shuoming_03.jpg); height: 523px; width: 68px;">&nbsp;</div>
                            <div style="float: left; background: url(../WebResources/Images/AstroDice/shuoming_zi.png) no-repeat; height: 523px; width: 626px;">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="continue" ToolTip="进入应用" OnClick="LinkButton1_Click1"></asp:LinkButton>
                            </div>
                            <div style="float: left; background-image: url(../WebResources/Images/AstroDice/shuoming_05.jpg); height: 523px; width: 66px;">&nbsp;</div>
                        </div>
                        <div style="background-image: url(../WebResources/Images/AstroDice/shuoming.jpg); height: 75px; width: 760px;">&nbsp;</div>
                    </div>
                </asp:View>
                <asp:View ID="view1" runat="server">
                    <div style="width: 480px; height: 510px; float: left;">
                        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0" width="480" height="510" id="astro dice1" align="middle">
                            <param name="allowScriptAccess" value="sameDomain" />
                            <param name="allowFullScreen" value="false" />
                            <param name="movie" value="astro dice 480 510 1.swf" />
                            <param name="quality" value="high" />
                            <param name="bgcolor" value="#0A1D47" />
                            <param name="wmode" value="opaque" />
                            <embed src="astro dice 480 510 1.swf" quality="high" bgcolor="#0A1D47" width="480" height="510" name="astro dice" align="middle" allowscriptaccess="sameDomain" allowfullscreen="false" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
                        </object>
                        <asp:HiddenField ID="flashtitle" runat="server" />

                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="explain">
                                <asp:Button ID="LinkButton8" runat="server" Text="" CssClass="element" ToolTip="查看解释" OnClick="LinkButton8_Click" />&nbsp;
                                <asp:Button ID="LinkButton9" runat="server" Text="" CssClass="element" ToolTip="查看解释" OnClick="LinkButton8_Click" />&nbsp;
                                <asp:Button ID="LinkButton10" runat="server" Text="" CssClass="element" ToolTip="查看解释" OnClick="LinkButton8_Click" /><br />
                                <br />
                                <asp:Literal ID="Label1" runat="server"></asp:Literal>
                            </div>
                            <div style="width: 760px; height: 42px; float: left; background: url(../WebResources/Images/AstroDice/bj_3.jpg) no-repeat;">
                                &nbsp;
                            </div>
                            <div style="width: 760px; height: 178px; overflow-y: auto; background: url(../WebResources/Images/AstroDice/bj_4.jpg) no-repeat;">
                                <div style="width: 720px; height: 170px; overflow-y: auto;">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <div class="content_reply">
                                                <div class="content_left">
                                                    <img src="<%#Eval("ReplyPhoto")%>/30" />
                                                </div>
                                                <div class="content_right">
                                                    <div class="content_title"><font style="color: #87ffc2;"><%#Eval("ReplyUserName")%></font>：<%#Eval("ReplyContent")%>||<font style="color: #87ffc2;"><%#Eval("QuestUserName")%></font>：<%#Eval("QuestContent").ToString().Replace(" 更多占星术知识请收听 @iamsnowsnow","").Replace(@"，求占卜师解答！亲们也来试试吧！ http://url.cn/GYqljE","")%></div>
                                                </div>
                                                <div class="clear"></div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </div>
                            </div>
                            <div class="foot">

                                <asp:HiddenField ID="xingzuo" runat="server" />
                                <asp:HiddenField ID="gong" runat="server" />
                                <asp:HiddenField ID="dice" runat="server" />
                                <asp:Button ID="Button1" runat="server" Text="" Style="display: none;" OnClick="Button1_Click" />
                                <%--<div style="width: 100%; text-align: center; padding-top: 10px;">
                                    <asp:LinkButton ID="LinkButton4" CssClass="span01" runat="server" OnClick="LinkButton4_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" CssClass="span01" runat="server" OnClick="LinkButton4_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton7" CssClass="span01" runat="server" OnClick="LinkButton4_Click"></asp:LinkButton>
                                </div>--%>
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" MaxLength="100" CssClass="box01"></asp:TextBox>
                                <font style="color: red; font-size: 14px; font-family: 'Microsoft YaHei'; position: absolute; top: 135px; left: 350px;">分享后会有占星师为您解答哦！</font>
                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="share" ToolTip="分享到腾讯微博让占星师解答" OnClick="LinkButton2_Click"></asp:LinkButton>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
