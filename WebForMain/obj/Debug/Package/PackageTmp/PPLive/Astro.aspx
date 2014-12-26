<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Astro.aspx.cs" Inherits="WebForMain.PPLive.Astro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/ControlLibrary/PPPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>西洋占星术星盘_在线排盘_上上签</title>
    <meta name="keywords" content="占星术_星盘排盘_推运_合盘_运势_星座_个人星盘_上上签_占星咨询_在线星盘_专业星盘_绘制星盘_算命_命盘" />
    <meta name="description" content="上上签为您提供免费专业西洋占星术在线星盘排盘软件,并支持在线收藏管理命盘,上上签的占星师还可在线为您解析星盘,免费获取精准的性格分析,爱情分析,星座运势,情侣星盘配对等内容" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager runat="server"></asp:ToolkitScriptManager>
    <div class="main">
        <div class="leftbox left">
            <h3>个人星盘排盘</h3>
            <div class="tabs">
                <a href="javascript:void(0)" title="本命盘" class="on">本命盘</a> <a href="javascript:void(0)"
                    title="组合盘">组合盘</a> <a href="javascript:void(0)" title="推运盘">推运盘</a>
            </div>
            <%--本命盘--%>
            <div class="pp">
                <div class="block stab">
                    <a href="javascript:void(0)" title="行运VS本命" class="on">行运VS本命(Transit)</a> | <a href="javascript:void(0)"
                        title="月限法">月限法(Progress)</a> | <a href="javascript:void(0)" title="反照法">反照法(Return)</a>
                    | <a href="javascript:void(0)" title="太阳弧度法">太阳弧度法(Solar Arcs)</a>
                </div>
                <div class="box_1">
                    <div class="box_t">
                        当事人信息
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>阳历生日：</strong>
                        <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                        <asp:CheckBox ID="chkDaylight1" runat="server" />
                        <span class="fsred"><strong>夏令时</strong></span>
                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="float:left;width:77px"><span class="fred">*</span><strong>出生地点：</strong></div>
                                <div style="width:500px">
                                <uc1:District ID="District1" runat="server"></uc1:District></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <span class="fred">*</span><strong>所属时区：</strong>
                        <asp:DropDownList ID="drpTimeZone1" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                        时区
                        <br />
                        &nbsp;<strong>姓 名：</strong>
                        <asp:TextBox ID="txtName1" runat="server" CssClass="ipt_3"></asp:TextBox><br />
                    </div>
                </div>
                <%--合盘--%>
                <div class="block">
                    <div class="box_1">
                        <div class="box_t">
                            第二当事人信息
                        </div>
                        <div class="box_c">

                            <span class="fred">*</span><strong>阳历生日：</strong>
                            <uc1:DatePicker ID="DatePicker2" runat="server"></uc1:DatePicker>
                            <asp:CheckBox ID="chkDaylight2" runat="server" />
                            <lable class="fsred"><strong>夏令时</strong></lable>
                            <asp:UpdatePanel ID="UpdatePaneld" runat="server">
                                <ContentTemplate>
                                    <div style="float:left;width:77px"><span class="fred">*</span><strong>出生地点：</strong></div>
                                    <div style="width:500px">
                                    <uc1:District ID="District2" runat="server"></uc1:District>
                                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="clear"></div>
                            <span class="fred">*</span><strong>所属时区：</strong>
                            <asp:DropDownList ID="drpTimeZone2" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            时区
                            <br />
                            &nbsp;<strong>姓 名：</strong><asp:TextBox ID="txtName2" runat="server" CssClass="ipt_3"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="box_1">
                        <div class="box_t">
                            合盘信息
                        </div>
                        <div class="box_c">
                            <span class="fred">*</span><strong>合盘类型：</strong>
                            <asp:DropDownList ID="drpCompareType" runat="server" CssClass="sel_0">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <%--行运--%>
                <div class="block box_1">
                    <div class="box_t">
                        推运信息
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>行运日期：</strong>
                        <uc1:DatePicker ID="DatePickert1" Type="3" runat="server"></uc1:DatePicker>

                    </div>
                </div>
                <%--月限--%>
                <div class="block box_1">
                    <div class="box_t">
                        推运信息
                    </div>
                    <div class="box_c">
                        <span class="fred">*</span><strong>推进类型：</strong>
                        <asp:DropDownList ID="drpProgressType" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="次限（365.25636）" Value="2"></asp:ListItem>
                            <asp:ListItem Text="三限（29.530588）" Value="3"></asp:ListItem>
                            <asp:ListItem Text="三限（27.321582）" Value="4"></asp:ListItem>
                        </asp:DropDownList>

                        <span class="fred">*</span><strong>推进日期：</strong>
                        <uc1:DatePicker ID="DatePickert2" Type="3" runat="server"></uc1:DatePicker>

                    </div>
                </div>
                <%--反照--%>
                <div class="block box_1">
                    <div class="box_t">
                        推运信息
                    </div>
                    <div class="box_c">
                        <span class="fred">*</span><strong>反照类型：</strong>
                        <asp:DropDownList ID="drpReturnType" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="太阳反照" Value="4"></asp:ListItem>
                            <asp:ListItem Text="月亮反照" Value="5"></asp:ListItem>
                        </asp:DropDownList>

                        <span class="fred">*</span><strong>推运日期：</strong>
                        <uc1:DatePicker ID="DatePickert3" Type="3" runat="server"></uc1:DatePicker>

                        <asp:UpdatePanel ID="UpdatePanelh" runat="server">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>推运地点：</strong>
                                <uc1:District ID="Districtt3" runat="server"></uc1:District>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%--太阳弧--%>
                <div class="block box_1">
                    <div class="box_t">
                        推运信息
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>推运日期：</strong>
                        <uc1:DatePicker ID="DatePickert4" Type="3" runat="server"></uc1:DatePicker>

                    </div>
                </div>
                <div class="box_1">
                    <div class="box_t">
                        <a href="javascript:void(0)" class="box_ta">星体与容许度设置</a>
                    </div>
                    <div class="box_c" style="display: none;">
                        &nbsp;<strong>相位容许度：合相0°<asp:DropDownList ID="drpAspect0" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                            冲相180°<asp:DropDownList ID="drpAspect180" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            刑相90°<asp:DropDownList ID="drpAspect90" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            三合120°<asp:DropDownList ID="drpAspect120" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            六合60°<asp:DropDownList ID="drpAspect60" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                        </strong>
                        <br />
                        <div class="line_02">
                        </div>
                        &nbsp;<strong>星体显示：</strong>
                        <asp:CheckBox ID="star1" runat="server" Text="太阳" Checked="true" />
                        <asp:CheckBox ID="star2" runat="server" Text="月亮" Checked="true" />
                        <asp:CheckBox ID="star3" runat="server" Text="水星" Checked="true" />
                        <asp:CheckBox ID="star4" runat="server" Text="金星" Checked="true" />
                        <asp:CheckBox ID="star5" runat="server" Text="火星" Checked="true" />
                        <asp:CheckBox ID="star6" runat="server" Text="木星" Checked="true" />
                        <br />
                        &nbsp;
                        <asp:CheckBox ID="star7" runat="server" Text="土星" Checked="true" />
                        <asp:CheckBox ID="star8" runat="server" Text="天王星" Checked="true" />
                        <asp:CheckBox ID="star9" runat="server" Text="海王星" Checked="true" />
                        <asp:CheckBox ID="star10" runat="server" Text="冥王星" Checked="true" /><br />
                        <div class="line_02">
                        </div>
                        &nbsp;<strong>小星体显示：</strong>
                        <asp:CheckBox ID="star11" runat="server" Text="凯龙星" />
                        <asp:CheckBox ID="star12" runat="server" Text="谷神星" />
                        <asp:CheckBox ID="star13" runat="server" Text="智神星" />
                        <asp:CheckBox ID="star14" runat="server" Text="婚神星" />
                        <asp:CheckBox ID="star15" runat="server" Text="灶神星" />
                        <br />
                        &nbsp;
                        <asp:CheckBox ID="star16" runat="server" Text="北交点" />
                        <asp:CheckBox ID="star17" runat="server" Text="莉莉丝" />
                        <asp:CheckBox ID="star18" runat="server" Text="福点" />
                        <asp:CheckBox ID="star19" runat="server" Text="宿命点" />
                        <asp:CheckBox ID="star20" runat="server" Text="东升点" />
                        <br />
                    </div>
                    <asp:HiddenField ID="hdType" runat="server" Value="10" />
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_03" PostBackUrl="AstroChart.aspx"
                        OnClientClick="javascript:setTimeout('document.forms[0].action= document.location.href;',500);">开始排盘</asp:LinkButton>
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

</asp:Content>
