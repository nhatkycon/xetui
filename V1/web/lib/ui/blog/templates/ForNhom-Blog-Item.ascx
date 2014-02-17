<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForNhom-Blog-Item.ascx.cs" Inherits="lib_ui_blog_templates_ForNhom_Blog_Item" %>
<%@ Import Namespace="linh.common" %>
<div class="blogNhom-item">
    <a href="<%=Item.Url %>" class="blogNhom-item-title">
        <%=Item.Ten %>
    </a>
    <a href="<%=Item.GetNguoiTao().Url %>" class="blogNhom-item-user"><%=Item.GetNguoiTao().Ten %></a>
    <span class="blogNhom-item-date" title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>">
        <%=Lib.TimeDiff(Item.NgayTao) %>
    </span>
</div>