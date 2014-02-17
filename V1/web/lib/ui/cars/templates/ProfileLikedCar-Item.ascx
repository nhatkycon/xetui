<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProfileLikedCar-Item.ascx.cs" Inherits="lib_ui_cars_templates_ProfileLikedCar_Item" %>
<%@ Register Src="~/lib/ui/HeThong/LikeBtn.ascx" TagPrefix="uc1" TagName="LikeBtn" %>
<div class="likedCar-item">    
    <a href="<%=Item.XeUrl %>" class="likedCar-item-user">
        <img src="/lib/up/car/<%=Item.Anh %>"/>
    </a>
    <div class="likedCar-item-body">
        <div class="pull-right">
            <uc1:LikeBtn runat="server" Loai="1" ID="LikeBtn" />        
        </div>
        <a href="<%=Item.XeUrl %>" class="likedCar-item-caption">
            <%=Item.Ten %>
        </a>
        <div class="likedCar-item-city"><%=Item.THANHPHO_Ten %></div>
        <a class="likedCar-item-username" href="<%=Item.Member.Url %>" >
            <%=Item.Member.Ten %>
        </a>
    </div>
</div>