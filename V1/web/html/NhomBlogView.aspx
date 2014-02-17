<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="NhomBlogView.aspx.cs" Inherits="html_NhomBlogView" %>

<%@ Register Src="~/lib/ui/blog/NhomBlog/View.ascx" TagPrefix="uc1" TagName="View" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:View runat="server" ID="View" />
</asp:Content>

