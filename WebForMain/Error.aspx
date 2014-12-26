<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebForMain.Error" %>

<%@ Register Src="ControlLibrary/ShowAdv.ascx" TagName="ShowAdv" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        页面不存在-上上签算命咨询网</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style='background: #f7f4ee; width: 786px; padding-left: 82px; padding-right: 82px; padding-top:50px;'>
        <div style='font:18px/24px "微软雅黑";margin-bottom:20px;'>
            <asp:Literal ID="ltrErr" runat="server"></asp:Literal>，您可以返回&nbsp;<a href="/" style="color:#a12026; text-decoration:underline;">首页</a></div>
        <div style='background-color: #80776D; padding:3px 0px 3px 16px; font: 14px/20px "微软雅黑"; color: #fff; margin-bottom: 10px; margin-top: 10px; width: 770px;'>
            你还可能对以下内容感兴趣
        </div>
        <div style="height:500px;width:786px;">
            <div style="float: left; width: 515px; padding-left:26px;">
                <div class="zjlm_box_t" style="height:120px;">
                    <h1>免费求测</h1>
                    免费求测咨询，供初学者或命理师研究学习，求测者有反馈义务。<br />
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Ask" target="_blank" class="zjlm_box_t_a" style="background: #779058;float:none;">求解盘</a>
                </div>
                <div class="zjlm_box_t" style="height:120px;">
                    <h1>学习讨论</h1>
                    星座，占星，塔罗占卜，紫薇八字，一网打尽，发帖讨论，学习交友，娱乐灌水。<br />
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Talk" target="_blank" class="zjlm_box_t_a" style="background: #6d8690;float:none;">发新贴</a>
                </div>
            </div>
            <div style="float: right; width: 245px">
                <div class="index_right_list2">
                    <ul>
                        <li style="padding: 3px 9px 0px; border-bottom: none"><a href="PPLive/Astro.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_zhanxing.jpg" height="58" width="58" alt="西洋占星术排盘" />占星排盘</a></li>
                        <li style="padding: 3px 9px 0px; border-bottom: none"><a href="PPLive/ZiWei.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_ziwei.jpg" height="58" width="58" alt="紫薇斗数排盘" />紫斗排盘</a></li>
                        <li style="padding: 3px 9px 0px; border-bottom: none"><a href="PPLive/BaZi.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_bazi.jpg" height="58" width="58" alt="四柱八字排盘" />八字排盘</a></li>
                    </ul>
                    <%--<a href="#">塔罗在线牌阵</a>--%>
                    <div class="clear">
                    </div>
                </div>
                <div class="index_right_list1" style="border-bottom:none;padding-left:15px;padding-top:10px;">
                    <uc1:ShowAdv ID="AdvRightMid" runat="server" advfrom="IndexCeOl.htm" EnableViewState="true" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
