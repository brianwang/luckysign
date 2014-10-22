<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebForMain.Quest.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>命理课程-上上签-专业在线算命课程-大师亲受</title>
    <meta name="keywords" content="上上签_占星术_占星骰子_在线排盘_星座运势_命理咨询_大师专业解盘_算命_命盘" />
    <meta name="description" content="上上签算命咨询网提供专业的排盘，在线算命咨询服务，这里还有海量的命理学习资料和名人命盘案例库，致力于用科技的手段服务于命理研究和在线咨询。" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">

        <div class="index_left">
            <!--课程列表-->
            <div class="zjlm_box">
                <div class="zjlm_box_t">
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Talk" target="_blank" class="zjlm_box_t_a" style="background: #6d8690">发新贴</a>
                    <h1>神秘学课程</h1>
                    星座，占星，塔罗占卜，紫薇八字，大师亲授，在线语音，一网打尽。
                </div>

                <div class="zjlm_ul3">
                    <ul>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="zjlm_img">
                                        <a href='<%=AppCmn.AppConfig.HomeUrl() %>Quest/TalkList/<%#Eval("SysNo")%>' target="_blank">
                                            <img alt='<%#Eval("Name")%>' src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/CatePic/<%#Eval("Pic")%>' /></a>
                                    </div>
                                    <div class="zjlm_img_r">
                                        <div class="zjlm_img_r_item"><a href='<%=AppCmn.AppConfig.HomeUrl() %>Quest/TalkList/<%#Eval("SysNo")%>' target="_blank"><%#Eval("Name")%></a></div>
                                        <div class="zjlm_img_r_num"><%#Eval("NewCount")%></div>
                                        <div class="clear"></div>
                                        <div class="zjlm_img_r_name"><a href='<%=AppCmn.AppConfig.HomeUrl() %>Quest/Topic/<%#Eval("NewSysNo")%>' target="_blank"><%#Eval("NewTitle")%></a></div>
                                        <div class="zjlm_img_r_content"><%# AppCmn.CommonTools.CutStr(AppCmn.CommonTools.NoHTML(Eval("NewContext").ToString()),60)%></div>
                                        <div class="zjlm_img_r_time"><%#Eval("NewUser")%>     <%# DateTime.Parse(Eval("NewTime").ToString()).ToString("yyyy-MM-dd HH:mm") %></div>
                                    </div>
                                    <div class="clear"></div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                    <div class="clear"></div>
                </div>
            </div>

        </div>


        <div class="index_right">
            <%--<div class="page_person_search" style="margin: 0; padding: 0; width: auto">
                <asp:TextBox runat="server" class="input1" ID="txtName" value="寻找你感兴趣的内容" onblur="if (this.value==''){ this.value='寻找你感兴趣的内容';this.style.color='#9C9C9C';}else{this.style.color='#333';}"
                    Style="width: 170px" onfocus="if (this.value=='寻找你感兴趣的内容') {this.value='';this.style.color='#333';}"></asp:TextBox>
                <asp:Button ID="LinkButton1" class="input2" runat="server" Text="GO" OnClick="LinkButton1_Click" />
            </div>
            <div class="zjlm_r">
                <div class="zjlm_r_t">最新问答</div>
                <div class="zjlm_r_c">
                    <ul>
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <li><a href='<%=AppCmn.AppConfig.HomeUrl() %>Quest/Question/<%#Eval("SysNo")%>' target="_blank"><%#Eval("AnswerUser")%>：<%#AppCmn.CommonTools.CutStr(Eval("Answer").ToString(),25)%> || <%#Eval("NickName")%>：[<%#Eval("CateName")%>]<%#AppCmn.CommonTools.CutStr(Eval("Title").ToString(),15)%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>

            <div class="zjlm_r">
                <div class="zjlm_r_t">最新话题</div>
                <div class="zjlm_r_c2">
                    <ul>
                        <asp:Repeater ID="Repeater4" runat="server" OnItemDataBound="Repeater4_ItemDataBound">
                            <ItemTemplate>
                                <asp:Repeater ID="Repeater5" runat="server">
                                    <ItemTemplate>
                                        <li><a href='<%=AppCmn.AppConfig.HomeUrl() %>Quest/Topic/<%#Eval("SysNo")%>' target="_blank"><%#AppCmn.CommonTools.CutStr(Eval("Title").ToString(),16)%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>

                </div>
            </div>--%>
        </div>


        <div class="clear"></div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <script type="text/javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/jquery.pngFix.pack.js"></script>
    <script type="text/javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/new.js"></script>
    <script type="text/javascript">
        $(function () {

            $(".zjlm_r_c2 li:nth-child(5n)").append("");
        })
    </script>
</asp:Content>
