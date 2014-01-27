<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="html_Search" %>
<%@ Register src="~/lib/ui/HeThong/Search.ascx" tagPrefix="heThong" tagName="search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <heThong:search ID="search1" runat="server"/>
    <%if(!string.IsNullOrEmpty(Paging)){ %>
    <ul class="pagination">
        <%=Paging %>
    </ul>
    <%} %>
</asp:Content>

