<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="WebForMain.Qin.AddBlog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>发布<%=AppCmn.AppEnum.GetBlogArticleType(type) %>-上上签</title>
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
                <asp:TextBox ID="TextBox1" runat="server" Text="选填标题" onblur="if (this.value==''){ this.value='选填标题';this.style.color='#9C9C9C';}else{this.style.color='#333';}" onfocus="if (this.value=='选填标题') {this.value='';this.style.color='#333';}"></asp:TextBox>
                <br />
            </div>
            <div class="file-box" id="fileadd" runat="server">
                <a href="javascript:void(0);" class="pic_submit_add" style="cursor: default;">+添加文件<asp:Literal ID="ltrAddBtn" runat="server"></asp:Literal></a>
                <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" Width="70" CssClass="file-div" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" OnUploadedFileError="AsyncFileUpload1_UploadedFileError"
                    OnClientUploadError="asyncfileupload1_uploaderror" OnClientUploadStarted="asyncfileupload1_startupload"
                    OnClientUploadComplete="asyncfileupload1_uploadcomplete" />
            </div>
            <asp:Literal ID="ltrTip" runat="server"></asp:Literal>
            <div class="pic_submit_filebox" id="filebox" runat="server" style="height: 22px; padding: 4px">
                <span class="loading">
                    <img src="WebResources/img/submit_btn1.gif" align="absmiddle" />我的歌声里.MP3</span>
                <div class="clear"></div>
            </div>

            <div class="pic_submit_all">
                <div class="pic_submit_form_l">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <div class="pic_submit_a">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">取消</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">预览</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="sumbit" OnClick="LinkButton4_Click">发布</asp:LinkButton>
                    </div>
                </div>
                <div class="pic_submit_form_r">
                    <div class="search_select_box">
                        <div class="search_select">
                            <a href="javascript:void(0)" class="SelectTitle">所有人可见</a>
                            <div class="SelectBox" style="display: none">
                                <a href="javascript:void(0);select(0);">所有人可见</a>
                                <a href="javascript:void(0);select(1);">好友可见</a>
                                <a href="javascript:void(0);select(2);">仅自己可见</a>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="pic_submit_r_a">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="存为草稿" />
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
            document.getelementbyid('labeluploadstatus').innertext = "对不起，文件“" + args.get_filename() + "”上传出错，原因：" + args.get_errormessage();
        }


        function asyncfileupload1_startupload(sender, args) {
            document.getelementbyid('labeluploadstatus').innertext = "文件“" + args.get_filename() + "”正在上传，请稍等";
        }

        function asyncfileupload1_uploadcomplete(sender, args) {
            document.getelementbyid('labeluploadstatus').innertext = "文件“" + args.get_filename() + "”上传完成，文件大小：" + args.get_length() + " bytes";
        }
    </script>
</asp:Content>
