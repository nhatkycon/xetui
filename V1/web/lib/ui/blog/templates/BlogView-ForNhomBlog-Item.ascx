<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogView-ForNhomBlog-Item.ascx.cs" Inherits="lib_ui_blog_templates_BlogView_ForNhomBlog_Item" %>
<%@ Register TagPrefix="heThong" TagName="likeBtn" Src="~/lib/ui/HeThong/LikeBtn.ascx" %>
<%@ Import Namespace="docsoft" %>
<%@ Import Namespace="linh.common" %>
<div class="blog-view">
    <a title="/<%=Blog.GetNguoiTao().Ten %>" href="/users/<%=Blog.NguoiTao %>/" class="blog-view-user">
        <img src="/lib/up/users/<%=Blog.GetNguoiTao().Anh %>"/>
    </a>
    <div class="blog-view-content">
        <h3 class="blog-view-title">
            <%=Blog.Ten %>
        </h3>
        <div class="blog-view-body">
            <%=Blog.NoiDung %>
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
                    <a class="btn btn-default btn-primary" href="<%=Blog.UrlEdit %>">
                        <i class="glyphicon glyphicon-edit"></i>
                        Sửa
                    </a>
                    &nbsp;
                <% } %>
                <heThong:likeBtn Loai="3" ID="likeBtn" runat="server"/>
            </div>
        </div>
    </div>
</div>