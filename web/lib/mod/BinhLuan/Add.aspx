<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_mod_BinhLuan_Add" %>

<%@ Register Src="~/lib/ui/binhLuan/AdminAdd.ascx" TagPrefix="uc1" TagName="AdminAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AdminAdd runat="server" ID="Add" />
</asp:Content>

