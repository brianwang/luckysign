<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexForQQ.aspx.cs" Inherits="WebForApps.LoveRose.IndexForQQ" %>

<%@ Register Src="../ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>爱情花</title>
    <link href="../WebResources/Images/LoveRose/css/login.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../WebResources/Images/LoveRose/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../WebResources/Images/LoveRose/js/jquery.pngFix.pack.js"></script>
    <script type="text/javascript" src="../WebResources/Images/LoveRose/js/default.js"></script>


    <link href="../WebResources/Images/LoveRose/css/common.css" type="text/css" rel="stylesheet" />
</head>
<body style="">
    <form id="form1" runat="server">
        <div class="x-box">
            <div class="x-top"></div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <script type="text/javascript">
                                //$(function () {
                                //    $(document).bind("click", function (e) {
                                //        var target = $(e.target);
                                //        if (target.closest(".sub-nav").length == 0 && target.closest(".select").length == 0) {
                                //            $(".sub-nav").hide();
                                //        }
                                //    })
                                //})

                                function refreshdistrict() {
                                    $("#Div2").children("a").click(function () {
                                        $(this).parent().parent().children("span").text($(this).text());
                                        //$(this).parent().css("display","none");
                                        $("#HiddenField2").val($(this).attr("id"));
                                    });
                                    $("#Div2").parent().click(function () {
                                        $(this).addClass("down")
                                    }).mouseleave(function () {
                                        $(this).removeClass("down")
                                    });
                                }

                                function initialselect() {
                                    $("#subyear").html("");
                                    for (var i = 2010; i > 1920; i--) {
                                        $("#subyear").html($("#subyear").html() + "<a id='" + i + "'>" + i + "</a>");
                                    }
                                    $("#submonth").html("");
                                    for (var i = 1; i < 13; i++) {
                                        $("#submonth").html($("#submonth").html() + "<a id='" + i + "'>" + i + "</a>");
                                    }
                                    $("#subday").html("");
                                    for (var i = 1; i < 32; i++) {
                                        $("#subday").html($("#subday").html() + "<a id='" + i + "'>" + i + "</a>");
                                    }
                                    $("#subhour").html("");
                                    for (var i = 0; i < 24; i++) {
                                        $("#subhour").html($("#subhour").html() + "<a id='" + i + "'>" + i + "</a>");
                                    }
                                    $("#subminite").html("");
                                    for (var i = 0; i < 60; i++) {
                                        $("#subminite").html($("#subminite").html() + "<a id='" + i + "'>" + i + "</a>");
                                    }

                                    $(".select").click(function () {
                                        $(this).addClass("down")
                                    }).mouseleave(function () {
                                        $(this).removeClass("down")
                                    });
                                    //$(".select").children("img").click(function () {
                                    //    if ($(this).parent().children(".sub-nav").css("display") == "none") {
                                    //        $(this).parent().children(".sub-nav").css("display", "");
                                    //    }
                                    //    else {
                                    //        $(this).parent().children(".sub-nav").css("display", "none");
                                    //    }
                                    //});
                                    $(".sub-nav").children("a").click(function () {
                                        $(this).parent().parent().children("span").text($(this).text());
                                        //$(this).parent().css("display","none");
                                        if ($(this).parent().attr("id") == "Div1") {
                                            $("#HiddenField3").val($(this).attr("id"));
                                            //$(this).parent().css("display", "none");
                                            $("#Button2").click();
                                        }
                                        else if ($(this).parent().attr("id") == "Div2") {
                                            $("#HiddenField2").val($(this).attr("id"));
                                        }
                                        else if (($(this).parent().attr("id") == "subyear") || ($(this).parent().attr("id") == "submonth")) {
                                            setDays($("#yearspan").text(), $("#monthspan").text());
                                            $("#HiddenField4").val($("#yearspan").text() + "-" + $("#monthspan").text() + "-" + $("#dayspan").text() + " " + $("#hourspan").text() + ":" + $("#minitespan").text() + ":0");
                                        }
                                        else if ($(this).parent().attr("id") == "sub0") {
                                            $("#HiddenField1").val($(this).attr("id"));
                                        }
                                        else if ($(this).parent().attr("id") == "sub1") {
                                            $("#HiddenField6").val($(this).attr("id"));
                                        }
                                        else {
                                            $("#HiddenField4").val($("#yearspan").text() + "-" + $("#monthspan").text() + "-" + $("#dayspan").text() + " " + $("#hourspan").text() + ":" + $("#minitespan").text() + ":0");
                                        }
                                    });


                                }
                            </script>
                            <script type="text/javascript">

                                //设置每个月份的天数
                                function setDays(year, month) {

                                    var monthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
                                    var yea = year;
                                    var mon = month;
                                    var num = monthDays[mon - 1];
                                    if (mon == 2 && isLeapYear(yea)) {
                                        num++;
                                    }
                                    $("#subday").html("");
                                    for (var i = 1; i < num + 1; i++) {
                                        $("#subday").html($("#subday").html() + "<a id='" + i + "'>" + i + "</a>");
                                    }
                                    $("#subday").children("a").click(function () {
                                        $(this).parent().parent().children("span").html($(this).text());
                                        $("#HiddenField4").val($("#yearspan").text() + "-" + $("#monthspan").text() + "-" + $("#dayspan").text() + " " + $("#hourspan").text() + ":" + $("#minitespan").text() + ":0");
                                    });
                                }

                                //判断是否闰年
                                function isLeapYear(year) {
                                    return (year % 4 == 0 || (year % 100 == 0 && year % 400 == 0));
                                }

                            </script>
                            <div class="x-left">
                                <div class="flash">
                                    <div class="login-box">
                                        <div class="login-list">
                                            <ul>
                                                <li>
                                                    <div class="select">
                                                        <span id="yearspan" runat="server">1995</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subyear">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="monthspan" runat="server">1</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="submonth">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="dayspan" runat="server">1</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subday">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="hourspan" runat="server">12</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subhour">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="minitespan" runat="server">0</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subminite">
                                                        </div>
                                                    </div>
                                                </li>
                                                <asp:HiddenField ID="HiddenField4" runat="server" />
                                                <li style="padding-left: 20px">
                                                    <div class="select" style="width: 120px; margin-right: 5px;">
                                                        <span id="district1" runat="server">北京市</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="Div1">
                                                            <asp:Repeater ID="Repeater1" runat="server">
                                                                <ItemTemplate>
                                                                    <a id='<%#Eval("sysno")%>'><%#Eval("Name")%></a>
                                                                    <%--<asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("sysno")%>'><%#Eval("Name")%></asp:LinkButton>--%>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" RenderMode="Inline">
                                                        <ContentTemplate>
                                                            <div class="select" style="width: 165px;">
                                                                <span id="district2" runat="server"></span>
                                                                <img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                                <div class="sub-nav" id="Div2">
                                                                    <asp:Repeater ID="Repeater2" runat="server">
                                                                        <ItemTemplate>
                                                                            <a id='<%#Eval("sysno")%>'><%#Eval("Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                    <asp:Button ID="Button2" runat="server" Style="display: none;" Text="Button" OnClick="Button2_Click" />
                                                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </li>

                                                <li>
                                                    <a href="#" title="夏令时" class="select-a"></a>
                                                    <div id="drp0" class="select">
                                                        <span>自动判断</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="sub0">
                                                            <a id="2">自动判断</a>
                                                            <a id="1">是</a>
                                                            <a id="0">否</a>
                                                        </div>
                                                    </div>
                                                    <div id="drp1" class="select" style="margin-left: 50px">
                                                        <span>女</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div id="sub1" class="sub-nav">
                                                            <a id="g1">男</a>
                                                            <a id="g0">女</a>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:HiddenField ID="HiddenField6" runat="server" />
                                        </div>
                                        <div class="login-button">
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed1_Click"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="x-right">



                                <div class="x-right-t">爱情攻略</div>
                                <div class="x-right-c">
                                    <ul>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                    </ul>
                                </div>

                                <div class="shouting">
                                    <div class="shouting-t">更多爱情占星攻略请关注</div>
                                    <div class="shouting-c">
                                        <ul>
                                            <li>
                                                <img src="../WebResources/Images/LoveRose/img/txxz.jpg"><span>腾讯星座</span><a target="_blank" href="http://e.t.qq.com/qqastro">+收听</a></li>
                                            <li>
                                                <img src="../WebResources/Images/LoveRose/img/zxxt.jpg"><span>占星学堂</span><a target="_blank" href="http://t.qq.com/astro_qy">+收听</a></li>
                                            <li>
                                                <img src="../WebResources/Images/LoveRose/img/iamsnowsnow.jpg"><span>蓝雪鳳兒</span><a target="_blank" href="http://t.qq.com/iamsnowsnow">+收听</a></li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear"></div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <script type="text/javascript">
                                function initialselect() { }
                            </script>
                            <div class="x-left">
                                <div class="flash">
                                    <div class="f-box">

                                        <div id="tip" runat="server" class="tip" style="display: none;">
                                            <div class="tip-close">
                                                <a onclick="javascript:<%=tip.ClientID %>.style.display='none';">
                                                    <img src="../WebResources/Images/LoveRose/img/close.gif"></a>
                                            </div>
                                            <div class="tip-box">
                                                <h1>
                                                    <asp:Literal ID="ltrTipTitle" runat="server"></asp:Literal></h1>
                                                <div class="tip-content">
                                                    <asp:Literal ID="ltrTipContent" runat="server"></asp:Literal>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="f-a-box">
                                            <asp:LinkButton ID="LinkButton2" CssClass="f-a" runat="server" OnClientClick="javascript:document.forms[0].target='_blank';setTimeout('document.forms[0].action= document.location.href;',500);" PostBackUrl="http://share.v.t.qq.com/index.php?c=share&a=index&url=http://astro.fashion.qq.com/app/loverose.htm&pic=&appkey=801402959&title=腾讯星座爱情花&line1=&line2=&line3=">转发到微博</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" CssClass="f-a" runat="server" OnClick="LinkButton3_Click">再测一次</asp:LinkButton>
                                            <div class="clear"></div>
                                        </div>
                                        <asp:HiddenField ID="HiddenField5" runat="server" />
                                        <asp:Button ID="Button1" runat="server" Text="" OnClick="Button1_Click" Style="display: none;" />
                                        <!--泡泡-->
                                        <div onclick="javascript:<%=HiddenField5.ClientID %>.value='13';<%=Button1.ClientID %>.click();" class="paopao" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                            <div class="level-4"></div>
                                        </div>

                                        <!--蜜蜂-->
                                        <div onclick="javascript:<%=HiddenField5.ClientID %>.value='2';<%=Button1.ClientID %>.click();" class="mifeng" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                            <div class="level-4"></div>
                                        </div>

                                        <!--虫子-->
                                        <div class="chongzi" onclick="javascript:<%=HiddenField5.ClientID %>.value='12';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--醋-->
                                        <div class="cu" onclick="javascript:<%=HiddenField5.ClientID %>.value='17';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--裂痕-->
                                        <div class="liehen" onclick="javascript:<%=HiddenField5.ClientID %>.value='16';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                            <div class="level-4"></div>
                                        </div>

                                        <!--花盆-->
                                        <div class="huapen">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--冰冻-->
                                        <div class="bingdong" onclick="javascript:<%=HiddenField5.ClientID %>.value='11';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--红杏-->
                                        <div class="hongxing" onclick="javascript:<%=HiddenField5.ClientID %>.value='3';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>

                                        <!--花-->
                                        <div class="hua" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                            <div class="f-1"></div>
                                            <div class="f-2"></div>
                                            <div class="f-3"></div>
                                            <div class="f-4"></div>
                                            <div class="f-5"></div>
                                            <div class="f-6"></div>
                                            <div class="f-7"></div>
                                            <div class="f-8"></div>
                                            <div class="f-9"></div>
                                            <div class="f-10"></div>
                                            <div class="f-11"></div>
                                            <div class="f-12"></div>
                                        </div>

                                        <!--折枝-->
                                        <div class="zhezhi" onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                            <div class="level-4"></div>
                                        </div>

                                        <!--枯枝-->
                                        <div class="kuzhi" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                    </div>
                                </div>
                                <div class="yuansu">
                                    <div class="yuansu-t"></div>
                                    <div class="yuansu-c">
                                        <ul>
                                            <li runat="server" id="li1" style="display: none;"><span style="background-position: -10px -10px"></span>蜜蜂的数量代表了你对异性的吸引力，如果同时出现蝴蝶说明你是桃花很旺的人。</li>
                                            <li runat="server" id="li2" style="display: none;"><span style="background-position: -70px -10px"></span>泡泡代表你经常遇人不淑，看错人，并在感情中存在不切实际的幻想。</li>
                                            <li runat="server" id="li3" style="display: none;"><span style="background-position: -10px -70px"></span>折枝代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li runat="server" id="li4" style="display: none;"><span style="background-position: -70px -70px"></span>虫子代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li runat="server" id="li5" style="display: none;"><span style="background-position: -10px -130px"></span>红杏代表你遭遇被劈腿的可能性很大。<a href="#" target="_blank">转运秘籍</a></li>
                                            <li runat="server" id="li6" style="display: none;"><span style="background-position: -70px -130px"></span>冰冻代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li runat="server" id="li7" style="display: none;"><span style="background-position: -10px -190px"></span>裂痕代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li runat="server" id="li8" style="display: none;"><span style="background-position: -70px -190px"></span>醋代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                        <li runat="server" id="li9" style="display: none;"><span style="background-position: -70px -190px"></span>枯叶代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                </div>
                            </div>

                            <div class="x-right">
                                <div class="x-right-t">个人信息</div>
                                <div class="x-right-c">
                                    <asp:Literal ID="ltrInfo" runat="server"></asp:Literal>
                                </div>

                                <div class="x-right-t">辅助分析</div>
                                <div class="x-right-c">
                                    <div class="per">
                                        稳定指数：<asp:Literal ID="ltr1" runat="server"></asp:Literal>%
                <div class="c1"><span id="span1" runat="server" style="width: 90px"></span></div>
                                    </div>
                                    <div class="per">
                                        魅力指数：70%
                <div class="c2"><span id="span2" runat="server" style="width: 90px"></span></div>
                                    </div>
                                    <%--<div class="per">
                                        旺夫指数：70%
                <div class="c3"><span id="span1" runat="server" style="width: 90px"></span></div>
                                    </div>--%>
                                    <div class="per">
                                        花心指数：<asp:Literal ID="ltr3" runat="server"></asp:Literal>%
                <div class="c4"><span id="span3" runat="server" style="width: 90px"></span></div>
                                    </div>
                                    <div class="per">
                                        嫁个有钱人指数：<asp:Literal ID="ltr4" runat="server"></asp:Literal>%
                <div class="c5"><span id="span4" runat="server" style="width: 90px"></span></div>
                                    </div>
                                </div>

                                <div class="x-right-t">爱情攻略</div>
                                <div class="x-right-c">
                                    <ul>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                        <li><a target="_blank" href="#">如何打动金星双子座？</a></li>
                                    </ul>
                                </div>

                                <div class="shouting">
                                    <div class="shouting-t">更多爱情占星攻略请关注</div>
                                    <div class="shouting-c">
                                        <ul>
                                            <li>
                                                <img src="../WebResources/Images/LoveRose/img/txxz.jpg"><span>腾讯星座</span><a target="_blank" href="http://e.t.qq.com/qqastro">+收听</a></li>
                                            <li>
                                                <img src="../WebResources/Images/LoveRose/img/zxxt.jpg"><span>占星学堂</span><a target="_blank" href="http://t.qq.com/astro_qy">+收听</a></li>
                                            <li>
                                                <img src="../WebResources/Images/LoveRose/img/iamsnowsnow.jpg"><span>蓝雪鳳兒</span><a target="_blank" href="http://t.qq.com/iamsnowsnow">+收听</a></li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                </div>

                            </div>

                            <div class="clear"></div>
                        </asp:View>
                    </asp:MultiView><asp:Literal ID="Label1" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>
