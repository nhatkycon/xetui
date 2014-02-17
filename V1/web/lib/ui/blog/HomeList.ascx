<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HomeList.ascx.cs" Inherits="lib_ui_blog_HomeList" %>
<%@ Register src="~/lib/ui/blog/templates/homeItem.ascx" tagPrefix="temp" tagName="homeItem" %>
<div class="">
    <div class="home-title">
        <%=Title %>
    </div>
    <div class="user-home-box">
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <temp:homeItem runat="server" ID="homeItem"  Item='<%# Container.DataItem %>'/>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

