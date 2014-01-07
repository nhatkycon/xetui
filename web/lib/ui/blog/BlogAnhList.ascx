<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogAnhList.ascx.cs" Inherits="lib_ui_blog_BlogAnhList" %>
<%@ Register src="~/lib/ui/blog/templates/BlogAnh-Item.ascx" tagPrefix="temp" tagName="BlogAnhItem" %>
<asp:Repeater runat="server" ID="rpt" Visible="False">
    <ItemTemplate>
        <temp:BlogAnhItem ID="anhItem" runat="server" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater> 