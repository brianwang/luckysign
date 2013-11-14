<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs"
    Inherits="WebForMain.ControlLibrary.DatePicker" %>
<script type="text/javascript">

    //设置每个月份的天数
    function setDays(year, month, day) {

        var monthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        var yea = year.options[year.selectedIndex].text;
        var mon = month.options[month.selectedIndex].text;
        var num = monthDays[mon - 1];
        if (mon == 2 && isLeapYear(yea)) {
            num++;
        }
        for (var i = day.options.length - 1; i >= 0; i--) {
            day.remove(i);
        }
        for (var i = 1; i <= num; i++) {
            addOption(day, i, i);
        }
    }

    //判断是否闰年
    function isLeapYear(year) {
        return (year % 4 == 0 || (year % 100 == 0 && year % 400 == 0));
    }

    //向select尾部添加option
    function addOption(selectbox, text, value) {
        var option = document.createElement("option");
        option.text = text;
        option.value = value;
        selectbox.options.add(option);
    }


</script>


<asp:DropDownList ID="drpYear" runat="server" CssClass="sel_2">
</asp:DropDownList>
年
<asp:DropDownList ID="drpMonth" runat="server" CssClass="sel_2">
</asp:DropDownList>
月
<asp:DropDownList ID="drpDay" runat="server" CssClass="sel_2">
</asp:DropDownList>
日
<asp:DropDownList ID="drpHour" runat="server" CssClass="sel_2" Visible="false" style="margin-left:70px">
</asp:DropDownList>

<asp:Literal ID="shi" runat="server" Text=""></asp:Literal>

<asp:DropDownList ID="drpMinute" runat="server" CssClass="sel_2" Visible="false">
</asp:DropDownList>

<asp:Literal ID="fen" runat="server" Text=""></asp:Literal>

<asp:DropDownList ID="drpSecond" runat="server" CssClass="sel_2" Visible="false">
</asp:DropDownList>

<asp:Literal ID="miao" runat="server" Text=""></asp:Literal>
   

