<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_cars_Add" %>
<%@ Register src="~/lib/ui/HeThong/DanhMucListByLdmMa.ascx" tagPrefix="HeThong" tagName="DanhMucListByLdmMa" %>
<%@ Register Src="~/lib/ui/HeThong/NamSanXuat.ascx" TagPrefix="HeThong" TagName="NamSanXuat" %>

<div class="padding-20 car-add-pnl">
    <form class="form-horizontal car-add-form" role="form">
        <input type="hidden" name="Id"  value="<%=Item.ID %>"/>
        <input type="hidden" name="RowId" class="RowId"  value="<%=Item.ID == 0 ? Guid.NewGuid() : Item.RowId %>"/>
        <div class="form-group">
            <label for="HANG_ID" class="col-sm-2 col-md-2 control-label">Hãng</label>
            <div class="col-sm-4 col-md-4">
                <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="HANG_ID" runat="server" ControlId="HANG_ID" ControlName="HANG_ID"/>
            </div>
            <label for="MODEL_ID" class="col-sm-2 col-md-2 control-label">Model</label>
            <div class="col-sm-4 col-md-4">
                <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="MODEL_ID" runat="server" ControlId="MODEL_ID" ControlName="MODEL_ID"/>
            </div>
        </div>
        <div class="form-group">
            <label for="SubModel" class="col-sm-2 col-md-2 control-label">Sub model</label>
            <div class="col-sm-4 col-md-4">
                <input type="text" class="form-control" id="SubModel" value="<%=Item.SubModel %>" name="SubModel" placeholder="Sub model">
            </div>
            <label for="Nam" class="col-sm-2 col-md-2 control-label">Năm sản xuất</label>
            <div class="col-sm-4 col-md-4">
                <HeThong:NamSanXuat runat="server" ID="Nam" ControlId="Nam" ControlName="Nam" ClientIDMode="Static" />
            </div>
        </div>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Tên</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tên">
            </div>
        </div>
        <div class="form-group">
            <label for="MoTa" class="col-sm-2 control-label">Giới thiệu</label>
            <div class="col-sm-10">
                <textarea class="form-control" name="MoTa" id="MoTa" rows="3"><%=Item.GioiThieu %></textarea>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <div class="checkbox">
                <label>
                    <input name="DangLai" type="checkbox"> Hiện tôi không dùng xe này, chỉ đưa lên để nhớ về nó.
                </label>
                </div>
            </div>
        </div>
        <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
            <br/><br/>
            <p class="alert alert-danger" style="display: none;"></p>
            <p class="alert alert-success" style="display: none;"></p>
        </div>
        </div>
    </form> 
    <div class="car-add-upload">
        <span class="btn btn-success car-add-upload-box">
            <i class="glyphicon glyphicon-plus"></i>
            <span>Chọn ảnh</span>
            <!-- The file input field used as target for the file upload widget -->
            <input type="file" multiple="" class="car-multipleUpload-btn" name="files[]" id="fileupload">
        </span> 
        <div id="progress" class="progress progress-striped" style="display: none;">
            <div class="bar progress_bar"></div>
        </div>
        <div class="well well-lg view-large car-add-upload-dropzone">
        </div>
    </div>
</div>
<script id="model-item" type="text/x-jquery-tmpl"> 
    <option value="${ID}">${Ten}</option> 
</script>
<script id="anh-item" type="text/x-jquery-tmpl">
    <div class="row item-anh-uploadPreview" data-id="${Id}">
        <div class="col-md-11">
            <div class="anh-img-box img-thumbnail">
                <img src="/lib/up/crop/${Thumbnail_url}" class="anh-img"/>
                <img src="/lib/up/crop/${Thumbnail_url}" data-id="${Id}" data-key="${Thumbnail_url}" class="anh-fix"/>
            </div>
        </div>    
        <div class="col-md-1">
            <button class="btn btn-primary apply" data-id="${Id}" style="margin-bottom: 10px;">Cắt ảnh</button><br/>
            <button class="btn btn-warning" data-id="${Id}" style="margin-bottom: 10px;">Xóa</button>
        </div>
        <input name="key" value="${Thumbnail_url}" type="hidden"/>
        <input name="Id" class="Id" value="${Id}" type="hidden"/>
        <input name="x" class="x" type="hidden"/>
        <input name="y"  class="y" type="hidden"/>
        <input name="x1" class="x1" type="hidden"/>
        <input name="y1" class="y1" type="hidden"/>
        <input name="w" class="w" type="hidden"/>
        <input name="h" class="h" type="hidden"/>
    </div>
    <hr/>
</script>
<link href="/lib/js/jCrop/jquery.Jcrop.min.css" rel="stylesheet" type="text/css" />
<script src="/lib/js/jCrop/jquery.Jcrop.min.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.iframe-transport.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.ui.widget.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.fileupload.js" type="text/javascript"></script>