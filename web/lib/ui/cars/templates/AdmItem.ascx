<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdmItem.ascx.cs" Inherits="lib_ui_cars_templates_AdmItem" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.Duyet ? "success" : "" %>">
    <td class="">
        <a href="/lib/mod/Cars/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Cars/Add.aspx?ID=<%=Item.ID %>">
            <img style="width: 80px; height: 45px;" src="/lib/up/car/<%=Item.Anh %>" class="img-responsive"/>
        </a>
    </td>
    <td class="">
        <a href="/lib/mod/Cars/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
        <a href="<%=Item.XeUrl %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Cars/Default.aspx?HANG_ID=<%=Item.HANG_ID %>">
            <%=Item.HANG_Ten %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Cars/Default.aspx?username=<%=Item.NguoiTao %>">
            <%=Item.NguoiTao_Ten %>
        </a>
    </td>
    <td title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>" class="">
        <%=Lib.TimeDiff(Item.NgayTao)%>
    </td>
    <td class="hidden-xs">
        <%if(Item.Duyet){ %>
        <%=Item.NgayDuyet.ToString("hh:mm dd/MM/yyyy") %> - <%=Item.NguoiDuyet %>
        <%} %>
    </td>
</tr>