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
                                                    <div id="drp0" class="select" style="width: 70px;">
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
                                function hoverinit() {
                                    alert("initialselect");
                                    //if ($(".shouting-c").length !== 0)
                                    //{ $(".shouting-c li:odd").css("margin-left", "20px") }

                                    //$(".f-box").children("div").hide();

                                    //$(document).pngFix();

                                    $(".f-box").children("div:not(0)").children("div").each(function () {
                                        if (!$(this).is(':has(a)')) {
                                            $(this).bind("mouseenter", function () {
                                                $(this).css("cursor", "pointer")
                                                var bgimg = $(this).css("background-image");//取背景
                                                bgimg = bgimg.replace(".", "_on.");//字符替换
                                                $(this).css("background-image", bgimg)//加on
                                            }).bind("mouseleave", function () {
                                                $(this).attr("style", "");//去除属性
                                                $(this).css("display", "block");
                                            })
                                        }
                                        else {
                                            //蜜蜂等区域热点
                                            $(this).children("a").bind("mouseenter", function () {
                                                var bgimg = $(this).parent().css("background-image");//取背景
                                                bgimg = bgimg.replace(".", "_on.");
                                                $(this).parent().css("background-image", bgimg)//加on
                                            }).bind("mouseleave", function () {
                                                $(this).parent().attr("style", "");//去除属性
                                            })

                                        }

                                    })
                                }
                                   
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
                                        <div class="paopao">
                                            <div class="level-1" onclick="javascript:<%=HiddenField5.ClientID %>.value='13';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-2" onclick="javascript:<%=HiddenField5.ClientID %>.value='13';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-3" onclick="javascript:<%=HiddenField5.ClientID %>.value='13';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-4" onclick="javascript:<%=HiddenField5.ClientID %>.value='13';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                        </div>

                                        <!--蜜蜂-->
                                        <div class="mifeng">
                                            <div class="level-1">
                                                <a class="mf_a1" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-2">
                                                <a class="mf_a1" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="mf_a2" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-3">
                                                <a class="mf_a1" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="mf_a2" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="mf_a3" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-4">
                                                <a class="mf_a1" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="mf_a2" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="mf_a3" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="mf_a4" onclick="javascript:<%=HiddenField5.ClientID %>.value='18';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                        </div>

                                        <!--虫子-->
                                        <div class="chongzi">
                                            <div class="level-1">
                                                <a class="cz_a1" onclick="javascript:<%=HiddenField5.ClientID %>.value='12';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-2">
                                                <a class="cz_a1" onclick="javascript:<%=HiddenField5.ClientID %>.value='12';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-3">
                                                <a class="cz_a1" onclick="javascript:<%=HiddenField5.ClientID %>.value='12';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="cz_a2" onclick="javascript:<%=HiddenField5.ClientID %>.value='12';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                        </div>

                                        <!--醋-->
                                        <div class="cu">
                                            <div class="level-1" onclick="javascript:<%=HiddenField5.ClientID %>.value='17';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-2" onclick="javascript:<%=HiddenField5.ClientID %>.value='17';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-3" onclick="javascript:<%=HiddenField5.ClientID %>.value='17';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                        </div>

                                        <!--裂痕-->
                                        <div class="liehen">
                                            <div class="level-1" onclick="javascript:<%=HiddenField5.ClientID %>.value='16';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-2" onclick="javascript:<%=HiddenField5.ClientID %>.value='16';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-3" onclick="javascript:<%=HiddenField5.ClientID %>.value='16';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-4" onclick="javascript:<%=HiddenField5.ClientID %>.value='16';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                        </div>

                                        <!--花盆-->
                                        <div class="huapen">
                                            <div id="nohover" class="level-1"></div>
                                            <div class="level-2">
                                                <a class="hp_a2" onclick="javascript:<%=HiddenField5.ClientID %>.value='20';<%=Button1.ClientID %>.click();" style="cursor: pointer"></a>

                                            </div>
                                            <div class="level-3" onclick="javascript:<%=HiddenField5.ClientID %>.value='20';<%=Button1.ClientID %>.click();" style="cursor: pointer">
                                                <a class="hp_a3" onclick="javascript:<%=HiddenField5.ClientID %>.value='20';<%=Button1.ClientID %>.click();" style="cursor: pointer"></a>
                                            </div>
                                        </div>

                                        <!--冰冻-->
                                        <div class="bingdong">
                                            <div class="level-1" onclick="javascript:<%=HiddenField5.ClientID %>.value='11';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-2" onclick="javascript:<%=HiddenField5.ClientID %>.value='11';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-3" onclick="javascript:<%=HiddenField5.ClientID %>.value='11';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                        </div>

                                        <!--红杏-->
                                        <div class="hongxing" >
                                            <div class="level-1" onclick="javascript:<%=HiddenField5.ClientID %>.value='19';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                        </div>

                                        <!--花-->
                                        <div class="hua">
                                            <div class="f-1" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-2" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-3" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-4" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-5" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-6" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-7" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-8" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-9" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-10" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-11" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="f-12" onclick="javascript:<%=HiddenField5.ClientID %>.value='1';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                        </div>

                                        <!--折枝-->
                                        <div class="zhezhi">
                                            <div class="level-1">
                                                <a class="zz_a1"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-2">
                                                <a class="zz_a1"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="zz_a2"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-3">
                                                <a class="zz_a1"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="zz_a2"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                            <div class="level-4">
                                                <a class="zz_a1"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="zz_a2"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                                <a class="zz_a3"  onclick="javascript:<%=HiddenField5.ClientID %>.value='14';<%=Button1.ClientID %>.click();">&nbsp;</a>
                                            </div>
                                        </div>

                                        <!--枯枝-->
                                        <div class="kuzhi">
                                            <div class="level-1" onclick="javascript:<%=HiddenField5.ClientID %>.value='15';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-2" onclick="javascript:<%=HiddenField5.ClientID %>.value='15';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                            <div class="level-3" onclick="javascript:<%=HiddenField5.ClientID %>.value='15';<%=Button1.ClientID %>.click();" style="cursor: pointer"></div>
                                        </div>

                                    </div>
                                </div>
                                <div class="yuansu">
                                    <div class="yuansu-t"></div>
                                    <div class="yuansu-c">
                                        <ul>
                                            <li runat="server" id="li1" style="display: none;"><span style="background-position: -10px -10px"></span>蜜蜂的数量代表了你对异性的吸引力，如果还同时出现蝴蝶，说明你是桃花很旺的人噢。</li>
                                            <li runat="server" id="li2" style="display: none;"><span style="background-position: -70px -10px"></span>泡泡代表你经常遇人不淑，选错人，并在感情中存在一些不切实际的幻想。</li>
                                            <li runat="server" id="li3" style="display: none;"><span style="background-position: -10px -70px"></span>折枝代表你在婚恋关系中比较敏感，常因个性偏强而争吵较多，感情难称心。</li>
                                            <li runat="server" id="li4" style="display: none;"><span style="background-position: -70px -70px"></span>虫子代表感情常因外力因素而破裂，被迫的分开，自己很难改变。</li>
                                            <li runat="server" id="li5" style="display: none;"><span style="background-position: -10px -130px"></span>红杏代表你在结婚后被劈腿的可能性比较大。<%--<a href="#" target="_blank">转运秘籍</a>--%></li>
                                            <li runat="server" id="li6" style="display: none;"><span style="background-position: -70px -130px"></span>冰冻代表感情忽冷忽热，频繁的分手，冷暴力，莫名的疏离感不亲近。</li>
                                            <li runat="server" id="li7" style="display: none;"><span style="background-position: -10px -190px"></span>裂痕代表老是挑剔对方，争吵较多，尤其感情中后期缺少柔情蜜意。</li>
                                            <li runat="server" id="li8" style="display: none;"><span style="background-position: -70px -190px"></span>醋瓶代表你在感情中容易陷入三角恋，容易吃醋，比较情绪化。</li>
                                        <li runat="server" id="li9" style="display: none;"><span style="background-position: -130px -10px"></span>枯叶代表对待感情过于自信，出现了问题又不以为然，结果导致难以挽回。</li>
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
                                        魅力指数：<asp:Literal ID="ltr2" runat="server"></asp:Literal>%
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
