<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComboShow.ascx.cs" Inherits="WebForMain.ControlLibrary.ComboShow" EnableViewState="false" %>
<%@ Register Src="AstroForQuest.ascx" TagName="Astro" TagPrefix="uc1" %>
<%@ Register Src="BaZiForQuest.ascx" TagName="Bazi" TagPrefix="uc1" %>
<%@ Register Src="ZiWeiForQuest.ascx" TagName="Ziwei" TagPrefix="uc1" %>
<asp:Repeater ID="rptCombo" runat="server">
    <ItemTemplate>
        <div class="page_box">
            <div class="page_box_l" id='pl<%#Eval("ifshowphoto")%>'>
                <img id="<%#Eval("PhotoID")%>" src="../ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" />
            </div>
            <div class="page_box_r" id='pr<%#Eval("width")%>'>
                <div class="page_corner" id='pc<%#Eval("ifshowphoto")%>' >
                </div>
                <div class="page_box_all">
                    <div id="<%#Eval("PersonID")%>" class="page_person_name">
                        <a href="View.aspx?id=<%# Eval("CustomerSysNo")%>"><%# Eval("NickName")%></a><%# DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd HH:mm")%>
                    </div>
                    <div class="page_person_title">
                        <%# Eval("TitleShow")%>
                    </div>
                    <div class="page_person_con">
                        <%# Eval("ImgShow")%>
                        <div class="page_person_text">
                            <%# Eval("ContentShow")%>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="page_person_a">
                        <%# Eval("ReadShow")%><%# Eval("CommentShow")%>
                    </div>
                    <div id="chartdiv<%# Container.ItemIndex %>" style="display:none;">
                        <uc1:Astro ID="Astro1" runat="server" Visible="false"></uc1:Astro>
                <uc1:Bazi ID="Bazi1" runat="server" Visible="false"></uc1:Bazi>
                <uc1:Ziwei ID="Ziwei1" runat="server" Visible="false"></uc1:Ziwei>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
