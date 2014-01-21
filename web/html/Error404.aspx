<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Error404.aspx.cs" Inherits="html_Error404" %>
<%@ Register src="~/lib/ui/HeThong/Error404.ascx" tagPrefix="heThong" tagName="Error404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <heThong:Error404 runat="server" ID="Error404"/>
</asp:Content>

