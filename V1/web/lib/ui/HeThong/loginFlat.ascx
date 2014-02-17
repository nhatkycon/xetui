<%@ Control Language="C#" AutoEventWireup="true" CodeFile="loginFlat.ascx.cs" Inherits="lib_ui_HeThong_loginFlat" %>
<div class="padding-20">
    <div class="h3-subtitle">
        Đăng nhập
    </div>
    <hr class="hr comment-hr"/>
    <div class="row login-form-normal">
        <div class="col-md-4 col-md-offset-1">
            <p class="help-block">
                Đăng nhập bằng tài khoản Facebook
            </p>
            <a href="javascript:;" class="btn btn-primary btn-lg loginFacebook">
            <i class="glyphicon glyphicon-user"></i> Đăng nhập
            </a>
        </div>
        <div class="col-md-1 hidden-sm hidden-xs"></div>
        <div class="col-md-1 visible-sm visible-xs"><hr/></div>
        <div class="col-md-4">
        <div role="form" class="login-form">
            <p class="help-block">
                Đăng nhập bằng tài khoản XETUI.VN
            </p>
            <div class="form-group">
                <label for="Email">Email:</label>
                <input type="email" id="Email" class="form-control Email" name="Email" placeholder="E-mail xịn" required="">
            </div>
            <div class="form-group">
                <label for="Pwd">Mật khẩu</label>
                <input type="password" class="form-control Pwd" id="Pwd" name="Pwd" placeholder="Password" required="">
            </div>
            <div class="checkbox">
            <label>
                <input type="checkbox" name="Rem" id="dongY"> 
                Ghi nhớ
            </label>
            </div>
            <div class="form-group">
                <button type="button" class="btn btn-primary loginBtn">Đăng nhập</button>
                <a href="/Register/" class="btn btn-success">Đăng ký</a>
                <p>
                    <a href="/Recover/" class="btn btn-link">Quên mật khẩu</a>
                </p>
            </div>
            <br/><br/>
            <p class="alert alert-danger" style="display: none;"></p>
        </div>      
        </div>
    </div>
</div>
