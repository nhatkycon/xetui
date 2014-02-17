<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListByHangXe.ascx.cs" Inherits="lib_ui_cars_ListByHangXe" %>
<%@ Register Src="~/lib/ui/cars/templates/Item-ListByHangXe.ascx" TagPrefix="uc1" TagName="ItemListByHangXe" %>
<%@ Register Src="~/lib/ui/hangXe/ListModelByHang.ascx" TagPrefix="uc1" TagName="ListModelByHang" %>

<div class="padding-20">
    <div class="h3-subtitle">
        <a href="/cars/">
            Xe
        </a>&nbsp; &gt;
        <a href="/cars/<%=Item.Ten %>/">
            <%=Item.Ten %>
        </a>        
    </div>
    <hr class="hr comment-hr"/>
    <uc1:ListModelByHang runat="server" id="ListModelByHang" />
    <hr class="hr comment-hr"/>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemListByHangXe runat="server" ID="ItemListByHangXe" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>

