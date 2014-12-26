<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QinAccountRight.ascx.cs" Inherits="WebForMain.ControlLibrary.QinAccountRight" %>
<div class="account_right">
    <ul class="account_right_ul">
        <li class="<%=on[0] %>"><a href="MyAccount.aspx?tab=0" style="background-position: 20px 10px;">灵签账户</a></li>
        <li class="<%=on[0] %>"><a href="MyAccount.aspx?tab=1" style="background-position: 20px -40px;">现金账户</a></li>
        <li class="<%=on[0] %>"><a href="#" style="background-position: 20px -90px;">投诉记录</a></li>
        <li class="<%=on[0] %>"><a href="#" style="background-position: 20px -140px;">我要充值</a></li>
        <li class="<%=on[0] %>"><a href="#" style="background-position: 20px -190px;">我要提现</a></li>
    </ul>
</div>
<script type="text/javascript">
    $(function () {
        $(".account_right_ul li").mouseenter(function () {
            $(".account_right_ul li").removeClass("current");
            $(this).addClass("current");
            $(".account_right_ul li")[<%=tab%>].addClass("current");
        })

    })

</script>
