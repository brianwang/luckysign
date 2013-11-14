// JavaScript Document
$(document).ready(SetDocument())

function SetDocument() { 
$(".blocks:even").addClass("even");
    $(".tabs a").click(function () {
        $(this).parent().children("a").removeClass("on");
        $(this).addClass("on");
        idx = $(this).parent().children("a").index(this);
        $(this).parent().parent().children(".block").removeClass("show");
        $(this).parent().parent().children(".block").eq(idx).addClass("show");
        //$(".pp").parent().children(".block").removeClass("show");
        //$(".pp").parent().children(".block").eq(idx).addClass("show");
    });
    $(".stab a").click(function () {
        $(this).parent().children("a").removeClass("on");
        $(this).addClass("on");
        idx = $(this).parent().children("a").index(this);
        $(this).parent().parent().children(".sblock").removeClass("show");
        $(this).parent().parent().children(".sblock").eq(idx).addClass("show")
    })
    var box_taFlag = 0;
    $(".tlk_tt").click(function () {

        if ($(this).parent().parent().attr("class") == "s_tlk2 left") {
            $(this).parent().parent().addClass("s_tlk2s");
            $(this).css("background-position", "right bottom");
        }
        else {
            $(this).parent().parent().removeClass("s_tlk2s");
            $(this).css("background-position", "right top");
        }
    })
    $(".box_ta").unbind();
    $(".box_ta").click(function () {
        if ($(this).parent().parent().children(".box_c").css("display") == "block") {
            $(this).css("background-position", "right top");
            $(this).parent().parent().children(".box_c").toggle();
        }
        else {
            $(this).css("background-position", "right bottom");
            $(this).parent().parent().children(".box_c").toggle();
        }
    })
    //regist
    if ($.formValidator) {
        $.formValidator.initConfig({ formID: "form1", debug: false, submitOnce: true,
            onError: function (msg, obj, errorlist) {
                $("#errorlist").empty();
                $.map(errorlist, function (msg) {
                    $("#errorlist").append("<li>" + msg + "</li>")
                });
                alert(msg);
            },
            submitAfterAjaxPrompt: '有数据正在异步验证，请稍等...'
        });

        $("#ctl00_ContentPlaceHolder1_email").formValidator({ onShow: "", onFocus: "<b><span class='fred'>重要！</span>请填写<span class='fred'>有效邮箱地址</span>，以验证完成注册。</b>", onCorrect: " ", defaultValue: "@" }).inputValidator({ min: 6, max: 100, onError: "邮箱至少<span class='fred'>6</span>个字符,最多<span class='fred'>100</span>个字符" }).regexValidator({ regExp: "^([\\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", onError: "<span class='err'> </span>你输入的邮箱格式不正确" });
        $("#ctl00_ContentPlaceHolder1_password1").formValidator({ onShow: "", onFocus: "请输入密码,至少<span class='fred'>6</span>位", onCorrect: " " }).inputValidator({ min: 6, empty: { leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空格符" }, onError: "密码不能为空或少于6位,请确认" });
        $("#ctl00_ContentPlaceHolder1_password2").formValidator({ onShow: "", onFocus: "输再次输入密码", onCorrect: " " }).inputValidator({ min: 6, empty: { leftEmpty: false, rightEmpty: false, emptyError: "重复密码两边不能有空格符" }, onError: "重复密码不能为空,请确认" }).compareValidator({ desID: "ctl00_ContentPlaceHolder1_password1", operateor: "=", onError: "2次密码不一致,请确认" });
        $("#ctl00_ContentPlaceHolder1_name").formValidator({ onShow: "", onFocus: "请输入您在上上签的通用名,最多<span class='fred'>10</span>个字", onCorrect: " " }).inputValidator({ min: 1, max: 10, onError: "名号不能为空且最多10个字符,请确认" });
        $("#ctl00_ContentPlaceHolder1_code").formValidator({ onShow: "", onFocus: "请输入上面图片中的文字", onCorrect: " " }).inputValidator({ min: 4, max: 4, onError: "验证码输入有误,请确认" });
    }
    //regist end
}

//ziweipaipan
function checkrealtime(chk) {
    if (chk.checked) {
        $("#ctl00_ContentPlaceHolder1_UpdatePanelb").addClass("show");
        $("#ctl00_ContentPlaceHolder1_UpdatePanelb").removeClass("block");
    }
    else {
        $("#ctl00_ContentPlaceHolder1_UpdatePanelb").removeClass("show");
        $("#ctl00_ContentPlaceHolder1_UpdatePanelb").addClass("block");
    }
}

function qaTypeChanged(drp) {
    if (drp.selectedIndex == 0) {
        $("#info2").addClass("block");
        $("#info2").removeClass("show");
        $("#info1").addClass("block");
        $("#info1").removeClass("show");
    }
    else if (drp.selectedIndex == 1) {
        $("#info1").addClass("show");
        $("#info1").removeClass("block");
        $("#info2").addClass("block");
        $("#info2").removeClass("show");
    }
    else if (drp.selectedIndex == 2) {
        $("#info1").addClass("show");
        $("#info1").removeClass("block");
        $("#info2").addClass("show");
        $("#info2").removeClass("block");
    }
}

function qaCateChanged(drp) {
    if (drp.selectedIndex == 3) {
        document.getElementById("ctl00_ContentPlaceHolder1_drpType").selectedIndex = 0;
        qaTypeChanged(document.getElementById("ctl00_ContentPlaceHolder1_drpType"));
    }
    else if (drp.selectedIndex == 1) {
        document.getElementById("ctl00_ContentPlaceHolder1_drpType").selectedIndex = 2;
        qaTypeChanged(document.getElementById("ctl00_ContentPlaceHolder1_drpType"));
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_drpType").selectedIndex = 1;
        qaTypeChanged(document.getElementById("ctl00_ContentPlaceHolder1_drpType"));
    }
}

function sansi(input) {
    var gong = input.id.replace("gong", "");
    for (var i = 0; i < 12; i++) {
        if ((i - gong + 12) % 4 == 0 || (i - gong + 12) % 6 == 0) {
            $('#gong' + i).css("background-color", "#ff2a01");
            $('#gong' + i).css("color", "#EEEEEE");
        }
        else {
            $('#gong' + i).css("background-color", "");
            $('#gong' + i).css("color", "#ff2a01");
        }
    }
}
function liusansi(input) {
    var gong = input;
    for (var i = 0; i < 12; i++) {
        if ((i - gong + 12) % 4 == 0 || (i - gong + 12) % 6 == 0) {
            $('#gong' + i).css("background-color", "#ff2a01");
            $('#gong' + i).css("color", "#EEEEEE");

            $('#yun' + i).css("background-color", "#149e11");
            $('#yun' + i).css("color", "#EEEEEE");

            $('#liu' + i).css("background-color", "#005995");
            $('#liu' + i).css("color", "#EEEEEE");
        }
        else {
            $('#gong' + i).css("background-color", "");
            $('#gong' + i).css("color", "#ff2a01");

            $('#yun' + i).css("background-color", "");
            $('#yun' + i).css("color", "#149e11");

            $('#liu' + i).css("background-color", "");
            $('#liu' + i).css("color", "#005995");
        }
    }
}
$(function () {
    $(".login_button").mouseover(function () {
        $(this).css("background-color", "#f7796d")
    }).mouseover(function () {
        $(this).css("background-color", "#A5534C")
    })

})