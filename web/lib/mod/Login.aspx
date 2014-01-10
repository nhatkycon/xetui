<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="lib_mod_Login" %>
<%@ Register Src="~/lib/ui/HeThong/AdmLogin.ascx" TagPrefix="uc1" TagName="AdmLogin" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:AdmLogin runat="server" ID="AdmLogin" />
    </form>
</body>
</html>
