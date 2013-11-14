<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="WebForAdmin.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        欢迎来到上上签后台管理系统</h2>
    <p id="page-intro">
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
                会员信息</label>
            当前网站注册会员总数为：<asp:Literal ID="ltrUserNum" runat="server"></asp:Literal>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                问答信息</label>
            当前网站提问总数为：<asp:Literal ID="ltrQuestNum" runat="server"></asp:Literal>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
    </fieldset>
    <fieldset class="column-right">
        <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
        <p>
            <label>
                资料信息</label>
            当前网站文章总数为：<asp:Literal ID="ltrCmsNum" runat="server"></asp:Literal>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                名人信息</label>
            当前网站名人案例总数为：<asp:Literal ID="ltrFamousNum" runat="server"></asp:Literal>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
    </fieldset>
    <div class="clear">
    </div>
    <fieldset>
        
    </fieldset>
</asp:Content>
