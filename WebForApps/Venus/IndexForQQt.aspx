<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexForQQt.aspx.cs" Inherits="WebForApps.Venus.IndexForQQt" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>金星星座看爱情-上上签</title>
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

        .wrapper {
            width: 760px;
            margin: auto;
        }

        .head {
            background: url(../WebResources/Images/Venus/head.jpg) no-repeat;
            height: 143px;
            width: 213px;
            padding-top: 287px;
            padding-left: 547px;
            position: relative;
        }

        .head_a {
            display: block;
            width: 58px;
            height: 57px;
        }

        .head_btn {
            position: absolute;
            top: 308px;
            left: 618px;
            width: 109px;
            height: 39px;
            cursor: pointer;
        }

        .bot1 {
            background: url(../WebResources/Images/Venus/bot1.jpg);
            width: 760px;
            height: 409px;
            text-align: center;
            padding-top: 81px;
            font-size: 20px;
            font-family: "微软雅黑";
            color: #303030;
            font-weight: normal;
        }

            .bot1 h1 {
                font-size: 22px;
                font-family: "微软雅黑";
                color: #303030;
                font-weight: normal;
                margin-bottom: 40px;
            }

            .bot1 select {
                font-family: Verdana, Arial, Helvetica, sans-serif;
                vertical-align: top;
                margin-top: 4px;
            }

        .bot_btn {
            margin-top: 45px;
            text-align: center;
        }

            .bot_btn a {
                width: 196px;
                height: 73px;
                display: block;
                background: url(../WebResources/Images/Venus/button_yellow1_link.jpg);
                cursor: pointer;
                margin: auto;
            }

                .bot_btn a:hover {
                    background: url(../WebResources/Images/Venus/button_yellow1_hover.jpg);
                }

                .bot_btn a:active {
                    background: url(../WebResources/Images/Venus/button_yellow1_press.jpg);
                }

        .bot2 {
            background: url(../WebResources/Images/Venus/bot1.jpg);
            width: 620px;
            height: 465px;
            padding: 25px 70px 0px 70px;
            font-size: 15px;
            font-family: "微软雅黑";
            color: #823537;
            font-weight: normal;
            position: relative;
            line-height: 150%;
        }

            .bot2 h1 {
                font-size: 22px;
                font-family: "微软雅黑";
                color: #BA181E;
                font-weight: normal;
                margin-bottom: 20px;
            }

        .again {
            width: 137px;
            height: 53px;
            background: url(../WebResources/Images/Venus/button_yellow_link.jpg);
            cursor: pointer;
            position: absolute;
            top: 267px;
            left: 305px;
        }

            .again:hover {
                background: url(../WebResources/Images/Venus/button_yellow_hover.jpg);
            }

            .again:active {
                background: url(../WebResources/Images/Venus/button_yellow_press.jpg);
            }

        .share {
            width: 176px;
            height: 53px;
            background: url(../WebResources/Images/Venus/button_lan_link.jpg);
            cursor: pointer;
            position: absolute;
            top: 267px;
            left: 538px;
        }

            .share:hover {
                background: url(../WebResources/Images/Venus/button_lan_hover.jpg);
            }

            .share:active {
                background: url(../WebResources/Images/Venus/button_lan_press.jpg);
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="wrapper">
                        <div class="head">
                            <a href="http://t.qq.com/iamsnowsnow" title="蓝雪鳯兒" class="head_a"></a>
                            <div class="head_btn" id="nofriend1" runat="server">
                                <asp:LinkButton ID="LinkButton6" runat="server" ToolTip="收听" OnClick="LinkButton1_Click"><img src="../WebResources/Images/Venus/button_red_link.jpg" style="border:none;" /></asp:LinkButton>
                            </div>
                            <div class="head_btn" id="isfriend1" runat="server" style="cursor:default;">
                                <img src="../WebResources/Images/Venus/button_red_grey.jpg" />
                            </div>
                        </div>
                        <div class="bot1">
                            <h1>请输入您的阳历生日：</h1>
                            <asp:DropDownList ID="ddlYear" runat="server" onchange="setDays(this,form1.ddlMonth,form1.ddlDay);SetYear(this);"></asp:DropDownList>
                            年
	<asp:DropDownList ID="ddlMonth" runat="server" onchange="setDays(form1.ddlYear,this,form1.ddlDay);SetMonth(this);"></asp:DropDownList>
                            月
	<asp:DropDownList ID="ddlDay" runat="server" onchange="SetDay(this);"></asp:DropDownList>
                            日
	<asp:DropDownList ID="ddlHour" runat="server" onchange="SetHour(this);"></asp:DropDownList>
                            时
	<asp:HiddenField ID="hfYear" runat="server" Value="1988" />
                            <asp:HiddenField ID="hfMonth" runat="server" Value="1" />
                            <asp:HiddenField ID="hfDay" runat="server" Value="1" />
                            <asp:HiddenField ID="hfHour" runat="server" Value="12" />
                            <div class="bot_btn">
                                <asp:LinkButton ID="LinkButton4" runat="server" ToolTip="开始测算" OnClick="Button1_Click"></asp:LinkButton>
                            </div>

                        </div>
                    </div>
                    <script type="text/javascript" src="../WebResources/JS/jquery-1.4.1.min.js"></script>
                    <script type="text/javascript">
                        $(function () {
                            var i = -1;
                            //添加年份，从1910年开始
                            for (i = 1910; i <= new Date().getFullYear() ; i++) {
                                addOption(form1.ddlYear, i, i - 1909);
                                //默认选中1988年
                                if (i == 1988) {
                                    form1.ddlYear.options[i - 1910].selected = true;
                                }
                            }
                            //添加月份
                            for (i = 1; i <= 12; i++) {
                                addOption(form1.ddlMonth, i, i);
                            }
                            //添加天份，先默认31天
                            for (i = 1; i <= 31; i++) {
                                addOption(form1.ddlDay, i, i);
                            }
                        });

                        //设置每个月份的天数
                        function setDays(year, month, day) {
                            var monthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
                            var yea = year.options[year.selectedIndex].text;
                            var mon = month.options[month.selectedIndex].text;
                            var num = monthDays[mon - 1];
                            if (mon == 2 && isLeapYear(yea)) {
                                num++;
                            }
                            for (var i = day.options.length - 1; i >= 0; i--) {
                                day.remove(i);
                            }
                            for (var i = 1; i <= num; i++) {
                                addOption(form1.ddlDay, i, i);
                            }
                        }

                        //判断是否闰年
                        function isLeapYear(year) {
                            return (year % 4 == 0 || (year % 100 == 0 && year % 400 == 0));
                        }

                        //向select尾部添加option
                        function addOption(selectbox, text, value) {
                            var option = document.createElement("option");
                            option.text = text;
                            option.value = value;
                            selectbox.options.add(option);
                        }

                        function SetYear(year) {
                            form1.hfYear.value = year.options[year.selectedIndex].text;
                        }
                        function SetMonth(month) {
                            form1.hfMonth.value = month.options[month.selectedIndex].text;
                        }
                        function SetDay(day) {
                            form1.hfDay.value = day.options[day.selectedIndex].text;
                        }
                        function SetHour(hour) {
                            form1.hfHour.value = hour.options[hour.selectedIndex].text;
                        }
                    </script>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="wrapper">
                        <div class="head">
                            <a href="http://t.qq.com/iamsnowsnow" title="蓝雪鳯兒" class="head_a"></a>
                            <div class="head_btn" id="nofriend2" runat="server">
                                <asp:LinkButton ID="LinkButton7" runat="server" ToolTip="收听" OnClick="LinkButton1_Click"><img src="../WebResources/Images/Venus/button_red_link.jpg" style="border:none;" /></asp:LinkButton>
                            </div>
                            <div class="head_btn" id="isfriend2" runat="server" style="cursor:default;">
                                <img src="../WebResources/Images/Venus/button_red_grey.jpg" />
                            </div>
                        </div>
                        <div class="bot2">
                            <h1>
                                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></h1>
                            <asp:Literal ID="ltrContext" runat="server"></asp:Literal>
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="again" ToolTip="再测一次" OnClick="LinkButton3_Click"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="share" ToolTip="分享到腾讯微博" OnClick="LinkButton2_Click"></asp:LinkButton>
                        </div>
                    </div>

                </asp:View>
            </asp:MultiView>
        </div>
    </form>
    

</body>
</html>
