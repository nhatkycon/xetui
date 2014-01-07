<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_blog_Add" %>
<%@ Register src="~/lib/ui/cars/templates/anh-item.ascx" tagPrefix="temp" tagName="anhItem" %>
<div class="padding-20 blog-add-pnl">
    <% switch (Item.Loai)
       {%>
    <%case 1: %>
    <div class="h3-subtitle">
        <a href="<%=Item.Profile.Url %>/blogs/">
            <%=Item.Profile.Ten %>
        </a>
    </div>
    <% break; %>
    
    <%case 2: %>
    <div class="h3-subtitle">
        <a href="<%=Item.Xe.XeUrl %>blogs/">
            Nhật ký hành trình
        </a>
    </div>
    <% break; %>
    
    <%case 3: %>
    
    <% break; %>

    <% } %>
    <hr class="hr comment-hr"/>
    <form class="form-horizontal blog-add-form" role="form">
        <input type="hidden" name="Id"  value="<%=Item.ID %>"/>
        <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
        <input type="hidden" name="PID_ID" class="PID_ID"  value="<%=Item.PID_ID %>"/>
        <input type="hidden" name="Loai" class="Loai"  value="<%=Item.Loai %>"/>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Tiêu đề</label>
            <div class="col-sm-10">
                <input type="text" class="form-control Ten" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tiêu đề blog">
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-12">
            <textarea class="form-control NoiDung" name="NoiDung" id="NoiDung" rows="10"><%=Item.NoiDung %></textarea>                
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
    <div class="blog-add-upload upload-anh-box" data-id="<%=Item.RowId %>">
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
        <div id="progress" class="progress progress-striped" style="display: none;">
            <div class="bar progress_bar"></div>
        </div>
        <div class="well well-lg view-large car-add-upload-dropzone">
            <asp:Repeater runat="server" ID="AnhList" Visible="False">
                <ItemTemplate>
                    <temp:anhItem ID="anhItem" runat="server" Item='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater> 
        </div>
        
    </div>
</div>
<script id="model-item" type="text/x-jquery-tmpl"> 
    <option value="${ID}">${Ten}</option> 
</script>
<script id="anh-item" type="text/x-jquery-tmpl">
    <div class="row item-anh-uploadPreview" data-id="${Id}">
        <div class="checkbox">            
            <button class="btn btn-primary apply" data-id="${Id}" style="margin-bottom: 10px;">Cắt ảnh</button> 
            <button class="btn btn-warning removeBtn" data-id="${Id}" style="margin-bottom: 10px;">Xóa</button>
            <label>
                <input name="AnhBia" type="radio" data-src="${Thumbnail_url}" class="setBiaBtn" data-id="${Id}" title="Đặt làm ảnh đại diện của xe"/> Chọn làm ảnh đại diện của xe
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
<%if(!string.IsNullOrEmpty(Id)){ %>
    <script>
        $(function () {
            
        });
    </script>
<%} %>