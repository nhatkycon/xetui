<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="CarByHangXe.aspx.cs" Inherits="html_CarByHangXe" %>

<%@ Register Src="~/lib/ui/cars/ListByHangXe.ascx" TagPrefix="uc1" TagName="ListByHangXe" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%=Item.Ten %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListByHangXe runat="server" ID="ListByHangXe" />
</asp:Content>

