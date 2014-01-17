<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminUnAuthorize.ascx.cs" Inherits="lib_ui_nhom_AdminUnAuthorize" %>
<div class="padding-20">
    <div class="h3-subtitle">
        <a href="/group/">Cộng đồng</a>&nbsp; &gt;
        <%=Item.Ten %>
    </div>
    <hr class="hr comment-hr"/>
    <div class="alert alert-danger">
        <h3 class="h3-subtitle">
         <i class="glyphicon glyphicon-warning-sign"></i> Bạn không phải là admin của nhóm <%=Item.Ten %>
        </h3>
        <p class="help-block">
            Vui lòng liên hệ với admin của nhóm
        </p>
    </div>
</div>