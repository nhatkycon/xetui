<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="CarByModelXe.aspx.cs" Inherits="html_CarByModelXe" %>

<%@ Register Src="~/lib/ui/cars/ListByModelXe.ascx" TagPrefix="uc1" TagName="ListByModelXe" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListByModelXe runat="server" ID="ListByModelXe" />
</asp:Content>

