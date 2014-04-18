// JavaScript Document
//png ie6兼容
$(function(){
	if($(".shouting-c").length!==0)
	{$(".shouting-c li:odd").css("margin-left","20px")}
	
	$(".f-box").children("div").hide();
	
$(document).pngFix();
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