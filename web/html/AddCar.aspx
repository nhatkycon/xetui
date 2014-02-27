<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="AddCar.aspx.cs" Inherits="html_AddCar" %>

<%@ Register Src="~/lib/ui/cars/Add.ascx" TagPrefix="cars" TagName="Add" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <cars:Add runat="server" id="Add" />
</asp:Content>

