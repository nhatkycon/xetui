<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuenMatKhau.ascx.cs" Inherits="lib_ui_HeThong_QuenMatKhau" %>
<div class="padding-20">
    <h1>
        Quên mật khẩu
    </h1>
    <%if(Recovering){ %>
    <p>
        Điền thông tin vào ô dưới để khôi phục lại mật khẩu
    </p>
    <hr class="hr comment-hr"/>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div role="form" class="recoverPasswordPnl">
                <div class="form-group">
                    <label class="col-sm-4 col-md-4 control-label" for="Email">
                        <span class="pull-right">E-mail:</span>
                    </label>
                    <div class="col-sm-8 col-md-8">
                        <input type="text" class="form-control Email" id="Email" name="Email" placeholder="Địa chỉ e-mail của bạn" required="" >
                        <p class="help-block">
                            Nhập địa chỉ e-mail của bạn để tiến hành khôi phục mật khẩu
                        </p>
                    </div>
                </div>
                <div class="form-group">
                <div class="col-sm-offset-4 col-sm-8">
                    <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">
                        Khôi phục
                    </a>
                    <br/><br/>
                    <p class="alert alert-danger" style="display: none;"></p>
                    <p class="alert alert-success" style="display: none;"></p>
                </div>
            </div>
            </div>
        </div>
    </div>
    <%}else
      {%>
      <%if(Correct){ %>
        <p>
            Tạo mật khẩu mới
        </p>
        <hr class="hr comment-hr"/>
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div role="form" class="recoverSavePasswordPnl">
                    <div class="form-group">
                        <label class="col-sm-4 col-md-4 control-label" for="Pwd">
                            <span class="pull-right">Mật khẩu mới:</span>
                        </label>
                        <div class="col-sm-8 col-md-8">
                            <input type="password" class="form-control Pwd" id="Pwd" name="Pwd" placeholder="Mật khẩu" required="" >
                            <p class="help-block">
                                Nhập mật khẩu mới của bạn và làm ơn <strong>ghi nhớ nó</strong> thật kỹ nhé
                            </p>
                        </div>
                    </div>
                    <div class="form-group">
                    <div class="col-sm-offset-4 col-sm-8">
                        <a data-id="<%=Id %>" href="javascript:;" class="btn btn-primary btn-lg savePwdBtn">
                            Lưu
                        </a>
                        <br/><br/>
                        <p class="alert alert-danger" style="display: none;"></p>
                        <p class="alert alert-success" style="display: none;"></p>
                    </div>
                </div>
                </div>
            </div>
        </div>      
      <%}
        else
        {%>
        <p class="alert alert-danger">
            Thông tin khôi phục của bạn không chính xác, vui lòng thử lại
        </p>
          <p>
                Điền thông tin vào ô dưới để khôi phục lại mật khẩu
            </p>
            <hr class="hr comment-hr"/>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div role="form" class="recoverPasswordPnl">
                        <div class="form-group">
                            <label class="col-sm-4 col-md-4 control-label" for="Email2">
                                <span class="pull-right">E-mail:</span>
                            </label>
                            <div class="col-sm-8 col-md-8">
                                <input type="text" class="form-control Email" id="Email2" name="Email" placeholder="Địa chỉ e-mail của bạn" required="" >
                                <p class="help-block">
                                    Nhập địa chỉ e-mail của bạn để tiến hành khôi phục mật khẩu
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                        <div class="col-sm-offset-4 col-sm-8">
                            <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">
                                Khôi phục
                            </a>
                            <br/><br/>
                            <p class="alert alert-danger" style="display: none;"></p>
                            <p class="alert alert-success" style="display: none;"></p>
                        </div>
                    </div>
                    </div>
                </div>
            </div>      
       <% } %>
    
     <% } %>
</div>