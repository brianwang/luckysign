<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebForMain.Passport.Register" %>
<%@ Register Src="~/ControlLibrary/PatnerLogin.ascx" TagName="PatnerLogin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>欢迎加入上上签</title>
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
        <h2>欢迎加入上上签</h2>
        <div class="dbox">
            <div class="left dle form_1">
                <dl>
                    <dt>邮箱：</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="email"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_emailTip">
                    </div>
                </dl>
                <dl>
                    <dt>密码：</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="password1" TextMode="Password"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_password1Tip">
                    </div>
                </dl>
                <dl>
                    <dt>重复密码：</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="password2" TextMode="Password"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_password2Tip">
                    </div>
                </dl>
                <dl>
                    <dt>名号：</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="name"></asp:TextBox></dd>
                    <div id="ctl00_ContentPlaceHolder1_nameTip">
                    </div>
                </dl>
                <dl>
                    <dt>我：</dt>
                    <dd>
                        <asp:DropDownList runat="server" class="sel_1" ID="drpType">
                            <asp:ListItem Text="对西洋占星术感兴趣" Value="1"></asp:ListItem>
                            <asp:ListItem Text="对紫薇斗数感兴趣" Value="2"></asp:ListItem>
                            <asp:ListItem Text="对四柱八字感兴趣" Value="3"></asp:ListItem>
                            <asp:ListItem Text="对塔罗牌感兴趣" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                    <div class="onFocus" id="ctl00_ContentPlaceHolder1_typeTip">
                        网站会根据您的选择来显示不同的内容
                    </div>
                </dl>
                <dl>
                    <dt>验证码：</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="code"></asp:TextBox><br />
                        <img id="imgVerify" width="115" height="35" style="cursor: pointer;" src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/VerifyCode.aspx?"
                            alt="看不清？点击更换" onclick="this.src=this.src+'?'" />
                        <a href="javascript:void(0);" onclick="javascript:document.getElementById('imgVerify').src=document.getElementById('imgVerify').src+'?'" title="看不清？点击更换" class="alink_01">看不清？点击更换</a>

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
                            我已经认真阅读并同意上上签<a href="Agreement.aspx" title="阅读协议" target="_blank" class="alink_02">《协议》</a></label>
                    </dd>
                    <div id="agreeTip">
                        <asp:Literal runat="server" ID="ltrAgree"></asp:Literal>
                    </div>
                </dl>
                <dl>
                    <dt>&nbsp;</dt>
                    <dd>
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn_0" OnClick="Unnamed3_Click">注册</asp:LinkButton></dd>
                </dl>
            </div>
            <div class="left line_01">
            </div>
            <div class="left dri">
                <p>
                    已经拥有上上签账号？马上 <asp:LinkButton ID="LinkButton2" ToolTip="登录" CssClass="btn_01" OnClick="LinkButton2_Click" runat="server">登录</asp:LinkButton>
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
