<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Small.ascx.cs" Inherits="lib_ui_blog_NhomBlog_templates_Item_Small" %>
<%@ Import Namespace="linh.common" %>
<div class="blogNhom-item">
    <a href="<%=Item.Url %>" class="blogNhom-item-title">
        <%=Item.Ten %>
    </a>
    <a href="<%=Item.MemberNguoiTao.Url %>" class="blogNhom-item-user"><%=Item.MemberNguoiTao.Ten %></a>
    <span class="blogNhom-item-date" title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>">
        <%=Lib.TimeDiff(Item.NgayTao) %>
    </span>
</div>