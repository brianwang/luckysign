<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MyCollection.aspx.cs" Inherits="WebForMain.Qin.MyCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../ControlLibrary/QinRightPannel.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/ComboShow.ascx" TagName="ComboShow" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ҵ��ղ�-����ǩ</title>
    <style type="text/css">
        .popup {
            filter: alpha(opacity=60);
			-moz-opacity:0.6;
			opacity:0.6;
            background-color: black;
        }
    </style>
    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>CSS/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="page_person1">
        <div class="page_person_img">
            <asp:Image ID="imgPhoto" runat="server" />
        </div>
        <div class="page_person_item">
            <asp:ImageButton runat="server" ImageUrl="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/button4.jpg" OnClick="Unnamed_Click" />
            <asp:ImageButton runat="server" ImageUrl="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/button5.jpg" OnClick="Unnamed_Click1" />
        </div>
        <div class="page_person_search">
            <uc1:Search ID="Search1" runat="server"></uc1:Search>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="height20">
    </div>
    <div class="page_left">
        <div class="page_con_item">
            <ul>
                <li class="<%=tabs[0] %>">
                    <asp:LinkButton runat="server" OnClick="Unnamed5_Click">&#8226; ����</asp:LinkButton></li>
                <li class="<%=tabs[1] %>">
                    <asp:LinkButton runat="server" OnClick="Unnamed3_Click">&#8226; �������</asp:LinkButton></li>
                <li class="<%=tabs[2] %>">
                    <asp:LinkButton runat="server" OnClick="Unnamed4_Click">&#8226; ����</asp:LinkButton></li>
                <li class="<%=tabs[3] %>">
                    <asp:LinkButton runat="server" OnClick="Unnamed7_Click">&#8226; ����</asp:LinkButton></li>
                <li class="<%=tabs[4] %>">
                    <asp:LinkButton runat="server" OnClick="Unnamed6_Click">&#8226; վ����Դ</asp:LinkButton></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="height20">
        </div>
        <uc1:ComboShow ID="ComboShow1" runat="server"></uc1:ComboShow>
        <div class="clear">
        </div>
        <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
    </div>
    <div class="page_right">
        <div class="page_right_box">
            <uc1:RightPannel ID="RightPannel1" runat="server"></uc1:RightPannel>
        </div>
        <div class="height20">
        </div>
        <div class="page_right_box">
            <div class="index_right_a2">
                <a href="#" class="c1"><span></span>����2</a> <a href="#" class="c2"><span></span>��2��</a>
                <a href="#" class="c3"><span></span>����2����</a><br />
                <br />
                <a href="#" class="c4"><span></span>����111</a> <a href="#" class="c5"><span></span>��2��</a>
                <a href="#" class="c6"><span></span>��������</a><br />
                <br />
                <a href="#" class="c7"><span></span>����2</a> <a href="#" class="c8"><span></span>�񾭲�</a>
                <a href="#" class="c9"><span></span>��������</a><br />
                <br />
                <a href="#" class="c10"><span></span>��2��</a> <a href="#" class="c11"><span></span>�񾭲�</a>
                <a href="#" class="c12"><span></span>��2������</a><br />
                <br />
                <a href="#" class="c13"><span></span>����</a> <a href="#" class="c14"><span></span>��2����</a>
                <a href="#" class="c15"><span></span>��������</a><br />
                <br />
                <a href="#" class="c16"><span></span>����</a> <a href="#" class="c17"><span></span>�񾭲�</a>
                <a href="#" class="c18"><span></span>��������</a>
            </div>
        </div>
    </div>
    <asp:Button ID="Button1" style="display:none;" runat="server" Text="Button" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="popup" TargetControlID="Button1" CancelControlID="Button6"  PopupControlID="Panel1"  BehaviorID="Panel1" runat="server"></asp:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" Style="display: none;">
        <div class="mr_left_name">
            <asp:Literal ID="ltrInfo" runat="server"></asp:Literal></div>
        <div class="setting_box">
            <ul class="setting_ul">
                <li><span>���⣺</span><div class="setting_r">
                    <div>
                        <asp:TextBox ID="txtName" runat="server" CssClass="setting_input" Width="208px"></asp:TextBox>
                    </div>
                    <h1></h1>
                </div>
                    <div class="clear"></div>
                </li>
                <li id="urlli" visible="false" runat="server"><span>url��ַ��</span><div class="setting_r">
                    <div>
                        <asp:TextBox ID="txtUrl" runat="server" Width="208px" CssClass="setting_input"></asp:TextBox>
                    </div>
                </div>
                    <div class="clear"></div>
                </li>
                <li id="Literal1" visible="false" runat="server"><span>�Ա�</span><div class="setting_r">
                    <div>
                        <asp:DropDownList ID="drpGender" runat="server" CssClass="select_item">
                            <asp:ListItem Text="��" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ů" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <h1></h1>
                </div>
                    <div class="clear"></div>
                </li>
                <li><span>˵����</span><div class="setting_r">
                    <div>
                        <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" CssClass="setting_textarea"></asp:TextBox>
                    </div>
                </div>
                    <div class="clear"></div>
                </li>
                <li><span>&nbsp;</span>
                    <div class="setting_r">
                        <asp:Button ID="Button5" runat="server" CssClass="setting_button1" OnClick="AddCollection" Text="����" />
                        <asp:Button ID="Button6" runat="server" CssClass="setting_button2" Text="ȡ��" />
                    </div>
                    <div class="clear"></div>
                </li>
            </ul>
        </div>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <%--<script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>--%>
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>
</asp:Content>
