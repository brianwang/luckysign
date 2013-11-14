<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SetPrivilege.aspx.cs" Inherits="WebForAdmin.Privilege.SetPrivilege" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>后台用户权限管理</h2>
    <p id="page-intro">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </p>
    <!-- End .clear -->
    <div class="content-box">
        <!-- Start Content Box -->
        <div class="content-box-header">
            <h3></h3> 
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
                            <th>功能项
                            </th>
                            <th>操作
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="3">
                                
                                <!-- End .pagination -->
                                <div class="clear">
                                </div>
                            </td>
                        </tr>
                    </tfoot>
                    <tbody>
                        <asp:Repeater ID="rptFamous" runat="server" OnItemDataBound="rptFamous_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("SysNo")%><asp:HiddenField ID="HiddenField1" Value='<%# Eval("SysNo")%>' runat="server" />
                                    </td>
                                    <td>
                                        <%# Eval("Name")%>
                                    </td>
                                    <td>
                                        <!-- Icons -->
                                        <asp:CheckBox ID="CheckBox1"  runat="server" />
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
    <fieldset>
       <p>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="保存" OnClick="Unnamed1_Click" />
        </p>
    </fieldset>
</asp:Content>
