<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PmItem.ascx.cs" Inherits="lib_ui_pm_templates_PmItem" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="pm-item <%=Item.NguoiGui != Security.Username ? "pm-item-own" : "" %>">
    <a class="pm-item-user" href="/users/<%=Item.NguoiGui %>">
        <img src="/lib/up/users/<%=Item.NguoiGuiMember.Anh %>" class="pm-item-avatar"/>
    </a>
    <div class="pm-item-body">
        <div class="pm-item-text">
            <%=Item.NoiDung %>
        </div>
        <div class="pm-item-date">
            <%=Lib.TimeDiff(Item.NgayTao) %>
        </div>
    </div>
</div>