<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="car-blog-view.aspx.cs" Inherits="html_car_blog_view" %>
<%@ Register src="~/lib/ui/blog/ViewForCar.ascx" tagPrefix="blog" tagName="ViewForCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <blog:ViewForCar Id="viewForCar" runat="server"/>
</asp:Content>

