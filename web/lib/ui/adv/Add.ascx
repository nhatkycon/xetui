<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_adv_Add" %>
<%@ Import Namespace="linh.common" %>
<div class="panel panel-default">
    <div class="panel-heading">
        <a href="/lib/mod/Adv/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>            
    </div>
    <div class="panel-body">
        <form class="form-horizontal Adv-add-pnl" role="form">
                <input type="hidden" name="Id"  value="<%=Item.ID == Guid.Empty ? ""  : Item.ID.ToString() %>"/>                
                <div class="form-group">
                    <label for="Loai" class="col-sm-2 col-md-2 control-label">Loại</label>
                    <div class="col-sm-10 col-md-10">
                        <select name="Loai" class="form-control Loai">
                            <option value="0">--</option>
                            <option value="1010">
                                Home-Top-1000
                            </option>
                            <option value="1020">
                                Home-Bot-1000
                            </option>
                            <option value="1030">
                                Home-300
                            </option>
                            <option value="1110">
                                Xe-300
                            </option>
                            <option value="1210">
                                Profile-300
                            </option>
                            <option value="1410">
                                Community-300
                            </option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Ten" class="col-sm-2 col-md-2 control-label"></label>
                    <div class="col-sm-10 col-md-10">
                        <input type="text" class="form-control" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tiêu đề 200 ký tự">
                    </div>
                </div>
                <div class="form-group">
                    <label for="Ma" class="col-sm-2 col-md-2 control-label">Mã</label>
                    <div class="col-sm-4 col-md-4">
                        <textarea class="form-control Ma" name="Ma" id="Ma" rows="6"><%=Item.Ma %></textarea>
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
                    <label for="RowId" class="col-sm-2 control-label">RowId</label>
                    <div class="col-sm-10 col-md-4">
                        <input type="text" class="form-control" id="RowId" value="<%=Item.RowId %>" name="RowId" placeholder="RowId"/>
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
                    <label for="Ten" class="col-sm-2 control-label">Quảng cáo</label>
                    <div class="col-sm-10">
                        <textarea class="form-control NoiDung" rows="3" name="NoiDung" id="NoiDung"><%=Item.NoiDung %></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Clicks" class="col-sm-2 control-label">Clicks</label>
                    <div class="col-sm-10 col-md-4">
                        <input type="text" class="form-control" id="Clicks" value="<%=Item.Clicks %>" name="Clicks" placeholder=""></input>
                    </div>
                    <label for="Views" class="col-sm-2 control-label">Views</label>
                    <div class="col-sm-10 col-md-4">
                        <input type="text" class="form-control" id="Views" value="<%=Item.Views %>" name="Views" placeholder=""></input>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Flash" class="col-sm-2 control-label">Flash</label>
                    <div class="col-sm-4">
                        <div class="checkbox">
                            <label>
                                <%if (Item.Flash)
                                  { %>
                                    <input name="Flash" checked="checked" class="Flash" id="Flash" type="checkbox">                                        
                                <%}else{ %>
                                  <input name="Flash" class="Flash" id="Flash" type="checkbox">
                                <%} %>
                            </label>
                        </div>
                    </div>
                    <label for="Duyet" class="col-sm-2 control-label">Tình trạng</label>
                    <div class="col-sm-4">
                        <div class="checkbox">
                            <label>
                                <%if (Item.Duyet)
                                  { %>
                                    <input name="Duyet" checked="checked" class="Duyet" id="Duyet" type="checkbox"> Duyệt
                                <%}else{ %>
                                   <input name="Duyet" class="Duyet" id="Duyet" type="checkbox">
                                <%} %>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
                        <%if (Item.ID != Guid.Empty)
                          { %>
                        <a href="javascript:;" class="btn btn-danger btn-lg xoaBtn">Xóa</a>
                        <%} %>
                
                        <%if(Item.Duyet){ %>
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
    </div>
</div>

<%if(Item.ID!=Guid.Empty){ %>
<script>
    $(function () {
        var pnl = $('.Adv-add-pnl');
        pnl.find('.Loai').val('<%=Item.Loai %>');
    });
</script>
<%} %>