<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="WebForMain.Qin.View" %>

<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/QinRightPannel.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=m_user.NickName %>的首页-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="height20"></div>
    <div class="page_left">
        <div class="page_otherperson">
            <div class="page_otherperson_img">
                <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" />
            </div>
            <div class="mypage_otherperson_info">
                <%=m_user.NickName %><img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/ico<%=(8-m_user.Gender).ToString("0") %>.gif" align="absmiddle" /><br />

                <%=ltrMe %>目前最感兴趣的是：<samp><%=AppCmn.AppEnum.GetFateType(m_user.FateType) %></samp><br />
                个人简介：<%=m_user.Intro %><br />
                <asp:Literal ID="ltrBirth" runat="server"></asp:Literal><br />
                来自：<asp:Literal ID="ltrFrom" runat="server"></asp:Literal>

                <div class="page_guanzhu_button">
                    <a id="intro" runat="server" href="UserInfo.aspx?id=<%=m_user.SysNo %>&tab=1" class="gz1">介绍自己</a>
                    <a id="sendmsg" runat="server" href="MsgDetail.aspx?UserSysNo=<%=m_user.SysNo %>" class="gz1">发消息</a>
                    <%--<a href="UserInfo.aspx?tab=3" class="gz2">排盘设置</a>--%>
                </div>
            </div>
            <div class="clear"></div>
        </div>

        <div class="mr_left_name">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><%=ltrMe %>的回答</asp:LinkButton>
            &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click"><%=ltrMe %>的文章</asp:LinkButton>
        </div>

        <div class="mypage_otherperson_content">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <ul class="mypage_otherperson_ul">
                        <asp:Repeater ID="rptArticle" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="mypage_otherperson_title"><a href="../Article/Content.aspx?id=<%# Eval("SysNo")%>" target="_blank"><%# Eval("Title")%></a></div>
                                    <div class="mypage_otherperson_con"><%# Eval("Description")%></div>
                                    <div class="mypage_otherperson_a"><%# Eval("KeyWordsShow")%></div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <ul class="mypage_otherperson_ul">
                        <asp:Repeater ID="rptQuest" runat="server">
                            <ItemTemplate>
                                <li>
                                    <div class="mypage_otherperson_title"><a href="../Quest/Question.aspx?id=<%# Eval("QuestSysNo")%>" target="_blank"><%# Eval("QuestTitle")%></a></div>
                                    <div class="mypage_otherperson_con"><%# Eval("Context")%></div>
<%--                                    <div class="mypage_otherperson_a"><%# Eval("KeyWordsShow")%></div>--%>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </asp:View>
            </asp:MultiView>

        </div>
        <div class="clear"></div>
    </div>

    <div class="page_right" style="width: 242px">

        <div class="page_right_box">
            <uc1:RightPannel ID="RightPannel1" runat="server"></uc1:RightPannel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
