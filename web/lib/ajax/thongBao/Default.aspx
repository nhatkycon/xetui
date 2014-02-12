<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_thongBao_Default" %>
<%@ Register Src="~/lib/ui/HeThong/notificationList.ascx" TagPrefix="heThong" TagName="notificationList" %>
<%@ Register Src="~/lib/ui/pm/pmNotificationList.ascx" TagPrefix="heThong" TagName="pmNotificationList" %>
<heThong:notificationList runat="server" id="notificationList" Visible="False" />
<heThong:pmNotificationList runat="server" ID="pmNotificationList" Visible="False" />
