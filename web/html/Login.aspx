<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="html_Login" %>

<%@ Register Src="~/lib/ui/HeThong/loginFlat.ascx" TagPrefix="uc1" TagName="loginFlat" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:loginFlat runat="server" ID="loginFlat" />
</asp:Content>

