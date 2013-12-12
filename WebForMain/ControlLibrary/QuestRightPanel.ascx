<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestRightPanel.ascx.cs" Inherits="WebForMain.ControlLibrary.QuestRightPanel" %>


<div class="new_right_t"><asp:Literal ID="ltrMaster" runat="server"></asp:Literal></div>
<asp:Repeater ID="rptStars" runat="server">
    
    <ItemTemplate>
        <div class="page_right_box_info" style="background: none; padding-bottom: 0px">
            <img src="~/ControlLibrary/ShowPhoto.aspx?type=o&id=<%#Eval("Photo")%>" />
            <div class="page_right_box_info_r" style="width: 135px">
                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Qin/View.aspx?id=<%#Eval("CustomerSysNo")%>" target="_blank"><%#Eval("NickName")%></a><br />
                <%#Eval("Intro")%>
            </div>
            <div class="clear"></div>
        </div>

    </ItemTemplate>
</asp:Repeater>


<div id="searchdiv" class="page_person_search" style="margin: 0; padding: 0; width: auto; margin-top: 10px;margin-bottom: 10px" runat="server">
    <asp:TextBox runat="server" class="input1" ID="txtName" value="寻找你感兴趣的咨询话题" onblur="if (this.value==''){ this.value='寻找你感兴趣的咨询话题';this.style.color='#9C9C9C';}else{this.style.color='#333';}"
        Style="width: 170px" onfocus="if (this.value=='寻找你感兴趣的咨询话题') {this.value='';this.style.color='#333';}"></asp:TextBox>
    <asp:Button ID="LinkButton1" class="input2" runat="server" Text="GO" OnClick="LinkButton1_Click" />
</div>
<div class="clear"></div>


<asp:Repeater ID="rptCateMain" runat="server" OnItemDataBound="rptCateMain_ItemDataBound">
    <ItemTemplate>
        <div class="new_right_t"><%#Eval("Name")%></div>
        <div class="new_right_c">
            <ul>
                <asp:Repeater ID="rptCateSub" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="new_right_l">
                                <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/new/ico<%#Eval("SysNo")%>.gif" align="absmiddle" />
                            </div>
                            <div class="new_right_r">
                                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Index/<%#Eval("SysNo")%>"><%#Eval("Name")%> （<%#Eval("Replys")%>）<br />
                                    <span style="font-size: 12px">问题数：<%#Eval("QuestNum")%>    已解决：<%#Eval("SolvedNum")%></span></a>
                            </div>
                            <div class="clear"></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </ItemTemplate>
</asp:Repeater>

