<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActiveEmail.ascx.cs" Inherits="lib_ui_HeThong_ActiveEmail" %>
<%@ Import Namespace="docsoft" %>
<div class="padding-20">
    <h1>
        <%if(Done) {%>
        Xác nhận thành công
        <%}else{ %>
        Xác nhận không thành công
        <%} %>
    </h1>
    <p>
        <%if(Done) {%>
        Bằng lái của bạn đã được Xetui.vn xác nhận thành công địa chỉ e-mail.<br/>
        Bạn là tài xế quá giỏi, chúc mừng bạn!
        <%}else{ %>
        Địa chỉ xác nhận đã hết hạn xác nhận<br/>
        Liên lạc <a href="mailto:support@xetui.vn">mailto:support@xetui.vn</a> để được hỗ trợ
        <%} %>
    </p>
    <h3>Tiếp theo</h3>
    <hr class="hr comment-hr"/>
        <%if(Done) {%>
        <div class="row">
            <div class="col-md-3 col-md-offset-1">
                <a href="/cars/add/" class="btn btn-success btn-lg" >1. Đăng ký xe</a>
                <p class="help-block">
                    Đăng ký cho những chiếc xế yêu của bạn
                </p>            
            </div>
            <div class="col-md-3 col-md-offset-1">
                <a href="/users/<%=Security.Username %>/" class="btn btn-primary btn-lg" >2. Trang cá nhân</a>
                <p class="help-block">
                    Ngôi nhà nhỏ của bạn
                </p>            
            </div>
            <div class="col-md-3 col-md-offset-1">
                <a href="/acc/" class="btn btn-primary btn-lg" >3. Cài đặt tài khoản</a>
                <p class="help-block">
                    Chỉnh sửa tên, ảnh đại diện, slogan
                </p>
            </div>        
        </div>
        <%} %>
</div>