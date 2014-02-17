<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pmNotificationItem.ascx.cs" Inherits="lib_ui_pm_templates_pmNotificationItem" %>
<%@ Import Namespace="linh.common" %>
<li>
    <a class="noti-item" href="/pm/#<%=Item.PMR_ID %>">
        <span class="noti-item-user">
            <img class="noti-item-avatar" src="/lib/up/users/<%=Item.NguoiGuiMember.Anh %>"/>                            
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