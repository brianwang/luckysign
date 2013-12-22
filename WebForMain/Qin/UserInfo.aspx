<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Qin.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="WebForMain.Qin.UserInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="~/ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Canvas {
            position: relative;
            width: 350px;
            height: 300px;
            border: 2px solid #888888;
            overflow: hidden;
            cursor: pointer;
        }

        .smallbig {
            cursor: pointer;
        }

        #bar {
            width: 211px;
            height: 18px;
            background-image: url("<%=AppCmn.AppConfig.WebResourcesPath() %>img/track.gif");
            background-repeat: no-repeat;
            position: relative;
        }

        .child {
            width: 11px;
            height: 16px;
            background-image: url("<%=AppCmn.AppConfig.WebResourcesPath() %>img/grip.gif");
            background-repeat: no-repeat;
            left: 0;
            top: 2px;
            position: absolute;
            left: 100px;
        }

        .imagePhoto {
            border-width: 0px;
            position: relative;
        }

        #IconContainer {
            position: relative;
            left: 0px;
            top: -180px;
        }

            #IconContainer img {
                FILTER: alpha(opacity=60);
                opacity: 0.6;
                background-color: #ccc;
            }

        #ImageDragContainer {
            border: 1px solid #ccc;
            width: 180px;
            height: 180px;
            cursor: pointer;
            position: relative;
            top: 61px;
            left: 84px;
            overflow: hidden;
            z-index: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="height20"></div>

    <div class="page_left">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="mr_left_name">修改头像</div>

                <div class="setting_box">
                    <div class="setting_img">
                        <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=o&id=<%=m_user.Photo %>" />
                    </div>
                    <div class="setting_img_upload" style="margin-left:10px;">
                        <asp:FileUpload ID="FileUpload1" CssClass="setting_input" Width="352px" runat="server" />

                        <h1>支持jpg、jpeg、gif、png格式的图片，不超过1M，建议图片尺寸大于180×180</h1>
                        <asp:Button ID="Button1" runat="server" CssClass="setting_button1" OnClick="Button1_Click" Text="上传" />
                        <asp:Button ID="Button2" runat="server" CssClass="setting_button2" OnClick="Button2_Click" Text="取消" />
                    </div>
                    <div class="clear"></div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="mr_left_name">基本资料</div>

                <div class="setting_box">
                    <ul class="setting_ul">
                        <li>
                            <samp>*</samp>打星号的为必填项，完整的资料会为你带来更多关注</li>
                        <li><span>账号:</span><div class="setting_r"><%=m_user.Email %></div>
                            <div class="clear"></div>
                        </li>
                        <li><span>密码:</span><div class="setting_r"><a href="ChangePass.aspx">修改密码</a></div>
                            <div class="clear"></div>
                        </li>
                        <li><span>昵称:</span><div class="setting_r"><%=m_user.NickName %></div>
                            <div class="clear"></div>
                        </li>
                        <li><span>
                            <samp>*</samp>我:</span>
                            <div class="setting_r">
                                <div class="select_item_box" style="position: relative; z-index: 501">
                                    <asp:DropDownList ID="drpFateType" runat="server" CssClass="select_item">
                                        <asp:ListItem Text="对西洋占星术感兴趣" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="对紫薇斗数感兴趣" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="对四柱八字感兴趣" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="对塔罗牌感兴趣" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <h1 style="color:red;">系统会根据您的选择显示身份及默认命盘类型，一定要认真选择噢~</h1>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>
                            <samp>*</samp>性别:</span><div class="setting_r">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>
                            <samp>*</samp>生日:</span>
                            <div class="setting_r">
                                <uc1:DatePicker ID="DatePicker2" runat="server" Type="3"></uc1:DatePicker>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <%--<li><span>星座:</span><div class="setting_r">狮子座</div>
                            <div class="clear"></div>
                        </li>--%>
                        <li><span>生日显示方式:</span>
                            <div class="setting_r">
                                <div class="select_item_box" style="position: relative; z-index: 499">
                                    <asp:DropDownList ID="drpBirthType" runat="server" CssClass="select_item">
                                        <asp:ListItem Text="显示生日" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="仅显示星座" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>所在地:</span>
                            <div class="setting_r">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <uc1:District ID="District2" runat="server"></uc1:District>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>个人介绍:</span>
                            <div class="setting_r">
                                <div>
                                    <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" CssClass="setting_textarea"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>&nbsp;</span>
                            <div class="setting_r">
                                <asp:Button ID="Button3" runat="server" CssClass="setting_button1" OnClick="Button3_Click" Text="保存" />
                                <asp:Button ID="Button4" runat="server" CssClass="setting_button2" OnClick="Button2_Click" Text="取消" />
                            </div>
                            <div class="clear"></div>
                        </li>
                    </ul>
                </div>

            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="mr_left_name">修改密码</div>

                <div class="setting_box">
                    <ul class="setting_ul">
                        <li><span>当前密码:</span><div class="setting_r">
                            <div>
                                <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" CssClass="setting_input" Width="208px"></asp:TextBox>
                            </div>
                            <h1><a href="../Passport/FindPass.aspx">忘记当前密码</a></h1>
                        </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>新密码:</span><div class="setting_r">
                            <div>
                                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="setting_input" Width="208px"></asp:TextBox>
                            </div>
                            <h1>密码由6-16个字符组成，区分大小写(推荐用字母数字组合，不能包含空格)</h1>
                        </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>确认新密码:</span><div class="setting_r">
                            <div>
                                <asp:TextBox ID="txtPassAgain" runat="server" TextMode="Password" CssClass="setting_input" Width="208px"></asp:TextBox>
                            </div>
                        </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>验证码:</span><div class="setting_r">
                            <div>
                                <asp:TextBox ID="txtValid" runat="server" TextMode="Password" CssClass="setting_input" Width="208px"></asp:TextBox>
                            </div>
                            <h1>请输入图中字符，不区分大小写<br />
                                <img id="imgVerify" width="133" height="53" style="cursor: pointer;" src="~/ControlLibrary/VerifyCode.aspx?"
                                    alt="看不清？点击更换" onclick="this.src=this.src+'?'" />
                                <a href="javascript:void(0);" onclick="javascript:document.getElementById('imgVerify').src=document.getElementById('imgVerify').src+'?'" title="看不清？点击更换" class="alink_01">看不清？点击更换</a>
                            </h1>
                        </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>&nbsp;</span>
                            <div class="setting_r">
                                <asp:Button ID="Button5" runat="server" CssClass="setting_button1" OnClick="Button5_Click" Text="确认" />
                                <asp:Button ID="Button6" runat="server" CssClass="setting_button2" OnClick="Button2_Click" Text="取消" />
                            </div>
                            <div class="clear"></div>
                        </li>
                    </ul>
                </div>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <div class="mr_left_name">星盘设置</div>

                <div class="setting_box">
                    <ul class="setting_ul1">
                        <li><span>相位容许度:</span>
                            <div class="setting_r">
                                <div class="setting_select1">
                                    <div class="setting_select_s">
                                        <select class="select_item">
                                            <option value="A" selected>合</option>
                                            <option value="B">2001</option>
                                            <option value="C">2002</option>
                                            <option value="D">2003</option>
                                            <option value="E">2003</option>
                                            <option value="F">2003</option>
                                            <option value="G">2003</option>
                                            <option value="H">2003</option>
                                            <option value="I">2003</option>
                                            <option value="J">2003</option>
                                        </select>
                                    </div>
                                    <div class="setting_select_font">合相0°</div>
                                </div>

                                <div class="setting_select1">
                                    <div class="setting_select_s">
                                        <select class="select_item">
                                            <option value="A" selected>冲相</option>
                                            <option value="B">2001</option>
                                            <option value="C">2002</option>
                                            <option value="D">2003</option>
                                            <option value="E">2003</option>
                                            <option value="F">2003</option>
                                            <option value="G">2003</option>
                                            <option value="H">2003</option>
                                            <option value="I">2003</option>
                                            <option value="J">2003</option>
                                        </select>
                                    </div>
                                    <div class="setting_select_font">冲相180°</div>
                                </div>


                                <div class="setting_select1">
                                    <div class="setting_select_s">
                                        <select class="select_item">
                                            <option value="A" selected>刑相</option>
                                            <option value="B">2001</option>
                                            <option value="C">2002</option>
                                            <option value="D">2003</option>
                                            <option value="E">2003</option>
                                            <option value="F">2003</option>
                                            <option value="G">2003</option>
                                            <option value="H">2003</option>
                                            <option value="I">2003</option>
                                            <option value="J">2003</option>
                                        </select>
                                    </div>
                                    <div class="setting_select_font">刑相90°</div>
                                </div>


                                <div class="setting_select1">
                                    <div class="setting_select_s">
                                        <select class="select_item">
                                            <option value="A" selected>三合</option>
                                            <option value="B">2001</option>
                                            <option value="C">2002</option>
                                            <option value="D">2003</option>
                                            <option value="E">2003</option>
                                            <option value="F">2003</option>
                                            <option value="G">2003</option>
                                            <option value="H">2003</option>
                                            <option value="I">2003</option>
                                            <option value="J">2003</option>
                                        </select>
                                    </div>
                                    <div class="setting_select_font">三合120°</div>
                                </div>


                                <div class="setting_select1">
                                    <div class="setting_select_s">
                                        <select class="select_item">
                                            <option value="A" selected>六合</option>
                                            <option value="B">2001</option>
                                            <option value="C">2002</option>
                                            <option value="D">2003</option>
                                            <option value="E">2003</option>
                                            <option value="F">2003</option>
                                            <option value="G">2003</option>
                                            <option value="H">2003</option>
                                            <option value="I">2003</option>
                                            <option value="J">2003</option>
                                        </select>
                                    </div>
                                    <div class="setting_select_font">六合60°</div>
                                </div>

                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>星体显示:</span>
                            <div class="setting_r">
                                <dd>
                                    <input type="checkbox" />太阳</dd>
                                <dd>
                                    <input type="checkbox" />月亮</dd>
                                <dd>
                                    <input type="checkbox" />水星</dd>
                                <dd>
                                    <input type="checkbox" />金星</dd>
                                <dd>
                                    <input type="checkbox" />火星</dd>
                                <dd>
                                    <input type="checkbox" />木星</dd>
                                <dd class="clear"></dd>
                                <dd>
                                    <input type="checkbox" />土星</dd>
                                <dd>
                                    <input type="checkbox" />天王星</dd>
                                <dd>
                                    <input type="checkbox" />海王星</dd>
                                <dd>
                                    <input type="checkbox" />冥王星</dd>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>小星体显示:</span>
                            <div class="setting_r">
                                <dd>
                                    <input type="checkbox" />凯龙星</dd>
                                <dd>
                                    <input type="checkbox" />婚神星</dd>
                                <dd>
                                    <input type="checkbox" />智神星</dd>
                                <dd>
                                    <input type="checkbox" />谷神星</dd>
                                <dd>
                                    <input type="checkbox" />杜神星</dd>
                                <dd>
                                    <input type="checkbox" />北交点</dd>
                                <dd class="clear"></dd>
                                <dd>
                                    <input type="checkbox" />南交点</dd>
                                <dd>
                                    <input type="checkbox" />莉莉丝</dd>
                                <dd>
                                    <input type="checkbox" />福点</dd>
                                <dd>
                                    <input type="checkbox" />宿命点</dd>
                                <dd>
                                    <input type="checkbox" />东升点</dd>
                            </div>
                            <div class="clear"></div>
                        </li>
                    </ul>
                </div>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <div class="mr_left_name">裁切头像照片</div>

                <div class="setting_box">
                    <ul class="setting_ul">
                        <li>您可以拖动照片以裁剪满意的头像</li>
                        <li>
                            <div id="Canvas" class="uploaddiv">
                                <div id="ImageDragContainer">
                                    <asp:Image ID="ImageDrag" runat="server" ImageUrl="~/image/blank.jpg" CssClass="imagePhoto" ToolTip="" />
                                </div>
                                <div id="IconContainer">
                                    <asp:Image ID="ImageIcon" runat="server" ImageUrl="~/image/blank.jpg" CssClass="imagePhoto" ToolTip="" />
                                </div>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li>
                            <div class="uploaddiv">
                                <table>
                                    <tr>
                                        <td id="Min">
                                            <img alt="缩小" src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/_c.gif" onmouseover="this.src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/_c.gif';" onmouseout="this.src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/_h.gif';" id="moresmall" class="smallbig" />
                                        </td>
                                        <td>
                                            <div id="bar">
                                                <div class="child">
                                                </div>
                                            </div>
                                        </td>
                                        <td id="Max">
                                            <img alt="放大" src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/c.gif" onmouseover="this.src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/c.gif';" onmouseout="this.src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/h.gif';" id="morebig" class="smallbig" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li><span>&nbsp;</span>
                            <div class="setting_r">
                                <asp:Button ID="Button7" runat="server" CssClass="setting_button1" OnClick="Button7_Click" Text="保存" />
                                <asp:Button ID="Button8" runat="server" CssClass="setting_button2" OnClick="Button2_Click" Text="取消" />
                            </div>
                            <div class="clear"></div>
                        </li>
                        <li style="display:none;">
                            <div>
                                图片实际宽度：
                                <asp:TextBox ID="txt_width" runat="server" Text="1"></asp:TextBox><br />
                                图片实际高度：
                                <asp:TextBox ID="txt_height" runat="server" Text="1"></asp:TextBox><br />
                                距离顶部：
                                <asp:TextBox ID="txt_top" runat="server" Text="82"></asp:TextBox><br />
                                距离左边：
                                <asp:TextBox ID="txt_left" runat="server" Text="73"></asp:TextBox><br />
                                截取框的宽：
                                <asp:TextBox ID="txt_DropWidth" runat="server" Text="180"></asp:TextBox><br />
                                截取框的高：
                                <asp:TextBox ID="txt_DropHeight" runat="server" Text="180"></asp:TextBox><br />
                                放大倍数：
                                <asp:TextBox ID="txt_Zoom" runat="server"></asp:TextBox>
                                <asp:HiddenField ID="hdfPicID" runat="server" />
                            </div>
                        </li>
                    </ul>
                </div>
            </asp:View>
        </asp:MultiView>
        <div class="clear"></div>
    </div>

    <div class="page_right" style="width: 242px">

        <div class="page_right_box">
            <div class="page_right_box_t">个人资料</div>
            <div class="mypage_otherperson_right">
                <div class="mypage_otherperson_s" style="border: 0">
                    <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=o&id=<%=m_user.Photo %>" />
                    <ul class="help_right_list">
                        <li><a href="UserInfo.aspx?id=<%=m_user.SysNo %>&tab=1">基本资料</a></li>
                        <li><a href="UserInfo.aspx?id=<%=m_user.SysNo %>&tab=0">修改头像</a></li>
                        <li><a href="UserInfo.aspx?id=<%=m_user.SysNo %>&tab=2">修改密码</a></li>
                        <%--<li><a href="UserInfo.aspx?tab=3">命盘默认设置</a></li>--%>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <script type="text/javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>js/jquery/jquery-ui-1.9.2.min.js"></script>
    <script type="text/javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>js/CutPic.js"></script>
</asp:Content>
