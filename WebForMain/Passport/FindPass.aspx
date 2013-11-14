<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="FindPass.aspx.cs" Inherits="WebForMain.Passport.FindPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>找回密码_上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <h2>
            找回密码</h2>
        <div class="dbox">
            <div class="left dle">
                <div class="form_1">
                <dl>
                    <dt style="width:100px">注册时的邮箱：</dt>
                    <dd>
                        <asp:TextBox ID="email" runat="server" class="ipt_1"></asp:TextBox></dd>
                    <div id="emailTip" runat="server">
                    </div>
                </dl>
                 <dl>
                    <dt style="width:100px">验证码：</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="code"></asp:TextBox><br />
                        <img id="imgVerify" width="115" height="35" style="cursor: pointer;" src="../ControlLibrary/VerifyCode.aspx?"
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
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn_01" OnClick="Unnamed1_Click">发送新密码到邮箱</asp:LinkButton></dd>
                </dl>
                </div>
            </div>
            <div class="left line_01">
            </div>
            <div class="left dri">
                <p>
                    还没有上上签账号？马上 <a href="Register.aspx" title="注册" class="btn_01">注册</a></p>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>