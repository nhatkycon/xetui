<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Nhom-Info.ascx.cs" Inherits="lib_ui_nhom_Nhom_Info" %>
<%@ Import Namespace="linh.common" %>
<div class="nhomItem-infoBox">
    <div class="nhomItem-infoBox-avatar">
        <img src="/lib/up/nhom/<%=Item.Anh %>"/>
    </div>
    <div class="nhomItem-infoBox-note">
        <%if(Item.TotalMember > 1){ %>
            <a href="<%=Item.Url %>members/"><%=Item.TotalMember %></a> thành viên <br/>
        <%} %>
        Hoạt động từ <%=Lib.TimeDiff(Item.NgayTao) %><br/>
        Tạo bởi: <a href="<%=Item.Member.Url %>">
                 <%=Item.Member.Ten %>
             </a>
    </div>
    <div class="nhomitem-infoBox-buttons">
        <%if(!Item.IsAdmin){ %>
            <%if(Item.Joined){ %>
                <button class="btn btn-default joinGroupBtn" data-joined="1" data-id="<%=Item.ID %>" title="Hủy tham gia <%=Item.Ten %>">Ngừng tham gia</button>
            <%}else{ %>
                <%if(Item.IsPendingMember){ %>
                    <button class="btn btn-default" data-joined="0" data-id="<%=Item.ID %>" title="Đăng ký tham gia <%=Item.Ten %>">Đã gửi yêu cầu</button>
                <%}else{ %>
                    <button class="btn btn-default joinGroupBtn" data-joined="0" data-id="<%=Item.ID %>" title="Đăng ký tham gia <%=Item.Ten %>">Tham gia</button>
                <%} %>
            <%} %>
        <%}else{ %>
            <a href="<%=Item.Url %>admin/" class="btn btn-default" title="Quản lý <%=Item.Ten %>">
                Quản lý
            </a>
        <%} %>
    </div>
    <hr class="hr comment-hr"/>
    <div class="nhomItem-infoBox-rules-header">
        Quy định
    </div>
    <div class="nhomItem-infoBox-rules">
        <%=Item.GioiThieu %>
    </div>
</div>