<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_mod_Blog_Add" %>
<%@ Register src="~/lib/ui/blog/Admin/Add.ascx" tagPrefix="blog" tagName="Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <blog:Add ID="Add" runat="server" />
</asp:Content>

