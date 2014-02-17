<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvList.ascx.cs" Inherits="lib_ui_adv_AdvList" %>
<%@ Register src="~/lib/ui/adv/templates/Adv-Item.ascx" tagPrefix="temp" tagName="AdvItem" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <temp:AdvItem runat="server" ID="AdvItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>