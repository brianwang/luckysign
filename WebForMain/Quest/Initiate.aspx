<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Initiate.aspx.cs" Inherits="WebForMain.Quest.Initiate" ValidateRequest="false" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>������ѯ-����ǩ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="index_left">
            <!--�������-->
            <div class="index_left_box">
                <div class="index_left_new_t" style="color: #a4534b; font-size: 16px">����������ѯ��</div>

                <div class="index_left_new_list">
                    <div class="pay_140218">
                        <ul class="pay_140218_ul">
                            <li><span class="t">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�⣺</span><span class="c"><asp:TextBox ID="txtTitle" CssClass="pay_140218_input" runat="server"></asp:TextBox><br />
                            </span><span id="TitleTip" runat="server">��������ı��⣬���������������ʦ.</span><div class="clear"></div>
                            </li>
                        </ul>

                        <div class="pay_140218_t" style="margin-top: 10px">��������</div>

                        <div class="pay_140218_samp">��������<span>Խ����ȷ</span>��Խ���׵õ�����Ľ������Խ�࣬����Խ�ߣ�</div>

                        <ul class="pay_140218_ul">
                            <li><span class="t">��Ҫ����1��</span><span class="c"><asp:TextBox ID="TextBox2" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">��Ҫ����2��</span><span class="c"><asp:TextBox ID="TextBox3" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                            <li><span class="t">��Ҫ����3��</span><span class="c"><asp:TextBox ID="TextBox4" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><div class="clear"></div>
                            </li>
                        </ul>

                        <div class="pay_140218_t">��������</div>

                        <div class="pay_140218_content">
                            �ɲ������ⱳ������������ȡ�<br />
                            <FTB:FreeTextBox id="txtContext" runat="Server" EnableHtmlMode="false" EnableToolbars="false" DesignModeCss="tarea" Width="560px" Height="200px" /><br />
                            <br />
                            Ԥ�����ѣ�<asp:TextBox ID="txtPay" CssClass="pay_140218_input" runat="server"></asp:TextBox>Ԫ<br />
                            <span id="PayTip" runat="server">�����Ԥ���������������������ʦ���ۡ�</span><br />
                            ��ϵ��ʽ��<asp:TextBox ID="TextBox6" CssClass="pay_140218_input" runat="server"></asp:TextBox><br />
                            <span>����վ�ͷ��ɼ����Է���Ϊ���ṩ����</span>
                        </div>

                        <div class="pay_140218_t">���������Ϣ</div>

                        <div class="pay_140218_content">
                            ������ͣ�<asp:DropDownList ID="drpType" runat="server" onchange="javascript:qaTypeChanged(this);">
                            </asp:DropDownList><span>�������ʱ�����ϴ󣬽���ͬʱ����ʱУ����</span>
                        </div>

                        <div id="setinfo" class="pay_140218_tab">
                            <div class="pay_140218_tab_t"><span id="firsttab" class="current" onclick="javascript:$('.current').removeClass('current');$(this).addClass('current');secondform.style.display='none';firstform.style.display='';">��һ��������Ϣ</span><span id="secondtab" style="display: none;" onclick="javascript:$('.current').removeClass('current');$(this).addClass('current');secondform.style.display='';firstform.style.display='none';">�ڶ���������Ϣ</span></div>

                            <div id="firstform" class="pay_140218_tab_c">
                                <!--��һ��������Ϣ-->
                                <ul class="pay_140218_ul">
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanela" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�������գ�</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker1" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="chkDaylight1" runat="server" /><font style="font-weight: bold; color: #a4534b">����ʱ</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanelb" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�����ص㣺</span>
                                                <span class="c">
                                                    <uc1:District ID="District1" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">ʱ      ����</span><span class="c"><asp:DropDownList ID="drpTimeZone1" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">�Ա�</span><span class="c"><asp:DropDownList ID="drpGender1" runat="server">
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
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�������գ�</span>
                                                <span class="c">
                                                    <uc1:DatePicker ID="DatePicker2" runat="server"></uc1:DatePicker>
                                                    <asp:CheckBox ID="chkDaylight2" runat="server" /><font style="font-weight: bold; color: #a4534b">����ʱ</font></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <span class="t">�����ص㣺</span>
                                                <span class="c">
                                                    <uc1:District ID="District2" runat="server"></uc1:District>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear"></div>
                                    </li>
                                    <li><span class="t">ʱ      ����</span><span class="c"><asp:DropDownList ID="drpTimeZone2" runat="server">
                                    </asp:DropDownList></span><div class="clear"></div>
                                    </li>
                                    <li><span class="t">�Ա�</span><span class="c"><asp:DropDownList ID="drpGender2" runat="server">
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
    </div>
    <div class="clear">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>
</asp:Content>
