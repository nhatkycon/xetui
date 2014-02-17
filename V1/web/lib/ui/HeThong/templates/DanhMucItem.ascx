<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhMucItem.ascx.cs" Inherits="lib_ui_HeThong_templates_DanhMucItem" %>
<option value="<%=Item.ID == Guid.Empty  ? string.Empty : Item.ID.ToString() %>">
    <%=Item.Ten %>
</option>