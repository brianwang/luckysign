<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="WebForMain.Qin.View" %>

<%@ Register Src="../ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/ComboShow.ascx" TagName="ComboShow" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=m_user.NickName %>的首页-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="height20">
    </div>
    <div class="page_left">
        <div class="page_otherperson">
            <div class="page_otherperson_img">
                <img src="../WebResources/<%=m_user.Photo %>" />
            </div>
            <div class="page_otherperson_info">
                <a href="#"><%=m_user.NickName %>
                    <%--<img src="WebResources/img/ico1.gif" align="absmiddle" />--%></a>
                签名档<br />
                <%=m_user. %><br />
                积分：<samp><%=m_user.Point %></samp><br />
                回答/被采纳：<samp>200/230</samp><br />
                关注：<samp>200</samp>
                粉丝：<samp>200</samp>
                <br />
                最后登录时间：<samp><%=m_user.LastLoginTime.ToString("yyyy-MM-dd HH:mm") %> </samp>

            </div>
            <div class="page_otherperson_item">
                <ul>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>
                    <li><a href="#">
                        <img src="WebResources/img/png1.png" /></a></li>

                </ul>

                <div class="clear"></div>

                <div class="page_otherperson_item_A">
                    <a href="#">
                        <img src="WebResources/img/png2.png" /></a>
                    <a href="#">
                        <img src="WebResources/img/png3.png" /></a>
                </div>
            </div>

            <div class="clear"></div>
        </div>
        <uc1:ComboShow ID="ComboShow1" runat="server"></uc1:ComboShow>
        <div class="clear">
        </div>
        <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
    </div>
    <div class="page_right">
        <div class="page_person_search" style="padding: 0px; margin: 0 0px 40px 0px">
            <uc1:Search ID="Search1" runat="server"></uc1:Search>
            <div class="clear">
            </div>
            <div class="page_guanzhu_button">
                <asp:LinkButton ID="LinkButton1" CssClass="gz1" runat="server" OnClick="Unnamed7_Click">添加关注</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" CssClass="gz2" runat="server" OnClick="Unnamed8_Click">发消息</asp:LinkButton>
            </div>
        </div>
        <div class="clear"></div>
        <div class="page_right_box">
            <div class="page_right_box_t">
                我关注的人(<%=TotalFriends %>)
            </div>
            <div class="page_right_box_c">
                <ul>
                    <asp:Repeater ID="rptFriend" runat="server">
                        <ItemTemplate>
                            <li><a href="View.aspx?id=<%# Eval("CustomerSysNo")%>">
                                <img src="../WebResources/<%#Eval("Photo")%>" /><%# Eval("NickName")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="page_right_box_a">
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="Unnamed9_Click">More>></asp:LinkButton>
            </div>
        </div>
        <div class="page_right_box">
            <div class="page_right_box_t">
                关注我的人(<%=TotalFans %>)
            </div>
            <div class="page_right_box_c">
                <ul>
                    <asp:Repeater ID="rptFans" runat="server">
                        <ItemTemplate>
                            <li><a href="View.aspx?id=<%# Eval("CustomerSysNo")%>">
                                <img src="../WebResources/<%#Eval("Photo")%>" /><%# Eval("NickName")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="page_right_box_a">
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="Unnamed10_Click">More>></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
