<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListByModelXe.ascx.cs" Inherits="lib_ui_cars_ListByModelXe" %>
<%@ Register Src="~/lib/ui/cars/templates/Item-ListByHangXe.ascx" TagPrefix="uc1" TagName="ItemListByHangXe" %>
<%@ Register Src="~/lib/ui/hangXe/ListModelByHang.ascx" TagPrefix="uc1" TagName="ListModelByHang" %>

<div class="padding-20">
    <div class="h3-subtitle">
        <a href="/cars/">
            Xe
        </a>&nbsp; &gt;
        <a href="/cars/<%=Item.Hang.Ten %>/">
            <%=Item.Hang.Ten %>
        </a>&nbsp; &gt;
        <a href="/cars/<%=Item.Hang.Ten %>/<%=Item.Ten %>/">
            <%=Item.Ten %>
        </a>
    </div>
    <hr class="hr comment-hr"/>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemListByHangXe runat="server" ID="ItemListByHangXe" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>