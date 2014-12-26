<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="WebForMain.Passport.Login" %>
<%@ Register Src="~/ControlLibrary/PatnerLogin.ascx" TagName="PatnerLogin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>登录上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <h2>
            直接登录</h2>
        <div class="dbox">
            <div class="left dle">
                <div class="form_1">
                <dl>
                    <dt>邮箱：</dt>
                    <dd>
                        <asp:TextBox ID="email" runat="server" class="ipt_1"></asp:TextBox></dd>
                    <div id="emailTip" style="margin-left:320px; color:red;" runat="server">
                    </div>
                </dl>
                <dl>
                    <dt>密码：</dt>
                    <dd>
                        <asp:TextBox class="ipt_1" ID="password1" runat="server" TextMode="Password"></asp:TextBox></dd>
                    <div id="password1Tip" style="margin-left:320px; color:red;" runat="server" >
                    </div>
                </dl>
                <dl>
                    <dt>&nbsp;</dt>
                    <dd>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <label>
                            下次自动登录</label>
                        <a href="FindPass.aspx">忘记密码</a>
                    </dd>
                </dl>
                <dl>
                    <dt>&nbsp;</dt>
                    <dd>
                        <asp:LinkButton id="Unnamed1" runat="server" class="btn_01" OnClick="Unnamed1_Click">登录</asp:LinkButton></dd>

                </dl>
                </div>
            </div>
            <div class="left line_01">
            </div>
            <div class="left dri">
                <p>
                    还没有上上签账号？马上 <asp:LinkButton ID="LinkButton1" ToolTip="注册" CssClass="btn_01" runat="server" OnClick="LinkButton1_Click">注册</asp:LinkButton></p>
                 <p>&nbsp;</p>
                <p><uc1:PatnerLogin ID="PatnerLogin1" runat="server"  /></p>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
