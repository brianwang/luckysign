<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="True"
    CodeBehind="Index.aspx.cs" Inherits="WebForMain.Article.Index" %>

<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/ArticleRightPanel.ascx" TagName="Right" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        <%=title %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="leftbox left">
            <div class="searchbar">
                <div class="searchipt left">
                    <asp:TextBox ID="txtName" runat="server" CssClass="ipt_2"></asp:TextBox></div>
                <asp:LinkButton runat="server" CssClass="btn_02" OnClick="Unnamed3_Click">搜索资料</asp:LinkButton>
                <div class="clear">
                </div>
            </div>
            <div class="block show">
                <asp:Repeater ID="rptQuestion" runat="server">
                    <ItemTemplate>
                        <div class="blocks even">
                            <h3>
                                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>" target="_blank" title="<%#Eval("Title")%>">
                                    <%#Eval("Title")%></a></h3>&nbsp;[<a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/<%#Eval("CateSysNo")%>" title="<%#Eval("Name")%>"><%#Eval("Name")%></a>]
                            <div class="txt">
                                发布时间：<%# DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd")%>| 人气：<%#Eval("ReadCount")%><%#Eval("Power")%></div>
                            <p>
                                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>">
                                    <%#Eval("Description")%></a></p>
                            <div class="span_02">
                                <%#Eval("Keys")%>
                            </div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="blocks">
                            <h3>
                                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>" target="_blank" title="<%#Eval("Title")%>">
                                    <%#Eval("Title")%></a></h3>&nbsp;[<a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/<%#Eval("CateSysNo")%>" title="<%#Eval("Name")%>"><%#Eval("Name")%></a>]
                            <div class="txt">
                                发布时间：<%# DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd")%>| 人气：<%#Eval("ReadCount")%><%#Eval("Power")%></div>
                            <p>
                                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Article/Content/<%#Eval("SysNo")%>">
                                    <%#Eval("Description")%></a></p>
                            <div class="span_02">
                                <%#Eval("Keys")%>
                            </div>
                        </div>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </div>
            <div class="clear">
            </div>
            <div class="line_02">
            </div>
            <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
            <div class="clear">
            </div>
        </div>
        <div class="rightbox left">
             <uc1:Right ID="Right1" runat="server"></uc1:Right>
           
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
<script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>
</asp:Content>
