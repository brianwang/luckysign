<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="SetOrder.aspx.cs" Inherits="WebForMain.Quest.SetOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlLibrary/AstroForQuest.ascx" TagName="Astro" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/BaZiForQuest.ascx" TagName="Bazi" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/ZiWeiForQuest.ascx" TagName="Ziwei" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>发布报价-上上签</title>
    <style type="text/css">
        .popup {
            filter: alpha(opacity=60);
            -moz-opacity: 0.6; /*Firefox私有，透明度50%*/
            opacity: 0.6; /*其他，透明度50%*/
            background-color: black;
        }
    </style>
    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>CSS/page.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>

    <div class="main">

        <div class="index_left">
            <!--煮酒论命-->
            <div class="index_left_box">
                <div class="index_new_ask_t">
                    <div class="index_new_ask_reply">浏览：<span><asp:Literal ID="ltrViewNum" runat="server"></asp:Literal></span>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;回复：<span><asp:Literal ID="ltrReply" runat="server"></asp:Literal></span></div>
                    <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                </div>

                <div class="index_left_new_list" style="padding: 18px;">

                    <div class="index_new_ask_qs">
                        <div class="index_new_ask_l">
                            <asp:Image ID="Image1" Width="70" Height="70" runat="server" /><br />
                            <span class="name">
                                <asp:Literal ID="ltrNickName" runat="server"></asp:Literal></span><br />
                            <span class="info">等级：<asp:Literal ID="ltrQALevel" runat="server"></asp:Literal><br />
                                提问数：<asp:Literal ID="ltrTotalAsk" runat="server"></asp:Literal><br />
                                反馈数：<asp:Literal ID="ltrTotalReply" runat="server"></asp:Literal></span>
                        </div>
                        <div class="index_new_ask_r">
                            <div class="index_new_ask_xs">
                                <span>
                                    <asp:Literal ID="ltrAward" runat="server"></asp:Literal></span><%=m_qustion.EndTime==null||m_qustion.EndTime==AppCmn.AppConst.DateTimeNull ? @"<span style=""color:#f00"">未解决</span>" : @"<span>已解决</span>"%>
                            </div>
                            <div class="index_new_ask_info">
                                <asp:Literal ID="ltrContext" runat="server"></asp:Literal>
                            </div>

                        </div>

                        <div class="clear"></div>
                    </div>


                    <uc1:Astro ID="Astro1" runat="server" Visible="false"></uc1:Astro>
                    <uc1:Bazi ID="Bazi1" runat="server" Visible="false"></uc1:Bazi>
                    <uc1:Ziwei ID="Ziwei1" runat="server" Visible="false"></uc1:Ziwei>

                    <div class="clear"></div>
                   
                </div>

                <div class="index_left_new_t" style="color: #a4534b; font-size: 16px">发布报价单</div>

                <div class="index_left_new_list">
                    <div class="pay_140218">

                        <div class="pay_140218_t" style="margin-top: 10px">报价信息</div>

                        <ul class="pay_140218_ul">
                            <li><span class="t">占卜结果最少字数：</span><span class="c"><asp:TextBox ID="TextBox2" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><span id="wordstip" runat="server"></span><div class="clear"></div>
                            </li>
                            <li><span class="t">我的报价：</span><span class="c"><asp:TextBox ID="TextBox3" CssClass="pay_140218_input" runat="server"></asp:TextBox></span><span id="pricetip" runat="server"></span><div class="clear"></div>
                            </li>
                        </ul>

                        <div class="pay_140218_t">服务描述</div>

                        <div class="pay_140218_content">
                            比如从哪些方面进行解答，个人特长，服务标准等。<br />
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="pay_140218_t">往事验证</div>

                        <div class="pay_140218_content">
                            可对咨询者之前的或Ta已知的事情进行描述以便其认可您的准确度。<br />
                            <asp:TextBox ID="txtTrial" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="clear"></div>

                    <div class="pay_140218_btn">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">提交</asp:LinkButton></div>

                </div>

            </div>
        </div>

        <div class="index_right">
        </div>
        <div class="clear"></div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <%-- <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>--%>
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>
</asp:Content>
