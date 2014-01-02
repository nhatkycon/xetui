<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="html_ui_Register" %>
<div class="padding-20 register-pnl">
    <h1>
        Tham gia <span class="logo-font">XETUI.VN</span>
    </h1>
    <p>
        Mạng xã hội <span class="logo-font">XETUI.VN</span> chào đón bạn và xế yêu!<br/>
        Chỉ vài bước đăng ký đơn giản, bạn sẽ tìm thấy mình trong thế giới <span class="logo-font">XETUI.VN</span>. 
        Nơi không có luật lệ giao thông, không có tắc đường, không tiền phạt và giá xăng tăng.
    </p>
    <div class="register-form step-1">
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <h3 class="register-form-header">Dùng Facebook</h3>
                <a href="javascript:;" class="btn btn-primary btn-lg singupFacebook">
                    <i class="glyphicon glyphicon-user"></i> Sử dụng Facebook
                </a>        
                <p class="help-block">
                    An toàn và chỉ mất 5s
                </p>
            </div>            
            <div class="col-md-4 col-md-offset-2">
                <h3 class="register-form-header">
                    Tạo tài khoản
                </h3>
                <div role="form" class="">
                    <div class="form-group">
                        <label for="Ten">Tên:</label>
                        <input type="text" class="form-control" id="Ten" name="Ten" placeholder="Tên xế" required="" >
                      </div>
                      <div class="form-group">
                        <label for="Email">Email:</label>
                        <input type="email" id="Email" class="form-control" name="Email" placeholder="E-mail xịn" required="">
                      </div>
                      <div class="form-group">
                        <label for="Pwd">Mật khẩu</label>
                        <input type="password" class="form-control" id="Pwd" name="Pwd" placeholder="Password" required="">
                      </div>
                      <div class="form-group">
                        <img class="img-rounded img-thumbnail" src="/lib/pages/Captcha.aspx"/>
                      </div>
                      <div class="form-group">
                        <label for="Captcha">Nhập ký tự từ ảnh trên</label>
                        <input class="form-control" id="Captcha" name="Captcha" placeholder="" required="">
                        <p class="help-block">
                            Chỉ để chắc chắn bạn không phải là robot
                        </p>
                      </div>
                      <div class="checkbox">
                        <label>
                          <input type="checkbox" id="dongY"> 
                            <b>Đồng ý điều khoản của Xetui</b><br/>
                            - Tôi chỉ đăng ảnh có bản quyền<br/>
                            - Tôi không dùng từ ngữ thô tục<br/>
                            - Tôi không quảng cáo<br/>
                        </label>
                      </div>
                      <a href="javascript:;" class="btn btn-success btn-lg dangKyBtn">Đăng ký</a>
                      <br/><br/>
                      <p class="alert alert-danger" style="display: none;"></p>
                </div>  
            </div>
        </div>        
    </div>
    <div class="register-form step-2">
        <div class="row">
            <div class="col-md-offset-4 col-md-4 col-sm-6 col-sm-offset-3">
                <h3 class="register-form-header">Nhận BẰNG LÁI XE</h3>                
                <div role="form" class="facebook-signup-form">
                      <div class="form-group">
                          <img class="img-thumbnail fb-avatar pull-left"/>                              
                          <p class="help-block">
                              Bằng lái của bạn trên <span class="logo-font">XETUI.VN</span> đã được tạo, check thông tin bên dưới trước khi bút xa, gà chết
                          </p>
                      </div>
                      <div class="form-group">
                        <label for="Ten1">Tên:</label>
                        <input type="text" class="form-control" id="Ten1" name="Ten" placeholder="Tên xế" required="" >
                      </div>
                      <div class="form-group">
                        <label for="Email2">Email:</label>
                        <input disabled="disabled" type="email" id="Email2" class="form-control" name="Email" placeholder="E-mail xịn" required="">
                      </div>                                                                  
                      <div class="checkbox">
                        <label>
                          <input type="checkbox" id="dongY"> 
                            <b>Đồng ý điều khoản của Xetui</b><br/>
                            - Tôi chỉ đăng ảnh có bản quyền<br/>
                            - Tôi không dùng từ ngữ thô tục<br/>
                            - Tôi không quảng cáo<br/>
                        </label>
                      </div>
                      <a href="javascript:;" class="btn btn-success btn-lg signup-done-btn">Hoàn thành</a>
                      <br/><br/>
                      <p class="alert alert-danger" style="display: none;"></p>
                </div>
            </div>
        </div>
    </div>
</div>

