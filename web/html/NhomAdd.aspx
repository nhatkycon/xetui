<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="NhomAdd.aspx.cs" Inherits="html_NhomAdd" %>
<%@ Register Src="~/lib/ui/nhom/Add.ascx" TagPrefix="nhom" TagName="Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <nhom:Add runat="server" ID="Add" />
</asp:Content>

