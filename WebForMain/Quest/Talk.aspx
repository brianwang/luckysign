<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Talk.aspx.cs" Inherits="WebForMain.Quest.Talk" ValidateRequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>发布问题-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="leftbox left">
            <h3>
                发新主题</h3>
            <div class="line_03">
            </div>
            <div class="block show pp">
                <div class="box_1">
                    <div class="box_c" style="padding-top:15px">
                        <span class="fred">*</span><strong>分 类：</strong><asp:DropDownList ID="drpCate" runat="server" >
                        </asp:DropDownList>
                        <div style="display:inline-block"><span id="CateTip" runat="server">为您的话题选择一个合适的分类</span></div>
                        <div class="clear"></div>
                        <span class="fred">*</span><strong>标 题：</strong><asp:TextBox ID="txtTitle" runat="server" CssClass="ipt_1"></asp:TextBox>
                        <%--<span class="err"></span><span class="rgt">--%>
                        <div style="display:inline-block"><span id="TitleTip" runat="server">标题长度不要超过200字符</span></div>
                        <div class="clear"></div>
                        <span class="fred">*</span><strong>排盘类型：</strong><asp:DropDownList ID="drpType" runat="server" onchange="javascript:qaTypeChanged(this);">
                        </asp:DropDownList>
                        <div style="display:inline-block"><span id="TypeTip" runat="server">话题可附带命盘案例哦</span></div>
                        <div class="clear"></div>
                        
                    </div>
                </div>
                <div id="info1" class="box_1 block">
                    <div class="box_t">
                        第一当事人信息</div>
                    <div class="box_c">
                        <asp:UpdatePanel ID="UpdatePanela" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>阳历生日：</strong>
                                <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                                <asp:CheckBox ID="chkDaylight1" runat="server" /><span class="fsred"><strong>夏令时</strong></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>出生地点：</strong>
                                <div style="display:block;width:546px;float:right;text-align:left">
                                	<uc1:District ID="District1" runat="server"></uc1:District>
                                </div>
                                <span id="District1Tip" runat="server"></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clear"></div>
                        &nbsp;<strong>所属时区：</strong>
                        <asp:DropDownList ID="drpTimeZone1" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                        时区
                        <br />
                        <span class="fred">*</span><strong>性 别：</strong>
                        <asp:RadioButtonList ID="drpGender1" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </div>
                </div>
                <div id="info2" class="box_1 block">
                    <div class="box_t">
                        第二当事人信息</div>
                    <div class="box_c">
                        <asp:UpdatePanel ID="UpdatePanelc" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>阳历生日：</strong>
                                <uc1:DatePicker ID="DatePicker2" runat="server"></uc1:DatePicker>
                                <asp:CheckBox ID="chkDaylight2" runat="server" /><span class="fsred"><strong>夏令时</strong></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="UpdatePaneld" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>出生地点：</strong>
                                <div style="display:block;width:550px;float:right;text-align:left">
                                <uc1:District ID="District2" runat="server"></uc1:District>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clear"></div>
                        &nbsp;<strong>所属时区：</strong>
                        <asp:DropDownList ID="drpTimeZone2" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                        时区
                        <br />
                        <span class="fred">*</span><strong>性 别：</strong><asp:RadioButtonList ID="drpGender2"
                            runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </div>
                </div>
                <div class="box_1">
                    <div class="line_02">
                        &nbsp;
                    </div>
                    <div class="box_c" style="padding-top:10px">
                        <%--<strong><span class="fred">*</span>持续时间：</strong><select class="sel_1"></select><br />--%>
                        <strong style="vertical-align: top"><span class="fred">*</span>话题内容：</strong>
                        <FTB:FreeTextBox id="txtContext" runat="Server" EnableHtmlMode="false" EnableToolbars="false" Width="560px" Height="200px" />
                        <%--<asp:TextBox
                            runat="server" ID="txtContext" TextMode="MultiLine" Columns="60" Rows="15" CssClass="tarea"></asp:TextBox>
                        <br />--%>
                        <asp:LinkButton runat="server" CssClass="btn_01" OnClick="Unnamed3_Click"  style="margin-top:10px;">提交</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="rightbox left">
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>
</asp:Content>
