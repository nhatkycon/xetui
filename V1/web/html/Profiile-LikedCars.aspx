<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Profiile-LikedCars.aspx.cs" Inherits="html_Profiile_LikedCars" %>

<%@ Register Src="~/lib/ui/cars/ProfileLikedCars.ascx" TagPrefix="cars" TagName="ProfileLikedCars" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cars:ProfileLikedCars runat="server" ID="ProfileLikedCars" />
</asp:Content>

