<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login.ascx.cs" Inherits="lib_ui_HeThong_login" %>
<div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">Đăng nhập</h4>
      </div>
      <div class="modal-body">
          <div class="row">
            <div class="col-md-5">
                  <p class="help-block">
                      Đăng nhập bằng tài khoản Facebook
                  </p>
                  <a href="javascript:;" class="btn btn-primary btn-lg loginFacebook">
                    <i class="glyphicon glyphicon-user"></i> Đăng nhập
                  </a>
              </div>
              <div class="col-md-1 hidden-sm hidden-xs"></div>
              <div class="col-md-1 visible-sm visible-xs"><hr/></div>
              <div class="col-md-6">
                <div role="form" class="login-form">
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
                        <a type="button" class="btn btn-success">Đăng ký</a>
                        <p>
                            <a href="/Recover/" class="btn btn-link">Quên mật khẩu</a>
                        </p>
                    </div>
                    <br/><br/>
                    <p class="alert alert-danger" style="display: none;"></p>
                </div>      
              </div>
          </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div>
</div>