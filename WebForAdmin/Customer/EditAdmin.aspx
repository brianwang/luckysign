<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="WebForAdmin.Privilege.EditAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>添加/修改后台用户</h2>
    <p id="page-intro">
        *为必填
    </p>
    <div id="noticediv" class="notification attention png_bg" style="display: none;">
        <a href="#" class="close">
            <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                alt="close" /></a>
        <div>
            <asp:Literal ID="ltrNotice" runat="server"></asp:Literal>
        </div>
    </div>
    <div id="errordiv" class="notification error png_bg" style="display: none;">
        <a href="#" class="close">
            <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                alt="close" /></a>
        <div>
            <asp:Literal ID="ltrError" runat="server"></asp:Literal>
        </div>
    </div>
    <fieldset class="column-left">
        <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
        
        <p>
            <label>
                编号*</label>
            <asp:TextBox ID="txtSysNo" class="text-input small-input" ReadOnly="true" Enabled="false"
                Text="自动生成" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                登录账号*</label>
            <asp:TextBox ID="txtUserName" class="text-input medium-input"  
                Text="" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>用来登录后台的账号</small>
        </p>

    </fieldset>
    <fieldset class="column-right">
        <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
        <p>
            <label>
                前台用户*</label>
            <asp:TextBox ID="txtName" class="text-input medium-inpHiddenField1ut" ReadOnly="true" Enabled="false"
                Text="" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                密码*</label>
            <asp:TextBox ID="txtPass" class="text-input medium-input"  
                Text="" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                与该用户相同权限</label>
            <asp:DropDownList ID="drpPrivilege" class="medium-input" runat="server"></asp:DropDownList>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>可设置与所选用户相同的权限</small>
        </p>
    </fieldset>
    <div class="clear">
    </div>
    <fieldset>
        <p>
            <asp:Button ID="Button1" runat="server" CssClass="button" Text="保存" OnClick="Unnamed3_Click" />
        </p>
    </fieldset>
</asp:Content>
