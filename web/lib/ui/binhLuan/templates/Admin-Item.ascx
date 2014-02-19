<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin-Item.ascx.cs" Inherits="lib_ui_binhLuan_templates_Admin_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="">
    <td class="">
        <a href="/lib/mod/BinhLuan/Add.aspx?ID=<%=Item.Id %>">
            <%=Item.Id %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/BinhLuan/Add.aspx?ID=<%=Item.Id %>">
            <%=Item.NoiDung %>
        </a>
         <a href="<%=Item.Url %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/BinhLuan/Default.aspx?username=<%=Item.Username %>">
            <%=Item.Member.Ten %>
        </a>
        <a href="<%=Item.Member.Username %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>" class="">
        <%=Lib.TimeDiff(Item.NgayTao)%>
    </td>
</tr>