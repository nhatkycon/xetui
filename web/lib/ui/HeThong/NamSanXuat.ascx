<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NamSanXuat.ascx.cs" Inherits="lib_ui_HeThong_NamSanXuat" %>
<select name="<%=ControlName %>" class="form-control <%=ControlId %>">
    <option value="">--</option>
    <% foreach (var item in List)
       {%>
        <option value="<%=item %>"><%=item %></option>
    <%} %>  
</select>