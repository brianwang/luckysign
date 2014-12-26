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

        function convert(input) {
            if (input < 10) {
                id = "#ctl00_ContentPlaceHolder1_Repeater1_ctl0" + input + "_p";
            }
            else {
                id = "#ctl00_ContentPlaceHolder1_Repeater1_ctl" + input + "_p";
            }

            var hidden = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField2").value;
            if ($(id).children("span").children("select").css("display") == "none") {

                $(id).children("select").css("display", "none");
                $(id).children("span").children("select").css("display", "");
                $(id).children("span").children("select").css("display", "");
                hidden = hidden.replace("|" + input + "|", "|");
                hidden = hidden + input + "|";
            }
            else {
                $(id).children("select").css("display", "");
                $(id).children("span").children("select").css("display", "none");
                hidden = hidden.replace("|" + input + "|", "|");
            }
            document.getElementById("ctl00_ContentPlaceHolder1_HiddenField2").value = hidden;
        }

        function show(input) {
            if (input < 9) {
                id1 = "#ctl00_ContentPlaceHolder1_Repeater1_ctl0" + (input) + "_p";
            }
            else {
                id1 = "#ctl00_ContentPlaceHolder1_Repeater1_ctl" + (input) + "_p";
            }

            $(id1).css("display", "");
            if (input > 0)
                $("#a" + (input - 1)).html("-");
        }

        function plus(input) {
            if (input < 10) {
                id = "#ctl00_ContentPlaceHolder1_Repeater1_ctl0" + input + "_p";
            }
            else {
                id = "#ctl00_ContentPlaceHolder1_Repeater1_ctl" + input + "_p";
            }
            if (input < 9) {
                id1 = "#ctl00_ContentPlaceHolder1_Repeater1_ctl0" + (input + 1) + "_p";
            }
            else {
                id1 = "#ctl00_ContentPlaceHolder1_Repeater1_ctl" + (input + 1) + "_p";
            }
            max = document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;
            if ($("#a" + input).html() == "+") {
                $(id1).css("display", "");
                $("#a" + input).html("-");
                document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value = (parseInt(max) + 1);
            }
            else {
                $(id1).css("display", "none");
                $("#a" + input).html("+");
                document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value = (parseInt(max) - 1);
            }

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>八字组合设置</h2>
    <p id="page-intro">
        请设置关系：
    </p>
    <div id="noticediv1" class="notification attention png_bg" style="display: none;">
        <a href="#" class="close">
            <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                alt="close" /></a>
        <div>
            <asp:Literal ID="ltrNotice1" runat="server"></asp:Literal>
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

    <fieldset class="column-left">
        <p>
            <label>
                标题</label>
            <asp:TextBox ID="txtTitle" class="text-input large-input"
                runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
    </fieldset>
    <fieldset class="column-right">
        <p>
            <label>
                类型</label>
            <asp:DropDownList ID="drpType" runat="server" class="small-input">
            </asp:DropDownList>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
    </fieldset>
    <div class="clear">
    </div>
    <fieldset class="column">
        <p>
            <label>
                详细</label>
            <asp:TextBox ID="txtDesc" class="text-input textarea" TextMode="MultiLine" Height="100"
                Width="300" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <label id="p" style="display: none;" runat="server">

                                <asp:TextBox ID="txtSign1" runat="server" CssClass="text-input tinyest-input"></asp:TextBox>

                                <asp:DropDownList ID="drpItem" runat="server" CssClass="tiny-input">
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpNegative" runat="server" CssClass="tinyest-input">
                                    <asp:ListItem Text="" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="非" Value="-1"></asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpType" runat="server" CssClass="tiny-input" AutoPostBack="true" OnSelectedIndexChanged="drpType_SelectedIndexChanged">
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpCondition" runat="server" CssClass="tiny-input">
                                </asp:DropDownList>

                                <asp:DropDownList ID="drpTarget" runat="server" CssClass="tiny-input">
                                </asp:DropDownList>

                                <span>
                                    <asp:DropDownList ID="drpLogic" runat="server" CssClass="tiny-input" Style="display: none;">
                                    </asp:DropDownList>
                                </span>

                                <a href="javascript:convert(<%# Container.ItemIndex%>);">模式</a>
                                <%--<asp:LinkButton runat="server" Text="模式" OnClick="Unnamed_Click"></asp:LinkButton>--%>

                                <asp:TextBox ID="txtSign2" runat="server" CssClass="text-input tinyest-input"></asp:TextBox>
                                <b>
                                    <asp:DropDownList ID="drpSign" runat="server" CssClass="tinyest-input">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="且" Value="&&"></asp:ListItem>
                                        <asp:ListItem Text="或" Value="||"></asp:ListItem>
                                    </asp:DropDownList></b>
                                <%--<asp:LinkButton ID="show" runat="server" Text="+" OnClick="Unnamed_Click1"></asp:LinkButton>--%>
                                <a id="a<%# Container.ItemIndex%>" href="javascript:plus(<%# Container.ItemIndex%>);">+</a>
                                <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
                                <!-- Classes for input-notification: success, error, information, attention -->

                            </label>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
            <asp:HiddenField ID="HiddenField2" Value="|" runat="server" />
        </p>
    </fieldset>
    <div class="clear">
    </div>
    <fieldset class="column-left">
        <p>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <%-- <asp:Button ID="Button2" runat="server" CssClass="button" Text="逻辑解释" OnClick="Button2_Click1" /><br />
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <br />
                        <small></small>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </p>
    </fieldset>
    <fieldset class="column-right">
        <p>
            <asp:Button ID="Button1" CssClass="button" runat="server" Text="保存" OnClick="Button1_Click" />
        </p>
    </fieldset>
    <div class="clear">
    </div>
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
        <p>
            <asp:Button CssClass="button" runat="server" Text="搜索案例" OnClick="Unnamed1_Click" />
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
