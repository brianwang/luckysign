<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="TalkList.aspx.cs" Inherits="WebForMain.Quest.TalkList" %>

<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/QuestRightPanel.ascx" TagName="Right" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>问题悬赏列表-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="index_left">
            <!--煮酒论命-->

            <div class="index_left_box">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="index_new_ask_t" style="padding: 0px">
                            <div class="index_new_ask_button">
                                <%--<a href="Ask.aspx" target="_blank" style="background: #779058">我要求测</a>--%>
                                <a href="Talk.aspx" target="_blank" style="background: #6D8690">发起讨论</a>
                            </div>
                            <div class="index_new_ask_position">
                                <asp:Literal ID="ltrNav" runat="server"></asp:Literal>
                            </div>
                            
                            <div class="index_new_ask_rank">
                                <asp:LinkButton ID="lkbOrder1" runat="server" OnClick="Unnamed5_Click" CssClass="current">发布时间<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/new/down.jpg"  align="absmiddle"/></asp:LinkButton>
                                <asp:LinkButton ID="lkbOrder3" runat="server" Style="display: none;" OnClick="Unnamed7_Click">悬赏金额<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/new/down.jpg"  align="absmiddle"/></asp:LinkButton>
                                <asp:LinkButton ID="lkbOrder2" runat="server" OnClick="Unnamed6_Click">回复数<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/new/down.jpg"  align="absmiddle"/></asp:LinkButton>
                            </div>
                            <div class="clear"></div>
                            
                        </div>

                        <div class="index_left_new_list">
                            <div class="index_left_new_ul">
                                <ul>
                                    <asp:Repeater ID="rptQuestion" runat="server" >
                                        <ItemTemplate>
                                            <li >
                                                <div class="index_left_new_msgnum"><%#Eval("ReplyCount")%></div>
                                                <div class="index_left_new_msgbox">
                                                    <span class="msgtime"><a href='../Qin/View.aspx?id=<%#Eval("CustomerSysNo")%>' target="_blank"><%#Eval("NickName")%></a>  |  <%#Eval("DateShow")%></span>
                                                    <h3><a href='Topic.aspx?id=<%#Eval("SysNo")%>'><%#AppCmn.CommonTools.CutStr(Eval("Title").ToString(),30)%></a> <%--<img src="WebResources/img/new/jing.gif" align="absmiddle" /> <img src="WebResources/img/new/ding.gif" align="absmiddle" />--%></h3>
                                                    <div class="clear"></div>
                                                    <div class="msgcontent">
                                                        <%#AppCmn.CommonTools.CutStr(Eval("Context").ToString(),50)%>
                                                        <%-- <img src="WebResources/IMAGES/pic_02.jpg" width="100" /> <img src="WebResources/IMAGES/pic_02.jpg" width="100" />--%>
                                                    </div>
                                                </div>
                                                <div class="clear"></div>
                                            </li>



                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <li class="odd">
                                                <div class="index_left_new_msgnum"><%#Eval("ReplyCount")%></div>
                                                <div class="index_left_new_msgbox">
                                                    <span class="msgtime"><a href='../Qin/View.aspx?id=<%#Eval("CustomerSysNo")%>' target="_blank"><%#Eval("NickName")%></a>  |  <%#Eval("DateShow")%></span>
                                                    <h3><a href='Topic.aspx?id=<%#Eval("SysNo")%>'><%#AppCmn.CommonTools.CutStr(Eval("Title").ToString(),30)%></a> <%--<img src="WebResources/img/new/jing.gif" align="absmiddle" /> <img src="WebResources/img/new/ding.gif" align="absmiddle" />--%></h3>
                                                    <div class="clear"></div>
                                                    <div class="msgcontent"><%#AppCmn.CommonTools.CutStr(Eval("Context").ToString(),50)%></div>
                                                </div>
                                                <div class="clear"></div>
                                            </li>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>


                                </ul>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
            </div>
        </div>

        <div class="index_right">
            <div class="new_right_item">
                <asp:Literal ID="ltrCateName" runat="server"></asp:Literal></div>
            <uc1:Right ID="Right1" runat="server"></uc1:Right>

        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
