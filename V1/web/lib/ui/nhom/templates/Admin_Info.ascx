<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin_Info.ascx.cs" Inherits="lib_ui_nhom_templates_Admin_Info" %>
<%@ Register Src="~/lib/ui/account/ChangeAlias.ascx" TagPrefix="uc1" TagName="ChangeAlias" %>
<%if(!Item.Duyet){ %>
    <p class="alert alert-danger">
        Cộng đồng chưa được duyệt do đó người khác bạn chưa thể truy cập<br/>
        Nếu bạn thấy vội hãy liên lạc bằng cách e-mail: <a href="mailto:support@xetui.vn">support@xetui.vn</a>
    </p>
<%} %>
<div class="panel panel-default">
    <div class="panel-heading">
        Thông tin nhóm
        <a href="#group-admin" name="group-admin-info" class="btn btn-default btn-sm pull-right">
            <i class="glyphicon glyphicon-arrow-up"></i>
        </a>
    </div>
    <div class="panel-body">
        <form class="form-horizontal nhom-edit-form" role="form">
            <input type="hidden" name="Id"  value="<%=Item.Id %>"/>
            <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
            <%if(Item.Duyet){ %>
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Địa chỉ:</label>
                <div class="col-sm-10">
                    <%if (string.IsNullOrEmpty(Obj.Alias)){ %>
                        <button class="btn btn-link btnChangeAlias" data-id="<%=Obj.RowId %>" data-toggle="modal" data-target="#changeAliasModal">Tạo địa chỉ ngắn</button>
                    <%}else
                        {%>
                            <a href="/<%=Obj.Alias %>">http://xetui.vn/<%=Obj.Alias %></a>  - <button class="btn  btn-link ChangeAlias" data-id="<%=Obj.RowId %>" data-toggle="modal" data-target="#changeAliasModal">Đổi địa chỉ</button>      
                        <% } %>
                </div>
            </div>
            <%} %>
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Tên </label>
                <div class="col-sm-10">
                    <input type="text" class="form-control Ten" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tên cộng đồng">
                </div>
            </div>
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Ảnh</label>
                <div class="col-sm-10">
                    <textarea type="text" class="form-control MoTa" id="MoTa" name="MoTa" rows="3" placeholder="Mô tả cộng đồng"><%=Item.MoTa %></textarea>
                </div>
            </div>
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Mô tả</label>
                <div class="col-sm-10">
                    <div class="user-avatar user-avatar-180 nhom-avatar">
                        <img class="user-avatar-img img-thumbnail" src="/lib/up/nhom/<%=Item.Anh %>" alt="<%=Item.Anh %>" />
                        <div class="changeBtn-box">
                            <a href="javascript:;" class="btn btn-success changeBtn">Đổi ảnh</a>                            
                        </div>
                        <input type="hidden" name="Anh" class="Anh"  value="<%=Item.Anh %>"/>
                    </div>
                    <p class="help-block">
                        Ảnh đại diện cho cộng đồng quan trọng vô cùng bạn ạ.
                    </p>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                <textarea class="form-control GioiThieu" name="GioiThieu" id="GioiThieu" rows="10">
                    <%=Item.GioiThieu %>
                </textarea>                
                </div>
            </div>
            <div class="form-group">
                <label for="Duyet" class="col-sm-2 col-md-2 control-label">Trạng thái</label>
                <div class="col-sm-8 col-md-8">
                    <div class="checkbox">
                        <label>
                            <%if (Item.NhomMo)
                              { %>
                                <input name="NhomMo" checked="checked" class="NhomMo" id="NhomMo" type="checkbox"> Mở
                            <%}else{ %>
                                <input name="NhomMo" class="NhomMo" id="NhomMo" type="checkbox"> Đóng
                            <%} %>
                        </label>
                        <p class="help-block">
                            <strong>Mở</strong>: Thành viên có thể đăng bài<br/>
                            <strong>Đóng</strong>: Bài đăng thành viên cần kiểm duyệt
                        </p>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">                    
                    <a href="javascript:;" class="btn btn-primary btn-lg saveNhomBtn">Lưu thay đổi</a>
                    <br/><br/>
                    <p class="alert alert-danger" style="display: none;"></p>
                    <p class="alert alert-success" style="display: none;"></p>
                </div>
            </div>
        </form>
    </div>    
</div>
<uc1:ChangeAlias runat="server" ID="ChangeAlias" />
