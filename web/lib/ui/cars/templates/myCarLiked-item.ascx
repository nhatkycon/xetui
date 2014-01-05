<%@ Control Language="C#" AutoEventWireup="true" CodeFile="myCarLiked-item.ascx.cs" Inherits="lib_ui_cars_templates_myCarLiked_item" %>
<%@ Import Namespace="linh.common" %>
<div class="carcard carcard-big">
    <div class="carcard-buttons">
        <a class="btn btn-link" href="/cars/edit/<%=Item.Xe.ID %>/">
            <i class="glyphicon glyphicon-edit"></i> Sửa
        </a>
    </div>
    <div class="carcard-pic">
        <a href="<%=Item.Xe.XeUrl %>">
            <img src="/lib/up/car/<%=Item.Xe.Anh %>" alt=""/>
        </a>
    </div>
    <div class="carcard-meta">
        <span class="carcard-meta-drive" title="Bình luận"><%=Item.Xe.TotalComment %></span> 
        <span class="carcard-meta-overdrive" title="Lượt thích"><%=Item.Xe.TotalLike %></span>
        <span class="carcard-meta-blog" title="Bài nhật ký xe"><%=Item.Xe.TotalBlog %></span>
    </div>
    <div class="carcard-caption">
        <a href="<%=Item.Xe.XeUrl %>">
            <%=Item.Xe.Ten %>
        </a>
    </div>
</div>