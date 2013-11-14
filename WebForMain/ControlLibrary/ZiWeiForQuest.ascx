<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ZiWeiForQuest.ascx.cs"
    Inherits="WebForMain.ControlLibrary.ZiWeiForQuest" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional"
    ChildrenAsTriggers="true">
    <ContentTemplate>
        <div class="tabs" id="tab1" runat="server">
            <a id="pnl1" runat="server" href="javascript:void(0)" title="第一星盘" class="on">第一星盘</a> <a  id="pnl2" runat="server" href="javascript:void(0)"
                title="第二星盘">第二星盘</a>
        </div>
        <div id="pnlpan1" class="block show pp" style="border-bottom:none;">
            <div id="chartdiv" class="res" style="font-family: 宋体; color: #3f3d3e; border-bottom: 1px;
                border-left: 1px; padding-bottom: 2px; line-height: 13px; padding-left: 2px;
                padding-right: 2px; font-size: 9pt; border-top: 1px; border-right: 1px; padding-top: 2px;height:auto">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
            <div class="tabs" id="Div2">
                <a id="pnltuiyun1" runat="server" href="javascript:void(0)" title="推运" class="on">推运</a> <a id="pnljiaozheng1" runat="server" href="javascript:void(0)"
                    title="生时校正">生时校正</a>
            </div>
            <div class="block show pp">
                <div class="box_1">
                    <div class="box_c">
                        <%--&nbsp;<strong>推运时间：</strong><asp:Literal ID="ltrTransTime1" runat="server" Text="请点击开始推运"></asp:Literal><br />--%>
                        <asp:Button ID="Button3" runat="server" Text="上一限" OnClick="Button11_Click" /> 
                        <asp:Button ID="Button4" runat="server" Text="下一限" OnClick="Button12_Click" />     
                        <asp:Button ID="Button5" runat="server" Text="上一年" OnClick="Button13_Click" /> 
                        <asp:Button ID="Button6" runat="server" Text="下一年" OnClick="Button14_Click" />
                        <asp:LinkButton ID="LinkButton1" CssClass="btn_01" runat="server" OnClick="LinkButton3_Click">开始推运</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" CssClass="btn_01" runat="server" OnClick="LinkButton1_Click">返回本命</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="block pp">
                <div class="box_1">
                    <div class="box_c">
                        <%--&nbsp;<strong>命盘时间：</strong><asp:Literal ID="ltrTime1" runat="server"></asp:Literal><br />--%>
                        <asp:Button ID="Button1" runat="server" Text="往前一时辰" OnClick="Button15_Click" />
                        <asp:Button ID="Button2" runat="server" Text="往后一时辰" OnClick="Button16_Click" />
                        <asp:LinkButton ID="LinkButton5" CssClass="btn_01" runat="server" OnClick="LinkButton5_Click">返回原盘</asp:LinkButton>
                    </div>
                </div>
            </div>
            <%--<a href="#" onclick="javascript:window.clipboardData.setData('text',document.getElementById('chartdiv').innerHTML);alert('星盘已经复制到剪贴板中');" class="btn_03">复制星盘</a>--%>
        </div>
        <div class="block pp" id="pnlpan2" style="border-bottom:none;">
            <div id="Div1" class="res" style="font-family: 宋体; color: #3f3d3e; border-bottom: 1px;
                border-left: 1px; padding-bottom: 2px; line-height: 13px; padding-left: 2px;
                padding-right: 2px; font-size: 9pt; border-top: 1px; border-right: 1px; padding-top: 2px;">
                <asp:Literal ID="Literal2" runat="server"></asp:Literal></div>
                <div class="tabs" id="Div3">
                <a id="pnltuiyun2" runat="server" href="javascript:void(0)" title="推运" class="on">推运</a> <a id="pnljiaozheng2" runat="server" href="javascript:void(0)"
                    title="生时校正">生时校正</a>
            </div>
            <div class="block show pp">
                <div class="box_1">
                    <div class="box_c">
                        <%--&nbsp;<strong>推运时间：</strong><asp:Literal ID="ltrTransTime2" runat="server" Text="请点击开始推运"></asp:Literal><br />--%>
                        <asp:Button ID="Button7" runat="server" Text="上一限" OnClick="Button21_Click" /> 
                        <asp:Button ID="Button8" runat="server" Text="下一限" OnClick="Button22_Click" />     
                        <asp:Button ID="Button9" runat="server" Text="上一年" OnClick="Button23_Click" /> 
                        <asp:Button ID="Button10" runat="server" Text="下一年" OnClick="Button24_Click" />
                        <asp:LinkButton ID="LinkButton2" CssClass="btn_01" runat="server" OnClick="LinkButton4_Click">开始推运</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" CssClass="btn_01" runat="server" OnClick="LinkButton2_Click">返回本命</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="block pp">
                <div class="box_1">
                    <div class="box_c">
                        <%--&nbsp;<strong>命盘时间：</strong><asp:Literal ID="ltrTime2" runat="server"></asp:Literal><br />--%>
                        <asp:Button ID="Button11" runat="server" Text="往前一时辰" OnClick="Button25_Click" />
                        <asp:Button ID="Button12" runat="server" Text="往后一时辰" OnClick="Button26_Click" />
                        <asp:LinkButton ID="LinkButton6" CssClass="btn_01" runat="server" OnClick="LinkButton6_Click">返回原盘</asp:LinkButton>
                    </div>
                </div>
            </div>
            
            <%--<a href="#" onclick="javascript:window.clipboardData.setData('text',document.getElementById('chartdiv').innerHTML);alert('星盘已经复制到剪贴板中');" class="btn_03">复制星盘</a>--%>
        </div>
         <div style="text-align: center; padding-top: 10px; border-top: 1px dotted #000000"><a href="../Qin/MyCollection.aspx?type=<%=(int)AppCmn.AppEnum.CollectionType.chart%>&minitype=ziwei&add=1&p=<%=chartpara %>" class="btn_01" target="_blank">收藏当前本命盘</a></div>
    </ContentTemplate>
</asp:UpdatePanel>
