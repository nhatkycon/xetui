<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="NhomAdmin.aspx.cs" Inherits="html_NhomAdmin" %>
<%@ Register Src="~/lib/ui/nhom/Admin.ascx" TagPrefix="uc1" TagName="Admin" %>
<%@ Register Src="~/lib/ui/nhom/AdminUnAuthorize.ascx" TagPrefix="uc1" TagName="AdminUnAuthorize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Admin runat="server" Visible="False" ID="Admin" />
    <uc1:AdminUnAuthorize runat="server" ID="AdminUnAuthorize" />
</asp:Content>

