<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="car-view.aspx.cs" Inherits="html_car_view" %>
<%@ Register src="~/lib/ui/cars/view.ascx" tagPrefix="cars" tagName="view" %>
<%@ Register src="~/lib/ui/cars/Missing.ascx" tagPrefix="cars" tagName="Missing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%=Item.Ten %></title>
    <meta property="fb:admins" content="740919195"/>
    <meta property="fb:app_id" content="372490826229164"/>
    <meta property="og:title" content="Video: <%=Item.Ten %>" />
    <meta property="og:description" content="<%=Item.Ten %>" />
    <% if (!string.IsNullOrEmpty(Item.Anh))
        { %>
    <meta property="og:image" content="http://xetui.vn/lib/up/car/<%=Item.Anh %>" />
    <% }%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cars:view Id="view" runat="server"/>
    <cars:Missing ID="Missing" runat="server" />
</asp:Content>

