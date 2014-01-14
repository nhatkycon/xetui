<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeAlias.ascx.cs" Inherits="lib_ui_account_ChangeAlias" %>
<div class="modal fade" id="changeAliasModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">
            Đổi địa chỉ
        </h4>
      </div>
      <div class="modal-body changeAliasForm">
            <div class="input-group">
              <input type="hidden" class="form-control RowId" name="RowId" value="<%=Item.RowId %>"/>
              <span class="input-group-addon">xetui.vn/</span>                
              <input type="text" class="form-control Alias" data-id="<%=Item.RowId %>" name="Alias" value="<%=Item.Alias %>" placeholder="Alias"/>
              <span class="input-group-addon">
                  <span class="loader"></span>
              </span>
            </div>            
            <p class="help-block">
                Địa chỉ ngắn giúp bạn truy cập nhanh hơn
            </p>            
            <p class="alert alert-danger" style="display: none;"></p>
            <p class="alert alert-success" style="display: none;"></p>
      </div>
      <div class="modal-footer">
          <button type="button" class="btn btn-primary changeBtn" data-id="<%=Item.RowId %>" >Đổi</button>
        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->