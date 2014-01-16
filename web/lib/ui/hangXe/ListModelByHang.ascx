<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListModelByHang.ascx.cs" Inherits="lib_ui_hangXe_ListModelByHang" %>
<%@ Register Src="~/lib/ui/hangXe/templates/Item-ModelByHang.ascx" TagPrefix="uc1" TagName="ItemModelByHang" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemModelByHang runat="server" id="ItemModelByHang" Item='<%# Container.DataItem %>'/>
    </ItemTemplate>
</asp:Repeater>