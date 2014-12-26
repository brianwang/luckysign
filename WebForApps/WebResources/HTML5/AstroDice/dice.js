var constdeg=0, gongdeg=0, constacc = 0.05, gongacc = 0.1, constspd = 0, gongspd = 0, dicespd = 0, dicenow = 0;
var rotConst, rotGong, rotDice;
var x,y,c;
var context;
var scale = 1;


$(document).ready(function(){
    scale = parseFloat(window.innerWidth) / parseFloat("640");
    x = document.getElementById("rotate1");
    y = document.getElementById("rotate2");
    c = document.getElementById("mycanvas");
    context = c.getContext('2d');
    changeheight(document.getElementById("content"));
    changeheight(document.getElementById("sec"));
    changeheight(x);
    changeheight(y);
    changeheight(document.getElementById("top"));
    changescale(document.getElementById("begin"));
    changescale(document.getElementById("result"));
    changeheight(document.getElementById("resultdiv"));
    for (i = 1; i < 13; i++)
    {
        changescale(document.getElementById("num" + i));
    }

    var beginarc = (Math.random() * 360);
    x.style.transform = "rotate(" + beginarc % 360 + "deg)";
    x.style.webkitTransform = "rotate(" + beginarc % 360 + "deg)";
    x.style.OTransform = "rotate(" + beginarc % 360 + "deg)";
    x.style.MozTransform = "rotate(" + beginarc % 360 + "deg)";
    constdeg = beginarc % 360;

    preImage("../WebResources/HTML5/AstroDice/Dice/126.png",function(){   
        context.drawImage(this, 269, 264, 105, 105);   
    }); 
    preImage("../WebResources/HTML5/AstroDice/Star/0.png",function(){   
        context.drawImage(this, 268, 265, 105, 105);   
    }); 
    changescale(c);
});

function preImage(url, callback) {
    var img = new Image(); //创建一个Image对象，实现图片的预下载   
    img.src = url;

    if (img.complete) { // 如果图片已经存在于浏览器缓存，直接调用回调函数   
        callback.call(img);
        return; // 直接返回，不用再处理onload事件   
    }

    img.onload = function () { //图片下载完毕时异步调用callback函数。   
        callback.call(img);//将回调函数的this替换为Image对象   
    };
}



function changeheight(input)
{
    input.style.height = scale * input.offsetHeight + "px";
    input.style.marginTop = scale * input.style.marginTop.replace("px","") + "px";

}
function changescale(input) {
    input.style.height = scale * input.offsetHeight + "px";
    input.style.left = scale * input.offsetLeft + "px";
    input.style.top = scale * input.offsetTop + "px";
    //input.style.marginTop = scale * input.style.marginTop.replace("px","") + "px";

}

function run() {
    if (constspd == 0 && gongspd == 0 && dicenow >= dicespd) {
        clearInterval(rotConst);
        clearInterval(rotGong);
        clearInterval(rotDice);

        constspd = Math.random() * 5 + 7;
        gongspd = constspd * 2 - 1;
        dicespd = Math.round(constspd / 0.05 / 10 - 6) * 10;
        dicenow = 1;
        rotConst = setInterval("ConstellationRotate();", 55);
        rotGong = setInterval("GongRotate();", 55);
        rotDice = setInterval("DiceRotate();", 55);
    }
}

function ConstellationRotate() {
    constdeg = constdeg + constspd;
    constspd = constspd - constacc;
    x.style.transform = "rotate(" + constdeg%360 + "deg)"
    x.style.webkitTransform = "rotate(" + constdeg % 360 + "deg)"
    x.style.OTransform = "rotate(" + constdeg % 360 + "deg)"
    x.style.MozTransform = "rotate(" + constdeg % 360 + "deg)"
    if (constspd < 0) {
        constspd = 0;
    }
    if (constspd == 0) {
        clearInterval(rotConst);
        $("#result").html("占卜结果："+starname[starnow] + "，" + ((Math.floor(gongdeg / 30) + 4 + 12 - 1) % 12 + 1) + "宫，" + constname[Math.floor((360 - ((Math.floor(gongdeg / 30) * 30 + 90) + constdeg) % 360) / 30 + 12) % 12] + "座");
    }
}

function GongRotate() {
    var tmppre = Math.floor(gongdeg / 30) * 30;
    gongdeg = gongdeg + gongspd;
    gongspd = gongspd - gongacc;

    var tmp = Math.floor(gongdeg / 30) * 30;
    if(tmp!=tmppre)
    {
        y.style.transform = "rotate(-" + tmp % 360 + "deg)"
        y.style.webkitTransform = "rotate(-" + tmp % 360 + "deg)"
        y.style.OTransform = "rotate(-" + tmp % 360 + "deg)"
        y.style.MozTransform = "rotate(-" + tmp % 360 + "deg)"

        for(i=1;i<13;i++)
        {
            $("#num" + i).css("z-index", "-999");
        }
        $("#num" + ((tmp / 30 + 3) % 12 + 1)).css("z-index", "9");
    }
    if (gongspd < 0) {
        gongspd = 0;
    }
    if (gongspd == 0) {
        clearInterval(rotGong);
    }
}

var tmpnum=6,lastnum=6,targetface=0,targetstar=0,starnow=0;
function DiceRotate() {
    if (dicenow >= dicespd)
    {
        return;
    }
    if (dicenow % 2 == 1)
    {
        if (dicenow % 10 == 1)
        {
            while (tmpnum == lastnum)
            {
                tmpnum = Math.floor(Math.random() * 5);
            }
            if (targetface == 0) {
                targe = 1;
            }
            else {
                targetface = 0;
            }
        }
        switch (((dicenow + 1) / 2) % 5 + 1)
        {
            case 1:
                break;
            case 2:
                context.clearRect(0, 0, c.width, c.height);
                var img = new Image(); img.src = "../WebResources/HTML5/AstroDice/Dice/" + (tmpnum * 12 + starnow + 1 + (((targetface + 1) % 2) * 60)) + ".png";
                context.drawImage(img, 269, 264, 105, 105);
                break;
            case 3:
                context.clearRect(0, 0, c.width, c.height);
                var img = new Image(); img.src = "../WebResources/HTML5/AstroDice/Dice/" + (tmpnum + 121) + ".png";
                context.drawImage(img, 269, 264, 105, 105);
                while (targetstar == starnow)
                {
                    targetstar = Math.floor(Math.random() * 12);
                }
                break;
            case 4:
                context.clearRect(0, 0, c.width, c.height);
                var img = new Image(); img.src = "../WebResources/HTML5/AstroDice/Dice/" + (tmpnum * 12 + targetstar + 1 + targetface * 60) + ".png";
                context.drawImage(img, 269, 264, 105, 105);
                break;
            case 5:
                context.clearRect(0, 0, c.width, c.height);
                var img = new Image(); img.src = "../WebResources/HTML5/AstroDice/Dice/" + (126 + targetface) + ".png";
                context.drawImage(img, 269, 264, 105, 105);
                var img = new Image(); img.src = "../WebResources/HTML5/AstroDice/Star/" + targetstar + ".png";
                context.drawImage(img, 268, 265, 105, 105);
                starnow = targetstar;
                break;
        }
    }
    lastnum = tmpnum;
    dicenow=dicenow+1;
}

var constname = ['白羊', '金牛', '双子', '巨蟹', '狮子', '处女', '天秤', '天蝎', '射手', '摩羯', '水瓶', '双鱼'];
var starname = ['太阳', '月亮', '水星', '金星', '火星', '木星', '土星', '天王星', '海王星', '冥王星', '北交点', '南交点'];


