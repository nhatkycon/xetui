<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/admin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_mod_Cars_Add" %>
<%@ Register TagPrefix="cars" TagName="Add" Src="~/lib/ui/cars/Add.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <a href="/lib/mod/Cars/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>            
        </div>
        <div class="panel-body">
            <cars:Add runat="server" id="Add" />
        </div>
    </div>
</asp:Content>

