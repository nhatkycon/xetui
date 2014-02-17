<%@ Control Language="C#" AutoEventWireup="true" CodeFile="notificationList.ascx.cs" Inherits="lib_ui_HeThong_notificationList" %>
<%@ Register Src="~/lib/ui/HeThong/templates/notification-item.ascx" TagPrefix="heThong" TagName="notificationitem" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <heThong:notificationitem runat="server" id="notificationitem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>
