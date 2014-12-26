<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassEdit.aspx.cs" Inherits="WebForAdmin.Master.PassEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <%--<link rel="stylesheet" href="../WebResources/css/reset.css" type="text/css" media="screen" />
    <!-- Main Stylesheet -->
    <link rel="stylesheet" href="../WebResources/css/style.css" type="text/css" media="screen" />
    <!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
    <link rel="stylesheet" href="../WebResources/css/invalid.css" type="text/css" media="screen" />--%>
<%--    <style type="text/css">
    BODY
    {
         background-image:none;
    }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>
            修改密码</h3>
        <fieldset>
            <p>
                <strong>输入旧密码：</strong>&nbsp;<asp:TextBox ID="txtOldPsd" CssClass="text-input medium-input"
                    runat="server"></asp:TextBox>
            </p>
            <p>
                <strong>输入新密码：</strong>&nbsp;<asp:TextBox ID="txtNewPsd" CssClass="text-input medium-input"
                    runat="server"></asp:TextBox>
            </p>
            <p>
                <strong>重复新密码：</strong>&nbsp;<asp:TextBox ID="txtNewAgain" CssClass="text-input medium-input"
                    runat="server"></asp:TextBox>
            </p>
            <div id="masternoticediv" class="notification attention png_bg" style="display: none;">
                <a href="#" class="close">
                    <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                        alt="close" /></a>
                <div>
                    <asp:Literal ID="ltrNotice" runat="server"></asp:Literal>
                </div>
            </div>
            <div id="mastererrordiv" class="notification error png_bg" style="display: none;">
                <a href="#" class="close">
                    <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                        alt="close" /></a>
                <div>
                    <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                </div>
            </div>
            <input id="Button1" type="button" class="button" value="保存" onclick="javascript:document.getElementById('<%=btn1.ClientID %>').click();" />
            <asp:Button ID="btn1" runat="server" Text="保存"  CssClass="button"
                OnClick="Unnamed1_Click" />
        </fieldset>
    </div>
    </form>
</body>
</html>
