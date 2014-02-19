<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForNhom-Blog-Item-Full.ascx.cs" Inherits="lib_ui_blog_templates_ForNhom_Blog_Item_Full" %>
<%@ Register TagPrefix="heThong" TagName="likeBtn" Src="~/lib/ui/HeThong/LikeBtn.ascx" %>
<%@ Import Namespace="linh.common" %>
    <hr class="hr comment-hr"/>
<div class="blog-view">
    <a title="/<%=Item.NguoiTaoMember.Ten %>" href="/users/<%=Item.NguoiTao %>/" class="blog-view-user">
        <img src="/lib/up/users/<%=Item.NguoiTaoMember.Anh %>"/>
    </a>
    <div class="blog-view-content">
        <a href="<%=Item.Url %>" class="blog-view-title">
            <%=Item.Ten %>
        </a>
        <div class="blog-view-body">
            <%=Item.NoiDung %>
        </div>
        <div class="blog-view-info">
            <span class="blog-item-info-span blog-item-date">
                <%=Lib.TimeDiff(Item.NgayTao)%>
            </span>
            <%if (Item.TotalLike > 0)
                { %>
            <span class="blog-item-info-span blog-item-likes">
                <%=Item.TotalLike%> người thích
            </span>
            <%} %>
           
            <div class="pull-right">
                <a href="<%=Item.Url %>#comments" class="blog-item-info-span blog-item-comments">
                    <%=Item.TotalComment%> bình luận
                </a>
                &nbsp;
                <heThong:likeBtn ID="likeBtn" Loai="3" Css=" btn-xs" runat="server"/>
            </div>
        </div>
    </div>
</div>