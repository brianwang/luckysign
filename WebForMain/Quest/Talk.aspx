<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Talk.aspx.cs" Inherits="WebForMain.Quest.Talk" ValidateRequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��������-����ǩ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="main">
         <div class="index_left">
            <!--�������-->
            <div class="index_left_box">
                <div class="index_left_new_t" style="color: #a4534b; font-size: 16px">��������</div>

                <div class="index_left_new_list">
                    <div class="pay_140218">
                        <ul class="pay_140218_ul">
                            <li><span class="t">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�ࣺ</span><span class="c"><asp:DropDownList ID="DropDownList1" runat="server" onchange="javascript:qaCateChanged(this);">
                        </asp:DropDownList><br />
                            </span><span id="Span1" runat="server">Ϊ��������ѡ��һ�����ʵķ���</span><div class="clear"></div>
                            </li>
                            <li><span class="t">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�⣺</span><span class="c"><asp:TextBox ID="TextBox1" CssClass="pay_140218_input" runat="server"></asp:TextBox><br />
                            </span><span id="Span2" runat="server">���ⳤ�Ȳ�Ҫ����200�ַ�</span><div class="clear"></div>
                            </li>
                        </ul>

                        <%--<div class="pay_140218_t" style="margin-top: 10px">��������</div>

                        <div class="pay_140218_samp">��������<span>Խ����ȷ</span>��Խ���׵õ�����Ľ������Խ�࣬����Խ�ߣ�</div>

                        <ul class="pay_140218_ul">
                            <li><span class="t">��Ҫ����1��</span><span class="c"><asp:TextBox ID="TextBox2" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">��Ҫ����2��</span><span class="c"><asp:TextBox ID="TextBox3" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">��Ҫ����3��</span><span class="c"><asp:TextBox ID="TextBox4" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                        </ul>--%>

                        <div class="pay_140218_t">��������</div>

                        <div class="pay_140218_content">
                            �ɲ������ⱳ������������ȡ�<br />
                            <FTB:FreeTextBox id="FreeTextBox1" runat="Server" EnableHtmlMode="false" EnableToolbars="false" DesignModeCss="tarea" Width="560px" Height="200px" />
                            <br />
                            <br />
                            ���ͻ��֣�<asp:TextBox ID="txtPoint" CssClass="pay_140218_input" runat="server"></asp:TextBox>
                            (��Ŀǰӵ�� <strong class="fred">
                            <asp:Literal ID="ltrPoint" runat="server"></asp:Literal></strong> ����) <br /><span id="PointTip"
                                runat="server">���Ͷ��Խ�ߣ���ѯʦ�Ļ�����Ҳ��Խ��</span><br />
                            <%--��ϵ��ʽ��<asp:TextBox ID="TextBox6" CssClass="pay_140218_input" runat="server"></asp:TextBox><br />
                            <span>����վ�ͷ��ɼ����Է���Ϊ���ṩ����</span>--%>
                        </div>

                        <div class="pay_140218_t">���������Ϣ</div>

                        <div class="pay_140218_content">
                            ������ͣ�<asp:DropDownList ID="DropDownList2" runat="server" onchange="javascript:qaTypeChanged(this);">
                            </asp:DropDownList><span id="Span3" runat="server">���������������Ҫ��ϸѡ�������</span>
                        </div>

                        <div id="setinfo" class="pay_140218_tab">
                            <div class="pay_140218_tab_t"><span id="firsttab" class="current" onclick="javascript:$('.current').removeClass('current');$(this).addClass('current');secondform.style.display='none';firstform.style.display='';">��һ��������Ϣ</span><span id="secondtab" style="display: none;" onclick="javascript:$('.current').removeClass('current');$(this).addClass('current');secondform.style.display='';firstform.style.display='none';">�ڶ���������Ϣ</span></div>

                            <div id="firstform" class="pay_140218_tab_c">
                                <!--��һ��������Ϣ-->
                                <ul class="pay_140218_ul">
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�������գ�</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker3" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" /><font style="font-weight: bold; color: #a4534b">����ʱ</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�����ص㣺</span>
                                                <span class="c">
                                                    <uc1:District ID="District3" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">ʱ      ����</span><span class="c"><asp:DropDownList ID="DropDownList3" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">�Ա�</span><span class="c"><asp:DropDownList ID="DropDownList4" runat="server">
                                        <asp:ListItem Text="��" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Ů" Value="0"></asp:ListItem>
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                </ul>
                            </div>
                            <div id="secondform" style="display: none;" class="pay_140218_tab_c">
                                <!--�ڶ���������Ϣ-->
                                <ul class="pay_140218_ul">
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�������գ�</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker4" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="CheckBox2" runat="server" /><font style="font-weight: bold; color: #a4534b">����ʱ</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�����ص㣺</span>
                                                <span class="c">
                                                    <uc1:District ID="District4" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">ʱ      ����</span><span class="c"><asp:DropDownList ID="DropDownList5" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">�Ա�</span><span class="c"><asp:DropDownList ID="DropDownList6" runat="server">
                                        <asp:ListItem Text="��" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Ů" Value="0"></asp:ListItem>
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                </ul>
                            </div>

                        </div>

                    </div>

                    <div class="clear"></div>

                    <div class="pay_140218_btn">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed3_Click">�ύ</asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>
        <div class="index_right">
        </div>

        <!--//////////////////////////////////////////////////////////////////-->




















        <div class="leftbox left">
            <h3>
                ��������</h3>
            <div class="line_03">
            </div>
            <div class="block show pp">
                <div class="box_1">
                    <div class="box_c" style="padding-top:15px">
                        <span class="fred">*</span><strong>�� �ࣺ</strong><asp:DropDownList ID="drpCate" runat="server" >
                        </asp:DropDownList>
                        <div style="display:inline-block"><span id="CateTip" runat="server">Ϊ���Ļ���ѡ��һ�����ʵķ���</span></div>
                        <div class="clear"></div>
                        <span class="fred">*</span><strong>�� �⣺</strong><asp:TextBox ID="txtTitle" runat="server" CssClass="ipt_1"></asp:TextBox>
                        <%--<span class="err"></span><span class="rgt">--%>
                        <div style="display:inline-block"><span id="TitleTip" runat="server">���ⳤ�Ȳ�Ҫ����200�ַ�</span></div>
                        <div class="clear"></div>
                        <span class="fred">*</span><strong>�������ͣ�</strong><asp:DropDownList ID="drpType" runat="server" onchange="javascript:qaTypeChanged(this);">
                        </asp:DropDownList>
                        <div style="display:inline-block"><span id="TypeTip" runat="server">����ɸ������̰���Ŷ</span></div>
                        <div class="clear"></div>
                        
                    </div>
                </div>
                <div id="info1" class="box_1 block">
                    <div class="box_t">
                        ��һ��������Ϣ</div>
                    <div class="box_c">
                        <asp:UpdatePanel ID="UpdatePanela" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>�������գ�</strong>
                                <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                                <asp:CheckBox ID="chkDaylight1" runat="server" /><span class="fsred"><strong>����ʱ</strong></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>�����ص㣺</strong>
                                <div style="display:block;width:546px;float:right;text-align:left">
                                	<uc1:District ID="District1" runat="server"></uc1:District>
                                </div>
                                <span id="District1Tip" runat="server"></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clear"></div>
                        &nbsp;<strong>����ʱ����</strong>
                        <asp:DropDownList ID="drpTimeZone1" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                        ʱ��
                        <br />
                        <span class="fred">*</span><strong>�� ��</strong>
                        <asp:RadioButtonList ID="drpGender1" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="��" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ů" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </div>
                </div>
                <div id="info2" class="box_1 block">
                    <div class="box_t">
                        �ڶ���������Ϣ</div>
                    <div class="box_c">
                        <asp:UpdatePanel ID="UpdatePanelc" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>�������գ�</strong>
                                <uc1:DatePicker ID="DatePicker2" runat="server"></uc1:DatePicker>
                                <asp:CheckBox ID="chkDaylight2" runat="server" /><span class="fsred"><strong>����ʱ</strong></span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="UpdatePaneld" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>�����ص㣺</strong>
                                <div style="display:block;width:550px;float:right;text-align:left">
                                <uc1:District ID="District2" runat="server"></uc1:District>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="clear"></div>
                        &nbsp;<strong>����ʱ����</strong>
                        <asp:DropDownList ID="drpTimeZone2" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                        ʱ��
                        <br />
                        <span class="fred">*</span><strong>�� ��</strong><asp:RadioButtonList ID="drpGender2"
                            runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="��" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ů" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </div>
                </div>
                <div class="box_1">
                    <div class="line_02">
                        &nbsp;
                    </div>
                    <div class="box_c" style="padding-top:10px">
                        <%--<strong><span class="fred">*</span>����ʱ�䣺</strong><select class="sel_1"></select><br />--%>
                        <strong style="vertical-align: top"><span class="fred">*</span>�������ݣ�</strong>
                        <FTB:FreeTextBox id="txtContext" runat="Server" EnableHtmlMode="false" EnableToolbars="false" Width="560px" Height="200px" />
                        <%--<asp:TextBox
                            runat="server" ID="txtContext" TextMode="MultiLine" Columns="60" Rows="15" CssClass="tarea"></asp:TextBox>
                        <br />--%>
                        <asp:LinkButton runat="server" CssClass="btn_01" OnClick="Unnamed3_Click"  style="margin-top:10px;">�ύ</asp:LinkButton>
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
