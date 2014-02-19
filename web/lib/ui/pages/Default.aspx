<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Normal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%=Request.Url.PathAndQuery %>
</asp:Content>

