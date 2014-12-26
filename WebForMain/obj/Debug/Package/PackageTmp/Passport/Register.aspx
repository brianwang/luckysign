<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebForMain.Passport.Register" %>
<%@ Register Src="~/ControlLibrary/PatnerLogin.ascx" TagName="PatnerLogin" TagPrefix="uc1" %>
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
                    <dt>���䣺</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="email"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_emailTip">
                    </div>
                </dl>
                <dl>
                    <dt>���룺</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="password1" TextMode="Password"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_password1Tip">
                    </div>
                </dl>
                <dl>
                    <dt>�ظ����룺</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="password2" TextMode="Password"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_password2Tip">
                    </div>
                </dl>
                <dl>
                    <dt>���ţ�</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="name"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_nameTip">
                    </div>
                </dl>
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
                    <dt>��֤�룺</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="code"></asp:TextBox><br />
                        <img id="imgVerify" width="115" height="35" style="cursor: pointer;" src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/VerifyCode.aspx?"
                            alt="�����壿�������" onclick="this.src=this.src+'?'" />
                        <a href="javascript:void(0);" onclick="javascript:document.getElementById('imgVerify').src=document.getElementById('imgVerify').src+'?'" title="�����壿�������" class="alink_01">�����壿�������</a>

                    </dd>
                    <div id="ctl00_ContentPlaceHolder1_codeTip">
                        <asp:Literal runat="server" ID="ltrCode"></asp:Literal>
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
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn_0" OnClick="Unnamed3_Click">ע��</asp:LinkButton></dd>
                </dl>
            </div>
            <div class="left line_01">
            </div>
            <div class="left dri">
                <p>
                    �Ѿ�ӵ������ǩ�˺ţ����� <asp:LinkButton ID="LinkButton2" ToolTip="��¼" CssClass="btn_01" OnClick="LinkButton2_Click" runat="server">��¼</asp:LinkButton>
                </p>
                 <p>&nbsp;</p>
                <p><uc1:PatnerLogin ID="PatnerLogin1" runat="server"  /></p>
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
