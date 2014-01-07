<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Signup-Done.ascx.cs" Inherits="lib_ui_HeThong_Signup_Done" %>
<%@ Import Namespace="docsoft" %>
<div class="padding-20">
    <h1>
        Bạn đã có bằng lái trên Xetui.vn
    </h1>
    <p>
        Thú vị nhất là bạn có thể "lái xe" trên Xetui.vn từ thời điểm này.
    </p>
    <%if(!Item.XacNhan){ %>
    <p class="alert alert-danger">
        Bạn cần kiểm tra hòm thư <strong><%=Item.Email %></strong> để xác nhận địa chỉ e-mail ngay.
        <br/>Nếu sau 30 ngày bạn không xác nhận, bằng lái xe bị <strong>tịch thu</strong>.
    </p>
    <%} %>
    <h3>Tiếp theo</h3>
    <hr class="hr comment-hr"/>
    <div class="row">
        <div class="col-md-12">
            <h3>Đổi ảnh đại diện</h3>
            <div class="user-avatar user-avatar-180 myAccount-avatar">
                <img class="user-avatar-img img-thumbnail" src="/lib/up/users/<%=Item.Anh %>" alt="<%=Item.Anh %>" />
                <div class="changeBtn-box">
                    <a href="javascript:;" class="btn btn-success changeBtn">Đổi ảnh</a>                            
                </div>
            </div>
        </div>
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
</div>