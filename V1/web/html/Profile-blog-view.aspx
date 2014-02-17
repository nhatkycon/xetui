<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Profile-blog-view.aspx.cs" Inherits="html_Profile_blog_view" %>
<%@ Register src="~/lib/ui/blog/ViewForProfile.ascx" tagPrefix="blog" tagName="ViewForProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <blog:ViewForProfile runat="server" Id="ViewForProfile"/>
</asp:Content>

