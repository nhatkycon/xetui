<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_promoted_Add" %>
<%@ Import Namespace="linh.common" %>
<form class="form-horizontal promoted-add-pnl" role="form">
        <input type="hidden" name="Id"  value="<%=Item.ID %>"/>
        <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
        <div class="form-group">
            <label for="Loai" class="col-sm-2 col-md-2 control-label">Loại</label>
            <div class="col-sm-4 col-md-4">
                <select name="Loai" class="form-control Loai">
                    <option value="0">--</option>
                    <option value="1">
                        Xe Top
                    </option>
                    <option value="2">
                        Xe Home Big
                    </option>
                    <option value="3">
                        Xe Home Medium
                    </option>
                    <option value="4">
                        Xe Home Small
                    </option>
                    <option value="5">
                        Xe View
                    </option>
                    <option value="10">
                        Other
                    </option>
                </select>
            </div>
            <label for="PRowId" class="col-sm-2 col-md-2 control-label">PRowId</label>
            <div class="col-sm-10 col-md-4">
                <input type="text" class="form-control" id="PRowId" value="<%=Item.PRowId %>" name="PRowId" placeholder="ID cha">
            </div>
        </div>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 col-md-2 control-label"></label>
            <div class="col-sm-10 col-md-10">
                <input type="text" class="form-control" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tiêu đề 200 ký tự">
            </div>
        </div>
        <div class="form-group">
            <label for="MoTa" class="col-sm-2 col-md-2 control-label">Mô tả</label>
            <div class="col-sm-4 col-md-4">
                <textarea class="form-control MoTa" name="MoTa" id="MoTa" rows="6"><%=Item.MoTa %></textarea>
            </div>
            <label for="Keywords" class="col-sm-2 col-md-2 control-label">Keywords</label>
            <div class="col-sm-4 col-md-4">
                <textarea class="form-control Keywords" name="Keywords" id="Keywords" rows="6"><%=Item.Keywords%></textarea>
            </div>
        </div>
        <div class="form-group">
            <label for="Url" class="col-sm-2 control-label">Url</label>
            <div class="col-sm-10 col-md-4">
                <textarea type="text" class="form-control" id="Url" value="<%=Item.Url %>" name="Url" placeholder="Url"></textarea>
            </div>
            <label for="NgayKetThuc" class="col-sm-2 control-label">refId</label>
            <div class="col-sm-10 col-md-4">
                <textarea type="text" class="form-control" id="refId" value="<%=Item.refId %>" name="refId" placeholder="refId"></textarea>
            </div>
        </div>
        <div class="form-group">
            <label for="NgayBatDau" class="col-sm-2 control-label">Ngày bắt đầu</label>
            <div class="col-sm-10 col-md-4">
                <div id="TuNgayPicker" class="input-append date input-group DatePickerInput">
                    <input 
                        data-format="dd/MM/yyyy" 
                        class="form-control NgayBatDau" 
                        name="NgayBatDau" 
                        type="text"
                        id="NgayBatDau"
                        value="<%=(Item.NgayBatDau != DateTime.MinValue) ? Item.NgayBatDau.ToString("dd/MM/yy") : "" %>"/>
                    <span class="add-on input-group-addon">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                        </i>
                    </span>
                </div>
                <p class="help-block"><%=DateTime.Now.ToString("dd/MM/yyyy")%></p>
            </div>
            <label for="NgayKetThuc" class="col-sm-2 control-label">Ngày kết thúc</label>
            <div class="col-sm-10 col-md-4">
                <div id="DenNgayPicker" class="input-append date input-group DatePickerInput">
                    <input 
                        data-format="dd/MM/yyyy" 
                        class="form-control NgayKetThuc" 
                        name="NgayKetThuc" 
                        type="text" id="NgayKetThuc" value="<%=(Item.NgayKetThuc != DateTime.MinValue) ? Item.NgayKetThuc.ToString("dd/MM/yy") : "" %>"/>
                    <span class="add-on input-group-addon">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                        </i>
                    </span>
                </div>
                <p class="help-block"><%=DateTime.Now.ToString("dd/MM/yyyy") %></p>
            </div>
        </div>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Ảnh</label>
            <div class="col-sm-10">
                <div class="user-avatar user-avatar-180 promoted-avatar">
                    <img class="user-avatar-img img-thumbnail" src="/lib/up/promoted/<%=Item.Anh %>" alt="<%=Item.Anh %>" />
                    <div class="changeBtn-box">
                        <a href="javascript:;" class="btn btn-success changeBtn">Đổi ảnh</a>                            
                    </div>
                    <input type="hidden" name="Anh" class="Anh"  value="<%=Item.Anh %>"/>
                </div>
                <p class="help-block">
                    rộng 300px
                </p>
            </div>
        </div>
        <div class="form-group">
            <label for="Clicked" class="col-sm-2 control-label">Clicks</label>
            <div class="col-sm-10 col-md-4">
                <input type="text" class="form-control" id="Clicked" value="<%=Item.Clicked %>" name="Clicked" placeholder=""></input>
            </div>
            <label for="Views" class="col-sm-2 control-label">Views</label>
            <div class="col-sm-10 col-md-4">
                <input type="text" class="form-control" id="Views" value="<%=Item.Views %>" name="Views" placeholder=""></input>
            </div>
        </div>
        <div class="form-group">
            <label for="Approved" class="col-sm-2 control-label">Tình trạng</label>
            <div class="col-sm-offset-2 col-sm-10">
                <div class="checkbox">
                    <label>
                        <%if (!Item.Approved)
                          { %>
                          <input name="Approved" class="Approved" id="Approved" type="checkbox">
                        <%}else{ %>
                            <input name="Approved" checked="checked" class="Approved" id="Approved" type="checkbox">
                                Duyệt
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
                
                <%if(Item.Approved){ %>
                    <p class="help-block">
                        <%=Item.NguoiTao %> ngày <%=Lib.TimeDiff(Item.NgayTao)%>
                    </p>
                <%} %>
                <br/><br/>
                <p class="alert alert-danger" style="display: none;"></p>
                <p class="alert alert-success" style="display: none;"></p>
            </div>
        </div>
    </form>
<%if(Item.ID!=0){ %>
<script>
    $(function () {
        var pnl = $('.promoted-add-pnl');
        pnl.find('.Loai').val('<%=Item.Loai %>');
    });
</script>
<%} %>