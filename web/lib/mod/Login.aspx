<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="lib_mod_Login" %>
<%@ Register Src="~/lib/ui/HeThong/AdmLogin.ascx" TagPrefix="uc1" TagName="AdmLogin" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <link href="/lib/css/web/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <link href="/lib/css/web/adm.css" rel="stylesheet" />
    <link href="/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:AdmLogin runat="server" ID="AdmLogin" />
    </form>
</body>
</html>
