<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="WebForMain.Celebrity.Detail" %>

<%@ Register Src="~/ControlLibrary/AstroForQuest.ascx" TagName="Astro" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/BaZiForQuest.ascx" TagName="Bazi" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/ZiWeiForQuest.ascx" TagName="Ziwei" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/Pagination.ascx" TagName="Pager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=m_famous.Name%>_�������̿�_����ǩ</title>
    <meta content="aaaa" name="keywords" />
    <meta content="bbbb" name="description" />

    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>CSS/page.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="mr_box">
            <!--��ҳ���-->
            <div class="mr_left">
                <%--<div class="mr_left_name">�������>��������</div>--%>

                <div class="mr_content" style="margin-top:0px">
                    <div class="mr_content_title">
                        <div class="mr_left_name_a">
                            <a href="<%=AppCmn.AppConfig.HomeUrl() %>Qin/MyCollection.aspx?type=<%=(int)AppCmn.AppEnum.CollectionType.famous %>&add=1&sysno=<%=m_famous.SysNo %>" target="_blank" class="gz1">��ӵ��ղ�</a>
                            <!-- JiaThis Button BEGIN -->
                            <a href="http://www.jiathis.com/share" class="jiathis gz2" target="_blank">����+</a>
                            <div class="jiathis_style" style="width:72px;float:left">
                                <a class="jiathis_counter_style_margin:3px 0 0 2px"></a>
                            </div>
                                
                            <script type="text/javascript">
                                var jiathis_config = {
                                    url: window.location.href,
                                    summary: "<%=AppCmn.CommonTools.CutStr(AppCmn.CommonTools.NoHTML(m_famous.Description), 70)%>",
                                    title: "<%=m_famous.Name%>����������һ��������TA���ر�֮���� #����ǩ���˰�����#",
                                    pic: "<%=m_famous.Photo%>",
                                    hideMore: false
                                }
                            </script>
                            <script type="text/javascript" src="http://v3.jiathis.com/code/jia.js" charset="utf-8"></script>
                            <!-- JiaThis Button END -->

                        </div>
                        <%=m_famous.Name%>
                    </div>

                    <div class="mr_content_img">
                        <img src="<%=m_famous.Photo%>" height="155" width="127" alt="<%=m_famous.Name%>����" />
                    </div>
                    <div class="mr_content_info">
                        <%=m_famous.Description%>
                    </div>

                    <div class="clear"></div>

                    <div class="mr_content_box">
                        <%--<a href="#" class="modify">��Ҫ�޸�</a>--%>
                        ����ʱ�䣺<%=m_famous.BirthYear %>��<%=m_famous.BirthTime.ToString("MM��dd�� HH:mm") %>��<%=GetTimeUnknow(m_famous.TimeUnknown) %>�� ��Դ��<%=m_famous.Source %><br />
                        �ص㣺<%=GetHomeTown(m_famous.HomeTown) %>
                    </div>
                    <uc1:Astro ID="Astro1" runat="server" Visible="false"></uc1:Astro>
                    <uc1:Bazi ID="Bazi1" runat="server" Visible="false"></uc1:Bazi>
                    <uc1:Ziwei ID="Ziwei1" runat="server" Visible="false"></uc1:Ziwei>

                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <!--����-->
                        <div class="mr_liuyan">
                            <ul>
                                <asp:Repeater ID="rptComment" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="mr_liuyan_img">
                                                <a href="<%=AppCmn.AppConfig.HomeUrl() %>Qin/View/<%#Eval("CustomerSysNo")%>" target="_blank">
                                                    <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("Photo")%>" width="70" height="70" /></a>
                                            </div>
                                            <div class="mr_liuyan_r">
                                                <div class="mr_liuyan_title"><a href="<%=AppCmn.AppConfig.HomeUrl() %>Qin/View/<%#Eval("CustomerSysNo")%>" target="_blank"><span><%#Eval("NickName")%></span></a> <%#DateTime.Parse(Eval("TS").ToString()).ToString("yyyy-MM-dd HH:mm")%> </div>
                                                <div class="mr_liuyan_text"><%#Eval("Context")%></div>
                                            </div>
                                            <div class="clear"></div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <uc1:Pager ID="Pager1" runat="server"></uc1:Pager>
                            <div class="clear">
                            </div>
                            <%--<div class="mr_page"><a href="#">��һҳ</a><a href="#">��һҳ</a></div>--%>
                        </div>

                        <div class="clear"></div>
                        <!--������-->
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="mr_form">
                                    <div class="mr_form_l">
                                        <asp:Image ID="Image1" runat="server" />
                                    </div>
                                    <div class="mr_form_r">
                                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton2" runat="server" class="btn_01" OnClick="Button1_Click">����</asp:LinkButton>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="mr_discuss">
                                    <ul>
                                        <li><span>����:</span><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><a href="../Passport/Register.aspx?url=<%=Request.Url.ToString() %>" target="_blank">û���˺ţ�����ע���</a></li>
                                        <li><span>����:</span><asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox></li>
                                        <li><span>����:</span><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox></li>
                                        <li style="padding: 0"><span>&nbsp;</span>
                                           <asp:LinkButton ID="LinkButton1" runat="server" class="btn_01" OnClick="Button2_Click">����</asp:LinkButton> </li>
                                    </ul>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!--��ҳ�Ҳ�-->
            <div class="mr_right">
                <div style="background: #696969; height: 190px; text-align: center; color: #fff">banner3</div>
            </div>

            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <%--<script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>--%>
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>
</asp:Content>
