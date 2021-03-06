﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForAdmin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>登录-上上签后台管理系统</title>
        <!--                       CSS                       -->
        <!-- Reset Stylesheet -->
        <link rel="stylesheet" href="WebResources/css/reset.css" type="text/css" media="screen" />
        <!-- Main Stylesheet -->
        <link rel="stylesheet" href="WebResources/css/style.css" type="text/css" media="screen" />
        <!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
        <link rel="stylesheet" href="WebResources/css/invalid.css" type="text/css" media="screen" />
        <!-- Colour Schemes
	  
		Default colour scheme is green. Uncomment prefered stylesheet to use it.
		
		<link rel="stylesheet" href="WebResources/css/blue.css" type="text/css" media="screen" />
		
		<link rel="stylesheet" href="WebResources/css/red.css" type="text/css" media="screen" />  
	 
		-->
        <!-- Internet Explorer Fixes Stylesheet -->
        <!--[if lte IE 7]>
			<link rel="stylesheet" href="WebResources/css/ie.css" type="text/css" media="screen" />
		<![endif]-->
        <!--                       Javascripts                       -->
        <!-- jQuery -->

        <script type="text/javascript" src="WebResources/scripts/jquery-1.3.2.min.js"></script>

        <!-- jQuery Configuration -->

        <script type="text/javascript" src="WebResources/scripts/simpla.jquery.configuration.js"></script>

        <!-- Facebox jQuery Plugin -->

        <script type="text/javascript" src="WebResources/scripts/facebox.js"></script>

        <!-- jQuery WYSIWYG Plugin -->

        <script type="text/javascript" src="WebResources/scripts/jquery.wysiwyg.js"></script>

        <!-- Internet Explorer .png-fix -->
        <!--[if IE 6]>
			<script type="text/javascript" src="WebResources/scripts/DD_belatedPNG_0.0.7a.js"></script>
			<script type="text/javascript">
				DD_belatedPNG.fix('.png_bg, img, li');
			</script>
		<![endif]-->
</head>
<body id="login">
    <form id="form1" runat="server">
    <div id="login-wrapper" class="png_bg">
        <div id="login-top">
            <h1>
                上上签后台管理系统</h1>
            <!-- Logo (221px width) -->
            <img id="logo" src="WebResources/images/logo.png" alt="上上签" />
        </div>
        <!-- End #logn-top -->
        <div id="login-content">
            <div id="divNotice" runat="server" class="notification information png_bg" style="display:none;">
                <div>
                    <asp:Literal ID="ltrNotice" runat="server"></asp:Literal>
                </div>
            </div>
            <p>
                <label>
                    用户名</label>
                <asp:TextBox ID="txtUname" class="text-input" runat="server"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p>
                <label>
                    密码</label>
                <asp:TextBox ID="txtPass" class="text-input" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p id="remember-password">
                <asp:CheckBox ID="CheckBox1" runat="server" />记住我
            </p>
            <div class="clear">
            </div>
            <p>
                <asp:Button ID="Button1" class="button" runat="server" Text="登陆" 
                    onclick="Button1_Click" />
            </p>
        </div>
        <!-- End #login-content -->
    </div>
    <!-- End #login-wrapper -->
    </form>
</body>
</html>
