<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhMucListByLdmMa.ascx.cs" Inherits="lib_ui_HeThong_DanhMucListByLdmMa" %>
<%@ Register src="~/lib/ui/HeThong/templates/DanhMucItem.ascx" tagname="DanhMucItem" tagprefix="uc1" %>
<select name="<%=ControlName %>" class="form-control <%=ControlId %>">
    <option value="">Chọn</option>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:DanhMucItem ID="DanhMucItem2" runat="server" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</select>