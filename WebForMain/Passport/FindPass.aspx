<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="FindPass.aspx.cs" Inherits="WebForMain.Passport.FindPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�һ�����_����ǩ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <h2>
            �һ�����</h2>
        <div class="dbox">
            <div class="left dle">
                <div class="form_1">
                <dl>
                    <dt style="width:100px">ע��ʱ�����䣺</dt>
                    <dd>
                        <asp:TextBox ID="email" runat="server" class="ipt_1"></asp:TextBox></dd>
                    <div id="emailTip" runat="server">
                    </div>
                </dl>
                 <dl>
                    <dt style="width:100px">��֤�룺</dt>
                    <dd>
                        <asp:TextBox runat="server" class="ipt_1" ID="code"></asp:TextBox><br />
                        <img id="imgVerify" width="115" height="35" style="cursor: pointer;" src="../ControlLibrary/VerifyCode.aspx?"
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
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn_01" OnClick="Unnamed1_Click">���������뵽����</asp:LinkButton></dd>
                </dl>
                </div>
            </div>
            <div class="left line_01">
            </div>
            <div class="left dri">
                <p>
                    ��û������ǩ�˺ţ����� <a href="Register.aspx" title="ע��" class="btn_01">ע��</a></p>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>