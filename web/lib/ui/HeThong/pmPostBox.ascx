<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pmPostBox.ascx.cs" Inherits="lib_ui_HeThong_pmPostBox" %>

<div class="modal fade" id="pmPostBoxModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">
            Gửi tin nhắn
        </h4>
      </div>
      <div class="modal-body">
            <textarea name="txt" class="form-control txt" rows="3"></textarea>
            <input type="hidden" class="toUser" name="toUser" value=""/>
            <p class="help-block">Nội dung lịch sự</p>            
            <p class="alert alert-danger" style="display: none;"></p>
            <p class="alert alert-success" style="display: none;"></p>
      </div>
      <div class="modal-footer">
          <button type="button" class="btn btn-primary saveBtn" >Gửi</button>
        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->