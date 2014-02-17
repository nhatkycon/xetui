<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterDone.aspx.cs" Inherits="html_RegisterDone" %>
<%@ Register src="~/lib/ui/HeThong/Signup-Done.ascx" tagPrefix="heThong" tagName="SignUpDone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <heThong:SignUpDone ID="SignUpDone" runat="server"/>
</asp:Content>

