﻿<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="NhomBlogs.aspx.cs" Inherits="html_NhomBlogs" %>
<%@ Register Src="~/lib/ui/blog/NhomBlog/ListFull.ascx" TagPrefix="blog" TagName="ListFull" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <blog:ListFull runat="server" ID="ListBlogForNhomFull1" />
</asp:Content>

