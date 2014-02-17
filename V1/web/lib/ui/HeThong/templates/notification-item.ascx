<%@ Control Language="C#" AutoEventWireup="true" CodeFile="notification-item.ascx.cs" Inherits="lib_ui_HeThong_templates_notification_item" %>
<%@ Import Namespace="linh.common" %>
<li>
    <a class="noti-item" href="<%=Item.Url %>">
        <span class="noti-item-user">
            <img class="noti-item-avatar" src="/lib/up/users/<%=Item.Member.Anh %>"/>                            
        </span>
        <span class="noti-item-body">
            <span class="noti-item-text">
                <%=Item.NoiDung %>
            </span>
            <span class="noti-item-date">
                <%=Lib.TimeDiff(Item.NgayTao) %>
            </span>
        </span>
    </a>
</li>