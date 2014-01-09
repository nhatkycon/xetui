<%@ Control Language="C#" AutoEventWireup="true" CodeFile="homeSmallList.ascx.cs" Inherits="lib_ui_cars_homeSmallList" %>
<%@ Register src="~/lib/ui/cars/templates/homeSmall-item.ascx" tagPrefix="temp" tagName="homeSmallItem" %>
<div class="padding-20">
    <div class="home-title">
        <%=Title %>
    </div>
    <div class="user-home-box">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <temp:homeSmallItem runat="server" ID="homeSmallItem"  Item='<%# Container.DataItem %>'/>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
