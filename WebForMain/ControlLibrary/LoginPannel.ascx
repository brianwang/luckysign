<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginPannel.ascx.cs" Inherits="WebForMain.ControlLibrary.LoginPannel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="popup" TargetControlID="Button4" CancelControlID="Button8" PopupControlID="Panel2" BehaviorID="Panel2" runat="server"></asp:ModalPopupExtender>
<asp:Button ID="Button4" Style="display: none;" runat="server" Text="Button" />
<asp:Panel ID="Panel2" runat="server" Style="display: none;">
    <div class="setting_box" style="padding: 10px 25px 25px 25px">
        <div class="mr_left_name" style="padding-bottom: 5px; border-bottom: solid 1px #A4534B; margin-bottom: 10px">
            登录上上签
        </div>
        <ul class="setting_ul" style="width:450px; margin-left:0px">
            <li><span>用户名：</span><div class="setting_r" style="width:350px;">
                <div>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="setting_input"></asp:TextBox>没有账号？立刻<a target="_blank" href="../Passport/Register.aspx">注册</a>
                </div>
            </div>

                <div class="clear"></div>
            </li>
            <li><span>密  码：</span><div class="setting_r" style="width:350px;">
                <div>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="setting_input"></asp:TextBox>
                </div>
            </div>

                <div class="clear"></div>
            </li>
            <li><span>&nbsp;</span>
                <div class="setting_r" style="width:350px;">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <asp:Button ID="Button7" runat="server" CssClass="setting_button1" OnClick="Button7_Click" Text="确定" />
                    <asp:Button ID="Button8" runat="server" CssClass="setting_button2" Text="取消" />
                </div>
                <div class="clear"></div>
            </li>
        </ul>
    </div>
</asp:Panel>
