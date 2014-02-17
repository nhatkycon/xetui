<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Fan-Item.ascx.cs" Inherits="lib_ui_account_templates_Fan_Item" %>
<%@ Register TagPrefix="heThong" TagName="likeBtn" Src="~/lib/ui/HeThong/LikeBtn.ascx" %>
<div class="row fan-item">
    <div class="col-md-8 fan-item-user">
        <%=Item.Vcard %>
    </div>
    <div class="col-md-4">
        <div class="pull-right">
            <heThong:likeBtn Loai="2" ID="likeBtn" runat="server"/>
        </div>
    </div>
</div>