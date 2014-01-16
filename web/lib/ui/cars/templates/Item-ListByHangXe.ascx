<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-ListByHangXe.ascx.cs" Inherits="lib_ui_cars_templates_Item_ListByHangXe" %>
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
    <div class="carcard-info">
        <span title="<%=Item.THANHPHO_Ten %>">
            <%=Item.THANHPHO_Ten %>
        </span>
    </div>
    <div class="carcard-owner">
        <a href="/users/<%=Item.NguoiTao %>/">
            <span class="uname">
                <%=Item.NguoiTao_Ten %>
            </span>
        </a>
    </div>
</div>