<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="AstroForQuest.ascx.cs"
    Inherits="WebForMain.ControlLibrary.AstroForQuest" %>
<%@ Register Src="DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<script type="text/javascript">
    function changepeople(input) {
        if (input == "first") {
            document.getElementById('first').className = "on";
            document.getElementById('<%=second.ClientID%>').className = "";
            document.getElementById('first1').style["display"] = "";
            document.getElementById('second1').style["display"] = "none";
        }
        else {
            document.getElementById('first').className = "";
            document.getElementById('<%=second.ClientID%>').className = "on";
            document.getElementById('first1').style["display"] = "none";
            document.getElementById('second1').style["display"] = "";
        }
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>



        <div class="paipan_l">
            <div class="paipan_img">
                <asp:Image ID="imgChart" runat="server" />
            </div>
            <div style="display: none;">
                图片地址：<asp:TextBox ID="txtUrl" runat="server" Width="600" onclick="select();"></asp:TextBox>
                <a href="#" onclick="javascript:window.clipboardData.setData('text','<%=picurl %>');alert('图片地址已经复制到剪贴板中');"
                    class="btn_03">复制地址</a>
            </div>
            <div class="paipan_l_c">
                <div class="tabs">
                    <a id="pnlTuiYun" runat="server" class="on" href="javascript:void(0)" title="推运">推运</a> <a id="pnlHePan" runat="server" href="javascript:void(0)" title="合盘">合盘</a> <a id="pnlJiaoZheng" runat="server" href="javascript:void(0)" title="生时校正">生时校正</a>
                </div>
                <div class="paipan_l_con">
                    <div class="block show pp" style="background: #F7F4ED">
                        <p>
                            <span>推运类型：</span><asp:DropDownList ID="drpProgressType" runat="server"
                                CssClass="sel_0">
                            </asp:DropDownList>
                        </p>
                        <p>
                            <span>推运时间：</span><uc1:DatePicker ID="DatePickert1"
                                Type="3" runat="server"></uc1:DatePicker>
                        </p>
                        <p>
                            <asp:LinkButton ID="LinkButton3" CssClass="paipan_a" runat="server" OnClick="LinkButton3_Click">开始排盘</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton4" CssClass="paipan_a" runat="server" OnClick="LinkButton2_Click" Style="margin-left: 5px">返回原盘</asp:LinkButton>
                        </p>
                    </div>

                    <div class="block pp" style="background: #F7F4ED">

                        <p>
                            <span>合盘类型：</span><asp:DropDownList ID="drpCompareType" runat="server" CssClass="sel_0">
                            </asp:DropDownList>
                        </p>
                        <div id="hepaninfo" runat="server">
                            <p>
                                <span>对方时间：</span>
                                <uc1:DatePicker ID="DatePicker2" runat="server"></uc1:DatePicker>
                                <asp:CheckBox ID="chkDaylight2" runat="server" />
                                <lable class="fsred"><strong>夏令时</strong></lable>
                            </p>
                            <p>
                                <span>出生地点：</span>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <samp style="display: block; width: 500px; float: right; text-align: left">
                                            <uc1:District ID="District2" runat="server"></uc1:District>
                                        </samp>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="clear"></div>
                            </p>
                        </div>
                        <p>
                            <span>所属时区：</span>
                            <asp:DropDownList ID="drpTimeZone2" runat="server" CssClass="sel_2">
                            </asp:DropDownList>
                            时区
                        </p>


                        <p>
                            <asp:LinkButton ID="LinkButton1" CssClass="paipan_a" runat="server" OnClick="LinkButton1_Click">开始排盘</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" CssClass="paipan_a" runat="server" OnClick="LinkButton2_Click">返回原盘</asp:LinkButton>
                        </p>

                    </div>
                    <div class="block pp" style="background: #F7F4ED">
                        <p>
                            <span>星盘时间：</span><uc1:DatePicker ID="DatePickert3"
                                Type="5" runat="server"></uc1:DatePicker>
                        </p>
                        <p>
                            <asp:Button ID="Button1" runat="server"  CssClass="paipan_a" Text="往前5分钟" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" CssClass="paipan_a" Text="往后5分钟" OnClick="Button2_Click" />
                            <asp:LinkButton ID="LinkButton5" CssClass="paipan_a" runat="server" OnClick="LinkButton4_Click">开始排盘</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton6" CssClass="paipan_a" runat="server" OnClick="LinkButton2_Click">返回原盘</asp:LinkButton>
                        </p>

                    </div>

                    <div class="paipan_line">
                        <a href="../Qin/MyCollection.aspx?type=<%=(int)AppCmn.AppEnum.CollectionType.chart%>&minitype=astro&add=1&p=<%=chartpara %>" class="paipan_a" style="width: 120px; margin: auto">收藏当前本命盘</a>
                    </div>
                </div>
            </div>
        </div>

        <div class="paipan_r">
            <div class="paipan_r_item">
                <span style="cursor: pointer;" onclick="javascript:changepeople('first');" id="first" class="on">星座信息1</span><span id="second" onclick="javascript:changepeople('second');" style="cursor: pointer;" runat="server">星座信息2</span><div class="clear"></div>
            </div>

            <div class="paipan_r_c">
                <div id="first1">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>
                <div id="second1" style="display: none;">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </div>


                <h1>容许度设置</h1>
                <p>
                    <span>合相 0°</span><asp:DropDownList ID="drpAspect0" runat="server" CssClass="sel_2">
                    </asp:DropDownList>
                </p>
                <p>
                    <span>冲相180°</span><asp:DropDownList ID="drpAspect180" runat="server" CssClass="sel_2">
                    </asp:DropDownList>
                </p>
                <p>
                    <span>刑相90°</span><asp:DropDownList ID="drpAspect90" runat="server" CssClass="sel_2">
                    </asp:DropDownList>
                </p>
                <p>
                    <span>三合120°</span><asp:DropDownList ID="drpAspect120" runat="server" CssClass="sel_2">
                    </asp:DropDownList>
                </p>
                <p>
                    <span>六合60°</span><asp:DropDownList ID="drpAspect60" runat="server" CssClass="sel_2">
                    </asp:DropDownList>
                </p>

                <h1>星体显示</h1>
                <asp:CheckBox ID="star1" runat="server" Text="太阳" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star2" runat="server" Text="月亮" Checked="true" /><br />
                <asp:CheckBox ID="star3" runat="server" Text="水星" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star4" runat="server" Text="金星" Checked="true" /><br />
                <asp:CheckBox ID="star5" runat="server" Text="火星" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star6" runat="server" Text="木星" Checked="true" /><br />
                <asp:CheckBox ID="star7" runat="server" Text="土星" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star8" runat="server" Text="天王星" Checked="true" /><br />
                <asp:CheckBox ID="star9" runat="server" Text="海王星" Checked="true" />&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star10" runat="server" Text="冥王星" Checked="true" /><br />

                <br />
                <asp:CheckBox ID="star11" runat="server" Text="凯龙星" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star12" runat="server" Text="谷神星" /><br />
                <asp:CheckBox ID="star13" runat="server" Text="智神星" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star14" runat="server" Text="婚神星" /><br />
                <asp:CheckBox ID="star15" runat="server" Text="灶神星" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star16" runat="server" Text="北交点" /><br />
                <asp:CheckBox ID="star17" runat="server" Text="莉莉丝" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star18" runat="server" Text="福点" /><br />
                <asp:CheckBox ID="star19" runat="server" Text="宿命点" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="star20" runat="server" Text="东升点" /><br />
                <br />

                <div class="paipan_button">
                    <asp:Button ID="LinkButton7" runat="server" Text="确定" OnClick="LinkButton7_Click" />
                </div>

            </div>

        </div>

        <div class="clear"></div>



    </ContentTemplate>
</asp:UpdatePanel>
