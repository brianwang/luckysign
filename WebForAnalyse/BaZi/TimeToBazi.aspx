<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="TimeToBazi.aspx.cs" Inherits="WebForAnalyse.BaZi.TimeToBazi" %>

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

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        八字男女同排</h2>
    <p id="page-intro">
        请输入生辰：</p>
    <fieldset class="column-left">
        <p>
            <label>
                日期</label><asp:TextBox ID="txtDate" CssClass="text-input small-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg" style="display:none;">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                大运排法</label><asp:DropDownList ID="drpDaYun" runat="server" CssClass="small-input">
                    <asp:ListItem Text="按月令起大运" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="按日柱起大运" Value="1"></asp:ListItem>
                    <asp:ListItem Text="按时柱起大运" Value="2"></asp:ListItem>
                    <asp:ListItem Text="按分钟起大运" Value="3"></asp:ListItem>
                </asp:DropDownList>
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
                时辰</label>
            <asp:DropDownList ID="drpHour" runat="server" CssClass="small-input">
            </asp:DropDownList>
            时
            <asp:DropDownList ID="drpMinute" runat="server" CssClass="small-input">
            </asp:DropDownList>
            分
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
