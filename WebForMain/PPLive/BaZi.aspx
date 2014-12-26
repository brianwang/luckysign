<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="BaZi.aspx.cs" Inherits="WebForMain.PPLive.BaZi" %>

<%@ Register Src="~/ControlLibrary/PPPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>������������-��������-����ǩ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="leftbox left">
            <h3>������������</h3>
            <div class="line_03">
            </div>
            <div class="block show pp">
                <div class="box_1">
                    <div class="box_c">

                        <span class="fred">*</span><strong>�������գ�</strong>
                        <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                        <br />
                        <span class="fred">&nbsp;</span><strong>��ʱУ����</strong>
                        <asp:CheckBox ID="chkRealTime" runat="server" onclick="checkrealtime(this);" Checked="true" /><span
                            class="fsred"><strong>��Ҫ������̫��ʱ</strong></span><br />
                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" RenderMode="Inline">
                            <ContentTemplate>
                                <div style="float: left; width: 77px"><span class="fred">*</span><strong>�����ص㣺</strong></div>
                                <div style="width: 500px">
                                    <uc1:District ID="District1" runat="server"></uc1:District>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <span class="fred">*</span><strong>�� ��</strong>
                        <asp:RadioButtonList ID="drpGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="��" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ů" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <span class="fred">*</span><strong>�������ͣ�</strong><asp:RadioButtonList ID="rblType"
                            runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="ȫ��" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="����" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </div>
                </div>
                <%--<div class="box_1">
                    <div class="box_t">
                        <a href="javascript:void(0)" class="box_ta">�߼�ѡ��</a></div>
                    <div class="box_c" style="display: none;">
                        &nbsp;<strong>�����ŷ���</strong>
                        <asp:DropDownList ID="drpLeaf" runat="server" CssClass="sel_0">
                        </asp:DropDownList>
                        &nbsp;<strong>�����ŷ���</strong>
                        <asp:DropDownList ID="drpTianma" runat="server" CssClass="sel_2">
                            <asp:ListItem Text="����" Value="0"></asp:ListItem>
                            <asp:ListItem Text="����" Value="1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<strong>�����ŷ���</strong>
                        <asp:DropDownList ID="drpShenzhu" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="��������֧" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="��������֧" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        &nbsp;<strong>��ʹ�����ŷ���</strong>
                        <asp:DropDownList ID="drpShiShang" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="������ͬ" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="������ͬ" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<strong>�����˽��ߣ�</strong>
                        <asp:DropDownList ID="drpTransit" runat="server" CssClass="sel_0">
                            <asp:ListItem Text="��ũ�����껻��" Value="1"></asp:ListItem>
                            <asp:ListItem Text="��ũ�����ջ���" Value="0" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <div class="line_02">
                        </div>
                    </div>
                </div>--%>
                <asp:LinkButton runat="server" CssClass="btn_03" OnClientClick="javascript:setTimeout('document.forms[0].action= document.location.href;',500);"
                    PostBackUrl="BaZiChart.aspx">��ʼ����</asp:LinkButton>
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
