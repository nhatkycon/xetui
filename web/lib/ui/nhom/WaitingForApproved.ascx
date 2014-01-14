﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WaitingForApproved.ascx.cs" Inherits="lib_ui_nhom_WaitingForApproved" %>
<div class="padding-20">
    <div class="h3-subtitle">
            <a href="/group/">Cộng đồng</a>&nbsp; &gt;
            <%=Item.Ten %>
        </div>
        <hr class="hr comment-hr"/>
        <h1>
            Cộng đồng <strong><%=Item.Ten %></strong>
             đang chờ duyệt trước khi công khai
        </h1>
        <p class="help-block">
            Đây là quy định nhằm bảo vệ lái xe và nâng cao chất lượng nội dung trên XETUI.VN<br/>
            Nếu bạn phiền lòng vì nó, xin vui lòng e-mail nhanh cho <a href="mailto:support@xetui.vn">support@xetui.vn</a> để chúng tôi duyệt nhanh hơn quy định.
        </p>
</div>