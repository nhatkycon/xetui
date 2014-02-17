<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adm-Item.ascx.cs" Inherits="lib_ui_users_templates_Adm_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.XacNhan ? "success" : "" %>">
    <td class="">
        <a href="/lib/mod/Users/Add.aspx?ID=<%=Item.Id %>">
            <%=Item.Id %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Users/Add.aspx?ID=<%=Item.Id %>">
            <img style="width: 45px; height: 45px;" src="/lib/up/users/<%=Item.Anh %>" class="img-responsive"/>
        </a>
    </td>
    <td class="">
        <a href="/lib/mod/Users/Add.aspx?ID=<%=Item.Id %>">
            <%=Item.Ten %>
        </a>
        <a href="<%=Item.Url %>" class="btn btn-default btn-xs">
            <i class="glyphicon glyphicon-link"></i>
        </a>
    </td>
    <td class="hidden-xs">
        <%=Item.Email %>
    </td>
    <td class="hidden-xs">
        <a href="/lib/mod/Users/Default.aspx?username=<%=Item.NguoiTao %>">
            <%=Item.Username %>
        </a>
    </td>
    <td title="<%=Item.NgayTao.ToString("hh:mm dd/MM/yyyy") %>" class="">
        <%=Lib.TimeDiff(Item.NgayTao)%>
    </td>
    <td class="hidden-xs">
        <%if(Item.XacNhan){ %>
            <%=Lib.TimeDiff(Item.NgayXacNhan)%>
        <%} %>
    </td>
</tr>