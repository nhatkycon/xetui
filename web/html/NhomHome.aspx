<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="NhomHome.aspx.cs" Inherits="html_NhomHome" %>
<%@ Register Src="~/lib/ui/nhom/NhomView.ascx" TagPrefix="uc1" TagName="NhomView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:NhomView runat="server" ID="NhomView" />
</asp:Content>

