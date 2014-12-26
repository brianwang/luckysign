<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebForAdmin.Privilege.Admin" %>

<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>后台用户管理</h2>
    <p id="page-intro">
        请按以下条件组合查询：
    </p>
    <fieldset class="column-left">
        <p>
            <label>
                用户名</label><asp:TextBox ID="txtName" CssClass="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>模糊查询 空格分隔 空白则为全部</small>
        </p>
         <p>
            <label>
                拥有权限</label>
             <asp:DropDownList ID="drpPrivilege" runat="server" CssClass="small-input">
            </asp:DropDownList>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
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
                <asp:ListItem Text="全部" Value="100"></asp:ListItem>
                <asp:ListItem Text="正常" Value="0" Selected="True"></asp:ListItem>
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
                            <th>系统编号
                            </th>
                            <th>登录账号
                            </th>
                            <th>前台账号
                            </th>
                            <th>前台昵称
                            </th>
                            <th>创建时间
                            </th>
                            <th>最后登录
                            </th>
                            <th>操作
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
                                        <%# Eval("UserName")%>
                                    </td>
                                    <td>
                                        <%# Eval("Email")%>
                                    </td>
                                    <td>
                                        <%# Eval("NickName")%>
                                    </td>
                                    <td>
                                        <%#DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd")%>
                                    </td>
                                    <td>
                                        <%#DateTime.Parse(Eval("LastLogin").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                                    </td>
                                    <td>
                                        <!-- Icons -->
                                        <a href="EditAdmin.aspx?type=edit&id=<%# Eval("SysNo")%>" title="详情/修改">
                                            <img src="../WebResources/images/icons/pencil.png" alt="Edit" />详情/修改</a>  <a href="SetPrivilege.aspx?id=<%# Eval("SysNo")%>" title='设置权限'>
                                                <img src="../WebResources/images/icons/pencil.png" alt='' />设置权限</a>  <a href='<%# Eval("deleteurl")%><%# Eval("SysNo")%>'
                                                    title="删除">
                                                    <img src="../WebResources/images/icons/cross.png" alt="删除" />删除</a>
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
