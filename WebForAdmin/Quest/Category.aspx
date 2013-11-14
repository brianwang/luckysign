<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="Category.aspx.cs" Inherits="WebForAdmin.Quest.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        问答分类管理</h2>
    <p id="page-intro">
        <a href="Category.aspx?type=top">返回一级分类列表</a><br /><asp:Button ID="Button2" runat="server"
            Text="添加新分类" onclick="Button2_Click" CssClass="button" /></p>
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
                <asp:Literal ID="ltrParent" runat="server"></asp:Literal></label>
            <br />
            <small></small>
        </p>
        <p>
            <label>
                中文名</label><asp:TextBox ID="txtName" CssClass="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="保存" OnClick="Unnamed1_Click" />
        </p>
    </fieldset>
    <fieldset id="fieldset2" runat="server" class="column-right">
        <p>
            <label>
                状态</label>
            <asp:DropDownList ID="drpStatus" runat="server" CssClass="small-input">
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
            <h3>
                子分类列表</h3>
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
                                分类
                            </th>
                            <th>
                                状态
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="4">
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
                                        <a href="Category.aspx?type=edit&id=<%# Eval("SysNo")%>"><%# Eval("SysNo")%></a>
                                    </td>
                                    <td>
                                        <a href="Category.aspx?type=edit&id=<%# Eval("SysNo")%>"><%# Eval("Name")%></a>
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
