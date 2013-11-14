<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexForQQ.aspx.cs" Inherits="WebForApps.AstroDice.IndexForQQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <script src="../WebResources/Images/AstroDice/jquery.js"></script>
    <!--[if IE 6]>
        <script type="text/javascript" src="../WebResources/Images/AstroDice/DD_belatedPNG.js"></script>
<script type="text/javascript">DD_belatedPNG.fix('.r_ico1 a'); DD_belatedPNG.fix('.r_ico2 a'); DD_belatedPNG.fix('.r_ico3 a');</script>
        <![endif]-->
    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "//hm.baidu.com/hm.js?72cef88fe2d96fc52b022f9fa3702f10";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
    </script>
    <script type="text/javascript">
        function rolled(title, xingzuo, gong, dice, filename) {
            document.getElementById('<%=flashtitle.ClientID%>').value = HTMLEncode(title);
            document.getElementById('<%=gong.ClientID%>').value = gong;
            document.getElementById('<%=xingzuo.ClientID%>').value = xingzuo;
            document.getElementById('<%=dice.ClientID%>').value = dice;
            document.getElementById('<%=filename.ClientID%>').value = filename;
            document.getElementById('<%=Button2.ClientID%>').click();

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

        function UrlEncode(str) {
            var ret = "";
            var strSpecial = "!\"#$%&'()*+,/:;<=>?[]^`{|}~%";
            var tt = "";

            for (var i = 0; i < str.length; i++) {
                var chr = str.charAt(i);
                var c = str2asc(chr);
                tt += chr + ":" + c + "n";
                if (parseInt("0x" + c) > 0x7f) {
                    ret += "%" + c.slice(0, 2) + "%" + c.slice(-2);
                } else {
                    if (chr == " ")
                        ret += "+";
                    else if (strSpecial.indexOf(chr) != -1)
                        ret += "%" + c.toString(16);
                    else
                        ret += chr;
                }
            }
            return ret;
        }

        function atfamous(input, link) {
            if (document.getElementById(input).style.color == "") {
                document.getElementById('<%=HiddenField1.ClientID%>').value += input + "|";
                document.getElementById(input).style.color = "rgb(168,29,31)";
            }
            else {
                document.getElementById(input).style.color = "";
                document.getElementById('<%=HiddenField1.ClientID%>').value = document.getElementById('<%=HiddenField1.ClientID%>').value.replace(input + "|", "");
            }
            document.getElementById('<%=Button3.ClientID%>').click();
        }
        $(function () {
            $(".a_btn").hover(function () {
                $(this).css('opacity', '0.8')
            }, function () {
                $(this).css('opacity', '1')
            })

            $(".r_ico1 li").hover(function () {
                $(".r_ico1 li.on").removeClass("on")
                $(this).addClass("on")
            }, function () {
                $(".r_ico1 li.on").removeClass("on")
            })

            $(".r_ico2 li").hover(function () {
                $(".r_ico2 li.on").removeClass("on")
                $(this).addClass("on")
            }, function () {
                $(".r_ico2 li.on").removeClass("on")
            })

            $(".r_ico3 li").hover(function () {
                $(".r_ico3 li.on").removeClass("on")
                $(this).addClass("on")
            }, function () {
                $(".r_ico3 li.on").removeClass("on")
            })

        })
        function TextChanged() {
            document.getElementById('<%=Button3.ClientID%>').click();
        }


    </script>
    <link href="../WebResources/Images/AstroDice/common1.css" type="text/css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="wrap">
            <div class="top">本产品由"<a target="_blank" href="http://www.ssqian.com">上上签命理咨询</a>"提供</div>

            <div class="content">

                <div class="left">
                    <div class="flash">
                        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0" width="547" height="475" id="astro dice1" align="middle">
                            <param name="allowScriptAccess" value="sameDomain" />
                            <param name="allowFullScreen" value="false" />
                            <param name="movie" value="astro dice 547 475.swf" />
                            <param name="quality" value="high" />
                            <param name="bgcolor" value="#0A1D47" />
                            <param name="wmode" value="opaque" />
                            <embed src="astro dice 547 475.swf" quality="high" bgcolor="#0A1D47" width="547" height="475" name="astro dice" align="middle" allowscriptaccess="sameDomain" allowfullscreen="false" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
                        </object>
                    </div>
                    <asp:HiddenField ID="flashtitle" runat="server" />
                    <asp:HiddenField ID="filename" runat="server" />
                    <asp:HiddenField ID="xingzuo" runat="server" />
                    <asp:HiddenField ID="gong" runat="server" />
                    <asp:HiddenField ID="dice" runat="server" />






                    <%--<div class="left_box" style="padding: 10px 0px">
                        <div class="left_form">
                            <div class="left_form_t"></div>
                            <div class="left_form_c">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                                    <ContentTemplate>
                                        
                                        <asp:Button CssClass="a_btn" ID="Button1" runat="server" Text="我要提问" OnClientClick="javascript:document.forms[0].target='_blank';setTimeout('document.forms[0].action= document.location.href;',500);" PostBackUrl="http://share.v.t.qq.com/index.php?c=share&a=index&url=http://app.t.qq.com/app/play/801272340&pic=&appkey=801402959&title=&line1=&line2=&line3=" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                                    <ContentTemplate>
                                        
                                        <span>占卜结果：<asp:Literal ID="Literal1" runat="server"></asp:Literal></span>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <h2><a id="iamsnowsnow" href="javascript:atfamous('iamsnowsnow',this);">@蓝雪鳳兒</a>
                                    <a id="bubuzhanxing" href="javascript:atfamous('bubuzhanxing',this);">@卜卜占星</a>
                                    <a id="shenrry776" href="javascript:atfamous('shenrry776',this);">@一然</a>
                                    <a id="susan1114" href="javascript:atfamous('susan1114',this);">@采薇</a>
                                    <a id="god82953378" href="javascript:atfamous('god82953378',this);">@山有扶苏</a>
                                    <a id="yellowlittleshoes" href="javascript:atfamous('yellowlittleshoes',this);">@黄小鞋</a><div class="clear"></div>
                                </h2>
                                
                                <div class="clear"></div>
                            </div>
                            <div class="left_form_b"></div>
                        </div>
                    </div>--%>
                    <div class="left_box" style="height: 194px">
                        <div class="box_t">解答攻略</div>
                        <div class="box_c gl">
                            <div class="gl1">
                                <a href="#">星座<br />
                                    HOW</a>
                            </div>
                            <div class="gl2"><a href="#">行星代表你拥有的基本能量</a></div>
                            <div class="gl3">
                                <a href="#">行星<br />
                                    WHAT</a>
                            </div>
                            <div class="gl4"><a href="#">宫位代表行星释放能量的领域</a></div>
                            <div class="gl5">
                                <a href="#">宫位<br />
                                    WHERE</a>
                            </div>
                            <div class="gl6"><a href="#">星座代表行星释放能量的方式</a></div>
                        </div>
                    </div>

                    <div class="left_box" style="height: 180px;">
                        <div class="box_t">骰子案例</div>
                        <div class="box_c al" style="padding-top: 8px">
                            <div class="al_l">
                                <ul>
                                    <li>
                                        <img src="../WebResources/Images/AstroDice/img1.jpg">冥王星</li>
                                    <li>
                                        <img src="../WebResources/Images/AstroDice/img2.jpg">10宫</li>
                                    <li>
                                        <img src="../WebResources/Images/AstroDice/img3.jpg">狮子座</li>
                                </ul>
                            </div>

                            <div class="al_r">
                                问：分手后能不能复合？<br>
                                答：可能性不大。冥王（不满），10宫（压力），狮子座（一意孤行）。可见这段感情让双方并不是很愉快，可能一方太过强势，忽略了对方对感受，太多的埋怨，愤怒，让对方心意已决，复合会比较困难。
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>

                    <div class="left_box" style="height: 142px">
                        <div class="box_t">骰子解答团</div>
                        <div class="box_c">
                            <div class="bg1">
                                <ul>
                                    <li><a href="http://t.qq.com/iamsnowsnow" target="_blank">
                                        <img src="../WebResources/Images/AstroDice/iamsnowsnow.jpg">蓝雪鳳兒</a></li>
                                    <li><a href="http://t.qq.com/bubuzhanxing" target="_blank">
                                        <img src="../WebResources/Images/AstroDice/qinghua.jpg">青花</a></li>
                                    <li><a href="http://t.qq.com/yiraneasy" target="_blank">
                                        <img src="../WebResources/Images/AstroDice/yiran.jpg">一然</a></li>
                                    <li><a href="http://t.qq.com/susan1114" target="_blank">
                                        <img src="../WebResources/Images/AstroDice/caiwei.jpg">采薇</a></li>
                                    <li><a href="http://t.qq.com/god82953378" target="_blank">
                                        <img src="../WebResources/Images/AstroDice/fusu.jpg">山有扶苏</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>


                    <div class="left_box" style="height: 270px">
                        <div class="box_t">骰子教程</div>
                        <div class="box_c jc">
                            <div class="jc_l">
                                <ul>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517.htm">占星骰子符号全释义</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130910/013380.htm">测占星骰子解答能力</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130910/014486.htm">占卜神器占星骰子简介</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130910/014486_1.htm">大话占星骰子之卜卦</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130910/014486_3.htm">大话占星骰子之信条</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130910/014486_4.htm">大话占星骰子之符号</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725.htm">七宫月亮射手：身份证在哪？</a></li>
                                </ul>
                            </div>

                            <div class="jc_l">
                                <ul>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725_1.htm">九宫土星金星：明年入学顺利吗？</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725_2.htm">三宫冥王巨蟹：女儿明年会恋爱吗？</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725_4.htm">二宫海王天蝎：今年有没有桃花？</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725_6.htm">四宫火星摩羯：工作发展趋势如何？</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725_7.htm">五宫太阳双鱼：新领导如何看自己？</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725_3.htm">八宫火星狮子：能找到新工作吗？</a></li>
                                    <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130913/008725_9.htm">一宫金星双鱼：朋友为什么不开心？</a></li>
                                </ul>
                            </div>

                            <div class="clear"></div>
                        </div>
                    </div>

                </div>

                <div class="right">
                    <div class="flash2">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                            <ContentTemplate>

                                <h1>
                                    <asp:Literal ID="Literal1" runat="server" Text="&nbsp;"></asp:Literal></h1>

                                <h2>
                                    <asp:Literal ID="Literal2" runat="server" Text="&nbsp;<br />&nbsp;<br />&nbsp;"></asp:Literal>
                                </h2>

                                <h3>更多行星，宫位，星座的解释，请查看下面</h3>
                                <h4>
                                    <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" onKeyDown="javascript:TextChanged();"></asp:TextBox>

                                    <span style="color: #f00; display: block; margin-top: 10px">分享后会有占星师会您解答噢!</span>
                                </h4>
                                <div class="clear"></div>
                                <asp:Button ID="Button2" runat="server" Text="" Style="display: none;" OnClick="Button2_Click" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                            <ContentTemplate>
                                <asp:Button ID="Button3" runat="server" Text="" Style="display: none;" OnClick="Button3_Click" />
                                <asp:Button ID="Button1" CssClass="button" runat="server" Text=""  OnClientClick="javascript:document.forms[0].target='_blank';setTimeout('document.forms[0].action= document.location.href;',500);" PostBackUrl="http://share.v.t.qq.com/index.php?c=share&a=index&url=http://astro.fashion.qq.com/app/astrodice.htm&pic=&appkey=801402959&title=腾讯星座占星骰子&line1=&line2=&line3="/>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div class="r_box">
                        <div class="box_t">行星</div>
                        <div class="r_c r_ico1">
                            <ul>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_24.htm" style="background-position: 0px 0px">太阳</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_25.htm" style="background-position: -86px 0px">月亮</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_26.htm" style="background-position: -173px 0px">水星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_27.htm" style="background-position: -259px 0px">金星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_28.htm" style="background-position: 0px -40px">火星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_29.htm" style="background-position: -86px -40px">木星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_30.htm" style="background-position: -173px -40px">土星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_31.htm" style="background-position: -259px -40px">天王星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_32.htm" style="background-position: 0px -81px">海王星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_33.htm" style="background-position: -86px -81px">冥王星</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_34.htm" style="background-position: -173px -81px">南交点</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_35.htm" style="background-position: -259px -81px">北交点</a></li>
                            </ul>
                            <div class="clear"></div>
                        </div>
                    </div>

                    <div class="r_box">
                        <div class="box_t">星座</div>
                        <div class="r_c r_ico2">
                            <ul>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_12.htm" style="background-position: 0px 0px">白羊</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_13.htm" style="background-position: -86px 0px">金牛</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_14.htm" style="background-position: -173px 0px">双子</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_15.htm" style="background-position: -259px 0px">巨蟹</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_16.htm" style="background-position: 0px -39px">狮子</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_17.htm" style="background-position: -86px -39px">处女</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_18.htm" style="background-position: -173px -39px">天秤</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_19.htm" style="background-position: -259px -39px">天蝎</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_20.htm" style="background-position: 0px -78px">射手</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_21.htm" style="background-position: -86px -78px">摩羯</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_22.htm" style="background-position: -173px -78px">水瓶</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_23.htm" style="background-position: -259px -78px">双鱼</a></li>
                            </ul>
                            <div class="clear"></div>
                        </div>
                    </div>

                    <div class="r_box">
                        <div class="box_t">宫位</div>
                        <div class="r_c r_ico3">
                            <ul>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517.htm" style="background-position: 0px 0px">1</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_1.htm" style="background-position: -86px 0px">2</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_2.htm" style="background-position: -173px 0px">3</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_3.htm" style="background-position: -259px 0px">4</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_4.htm" style="background-position: 0px -41px">5</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_5.htm" style="background-position: -86px -41px">6</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_6.htm" style="background-position: -173px -41px">7</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_7.htm" style="background-position: -259px -41px">8</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_8.htm" style="background-position: 0px -82px">9</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_9.htm" style="background-position: -86px -82px">10</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_10.htm" style="background-position: -173px -82px">11</a></li>
                                <li><a target="_blank" href="http://astro.fashion.qq.com/a/20130829/011517_11.htm" style="background-position: -259px -82px">12</a></li>
                            </ul>
                            <div class="clear"></div>
                        </div>
                    </div>

                    <%----%>

                    <%--<div class="r_box">
                        <div class="box_t">最新提问</div>
                        <div class="r_c" style="padding: 0px 12px 11px 15px">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div class="ask_s">
                                        <div class="ask_l">
                                            <img src='<%#Eval("QuestPhoto")%>/30'>
                                        </div>
                                        <div class="ask_cor"></div>
                                        <div class="ask_r">
                                            <font style="color: #0b78ba;"><%#Eval("QuestUserName")%></font>：<%#Eval("QuestContent").ToString().Replace(" 更多占星术知识请收听 @iamsnowsnow","").Replace("亲们也来试试吧！","").Replace(@"http://url.cn/FlfQuO","").Replace(@"http://url.cn/GYqljE","")%></a>
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>--%>

                    <div class="r_box">
                        <div class="box_t">最新回复</div>
                        <div class="r_c" style="padding: 0px 12px 11px 15px">
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <div class="ask_s">
                                        <div class="ask_l">
                                            <img src="<%#Eval("ReplyPhoto")%>/30">
                                        </div>
                                        <div class="ask_cor"></div>
                                        <div class="ask_r">
                                            <font style="color: #0b78ba;"><%#Eval("ReplyUserName")%></font>：<%#Eval("ReplyContent")%>||<font style="color: #0b78ba;"><%#Eval("QuestUserName")%></font>：<%#Eval("QuestContent").ToString().Replace(" 更多占星术知识请收听 @iamsnowsnow","").Replace("亲们也来试试吧！ ","").Replace(@"http://url.cn/FlfQuO","").Replace(@"http://url.cn/GYqljE","").Replace(@"http://url.cn/UsYMxD","").Replace("@iamsnowsnow @bubuzhanxing @yiraneasy @susan1114 @god82953378 @yellowlittleshoes 好玩好准的占星骰子，亲们也来试试： http://url.cn/WPXrll ","") %>
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                </div>

                <div class="clear"></div>
            </div>
        </div>
    </form>

</body>
</html>
