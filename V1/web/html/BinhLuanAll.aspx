<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="BinhLuanAll.aspx.cs" Inherits="html_BinhLuanAll" %>
<%@ Register src="~/lib/ui/binhLuan/ListAll.ascx" tagPrefix="binhLuan" tagName="ListAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%=Item.Ten %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <binhLuan:ListAll ID="ListAll" runat="server" />
</asp:Content>

