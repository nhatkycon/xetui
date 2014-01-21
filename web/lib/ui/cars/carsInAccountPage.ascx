<%@ Control Language="C#" AutoEventWireup="true" CodeFile="carsInAccountPage.ascx.cs" Inherits="lib_ui_cars_carsInAccountPage" %>
<%@ Register src="~/lib/ui/cars/templates/carInAccountPage-item.ascx" tagPrefix="temp" tagName="carInAccountPageItem" %>
<hr class="hr comment-hr"/>
<h3 class="h3-subtitle">
    <%=Ten %>    
</h3>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>        
        <temp:carInAccountPageItem runat="server" ID="carInAccountPageItem" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>