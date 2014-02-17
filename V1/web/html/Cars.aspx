<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Cars.aspx.cs" Inherits="html_Cars" %>
<%@ Register Src="~/lib/ui/cars/ListAll.ascx" TagPrefix="uc1" TagName="ListAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListAll runat="server" ID="ListAll" />
</asp:Content>

