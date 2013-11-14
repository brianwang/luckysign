<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="RegisterSucc.aspx.cs" Inherits="WebForMain.Passport.RegisterSucc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SetTimeDown() {
            var tmp = document.getElementById("countdown").innerHTML;
            tmp--;
            if (tmp < 0)
            { window.window.location.href(document.getElementById("returl").innerHTML); }
            else {
                document.getElementById("countdown").innerHTML = tmp;
                setTimeout('SetTimeDown()', 1000);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <h2>欢迎加入上上签</h2>
        <div class="dbox">
            <div class="left dle">
                <div class="form_1">
                    <div style="line-height:20px;font-size:20px; color:gray; vertical-align:bottom">
<img src="../WebResources/Images/gou.png" width="35" height="35" style="vertical-align:bottom;" />&nbsp;<b>&nbsp;恭喜你！注册成功！</b>
                    </div>
                   <div style="margin-top:20px; font-size:14px;">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal></div>
                    <div style="line-height:24px;font-size:14px;"><a href="../Qin/View.aspx?id=<%=GetSession().CustomerEntity.SysNo %>" style="color:blue; text-decoration:underline;">我的首页</a><br />
                        <a href="../Qin/UserInfo.aspx?tab=0&id=<%=GetSession().CustomerEntity.SysNo %>" style="color:blue; text-decoration:underline;">上传我的头像</a><br /> 
                        <a href="../Qin/UserInfo.aspx?tab=1&id=<%=GetSession().CustomerEntity.SysNo %>" style="color:blue; text-decoration:underline;">完善个人资料</a><br /> 
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="left line_01">
            </div>
            <div class="left dri">
                <p></p>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bottom" runat="server">
</asp:Content>
