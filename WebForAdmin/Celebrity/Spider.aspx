<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="Spider.aspx.cs" Inherits="WebForAdmin.Celebrity.Spider" %>

<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    $(document).ready(function() {
    $("#<%= txtTimeBegin.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '-200:+50',
            monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
            dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
            dateFormat: 'yy-mm-dd' 
        }
);
        $("#<%= txtTimeEnd.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '-200:+50',
            monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
            dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
            dateFormat: 'yy-mm-dd'
        }
);
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        蜘蛛抓取结果</h2>
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
                是否已导入</label>
            <asp:DropDownList ID="drpInput" runat="server" CssClass="small-input">
                <asp:ListItem Text="全部" Value="2" Selected="True"></asp:ListItem>
                <asp:ListItem Text="已导入" Value="1"></asp:ListItem>
                <asp:ListItem Text="未导入" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button CssClass="button" runat="server" Text="查询" OnClick="Unnamed1_Click" />
        </p>
    </fieldset>
    <fieldset class="column-right">
        <p>
            <label>
                时间段选择</label><asp:TextBox ID="txtTimeBegin" CssClass="text-input small-input" runat="server"></asp:TextBox>
            &nbsp;—&nbsp;
            <asp:TextBox ID="txtTimeEnd" CssClass="text-input small-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>不选择则为全部,格式为2010-12-31</small>
        </p>
        <p>
            <label>
                国家选择</label>
                <asp:DropDownList ID="drpNation" runat="server" CssClass="small-input">
            </asp:DropDownList>
            
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
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
                <div class="notification attention png_bg" style="display: none;">
                    <a href="#" class="close">
                        <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                            alt="close" /></a>
                    <div>
                        <asp:Literal ID="ltrNotice" runat="server"></asp:Literal>
                    </div>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th>
                                <input class="check-all" type="checkbox" id="checkall" runat="server" />
                            </th>
                            <th>
                                名字
                            </th>
                            <th>
                                出生时间
                            </th>
                            <th>
                                准确时间
                            </th>
                            <th>
                                出生地点
                            </th>
                            <th>
                                性别
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <td colspan="6">
                                <div class="bulk-actions align-left">
                                    <asp:Button runat="server" Text="批量导入" OnClick="Unnamed2_Click" /></div>
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
                                        <asp:CheckBox runat="server" />
                                    </td>
                                    <td>
                                        <%# Eval("FamousName")%>
                                    </td>
                                    <td>
                                        <%# Eval("Birthtmp")%>
                                    </td>
                                    <td>
                                        <%# AppCmn.AppEnum.GetBOOL(int.Parse(Eval("IsUnknow").ToString())^1)%>
                                    </td>
                                    <td>
                                        <%# Eval("HomeTown")%>
                                    </td>
                                    <td>
                                        <%# AppCmn.AppEnum.GetGender(int.Parse(Eval("Gender").ToString()))%>
                                    </td>
                                    <td>
                                        <!-- Icons -->
                                        <a href="Edit.aspx?type=input&id=<%# Eval("SysNo")%>" target="_blank" title="导入" style="<%# Eval("Display")%>">
                                            <img src="../WebResources/images/icons/hammer_screwdriver.png" alt="导入" /></a>
                                        <a href="http://www.astrotheme.com/portraits/<%# Eval("AstroThemeID")%>.htm" title="源页面"
                                            target="_blank">
                                            <img src="../WebResources/images/icons/astrotheme.bmp" alt="源页面" /></a>
                                        <a href="http://en.wikipedia.org/wiki/<%# Eval("FamousName")%>" title="WIKI" target="_blank">
                                            <img src="../WebResources/images/icons/Wiki.bmp" alt="WIKI" /></a>
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
