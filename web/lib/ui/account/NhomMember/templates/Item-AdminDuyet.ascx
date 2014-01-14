<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-AdminDuyet.ascx.cs" Inherits="lib_ui_account_NhomMember_templates_Item_AdminDuyet" %>
<%@ Import Namespace="linh.common" %>
<div class="NhomMemberPending-Item">
    <div class="row">
        <div class="col-md-8">
            <%=Item.Member.Vcard %>    
        </div>
        <div class="col-md-4">
            <div class="pull-right">
                <p class="help-block"><%=Lib.TimeDiff(Item.NgayTao) %></p>
                <button title="Xóa" class="btn btn-default removeMemberBtn" data-id="<%=Item.ID %>">
                    <i class="glyphicon glyphicon-remove"></i>
                </button>
                <button title="Duyệt" class="btn btn-default duyetMemberBtn" data-id="<%=Item.ID %>">
                    <i class="glyphicon glyphicon-ok"></i>
                </button>
            </div>        
        </div>
    </div>
    <hr class="comment-hr hr"/>
</div>