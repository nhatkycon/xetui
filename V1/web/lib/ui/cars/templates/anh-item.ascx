<%@ Control Language="C#" AutoEventWireup="true" CodeFile="anh-item.ascx.cs" Inherits="lib_ui_cars_templates_anh_item" %>
<div class="row item-anh-uploadPreview" data-id="<%=Item.Id %>">
    <div class="checkbox">
        <button class="btn btn-primary insert" data-src="/lib/up/car/<%=Item.FileAnh %>" data-id="<%=Item.Id %>" style="margin-bottom: 10px;">Chèn</button>             
        <button class="btn btn-warning removeBtn" data-id="<%=Item.Id %>" style="margin-bottom: 10px;">Xóa</button>
        <label>
            <%if(Item.AnhBia){ %>
            <input name="AnhBia" checked="checked" type="radio" data-src="<%=Item.FileAnh %>" class="setBiaBtn" data-id="<%=Item.Id %>" title="Đặt làm ảnh đại diện của xe"/> Chọn làm ảnh đại diện
            <%}
              else
              { %>
            <input name="AnhBia" type="radio" data-src="<%=Item.FileAnh %>" class="setBiaBtn" data-id="<%=Item.Id %>" title="Đặt làm ảnh đại diện của xe"/> Chọn làm ảnh đại diện
            <%} %>
        </label>
    </div>    
    <div class="anh-img-box img-thumbnail">
        <img src="/lib/up/car/<%=Item.FileAnh %>" class="anh-img img-responsive"/>
    </div>
<hr/>
</div>
