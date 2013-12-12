<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MsgDetail.aspx.cs" Inherits="WebForMain.Qin.MsgDetail" %>
<%@ Register Src="~/ControlLibrary/QinRightPannel.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我和<%=TargetName %>之间的私密对话-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="height20">
    </div>
    <div class="page_left">
        <div class="page_con_item">
            <div class="page_submit">
                <a href="MyMessage.aspx">返回</a>
            </div>
            <ul>
                <li><a href="MyComment.aspx">? 评论</a></li>
                <li><a href="MyNotice.aspx">? 系统消息</a></li>
                <li class="on"><a href="MyMessage.aspx">? 私信</a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div id="isTarget" runat="server" class="page_letter_text">
            我与 <a href="View.aspx?id=<%=TargetID %>"><%=TargetName %></a> 之间的私密对话
        </div>
        <div class="height20">
        </div>
        <asp:Repeater ID="rptMsg" runat="server">
            <ItemTemplate>
                <div class="page_box">
                    <div class="page_box_l">
                        <img src='~/ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("FromPhoto")%>' />
                    </div>
                    <div class="page_box_r">
                        <div class="page_letter_t">
                            <a href='View.aspx?id=<%# Eval("FromSysNo")%>'><%# Eval("FromNickName")%></a> <%# DateTime.Parse(Eval("TS").ToString()).ToString("")%>
                        </div>
                        <div class="page_letter_c">
                            <%# Eval("Context")%>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <!--评论-->
        <div class="page_letter_dis">
            <asp:Image ID="imgPhoto" Visible="false" runat="server" />
            <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:LinkButton ID="LinkButton1" runat="server" class="btn_01" OnClick="Unnamed2_Click" style="margin-top:10px">发送</asp:LinkButton>
        </div>
    </div>
    <div class="page_right">
        <div class="page_person_search" style="margin: 0; padding: 0">
            <uc1:Search ID="Search1" runat="server"></uc1:Search>
        </div>
        <div class="height20">
        </div>
        <div class="page_right_box">
            <uc1:RightPannel ID="RightPannel1" runat="server"></uc1:RightPannel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
