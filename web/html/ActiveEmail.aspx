<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="ActiveEmail.aspx.cs" Inherits="html_ActiveEmail" %>
<%@ Register src="~/lib/ui/HeThong/ActiveEmail.ascx" tagPrefix="heThong" tagName="ActiveEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <heThong:ActiveEmail ID="activeEmail" runat="server"/>
</asp:Content>

