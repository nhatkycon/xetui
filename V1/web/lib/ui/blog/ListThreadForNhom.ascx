<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListThreadForNhom.ascx.cs" Inherits="lib_ui_blog_ListThreadForNhom" %>
<%@ Register TagPrefix="uc1" TagName="ForNhomBlogItem" Src="~/lib/ui/blog/templates/ForNhom-Blog-Item.ascx" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ForNhomBlogItem runat="server" ID="ForNhomBlogItem"  Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>