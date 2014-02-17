<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Nhom-Header-Blog.ascx.cs" Inherits="lib_ui_nhom_Nhom_Header_Blog" %>
<div class="h3-subtitle">
    <a href="/group/">Cộng đồng</a>&nbsp; &gt;
    <a href="<%=Item.Url %>">
        <%=Item.Ten %>
    </a>&nbsp; &gt;
    <a href="<%=Item.Url %>blogs/">
        Blog
    </a>                
</div>  
<%if(Item.Joined){ %>   
<hr class="hr comment-hr"/> 
<div>
    <a href="<%=Item.Url %>/blogs/add/" class="btn btn-primary">
        <i class="glyphicon glyphicon-plus">
        </i>
            Viết blog
    </a>
</div>
<%} %>