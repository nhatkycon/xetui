<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListAll.ascx.cs" Inherits="lib_ui_cars_ListAll" %>
<%@ Register Src="~/lib/ui/hangXe/ListHangXe.ascx" TagPrefix="uc1" TagName="ListHangXe" %>

<div class="padding-20">
    <div class="h3-subtitle">
        <a href="/cars/">
            Ôtô
        </a> 
    </div>
    <hr class="hr comment-hr"/>
    <uc1:ListHangXe runat="server" id="ListHangXe" />
    <hr class="hr comment-hr"/>
</div>