<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LikeBtn.ascx.cs" Inherits="lib_ui_HeThong_LikeBtn" %>
<%if (!Liked)
  { %>
    <a href="javascript:;" data-id="<%=RowId %>" data-loai="<%=Loai %>" class="btn btn-primary likeBtn<%=Css %>">
        <i class="glyphicon glyphicon-star-empty"></i>
        <span>
        Thích            
        </span>
    </a>
<%}else{ %>
    <a href="javascript:;" data-id="<%=RowId %>" data-loai="<%=Loai %>" class="btn btn-default liked likeBtn<%=Css %>">
        <i class="glyphicon glyphicon-star"></i>
        <span>
        Đã thích
        </span>
    </a>
<%} %> 
