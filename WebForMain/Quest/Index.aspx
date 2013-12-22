<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebForMain.Quest.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>煮酒论命-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">

        <div class="index_left">
            <!--免费求测-->
            <div class="zjlm_box" style="border-top: solid 2px #a4534b">
                <div class="zjlm_box_t">
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Ask" target="_blank" class="zjlm_box_t_a" style="background: #779058">求解盘</a>
                    <h1>免费求测</h1>
                    免费求测咨询，供初学者或命理师研究学习，求测者有反馈义务。
                </div>


                <div class="zjlm_ul1">
                    <ul>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <li style='<%#Eval("style")%>'>
                                    <a href='<%=AppCmn.AppConfig.HomeUrl() %>Quest/QuestList/<%#Eval("SysNo")%>' target="_blank">
                                        <img src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/CatePic/<%#Eval("Pic")%>' alt='<%#Eval("Name")%>' /></a>
                                    <a href='<%=AppCmn.AppConfig.HomeUrl() %>Quest/QuestList/<%#Eval("SysNo")%>' target="_blank"><%#Eval("Name")%>（<%#Eval("NewCount")%>）</a>
                                    <%#Eval("Intro")%>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear"></div>
                </div>
            </div>

            <!--专业咨询-->
            <%--<div class="zjlm_box" style="background: #d2eff2">
                <div class="zjlm_box_t">
                    <a href="#" class="zjlm_box_t_a" style="background: #a5534c">求解盘</a>
                    <h1>专业咨询</h1>
                    面向客户的付费专业解盘，由获命理师竞价咨询提供深度解析服务，保障服务质量并提供隐私保护。
                </div>

                <div class="zjlm_ul2">
                    <ul>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>
                        <li><a href="#">不知道还能不能嫁出去了。救…(19) </a><span>0</span>/5单</li>

                    </ul>
                    <div class="clear"></div>
                </div>
            </div>--%>

            <!--学习讨论-->
            <div class="zjlm_box">
                <div class="zjlm_box_t">
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Talk" target="_blank" class="zjlm_box_t_a" style="background: #6d8690">发新贴</a>
                    <h1>学习讨论</h1>
                    星座，占星，塔罗占卜，紫薇八字，一网打尽，发帖讨论，学习交友，娱乐灌水。
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
            <div class="page_person_search" style="margin: 0; padding: 0; width: auto">
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
            </div>
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
