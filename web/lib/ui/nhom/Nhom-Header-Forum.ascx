<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Nhom-Header-Forum.ascx.cs" Inherits="lib_ui_nhom_Nhom_Header_Forum" %>
<div class="h3-subtitle">
    <a href="/group/">Cộng đồng</a>&nbsp; &gt;
    <a href="<%=Item.Url %>">
        <%=Item.Ten %>
    </a>&nbsp; &gt;
    <a href="<%=Item.Url %>forum/">
        Thảo luận
    </a>                
</div>  
<%if(Item.Joined){ %>    
<div>
    <a href="<%=Item.Url %>/forum/add/" class="btn btn-primary">
        <i class="glyphicon glyphicon-plus">
        </i>
            Chủ đề mới
    </a>
</div>
<%} %>