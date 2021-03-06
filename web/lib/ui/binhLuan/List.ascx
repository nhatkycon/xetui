﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_binhLuan_List" %>
<%@ Import Namespace="docsoft" %>
<%@ Register Src="~/lib/ui/binhLuan/templates/Item.ascx" TagPrefix="binhLuan" TagName="Item" %>

<div class="padding-20 binhLuan-ListBox">
    <h3 class="binhLuan-header">
        Bình luận <span class="text-muted"><%=Pager.Total %></span>
    </h3>
    <%if(Security.IsAuthenticated()){ %>
    <hr class="hr comment-hr"/>
    <div class="binhLuan-post binhLuanPostBox">
        <textarea name="txt" class="form-control txt" rows="3"></textarea>
        <div class="binhLuan-post-btn">
            <span class="pull-right">
                <a href="javascript:;" data-id="<%=PRowId %>" class="btn btn-lg btn-default saveBtn">Gửi bình luận</a>
                <input type="hidden" name="PRowId" value="<%=PRowId %>"/>
            </span>
            <span class="help-block">Nội dung lịch sự</span>            
        </div>
        <p class="alert alert-danger" style="display: none;"></p>
        <p class="alert alert-success" style="display: none;"></p>
    </div>
    <%} %>
    <div class="binhLuan-Items">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <binhLuan:Item runat="server" ID="Item" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>     
    </div>
    <%if(Pager.Total > Pager.PageSize){ %>
    <hr class="hr comment-hr"/>
    <a class="btn btn-default" href="/comments/<%=PRowId %>/">Xem thêm</a>
    <%} %>
</div>

<div class="binhLuan-post binhLuanReplyBox">
    <hr class="hr comment-hr"/>
    <textarea name="txt" class="form-control txt" rows="3"></textarea>
    <div class="binhLuan-post-btn">
        <span class="pull-right">
            <a href="javascript:;" data-id="<%=PRowId %>" class="btn btn-lg btn-default replySaveBtn">Gửi bình luận</a>
            <input type="hidden" class="PRowId" name="PRowId" value="<%=PRowId %>"/>
            <input type="hidden" class="PBL_ID" name="PBL_ID" value=""/>
        </span>
        <span class="help-block">Nội dung lịch sự</span>            
    </div>
    <p class="alert alert-danger" style="display: none;"></p>
    <p class="alert alert-success" style="display: none;"></p>
</div>