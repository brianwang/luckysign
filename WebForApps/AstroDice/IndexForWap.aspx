<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexForWap.aspx.cs" Inherits="WebForApps.AstroDice.IndexForWap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="format-detection" content="telephone=no" />
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <script src="../WebResources/js/jquery-1.4.1.min.js"></script>
    <%--<script type="text/javascript" src="js/jquery-scrollable.js"></script>
    <script type="text/javascript" src="js/comm.js"></script>
    <script type="text/javascript" src="js/get_list_tuan.js"></script>
    <script type="text/javascript" src="js/WeixinApi.js"></script>--%>
    <meta content="上上签占星骰子" name="description" />
    <title>占星骰子_上上签</title>
    <link type="text/css" rel="stylesheet" href="../WebResources/HTML5/AstroDice/global.css" />
    <%--<link type="text/css" rel="stylesheet" href="css/red.css">
    <link type="text/css" rel="stylesheet" href="css/message.css">--%>
</head>
<body class="index">
    <form id="form1" runat="server">
        <div id="content">
            <div id="top" style="width: 100%; height: 150px; margin: 0 auto; position: relative;">
                <asp:TextBox ID="TextBox1" BorderStyle="None" runat="server" Style="position: absolute; left: 60px; top: 85px; height: 35px; width: 57%; background-color: transparent; color: #0ff; font-size: 20px; font-family: 'Microsoft YaHei'"></asp:TextBox>
                <div id="begin" class="begin" onmousedown="javascript:$(this).css('background-image', 'url(../WebResources/HTML5/AstroDice/go_btn_2_03.png)');" onmouseup="javascript:$(this).css('background-image', 'url(../WebResources/HTML5/AstroDice/go_btn_1_03.png)');" onclick="javascript:run();" style="position: absolute; width: 30%; height: 70px; left: 440px; top: 68px; background: url(../WebResources/HTML5/AstroDice/go_btn_1_03.png) no-repeat; background-size: 100%; cursor:pointer;"></div>
            </div>
            <section id="sec" style="width: 100%; height: 640px; margin: 0 auto; position: relative; overflow: hidden;">

                <div id="Div1" style="height: 640px; width: 100%; position: absolute; background: url(../WebResources/HTML5/AstroDice/astro_circle.png) no-repeat; background-size: 100%; left: 0px; top: 0px;"></div>
                <div id="rotate1" style="height: 640px; width: 100%; position: absolute; background: url(../WebResources/HTML5/AstroDice/astro_xz.png) no-repeat; background-size: 100%; left: 0px; top: 0px;"></div>
                <div id="rotate2" style="height: 640px; width: 100%; position: absolute; background: url(../WebResources/HTML5/AstroDice/Light/delta.png) no-repeat; background-size: 100%; left: 0px; top: 0px;"></div>
                <div id="num1" class="num high1" style="z-index: -999"></div>
                <div id="num2" class="num high2" style="z-index: -999"></div>
                <div id="num3" class="num high3" style="z-index: -999"></div>
                <div id="num4" class="num high4"></div>
                <div id="num5" class="num high5" style="z-index: -999"></div>
                <div id="num6" class="num high6" style="z-index: -999"></div>
                <div id="num7" class="num high7" style="z-index: -999"></div>
                <div id="num8" class="num high8" style="z-index: -999"></div>
                <div id="num9" class="num high9" style="z-index: -999"></div>
                <div id="num10" class="num high10" style="z-index: -999"></div>
                <div id="num11" class="num high11" style="z-index: -999"></div>
                <div id="num12" class="num high12" style="z-index: -999"></div>
                <canvas id="mycanvas" width="640" height="640" style="position: absolute;">Your browser does not support the HTML5 canvas tag. </canvas>

            </section>
            <%--<section class="red-packet packet-close" id="card">
            <div class="packet-card" id="prize"></div>
            <div class="packet-body">
                <div id="logo">
                    <img src="images/logo.png" alt="超级亲友团">
                </div>
                <div id="red-tips" class="packet-lottery-title-left f-biger" style="display: block;"><!--又一大波红包来袭：<br />充话费闪电到账，这回妥了！--><div style="margin:0 15px;font-size:15px;">大波话费红包，分享可赢Gear S，妥了</div></div>
                <div id="scroll" style="display: block;">
                    <div class="line"></div>
                    <div style="position: relative; overflow: hidden; width: 288px; height: 38px;"><div style="position: absolute; overflow: hidden; top: 0px; left: 0px; width: 288px; height: 760px; margin-top: -281.200000000393px;"><ol><li>1元</li><li>4元</li><li>3元</li><li>2元</li><li>6元</li><li>5元</li><li>7元</li><li>8元</li><li>9元</li><li>10元</li></ol><ol><li>1元</li><li>4元</li><li>3元</li><li>2元</li><li>6元</li><li>5元</li><li>7元</li><li>8元</li><li>9元</li><li>10元</li></ol></div></div>
                    <div class="line"></div>
                </div>
                <div id="my_total_money" class="f-biger f-card t-center pd20-0" style="display: none;">
                    当前余额：<span class="f-huge">￥0</span>
                </div>
                <div id="luck-draw">
                    <input type="button" class="btn-1 w-full" value="抢红包" id="submitBtn" style="">
                </div>
            </div>
            <div id="wx-overlay" style="display: none">
                <img style="width: 80%" src="images/share.png">
            </div>
        </section>--%>、
            <div id="resultdiv" style="width:100%; height:186px; background: url(../WebResources/HTML5/AstroDice/jieguo_08.png) no-repeat bottom; background-size: 100%;text-align:center;  position: relative;">
                <%--<div style="float:left; width:20%; height:242px; background: url(../WebResources/HTML5/AstroDice/ren_08.png) no-repeat bottom; background-size: 100%;"></div>--%>
               <%-- <div style="float:left; width:100%;height:100%;padding:100px 50px 45px 0px;">--%>
                    <span id="result" style="color: saddlebrown; font-size: 20px; font-family: 'Microsoft YaHei';margin-right:50px;position: absolute; left: 50px; top: 45px;"></span></div>
            <%--</div>--%>
        </div>
        <%--<div class="bottom">
            <p onclick="javascript:run();">开始</p>
            <p onclick="javascript:location.href='Tuan_Rule.aspx';">活动规则</p>
        </div>--%>
    </form>
    <script type="text/javascript" src="../WebResources/HTML5/AstroDice/dice.js"></script>
</body>
</html>
