<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Big.ascx.cs" Inherits="lib_ui_binhLuan_templates_Item_Big" %>
<div class="binhLuan-item">
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