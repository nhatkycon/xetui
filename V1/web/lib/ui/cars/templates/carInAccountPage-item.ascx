<%@ Control Language="C#" AutoEventWireup="true" CodeFile="carInAccountPage-item.ascx.cs" Inherits="lib_ui_cars_templates_carInAccountPage_item" %>
<div class="carcard carcard-big">
    <div class="carcard-pic">
        <a href="<%=Item.XeUrl %>">
            <img src="/lib/up/car/<%=Item.Anh %>" alt=""/>
        </a>
    </div>
    <div class="carcard-meta">
        <span class="carcard-meta-drive" title="Bình luận"><%=Item.TotalComment %></span> 
        <span class="carcard-meta-overdrive" title="Lượt thích"><%=Item.TotalLike %></span>
        <span class="carcard-meta-blog" title="Bài nhật ký xe"><%=Item.TotalBlog %></span>
    </div>
    <div class="carcard-caption">
        <a href="<%=Item.XeUrl %>">
            <%=Item.Ten %>
        </a>
    </div>
</div>