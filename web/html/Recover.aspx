<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Recover.aspx.cs" Inherits="html_Recover" %>
<%@ Register src="~/lib/ui/HeThong/QuenMatKhau.ascx" tagPrefix="heThong" tagName="QuenMatKhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <heThong:QuenMatKhau runat="server" ID="QuenMatKhau"/>
</asp:Content>

