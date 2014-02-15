<%@ Control Language="C#" AutoEventWireup="true" CodeFile="myAccount.ascx.cs" Inherits="lib_ui_account_myAccount" %>
<%@ Register src="~/lib/ui/HeThong/DanhMucListByLdmMa.ascx" tagPrefix="HeThong" tagName="DanhMucListByLdmMa" %>
<%@ Register src="~/lib/ui/account/ChangeAlias.ascx" tagPrefix="account" tagName="ChangeAlias" %>
<div class="padding-20">
    <div class="page-header">
        <h1>Trang cá nhân</h1>        
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="user-avatar user-avatar-180 myAccount-avatar">
                <img class="user-avatar-img img-thumbnail" src="/lib/up/users/<%=User.Anh %>" alt="<%=User.Anh %>" />
                <div class="changeBtn-box">
                    <a href="javascript:;" class="btn btn-success changeBtn">Đổi ảnh</a>                            
                </div>
            </div>
        </div>
        <hr class="hr comment-hr visible-xs visible-sm"/>
        <div class="col-md-8">
            <form class="form-horizontal myAccount-form" role="form">
                <div class="form-group">
                    <label for="Ten" class="col-sm-2 control-label">Địa chỉ:</label>
                    <div class="col-sm-10">
                        <%if (string.IsNullOrEmpty(Obj.Alias)){ %>
                            <button class="btn btn-link btnChangeAlias" data-id="<%=Obj.RowId %>" data-toggle="modal" data-target="#changeAliasModal">Tạo địa chỉ ngắn</button>
                        <%}else
                          {%>
                             <a href="/<%=Obj.Alias %>">http://xetui.vn/<%=Obj.Alias %></a>  - <button class="btn  btn-link ChangeAlias" data-id="<%=Obj.RowId %>" data-toggle="modal" data-target="#changeAliasModal">Đổi địa chỉ</button>      
                         <% } %>
                    </div>
              </div>
              <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Tên</label>
                <div class="col-sm-10">
                    <input type="hidden" name="Id"  value="<%=User.Id %>"/>
                  <input type="text" class="form-control" id="Ten" value="<%=User.Ten %>" name="Ten" placeholder="Tên">
                </div>
              </div>
              <div class="form-group">
                <label for="MoTa" class="col-sm-2 control-label">Giới thiệu</label>
                <div class="col-sm-10">
                  <textarea class="form-control" name="MoTa" id="MoTa" rows="3"><%=User.Mota %></textarea>
                </div>
              </div>
              <div class="form-group">
                <label for="Mobile" class="col-sm-2 control-label">Mobile</label>
                <div class="col-sm-10">
                  <input type="text" class="form-control" id="Mobile"  value="<%=User.Mobile %>" name="Mobile" placeholder="Mobile">
                  <p class="help-block">
                      Nhập số mobile xịn hoặc bỏ trống
                  </p>
                </div>
              </div>
              <div class="form-group">
                <label for="TinhList" class="col-sm-2 control-label">Khu vực</label>
                <div class="col-sm-10">
                    <HeThong:DanhMucListByLdmMa ClientIDMode="Static" ID="TinhList" runat="server" ControlId="Tinh_ID" ControlName="Tinh_ID"/>
                  <p class="help-block">
                      Dành cho việc tụ tập lái xe
                  </p>
                </div>
              </div>
              <%--<div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                  <div class="checkbox">
                    <label>
                      <input type="checkbox"> Remember me
                    </label>
                  </div>
                </div>
              </div>--%>
              <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                  <a href="javascript:;" class="btn btn-primary btn-lg saveBtn">Lưu thay đổi</a>
                  <br/><br/>
                    <p class="alert alert-danger" style="display: none;"></p>
                    <p class="alert alert-success" style="display: none;"></p>
                </div>
              </div>
            </form>            
        </div>
    </div>
</div>
<script>
    $('.Tinh_ID').val('<%=User.Tinh %>');
</script>
<account:changealias ID="changeAlias" runat="server"/>