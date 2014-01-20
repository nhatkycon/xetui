<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Home.ascx.cs" Inherits="lib_ui_promoted_Home" %>
<%@ Register src="~/lib/ui/promoted/templates/Item-Home.ascx" tagPrefix="temp" tagName="ItemHome" %>
<%@ Register src="~/lib/ui/promoted/templates/Item-HomeBig.ascx" tagPrefix="temp" tagName="ItemHomeBig" %>
<div class="x-col x4 cars-home-1st-list">
    <temp:ItemHomeBig runat="server" ID="ItemBig" />
</div>
<div class="x-col x2 cars-home-2nd-list">
    <asp:Repeater runat="server" ID="homeMedium">
        <ItemTemplate>
            <temp:ItemHome runat="server" ID="AdmItem1" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="x-col x1 cars-home-3rd-list">
    <asp:Repeater runat="server" ID="homeSmall">
        <ItemTemplate>
            <temp:ItemHome runat="server" ID="AdmItem1" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>
</div>