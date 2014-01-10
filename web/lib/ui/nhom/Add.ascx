<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_nhom_Add" %>
<div class="padding-20 nhom-add-pnl">
    <div class="h3-subtitle">
        <a href="/">
            Nhóm của tôi
        </a>
    </div>
    <hr class="hr comment-hr"/>
    <form class="form-horizontal blog-add-form" role="form">
        <input type="hidden" name="Id"  value="<%=Item.ID %>"/>
        <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Tên</label>
            <div class="col-sm-10">
                <input type="text" class="form-control Ten" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tiêu đề blog">
            </div>
        </div>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Tên</label>
            <div class="col-sm-10">
                <input type="text" class="form-control MoTa" id="MoTa" value="<%=Item.MoTa %>" name="MoTa" placeholder="Mô tả">
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-12">
            <textarea class="form-control NoiDung" name="NoiDung" id="NoiDung" rows="10"><%=Item.GioiThieu %></textarea>                
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
                <%if(Item.ID!=0){ %>
                    <a href="javascript:;" class="btn btn-danger btn-lg xoaBtn">Xóa</a>
                <%} %>
                <br/><br/>
                <p class="alert alert-danger" style="display: none;"></p>
                <p class="alert alert-success" style="display: none;"></p>
            </div>
        </div>
    </form>
</div>