<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="car-blog.aspx.cs" Inherits="html_car_blog" %>
<%@ Register TagPrefix="blog" TagName="ListForCarFull" Src="~/lib/ui/blog/ListForCarFull.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <blog:ListForCarFull Id="ListForCarFull" runat="server"/>
</asp:Content>

