<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_mod_BinhLuan_Default" %>

<%@ Register Src="~/lib/ui/binhLuan/AdminList.ascx" TagPrefix="uc1" TagName="AdminList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AdminList runat="server" id="AdminList" />
</asp:Content>

