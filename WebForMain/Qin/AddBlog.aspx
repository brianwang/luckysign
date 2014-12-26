<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="WebForMain.Qin.AddBlog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>����<%=AppCmn.AppEnum.GetBlogArticleType(type) %>-����ǩ</title>
    <style type="text/css">
        body {
            font-size: 14px;
        }

        input {
            vertical-align: middle;
            margin: 0;
            padding: 0;
        }

        .file-box {
            position: relative;
            width: 80px;
        }

        .file-div {
            position: absolute;
            top: 6px;
            right: 0px;
            height: 24px;
            filter: alpha(opacity:0);
            opacity: 0;
            width: 80px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="height20"></div>
    <div class="pic_submit">
        <div class="pic_submit_t1">
            <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
        </div>
        <div class="pic_submit_form">
            <div class="pic_submit_title">
                <asp:TextBox ID="TextBox1" runat="server" Text="ѡ�����" onblur="if (this.value==''){ this.value='ѡ�����';this.style.color='#9C9C9C';}else{this.style.color='#333';}" onfocus="if (this.value=='ѡ�����') {this.value='';this.style.color='#333';}"></asp:TextBox>
                <br />
            </div>
            <div class="file-box" id="fileadd" runat="server">
                <a href="javascript:void(0);" class="pic_submit_add" style="cursor: default;">+����ļ�<asp:Literal ID="ltrAddBtn" runat="server"></asp:Literal></a>
                <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" Width="70" CssClass="file-div" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" OnUploadedFileError="AsyncFileUpload1_UploadedFileError"
                    OnClientUploadError="asyncfileupload1_uploaderror" OnClientUploadStarted="asyncfileupload1_startupload"
                    OnClientUploadComplete="asyncfileupload1_uploadcomplete" />
            </div>
            <asp:Literal ID="ltrTip" runat="server"></asp:Literal>
            <div class="pic_submit_filebox" id="filebox" runat="server" style="height: 22px; padding: 4px">
                <span class="loading">
                    <img src="WebResources/img/submit_btn1.gif" align="absmiddle" />�ҵĸ�����.MP3</span>
                <div class="clear"></div>
            </div>

            <div class="pic_submit_all">
                <div class="pic_submit_form_l">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <div class="pic_submit_a">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">ȡ��</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Ԥ��</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="sumbit" OnClick="LinkButton4_Click">����</asp:LinkButton>
                    </div>
                </div>
                <div class="pic_submit_form_r">
                    <div class="search_select_box">
                        <div class="search_select">
                            <a href="javascript:void(0)" class="SelectTitle">�����˿ɼ�</a>
                            <div class="SelectBox" style="display: none">
                                <a href="javascript:void(0);select(0);">�����˿ɼ�</a>
                                <a href="javascript:void(0);select(1);">���ѿɼ�</a>
                                <a href="javascript:void(0);select(2);">���Լ��ɼ�</a>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="pic_submit_r_a">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="��Ϊ�ݸ�" />
                    </div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <script type="text/javascript">
        function select(input) {
            document.getElementById("<%=HiddenField1.ClientID%>").value = input;
        }

        function asyncfileupload1_uploaderror(sender, args) {
            document.getelementbyid('labeluploadstatus').innertext = "�Բ����ļ���" + args.get_filename() + "���ϴ�����ԭ��" + args.get_errormessage();
        }


        function asyncfileupload1_startupload(sender, args) {
            document.getelementbyid('labeluploadstatus').innertext = "�ļ���" + args.get_filename() + "�������ϴ������Ե�";
        }

        function asyncfileupload1_uploadcomplete(sender, args) {
            document.getelementbyid('labeluploadstatus').innertext = "�ļ���" + args.get_filename() + "���ϴ���ɣ��ļ���С��" + args.get_length() + " bytes";
        }
    </script>
</asp:Content>
