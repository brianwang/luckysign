<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    Inherits="WebForAdmin.Customer.MasterList" CodeBehind="MasterList.aspx.cs" %>

<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>会员管理</h2>
    <p id="page-intro">
        请按以下条件组合查询：
    </p>
    <fieldset class="column-left">
        <p>
            <label>
                昵称，Email</label><asp:TextBox ID="txtName" CssClass="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>模糊查询 空格分隔 空白则为全部</small>
        </p>

        <p>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="查询" OnClick="Unnamed1_Click" />
        </p>
    </fieldset>
    <fieldset class="column-right">
        <p>
            <label>
                问题分类</label>
            <asp:DropDownList ID="drpQACate" runat="server"></asp:DropDownList>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
    </fieldset>
    <!-- End .shortcut-buttons-set -->
    <div class="clear">
    </div>
    <!-- End .clear -->
    <div class="content-box">
        <!-- Start Content Box -->
        <div class="content-box-header">
            <h3>查询结果</h3>
            <div class="clear">
            </div>
        </div>
        <!-- End .content-box-header -->
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <!-- This is the target div. id must match the href of this div's tab -->
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
                <table>
                    <thead>
                        <tr>
                            <th>序号
                            </th>
                            <th>账号
                            </th>
                            <th>昵称
                            </th>
                            <th>分类
                            </th>
                            <th>分类类型
                            </th>
                            <th>操作
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="6">
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
                                        <%# Eval("Email")%>
                                    </td>
                                    <td>
                                        <%# Eval("NickName")%>
                                    </td>
                                    <td>
                                        <%# Eval("Name")%>
                                    </td>
                                    <td>
                                        <%#AppCmn.AppEnum.GetCategoryType(int.Parse(Eval("Type").ToString()))%>
                                    </td>
                                    <td>
                                        <!-- Icons -->
                                        <a href='<%# Eval("deleteurl")%><%# Eval("SysNo")%>'
                                            title="删除">
                                            <img src="../WebResources/images/icons/cross.png" alt="删除" /></a>
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
