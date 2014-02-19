<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-View.ascx.cs" Inherits="lib_ui_blog_NhomForum_templates_Item_View" %>
<%@ Register TagPrefix="heThong" TagName="likeBtn" Src="~/lib/ui/HeThong/LikeBtn.ascx" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>

<div class="binhLuan-item">
    <div class="binhLuan-item-user">
        <%=Blog.NguoiTaoMember.Vcard%>
    </div>
    <div class="binhLuan-item-body">
        <h3 class="blog-view-title">
            <%=Blog.Ten %>
        </h3>
        <span class="binhLuan-item-text">
            <%=Blog.NoiDung%>            
        </span>
    </div>
    <div class="blog-view-info">
        <span class="blog-item-info-span blog-item-date">
            <%=Lib.TimeDiff(Blog.NgayTao)%>
        </span>
        <%if (Blog.TotalLike > 0)
            { %>
        <span class="blog-item-info-span blog-item-likes">
            <%=Blog.TotalLike%> người thích
        </span>
        <%} %>
        <a href="<%=Blog.Url %>" class="blog-item-info-span blog-item-comments">
            <%=Blog.TotalComment%> bình luận
        </a>
        <div class="pull-right">
            <%if (Blog.NguoiTao == Security.Username || Item.IsAdmin)
                { %>
                <a class="btn btn-default btn-primary btn-xs" href="<%=Blog.UrlEdit %>">
                    <i class="glyphicon glyphicon-edit"></i>
                    Sửa
                </a>
                &nbsp;
            <% } %>
            <heThong:likeBtn Css=" btn-xs" Loai="3" ID="likeBtn" runat="server"/>
        </div>
    </div>
</div>