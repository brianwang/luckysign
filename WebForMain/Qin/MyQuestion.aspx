<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true"
    CodeBehind="MyQuestion.aspx.cs" Inherits="WebForMain.Qin.MyQuestion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlLibrary/QinSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/ComboShow.ascx" TagName="ComboShow" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/QinRightPannel.ascx" TagName="RightPannel" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的问答-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="height20">
    </div>
    <div class="page_left">
        <div class="page_con_item">
            <ul>
                <li class="<%=on[0] %>"><a href="MyQuestion.aspx?type=0">我的提问</a></li>
                <li class="<%=on[1] %>"><a href="MyQuestion.aspx?type=1">我的回答</a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="height20">
        </div>
        <uc1:ComboShow ID="ComboShow1" runat="server"></uc1:ComboShow>
         <div class="clear">
        </div>
        <uc1:Pager ID="Pager1" runat="server">
        </uc1:Pager>
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
        <div class="height20">
        </div>
        <div class="page_right_box">
            <div class="page_right_box_t">
                最新问题</div>
            <div class="page_right_question">
                <ul>
                    <asp:Repeater ID="rptNewQuest" runat="server">
                        <ItemTemplate>
                            <li><a href="../Quest/Question.aspx?id=<%# Eval("SysNo")%>">
                                <%# Eval("Title")%></a> <span>
                                    <%# Eval("LeftTime")%></span><span>回复：<%# Eval("ReplyCount")%></span><span>悬赏积分：<%# Eval("Award")%></span>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="height20">
        </div>
        <div class="page_right_box">
            <div class="page_right_box_t">
                排行榜</div>
            <div class="page_right_rank">
                <ul>
                    <asp:Repeater ID="rptHotUser" runat="server">
                        <ItemTemplate>
                            <li class="<%# GetEnglishNum(Container.ItemIndex+1)%>)">
                                <div class="page_right_rank_s">
                                    <span></span>
                                    <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" width="70" height="70" />
                                    <a href="View/<%# Eval("CustomerSysNo")%>">
                                        <%# Eval("NickName")%>
                                        |
                                        <%#AppCmn.AppEnum.GetFateType(int.Parse(Eval("FateType").ToString()))%></a><br />
                                    积分：<%# Eval("Point")%><br />
                                    金币：<%# Eval("Credit")%>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
