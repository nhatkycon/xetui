<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="html_Profile" %>
<%@ Register src="~/lib/ui/account/profile.ascx" tagPrefix="account" tagName="profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%=Item.Ten %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <account:profile ID="profile" runat="server"/>
</asp:Content>

