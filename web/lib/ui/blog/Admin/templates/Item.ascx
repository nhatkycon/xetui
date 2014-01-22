﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_blog_Admin_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.Publish ? "success" : "" %>">
    <td class="">
        <a href="/lib/mod/Users/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Users/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.LoaiTen %>
        </a>
    </td>
    <td class="">
        <a href="/lib/mod/Users/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
        <a href="<%=Item.Url %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Users/Default.aspx?username=<%=Item.NguoiTao %>">
            <%=Item.MemberNguoiTao.Ten %>
        </a>
        <a href="<%=Item.MemberNguoiTao.Url %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>" class="">
        <%=Lib.TimeDiff(Item.NgayTao)%>
    </td>
    <td class="hidden-xs">
        <%if(Item.Publish){ %>
            Duyệt
        <%} %>
    </td>
</tr>