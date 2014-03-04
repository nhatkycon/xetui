<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploaderV2.ascx.cs" Inherits="lib_ui_HeThong_UploaderV2" %>
<%@ Register TagPrefix="temp" TagName="anhItem" Src="~/lib/ui/cars/templates/anh-item.ascx" %>
<%@ Register Src="~/lib/ui/cars/templates/anh-item-v2.ascx" TagPrefix="temp" TagName="anhitemv2" %>

<div class="car-add-upload uploaderBox hangXeDdl" data-id="<%=RowId %>">
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
            <div class="well well-lg car-add-upload-dropzone">
                <div class="row view-large">
                    <asp:Repeater runat="server" ID="AnhList" Visible="False">
                        <ItemTemplate>
                            <temp:anhitemv2 runat="server" ID="anhitemv2"  Item='<%# Container.DataItem %>' />
                            <%--<temp:anhItem ID="anhItem" runat="server" Item='<%# Container.DataItem %>' />--%>
                        </ItemTemplate>
                    </asp:Repeater> 
                </div>                
            </div>
        </div>
        <script id="anh-item" type="text/x-jquery-tmpl">
            <div class="col-md-3 item-anh-uploadPreview" data-id="${Id}">            
                <div class="dropdown">
                    <a  class="btn btn-default" id="${Id}" role="button" data-toggle="dropdown" data-target="#">
                        <i class="glyphicon glyphicon-cog"></i>
                        <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu" role="menu" aria-labelledby="${Id}">
                        <li>
                        <a href="javascript:;" class="insert" data-src="${Thumbnail_url}" data-id="${Id}" style="margin-bottom: 10px;">Chèn</a>
                        </li>
                        <li>
                        <a href="javascript:;" class="editBtn" data-src="${Thumbnail_url}" data-id="${Id}" style="margin-bottom: 10px;">Sửa ảnh</a> 
                        </li>
                        <li>
                        <a href="javascript:;" class="removeBtn" data-id="${Id}" style="margin-bottom: 10px;">Xóa</a>
                        </li>
                        <li>
                            <a href="javascript:;">
                                <label>
                                <input name="AnhBia" type="radio" data-src="${Thumbnail_url}" class="setBiaBtn" data-id="${Id}" title="Đặt làm ảnh đại diện của xe"/>&nbsp;Chọn làm ảnh đại diện
                            </label>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="anh-img-box img-thumbnail">
                    <img src="/lib/up/car/${Thumbnail_url}?w=180&h=101"  data-key="${Thumbnail_url}" class="anh-img img-responsive"/>
                </div>
            </div>
        </script>
        <div class="modal fade" id="cropImageModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">
                    Sửa ảnh
                </h4>
              </div>
                <div class="modal-body">
                    <p class="alert alert-info">Ảnh nên để độ phân giải 960 X  540</p>
                    <div class="cropImageModal-imgBox" style="width: 960px;">
                        <img id="cropImageModal-img" class=""/>
                        <input name="key" class="key" value="" type="hidden"/>
                        <input name="Id" class="Id" value="" type="hidden"/>
                        <input name="x" class="x" type="hidden"/>
                        <input name="y"  class="y" type="hidden"/>
                        <input name="x1" class="x1" type="hidden"/>
                        <input name="y1" class="y1" type="hidden"/>
                        <input name="w" class="w" type="hidden"/>
                        <input name="h" class="h" type="hidden"/>
                    </div>
                </div>
              <div class="modal-footer">                
                <button type="button" class="btn btn-primary btnApply" >Cắt ảnh</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Bỏ qua</button>
              </div>
            </div><!-- /.modal-content -->
          </div><!-- /.modal-dialog -->
        </div>

<link href="/lib/js/jCrop/jquery.Jcrop.min.css" rel="stylesheet" type="text/css" />
<script src="/lib/js/jCrop/jquery.Jcrop.min.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.iframe-transport.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.ui.widget.js" type="text/javascript"></script>
<script src="/lib/js/Html5MultiUpload/jquery.fileupload.js" type="text/javascript"></script>