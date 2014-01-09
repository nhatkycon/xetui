<%@ Control Language="C#" AutoEventWireup="true" CodeFile="promoted-item.ascx.cs" Inherits="lib_ui_cars_templates_promoted_item" %>
<div class="col-sm-2">
    <a href="<%=Item.XeUrl %>" class="car-promoted-item">
        <img class="car-img" src="/lib/up/car/<%=Item.Anh %>"/>  
        <span class="car-caption">
            <%=Item.Ten %>
        </span>          
        <span class="car-meta">
            <span class="car-meta-subscribers" title="">
                <%=Item.TotalLike %>
            </span>
            <span class="car-meta-views" title="">
                <%=Item.TotalView %>
            </span>
            <span class="car-meta-blogs" title="">
                <%=Item.TotalBlog %>
            </span>
        </span>          
    </a>
</div>