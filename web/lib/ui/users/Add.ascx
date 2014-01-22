<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_users_Add" %>

<div class="panel panel-default">
    <div class="panel-heading">
        <a href="/lib/mod/Users/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>            
    </div>
    <div class="panel-body">
        <div class="padding-20 user-add-pnl">
            <form class="form-horizontal user-add-form" role="form">
                <input type="hidden" name="Id"  value="<%=Item.ID %>"/>
                <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
                <div class="form-group">
                    <label for="Ten" class="col-md-2 control-label">
                        Tên
                    </label>
                    <div class="col-md-4">
                        <input type="text" class="form-control Ten" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tên thành viên">
                    </div>
                    <label for="Email" class="col-md-2 control-label">
                        E-mail
                    </label>
                    <div class="col-md-4">
                        <input type="text" class="form-control Email" id="Email" value="<%=Item.Email %>" name="Email" placeholder="E-mail">
                    </div>
                </div>
                <div class="form-group">
                    <label for="Username" class="col-md-2 control-label">
                        Username
                    </label>
                    <div class="col-md-4">
                        <input type="text" class="form-control Username" id="Username" value="<%=Item.Username %>" name="Username" placeholder="Username">
                    </div>
                    <label for="DiaChi" class="col-md-2 control-label">
                        Key
                    </label>
                    <div class="col-md-4">
                        <input type="text" class="form-control DiaChi" id="DiaChi" value="<%=Item.DiaChi %>" name="DiaChi" placeholder="Key">
                    </div>
                </div>
                <div class="form-group">
                    <label for="Password" class="col-sm-2 control-label">Mật khẩu</label>
                    <div class="col-sm-10">
                        <input type="password" class="form-control Password" id="Password" value="" name="Password" placeholder="Password">
                    </div>
                </div>
                <div class="form-group">
                    <label for="MoTa" class="col-sm-2 control-label">Mô tả</label>
                    <div class="col-sm-10">
                        <textarea type="text" class="form-control MoTa" id="MoTa" name="MoTa" rows="3" placeholder="Mô tả cộng đồng"><%=Item.Mota %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Anh" class="col-sm-2 control-label">Ảnh</label>
                    <div class="col-sm-10">
                        <div class="user-avatar user-avatar-180 nhom-avatar">
                            <img class="user-avatar-img img-thumbnail" src="/lib/up/users/<%=Item.Anh %>" alt="<%=Item.Anh %>" />
                            <input type="hidden" id="Anh" name="Anh" class="Anh"  value="<%=Item.Anh %>"/>
                        </div>
                        <p class="help-block">
                            Ảnh hồ sơ của cá nhân
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Active" class="col-sm-2 col-md-2 control-label">Trạng thái</label>
                    <div class="col-sm-4 col-md-4">
                        <div class="checkbox">
                            <label>
                                <%if(Item.Active){ %>
                                    <input name="Active" checked="checked" class="Active" id="Active" type="checkbox"> Khóa
                                <%}else{ %>
                                    <input name="Active" class="Active" id="Active" type="checkbox">
                                <%} %>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
                        <%if(Item.ID!=0){ %>
                            <a href="javascript:;" class="btn btn-danger btn-lg xoaBtn">Xóa</a>
                        <%} %>
                        <br/><br/>
                        <p class="alert alert-danger" style="display: none;"></p>
                        <p class="alert alert-success" style="display: none;"></p>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>