<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebForMain.Error" %>

<%@ Register Src="ControlLibrary/ShowAdv.ascx" TagName="ShowAdv" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        ҳ�治����-����ǩ������ѯ��</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style='background: #f7f4ee; width: 786px; padding-left: 82px; padding-right: 82px; padding-top:50px;'>
        <div style='font:18px/24px "΢���ź�";margin-bottom:20px;'>
            <asp:Literal ID="ltrErr" runat="server"></asp:Literal>�������Է���&nbsp;<a href="/" style="color:#a12026; text-decoration:underline;">��ҳ</a></div>
        <div style='background-color: #80776D; padding:3px 0px 3px 16px; font: 14px/20px "΢���ź�"; color: #fff; margin-bottom: 10px; margin-top: 10px; width: 770px;'>
            �㻹���ܶ��������ݸ���Ȥ
        </div>
        <div style="height:500px;width:786px;">
            <div style="float: left; width: 515px; padding-left:26px;">
                <div class="zjlm_box_t" style="height:120px;">
                    <h1>������</h1>
                    ��������ѯ������ѧ�߻�����ʦ�о�ѧϰ��������з�������<br />
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Ask" target="_blank" class="zjlm_box_t_a" style="background: #779058;float:none;">�����</a>
                </div>
                <div class="zjlm_box_t" style="height:120px;">
                    <h1>ѧϰ����</h1>
                    ������ռ�ǣ�����ռ������ޱ���֣�һ���򾡣��������ۣ�ѧϰ���ѣ����ֹ�ˮ��<br />
                    <a href="<%=AppCmn.AppConfig.HomeUrl() %>Quest/Talk" target="_blank" class="zjlm_box_t_a" style="background: #6d8690;float:none;">������</a>
                </div>
            </div>
            <div style="float: right; width: 245px">
                <div class="index_right_list2">
                    <ul>
                        <li style="padding: 3px 9px 0px; border-bottom: none"><a href="PPLive/Astro.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_zhanxing.jpg" height="58" width="58" alt="����ռ��������" />ռ������</a></li>
                        <li style="padding: 3px 9px 0px; border-bottom: none"><a href="PPLive/ZiWei.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_ziwei.jpg" height="58" width="58" alt="��ޱ��������" />�϶�����</a></li>
                        <li style="padding: 3px 9px 0px; border-bottom: none"><a href="PPLive/BaZi.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_bazi.jpg" height="58" width="58" alt="������������" />��������</a></li>
                    </ul>
                    <%--<a href="#">������������</a>--%>
                    <div class="clear">
                    </div>
                </div>
                <div class="index_right_list1" style="border-bottom:none;padding-left:15px;padding-top:10px;">
                    <uc1:ShowAdv ID="AdvRightMid" runat="server" advfrom="IndexCeOl.htm" EnableViewState="true" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
