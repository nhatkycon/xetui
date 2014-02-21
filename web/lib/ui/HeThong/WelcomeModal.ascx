<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WelcomeModal.ascx.cs" Inherits="lib_ui_HeThong_WelcomeModal" %>
<!-- Modal -->
<div class="modal fade" id="welComeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">
            Lái xe trên Xetui.vn
        </h4>
      </div>
      <div class="modal-body modal-welcome">
          <div class="hidden-xs">
        Xetui.vn là cộng đồng dành cho xe và xế. &nbsp;
        Nơi bạn tìm thấy chính mình trong thế giới tuyệt vời của những chiếc xe và tình yêu của các xế xịn. &nbsp;
        Nơi mà không có luật lệ giao thông, tai nạn, tắc đường, áo vàng và không tốn tiền cho xăng dầu. &nbsp;
        <br/>
        Hãy đăng ký để có bằng lái xe trên Xetui.vn ngay.<br/>
        Chúng tôi chờ bạn!      
          </div>
        <div class="visible-xs">
        Xetui.vn là cộng đồng dành cho xe và xế.<br/>
            Hãy đăng ký để có bằng lái xe trên Xetui.vn ngay.<br/>
        </div>

      </div>
      <div class="modal-footer">
        <a href="/Register/" class="btn btn-success">Đăng ký</a>
        <a href="/Login/?return=<%=Server.UrlEncode(Request.RawUrl) %>" class="btn btn-primary" >Đăng nhập</a>
        <button type="button" class="btn btn-default" data-dismiss="modal">Đăng ký sau</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->