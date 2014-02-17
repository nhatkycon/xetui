<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile-Info.ascx.cs" Inherits="lib_ui_account_Profile_Info" %>
<%@ Register TagPrefix="heThong" TagName="likeBtn" Src="~/lib/ui/HeThong/LikeBtn.ascx" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="profile-box">
    <div class="row nopadding">
        <div class="col-md-6">
            <a href="<%=Item.Url %>" class="profile-user-avatar">
                <img alt="<%=Item.Anh %>" class="profile-user-anh" src="/lib/up/users/<%=Item.Anh %>"/>                
            </a>
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
                    <a class="user-stats-block" href="<%=Item.Url %>/followers">
                        <span class="user-stats-num"><%=Item.TotalLiked %></span>
                        <span class="user-stats-txt">Người thích</span>
                    </a>
                    <a class="user-stats-block" href="<%=Item.Url %>/cars">
                        <span class="user-stats-num"><%=Item.TotalXe %></span>
                        <span class="user-stats-txt">Xe</span>
                    </a>
                    <a class="user-stats-block" href="<%=Item.Url %>/blogs/">
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
                    <heThong:likeBtn Loai="2" ID="likeBtn" runat="server"/>
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