<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="HelpCenter.aspx.cs" Inherits="WebForMain.About.HelpCenter" %>

<%@ Register Src="../ControlLibrary/ShowAdv.ascx" TagName="ShowAdv" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>帮助中心</h2>
    <div class="help_box">
        <!--内页左侧-->
        <div class="help_left">
            <div class="help_left_position">相关问题>人生命运<asp:Literal ID="ltrTitle" runat="server"></asp:Literal></div>
            <div class="help_list">
                <uc1:showadv id="HelpContent" runat="server" enableviewstate="false" />
            </div>
        </div>
        <!--内页右侧-->
        <div class="help_right">
            <div class="page_right_box">
                <div class="page_right_box_t">会员账户</div>
                <div class="help_right_c">
                    <ul class="help_right_list">
                        <li><a href="HelpCenter.aspx?memo=UserRegister">新用户注册</a></li>
                        <li><a href="HelpCenter.aspx?memo=AccountSafe">账号安全</a></li>
                        <li><a href="HelpCenter.aspx?memo=DefaultChartSet">默认排盘类型与命盘设置</a></li>
                        <li><a href="HelpCenter.aspx?memo=UserGrade">会员等级规则</a></li>
                        <li><a href="HelpCenter.aspx?memo=PointAndCredit">积分&点卷</a></li>
                        <li><a href="HelpCenter.aspx?memo=Payment">充值&提现</a></li>
                    </ul>
                </div>
            </div>
            <div class="height10"></div>
            <div class="page_right_box">
                <div class="page_right_box_t">我要提问求测</div>
                <div class="help_right_c">
                    <ul class="help_right_list">
                        <li><a href="HelpCenter.aspx?memo=AskGuide">提问求测流程图</a></li>
                        <li><a href="HelpCenter.aspx?memo=AskSetChart">命盘发布指导</a></li>
                        <li><a href="HelpCenter.aspx?memo=OfferReward">悬赏规则</a></li>
                        <li><a href="HelpCenter.aspx?memo=EndQuestion">结贴反馈机制</a></li>
                    </ul>
                </div>
            </div>
            <div class="height10"></div>
            <div class="page_right_box">
                <div class="page_right_box_t">我要解盘答疑</div>
                <div class="help_right_c">
                    <ul class="help_right_list">
                        <li><a href="HelpCenter.aspx?memo=AnswerGuide">解盘答疑流程图</a></li>
                        <li><a href="HelpCenter.aspx?memo=ReplyQuest">回复与评价</a></li>
                        <li><a href="HelpCenter.aspx?memo=GetReward">如何获得悬赏</a></li>
                        <li><a href="HelpCenter.aspx?memo=IdentifyAndRecommend">认证与明星推荐</a></li>
                    </ul>
                </div>
            </div>
            <div class="height10"></div>
            <div class="page_right_box">
                <div class="page_right_box_t">在线排盘</div>
                <div class="help_right_c">
                    <ul class="help_right_list">
                        <li><a href="HelpCenter.aspx?memo=AstroChart">西洋占星术排盘</a></li>
                        <li><a href="HelpCenter.aspx?memo=AstroSet">西洋占星术高级选项设置</a></li>
                        <li><a href="HelpCenter.aspx?memo=ZiWeiChart">紫微斗数排盘</a></li>
                        <li><a href="HelpCenter.aspx?memo=ZiWeiSet">紫微斗数高级选项设置</a></li>
                        <li><a href="HelpCenter.aspx?memo=BaZiChart">四柱八字排盘</a></li>
                        <li><a href="HelpCenter.aspx?memo=BaziSet">四柱八字高级选项设置</a></li>
                        <li><a href="HelpCenter.aspx?memo=CollectChart">命盘收藏</a></li>
                    </ul>
                </div>
            </div>
            <div class="height10"></div>
            <div class="page_right_box">
                <div class="page_right_box_t">名人案例库</div>
                <div class="help_right_c">
                    <ul class="help_right_list">
                        <li><a href="HelpCenter.aspx?memo=FamousSearch">案例库搜索</a></li>
                        <li><a href="HelpCenter.aspx?memo=WikiIntro">维基百科模式</a></li>
                        <li><a href="HelpCenter.aspx?memo=FamousResearch">付费研究功能</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
