<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Error404.ascx.cs" Inherits="lib_ui_HeThong_Error404" %>
<div class="padding-20">
    <div class="h3-subtitle">
        Trang này không tồn tại
    </div>
    <hr class="hr comment-hr"/>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="alert alert-warning">
                Địa chỉ <%=Request.RawUrl %> không tồn tại
            </div>
            <img class="img-responsive" src="/lib/css/web/i/bkg-not-found.jpg" />                        
        </div>
    </div>
</div>