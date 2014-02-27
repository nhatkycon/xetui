<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListHangXe.ascx.cs" Inherits="lib_ui_hangXe_ListHangXe" %>
<%@ Register Src="~/lib/ui/hangXe/templates/Item-Hang.ascx" TagPrefix="uc1" TagName="ItemHang" %>
<asp:Repeater runat="server" ID="otoRpt">
    <ItemTemplate>
        <uc1:ItemHang runat="server" id="ItemHang" Item='<%# Container.DataItem %>'/>
    </ItemTemplate>
</asp:Repeater>
<hr class="hr comment-hr"/>
<div class="h3-subtitle">
        <a href="/cars/">
            Xe máy
        </a> 
    </div>
<hr class="hr comment-hr"/>
<asp:Repeater runat="server" ID="xeMayRpt">
    <ItemTemplate>
        <uc1:ItemHang runat="server" id="ItemHang" Item='<%# Container.DataItem %>'/>
    </ItemTemplate>
</asp:Repeater>