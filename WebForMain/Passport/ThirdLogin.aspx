<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ThirdLogin.aspx.cs" Inherits="WebForMain.Passport.ThirdLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��ӭ��������ǩ</title>
    <script type="text/javascript">
        function checkagree(input) {
            if (input.checked) {
                document.getElementById("<%=LinkButton1.ClientID  %>").className = "btn_01";
                document.getElementById("<%=LinkButton1.ClientID  %>").disabled = false;
            }
            else {
                document.getElementById("<%=LinkButton1.ClientID  %>").className = "btn_0";
                document.getElementById("<%=LinkButton1.ClientID  %>").disabled = true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <h2>��ӭ��������ǩ</h2>
        <div class="dbox">
            <div class="left dle form_1">
                <dl>
                    <dt>�ң�</dt>
                    <dd>
                        <asp:DropDownList runat="server" class="sel_1" ID="drpType">
                            <asp:ListItem Text="������ռ��������Ȥ" Value="1"></asp:ListItem>
                            <asp:ListItem Text="����ޱ��������Ȥ" Value="2"></asp:ListItem>
                            <asp:ListItem Text="���������ָ���Ȥ" Value="3"></asp:ListItem>
                            <asp:ListItem Text="�������Ƹ���Ȥ" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                    <div class="onFocus" id="ctl00_ContentPlaceHolder1_typeTip">
                        ��վ���������ѡ������ʾ��ͬ������
                    </div>
                </dl>
                <dl>
                    <dt>&nbsp;</dt>
                    <dd>
                        <asp:CheckBox runat="server" ID="chkAgree" Checked="false" onclick="javascript:checkagree(this);" />
                        <label>
                            ���Ѿ������Ķ���ͬ������ǩ<a href="Agreement.aspx" title="�Ķ�Э��" target="_blank" class="alink_02">��Э�顷</a></label>
                    </dd>
                    <div id="agreeTip">
                        <asp:Literal runat="server" ID="ltrAgree"></asp:Literal>
                    </div>
                </dl>
                <dl>
                    <dt>&nbsp;</dt>
                    <dd>
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn_0" OnClick="LinkButton1_Click">������Ϣ</asp:LinkButton></dd>
                </dl>
            </div>
            <div class="left line_01">
            </div>
            <div class="left dri">
                <p>
                    �Ѿ�ӵ������ǩ�˺ţ����� <a href="Login.aspx" title="��¼" class="btn_01">��¼</a>
                </p>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
        <script src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/formValidator-4.0.1.min.js" type="text/javascript"
        charset="UTF-8"></script>

    <script src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/formValidatorRegex.js" type="text/javascript" charset="UTF-8"></script>

    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/DateTimeMask.js" type="text/javascript"></script>

    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>

    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>
</asp:Content>
