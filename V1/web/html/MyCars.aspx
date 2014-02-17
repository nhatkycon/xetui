<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="MyCars.aspx.cs" Inherits="html_MyCars" %>
<%@ Register tagPrefix="cars" tagName="myCars" src="~/lib/ui/cars/myCars.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cars:myCars runat="server" ID="myCars" />
</asp:Content>

