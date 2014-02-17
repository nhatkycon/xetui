<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminAdd.ascx.cs" Inherits="lib_ui_binhLuan_AdminAdd" %>
<div class="panel panel-default">
    <div class="panel-heading">
        <a href="/lib/mod/BinhLuan/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>            
    </div>
    <div class="panel-body">
        <div class="padding-20 binhLuan-add-pnl">
            <form class="form-horizontal blog-add-form" role="form">
                <input type="hidden" name="Id"  value="<%=Item.Id %>"/>
                <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
                <div class="form-group">
                    <div class="col-sm-12">
                    <textarea class="form-control NoiDung" name="NoiDung" id="NoiDung" rows="10">
                    <%=Item.NoiDung %>
                    </textarea>                
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
                        <%if(Item.Id!=0){ %>
                            <a href="javascript:;" class="btn btn-danger btn-lg xoaBtn">Xóa</a>
                        <%} %>
                        <br/><br/>
                        <p class="alert alert-danger" style="display: none;"></p>
                        <p class="alert alert-success" style="display: none;"></p>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>