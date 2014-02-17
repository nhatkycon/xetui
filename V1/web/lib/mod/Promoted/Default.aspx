<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_mod_Promoted_Default" %>
<%@ Register src="~/lib/ui/promoted/Adm-List.ascx" tagPrefix="promoted" tagName="AdmList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <promoted:AdmList ID="List" runat="server"/>
</asp:Content>

