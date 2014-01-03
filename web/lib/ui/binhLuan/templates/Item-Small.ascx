<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Small.ascx.cs" Inherits="lib_ui_binhLuan_templates_Item_Small" %>
<div class="binhLuan-item binhLuan-item-reply">
    <div class="binhLuan-item-user">
        <%=Item.Member.Vcard %>
    </div>
    <div class="binhLuan-item-body">
        <%=Item.NoiDung %>
    </div>
    <div class="binhLuan-item-footer">
        <div class="pull-right">
            <a href="javascript:;" title="<%=Item.NgayTao.ToString("HH:mm dd/MM/yy") %>"><%=Item.NgayTao.ToString("HH:mm dd/MM/YYYY") %></a>
        </div>
    </div>
    <hr class="hr comment-hr"/>
</div>