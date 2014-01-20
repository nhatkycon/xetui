<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="html_AboutUs" %>
<%@ Register Src="~/lib/ui/HeThong/AboutUs.ascx" TagPrefix="uc1" TagName="AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AboutUs runat="server" id="AboutUs" />
</asp:Content>

