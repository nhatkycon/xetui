<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="NhomUnApproved.aspx.cs" Inherits="html_NhomUnApproved" %>
<%@ Register src="~/lib/ui/nhom/WaitingForApproved.ascx" tagPrefix="nhom" tagName="UnApproved" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <nhom:UnApproved ID="UnApproved1" runat="server" />
</asp:Content>

