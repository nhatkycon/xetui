<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_mod_Adv_Default" %>
<%@ Register src="~/lib/ui/adv/AdmList.ascx" tagPrefix="Adv" tagName="List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <Adv:List ID="List" runat="server" />
</asp:Content>

