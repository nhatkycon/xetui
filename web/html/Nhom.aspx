<%@ Page Title="" Language="C#" MasterPageFile="~/html/MasterPage.master" AutoEventWireup="true" CodeFile="Nhom.aspx.cs" Inherits="html_Nhom" %>

<%@ Register Src="~/lib/ui/nhom/List.ascx" TagPrefix="uc1" TagName="List" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-8">
            <uc1:List runat="server" ID="List" />            
        </div>
        <div class="col-md-4">
            
        </div>
    </div>
</asp:Content>

