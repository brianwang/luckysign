<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="SendNotice.aspx.cs" Inherits="WebForAdmin.Notice.SendNotice" %>
<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        发送站内公告</h2>
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
    <fieldset id="fieldset1" runat="server" class="column-left">
        <p>
            <label>
                标题</label><asp:TextBox ID="txtTitle" CssClass="text-input medium-input" runat="server"></asp:TextBox>
            <br />
            <small></small>
        </p>
       
        
    </fieldset>
    <fieldset id="fieldset2" runat="server" class="column-right">
         <p>
            <label>
                条件语句</label><asp:TextBox ID="txtWhere" CssClass="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>

    </fieldset>
     <div class="clear">
    </div>
    <fieldset>
        <p>
            <label>
                内容</label>
            <CKEditor:CKEditorControl ID="txtContext" runat="server" Skin="kama"></CKEditor:CKEditorControl>

            <br />
            <small></small>
        </p>
        <p>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="保存" OnClick="Unnamed1_Click" />
        </p>
        </fieldset>
    <!-- End .shortcut-buttons-set -->
    <div class="clear">
    </div>
    <!-- End .clear -->
    <div class="content-box">
        <!-- Start Content Box -->
        <div class="content-box-header">
            <h3>
                历史公告列表</h3>
            <div class="clear">
            </div>
        </div>
        <!-- End .content-box-header -->
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <!-- This is the target div. id must match the href of this div's tab -->
                <table>
                    <thead>
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                内容
                            </th>
                             <th>
                                发送人数
                            </th>
                            <th>
                                条件
                            </th>
                            <th>
                                状态
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="5">
                                <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
                                <!-- End .pagination -->
                                <div class="clear">
                                </div>
                            </td>
                        </tr>
                    </tfoot>
                    <tbody>
                        <asp:Repeater ID="rptFamous" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("SysNo")%>
                                    </td>
                                    <td>
                                        <a href="#" title="<%# Eval("Context")%>"><%# Eval("Title")%></a>
                                    </td>
                                    <td>
                                        <%# Eval("CustomerNum")%>
                                    </td>
                                    <td>
                                        <%# Eval("Condition")%>
                                    </td>
                                    <td>
                                        <%# AppCmn.AppEnum.GetState(Eval("DR"))%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <!-- End #tab1 -->
        </div>
        <!-- End .content-box-content -->
    </div>
    <!-- End .content-box -->
    <div class="clear">
    </div>
</asp:Content>
