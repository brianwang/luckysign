<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Initiate.aspx.cs" Inherits="WebForMain.Quest.Initiate" ValidateRequest="false" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>发起咨询-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="main">

        <div class="index_left">
            <!--煮酒论命-->
            <div class="index_left_box">
                <div class="index_left_new_t" style="color: #a4534b; font-size: 16px">发布付费咨询帖</div>

                <div class="index_left_new_list">
                    <div class="pay_140218">
                        <ul class="pay_140218_ul">
                            <li><span class="t">标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：</span><span class="c"><asp:TextBox ID="TextBox1" CssClass="pay_140218_input" runat="server"></asp:TextBox><br />
                                <samp>夺人眼球</samp>的标题，能吸引更多的命理师.</span><div class="clear"></div>
                            </li>
                        </ul>

                        <div class="pay_140218_t" style="margin-top: 10px">问题描述</div>

                        <div class="pay_140218_samp">问题描述<span>越简单明确</span>，越容易得到满意的解答。问题越多，费用越高，</div>

                        <ul class="pay_140218_ul">
                            <li><span class="t">主要问题1：</span><span class="c"><asp:TextBox ID="TextBox2" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">主要问题2：</span><span class="c"><asp:TextBox ID="TextBox3" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">主要问题3：</span><span class="c"><asp:TextBox ID="TextBox4" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                        </ul>

                        <div class="pay_140218_t">问题详情</div>

                        <div class="pay_140218_content">
                            可补充问题背景，其他问题等。<br />
                            <asp:TextBox ID="TextBox5" TextMode="MultiLine" runat="server"></asp:TextBox><br />

                            预计消费：<select><option>个人运势</option>
                            </select><span><samp>充足的预算</samp>能吸引更多优秀的命理师报价。</span><br />
                            联系方式：<select><option>个人运势</option>
                            </select><span>方便网站客服为您服务。</span>
                        </div>

                        <div class="pay_140218_t">相关星盘信息</div>

                        <div class="pay_140218_content">
                            排盘类型：<asp:DropDownList ID="drpType" runat="server" onchange="javascript:qaTypeChanged(this);">
                            </asp:DropDownList><span>如果出生时间误差较大，建议同时做生时校正。</span>
                        </div>

                        <div class="pay_140218_tab">
                            <div class="pay_140218_tab_t"><span class="current">第一当事人信息</span><span>第二当事人信息</span></div>

                            <div class="pay_140218_tab_c">
                                <!--第一当事人信息-->
                                <ul class="pay_140218_ul">
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanela" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">阳历生日：</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="chkDaylight1" runat="server" /><font style="font-weight: bold; color: #a4534b">夏令时</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">出生地点：</span>
                                                <span class="c">
                                                    <uc1:District ID="District1" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">时      区：</span><span class="c"><asp:DropDownList ID="drpTimeZone1" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">性别：</span><span class="c"><asp:DropDownList ID="drpGender1" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                </ul>
                            </div>
                            <div class="pay_140218_tab_c">
                                <!--第二当事人信息-->
                                <ul class="pay_140218_ul">
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">阳历生日：</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker2" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="chkDaylight2" runat="server" /><font style="font-weight: bold; color: #a4534b">夏令时</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">出生地点：</span>
                                                <span class="c">
                                                    <uc1:District ID="District2" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">时      区：</span><span class="c"><asp:DropDownList ID="drpTimeZone2" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">性别：</span><span class="c"><asp:DropDownList ID="drpGender2" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                </ul>
                            </div>

                        </div>

                    </div>

                    <div class="clear"></div>

                    <div class="pay_140218_btn">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed3_Click">提交</asp:LinkButton></div>

                </div>


            </div>





        </div>


        <div class="index_right">
        </div>
    </div>

















    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>
</asp:Content>
