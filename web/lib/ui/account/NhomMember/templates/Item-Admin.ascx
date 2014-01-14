<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Admin.ascx.cs" Inherits="lib_ui_account_NhomMember_templates_Item_Admin" %>
<%@ Import Namespace="linh.common" %>
<div class="NhomMemberPending-Item">
    <div class="row">
        <div class="col-md-8">
            <%=Item.Member.Vcard %>    
        </div>
        <div class="col-md-4">
            <div class="pull-right">
                <p class="help-block">
                    <% switch (Item.ModLoai)
                       {%>
                    <%case 1: %>
                    Duyệt thành viên
                    <% break; %>

                    <%case 2: %>
                    Duyệt blog
                    <% break; %>
                    
                    <%case 3: %>
                    Duyệt diễn đàn
                    <% break; %>
                    
                    <%case 4: %>
                    Duyệt hỏi đáp
                    <% break; %>
                    
                    <%case 5: %>
                    Admin
                    <% break; %>
                    
                    <%case 0: %>
                        <%=Lib.TimeDiff(Item.NgayTao) %>
                    <% break; %>
                    <% } %>
                </p>
                <div class="btn-group btn-xs">
                  <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                    Quyền <span class="caret"></span>
                  </button>
                  <ul class="dropdown-menu" role="menu">
                    <li class="phanQuyenMemberBtn" data-loai="1" data-id="<%=Item.ID %>">
                        <a href="javascript:;">Duyệt thành viên</a>
                    </li>
                    <li class="phanQuyenMemberBtn" data-loai="2" data-id="<%=Item.ID %>">
                        <a href="javascript:;">Duyệt blog</a>
                    </li>
                    <li class="phanQuyenMemberBtn" data-loai="3" data-id="<%=Item.ID %>">
                        <a href="javascript:;">Duyệt diễn đàn</a>
                    </li>
                    <li class="phanQuyenMemberBtn" data-loai="5" data-id="<%=Item.ID %>">
                        <a href="javascript:;">Admin</a>
                    </li>
                    <li class="divider"></li>
                    <li class="phanQuyenMemberBtn" data-loai="0" data-id="<%=Item.ID %>">
                        <a href="javascript:;">Thành viên thường</a>
                    </li>
                  </ul>
                </div>
                <button title="Xóa" class="btn btn-default removeMemberBtn" data-id="<%=Item.ID %>">
                    <i class="glyphicon glyphicon-remove"></i>
                </button>
            </div>        
        </div>
    </div>
    <hr class="comment-hr hr"/>
</div>
