<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_mod_Nhom_Default" %>
<%@ Register TagPrefix="uc1" TagName="AdmList" Src="~/lib/ui/nhom/AdmList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AdmList runat="server" ID="AdmList" />
</asp:Content>

