<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Astro.aspx.cs" Inherits="WebForMain.PPLive.Astro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/ControlLibrary/PPPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>����ռ��������_��������_����ǩ</title>
    <meta name="keywords" content="ռ����_��������_����_����_����_����_��������_����ǩ_ռ����ѯ_��������_רҵ����_��������_����_����" />
    <meta name="description" content="����ǩΪ���ṩ���רҵ����ռ�������������������,��֧�������ղع�������,����ǩ��ռ��ʦ��������Ϊ����������,��ѻ�ȡ��׼���Ը����,�������,��������,����������Ե�����" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager runat="server"></asp:ToolkitScriptManager>
    <div class="main">
        <div class="leftbox left">
            <h3>������������</h3>
            <div class="tabs">
                <a href="javascript:void(0)" title="������" class="on">������</a> <a href="javascript:void(0)"
                    title="�����">�����</a> <a href="javascript:void(0)" title="������">������</a>
            </div>
            <%--������--%>
            <div class="pp">
                <div class="block stab">
                    <a href="javascript:void(0)" title="����VS����" class="on">����VS����(Transit)</a> | <a href="javascript:void(0)"
                        title="���޷�">���޷�(Progress)</a> | <a href="javascript:void(0)" title="���շ�">���շ�(Return)</a>
                    | <a href="javascript:void(0)" title="̫�����ȷ�">̫�����ȷ�(Solar Arcs)</a>
                </div>
                <div class="box_1">
                    <div class="box_t">
                        ��������Ϣ
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>�������գ�</strong>
                        <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                        <asp:CheckBox ID="chkDaylight1" runat="server" />
                        <span class="fsred"><strong>����ʱ</strong></span>
                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="float:left;width:77px"><span class="fred">*</span><strong>�����ص㣺</strong></div>
                                <div style="width:500px">
                                <uc1:District ID="District1" runat="server"></uc1:District></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <span class="fred">*</span><strong>����ʱ����</strong>
                        <asp:DropDownList ID="drpTimeZone1" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                        ʱ��
                        <br />
                        &nbsp;<strong>�� ����</strong>
                        <asp:TextBox ID="txtName1" runat="server" CssClass="ipt_3"></asp:TextBox><br />
                    </div>
                </div>
                <%--����--%>
                <div class="block">
                    <div class="box_1">
                        <div class="box_t">
                            �ڶ���������Ϣ
                        </div>
                        <div class="box_c">

                            <span class="fred">*</span><strong>�������գ�</strong>
                            <uc1:DatePicker ID="DatePicker2" runat="server"></uc1:DatePicker>
                            <asp:CheckBox ID="chkDaylight2" runat="server" />
                            <lable class="fsred"><strong>����ʱ</strong></lable>
                            <asp:UpdatePanel ID="UpdatePaneld" runat="server">
                                <ContentTemplate>
                                    <div style="float:left;width:77px"><span class="fred">*</span><strong>�����ص㣺</strong></div>
                                    <div style="width:500px">
                                    <uc1:District ID="District2" runat="server"></uc1:District>
                                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="clear"></div>
                            <span class="fred">*</span><strong>����ʱ����</strong>
                            <asp:DropDownList ID="drpTimeZone2" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            ʱ��
                            <br />
                            &nbsp;<strong>�� ����</strong><asp:TextBox ID="txtName2" runat="server" CssClass="ipt_3"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="box_1">
                        <div class="box_t">
                            ������Ϣ
                        </div>
                        <div class="box_c">
                            <span class="fred">*</span><strong>�������ͣ�</strong>
                            <asp:DropDownList ID="drpCompareType" runat="server" CssClass="sel_0">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <%--����--%>
                <div class="block box_1">
                    <div class="box_t">
                        ������Ϣ
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>�������ڣ�</strong>
                        <uc1:DatePicker ID="DatePickert1" Type="3" runat="server"></uc1:DatePicker>

                    </div>
                </div>
                <%--����--%>
                <div class="block box_1">
                    <div class="box_t">
                        ������Ϣ
                    </div>
                    <div class="box_c">
                        <span class="fred">*</span><strong>�ƽ����ͣ�</strong>
                        <asp:DropDownList ID="drpProgressType" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="���ޣ�365.25636��" Value="2"></asp:ListItem>
                            <asp:ListItem Text="���ޣ�29.530588��" Value="3"></asp:ListItem>
                            <asp:ListItem Text="���ޣ�27.321582��" Value="4"></asp:ListItem>
                        </asp:DropDownList>

                        <span class="fred">*</span><strong>�ƽ����ڣ�</strong>
                        <uc1:DatePicker ID="DatePickert2" Type="3" runat="server"></uc1:DatePicker>

                    </div>
                </div>
                <%--����--%>
                <div class="block box_1">
                    <div class="box_t">
                        ������Ϣ
                    </div>
                    <div class="box_c">
                        <span class="fred">*</span><strong>�������ͣ�</strong>
                        <asp:DropDownList ID="drpReturnType" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="̫������" Value="4"></asp:ListItem>
                            <asp:ListItem Text="��������" Value="5"></asp:ListItem>
                        </asp:DropDownList>

                        <span class="fred">*</span><strong>�������ڣ�</strong>
                        <uc1:DatePicker ID="DatePickert3" Type="3" runat="server"></uc1:DatePicker>

                        <asp:UpdatePanel ID="UpdatePanelh" runat="server">
                            <ContentTemplate>
                                <span class="fred">*</span><strong>���˵ص㣺</strong>
                                <uc1:District ID="Districtt3" runat="server"></uc1:District>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%--̫����--%>
                <div class="block box_1">
                    <div class="box_t">
                        ������Ϣ
                    </div>
                    <div class="box_c">

                        <span class="fred">*</span><strong>�������ڣ�</strong>
                        <uc1:DatePicker ID="DatePickert4" Type="3" runat="server"></uc1:DatePicker>

                    </div>
                </div>
                <div class="box_1">
                    <div class="box_t">
                        <a href="javascript:void(0)" class="box_ta">���������������</a>
                    </div>
                    <div class="box_c" style="display: none;">
                        &nbsp;<strong>��λ����ȣ�����0��<asp:DropDownList ID="drpAspect0" runat="server" CssClass="sel_2">
                        </asp:DropDownList>
                            ����180��<asp:DropDownList ID="drpAspect180" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            ����90��<asp:DropDownList ID="drpAspect90" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            ����120��<asp:DropDownList ID="drpAspect120" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            ����60��<asp:DropDownList ID="drpAspect60" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                        </strong>
                        <br />
                        <div class="line_02">
                        </div>
                        &nbsp;<strong>������ʾ��</strong>
                        <asp:CheckBox ID="star1" runat="server" Text="̫��" Checked="true" />
                        <asp:CheckBox ID="star2" runat="server" Text="����" Checked="true" />
                        <asp:CheckBox ID="star3" runat="server" Text="ˮ��" Checked="true" />
                        <asp:CheckBox ID="star4" runat="server" Text="����" Checked="true" />
                        <asp:CheckBox ID="star5" runat="server" Text="����" Checked="true" />
                        <asp:CheckBox ID="star6" runat="server" Text="ľ��" Checked="true" />
                        <br />
                        &nbsp;
                        <asp:CheckBox ID="star7" runat="server" Text="����" Checked="true" />
                        <asp:CheckBox ID="star8" runat="server" Text="������" Checked="true" />
                        <asp:CheckBox ID="star9" runat="server" Text="������" Checked="true" />
                        <asp:CheckBox ID="star10" runat="server" Text="ڤ����" Checked="true" /><br />
                        <div class="line_02">
                        </div>
                        &nbsp;<strong>С������ʾ��</strong>
                        <asp:CheckBox ID="star11" runat="server" Text="������" />
                        <asp:CheckBox ID="star12" runat="server" Text="������" />
                        <asp:CheckBox ID="star13" runat="server" Text="������" />
                        <asp:CheckBox ID="star14" runat="server" Text="������" />
                        <asp:CheckBox ID="star15" runat="server" Text="������" />
                        <br />
                        &nbsp;
                        <asp:CheckBox ID="star16" runat="server" Text="������" />
                        <asp:CheckBox ID="star17" runat="server" Text="����˿" />
                        <asp:CheckBox ID="star18" runat="server" Text="����" />
                        <asp:CheckBox ID="star19" runat="server" Text="������" />
                        <asp:CheckBox ID="star20" runat="server" Text="������" />
                        <br />
                    </div>
                    <asp:HiddenField ID="hdType" runat="server" Value="10" />
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn_03" PostBackUrl="AstroChart.aspx"
                        OnClientClick="javascript:setTimeout('document.forms[0].action= document.location.href;',500);">��ʼ����</asp:LinkButton>
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
