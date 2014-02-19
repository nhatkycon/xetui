<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Admin.ascx.cs" Inherits="lib_ui_blog_NhomBlog_templates_Item_Admin" %>
<%@ Import Namespace="linh.common" %>
<div class="blogNhom-item">
    <div class="pull-right">
        <button title="Xóa" class="btn btn-default publishBlogBtn" data-approved="0" data-id="<%=Item.Id %>">
            <i class="glyphicon glyphicon-remove"></i>
        </button>
        <button title="Duyệt" class="btn btn-default publishBlogBtn" data-approved="1" data-id="<%=Item.Id %>">
            <i class="glyphicon glyphicon-ok"></i>
        </button>
    </div>
    <a href="<%=Item.Url %>" class="blogNhom-item-title">
        <%=Item.Ten %>
    </a>
    <a href="<%=Item.NguoiTaoMember.Url %>" class="blogNhom-item-user"><%=Item.NguoiTaoMember.Ten %></a>
    <span class="blogNhom-item-date" title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>">
        <%=Lib.TimeDiff(Item.NgayTao) %>
    </span>        
</div>