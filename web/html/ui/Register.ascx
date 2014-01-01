<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="html_ui_Register" %>
<div class="padding-20">
    <h1>
            Tham gia <strong class="logo-font">Xetui</strong>
        </h1>
        <p>
            Mạng xã hội <strong class="logo-font">Xetui</strong> chào đón bạn và xế yêu!<br/>
            Chỉ vài bước đăng ký đơn giản, bạn sẽ tìm thấy mình trong thế giới <strong class="logo-font">Xetui</strong>. 
            Nơi không có luật lệ giao thông, không có tắc đường, không tiền phạt và giá xăng tăng.
        </p>
    <div class="register-form">
        <div class="row">
            <div class="col-md-4 col-md-offset-2">
                <h3>Dùng tài khoản Facebook</h3>
                <a href="javascript:;" class="btn btn-primary">
                    <i class="glyphicon glyphicon-user"></i> Sử dụng Facebook
                </a>        
            </div>
            <div class="col-md-4 register-form-accform">
                <h3>
                    Tạo tài khoản
                </h3>
                <div role="form" class="">
                    <div class="form-group">
                        <label for="Ten">Tên:</label>
                        <input type="email" class="form-control" id="Ten" name="Ten" placeholder="Tên xế" required="" >
                      </div>
                      <div class="form-group">
                        <label for="Email">Email:</label>
                        <input type="email" id="Email" class="form-control" name="Email" placeholder="E-mail xịn" required="">
                      </div>
                      <div class="form-group">
                        <label for="Pwd">Password</label>
                        <input type="password" class="form-control" id="Pwd" name="Pwd" placeholder="Password" required="">
                      </div>
                      <div class="checkbox">
                        <label>
                          <input type="checkbox"> 
                            <b>Đồng ý điều khoản của Xetui</b><br/>
                            - Tôi chỉ đăng ảnh có bản quyền<br/>
                            - Tôi không dùng từ ngữ thô tục<br/>
                            - Tôi không quảng cáo<br/>
                        </label>
                      </div>
                      <button type="submit" class="btn btn-primary">Đăng ký</button>
                </div>  
            </div>
        </div>        
    </div>    
</div>

