<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true" CodeBehind="SearchBazi.aspx.cs" Inherits="WebForAnalyse.BaZi.SearchBazi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%= txtDate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '-10:+10',
            monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
            dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
            dateFormat: 'yy-mm-dd'
        }
);
        $("#<%= txtDate1.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '-10:+10',
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
<h2>
        八字查询</h2>
    <p id="page-intro">
        请输入生辰：</p>
    <fieldset class="column-left">
        <p>
            <label>
                日期段</label><asp:TextBox ID="txtDate" CssClass="text-input small-input" runat="server"></asp:TextBox>-<asp:TextBox
                    ID="txtDate1" CssClass="text-input small-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <asp:Button CssClass="button" runat="server" Text="查询" OnClick="Unnamed1_Click" />
        </p>
    </fieldset>
    <fieldset class="column-right">
        <p>
            <label>
                八字：</label>
            <asp:DropDownList ID="drpYear" runat="server" CssClass="small-input">
            </asp:DropDownList>年
            <asp:DropDownList ID="drpMonth" runat="server" CssClass="small-input">
            </asp:DropDownList>月
            <asp:DropDownList ID="drpDay" runat="server" CssClass="small-input">
            </asp:DropDownList>日
            <asp:DropDownList ID="drpHour" runat="server" CssClass="small-input">
            </asp:DropDownList>时
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
            <h3>
                计算结果</h3>
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
