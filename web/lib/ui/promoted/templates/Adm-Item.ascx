<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adm-Item.ascx.cs" Inherits="lib_ui_promoted_templates_Adm_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.Approved ? "success" : "" %>">
    <td class="">
        <a href="/lib/mod/promoted/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/promoted/Add.aspx?ID=<%=Item.ID %>">
            <img style="width: 80px; " src="/lib/up/promoted/<%=Item.Anh %>" class="img-responsive"/>
        </a>
    </td>
    <td class="">
        <a href="/lib/mod/promoted/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
        <a href="<%=Item.Url %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td>
        <%=Item.LoaiTen %>
    </td>
    <td class="hidden-xs">
        <%=(Item.NgayBatDau != DateTime.MinValue) ? Item.NgayBatDau.ToString("dd-MM-yy") : "" %> - 
        <%=(Item.NgayKetThuc != DateTime.MinValue) ? Item.NgayKetThuc.ToString("dd-MM-yy") : ""%>
    </td>
    <td class="hidden-xs">
        <%=string.Format("{0}-{1}",Item.Clicked, Item.Views) %>
    </td>
    <td title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>"  class="hidden-xs">
        <%=Lib.TimeDiff(Item.NgayTao)%> - 
        <a href="/lib/mod/Cars/Default.aspx?username=<%=Item.NguoiTao %>">
            <%=Item.NguoiTao %>
        </a>
    </td>
    <td class="hidden-xs">
        <%if(Item.Approved){ %>
            <%=Item.ApprovedDate.ToString("hh:mm dd/MM/yyyy") %> - <%=Item.ApprovedBy %>
        <%} %>
    </td>
</tr>