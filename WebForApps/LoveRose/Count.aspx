<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Count.aspx.cs" Inherits="WebForApps.LoveRose.Count" %>

<%@ Register Src="../ControlLibrary/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<%@ Register Src="../ControlLibrary/DistrictPicker.ascx" TagName="District" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>爱情花</title>
    <link href="../WebResources/Images/LoveRose/css/login.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../WebResources/Images/LoveRose/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../WebResources/Images/LoveRose/js/jquery.pngFix.pack.js"></script>
    <script type="text/javascript" src="../WebResources/Images/LoveRose/js/default.js"></script>
    
    
    <link href="../WebResources/Images/LoveRose/css/common.css" type="text/css" rel="stylesheet" />
</head>
<body style="">
    <form id="form1" runat="server">
        <uc1:DatePicker ID="DatePicker1" runat="server" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <asp:Literal ID="Label1" runat="server"></asp:Literal>
              
        
    </form>
</body>
</html>
