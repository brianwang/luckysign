// JavaScript Document
$(document).ready(function(){
	
	
	if($("#new_list_ul").length!==0){
		$("#new_list_ul").each(function(){
			$(this).children("li:last").css("border-bottom","dotted 1px #80776D")
		})
	}				   
	
	$(".page_person_item img:last").css("margin",0)
	
	
	$(".page_person_item img").mouseover(function(){
		$(this).attr("src",$(this).attr("src").replace(".","_."));
	}).mouseout(function(){
		$(this).attr("src",$(this).attr("src").replace("_.","."));
	})
	
	$(".page_con_item li").mouseover(function(){
		$(this).addClass("on")
	}).mouseout(function(){
		$(this).removeClass("on")
	})
	
	$(".mypage_otherperson_ul li").mouseover(function(){
		$(this).addClass("on")
	}).mouseout(function(){
		$(this).removeClass("on")
	})
	
	
	$(".page_menu a").mouseover(function(){
		$(this).addClass("on")
	}).mouseout(function(){
		$(this).removeClass("on")
	})
	
	$(".index_tip_div").mouseover(function(){
		$(".index_tip_div.on").removeClass("on");					   
		$(this).addClass("on");
		
	})
	
	$(".index_left_list2 li:nth-child(2n+1)").css("margin-left","0px");
	
	
	if($(".mr_search_ul").length!==0){$(".mr_search_ul li:last").css("border","none")}

	
	//首页切换
	banner_ch(i);
	
	$(".banner_nav li").click(function()
	{
		$(".banner_nav li.on").removeClass("on");
		$(this).addClass("on");
		var In_pic=$(this).index();
		num=In_pic;
		banner_ch(num);
	});
	
		$(document).pngFix(); 
	
});


$(document).bind('click', function(e) {   
   var clickme = $(e.target);   
   if (!clickme.hasClass("SelectTitle")) {   
	   $(".SelectBox").hide();   //在不是列表输入区域单击时（有可能是空白区或者下拉列表中单击）   
	   if (clickme.parent().hasClass("SelectBox")) {     //在下拉列表中单击时执行   
		   clickme.parent().prev().html(clickme.html());   
		   clickme.parent().prev().attr("attrid", clickme.attr("attrid"));   
								  }   
	     
   }   
   else {   
	   $(".SelectBox").hide();  //先全体隐藏，再显示点中的下拉列表层   
	   clickme.next().show();   
   }   
});

var i;
var num=0;
var t;
function banner_ch(i)
{
	clearTimeout(t);
	i=num;
	$(".banner_nav li.on").removeClass("on");
	$(".banner_nav li:eq("+i+")").addClass("on");
	$(".banner_img img").css("display","none");
	$(".banner_img img:eq("+i+")").fadeIn();
	var li_index=$(".banner_nav li").length;
	num++;
	if(num>li_index-1){num=0};
	t=setTimeout(banner_ch,3000);
}