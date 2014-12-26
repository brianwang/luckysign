<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="WebForAdmin.Celebrity.Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function keysinput(input, evt) {
            var evt = evt ? evt : (window.event ? window.event : null); //区分IE和FF来得到event
            var code = evt.which ? evt.which : evt.keyCode; //区分IE和FF来得到 event.keyCode 或 event.which
            //alert(code);
            if (code == 38 || code == 40) {//up or down
                var tmp = document.getElementById("<%= HiddenField1.ClientID %>").value;
                var total = tmp.split("|")[0];
                var now = tmp.split("|")[1];
                if (total == 0) {
                    return;
                }
                if (code == 38 && Number(now) != "1") {
                    if (input.lastIndexOf(' ') == -1) {
                        document.getElementById("<%= txtKey.ClientID %>").value = document.getElementById("keyspan" + (Number(now) - 1).toString()).innerHTML;
                    }
                    else {
                        document.getElementById("<%= txtKey.ClientID %>").value = input.substr(0, input.lastIndexOf(' ') + 1) + document.getElementById("keyspan" + (Number(now) - 1).toString()).innerHTML;
                    }

                    document.getElementById("<%= HiddenField1.ClientID %>").value = total + "|" + (Number(now) - 1).toString();
                    for (var i = 1; i <= total; i++) {
                        document.getElementById("keytr" + i.toString()).style.backgroundColor = "";
                    }
                    document.getElementById("keytr" + (Number(now) - 1).toString()).style.backgroundColor = "#e2eaff";
                }
                else if (code == 40 && now != total) {
                    if (input.lastIndexOf(' ') == -1) {
                        document.getElementById("<%= txtKey.ClientID %>").value = document.getElementById("keyspan" + (Number(now) + 1).toString()).innerHTML;
                    }
                    else {
                        document.getElementById("<%= txtKey.ClientID %>").value = input.substr(0, input.lastIndexOf(' ') + 1) + document.getElementById("keyspan" + (Number(now) + 1).toString()).innerHTML;
                    }
                    document.getElementById("<%= HiddenField1.ClientID %>").value = total + "|" + (Number(now) + 1).toString();
                    for (var i = 1; i <= total; i++) {
                        document.getElementById("keytr" + i.toString()).style.backgroundColor = "";
                    }
                    document.getElementById("keytr" + (Number(now) + 1).toString()).style.backgroundColor = "#e2eaff";
                }
            document.getElementById("<%= HiddenField2.ClientID %>").value = document.getElementById("<%= txtKey.ClientID %>").value
                return;
            }
            if (document.getElementById("<%= HiddenField2.ClientID %>").value == document.getElementById("<%= txtKey.ClientID %>").value) {
                return;
            }
            if (input.length == 0 || input.lastIndexOf(' ') == input.length - 1) {
                document.getElementById("<%= keysauto.ClientID %>").style.display = "none";
                return;
            }

            document.getElementById("<%= Button1.ClientID %>").click();
        }
        function keyshide() {
            document.getElementById("<%= keysauto.ClientID %>").style.display = "none";
        }
        function choosekey(tr) {
            var now = tr.id.replace("keytr", "");
            var input = document.getElementById("<%= txtKey.ClientID %>").value;
            var tmp = document.getElementById("<%= HiddenField1.ClientID %>").value;
            var total = tmp.split("|")[0];
            if (input.lastIndexOf(' ') == -1) {
                document.getElementById("<%= txtKey.ClientID %>").value = document.getElementById("keyspan" + (Number(now)).toString()).innerHTML;
            }
            else {
                document.getElementById("<%= txtKey.ClientID %>").value = input.substr(0, input.lastIndexOf(' ') + 1) + document.getElementById("keyspan" + (Number(now)).toString()).innerHTML;
            }

            document.getElementById("<%= HiddenField1.ClientID %>").value = total + "|" + (Number(now)).toString();
            for (var i = 1; i <= total; i++) {
                document.getElementById("keytr" + i.toString()).style.backgroundColor = "";
            }
            document.getElementById("keytr" + (Number(now)).toString()).style.backgroundColor = "#e2eaff";
        }

        function keysinput1(input, evt) {
            var evt = evt ? evt : (window.event ? window.event : null); //区分IE和FF来得到event
            var code = evt.which ? evt.which : evt.keyCode; //区分IE和FF来得到 event.keyCode 或 event.which
            //alert(code);
            if (code == 38 || code == 40) {//up or down
                var tmp = document.getElementById("<%= HiddenField11.ClientID %>").value;
                var total = tmp.split("|")[0];
                var now = tmp.split("|")[1];
                if (total == 0) {
                    return;
                }
                if (code == 38 && Number(now) != "1") {
                    if (input.lastIndexOf(' ') == -1) {
                        document.getElementById("<%= txtName.ClientID %>").value = document.getElementById("key1span" + (Number(now) - 1).toString()).innerHTML;
                    }
                    else {
                        document.getElementById("<%= txtName.ClientID %>").value = input.substr(0, input.lastIndexOf(' ') + 1) + document.getElementById("key1span" + (Number(now) - 1).toString()).innerHTML;
                    }

                    document.getElementById("<%= HiddenField11.ClientID %>").value = total + "|" + (Number(now) - 1).toString();
                    for (var i = 1; i <= total; i++) {
                        document.getElementById("key1tr" + i.toString()).style.backgroundColor = "";
                    }
                    document.getElementById("key1tr" + (Number(now) - 1).toString()).style.backgroundColor = "#e2eaff";
                }
                else if (code == 40 && now != total) {
                    if (input.lastIndexOf(' ') == -1) {
                        document.getElementById("<%= txtName.ClientID %>").value = document.getElementById("key1span" + (Number(now) + 1).toString()).innerHTML;
                    }
                    else {
                        document.getElementById("<%= txtName.ClientID %>").value = input.substr(0, input.lastIndexOf(' ') + 1) + document.getElementById("key1span" + (Number(now) + 1).toString()).innerHTML;
                    }
                    document.getElementById("<%= HiddenField11.ClientID %>").value = total + "|" + (Number(now) + 1).toString();
                    for (var i = 1; i <= total; i++) {
                        document.getElementById("key1tr" + i.toString()).style.backgroundColor = "";
                    }
                    document.getElementById("key1tr" + (Number(now) + 1).toString()).style.backgroundColor = "#e2eaff";
                }
            document.getElementById("<%= HiddenField21.ClientID %>").value = document.getElementById("<%= txtName.ClientID %>").value
                return;
            }
            if (document.getElementById("<%= HiddenField21.ClientID %>").value == document.getElementById("<%= txtName.ClientID %>").value) {
                return;
            }
            if (input.length == 0 || input.lastIndexOf(' ') == input.length - 1) {
                document.getElementById("<%= keysauto1.ClientID %>").style.display = "none";
                return;
            }

            document.getElementById("<%= Button2.ClientID %>").click();
        }
        function keyshide1() {
            document.getElementById("<%= keysauto1.ClientID %>").style.display = "none";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>添加/修改案例</h2>
    <p id="page-intro">
        *为必填
    </p>
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
    <fieldset class="column-left">
        <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
        <p>
            <label>
                编号*</label>
            <asp:TextBox ID="txtSysNo" class="text-input small-input" ReadOnly="true" Enabled="false"
                runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                名字*</label>
            <asp:TextBox ID="txtName" class="text-input medium-input" runat="server"
                autocomplete="off" onkeyup="keysinput1(this.value,event)" onblur="keyshide1()" onfocus="keysinput1(this.value,event)"></asp:TextBox>
            <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" Style="display: none;" />
                    <asp:HiddenField ID="HiddenField11" runat="server" />
                    <asp:HiddenField ID="HiddenField21" runat="server" />
                    <div id="keysauto1" runat="server" style="width: 300px; display: none;">
                        <table cellspacing="0" cellpadding="2">
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <tr id="key1tr<%# Container.ItemIndex + 1%>">
                                        <td>
                                            <span id="key1span<%# Container.ItemIndex + 1%>">
                                                <%# Eval("Name")%></span>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>中文名，常用名，前台显示的名字</small>
        </p>
        <p>
            <label>
                性别*</label><asp:DropDownList ID="drpGender" runat="server" class="small-input">
                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                    <asp:ListItem Text="男" Value="1"></asp:ListItem>
                    <asp:ListItem Text="其他" Value="2" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            <br />
            <small></small>
        </p>
    </fieldset>
    <fieldset class="column-right">
        <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
        <p>
            <label>
                分类*</label><asp:DropDownList ID="drpCate" runat="server" class="small-input">
                </asp:DropDownList>
            <br />
            <small></small>
        </p>
        <p>
            <label>
                全名</label>
            <asp:TextBox ID="txtFullName" class="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>英文全名，可为空</small>
        </p>
        <p>
            <label>
                身高</label>
            <asp:TextBox ID="txtHeight" class="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>单位CM，请填写整数</small>
        </p>
    </fieldset>
    <div class="clear">
    </div>
    <fieldset>
        <p>
            <label>
                出生时间*</label>
            <asp:TextBox ID="txtYear" class="text-input tiny-input" runat="server"></asp:TextBox><span>年</span>
            <asp:TextBox ID="txtMonth" class="text-input tiny-input" runat="server"></asp:TextBox><span>月</span>
            <asp:TextBox ID="txtDay" class="text-input tiny-input" runat="server"></asp:TextBox><span>日</span>
            <asp:TextBox ID="txtHour" class="text-input tiny-input" runat="server"></asp:TextBox><span>时</span>
            <asp:TextBox ID="txtMinute" class="text-input tiny-input" runat="server"></asp:TextBox><span>分</span>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>请填写有效时间，24小时制</small>
        </p>
        <p>
            <label>
                时间是否精确*</label>
            <asp:DropDownList ID="chkTime" runat="server" class="small-input">
            </asp:DropDownList>
        </p>
        <p>
            <label>
                出生地*</label><asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="drpDistrict1" runat="server" class="small-input" AutoPostBack="true"
                            OnSelectedIndexChanged="drpDistrict1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <span>—</span><asp:DropDownList ID="drpDistrict2" runat="server" class="small-input"
                            OnSelectedIndexChanged="drpDistrict2_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <span>—</span><asp:DropDownList ID="drpDistrict3" runat="server" class="small-input"
                            OnSelectedIndexChanged="drpDistrict3_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="lblPosition" runat="server" CssClass="input-notification information png_bg"
                            Text="" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <br />
            <small>三级地区选择，必须精确到第三级</small>
        </p>
        <p>
            <label>
                人物简介</label>
            <asp:TextBox ID="txtDesc" class="text-input textarea" TextMode="MultiLine" Height="300"
                Width="300" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p style="padding-bottom: 0px;">
            <label>
                关键字</label>
            <asp:TextBox ID="txtKey" class="text-input textarea" Width="300px" runat="server"
                autocomplete="off" onkeyup="keysinput(this.value,event)" onblur="keyshide()" onfocus="keysinput(this.value,event)"></asp:TextBox>
            <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="display: none;" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <div id="keysauto" runat="server" style="width: 300px; display: none;">
                        <table cellspacing="0" cellpadding="2">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr id="keytr<%# Container.ItemIndex + 1%>" onmouseover="choosekey(this)">
                                        <td>
                                            <span id="keyspan<%# Container.ItemIndex + 1%>">
                                                <%# Eval("KeyWords")%></span>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <asp:Button runat="server" CssClass="button" Text="保存" OnClick="Unnamed3_Click" />
        </p>
    </fieldset>
</asp:Content>
