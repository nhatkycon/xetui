<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_mod_Cars_Default" %>

<%@ Register Src="~/lib/ui/cars/AdmDanhSach.ascx" TagPrefix="uc1" TagName="AdmDanhSach" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AdmDanhSach runat="server" ID="AdmDanhSach" />
</asp:Content>

