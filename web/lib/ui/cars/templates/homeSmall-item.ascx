<%@ Control Language="C#" AutoEventWireup="true" CodeFile="homeSmall-item.ascx.cs" Inherits="lib_ui_cars_templates_homeSmall_item" %>
<div class="carsHomeSmall-item">
    <a href="<%=Item.XeUrl %>" class="carsHomeSmall-item-imgBox">
        <img alt="<%=Item.Anh %>" src="/lib/up/car/<%=Item.Anh %>?w=80" 
            class="carsHomeSmall-item-img"/>
    </a>
    <a href="<%=Item.XeUrl %>" class="carsHomeSmall-item-caption">
        <%=Item.Ten %>
    </a>
    <div class="carsHomeSmall-item-city">
        <%=Item.THANHPHO_Ten %>
    </div>
    <a href="<%=Item.Member.Url %>"  class="carsHomeSmall-item-city uname">
        <%=Item.Member.Ten %>
    </a>
</div>