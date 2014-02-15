<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploaderV1.ascx.cs" Inherits="lib_ui_HeThong_UploaderV1" %>
<%@ Register src="~/lib/ui/cars/templates/anh-item.ascx" tagPrefix="temp" tagName="anhItem" %>
<div class="car-add-upload upload-anh-box" data-id="<%=RowId %>">
        <div class="row">
            <span class="col-sm-offset-2 col-sm-10">
                <span class="btn btn-success btn-lg car-add-upload-box">
                    <i class="glyphicon glyphicon-plus"></i>
                    <span>Chọn ảnh</span>
                    <!-- The file input field used as target for the file upload widget -->
                    <input type="file" multiple="" class="car-multipleUpload-btn" name="files[]" id="fileupload">
                </span>
            </span>    
        </div>
        <div id="progress" class="progress" style="display: none;">
            <div class="progress-bar progress-bar-success"></div>
        </div>
        <div class="well well-lg view-large car-add-upload-dropzone">
            <asp:Repeater runat="server" ID="AnhList" Visible="False">
                <ItemTemplate>
                    <temp:anhItem ID="anhItem" runat="server" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater> 
        </div>
    </div>
<script id="anh-item" type="text/x-jquery-tmpl">
    <div class="row item-anh-uploadPreview" data-id="${Id}">
        <div class="checkbox">            
            <button class="btn btn-primary insert" data-src="${Thumbnail_url}" data-id="${Id}" style="margin-bottom: 10px;">Chèn</button> 
            <button class="btn btn-primary apply" data-id="${Id}" style="margin-bottom: 10px;">Cắt ảnh</button> 
            <button class="btn btn-warning removeBtn" data-id="${Id}" style="margin-bottom: 10px;">Xóa</button>
            <label>
                <input name="AnhBia" type="radio" data-src="${Thumbnail_url}" class="setBiaBtn" data-id="${Id}" title="Đặt làm ảnh đại diện của xe"/> Chọn làm ảnh đại diện
            </label>
        </div>    
        <div class="anh-img-box img-thumbnail">
            <img src="/lib/up/crop/${Thumbnail_url}" class="anh-img img-responsive"/>
            <img src="/lib/up/crop/${Thumbnail_url}" data-id="${Id}" data-key="${Thumbnail_url}" class="anh-fix img-responsive"/>
        </div>
        <input name="key" value="${Thumbnail_url}" type="hidden"/>
        <input name="Id" class="Id" value="${Id}" type="hidden"/>
        <input name="x" class="x" type="hidden"/>
        <input name="y"  class="y" type="hidden"/>
        <input name="x1" class="x1" type="hidden"/>
        <input name="y1" class="y1" type="hidden"/>
        <input name="w" class="w" type="hidden"/>
        <input name="h" class="h" type="hidden"/>
    <hr/>
    </div>
</script>
<link href="/lib/js/jCrop/jquery.Jcrop.min.css" rel="stylesheet" type="text/css" />
<script src="/lib/js/jCrop/jquery.Jcrop.min.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.iframe-transport.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.ui.widget.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.fileupload.js" type="text/javascript"></script>