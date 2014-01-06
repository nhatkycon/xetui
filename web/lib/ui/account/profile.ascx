<%@ Control Language="C#" AutoEventWireup="true" CodeFile="profile.ascx.cs" Inherits="lib_ui_account_profile" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="profile-box">
    <div class="row nopadding">
        <div class="col-md-6">
            <div class="profile-user-avatar">
                <img alt="<%=Item.Anh %>" class="profile-user-anh" src="/lib/up/users/<%=Item.Anh %>"/>                
            </div>
            <div class="profile-user-note">
                <h1 class="profile-user-username">
                    <%=Item.Ten %>
                </h1>
                <p class="profile-user-tinh">
                    <%=Item.Tinh_Ten %>
                </p>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-8">
                    <a class="user-stats-block" href="/users/<%=Item.Username %>/followers">
                        <span class="user-stats-num"><%=Item.TotalLiked %></span>
                        <span class="user-stats-txt">Người thích</span>
                    </a>
                    <a class="user-stats-block" href="/users/<%=Item.Username %>/cars">
                        <span class="user-stats-num"><%=Item.TotalXe %></span>
                        <span class="user-stats-txt">Xe</span>
                    </a>
                    <a class="user-stats-block" href="/users/<%=Item.Username %>/blogs">
                        <span class="user-stats-num"><%=Item.TotalBlog %></span>
                        <span class="user-stats-txt">Blog</span>
                    </a>
                </div>
                <div class="col-md-4">
                    <div class="profile-user-static">
                        Tham gia Xetui.vn <%=Lib.TimeDiff(Item.NgayTao) %>
                    </div>
                    <% if(Item.TotalComment > 0){ %>
                    <div class="profile-user-static">
                        Đóng góp <%=Item.TotalComment%> bình luận
                    </div>
                    <%} %>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <%if(Item.Username != Security.Username){ %>
                    <button class="btn btn-primary">
                        <i class="glyphicon glyphicon-star-empty"></i>
                        Thích
                    </button>
                    <%} %>
                    <%if(Item.Username != Security.Username){ %>
                    <button data-user="<%=Item.Username %>"  class="btn btn-default pmBtn">
                        Nhắn tin
                    </button>
                    <%} %>
                    
                </div>                
            </div>
        </div>
    </div>
</div>
<div class="padding-20">
    <div class="row">
        <div class="col-md-8"></div>
        <div class="col-md-4 profile-info">
            <h3 class="profile-info-header">
                Về tôi
            </h3>
            <h3 class="profile-info-about">
                <%=Item.Mota %>
            </h3>
            <hr class="hr comment-hr"/>
            <h3 class="profile-info-header">
                Cộng đồng
            </h3>
            <ul>
                <li>
                    <a href="/communities/">Audi</a>
                </li>
                <li>
                    <a href="/communities/">Xe nhật</a>
                </li>
            </ul>
        </div>
    </div>
</div>