<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="BlogAdd.aspx.cs" Inherits="html_BlogAdd" %>

<%@ Register Src="~/lib/ui/blog/Add.ascx" TagPrefix="blog" TagName="Add" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <blog:Add runat="server" Id="Add" />
</asp:Content>

