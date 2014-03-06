// JavaScript Document
//png ie6兼容
$(function(){
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
		objDiv.hide();	
		objDiv.eq(num-1).show();
	}
	
	
}