<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home-item.ascx.cs" Inherits="lib_ui_account_templates_home_item" %>
<div class="user-home-item">
    <a href="<%=Item.Url %>" class="user-home-item-avatar">
        <img src="/lib/up/users/<%=Item.Anh %>" class="user-home-item-img" alt="<%=Item.Ten %>"/>
    </a>
    <a href="<%=Item.Url %>" class="user-home-item-ten uname">
        <%=Item.Ten %>
    </a>
    <%if (!string.IsNullOrEmpty(Item.Tinh_Ten)){ %>
        <div class="user-home-item-city">
            <%=Item.Tinh_Ten %>
        </div>
    <%} %>
</div>