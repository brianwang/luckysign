// JavaScript Document

$(function(){
	if($(".shouting-c").length!==0)
	{$(".shouting-c li:odd").css("margin-left","20px")}
	
	$(".f-box").children("div").hide();
	
	$(document).pngFix( );
	
	$(".f-box").children("div:not(0)").children("div").each(function(){
		if(!$(this).is(':has(a)'))
		{
			$(this).bind("mouseenter",function()
			{
				$(this).css("cursor","pointer")
				var bgimg=$(this).css("background-image");//取背景
				bgimg=bgimg.replace(".", "_on.");//字符替换
				$(this).css("background-image",bgimg)//加on
			}).bind("mouseleave",function(){
				$(this).attr("style","");//去除属性
				$(this).css("display","block");
			})
		}
		else
		{
			//蜜蜂等区域热点
			$(this).children("a").bind("mouseenter",function()
			{
				var bgimg=$(this).parent().css("background-image");//取背景
				bgimg=bgimg.replace(".", "_on.");
				$(this).parent().css("background-image",bgimg)//加on
			}).bind("mouseleave",function(){
				$(this).parent().attr("style","");//去除属性
			})
		
		}
		
	})
	
	


})

function showItem(obj,num){
	var objSelect=$("."+obj);
	var objDiv=objSelect.children("div");
	if (objDiv.length==0)
	{
		if(num==0){	objSelect.hide()}
		if(num==1){	objSelect.show()}
		else{return false}
	}
	
	else
	{
		objSelect.show();
		objDiv.hide();	
		objDiv.eq(num-1).show();
	}
	
	
}