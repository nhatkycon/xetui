<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_cars_Add" %>
<%@ Register src="~/lib/ui/HeThong/DanhMucListByLdmMa.ascx" tagPrefix="HeThong" tagName="DanhMucListByLdmMa" %>
<%@ Register Src="~/lib/ui/HeThong/NamSanXuat.ascx" TagPrefix="HeThong" TagName="NamSanXuat" %>
<%@ Register src="~/lib/ui/cars/templates/anh-item.ascx" tagPrefix="temp" tagName="anhItem" %>
<div class="padding-20 car-add-pnl">
    <form class="form-horizontal car-add-form" role="form">
        <input type="hidden" name="Id"  value="<%=Item.ID %>"/>
        <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
        <input type="hidden" name="AdminKey" class="AdminKey"  value="<%=IsAdmin %>"/>
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
            <label for="GioiThieu" class="col-sm-2 control-label">Giới thiệu</label>
            <div class="col-sm-10">
                <textarea class="form-control GioiThieu" name="GioiThieu" id="GioiThieu" rows="6"><%=Item.GioiThieu %></textarea>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <div class="checkbox">
                    <label>
                        <%if (Item.DangLai)
                          { %>
                          <input name="DangLai" class="DangLai" id="DangLai" type="checkbox">
                        <%}else{ %>
                            <input name="DangLai" checked="checked" class="DangLai" id="Checkbox1" type="checkbox">
                        <%} %>
                         Tôi đang sử dụng nó
                    </label>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <a href="javascript:;" data-toggle="collapse" data-target="#car-add-more" class="btn btn-link">Thêm chi tiết</a>
            </div>
        </div>
        <div class="collapse" id="car-add-more">
            <div class="form-group">
                <label for="XuatXu" class="col-sm-2 col-md-2 control-label">Xuất xứ</label>
                <div class="col-sm-4 col-md-4">
                    <select class="form-control" id="XuatXu" name="XuatXu">
                        <option value="true">Trong nước</option>
                        <option value="false">Nhập khẩu</option>
                    </select>
                </div>
            
                <label for="TinhTrang" class="col-sm-2 col-md-2 control-label">Tình trạng</label>
                <div class="col-sm-4 col-md-4">
                    <select class="form-control" id="TinhTrang" name="TinhTrang">
                        <option value="true">Xe mua mới</option>
                        <option value="false">Xe mua cũ</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="HopSo" class="col-sm-2 col-md-2 control-label">Loại hộp số</label>
                <div class="col-sm-4 col-md-4">
                    <select class="form-control" id="HopSo" name="HopSo">
                        <option value="true">Tự động</option>
                        <option value="false">Số sàn</option>
                    </select>
                </div>

                <label for="DONGXE_ID" class="col-sm-2 col-md-2 control-label">Dòng xe</label>
                <div class="col-sm-4 col-md-4">
                    <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="DONGXE_ID" runat="server" ControlId="DONGXE_ID" ControlName="DONGXE_ID"/>
                </div>
            </div>
            
            <div class="form-group">
                <label for="MAUNGOAITHAT_ID" class="col-sm-2 col-md-2 control-label">Màu ngoại thất</label>
                <div class="col-sm-4 col-md-4">
                    <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="MAUNGOAITHAT_ID" runat="server" ControlId="MAUNGOAITHAT_ID" ControlName="MAUNGOAITHAT_ID"/>
                </div>
            
                <label for="MAUNOITHAT_ID" class="col-sm-2 col-md-2 control-label">Màu nội thất</label>
                <div class="col-sm-4 col-md-4">
                    <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="MAUNOITHAT_ID" runat="server" ControlId="MAUNOITHAT_ID" ControlName="MAUNOITHAT_ID"/>
                </div>
            </div>
            
            <div class="form-group">
                <label for="KIEUDANDONG_ID" class="col-sm-2 col-md-2 control-label">Kiểu dẫn động</label>
                <div class="col-sm-4 col-md-4">
                    <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="KIEUDANDONG_ID" runat="server" ControlId="KIEUDANDONG_ID" ControlName="KIEUDANDONG_ID"/>
                </div>                        
            
                <label for="NHIENLIEU_ID" class="col-sm-2 col-md-2 control-label">Nhiên liệu</label>
                <div class="col-sm-4 col-md-4">
                    <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="NHIENLIEU_ID" runat="server" ControlId="NHIENLIEU_ID" ControlName="NHIENLIEU_ID"/>
                </div>
            </div>
            
            
            <div class="form-group">
                <label for="THANHPHO_ID" class="col-sm-2 col-md-2 control-label">Thành phố</label>
                <div class="col-sm-4 col-md-4">
                    <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="THANHPHO_ID" runat="server" ControlId="THANHPHO_ID" ControlName="THANHPHO_ID"/>
                    <p class="help-block">
                        Bạn đang chạy ở tỉnh nào?
                    </p>
                </div>
            </div>
            
            
            <div class="form-group">
                <label for="RaoBan" class="col-sm-2 col-md-2 control-label">Rao bán</label>
                <div class="col-sm-4 col-md-4">
                    <div class="checkbox">
                        <label>
                            <%if(Item.RaoBan){ %>
                                <input name="RaoBan" checked="checked" class="RaoBan" id="Checkbox2" type="checkbox"> Nếu bạn muốn bán hãy tick vào đây
                            <%}else{ %>
                                <input name="RaoBan" class="RaoBan" id="RaoBan" type="checkbox"> Nếu bạn muốn bán hãy tick vào đây
                            <%} %>
                        </label>
                    </div>
                </div>
           
                <label for="Gia" class="col-sm-2 col-md-2 control-label">Giá bán</label>
                <div class="col-sm-4 col-md-4">
                    <input type="number" class="form-control" id="Gia" value="<%=Item.Gia %>" name="Gia" placeholder="Giá bán">
                </div>
            </div>
            
        </div>
        <%if(IsAdmin){ %>
        <div class="form-group">
            <label for="RaoBan" class="col-sm-2 col-md-2 control-label">Trạng thái</label>
            <div class="col-sm-4 col-md-4">
                <div class="checkbox">
                    <label>
                        <%if(Item.Duyet){ %>
                            <input name="Duyet" checked="checked" class="Duyet" id="Duyet" type="checkbox"> Đã duyệt: <%=Item.NgayDuyet.ToString("hh:mm dd/MM/yyyy") %> - <%=Item.NguoiDuyet %>
                        <%}else{ %>
                            <input name="Duyet" class="Duyet" id="Duyet" type="checkbox"> Chưa duyệt
                        <%} %>
                    </label>
                </div>
            </div>
        </div>
        <%} %>
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
    <div class="car-add-upload upload-anh-box" data-id="<%=Item.RowId %>">
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
            var carAddPnl = $('.car-add-pnl');
            carAddPnl.find('.HANG_ID').val('<%=Item.HANG_ID %>');
            var MODEL_ID = carAddPnl.find('.MODEL_ID');
            var data = [];
            data.push({ name: 'subAct', value: 'GetModelByHangXe' });
            data.push({ name: 'DM_PID', value: '<%=Item.HANG_ID %>' });
            MODEL_ID.find('option').remove();
            MODEL_ID.html('<option>...</option>');
            $.ajax({
                url: autoFn.url.car
                , type: 'POST'
                , data: data
                , dataType: 'SCRIPT'
                , success: function (rs) {
                    MODEL_ID.find('option').remove();
                    var models = JSON.parse(rs);
                    MODEL_ID.find('option').remove();
                    $.each(models, function (i, item) {
                        var modelItem = $('#model-item').tmpl(item).prependTo(MODEL_ID);
                    });
                    MODEL_ID.val('<%=Item.MODEL_ID %>');                    
                }
            });

            carAddPnl.find('.Nam').val('<%=Item.Nam %>');
            carAddPnl.find('.XuatXu').val('<%=Item.XuatXu %>');
            carAddPnl.find('.TinhTrang').val('<%=Item.TinhTrang.ToString().ToLower() %>');
            carAddPnl.find('.DONGXE_ID').val('<%=Item.DONGXE_ID %>');
            carAddPnl.find('.MAUNGOAITHAT_ID').val('<%=Item.MAUNGOAITHAT_ID %>');
            carAddPnl.find('.MAUNOITHAT_ID').val('<%=Item.MAUNOITHAT_ID %>');
            carAddPnl.find('.HopSo').val('<%=Item.HopSo.ToString().ToLower() %>');
            carAddPnl.find('.KIEUDANDONG_ID').val('<%=Item.KIEUDANDONG_ID %>');
            carAddPnl.find('.NHIENLIEU_ID').val('<%=Item.NHIENLIEU_ID %>');
            carAddPnl.find('.THANHPHO_ID').val('<%=Item.THANHPHO_ID %>');
        });
        
    </script>
<%} %>