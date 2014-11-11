<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="PatternEdit.aspx.cs" Inherits="WebForAnalyse.BaZi.PatternEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
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
            $("#p" + (input + 1)).css("display", "");
            $("#2p" + (input + 1)).css("display", "");
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>八字组合设置</h2>
    <p id="page-intro">
        请设置关系：
    </p>
    <fieldset class="column">
        <p style="display: none;">
            <asp:TextBox ID="txtSign" runat="server"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <label id="p<%# Container.ItemIndex + 1%>" style="display: none;">

                                <asp:DropDownList ID="drpItem" runat="server" CssClass="small-input">
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpType" runat="server" CssClass="small-input" AutoPostBack="true" OnSelectedIndexChanged="drpType_SelectedIndexChanged">
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpCondition" runat="server" CssClass="small-input">
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpTarget" runat="server" CssClass="small-input">
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpLogic" runat="server" CssClass="medium-input" Visible="false">
                                </asp:DropDownList>
                                <asp:Button ID="Button2" runat="server" Text="添加已有逻辑" />
                                <asp:TextBox ID="txtSign" runat="server" CssClass="small-input"></asp:TextBox>
                                <a href="javascript:plus(<%# Container.ItemIndex + 1%>);">+ </a>
                                <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
                                <!-- Classes for input-notification: success, error, information, attention -->
                            </label>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </p>
        <p>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <label>
                        解释
                    </label>
                    <asp:Button ID="Button2" runat="server" Text="生成" OnClick="Button2_Click1" />
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
                    <!-- Classes for input-notification: success, error, information, attention -->
                    <br />
                    <small></small>
                </ContentTemplate>
            </asp:UpdatePanel>
        </p>
        <p>
            <label>
                日期</label><asp:TextBox ID="txtDate" CssClass="text-input small-input" runat="server"></asp:TextBox>-<asp:TextBox
                    ID="txtDate1" CssClass="text-input small-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <asp:Button CssClass="button" runat="server" Text="搜索案例" OnClick="Unnamed1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="保存" OnClick="Button1_Click" />
        </p>
    </fieldset>
    <!-- End .shortcut-buttons-set -->
    <div class="clear">
    </div>
    <!-- End .clear -->
    <div class="content-box">
        <!-- Start Content Box -->
        <div class="content-box-header">
            <h3>计算结果</h3>
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
