<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="html_MyAccount" %>
<%@ Register src="~/lib/ui/account/myAccount.ascx" tagPrefix="account" tagName="myAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <account:myAccount ID="myAcc" runat="server"/>
</asp:Content>

