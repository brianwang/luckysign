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
    <script type="text/javascript">
        $(function () {
            //showItem("paopao", 3);  //泡泡等级3 下同
            //showItem("mifeng", 2);
            //showItem("chongzi", 2);
            //showItem("cu", 2);
            //showItem("liehen", 2);
            //showItem("huapen", 3);
            //showItem("bingdong", 2);
            //showItem("hongxing", 1);  //红杏显示  隐藏0
            //showItem("hua", 6);		//第六朵花
            //showItem("zhezhi", 0);	//折纸隐藏
        })

        $(function () {
            $(document).bind("click", function (e) {
                var target = $(e.target);
                if (target.closest(".sub-nav").length == 0 && target.closest(".select").length == 0) {
                    $(".sub-nav").hide();
                }
            })
        })

        function refreshdistrict() {
            $("#Div1").css("display", "none");
            $("#Div2").children("a").click(function () {
                $(this).parent().parent().children("span").text($(this).text());
                //$(this).parent().css("display","none");
                $("#HiddenField2").val($(this).attr("id"));
            });
            $("#Div2").parent().click(function () {
                if ($("#Div2").parent().children(".sub-nav").css("display") == "none") {
                    $(".sub-nav").hide();
                    $("#Div2").parent().children(".sub-nav").css("display", "");
                }
                else {
                    $(".sub-nav").hide();
                    $("#Div2").parent().children(".sub-nav").css("display", "none");
                }
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
                if ($(this).children(".sub-nav").css("display") == "none") {
                    $(".sub-nav").hide();
                    $(this).children(".sub-nav").css("display", "");
                }
                else {
                    $(".sub-nav").hide();
                    $(this).children(".sub-nav").css("display", "none");
                }
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
            });
        }

        //判断是否闰年
        function isLeapYear(year) {
            return (year % 4 == 0 || (year % 100 == 0 && year % 400 == 0));
        }

    </script>
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
                            <div class="x-left">
                                <div class="flash">
                                    <div class="login-box">
                                        <div class="login-list">
                                            <ul>
                                                <li>
                                                    <div class="select">
                                                        <span id="yearspan" runat="server">1995</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subyear" style="width: 56px; display: none;">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="monthspan" runat="server">1</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="submonth" style="display: none;">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="dayspan" runat="server">1</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subday" style="display: none;">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="hourspan" runat="server">12</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subhour" style="display: none;">
                                                        </div>
                                                    </div>
                                                    <div class="select" style="width: 30px;">
                                                        <span id="minitespan" runat="server">0</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="subminite" style="display: none;">
                                                        </div>
                                                    </div>
                                                </li>
                                                <asp:HiddenField ID="HiddenField4" runat="server" />
                                                <li style="padding-left: 50px">
                                                    <div class="select" style="width: 120px;">
                                                        <span id="district1" runat="server">北京市</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="Div1" style="display: none;">
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
                                                            <div class="select" style="width: 100px;">
                                                                <span id="district2" runat="server"></span>
                                                                <img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                                <div class="sub-nav" id="Div2" style="display: none;">
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

                                                <li style="padding-left: 40px">
                                                    <a href="#" title="夏令时" class="select-a"></a>
                                                    <div id="drp0" class="select">
                                                        <span>自动判断</span><img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                        <div class="sub-nav" id="sub0" style="width: 56px; display: none;">
                                                            <a id="2">自动判断</a>
                                                            <a id="1">是</a>
                                                            <a id="0">否</a>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
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
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                    </ul>
                                </div>

                                <div class="shouting">
                                    <div class="shouting-t">更多爱情占星攻略请关注</div>
                                    <div class="shouting-c">
                                        <ul>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="x-right">



                                <div class="x-right-t">爱情攻略</div>
                                <div class="x-right-c">
                                    <ul>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                    </ul>
                                </div>

                                <div class="shouting">
                                    <div class="shouting-t">更多爱情占星攻略请关注</div>
                                    <div class="shouting-c">
                                        <ul>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                </div>

                            </div>

                            <div class="clear"></div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <div class="x-left">
                                <div class="flash">
                                    <div class="f-box">

                                        <div class="tip" style="display: none;">
                                            <div class="tip-close">
                                                <a href="#">
                                                    <img src="../WebResources/Images/LoveRose/img/close.gif"></a>
                                            </div>
                                            <div class="tip-box">
                                                <h1>向日葵 ：执着  自信</h1>
                                                <div class="tip-content">
                                                    让我们先来看一个关于向日葵的美丽传说：克丽泰是一位水泽仙女。一天，她在树林里遇见了正在狩猎的太阳神阿波罗，疯狂地爱上了他。可是，阿波罗连正眼也不瞧她一下就走了。克丽泰热切地盼望有一天阿波罗能对她说说话，但她却再也没有遇见过他。她只能每天仰望天空，看着阿波罗驾着金碧辉煌的太阳轮划过天空，直到他下山。后来，众神怜悯她，把她了一朵很大的向日葵，永远向着太阳，诉说她永远不变的爱慕。<br>
                                                    <br>
                                                    因此，向日葵寓意传说中的高富帅才是你的梦中情人，犹如太阳神阿波罗，是古希腊神话中的花样美男，超高的音乐才华，九头身的完美身材，以至于古希腊的雕刻艺术常借他的形象来表现男性之美，并且家世显赫，是众神之王宙斯与暗夜女神之子。向日葵也代表你是很有品味的人，所以对待异性的要求自然不低。就性格而言，你也喜欢心智成熟，霸道一点的异性，一定要是超自信超幽默的，唯唯诺诺，害羞胆怯的男生是难入你法眼的。<br>
                                                    <br>
                                                    向日葵也代表你对爱情的忠诚与专一，不管你以什么方式开始一段感情，你都希望能有一个好的结果，对对方也是尽心尽力，关怀备至。但时间长了，你可能会比较迟钝，明明你们的感情已经出现了问题，但你还是一如既往的认为你们感情很好很恩爱，所以裂痕一旦显露出来，就会让你难以接受，伤心复原期通常会是别人的两倍。 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="f-a-box">
                                            <asp:LinkButton ID="LinkButton2"  CssClass="f-a" runat="server">转发到微博</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" CssClass="f-a" runat="server">再测一次</asp:LinkButton>
                                            <div class="clear"></div>
                                        </div>
                                        <!--泡泡-->
                                        <div class="paopao">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--蜜蜂-->
                                        <div class="mifeng">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--虫子-->
                                        <div class="chongzi">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--醋-->
                                        <div class="cu">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--裂痕-->
                                        <div class="liehen">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--花盆-->
                                        <div class="huapen">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--冰冻-->
                                        <div class="bingdong">
                                            <div class="level-1"></div>
                                            <div class="level-2"></div>
                                            <div class="level-3"></div>
                                        </div>

                                        <!--红杏-->
                                        <div class="hongxing"></div>

                                        <!--花-->
                                        <div class="hua">
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
                                        <div class="zhezhi"></div>
                                    </div>
                                </div>
                                <div class="yuansu">
                                    <div class="yuansu-t"></div>
                                    <div class="yuansu-c">
                                        <ul>
                                            <li><span style="background-position: -10px -10px"></span>蜜蜂的数量代表了你对异性的吸引力，如果同时出现蝴蝶说明你是桃花很旺的人。</li>
                                            <li><span style="background-position: -70px -10px"></span>泡泡代表你经常遇人不淑，看错人，并在感情中存在不切实际的幻想。</li>
                                            <li><span style="background-position: -10px -70px"></span>泡泡代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li><span style="background-position: -70px -70px"></span>泡泡代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li><span style="background-position: -10px -130px"></span>红杏代表你遭遇被劈腿的可能性很大。<a href="#">转运秘籍</a></li>
                                            <li><span style="background-position: -70px -130px"></span>泡泡代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li><span style="background-position: -10px -190px"></span>泡泡代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
                                            <li><span style="background-position: -70px -190px"></span>泡泡代表你在爱情或婚姻中受到了海王星的负面影响，容易看走眼，遇人不淑。</li>
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
                                        稳定指数：70%
                <div class="c1"><span style="width: 90px"></span></div>
                                    </div>
                                    <div class="per">
                                        魅力指数：70%
                <div class="c2"><span style="width: 90px"></span></div>
                                    </div>
                                    <div class="per">
                                        旺夫指数：70%
                <div class="c3"><span style="width: 90px"></span></div>
                                    </div>
                                    <div class="per">
                                        花心指数：70%
                <div class="c4"><span style="width: 90px"></span></div>
                                    </div>
                                    <div class="per">
                                        嫁个有钱人指数：70%
                <div class="c5"><span style="width: 90px"></span></div>
                                    </div>
                                </div>

                                <div class="x-right-t">爱情攻略</div>
                                <div class="x-right-c">
                                    <ul>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                        <li><a href="#">如何打动金星双子座？</a></li>
                                    </ul>
                                </div>

                                <div class="shouting">
                                    <div class="shouting-t">更多爱情占星攻略请关注</div>
                                    <div class="shouting-c">
                                        <ul>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                            <li>
                                                <img src="img/img.jpg"><span>蓝雪鳳兒</span><a href="#">+收听</a></li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                </div>

                            </div>

                            <div class="clear"></div>
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Literal ID="Label1" runat="server"></asp:Literal>
    </form>
</body>
</html>
