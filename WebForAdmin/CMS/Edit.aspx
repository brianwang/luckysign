<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="WebForAdmin.CMS.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>添加/修改文章</h2>
    <p id="page-intro">
        *为必填
    </p>
    <div id="noticediv" class="notification attention png_bg" style="display: none;">
        <a href="#" class="close">
            <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                alt="close" /></a>
        <div>
            <asp:Literal ID="ltrNotice" runat="server"></asp:Literal>
        </div>
    </div>
    <div id="errordiv" class="notification error png_bg" style="display: none;">
        <a href="#" class="close">
            <img src="../WebResources/images/icons/cross_grey_small.png" title="Close this notification"
                alt="close" /></a>
        <div>
            <asp:Literal ID="ltrError" runat="server"></asp:Literal>
        </div>
    </div>
    <fieldset class="column-left">
        <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
        <p>
            <label>
                编号*</label>
            <asp:TextBox ID="txtSysNo" class="text-input small-input" ReadOnly="true" Enabled="false"
                Text="自动生成" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                分类*</label><asp:DropDownList ID="drpCate" runat="server" class="medium-input">
                </asp:DropDownList>
            <br />
            <small></small>
        </p>
        <p>
            <label>
                阅读价格*</label>
            <asp:TextBox ID="txtPoint" class="text-input small-input" runat="server" Text="0"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>阅读所需要支付的积分数</small>
        </p>
        <p>
            <label>
                作者</label>
            <asp:TextBox ID="txtAuthor" class="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
    </fieldset>
    <fieldset class="column-right">
        <!-- Set class to "column-left" or "column-right" on fieldsets to divide the form into columns -->
        <p>
            <label>
                来源</label>
            <asp:TextBox ID="txtSource" class="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <label>
                关键字</label>
            <asp:TextBox ID="txtKeyWords" class="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>关键字，空格分隔</small>
        </p>
        <p>
            <label>
                排序数值</label>
            <asp:TextBox ID="txtOrder" class="text-input small-input" runat="server" Text="0"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>排序值，按数字倒序排列</small>
        </p>
    </fieldset>
    <div class="clear">
    </div>
    <fieldset>
        <p>
            <label>
                标题*</label>
            <asp:TextBox ID="txtTitle" class="text-input medium-input" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>文章标题</small>
        </p>
        <p>
            <label>
                简介*</label>
            <asp:TextBox ID="txtDesc" class="text-input medium-input" TextMode="MultiLine" runat="server" Height="50"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>一段简短的吸引人的介绍</small>
        </p>
        <p>
            <label>
                图片上传</label><asp:FileUpload ID="FileUpload1" CssClass="medium-input" Width="352px" runat="server" />
                    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="上传" /><br />
                    <asp:Image ID="Image1" runat="server" Height="80" Width="120" Visible="false" /><br />
                    <asp:TextBox ID="TextBox1" class="text-input medium-input" ReadOnly="true" Visible="false" runat="server"></asp:TextBox>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small>支持jpg、jpeg、gif、png格式的图片，不超过1M，建议图片尺寸大于180×180</small>
        </p>
        <p>
            <label>
                文章内容*</label>
            <CKEditor:CKEditorControl ID="txtContext" runat="server" Skin="kama"></CKEditor:CKEditorControl>
            <%--<span class="input-notification success png_bg">Successful message</span>--%>
            <!-- Classes for input-notification: success, error, information, attention -->
            <br />
            <small></small>
        </p>
        <p>
            <asp:Button runat="server" CssClass="button" Text="保存" OnClick="Unnamed3_Click" />
        </p>
    </fieldset>
</asp:Content>
