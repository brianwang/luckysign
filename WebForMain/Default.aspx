<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebForMain.Default" %>

<%@ Register Src="ControlLibrary/ShowAdv.ascx" TagName="ShowAdv" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>上上签算命咨询网_让命理科技化_让算命人性化_专业排盘_大师亲测</title>
    <meta name="keywords" content="上上签_占星术_占星骰子_紫薇斗数_四柱八字_塔罗牌_在线排盘_星座运势_命理咨询_大师专业解盘_名人案例库_算命_命盘" />
    <meta name="description" content="上上签算命咨询网提供专业的排盘，在线算命咨询服务，这里还有海量的命理学习资料和名人命盘案例库，致力于用科技的手段服务于命理研究和在线咨询。" />

    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>CSS/new.css" rel="stylesheet" type="text/css" />
    <link href="<%=AppCmn.AppConfig.WebResourcesPath() %>CSS/page.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <!--banner-->
        <uc1:ShowAdv ID="AdvTopMid" runat="server" advfrom="IndexFlash.htm" EnableViewState="true" />
        <!--注册-->
        <div class="index_login">
            <div class="index_login_box">
                <ul>
                    <li><span>Email：</span><asp:TextBox ID="txtEmail" runat="server" CssClass="index_login_input1"></asp:TextBox></li>
                    <li><span>密&nbsp;&nbsp;码：</span><asp:TextBox ID="txtPass" runat="server" CssClass="index_login_input1"
                        TextMode="Password"></asp:TextBox></li>
                    <li class="pad">
                        <asp:CheckBox ID="chkRemember" runat="server" Text="记住我" /><a target="_blank" href="PassPort/FindPass.aspx">忘记密码?</a></li>
                    <li class="pad">
                        <asp:Button runat="server" Text="登录" CssClass="login_button" OnClick="Unnamed2_Click" /><asp:Button runat="server" CssClass="login_button" Style="margin-right: 0px" OnClick="Unnamed_Click" Text="立即注册" />
                    </li>
                </ul>

                <div class="clear">
                </div>
            </div>
            
            <div class="index_search_box" style="margin-top:13px;">
                <div class="index_right_list2">
                    <ul>
                        <li style="padding:3px 9px 0px; border-bottom:none"><a href="PPLive/Astro.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_zhanxing.jpg" height="58" width="58" alt="西洋占星术排盘" />占星排盘</a></li>
                        <li style="padding:3px 9px 0px; border-bottom:none"><a href="PPLive/ZiWei.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_ziwei.jpg" height="58" width="58" alt="紫薇斗数排盘" />紫斗排盘</a></li>
                        <li style="padding:3px 9px 0px; border-bottom:none"><a href="PPLive/BaZi.aspx">
                            <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_bazi.jpg" height="58" width="58" alt="四柱八字排盘" />八字排盘</a></li>
                    </ul>
                    <%--<a href="#">塔罗在线牌阵</a>--%>
                    <div class="clear">
                    </div>
                </div>
                <!--搜索-->
                <%--<asp:TextBox runat="server" ID="txtSearch" value="寻找你感兴趣的内容" onblur="if (this.value==''){ this.value='寻找你感兴趣的内容';this.style.color='#9C9C9C';}else{this.style.color='#333';}"
                    onfocus="if (this.value=='寻找你感兴趣的内容') {this.value='';this.style.color='#333';}"></asp:TextBox>
                <asp:Button runat="server" Text="GO" />--%>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="index_left">

            <div style="margin-top: 20px; height: 60px;">
                <ul>
                    <li style="width: 158px; height: 56px; float: left;"><a href="PPLive/Astro.aspx">
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_paipan_normal.jpg" onmouseover="this.src='WebResources/IMAGES/icon_paipan_up.jpg';" onmouseout="this.src='WebResources/IMAGES/icon_paipan_normal.jpg';" width="158px" height="56px" /></a></li>
                    <li style="width: 158px; height: 56px; float: left; margin-left: 14px;"><a href="Quest/Ask">
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_qiuce_normal.jpg" onmouseover="this.src='WebResources/IMAGES/icon_qiuce_up.jpg';" onmouseout="this.src='WebResources/IMAGES/icon_qiuce_normal.jpg';" width="158px" height="56px" /></a></li>
                    <li style="width: 158px; height: 56px; float: left; margin-left: 14px;"><a href="Article">
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_study_normal.jpg" onmouseover="this.src='WebResources/IMAGES/icon_study_up.jpg';" onmouseout="this.src='WebResources/IMAGES/icon_study_normal.jpg';" width="158px" height="56px" /></a></li>
                    <li style="width: 158px; height: 56px; float: left; margin-left: 14px;"><a href="Celebrity">
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>IMAGES/icon_yanjiu_normal.jpg" onmouseover="this.src='WebResources/IMAGES/icon_yanjiu_up.jpg';" onmouseout="this.src='WebResources/IMAGES/icon_yanjiu_normal.jpg';" width="158px" height="56px" /></a></li>
                </ul>
            </div>


            <!--煮酒论命-->
            <div class="index_left_box" style="margin-top:10px">

                <div class="index_left_new_t">
                    <div class="index_left_new_item"><span class="on" style="cursor: pointer;">求测解惑</span><span style="cursor: pointer;">学习研究</span></div>
                    煮酒论命
                </div>

                <div class="index_left_new_list block show">
                    <div class="new_list_ul" style="width: 325px">
                        <div class="new_list_ul_t" style="background: url(<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/new_ico1.gif) no-repeat 0px 10px">咨询榜</div>
                        <ul>
                            <asp:Repeater ID="rptCeNew" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <h2>
                                            <a href="Qin/View.aspx?id=<%# Eval("LastReplyUser")%>">
                                                <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("ReplyPhoto")%>" /></a></h2>
                                        <h1><a href="Quest/Question/<%# Eval("SysNo")%>"><%# Eval("Title")%></a><img id='cenew<%# Eval("IsHot")%>' src="WebResources/img/page/new_ico4.gif" align="absmiddle" /></h1>
                                        <div class="clear"></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="new_list_ul" style="width: 290px">
                        <div class="new_list_ul_t" style="background: url(<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/new_ico2.gif) no-repeat 0px 10px">等你解答</div>
                        <ul>
                            <asp:Repeater ID="tprCeHot" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <h1><a href="Quest/Question/<%# Eval("SysNo")%>"><%# Eval("Title")%></a><img id='cehot<%# Eval("IsNew")%>' src="WebResources/img/page/new_ico3.gif" align="absmiddle" /></h1>
                                        <div class="clear"></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="index_left_new_list block">
                    <div class="new_list_ul" style="width: 325px">
                        <div class="new_list_ul_t" style="background: url(<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/new_ico1.gif) no-repeat 0px 10px">咨询榜</div>
                        <ul>
                            <asp:Repeater ID="rptStudyNew" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <h2>
                                            <a href="Qin/View.aspx?id=<%# Eval("LastReplyUser")%>">
                                                <img src="<%=AppCmn.AppConfig.HomeUrl() %>ControlLibrary/ShowPhoto.aspx?type=t&id=<%#Eval("ReplyPhoto")%>" /></a></h2>
                                        <h1><a href="Quest/Question/<%# Eval("SysNo")%>"><%# Eval("Title")%></a><img id='studynew<%# Eval("IsHot")%>' src="WebResources/img/page/new_ico4.gif" align="absmiddle" /></h1>
                                        <div class="clear"></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="new_list_ul" style="width: 290px">
                        <div class="new_list_ul_t" style="background: url(<%=AppCmn.AppConfig.WebResourcesPath() %>img/page/new_ico2.gif) no-repeat 0px 10px">等你解答</div>
                        <ul>
                            <asp:Repeater ID="rptStudyHot" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <h1><a href="Quest/Question/<%# Eval("SysNo")%>"><%# Eval("Title")%></a><img id='studyhot<%# Eval("IsNew")%>' src="WebResources/img/page/new_ico3.gif" align="absmiddle" /></h1>
                                        <div class="clear"></div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="index_left_new_btn"><a href="Quest">+more</a></div>
            </div>
            <!--群组-->
            <%--<div class="index_left_box" style="margin-top: 19px">
                <div class="index_left_box_t">
                    群组</div>
                <div class="index_left_list2">
                    <ul>
                        <asp:Repeater runat="server" ID="rptGroup">
                            <ItemTemplate>
                                <li>
                                    <div class="index_list2_pic">
                                        <img src="WebResources/img/index_pic2.jpg" /></div>
                                    <div class="index_list2_info">
                                        <a href="#">我靠同学的小豆芽</a>
                                        <h1>
                                            12980 人喜欢</h1>
                                        迪士尼电影豆瓣官网小站。最新最新最站。最新欧美流行音乐资讯欧美流行音...
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
            </div>--%>
            <!--象牙塔-->
            <div class="index_left_box" style="margin-top:35px;">
                <div class="index_left_new_t">
                    <div class="index_left_new_item">
                        <asp:Repeater runat="server" ID="rptCMSCate">
                            <ItemTemplate>
                                <span class="<%#Eval("on")%>" style="cursor: pointer;"><%#Eval("Name")%></span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    象牙塔
                </div>

                <asp:Repeater runat="server" ID="rptCateArticle" OnItemDataBound="rptCMSCate_ItemDataBound">
                    <ItemTemplate>
                        <div class="index_left_new_list block <%#Eval("show")%>">
                            <div class="new_list_ul" style="width: 325px">
                                <div class="new_list_ul_t">&nbsp;</div>
                                <ul>
                                    <asp:Repeater runat="server" ID="rptArticle">
                                        <ItemTemplate>
                                            <li>
                                                <h2>&nbsp;</h2>
                                                <h1><a href='Article/Content/<%# Eval("SysNo")%>'><%# Eval("Title")%></a><img id='studyhot<%# Eval("IsHot")%>' src="WebResources/img/page/new_ico4.gif" align="absmiddle" /></h1>
                                                <div class="clear"></div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="new_list_ul" style="width: 290px">
                                <div class="new_list_ul_t">&nbsp;</div>
                                <ul>
                                    <asp:Repeater runat="server" ID="rptArticle1">
                                        <ItemTemplate>
                                            <li>
                                                <h1><a href='Article/Content/<%# Eval("SysNo")%>'><%# Eval("Title")%></a><img id='studyhot<%# Eval("IsHot")%>' src="WebResources/img/page/new_ico4.gif" align="absmiddle" /></h1>
                                                <div class="clear"></div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="index_left_new_btn"><a href="Quest">+more</a></div>
            </div>
        </div>
        <div class="index_right">
            <!--在线测算-->
            <div class="index_right_box">
                <div class="index_right_box_t">
                    在线测算
                </div>
                <div class="index_right_list1">
                    <uc1:ShowAdv ID="AdvRightMid" runat="server" advfrom="IndexCeOl.htm" EnableViewState="true" />
                </div>

            </div>
            <!--名人库-->
            <div class="index_right_box">
                <div class="index_right_box_t">
                    名人库
                </div>
                <div class="index_right_list2">
                    <ul>
                        <asp:Repeater runat="server" ID="rptFamous">
                            <ItemTemplate>
                                <li><a href="Celebrity/Detail/<%#Server.UrlDecode(AppCmn.CommonTools.Encode(Eval("SysNo").ToString())) %>">
                                    <img src="<%#Eval("photo") %>" height="60" width="60" alt="<%#Eval("Name") %>命盘" /><%#Eval("Name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <div class="index_right_a2">
                    <asp:Repeater runat="server" ID="rptKeys">
                        <ItemTemplate>
                            <a href="Celebrity/<%#Eval("SysNo") %>" class="c<%# Container.ItemIndex + 1 %>"><span></span><%#Eval("KeyWords") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>
    <script type="text/javascript">

        /*首页广告效果*/
        $(function () {
            var len = $(".num li").length;
            var index = 0;
            var adTimer;
            $(".num li").mouseover(function () {
                index = $(".num li").index(this);
                showImg(index);
            }).eq(0).mouseover();
            //滑入 停止动画，滑出开始动画.
            $('.banner_img').hover(function () {
                clearInterval(adTimer);
            }, function () {
                adTimer = setInterval(function () {
                    showImg(index)
                    index++;
                    if (index == len) { index = 0; }
                }, 5000);
            }).trigger("mouseleave");
        })
        // 通过控制top ，来显示不同的幻灯片
        function showImg(index) {
            var adHeight = $(".banner_img").height();
            $(".slider").stop(true, false).animate({ bottom: -adHeight * index }, 1000);
            $(".num li").removeClass("on")
                .eq(index).addClass("on");
        }
</script>
</asp:Content>
