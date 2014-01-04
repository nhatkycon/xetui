﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_binhLuan_templates_Item" %>
<%@ Import Namespace="docsoft" %>
<div class="binhLuan-item<%= Item.PBL_ID != 0 ? " binhLuan-item-reply" : "" %>">
    <a name="<%=Item.ID %>"></a>
    <hr class="hr comment-hr"/>
    <div class="binhLuan-item-user">
        <%=Item.Member.Vcard %>
    </div>
    <div class="binhLuan-item-body">
        <span class="binhLuan-item-text<%=Item.X_NguoiTao == Item.Username ? " own" : "" %>">
            <%=Item.NoiDung %>            
        </span>
    </div>
    <div class="binhLuan-item-footer">
        <div class="pull-right">
            <a class="btn btn-link btn-sm binhLuan-item-date" href="javascript:;" title="<%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>"><%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %></a>
            <%if ((Item.Username == Security.Username || Item.X_NguoiTao == Security.Username) && Security.IsAuthenticated())
              { %>
                <a class="btn btn-default btn-sm removeBlBtn" data-id="<%=Item.ID %>">
                    <i class="glyphicon glyphicon-remove"></i> Xóa
                </a>
            <%}else{ %>
                <%if (Security.IsAuthenticated())
                  { %>    
                    <a class="btn btn-default btn-sm reportBlBtn" data-id="<%=Item.ID %>">
                        <i class="glyphicon glyphicon-minus-sign"></i> Báo cáo
                    </a>
                <%} %>
            <%} %>

            <%if (Item.PBL_ID == 0 && Security.IsAuthenticated())
              { %>
            <a data-pRowId="<%=Item.P_RowId %>" data-pid="<%=Item.ID %>" href="javascript:;" class="btn btn-sm btn-default replyBtn" title="Trả lời">
                <i class="glyphicon glyphicon-repeat"></i> Trả lời
            </a>
            <%} %>
        </div>
    </div>
</div>