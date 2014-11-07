<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="PatternEdit.aspx.cs" Inherits="WebForAnalyse.BaZi.PatternEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '-100:+10',
                monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
                dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
                dateFormat: 'yy-mm-dd'
            }
);
$("#<%= txtDate1.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '-100:+10',
                monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
                dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
                dateFormat: 'yy-mm-dd'
            }
);

        });

        function plus(input) {
            $("#p" + (input+1)).css("display", "");
            $("#2p" + (input+1)).css("display", "");
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        紫薇格局组合分析</h2>
    <p id="page-intro">
        请选择组合：</p>
    <fieldset class="column">
        <p>
            <label>
                日期</label><asp:TextBox ID="txtDate" CssClass="text-input small-input" runat="server"></asp:TextBox>-<asp:TextBox
                    ID="txtDate1" CssClass="text-input small-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <p id="p<%# Container.ItemIndex + 1%>" style="display: none;">
                    <label>
                        星体：</label><asp:DropDownList ID="drpStar" runat="server" CssClass="small-input">
                        </asp:DropDownList>
                    <label>
                        四化：</label><asp:DropDownList ID="drpHua" runat="server" CssClass="small-input">
                        </asp:DropDownList>
                    <label>
                        所在宫：</label><asp:DropDownList ID="drpGong" runat="server" CssClass="small-input">
                        </asp:DropDownList>
                    <label>
                        所在位：</label><asp:DropDownList ID="drpWei" runat="server" CssClass="small-input">
                        </asp:DropDownList>
                    <a href="javascript:plus(<%# Container.ItemIndex + 1%>);">+ </a>
                    <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
                    <!-- Classes for input-notification: success, error, information, attention -->
                    <br />
                    <small></small>
                </p>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
            <ItemTemplate>
                <p id="2p<%# Container.ItemIndex + 1%>" style="display: none;">
                    <label>
                        星体：</label><asp:DropDownList ID="drpStar" runat="server" CssClass="small-input">
                        </asp:DropDownList>
                    <%--<label>
                        四化：</label><asp:DropDownList ID="drpHua" runat="server">
                        </asp:DropDownList>--%>
                    <label>
                        关系：</label><asp:DropDownList ID="drpRel" runat="server" CssClass="small-input">
                            <asp:ListItem Text="同宫" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="对宫" Value="1"></asp:ListItem>
                            <asp:ListItem Text="三合" Value="2"></asp:ListItem>
                            <asp:ListItem Text="三方四正" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    <label>
                        星体：</label><asp:DropDownList ID="drpStar1" runat="server" CssClass="small-input">
                        </asp:DropDownList>
                    <%--<label>
                        四化：</label><asp:DropDownList ID="drpHua1" runat="server">
                        </asp:DropDownList>--%>
                    <a href="javascript:plus(<%# Container.ItemIndex + 1%>);">+ </a>
                    <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
                    <!-- Classes for input-notification: success, error, information, attention -->
                    <br />
                    <small></small>
                </p>
            </ItemTemplate>
        </asp:Repeater>
        <p>
            <asp:Button CssClass="button" runat="server" Text="查询" OnClick="Unnamed1_Click" />
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
                计算结果</h3>
            <div class="clear">
            </div>
        </div>
        <!-- End .content-box-header -->
        <div class="content-box-content">
            <div class="tab-content default-tab" id="tab1">
                <!-- This is the target div. id must match the href of this div's tab -->
                <div  id="noticediv"  class="notification attention png_bg" style="display: none;">
                    <a href="#" class="close">
                        <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                            alt="close" /></a>
                    <div>
                        <asp:Literal ID="ltrNotice" runat="server"></asp:Literal>
                    </div>
                </div>
                <asp:Literal ID="ltrResult" runat="server"></asp:Literal>
            </div>
            <!-- End #tab1 -->
        </div>
        <!-- End .content-box-content -->
    </div>
    <!-- End .content-box -->
    <div class="clear">
    </div>
</asp:Content>
