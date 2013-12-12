<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="ZiWei.aspx.cs" Inherits="WebForMain.PPLive.ZiWei" %>

<%@ Register Src="~/ControlLibrary/PPPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>紫薇斗数排盘-在线排盘-上上签</title>
    <meta name="keywords" content="紫薇斗数_紫薇排盘_紫斗_推运_运势_个人星盘_上上签_紫薇咨询_在线星盘_专业星盘_绘制星盘_算命_命盘_命理" />
    <meta name="description" content="上上签为您提供免费专业紫薇斗数在线星盘排盘软件,并支持在线收藏管理命盘,上上签的紫薇斗数大师还可在线为您解析星盘,免费获取精准的命格分析,爱情分析,运势分析,情侣星盘配对等内容" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="leftbox left">
            <h3>紫薇斗数排盘</h3>
            <div class="line_03">
            </div>
            <div class="block show pp">
                <div class="box_1">
                    <div class="box_t">
                        当事人信息
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>阳历生日：</strong>
                        <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                        <br />
                        <span class="fred">&nbsp;</span><strong>生时校正：</strong>
                        <asp:CheckBox ID="chkRealTime" runat="server" onclick="checkrealtime(this);" Checked="true" /><span
                            class="fsred"><strong>需要计算真太阳时</strong></span><br />
                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" RenderMode="Inline">
                            <ContentTemplate>
                                 <div style="float:left;width:77px"><span class="fred">*</span><strong>出生地点：</strong></div>
                                <div style="width:500px">
                                <uc1:District ID="District1" runat="server"></uc1:District></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <span class="fred">*</span><strong>性 别：</strong>
                        <asp:RadioButtonList ID="drpGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <span class="fred">*</span><strong>排盘类型：</strong>
                        <asp:RadioButton ID="rblType1" GroupName="rblType" Text="天盘" Checked="true" onclick="javascript:TransitBox.style.display='none';" runat="server" />
                        <asp:RadioButton ID="rblType2" GroupName="rblType" Text="流限盘" onclick="javascript:TransitBox.style.display='';" runat="server" />
                        <br />
                    </div>
                </div>
                <div class="box_1" id="TransitBox" style="display: none;">
                    <div class="box_t">
                        推运信息
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>推运时间：</strong>
                        <uc1:DatePicker ID="TransitDate" runat="server" Type="3"></uc1:DatePicker>

                    </div>
                </div>
                <div class="box_1">
                    <div class="box_t">
                        <a href="javascript:void(0)" class="box_ta">高级选项</a>
                    </div>
                    <div class="box_c" style="display: none;">
                        &nbsp;<strong>闰月排法：</strong>
                        <asp:DropDownList ID="drpLeaf" runat="server" CssClass="sel_0">
                        </asp:DropDownList>
                        &nbsp;<strong>天马排法：</strong>
                        <asp:DropDownList ID="drpTianma" runat="server" CssClass="sel_2">
                            <asp:ListItem Text="年马" Value="0"></asp:ListItem>
                            <asp:ListItem Text="月马" Value="1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<strong>身主排法：</strong>
                        <asp:DropDownList ID="drpShenzhu" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="按生年年支" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="按命宫地支" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        &nbsp;<strong>天使天伤排法：</strong>
                        <asp:DropDownList ID="drpShiShang" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="阴阳不同" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="阴阳不同" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<strong>换大运界线：</strong>
                        <asp:DropDownList ID="drpTransit" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="按农历新年换运" Value="1"></asp:ListItem>
                            <asp:ListItem Text="按农历生日换运" Value="0" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <div class="line_02">
                        </div>
                    </div>
                    <asp:LinkButton runat="server" CssClass="btn_03" OnClientClick="javascript:setTimeout('document.forms[0].action= document.location.href;',500);"
                        PostBackUrl="ZiWeiChart.aspx">开始排盘</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="rightbox left">
            <uc1:RightPanel ID="Panel1" runat="server"></uc1:RightPanel>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">

    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>
    <script type="text/javascript">

    </script>
</asp:Content>
