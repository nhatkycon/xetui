<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_nhom_Add" %>
<div class="padding-20 nhom-add-pnl">
    <%if(!IsAdmin){ %>
        <div class="h3-subtitle">
            <a href="/group/">
                Cộng đồng
            </a>&nbsp; &gt;
            Thêm cộng đồng
        </div>
        <hr class="hr comment-hr"/>
    <%}%>
    <form class="form-horizontal nhom-add-form" role="form">
        <input type="hidden" name="Id"  value="<%=Item.Id %>"/>
        <input type="hidden" name="RowId" class="RowId"  value="<%=Item.RowId %>"/>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Tên cộng đồng</label>
            <div class="col-sm-10">
                <input type="text" class="form-control Ten" id="Ten" value="<%=Item.Ten %>" name="Ten" placeholder="Tên cộng đồng">
            </div>
        </div>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Mô tả</label>
            <div class="col-sm-10">
                <textarea type="text" class="form-control MoTa" id="MoTa" name="MoTa" rows="3" placeholder="Mô tả cộng đồng"><%=Item.MoTa %></textarea>
            </div>
        </div>
        <div class="form-group">
            <label for="Ten" class="col-sm-2 control-label">Ảnh</label>
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
        <%if(IsAdmin){ %>
        <div class="form-group">
            <label for="Duyet" class="col-sm-2 col-md-2 control-label">Trạng thái</label>
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
        <%}%>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <%if(!IsAdmin){ %>
                <div class="checkbox">
                    <label>
                        <input type="checkbox" id="dongY"> 
                        <b>Bạn cần đồng ý</b><br/>
                        - Không lừa đảo, xúc phạm<br/>
                        - Không mạo danh và quảng cáo<br/>
                    </label>
                </div>
                <br/><br/>
                <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
                 <%}
                  else
                  {%>
                <a href="javascript:;" class="btn btn-primary btn-lg adminSaveBtn">Lưu thay đổi</a>
                <%  }%>
                <%if(Item.Id!=0){ %>
                    <a href="javascript:;" class="btn btn-danger btn-lg xoaBtn">Xóa</a>
                <%} %>
                <br/><br/>
                <p class="alert alert-danger" style="display: none;"></p>
                <p class="alert alert-success" style="display: none;"></p>
            </div>
        </div>
    </form>
</div>