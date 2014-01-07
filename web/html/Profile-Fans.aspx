<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Profile-Fans.aspx.cs" Inherits="html_Profile_Fans" %>
<%@ Register src="~/lib/ui/account/Profile-fans.ascx" tagPrefix="account" tagName="ProfileFans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <account:ProfileFans ID="ProfileFans" runat="server" />
</asp:Content>

