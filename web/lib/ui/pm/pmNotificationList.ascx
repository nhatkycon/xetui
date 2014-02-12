<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pmNotificationList.ascx.cs" Inherits="lib_ui_pm_pmNotificationList" %>
<%@ Register Src="~/lib/ui/pm/templates/pmNotificationItem.ascx" TagPrefix="heThong" TagName="pmNotificationItem" %>

<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <heThong:pmNotificationItem runat="server" ID="pmNotificationItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>