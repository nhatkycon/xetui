<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="lib_ui_HeThong_Header" %>
<%@ Import Namespace="docsoft" %>
<meta name="viewport" content="width=device-width, initial-scale=1.0,maximum-scale=1.0; user-scalable=no">
    <link href="/lib/css/web/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <link href="/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/lib/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="/lib/css/web/1.css" rel="stylesheet" type="text/css" />
    <script src="/lib/js/jqueryLib/jquery-1.10.2.min.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="/lib/favi.png" />
    <script src="//connect.facebook.net/en_US/all.js#xfbml=1&appId=372490826229164"></script>        
    <script>
        var src = '<%=Request.Url.PathAndQuery %>';
        var logged = <%=Security.IsAuthenticated().ToString().ToLower()%>;
        var admMode = false;
        var hideWelcome = <%=Security.IsAuthenticated().ToString().ToLower()%>;
        var iOs = /(iPhone|iPad|iPod)/.test(navigator.userAgent);
        
        var admKey = '';
        FB.init({
            appId: '372490826229164',
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });
    </script>
<%--<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="format-detection" content="telephone=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="apple-mobile-web-app-title" content="XETUI.VN" />
<meta name="SKYPE_TOOLBAR" content="SKYPE_TOOLBAR_PARSER_COMPATIBLE" />

<link rel="apple-touch-icon" href="/lib/css/web/i/touch-icon-iphone.png" />
<link rel="apple-touch-icon" sizes="72x72" href="/lib/css/web/i/touch-icon-ipad.png" />
<link rel="apple-touch-icon" sizes="114x114" href="/lib/css/web/i/touch-icon-iphone4.png" />
<link rel="apple-touch-startup-image" href="/lib/css/web/i/touch-icon-ipad.png" /><link rel="apple-touch-icon" href="/lib/css/web/i/touch-icon-iphone.png" />
<link rel="apple-touch-icon" sizes="72x72" href="/lib/css/web/i/touch-icon-ipad.png" />
<link rel="apple-touch-icon" sizes="114x114" href="/lib/css/web/i/touch-icon-iphone4.png" />
<link rel="apple-touch-startup-image" href="/lib/css/web/i/touch-icon-ipad.png" />
<link rel="shortcut icon" href="/lib/css/web/i/icon.png" />--%>
