<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListHangXe.ascx.cs" Inherits="lib_ui_hangXe_ListHangXe" %>
<%@ Register Src="~/lib/ui/hangXe/templates/Item-Hang.ascx" TagPrefix="uc1" TagName="ItemHang" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemHang runat="server" id="ItemHang" Item='<%# Container.DataItem %>'/>
    </ItemTemplate>
</asp:Repeater>