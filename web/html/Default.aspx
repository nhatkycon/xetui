<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="html_Default" %>

<%@ Register src="ui/left-navigation.ascx" tagname="left" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:left ID="left1" runat="server" />
    <div class="row-home">
        <img class="img-responsive" src="/html/img/car/big_1.jpg"/>
    </div>    
</asp:Content>

