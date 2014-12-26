﻿/// <reference path="JSintellisense/jquery-1.2.6-intellisense.js" />

//全局变量定义
var CANVAS_WIDTH = 350; //画布的宽
var CANVAS_HEIGHT = 300; //画布的高
var ICON_SIZE = 180;  //截取框的大小，正方形
var LEFT_EDGE = (CANVAS_WIDTH - ICON_SIZE) / 2; //85
var TOP_EDGE = (CANVAS_HEIGHT - ICON_SIZE) / 2; //60
var CANVAS_LEFT_MARGIN = 4;


//用document. ready事件中在上传后第一次转向时无法获取到图片的打开，应该是没有被下载来的缘故
$(window).load(function() {
    var $iconElement = $("#ctl00_ContentPlaceHolder1_ImageIcon");
    var $imagedrag = $("#ctl00_ContentPlaceHolder1_ImageDrag");

    //获取上传图片的实际高度，宽度
    var image = new Image();
    image.src = $iconElement.attr("src");
    var realWidth = image.width;
    var realHeight = image.height;  
    image = null;       
   
    //计算缩放比例开始
    var minFactor = ICON_SIZE / Math.max(realWidth, realHeight);
    if (ICON_SIZE > realWidth && ICON_SIZE > realHeight) {
        minFactor = 1;
    }
    var factor = minFactor > 0.25 ? 8.0 : 4.0 / Math.sqrt(minFactor);

    //图片缩放比例
    var scaleFactor = 1;
    if (realWidth > CANVAS_WIDTH && realHeight > CANVAS_HEIGHT) {
        if (realWidth / CANVAS_WIDTH > realHeight / CANVAS_HEIGHT) {
            scaleFactor = CANVAS_HEIGHT / realHeight;
        }
        else {
            scaleFactor = CANVAS_WIDTH / realWidth;
        }
    }
    //计算缩放比例结束

    //设置滑动条的位置，设置滑动条的值的变化来改变缩放率是一个非线性的变化，而是幂函数类型 即类似y=factor（X）--此处x为幂指数
    //此处100 * (Math.log(scaleFactor * factor) / Math.log(factor)) 为知道y 求解x 的算法
    $(".child").css("left", 100 * (Math.log(scaleFactor * factor) / Math.log(factor)) + "px");

    //图片实际尺寸，并近似到整数
    var currentWidth = Math.round(scaleFactor * realWidth);
    var currentHeight = Math.round(scaleFactor * realHeight);


    //图片相对CANVAS的初始位置，图片相对画布居中
    var originLeft = Math.round((CANVAS_WIDTH - currentWidth) / 2) ;
    var originTop = Math.round((CANVAS_HEIGHT - currentHeight) / 2);
    //计算截取框中的图片的位置
    var dragleft = originLeft - LEFT_EDGE;
    var dragtop = originTop - TOP_EDGE;


    //设置图片当前尺寸和位置
    $iconElement.css({ width: currentWidth + "px", height: currentHeight + "px", left: originLeft + "px", top: originTop + "px" });
    $imagedrag.css({ width: currentWidth + "px", height: currentHeight + "px", left: dragleft + "px", top: dragtop + "px" });

    //初始化默认值
    $("#ctl00_ContentPlaceHolder1_txt_width").val(currentWidth);
    $("#ctl00_ContentPlaceHolder1_txt_height").val(currentHeight);
    $("#ctl00_ContentPlaceHolder1_txt_top").val(0 - dragtop);
    $("#ctl00_ContentPlaceHolder1_txt_left").val(0 - dragleft);
    $("#ctl00_ContentPlaceHolder1_txt_Zoom").val(scaleFactor);

    var oldWidth = currentWidth;
    var oldHeight = currentHeight;

    //设置图片可拖拽，并且拖拽一张图片时，同时移动另外一张图片
    $imagedrag.draggable(
    {
        cursor: 'move',
        drag: function(e, ui) {
            var self = $(this).data("draggable");
            var drop_img = $("#ctl00_ContentPlaceHolder1_ImageIcon");
            var top = drop_img.css("top").replace(/px/, ""); //取出截取框到顶部的距离
            var left = drop_img.css("left").replace(/px/, ""); //取出截取框到左边的距离
            //if (0 - parseInt(self.position.left) > 0) {
            //    drop_img.css({ left: LEFT_EDGE+"px" });
            //}
            //else {
            //    drop_img.css({ left: (parseInt(self.position.left) + LEFT_EDGE) + "px" });
            //}
            //if (0 - parseInt(self.position.top) > 0) {
            //    drop_img.css({ top: TOP_EDGE+"px" });
            //}
            //else {
            //    drop_img.css({ top: (parseInt(self.position.top) + TOP_EDGE) + "px" });
            //}
            drop_img.css({ left: (parseInt(self.position.left) + LEFT_EDGE) + "px", top: (parseInt(self.position.top) + TOP_EDGE) + "px" }); //同时移动内部的图片
            $("#ctl00_ContentPlaceHolder1_txt_left").val(0 - parseInt(self.position.left));
            $("#ctl00_ContentPlaceHolder1_txt_top").val(0 - parseInt(self.position.top));
        }
    }
    );
    //设置图片可拖拽，并且拖拽一张图片时，同时移动另外一张图片
    $iconElement.draggable(
    {
        cursor: 'move',
        drag: function(e, ui) {
            var self = $(this).data("draggable");
            var drop_img = $("#ctl00_ContentPlaceHolder1_ImageDrag");
            var top = drop_img.css("top").replace(/px/, ""); //取出截取框到顶部的距离
            var left = drop_img.css("left").replace(/px/, ""); //取出截取框到左边的距离
            //if (0 - (parseInt(self.position.left) - LEFT_EDGE) > 0) {
            //    drop_img.css({ left: LEFT_EDGE + "px" });
            //    $("#ctl00_ContentPlaceHolder1_txt_left").val(0);
            //}
            //else {
            //    drop_img.css({ left: (parseInt(self.position.left) - LEFT_EDGE) + "px" });
            //    $("#ctl00_ContentPlaceHolder1_txt_left").val(0 - (parseInt(self.position.left) - LEFT_EDGE));
            //}
            //if (0 - (parseInt(self.position.top) - TOP_EDGE) > 0) {
            //    drop_img.css({ top: TOP_EDGE + "px" });
            //    $("#ctl00_ContentPlaceHolder1_txt_top").val(0);
            //}
            //else {
            //    drop_img.css({ top: (parseInt(self.position.top) + TOP_EDGE) + "px" });
            //    $("#ctl00_ContentPlaceHolder1_txt_top").val(0 - (parseInt(self.position.top) - TOP_EDGE));
            //}
            drop_img.css({ left: (parseInt(self.position.left) - LEFT_EDGE) + "px", top: (parseInt(self.position.top) - TOP_EDGE) + "px" }); //同时移动内部的图片
            $("#ctl00_ContentPlaceHolder1_txt_left").val(0 - (parseInt(self.position.left) - LEFT_EDGE));
            $("#ctl00_ContentPlaceHolder1_txt_top").val(0 - (parseInt(self.position.top) - TOP_EDGE));
        }

    }
    );

    //缩放的代码，要缩放以截取框为中心，所以要重新计算图片的left和top
    $(".child").draggable(
  {
      cursor: "move", containment: $("#bar"),
      drag: function(e, ui) {
      var left = parseInt($(this).css("left"));
          //前面讲过了y=factor（x），此处是知道x求y的值，即知道滑动条的位置，获取缩放率
          scaleFactor = Math.pow(factor, (left / 100 - 1));
          if (scaleFactor < minFactor) {
              scaleFactor = minFactor;
          }
          if (scaleFactor > factor) {
              scaleFactor = factor;
          }
          //以下代码同初始化过程，因为用到局部变量所以没有
          var iconElement = $("#ctl00_ContentPlaceHolder1_ImageIcon");
          var imagedrag = $("#ctl00_ContentPlaceHolder1_ImageDrag");

          var image = new Image();
          image.src = iconElement.attr("src");
          var realWidth = image.width;
          var realHeight = image.height;
          image = null;

          //图片实际尺寸
          var currentWidth = Math.round(scaleFactor * realWidth);
          var currentHeight = Math.round(scaleFactor * realHeight);

          //图片相对CANVAS的初始位置
          var originLeft = parseInt(iconElement.css("left"));
          var originTop = parseInt(iconElement.css("top"));

          originLeft -= Math.round((currentWidth - oldWidth) / 2);
          originTop -= Math.round((currentHeight - oldHeight) / 2);
          dragleft = originLeft - LEFT_EDGE;
          dragtop = originTop - TOP_EDGE;

          //图片当前尺寸和位置
          iconElement.css({ width: currentWidth + "px", height: currentHeight + "px", left: originLeft + "px", top: originTop + "px" });
          imagedrag.css({ width: currentWidth + "px", height: currentHeight + "px", left: dragleft + "px", top: dragtop + "px" });

          $("#ctl00_ContentPlaceHolder1_txt_Zoom").val(scaleFactor);
          $("#ctl00_ContentPlaceHolder1_txt_left").val(0 - dragleft);
          $("#ctl00_ContentPlaceHolder1_txt_top").val(0 - dragtop);
          $("#ctl00_ContentPlaceHolder1_txt_width").val(currentWidth);
          $("#ctl00_ContentPlaceHolder1_txt_height").val(currentHeight);
          oldWidth = currentWidth;
          oldHeight = currentHeight;

      }
  });
    var SilderSetValue = function(i) {
        var left = parseInt($(".child").css("left"));
        left += i;

        if (left < 0) {
            left = 0;
        }
        if (left > 200) {
            left = 200;
        }

        scaleFactor = Math.pow(factor, (left / 100 - 1));
        if (scaleFactor < minFactor) {
            scaleFactor = minFactor;
        }
        if (scaleFactor > factor) {
            scaleFactor = factor;
        }
        var iconElement = $("#ctl00_ContentPlaceHolder1_ImageIcon");
        var imagedrag = $("#ctl00_ContentPlaceHolder1_ImageDrag");

        var image = new Image();
        image.src = iconElement.attr("src");
        var realWidth = image.width;
        var realHeight = image.height;
        image = null;

        //图片实际尺寸
        var currentWidth = Math.round(scaleFactor * realWidth);
        var currentHeight = Math.round(scaleFactor * realHeight);

        //图片相对CANVAS的初始位置
        var originLeft = parseInt(iconElement.css("left"));
        var originTop = parseInt(iconElement.css("top"));

        originLeft -= Math.round((currentWidth - oldWidth) / 2);
        originTop -= Math.round((currentHeight - oldHeight) / 2);
        dragleft = originLeft - LEFT_EDGE;
        dragtop = originTop - TOP_EDGE;

        //图片当前尺寸和位置
        $(".child").css("left", left + "px");

        if (originLeft >= ICON_SIZE + LEFT_EDGE)
        {
            originLeft = LEFT_EDGE;
            dragleft = 0;
        }
        else if (originLeft <= LEFT_EDGE - currentWidth)
        {
            originLeft = ICON_SIZE + LEFT_EDGE - currentWidth;
            dragleft = ICON_SIZE - currentWidth;
        }
        if (originTop >= ICON_SIZE + TOP_EDGE)
        {
            originTop = TOP_EDGE;
            dragtop = 0;
        }
        else if (originTop <= TOP_EDGE - currentHeight)
        {
            originTop = ICON_SIZE + TOP_EDGE - currentHeight;
            dragtop = ICON_SIZE - currentHeight;
        }

        iconElement.css({ width: currentWidth + "px", height: currentHeight + "px", left: originLeft + "px", top: originTop + "px" });
        imagedrag.css({ width: currentWidth + "px", height: currentHeight + "px", left: dragleft + "px", top: dragtop + "px" });

        $("#ctl00_ContentPlaceHolder1_txt_Zoom").val(scaleFactor);
        $("#ctl00_ContentPlaceHolder1_txt_left").val(0 - dragleft);
        $("#ctl00_ContentPlaceHolder1_txt_top").val(0 - dragtop);
        $("#ctl00_ContentPlaceHolder1_txt_width").val(currentWidth);
        $("#ctl00_ContentPlaceHolder1_txt_height").val(currentHeight);

        oldWidth = currentWidth;
        oldHeight = currentHeight;
    }
    //点击加减号
    $("#moresmall").click(function() {
        SilderSetValue(-20);
    });
    $("#morebig").click(function() {
        SilderSetValue(20);
    });

});