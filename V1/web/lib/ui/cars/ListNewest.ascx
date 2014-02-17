<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNewest.ascx.cs" Inherits="lib_ui_cars_ListNewest" %>
<%@ Register Src="~/lib/ui/cars/templates/Item-ListByHangXe.ascx" TagPrefix="uc1" TagName="ItemListByHangXe" %>
<div class="padding-20">
    <div class="h3-subtitle">
        <a href="/cars/">
            Xe
        </a>&nbsp; &gt;
        <a href="/cars/Newsest/">
            Xe mới
        </a>        
    </div>    
    <hr class="hr comment-hr"/>    
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemListByHangXe runat="server" ID="ItemListByHangXe" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>