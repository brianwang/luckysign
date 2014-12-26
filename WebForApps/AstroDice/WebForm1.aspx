<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebForApps.AstroDice.WebForm1" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>无标题文档</title>
<style type="text/css">
/*---CSS变形,transform的使用----*/
.rotate3 {
  /* -webkit-transform: matrix(1,0.5,1,1,1,1); */
 
    margin: 100px auto;
    background:red;
    width: 100px;
    height: 100px; 
    /*-webkit-transform-origin:top left;
     -webkit-transform:rotate(20deg);*/
    /*-webkit-transition:transfrom 2s;*/
    /*-webkit-transition-property:transform;
    -webkit-transition-duration:2s;*/
    /*-webkit-transition-delay:3s//表示延迟的时间*/
    /*-webkit-transition:width 2s;
    -webkit-transition-timing-function:ease;*/
}
.rotate3:hover{
    /*-webkit-transform: scale3d(2,3,5);*/
    /*background:yellow;*/
    /*width:200px;*/
    /*-webkit-transform:rotate(90deg)*/
    /*-webkit-transform:matrix(2,1.5,1,1,80,30);*/
    /*-webkit-transform-origin:50px 70px;
     -webkit-transform:rotate(20deg);*/
    /*-webkit-transform:skew(20deg,50deg)//表示倾斜*/
    /*-webkit-transform:translate(100px,100px)//表示移动*/
    /*-webkit-transform:scale(-1)*/
    /*-webkit-transform:scale(2)//放大效果，一个参数表示宽，高同时放大到这个值*/
    /*-webkit-transform:scale(0.5)//缩小效果*/
    /*-moz-transform:rotate(-20deg);//翻转效果
    -webkit-transform:rotate(-20deg);*/
    }
 
#nav a{ background-color:red; }
    #nav a:hover, #nav a:focus{
        background-color:blue;
        /* 告诉转换去应用到background-color 属性(看起来像一个CSS 参数，不是吗？ #foreshadowing)*/
        -webkit-transition-property:background-color;
        -o-transition-property:background-color;
        /* 让它持续两秒钟*/
        -webkit-transition-duration:2s;
        -o-transition-duration:2s;
}
</style>
</head>
 
<body>
<div id="rotate1" onclick="rotateDIV()" class="rotate3">aa</div>
<div id="rotatey1" onclick="rotateYDIV()" class="rotate3">bbb</div>
<div id="nav"><a href="">aa</a></div>
<script type="text/javascript">
    var x, y, n = 0, ny = 0, rotINT, rotYINT
    function rotateDIV() {
        x = document.getElementById("rotate1")
        clearInterval(rotINT)
        rotINT = setInterval("startRotate()", 10)
    }
    function rotateYDIV() {
        y = document.getElementById("rotatey1")
        clearInterval(rotYINT)
        rotYINT = setInterval("startYRotate()", 10)
    }
    function startRotate() {
        n = n + 1
        x.style.transform = "rotate(" + n + "deg)"
        x.style.webkitTransform = "rotate(" + n + "deg)"
        x.style.OTransform = "rotate(" + n + "deg)"
        x.style.MozTransform = "rotate(" + n + "deg)"
        if (n == 180 || n == 360) {
            clearInterval(rotINT)
            if (n == 360) {
                n = 0
            }
        }
    }
    function startYRotate() {
        ny = ny + 1
        y.style.transform = "rotateY(" + ny + "deg)"
        y.style.webkitTransform = "rotateY(" + ny + "deg)"
        y.style.OTransform = "rotateY(" + ny + "deg)"
        y.style.MozTransform = "rotateY(" + ny + "deg)"
        if (ny == 180 || ny >= 360) {
            clearInterval(rotYINT)
            if (ny >= 360) {
                ny = 0
            }
        }
    }
</script>
</body>
</html>
