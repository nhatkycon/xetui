<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_blog_NhomBlog_List" %>
<%@ Register Src="~/lib/ui/blog/NhomBlog/templates/Item-Small.ascx" TagPrefix="uc1" TagName="ItemSmall" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemSmall runat="server" ID="ItemSmall" Item='<%# Container.DataItem %>' />
    </ItemTemplate>
</asp:Repeater>