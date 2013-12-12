<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QinRightPannel.ascx.cs" Inherits="WebForMain.ControlLibrary.QinRightPannel" %>
<div class="page_right_box_t">个人信息</div>
            <div class="mypage_otherperson_right">
                <div class="mypage_otherperson_s">
                    活跃等级：<span><%=m_grade.Name %></span><br />
                    <%=ltr_me %>的灵签：<span><%=m_user.Point %></span><br />
                    上上签币：<span><%=m_user.Credit %></span><br />
                    提问数：<span><%=m_user.TotalQuest %></span><br />
                    反馈数：<span><%=m_user.TotalReply %></span><br />
                    解答问题数：<span><%=m_user.TotalAnswer %></span><br />
                    被采纳数：<span><%=m_user.BestAnswer %></span>
                </div>

                <div class="mypage_otherperson_s">
                    <%=ltr_me %>的勋章：<br />
                    <div class="page_otherperson_item" style="background: none; height: inherit; padding-left: 0px; margin-top:5px">
                        <ul>
                            <asp:Repeater ID="rptIcon" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img src='<%=AppCmn.AppConfig.WebResourcesPath() %>img/Medal/<%#Eval("MedalSysNo")%>.gif' width="22" height="23" alt="<%#Eval("MedalName")%>"  /></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>

                <div class="mypage_otherperson_s" style="border: 0">
                    注册时间：<%=m_user.RegTime.ToString("yyyy年MM月dd日") %><br />
                    上次访问：<%=m_user.LastLoginTime.ToString("yyyy年MM月dd日") %>
                    <%-- <div class="page_guanzhu_button">
                                <a href="#" class="gz2">绑定微博</a>
                            </div>
                    <div class="clear"></div>
                    <div class="mypage_ico">
                        <a href="#" class="weibo1">
                            <img src="WebResources/img/page/sina.gif" /></a>
                        <a href="#" class="weibo1">
                            <img src="WebResources/img/page/qq.gif" /></a>
                    </div>--%>
                    <div class="clear"></div>
                </div>

            </div>