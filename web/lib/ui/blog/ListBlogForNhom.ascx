<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListBlogForNhom.ascx.cs" Inherits="lib_ui_blog_ListBlogForNhom" %>
<%@ Register Src="~/lib/ui/blog/templates/ForNhom-Blog-Item.ascx" TagPrefix="uc1" TagName="ForNhomBlogItem" %>

<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ForNhomBlogItem runat="server" ID="ForNhomBlogItem"  Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>