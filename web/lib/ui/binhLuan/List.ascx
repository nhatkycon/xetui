<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_binhLuan_List" %>
<%@ Register Src="~/lib/ui/binhLuan/templates/Item.ascx" TagPrefix="binhLuan" TagName="Item" %>

<div class="padding-20">
    <h3 class="binhLuan-header">
        Bình luận
    </h3>
    <hr class="hr comment-hr"/>
    <div class="binhLuan-post">
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
        <hr class="hr comment-hr"/>
    </div>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <binhLuan:Item runat="server" ID="Item" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater> 
</div>