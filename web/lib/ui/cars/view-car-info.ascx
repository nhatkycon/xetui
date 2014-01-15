<%@ Control Language="C#" AutoEventWireup="true" CodeFile="view-car-info.ascx.cs" Inherits="lib_ui_cars_view_car_info" %>
<%@ Register TagPrefix="heThong" TagName="likeBtn" Src="~/lib/ui/HeThong/LikeBtn.ascx" %>
<div class="car-view-infobox<%=Css %>">
<div class="car-view-breadcumb">
    <ol class="breadcrumb">
        <li><a href="/cars/">Xe</a></li>
        <li><a href="/cars/<%=Item.HANG_Ten %>/"><%=Item.HANG_Ten %></a></li>
        <li><a href="/cars/<%=Item.HANG_Ten %>/<%=Item.MODEL_Ten %>/"><%=Item.MODEL_Ten %></a></li>
    </ol>
</div>
<h1 class="car-view-caption">
    <%=Item.Ten %>                
</h1>
<div class="row car-view-stat">
    <div class="col-md-8">
        <div class="car-view-stat-item">
            <span class="car-view-stat-item-num car-view-stat-item-num-drive">
                <%=Item.TotalComment %>
            </span><br/>
            Bình luận
        </div>
        <div class="car-view-stat-item">
            <span class="car-view-stat-item-num car-view-stat-item-num-overdrive">
                <%=Item.TotalLike %>
            </span><br/>
            Thích
        </div>
        <a href="<%=Item.XeUrl %>blogs/" class="car-view-stat-item">
            <span class="car-view-stat-item-num car-view-stat-item-num-blog">
                <%=Item.TotalBlog %>
            </span><br/>
            Nhật ký
        </a>
    </div>
    <div class="col-md-4 car-view-summary">
        <%=Item.TotalView %> người thăm
    </div>
</div>
<div class="car-view-buttons">
    <div class="pull-right">
        <a href="javascript:;" class="btn btn-link reportBtn">
            Báo xe đểu
        </a>    
    </div>
    <heThong:likeBtn Loai="1" ID="likeBtn" runat="server"/>
    &nbsp;
    <a href="javascript:;" data-user="<%=Item.NguoiTao %>" class="btn btn-warning pmBtn">
        Nhắn tin
    </a>                
</div>
</div>