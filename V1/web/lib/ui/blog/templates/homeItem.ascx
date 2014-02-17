<%@ Control Language="C#" AutoEventWireup="true" CodeFile="homeItem.ascx.cs" Inherits="lib_ui_blog_templates_homeItem" %>
<%@ Import Namespace="linh.common" %>
<div class="blog-item car-blog-item">
    <a href="<%=Item.GetNguoiTaoUrl() %>" class="blog-item-user">
        <img src="/lib/up/users/<%=Item.GetNguoiTao().Anh %>?w=50"                
            class=""
            />
    </a>
    <div class="blog-item-entry">
        <a class="blog-item-caption" href="<%=Item.Url %>" title="<%=Item.Ten %>"><%=Item.Ten %></a>
        <div class="blog-item-mota">
            <%=Item.MoTa %>
        </div>
    </div>
    <%if (!string.IsNullOrEmpty(Item.AnhStr)){ %>
        <div class="blog-item-pics hidden-sm">
            <%=Item.AnhStr %>
        </div>
    <%} %>
    <div class="blog-item-info">
        <span class="blog-item-info-span blog-item-date">
            <%=Lib.TimeDiff(Item.NgayTao) %>
        </span>
        <%if (Item.TotalLike > 0)
          { %>
        <span class="blog-item-info-span blog-item-likes">
            <%=Item.TotalLike %> người thích
        </span>
        <%} %>
        <a href="<%=Item.Url %>#comments" class="blog-item-info-span blog-item-comments">
            <%=Item.TotalComment %> bình luận
        </a>
    </div>
</div>