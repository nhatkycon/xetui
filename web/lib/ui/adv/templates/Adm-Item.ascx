<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adm-Item.ascx.cs" Inherits="lib_ui_adv_templates_Adm_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.Duyet ? "success" : "" %>">
    <td class="">
        <a href="/lib/mod/Adv/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.ID %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Adv/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>
    </td>
    <td class="">
        <a href="/lib/mod/Adv/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
        <a href="<%=Item.Url %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Adv/Add.aspx?Loai=<%=Item.Loai %>">
            <%=Item.LoaiTen%>
        </a>        
    </td>
    <td class="hidden-xs">
        <%=string.Format("{0:dd/MM/yy}-{1:dd/MM/yy}",Item.NgayBatDau, Item.NgayKetThuc)%>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Adv/Default.aspx?username=<%=Item.NguoiTao %>">
            <%=Item.NguoiTao %>
        </a>
    </td>
    <td title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>" class="">
        <%=Lib.TimeDiff(Item.NgayTao)%>
    </td>
    <td class="hidden-xs">
        <%if(Item.Duyet){ %>
            <%=Lib.TimeDiff(Item.NgayDuyet)%>
        <%} %>
    </td>
</tr>