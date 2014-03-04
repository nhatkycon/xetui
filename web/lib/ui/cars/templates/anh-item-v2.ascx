<%@ Control Language="C#" AutoEventWireup="true" CodeFile="anh-item-v2.ascx.cs" Inherits="lib_ui_cars_templates_anh_item_v2" %>
<div class="col-md-3 item-anh-uploadPreview<%=Item.AnhBia ? " item-anh-uploadPreview-anhBia" : "" %>" data-id="<%=Item.Id %>">
    <div class="dropdown">
        <a id="<%=Item.Id %>" role="button" class="btn btn-default" data-toggle="dropdown" data-target="#">
                <i class="glyphicon glyphicon-cog"></i>
                <span class="caret"></span>
         </a>
        <ul class="dropdown-menu" role="menu" aria-labelledby=""<%=Item.Id %>">
            <li>
                <a href="javascript:;" class="insert" data-src="/lib/up/car/<%=Item.FileAnh %>" data-id="<%=Item.Id %>">Chèn</a>             
            </li>
            <li>
                <a href="javascript:;" class="editBtn" data-src="<%=Item.FileAnh %>" data-id="<%=Item.Id %>">Sửa ảnh</a> 
            </li>
            <li>
                <a href="javascript:;" class="removeBtn" data-id="<%=Item.Id %>">Xóa</a>
            </li>
            <li>
                <a  href="javascript:;">
                    <label>
                        <%if(Item.AnhBia){ %>
                        <input name="AnhBia" checked="checked" type="radio" data-src="<%=Item.FileAnh %>" class="setBiaBtn" data-id="<%=Item.Id %>" title="Đặt làm ảnh đại diện của xe"/> Chọn làm ảnh đại diện
                        <%}
                            else
                            { %>
                        <input name="AnhBia" type="radio" data-src="<%=Item.FileAnh %>" class="setBiaBtn" data-id="<%=Item.Id %>" title="Đặt làm ảnh đại diện của xe"/> Chọn làm ảnh đại diện
                        <%} %>
                    </label>
                </a>
            </li>
        </ul>
    </div>
    <div class="anh-img-box img-thumbnail">
        <img data-key="<%=Item.FileAnh %>" src="/lib/up/car/<%=Item.FileAnh %>?w=180&h=101" class="anh-img img-responsive"/>
    </div>
<hr/>
</div>
