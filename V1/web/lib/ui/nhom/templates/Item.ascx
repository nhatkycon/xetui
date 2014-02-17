<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_nhom_templates_Item" %>
<tr data-id="<%=Item.Id %>" data-member="<%=Item.TotalMember %>" data-name="<%=Item.Ten %>">
    <td class="nhom-itemInList-sort">
    </td>
    <td class="nhom-itemInList-sort-name">
        <a href="<%=Item.Url %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td class="nhom-itemInList-members">
        <%=Item.TotalMember %>
    </td>
</tr>