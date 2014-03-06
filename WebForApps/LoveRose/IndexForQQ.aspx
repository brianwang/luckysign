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
            showItem("paopao", 3);  //泡泡等级3 下同
            showItem("mifeng", 2);
            showItem("chongzi", 2);
            showItem("cu", 2);
            showItem("liehen", 2);
            showItem("huapen", 3);
            showItem("bingdong", 2);
            showItem("hongxing", 1);  //红杏显示  隐藏0
            showItem("hua", 6);		//第六朵花
            showItem("zhezhi", 0);	//折纸隐藏
        })
        function initialselect() {
            $(".select").click(function () {
                if ($(this).parent().children(".sub-nav").css("display") == "none") {
                    $(this).parent().children(".sub-nav").css("display") = "";
                }
                else {
                    $(this).parent().children(".sub-nav").css("display") = "none";
                }
            });
        }
    </script>
    <link href="../WebResources/Images/LoveRose/css/common.css" type="text/css" rel="stylesheet" />
</head>
<body style="">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <div class="login-box">
                                <div class="login-list">
                                    <ul>
                                        <li>
                                            <div class="select">
                                                1995<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                <div class="sub-nav" id="subyear" style="width: 56px">
                                                </div>
                                            </div>
                                            <div class="select">12<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                <div class="sub-nav" id="submonth" style="width: 56px">
                                                </div>
                                            </div>
                                            <div class="select">12<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                <div class="sub-nav" id="subday" style="width: 56px">
                                                </div>
                                            </div>
                                            <div class="select">12<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                <div class="sub-nav" id="subhour" style="width: 56px">
                                                </div>
                                            </div>
                                            <div class="select">12<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                <div class="sub-nav" id="subminite" style="width: 56px">
                                                </div>
                                            </div>
                                        </li>
                                        <li style="padding-left: 50px">
                                            <div class="select">新疆<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle"></div>
                                            <div class="select">乌鲁木齐<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle"></div>
                                        </li>
                                        <li style="padding-left: 110px">
                                            <div id="drp0" class="select">自动判断<img src="../WebResources/Images/LoveRose/img/arrow.gif" align="absmiddle">
                                                <div class="sub-nav" id="sub0" style="width: 56px">
                                                    <a href="#">是</a>
                                                    <a href="#">否</a>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <div class="login-button">
                                    <a href="#"></a>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <div class="f-box">
                                <div class="tip">
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
                        </asp:View>
                    </asp:MultiView>

                    <asp:UpdatePanel ID="UpdatePanela" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <span class="fred">*</span><strong>阳历生日：</strong>
                            <uc1:DatePicker ID="DatePicker1" runat="server" Type="3"></uc1:DatePicker>
                            <%-- <asp:CheckBox ID="chkDaylight1" runat="server" />
                <span class="fsred"><strong>夏令时</strong></span>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <span class="fred">*</span><strong>出生地点：</strong>
                            <uc1:District ID="District1" runat="server"></uc1:District>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:ImageButton runat="server" ID="ImageButton1" OnClick="Unnamed1_Click" />

                    <asp:Button ID="Button1" runat="server" Text="统计" OnClick="Button1_Click" />

                    <br />
                    <br />
                    <div id="flashmov" align="center">

                        <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                        <asp:Literal ID="Label1" runat="server"></asp:Literal>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>



    </form>

</body>
</html>
