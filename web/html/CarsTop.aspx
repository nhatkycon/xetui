<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="CarsTop.aspx.cs" Inherits="html_CarsTop" %>
<%@ Register Src="~/lib/ui/cars/ListTop.ascx" TagPrefix="uc1" TagName="List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:List runat="server" ID="List" />
</asp:Content>

