<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_mod_Users_Default" %>
<%@ Register src="~/lib/ui/users/AdmList.ascx" tagPrefix="users" tagName="AdmList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <users:AdmList ID="AdminList" runat="server"/>
</asp:Content>

