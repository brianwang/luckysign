<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="Keys.aspx.cs" Inherits="WebForAdmin.Celebrity.Keys" %>

<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        案例关键字</h2>
    <p id="page-intro">
        请按以下条件组合查询：</p>
    <fieldset class="column-left">
        <p>
            <label>
                包含字符</label><asp:TextBox ID="txtName" CssClass="text-input medium-input" runat="server"></asp:TextBox>
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
                状态</label>
            <asp:DropDownList ID="drpStatus" runat="server" CssClass="small-input">
                <asp:ListItem Text="全部" Value="100" Selected="True"></asp:ListItem>
                <asp:ListItem Text="正常" Value="0"></asp:ListItem>
                <asp:ListItem Text="已删除" Value="1"></asp:ListItem>
            </asp:DropDownList>
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
                                关键字
                            </th>
                            <th>
                                状态
                            </th>
                             <th>
                                是否置顶
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="6">
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
                                        <%# Eval("Keywords")%>
                                    </td>
                                    <td>
                                        <%# AppCmn.AppEnum.GetState(Eval("DR"))%>
                                    </td>
                                    <td>
                                        <%# AppCmn.AppEnum.GetBOOL(int.Parse(Eval("IsTop").ToString()))%>
                                    </td>
                                    <td>
                                        <!-- Icons -->
                                        <a href='<%# Eval("deleteurl")%><%# Eval("SysNo")%>' title="Delete">
                                            <img src="../WebResources/images/icons/cross.png" alt="Delete" /></a> <a href="<%# Eval("topurl")%><%# Eval("SysNo")%>" title='<%# Eval("topname")%>'>
                                            <img src="../WebResources/images/icons/pencil.png" alt='<%# Eval("topname")%>' /></a>
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
