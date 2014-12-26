<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="Articles.aspx.cs" Inherits="WebForAdmin.CMS.Articles" %>
    <%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        查询文章</h2>
    <p id="page-intro">
        请按以下条件组合查询：</p>
    <fieldset class="column-left">
        <p>
            <label>
                名字</label><asp:TextBox ID="txtName" CssClass="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>模糊查询 空格分隔 空白则为全部</small>
        </p>
        <p>
            <label>
                状态</label>
            <asp:DropDownList ID="drpStatus" runat="server" CssClass="small-input">
                <asp:ListItem Text="全部" Value="100"></asp:ListItem>
                <asp:ListItem Text="正常" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="已删除" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button CssClass="button" runat="server" Text="查询" OnClick="Unnamed1_Click" />
        </p>
    </fieldset>
    <fieldset class="column-right">
        <p>
            <label>
                选择所属目录</label><asp:DropDownList ID="drpCate" runat="server" CssClass="medium-input">
                </asp:DropDownList>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
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
                查询结果</h3>
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
                            <th>
                                序号
                            </th>
                            <th>
                                标题
                            </th>
                            <th>
                                所属目录
                            </th>
                            <th>
                                状态
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="6">
                                <uc1:pager id="Pager1" runat="server"></uc1:pager>
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
                                        <a target="_blank" href="Edit.aspx?type=edit&id=<%# Eval("SysNo")%>" title="Edit"><%# Eval("Title")%></a>
                                    </td>
                                    <td>
                                        <%# Eval("Name")%>
                                    </td>
                                    <td>
                                        <%# AppCmn.AppEnum.GetState(Eval("DR"))%>
                                    </td>
                                    <td>
                                        <!-- Icons -->
                                        <a target="_blank" href="Edit.aspx?type=edit&id=<%# Eval("SysNo")%>" title="Edit">
                                            <img src="../WebResources/images/icons/pencil.png" alt="Edit" /></a> <a href='<%# Eval("deleteurl")%><%# Eval("SysNo")%>'
                                                title="Delete">
                                                <img src="../WebResources/images/icons/cross.png" alt="Delete" /></a>
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
