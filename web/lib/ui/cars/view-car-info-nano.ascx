<%@ Control Language="C#" AutoEventWireup="true" CodeFile="view-car-info-nano.ascx.cs" Inherits="lib_ui_cars_view_car_info_nano" %>
<%@ Register TagPrefix="heThong" TagName="likeBtn" Src="~/lib/ui/HeThong/LikeBtn.ascx" %>
<div class="car-view-infobox">
<div class="car-view-breadcumb">
    <ol class="breadcrumb">
        <li><a href="/cars/">Xe</a></li>
        <li><a href="/cars/<%=Item.HANG_Ten %>/"><%=Item.HANG_Ten %></a></li>
        <li><a href="/cars/<%=Item.HANG_Ten %>/<%=Item.MODEL_Ten %>/"><%=Item.MODEL_Ten %></a></li>
    </ol>
</div>
<h1 class="car-view-caption car-view-caption-nano">
    <%=Item.Ten %>                
</h1>
<div class="row car-view-stat">
    <div class="col-md-12">
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
</div>
<p>
        <%=Item.TotalView %> người thăm
    </p>
<div class="car-view-buttons">    
    <heThong:likeBtn Loai="1" ID="likeBtn" runat="server"/>
    <br/><br/>
    <a href="javascript:;" data-user="<%=Item.NguoiTao %>" class="btn btn-warning pmBtn">
        Nhắn tin
    </a>
    <br/><br/>
    <a href="javascript:;" class="btn btn-link reportBtn">
            Báo xe đểu
    </a>                
</div>
</div>