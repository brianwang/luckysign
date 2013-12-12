<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="True"
    CodeBehind="Index.aspx.cs" Inherits="WebForMain.Qin.Index" %>

<%@ Register Src="../ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/ComboShow.ascx" TagName="ComboShow" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的关注-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page_person">
        <div class="page_person_img">
            <asp:Image ID="imgPhoto" runat="server" /></div>
        <div class="page_person_item">
            <asp:ImageButton runat="server" ImageUrl="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/button1.jpg" OnClick="Unnamed1_Click" />
            <asp:ImageButton runat="server" ImageUrl="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/button2.jpg" OnClick="Unnamed2_Click" />
            <asp:ImageButton runat="server" ImageUrl="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/button3.jpg" OnClick="Unnamed3_Click" />
            <asp:ImageButton runat="server" ImageUrl="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/button4.jpg" OnClick="Unnamed4_Click" />
            <asp:ImageButton runat="server" ImageUrl="<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/button5.jpg" OnClick="Unnamed5_Click" />
        </div>
        <div class="page_person_search" style="padding-top: 10px">
            <uc1:Search ID="Search1" runat="server">
            </uc1:Search>
            <div class="clear">
            </div>
            <div class="page_guanzhu_button">
                <asp:LinkButton CssClass="gz1" runat="server" OnClick="Unnamed7_Click">介绍自己</asp:LinkButton>
                <asp:LinkButton CssClass="gz2" runat="server" OnClick="Unnamed8_Click">绑定微博</asp:LinkButton>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="height20">
    </div>
    <div class="page_left">
        <uc1:ComboShow ID="ComboShow1" runat="server"></uc1:ComboShow>
        <div class="clear">
        </div>
        <uc1:Pager ID="Pager1" runat="server">
        </uc1:Pager>
    </div>
    <div class="page_right">
        <div class="page_right_box">
            <div class="page_right_box_t">
                我关注的人(<%=TotalFriends %>)</div>
            <div class="page_right_box_c">
                <ul>
                    <asp:Repeater ID="rptFriend" runat="server">
                        <ItemTemplate>
                            <li><a href="View.aspx?id=<%# Eval("CustomerSysNo")%>">
                                <img src="../ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" /><%# Eval("NickName")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="page_right_box_a">
                <asp:LinkButton runat="server" OnClick="Unnamed9_Click">More>></asp:LinkButton></div>
        </div>
        <div class="page_right_box">
            <div class="page_right_box_t">
                关注我的人(<%=TotalFans %>)</div>
            <div class="page_right_box_c">
                <ul>
                    <asp:Repeater ID="rptFans" runat="server">
                        <ItemTemplate>
                            <li><a href="View.aspx?id=<%# Eval("CustomerSysNo")%>">
                                <img src="../ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" /><%# Eval("NickName")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="page_right_box_a">
                <asp:LinkButton runat="server" OnClick="Unnamed10_Click">More>></asp:LinkButton></div>
        </div>
        <div class="page_right_box">
            <div class="page_right_box_t">
                你可能喜欢的人(118)</div>
            <div class="page_right_box_c">
                <ul>
                    <asp:Repeater ID="rptLike" runat="server">
                        <ItemTemplate>
                            <li><a href="#">
                                <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/man.jpg" />赵薇</a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="page_right_box_a">
                <asp:LinkButton runat="server" OnClick="Unnamed11_Click">More>></asp:LinkButton></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
