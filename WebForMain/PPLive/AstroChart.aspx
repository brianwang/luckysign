<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="AstroChart.aspx.cs" Inherits="WebForMain.PPLive.AstroChart" %>

<%@ Register Src="~/ControlLibrary/PPPanel.ascx" TagName="RightPanel" TagPrefix="uc1" %>
<%@ PreviousPageType VirtualPath="~/PPLive/Astro.aspx" %>
<%@ Register Src="~/ControlLibrary/AstroForQuest.ascx" TagName="Astro" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>西洋占星术星盘排盘-在线排盘-上上签</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="index_left">
            <!--煮酒论命-->
            <div class="index_left_box">
                <div class="index_left_new_t">
                    <span style="font-size: 16px; color: #A4534B">西洋占星术排盘</span>
                </div>
                <div class="index_left_new_list"  style="padding:18px;">
                <uc1:Astro ID="Astro1" runat="server"></uc1:Astro>
                    </div>
                <%--<div>
                    <asp:Image ID="imgChart" runat="server" Height="480" Width="640" /></div>
                    <div>图片地址：<asp:TextBox ID="txtUrl" runat="server" Width="600" onclick="select();"></asp:TextBox>
                    <a href="#" onclick="javascript:window.clipboardData.setData('text','<%=picurl %>');alert('图片地址已经复制到剪贴板中');" class="btn_03">复制地址</a></div>--%>
                <div class="paipan_t">行星的位置</div>

                <div class="paipan_box">
                    <div class="paipan_box_l">
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[0].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[0].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[0].Constellation) %> <%=m_astro.Stars[0].Degree %>度<%=m_astro.Stars[0].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[0].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[0].Constellation) %>">查看</a>；第<%=m_astro.Stars[0].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[0].StarName) %> <%=m_astro.Stars[0].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[1].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[1].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[1].Constellation) %> <%=m_astro.Stars[1].Degree %>度<%=m_astro.Stars[0].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[1].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[1].Constellation) %>">查看</a>；第<%=m_astro.Stars[1].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[1].StarName) %> <%=m_astro.Stars[1].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[2].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[2].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[2].Constellation) %> <%=m_astro.Stars[2].Degree %>度<%=m_astro.Stars[0].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[2].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[2].Constellation) %>">查看</a>；第<%=m_astro.Stars[2].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[2].StarName) %> <%=m_astro.Stars[2].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[3].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[3].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[3].Constellation) %> <%=m_astro.Stars[3].Degree %>度<%=m_astro.Stars[0].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[3].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[3].Constellation) %>">查看</a>；第<%=m_astro.Stars[3].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[3].StarName) %> <%=m_astro.Stars[3].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[4].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[4].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[4].Constellation) %> <%=m_astro.Stars[4].Degree %>度<%=m_astro.Stars[0].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[4].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[4].Constellation) %>">查看</a>；第<%=m_astro.Stars[4].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[4].StarName) %> <%=m_astro.Stars[4].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[20].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[20].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[20].Constellation) %> <%=m_astro.Stars[20].Degree %>度<%=m_astro.Stars[20].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[20].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[20].Constellation) %>">查看</a>；
                    </div>

                    <div class="paipan_box_l">
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[5].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[5].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[5].Constellation) %> <%=m_astro.Stars[5].Degree %>度<%=m_astro.Stars[5].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[5].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[5].Constellation) %>">查看</a>；第<%=m_astro.Stars[5].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[5].StarName) %> <%=m_astro.Stars[5].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[6].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[6].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[6].Constellation) %> <%=m_astro.Stars[6].Degree %>度<%=m_astro.Stars[6].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[6].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[6].Constellation) %>">查看</a>；第<%=m_astro.Stars[6].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[6].StarName) %> <%=m_astro.Stars[6].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[7].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[7].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[7].Constellation) %> <%=m_astro.Stars[7].Degree %>度<%=m_astro.Stars[7].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[7].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[7].Constellation) %>">查看</a>；第<%=m_astro.Stars[7].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[7].StarName) %> <%=m_astro.Stars[7].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[8].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[8].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[8].Constellation) %> <%=m_astro.Stars[8].Degree %>度<%=m_astro.Stars[8].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[8].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[8].Constellation) %>">查看</a>；第<%=m_astro.Stars[8].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[8].StarName) %> <%=m_astro.Stars[8].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[9].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[9].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[9].Constellation) %> <%=m_astro.Stars[9].Degree %>度<%=m_astro.Stars[9].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[9].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[9].Constellation) %>">查看</a>；第<%=m_astro.Stars[9].Gong %>宫<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[9].StarName) %> <%=m_astro.Stars[9].Gong %>宫">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[29].StarName %>.jpg" /><%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[29].StarName) %>落在 <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[29].Constellation) %> <%=m_astro.Stars[29].Degree %>度<%=m_astro.Stars[29].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[29].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[29].Constellation) %>">查看</a>；
                    </div>

                    <div class="clear"></div>

                </div>

                <div class="paipan_t">各宫的位置</div>

                <div class="paipan_box">
                    <div class="paipan_box_l">
                        第1宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[20].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[20].Constellation) %> <%=m_astro.Stars[20].Degree %>度<%=m_astro.Stars[20].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[20].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[20].Constellation) %>">查看</a><br />
                        第2宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[21].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[21].Constellation) %> <%=m_astro.Stars[21].Degree %>度<%=m_astro.Stars[21].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[21].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[21].Constellation) %>">查看</a><br />
                        第3宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[22].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[22].Constellation) %> <%=m_astro.Stars[22].Degree %>度<%=m_astro.Stars[22].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[22].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[22].Constellation) %>">查看</a><br />
                        第4宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[23].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[23].Constellation) %> <%=m_astro.Stars[23].Degree %>度<%=m_astro.Stars[23].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[23].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[23].Constellation) %>">查看</a><br />
                        第5宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[24].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[24].Constellation) %> <%=m_astro.Stars[24].Degree %>度<%=m_astro.Stars[24].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[24].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[24].Constellation) %>">查看</a><br />
                        第6宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[25].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[25].Constellation) %> <%=m_astro.Stars[25].Degree %>度<%=m_astro.Stars[25].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[25].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[25].Constellation) %>">查看</a><br />
                    </div>

                    <div class="paipan_box_l">
                        第7宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[26].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[26].Constellation) %> <%=m_astro.Stars[26].Degree %>度<%=m_astro.Stars[26].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[26].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[26].Constellation) %>">查看</a><br />
                        第8宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[27].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[27].Constellation) %> <%=m_astro.Stars[27].Degree %>度<%=m_astro.Stars[27].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[27].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[27].Constellation) %>">查看</a><br />
                        第9宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[28].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[28].Constellation) %> <%=m_astro.Stars[28].Degree %>度<%=m_astro.Stars[28].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[28].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[28].Constellation) %>">查看</a><br />
                        第10宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[29].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[29].Constellation) %> <%=m_astro.Stars[29].Degree %>度<%=m_astro.Stars[29].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[29].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[29].Constellation) %>">查看</a><br />
                        第11宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[30].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[30].Constellation) %> <%=m_astro.Stars[30].Degree %>度<%=m_astro.Stars[30].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[30].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[30].Constellation) %>">查看</a><br />
                        第12宫   在<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/<%=m_astro.Stars[31].Constellation %>.jpg" />
                        <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[31].Constellation) %> <%=m_astro.Stars[31].Degree %>度<%=m_astro.Stars[31].Cent.ToString("00") %>分<a target="_blank" href="http://www.ssqian.com/Article/Index.aspx?key=<%=PPLive.PublicValue.GetAstroStar(m_astro.Stars[31].StarName) %> <%=PPLive.PublicValue.GetConstellation(m_astro.Stars[31].Constellation) %>">查看</a><br />
                    </div>

                    <div class="clear"></div>

                </div>


                <%--<div class="paipan_t">行星的主要相位</div>

                <div class="paipan_box">
                    <div class="paipan_box_l" style="width: 200px">

                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳拱木星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/muxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳拱土星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/tuxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳六合中天<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/tuxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮六合水星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/shuixing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮六合火星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/huoxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮合海王星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/haiwangxing.jpg" /><a href="#">查看</a><br />
                    </div>

                    <div class="paipan_box_l" style="width: 200px">

                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳拱木星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/muxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳拱土星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/tuxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳六合中天<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/tuxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮六合水星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/shuixing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮六合火星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/huoxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮合海王星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/haiwangxing.jpg" /><a href="#">查看</a><br />
                    </div>

                    <div class="paipan_box_l" style="width: 200px">

                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳拱木星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/muxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳拱土星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/tuxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/taiyang.jpg" />太阳六合中天<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/tuxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮六合水星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/shuixing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮六合火星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/huoxing.jpg" /><a href="#">查看</a><br />
                        <img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/yueliang.jpg" />月亮合海王星<img src="<%=AppCmn.AppConfig.WebResourcesPath() %>img/paipan/haiwangxing.jpg" /><a href="#">查看</a><br />
                    </div>

                    <div class="clear"></div>

                </div>--%>
            </div>





        </div>
        <div class="index_right">
            <uc1:RightPanel ID="Panel1" runat="server"></uc1:RightPanel>
            <div class="paipan_right_box1">
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        与你<%#Eval("Value")%>相同度数的名人有：<br />
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate><a target="_blank" href="../Celebrity/Detail.aspx?id=<%#AppCmn.CommonTools.Encode(Eval("SysNo").ToString())%>"><%#Eval("name")%></a>&nbsp;</ItemTemplate>
                        </asp:Repeater>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>


            <div class="paipan_right_box2">
                <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                    <ItemTemplate>
                        <%#Eval("starname")%>也在<%#Eval("gong")%>宫的名人有：<br />
                        <asp:Repeater ID="Repeater4" runat="server">
                            <ItemTemplate><a target="_blank" href="../Celebrity/Detail.aspx?id=<%#AppCmn.CommonTools.Encode(Eval("SysNo").ToString())%>"><%#Eval("name")%></a>&nbsp;</ItemTemplate>
                        </asp:Repeater>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>


            <%--<div class="paipan_right_box3">
                与你太阳相同度数的名人有：<br />
                <a href="#">Whitney Young</a>，<a href="#">Deval Patrick</a><br />
                与你月亮相同度数的名人有：<br />
                <a href="#">France Nuyen</a>，<a href="#">Mike Bielecki</a><br />
                与你水星相同度数的名人有：<br />
                <a href="#">Mike Bielecki </a>
                <br />
                与你金星相同度数的名人有：<br />
                <a href="#">黎明</a>，<a href="#">郭富城</a><br />
                与你火星相同度数的名人有：<br />
                <a href="#">玛丽莲梦露</a>，<a href="#">小燕子</a>
            </div>--%>
        </div>


        <div class="clear"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
    <%--<script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/addition.js" type="text/javascript"></script>--%>
    <script language="javascript" src="<%=AppCmn.AppConfig.WebResourcesPath() %>JS/comm.js" type="text/javascript"></script>

</asp:Content>
