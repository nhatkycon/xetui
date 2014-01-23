<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListTop.ascx.cs" Inherits="lib_ui_cars_ListTop" %>
<%@ Register Src="~/lib/ui/cars/templates/Item-ListByHangXe.ascx" TagPrefix="uc1" TagName="ItemListByHangXe" %>
<div class="padding-20">
    <div class="h3-subtitle">
        <a href="/cars/">
            Xe
        </a>&nbsp; &gt;
        <a href="/cars/Top/">
            Top 100
        </a>        
    </div>    
    <hr class="hr comment-hr"/>
    <div class="alert alert-info">
        Tiêu chí do cộng đồng xế trên Xetui.vn bình chọn
    </div>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemListByHangXe runat="server" ID="ItemListByHangXe" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>