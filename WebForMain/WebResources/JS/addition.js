//GetForm
function getform(input) {
    var _obj = input.parentNode;
    while (_obj.tagName.toUpperCase() != "FROM") {
        _obj = _obj.parentNode;
    }
}
// Reg
function checkAgree(chk) {
    if (chk.checked) {
        $("#Unnamed3").removeClass("btn_0");
        $("#Unnamed3").addClass("btn_1");
    }
    else {
        $("#Unnamed3").removeClass("btn_1");
        $("#Unnamed3").addClass("btn_0");
    }
}



$(document).ready(function() {
    //paipan
    $(".blocks:even").addClass("even");
    $(".tabs a").click(function() {
        $(this).parent().children("a").removeClass("on");
        $(this).addClass("on");
        idx = $(this).parent().children("a").index(this);
        $(".pp").children(".block").removeClass("show");
        $(".pp").children(".block").eq(idx).addClass("show");
        $(".pp").parent().children(".block").removeClass("show");
        $(".pp").parent().children(".block").eq(idx).addClass("show");
        $("#ctl00_ContentPlaceHolder1_hdType").val((idx + 1) * 10);
        if (idx == 2) {
            $(".stab").addClass("show");
            $(".stab").children("a").removeClass("on");
            $(".stab").children("a").eq(0).addClass("on");
        }
        else {
            $(".stab").removeClass("show");
        }
    });
    $(".stab a").click(function() {
        $(this).parent().children("a").removeClass("on");
        $(this).addClass("on");
        idx = $(this).parent().children("a").index(this);
        $(".pp").children(".block").removeClass("show");
        $(".pp").children(".block").eq(idx + 2).addClass("show");
        $(".stab").addClass("show");
        $("#ctl00_ContentPlaceHolder1_hdType").val(parseInt(parseInt($("#ctl00_ContentPlaceHolder1_hdType").val()) / 10) * 10 + idx + 1);
    })
    var box_taFlag = 0
    $(".box_ta").unbind();
    $(".box_ta").click(function() {
        if ($(this).parent().parent().children(".box_c").css("display") == "block") {
            $(this).css("background-position", "right top");
            $(this).parent().parent().children(".box_c").toggle();
        }
        else {
            $(this).css("background-position", "right bottom");
            $(this).parent().parent().children(".box_c").toggle();
        }
    });
    $(".index_left_new_item span").click(function () {
        $(this).parent().children("span").removeClass("on");
        $(this).addClass("on");
        idx = $(this).parent().children("span").index(this);
        $(this).parent().parent().parent().children(".block").removeClass("show");
        $(this).parent().parent().parent().children(".block").eq(idx).addClass("show")
    });

})