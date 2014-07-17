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
         <div class="index_left">
            <!--煮酒论命-->
            <div class="index_left_box">
                <div class="index_left_new_t" style="color: #a4534b; font-size: 16px">发布问题</div>

                <div class="index_left_new_list">
                    <div class="pay_140218">
                        <ul class="pay_140218_ul">
                            <li><span class="t">分&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;类：</span><span class="c"><asp:DropDownList ID="DropDownList1" runat="server" onchange="javascript:qaCateChanged(this);">
                        </asp:DropDownList><br />
                            </span><span id="Span1" runat="server">为您的问题选择一个合适的分类</span><div class="clear"></div>
                            </li>
                            <li><span class="t">标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：</span><span class="c"><asp:TextBox ID="TextBox1" CssClass="pay_140218_input" runat="server"></asp:TextBox><br />
                            </span><span id="Span2" runat="server">标题长度不要超过200字符</span><div class="clear"></div>
                            </li>
                        </ul>

                        <%--<div class="pay_140218_t" style="margin-top: 10px">问题描述</div>

                        <div class="pay_140218_samp">问题描述<span>越简单明确</span>，越容易得到满意的解答。问题越多，费用越高，</div>

                        <ul class="pay_140218_ul">
                            <li><span class="t">主要问题1：</span><span class="c"><asp:TextBox ID="TextBox2" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">主要问题2：</span><span class="c"><asp:TextBox ID="TextBox3" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">主要问题3：</span><span class="c"><asp:TextBox ID="TextBox4" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                        </ul>--%>

                        <div class="pay_140218_t">问题详情</div>

                        <div class="pay_140218_content">
                            可补充问题背景，其他问题等。<br />
                            <FTB:FreeTextBox id="FreeTextBox1" runat="Server" EnableHtmlMode="false" EnableToolbars="false" DesignModeCss="tarea" Width="560px" Height="200px" />
                            <br />
                            <br />
                            悬赏积分：<asp:TextBox ID="txtPoint" CssClass="pay_140218_input" runat="server"></asp:TextBox>
                            (您目前拥有 <strong class="fred">
                            <asp:Literal ID="ltrPoint" runat="server"></asp:Literal></strong> 积分) <br /><span id="PointTip"
                                runat="server">悬赏额度越高，咨询师的积极性也会越高</span><br />
                            <%--联系方式：<asp:TextBox ID="TextBox6" CssClass="pay_140218_input" runat="server"></asp:TextBox><br />
                            <span>仅网站客服可见，以方便为您提供服务。</span>--%>
                        </div>

                        <div class="pay_140218_t">相关命盘信息</div>

                        <div class="pay_140218_content">
                            求测类型：<asp:DropDownList ID="DropDownList2" runat="server" onchange="javascript:qaTypeChanged(this);">
                            </asp:DropDownList><span id="Span3" runat="server">请根据您的问题需要仔细选择该类型</span>
                        </div>

                        <div id="setinfo" class="pay_140218_tab">
                            <div class="pay_140218_tab_t"><span id="firsttab" class="current" onclick="javascript:$('.current').removeClass('current');$(this).addClass('current');secondform.style.display='none';firstform.style.display='';">第一当事人信息</span><span id="secondtab" style="display: none;" onclick="javascript:$('.current').removeClass('current');$(this).addClass('current');secondform.style.display='';firstform.style.display='none';">第二当事人信息</span></div>

                            <div id="firstform" class="pay_140218_tab_c">
                                <!--第一当事人信息-->
                                <ul class="pay_140218_ul">
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">阳历生日：</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker3" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" /><font style="font-weight: bold; color: #a4534b">夏令时</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">出生地点：</span>
                                                <span class="c">
                                                    <uc1:District ID="District3" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">时      区：</span><span class="c"><asp:DropDownList ID="DropDownList3" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">性别：</span><span class="c"><asp:DropDownList ID="DropDownList4" runat="server">
                                        <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                </ul>
                            </div>
                            <div id="secondform" style="display: none;" class="pay_140218_tab_c">
                                <!--第二当事人信息-->
                                <ul class="pay_140218_ul">
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">阳历生日：</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker4" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="CheckBox2" runat="server" /><font style="font-weight: bold; color: #a4534b">夏令时</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">出生地点：</span>
                                                <span class="c">
                                                    <uc1:District ID="District4" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">时      区：</span><span class="c"><asp:DropDownList ID="DropDownList5" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">性别：</span><span class="c"><asp:DropDownList ID="DropDownList6" runat="server">
                                        <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                </ul>
                            </div>

                        </div>

                    </div>

                    <div class="clear"></div>

                    <div class="pay_140218_btn">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed3_Click">提交</asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>
        <div class="index_right">
        </div>

        <!--//////////////////////////////////////////////////////////////////-->




















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
