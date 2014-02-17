<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_mod_Adv_Add" %>
<%@ Register src="~/lib/ui/adv/Add.ascx" tagPrefix="Adv" tagName="Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <Adv:Add runat="server" ID="Add" />
</asp:Content>

