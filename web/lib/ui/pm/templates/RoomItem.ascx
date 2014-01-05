<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoomItem.ascx.cs" Inherits="lib_ui_pm_templates_RoomItem" %>
<div data-id="<%=Item.ID %>" class="list-group-item PmRoom-Item">
    <a class="PmRoom-Item-User" href="/users/<%=Item.Member.Username%>/">
        <img class="PmRoom-Item-Avatar" src="/lib/up/users/<%=Item.Member.Anh %>"/>
    </a>
    <div class="PmRoom-Item-Body">
        <%=Item.Member.Ten %>
    </div>
</div>